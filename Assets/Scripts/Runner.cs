using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runner : MonoBehaviour
{
    public int speed;
    public int maxSpeed;
    public float resetTime;
    public float speedUpRate;
    public int rampUp;
    public Animator animator;
    public GameObject mainEnemy;
    Rigidbody2D rb;
    bool jump;

    bool slowed = false;
   

    public CharacterController2D controller;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        animator.SetFloat("Speed", 1);
    }

    void Update(){
        if(Input.GetKeyDown("w")){
            animator.SetBool("Jump", true);
            jump = true;
        }else if(Input.GetKeyUp("w")){
            animator.SetBool("Jump", false);
        }

        if(maxSpeed <= speed){
            CancelInvoke();
            slowed = false;
            mainEnemy.GetComponent<Follow>().chaseReset();
        }
    }

    void ramp(){
        if(speed <= maxSpeed)
        speed += rampUp;

    }

    void FixedUpdate()
    {

        controller.Move(speed * Time.fixedDeltaTime, false, jump);

        jump = false;
    }

    public IEnumerator slowDown(int slowAmount, float slowTime){
        CancelInvoke();
        mainEnemy.GetComponent<Follow>().chaseInc();

        if(!slowed){
        speed -= slowAmount;
        slowed = true;
        }

        yield return new WaitForSeconds(slowTime);

        InvokeRepeating("ramp", Time.time + resetTime, speedUpRate);
        
    }
}
