using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipMovement : MonoBehaviour
{

    public CharacterController2D controller;
    float horizontalMove = 0f;
    public float flightSpeed = 40f;

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * flightSpeed;

    }

    void FixedUpdate(){
        
        //move character
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, false);
    }
}
