using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if(gameObject.GetComponent<Rigidbody2D>()){
            gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
        }
        if(gameObject.GetComponent<CircleCollider2D>()) gameObject.GetComponent<CircleCollider2D>().enabled = false;      
        if(gameObject.GetComponent<Patrol>()) Destroy(gameObject.GetComponent<Patrol>());

        float dtime = 0;
        ps.addPointsKill();

        if(confetti){
        this.GetComponent<ConfettiPoints>().spawnDrop();
        }

        if(animator){
            animator.SetTrigger("Die");
            dtime = this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length;
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
