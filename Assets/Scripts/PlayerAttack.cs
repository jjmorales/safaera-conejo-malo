using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator animator;
    public FindClosest findClosest;
    public Transform attackPointMelee;
    public Transform attackPointRanged;
    public float attackRangeMelee = 0.5f;
    public float attackRangeRange = 0.5f;
    public LayerMask enemyLayers;
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
    
    void meleerangeAuto(){
        // calculate range from closest enemy
        float distance = findClosest.getDistanceFromEnemy(findClosest.getClosestEnemy());
        Debug.Log(distance);
        if(distance > 1.4){
            // ranged attack
            // play animation
            animator.SetTrigger("attackRanged");

            // detect enemies in range
            Collider2D [] hitEnemies = Physics2D.OverlapCircleAll(attackPointRanged.position, attackRangeRange, enemyLayers);

            // damage enemy
            foreach(Collider2D enemy in hitEnemies){
            enemy.GetComponent<Enemy>().takeDamage(attackDamage);
            }
        }else{
            // melee attack
            // play animation
            animator.SetTrigger("attackMelee");

            // detect enemies in range
            Collider2D [] hitEnemies = Physics2D.OverlapCircleAll(attackPointMelee.position, attackRangeMelee, enemyLayers);

            // damage enemy
            foreach(Collider2D enemy in hitEnemies){
                enemy.GetComponent<Enemy>().takeDamage(attackDamage);
            }
        }
    }

    // attack range
    void OnDrawGizmosSelected(){
        Gizmos.DrawWireSphere(attackPointRanged.position, attackRangeRange);
    }
}
