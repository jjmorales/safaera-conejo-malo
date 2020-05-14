using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2D : MonoBehaviour
{

    public CharacterController2D controller;
    public Animator animator;

    float horizontalMove = 0f;
    public float runSpeed = 40f;
    bool jump = false;
    bool crouch = false;
    public float clampTop;
    public float clampBot;
    public float clampLeft;
    public float clampRight;
    public bool clamp;

    // Update is called once per frame
    void Update()
    {

        if(!Input.GetKey("q")){
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

            if(clamp){
            transform.position = new Vector2(Mathf.Clamp(transform.position.x, clampLeft, clampRight), Mathf.Clamp(transform.position.y, clampBot, clampTop));
            }
        
        }else{
            horizontalMove = 0;
        }

        // update animator
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        //animator.SetBool("isCrouched", crouch);

        if(Input.GetButtonDown("Jump") && !Input.GetKey("q")){
            jump = true;
        }

        if(Input.GetButtonDown("Crouch")){
            crouch = true;
        }else if(Input.GetButtonUp("Crouch")){
            crouch = false;
        }
    }

    void FixedUpdate(){
        
        //move character
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }

    
}
