using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shark : MonoBehaviour
{

    public float thrust;
    public float sinkSpeed;

    int hitCount = 0;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter2D(Collider2D col){
  
        if(col.gameObject.tag == "Player"){
            hitCount++;
            if(hitCount == 1){
                animator.SetTrigger("Hit");
                col.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, thrust);
            }else if(hitCount == 2){
                col.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, thrust);
                gameObject.GetComponent<Rigidbody2D>().gravityScale = sinkSpeed;
            }

        }
    }
    
}
