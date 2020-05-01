using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int attackDamage = 40;


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("q")){
            meleeAttack();
        }
    }

    void rangedAttack(){

    }

    void meleeAttack(){
        // play animation
        animator.SetTrigger("Attack");

        // detect enemies in range
        Collider2D [] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        // damage enemy
        foreach(Collider2D enemy in hitEnemies){
            enemy.GetComponent<Enemy>().takeDamage(attackDamage);
        }
    }


    // attack range
    void OnDrawGizmosSelected(){
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
