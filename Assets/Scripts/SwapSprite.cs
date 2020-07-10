using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapSprite : MonoBehaviour
{

    public float timer;
    public Sprite newSprite;

    // Start is called before the first frame update
    void Start()
    {

        Invoke("Effect", timer);
    }

    void Effect(){
        StartCoroutine("Swap");
    }

    IEnumerator Swap(){

        gameObject.GetComponent<SpriteRenderer>().color = Color.black;

        yield return new WaitForSeconds(0.5f);
        
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        gameObject.GetComponent<SpriteRenderer>().sprite = newSprite;

    }
}
