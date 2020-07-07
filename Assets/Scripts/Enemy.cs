using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Enemy : MonoBehaviour
{

    public int maxHealth = 100;
    public int AttackDamage = 20;
    public bool confetti = false;
    private Animator animator;
    private int currHealth;
    private PointSystem ps;

    // Start is called before the first frame update
    void Start()
    {
        currHealth = maxHealth;
        ps = GameObject.FindGameObjectWithTag("Scoreboard").GetComponent<PointSystem>();
        if(this.gameObject.GetComponent<Animator>() != null) animator = this.gameObject.GetComponent<Animator>();

    
    }

    public void takeDamage(int damageTaken){
        currHealth -= damageTaken;


        StartCoroutine(RedOnHit()); // damage red tint

        // hurt animation
        if(currHealth <= 0){
            die();
        }else{
            ps.addPointsDmg();
        }
    }

    void die(){
        Destroy(gameObject.GetComponent<Rigidbody2D>());
        float dtime = 0;
        gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
        ps.addPointsKill();

        if(confetti){
        this.GetComponent<ConfettiPoints>().spawnDrop();
        }

        Destroy(gameObject.GetComponent<Patrol>());
        if(animator){
            animator.SetTrigger("Die");
            dtime = this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + 0.2f;
        }

        Destroy (gameObject, dtime);
    }

    // tint enemy red on hit
    IEnumerator RedOnHit(){
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;   // damaged

        yield return new WaitForSeconds(0.2f);
        
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;   // back to normal
    }

    public int getEnemyHealth(){
        return currHealth;
    }

}
