using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public GameObject target;
    public GameObject [] increments;
    public float speed;
    public bool endGameCatch = false;
    int chaseIndex = 4;


    // Update is called once per frame
    void Update()
    {
        if(chaseIndex > 4){
            chaseIndex = 4;
        }else if(chaseIndex < 0){
            chaseIndex = 0;
        }
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(increments[chaseIndex].transform.position.x, -3.81f), Time.deltaTime * speed);
    }

    public void chaseReset(){
        chaseIndex = 4;
    }

    public void chaseInc(){

        chaseIndex = chaseIndex - 1;
    }

    void OnTriggerEnter2D(Collider2D col){
        if(endGameCatch && col.gameObject.tag == "Player"){

            // end game

            col.GetComponent<Player>().Die();
            speed = 0;
        }
    }
}
