using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;

    private bool movingRight = true;

    public Transform groundDetection;
  

    bool chase = false;
    bool inSight = false;
    public float lastSeen;


    private void Update()
    {

        if(Time.time - lastSeen >= 3){
            chase = false;
        }

        RaycastHit2D groundInfo;
        RaycastHit2D wallInfo;
        RaycastHit2D playerInfo;

        if(movingRight){
            groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 2f);    // floor detection
            wallInfo = Physics2D.Raycast(groundDetection.position, Vector2.right, 2f);     // wall detection
            playerInfo = Physics2D.Raycast(groundDetection.position, Vector2.right, 4f);   // player detection
        }else{
            groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 2f);    // floor detection
            wallInfo = Physics2D.Raycast(groundDetection.position, Vector2.right, -2f);     // wall detection
            playerInfo = Physics2D.Raycast(groundDetection.position, Vector2.right, -4f);   // player detection
        }
        Debug.DrawLine(groundDetection.position, transform.position + Vector3.right * 2f, Color.red);

        if(playerInfo.collider != null){
            if(playerInfo.transform.tag == "Player"){
                chase = true;
                lastSeen = Time.time;
                Debug.Log("GOTchaaa");
            }
        }


        if(chase){
            Transform oldPos = transform;   // save previous transform to compare for facing left/right

            transform.position = Vector2.MoveTowards(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position, 1.6f * speed * Time.deltaTime);

            // update facing direction
            if(transform.position.x > oldPos.position.x){
                movingRight = true;
            }else if(transform.position.x < oldPos.position.x){
                movingRight = false;
            }
        }else{
            transform.position += transform.right * speed * Time.deltaTime;
        }


        // patrol behavior direction toggle on obstacle
        if(groundInfo.collider == false)
        {
            changeDirection();
        }

        if(wallInfo.collider != null){
            if(wallInfo.transform.tag == "Level"){
                changeDirection();
            }
        }

        spriteCheck();
    }

    void changeDirection(){
        if(movingRight == true){
            movingRight = false;
        }else{
            movingRight = true;
            }
    }

    void spriteCheck(){
        if(movingRight == true){
            transform.eulerAngles = new Vector3(0, 0, 0);
        }else{
            transform.eulerAngles = new Vector3(0, -180, 0);
            }
    }
    
}

