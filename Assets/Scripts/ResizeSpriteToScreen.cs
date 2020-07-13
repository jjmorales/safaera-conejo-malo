using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResizeSpriteToScreen : MonoBehaviour
{
  void Resize(GameObject theSprite, Camera theCamera, int fitToScreenWidth, int fitToScreenHeight)
     {        
         SpriteRenderer sr = theSprite.GetComponent<SpriteRenderer>();
 
         theSprite.transform.localScale = new Vector3(1,1,1);
 
         float width = sr.sprite.bounds.size.x;
         float height = sr.sprite.bounds.size.y;
         
         float worldScreenHeight = (float)(theCamera.orthographicSize * 2.0);
         float worldScreenWidth = (float)(worldScreenHeight / Screen.height * Screen.width);
         
         if (fitToScreenWidth != 0)
         {
             Vector2 sizeX = new Vector2(worldScreenWidth / width / fitToScreenWidth,theSprite.transform.localScale.y);
             theSprite.transform.localScale = sizeX;
         }
         
         if (fitToScreenHeight != 0)
         {
             Vector2 sizeY = new Vector2(theSprite.transform.localScale.x, worldScreenHeight / height / fitToScreenHeight);
             theSprite.transform.localScale = sizeY;
         }
     }

    void OnAwake(){

        GameObject sprite = this.gameObject;
        Camera camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

        Resize(sprite, camera, 1,1);
    }
}
