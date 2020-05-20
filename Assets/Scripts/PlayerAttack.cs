using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator animator;

    public int attackDamage = 40;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")){

            // charge up
            chargeUpBlaster();
        }
        if(Input.GetButtonDown("Fire1")){
            // shoot
            shootBlaster();
        }
    }


    void chargeUpBlaster(){
        animator.SetBool("ChargeUp", true);
    }

    void shootBlaster(){
        animator.SetBool("ChargeUp", false);
    }

}
