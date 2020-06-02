using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{ 
    // public vars
    public float speed;
    public Rigidbody2D rb;
    public float lastSeen;
    public float chaseSpeed;
    public bool knockedBack = false;
    public Transform groundDetection;
    
    // private vars
    Animator animator;
    bool movingRight = true;
    bool chase = false;
    bool inSight = false;

    private void Start(){
        animator = this.gameObject.GetComponent<Animator>();
    }

    private void FixedUpdate(){

        if(!knockedBack){   // no chasing or mocement if knocked back
            if(chase){  // chase character
                rb.MovePosition((Vector2)transform.position + ((Vector2)transform.right * chaseSpeed * Time.deltaTime));

                // update facing direction
                if(GameObject.FindGameObjectWithTag("Player")){
                    if(transform.position.x < GameObject.FindGameObjectWithTag("Player").transform.position.x){
                        movingRight = true;
                    }else if(transform.position.x > GameObject.FindGameObjectWithTag("Player").transform.position.x){
                        movingRight = false;
                    }
                }
            }else{  // patrol platform
                rb.velocity = transform.right * speed * Time.deltaTime;
            }
        }
    }

    private void Update()
    {
        animator.SetBool("Chase", chase);

        // chase reset on timer
        if(Time.time - lastSeen >= 3){
            chase = false;
        }

        // create rays for potential collisions
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
        

        // player check
        if(playerInfo.collider != null){
            if(playerInfo.transform.tag == "Player"){
                chase = true;
                lastSeen = Time.time;
            }
        }

        // obstacle check
        if(groundInfo.collider == false)
        {   
            chase = false;
            changeDirection();
        }
        if(wallInfo.collider != null){
            if(wallInfo.transform.tag == "Level"){
                chase = false;
                changeDirection();
            }
        }


        spriteCheck();  // fix sprite rotation
    }

    // flip direction (turn)
    void changeDirection(){
        if(movingRight == true){
            movingRight = false;
        }else{
            movingRight = true;
            }
    }

    // check that sprite is facing correct direction
    void spriteCheck(){
        if(movingRight == true){
            transform.eulerAngles = new Vector3(0, 0, 0);
        }else{
            transform.eulerAngles = new Vector3(0, -180, 0);
            }
    }

    // no chasing or movement if knocked back
    public void toggleKnockback(){
        knockedBack = !knockedBack;
    }

    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.transform.tag == "PlayerAttack" || col.gameObject.transform.tag == "Player"){
            chase = true;
            lastSeen = Time.time;
        }

        if(!chase && col.gameObject.transform.tag == "Enemy"){
            changeDirection();
        }
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.transform.tag == "PlayerAttack"){
            chase = true;
            lastSeen = Time.time;
        }
    }    
}

