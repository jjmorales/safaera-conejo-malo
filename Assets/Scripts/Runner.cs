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
    Rigidbody2D rb;
    bool jump;

    bool slowed = false;
   

    public CharacterController2D controller;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        InvokeRepeating("ramp", Time.time + resetTime, speedUpRate);
        animator.SetFloat("Speed", 1);
    }

    void Update(){
        if(Input.GetKeyDown("w")){
            animator.SetBool("Jump", true);
            jump = true;
        }else if(Input.GetKeyUp("w")){
            animator.SetBool("Jump", false);
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
        speed -= slowAmount;
        slowed = true;

        yield return new WaitForSeconds(slowTime);

        slowed = false;

        InvokeRepeating("ramp", Time.time + resetTime, speedUpRate);
        
    }
}
