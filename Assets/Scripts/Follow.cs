using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public GameObject target;
    public GameObject [] increments;
    public float speed;
    public bool endGameCatch = false;
    public Animator animator;
    int chaseIndex = 4;


    // Update is called once per frame
    void Update()
    {
        if(chaseIndex > 4){
            chaseIndex = 4;
        }else if(chaseIndex < 0){
            chaseIndex = 0;
        }

        if(chaseIndex != 1){
            animator.SetBool("Close", false);
        }
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(increments[chaseIndex].transform.position.x, -3.81f), Time.deltaTime * speed);
    }

    public void chaseReset(){
        chaseIndex = 4;
    }

    public void chaseInc(){

        chaseIndex = chaseIndex - 1;
        
        if(chaseIndex == 1)
        animator.SetBool("Close", true);
    }

    void OnTriggerEnter2D(Collider2D col){
        if(endGameCatch && col.gameObject.tag == "Player"){
            speed = 0;

            // end game
            col.GetComponent<Runner>().speed = 0;
            col.GetComponent<Runner>().die();
            animator.SetTrigger("Catch");
        }
    }
}
