using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shark : MonoBehaviour
{

    public float thrust;
    public float returnGravity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter2D(Collider2D col){
  
        if(col.gameObject.tag == "Player"){
            //StartCoroutine("gravityAdjust");
            //col.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, thrust), ForceMode2D.Impulse);
            col.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, thrust);
        }
    }

    // IEnumerator gravityAdjust(){
    //     GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().gravityScale = 0;
    //     yield return new WaitForSeconds(returnGravity);
    //             GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().gravityScale = 2;

    // }
    
}
