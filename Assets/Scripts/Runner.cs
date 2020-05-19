using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runner : MonoBehaviour
{
    public int speed;
    Rigidbody2D rb;
    bool jump;
    public CharacterController2D controller;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
    }

    void Update(){
        if(Input.GetKeyDown("w")){
            jump = true;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        controller.Move(speed * Time.fixedDeltaTime, false, jump);

        jump = false;
    }

    public IEnumerator slowDown(int slowAmount, float slowTime){
        int currSpeed = speed;

        speed -= slowAmount;

        yield return new WaitForSeconds(1f);

        speed = currSpeed;
    }
}
