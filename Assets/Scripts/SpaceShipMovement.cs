using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipMovement : MonoBehaviour
{

    public CharacterController2D controller;
    float horizontalMove = 0f;
    public float flightSpeed = 40f;
    public float clampTop;
    public float clampBot;
    public float clampLeft;
    public float clampRight;
    public bool clamp;

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * flightSpeed;

        if(clamp){
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, clampLeft, clampRight), Mathf.Clamp(transform.position.y, clampBot, clampTop));
        }

    }

    void FixedUpdate(){
        
        //move character
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, false);
    }
}
