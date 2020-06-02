using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 2D player movement, script handles input and sends it to the controller (PlayerControler2D)
public class PlayerMovement2D : MonoBehaviour
{

    public CharacterController2D controller;
    public Animator animator;

    float horizontalMove = 0f;
    public float runSpeed = 40f;
    bool jump = false;
    bool crouch = false;


    void Update()
    {

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;


        // update animator
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        //animator.SetBool("isCrouched", crouch);

        if(Input.GetButton("Jump")){
            animator.SetBool("Jump", true);
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
