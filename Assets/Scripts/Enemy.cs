using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int maxHealth = 100;
    public Animator animator;
    public float speed = 2f;
    GameObject targetChase;
    int currHealth;
    PointSystem ps;


    // Start is called before the first frame update
    void Start()
    {
        targetChase = GameObject.FindGameObjectWithTag("Player");
        currHealth = maxHealth;
        ps = GameObject.FindGameObjectWithTag("Scoreboard").GetComponent<PointSystem>();
    
    }

    void Update(){
        // update animator
        // animator.SetFloat("Speed", 1);
        approachPlayer();
    }

    public void takeDamage(int damageTaken){
        currHealth -= damageTaken;

        // hurt animation
        if(currHealth <= 0){
            die();
        }else{
            ps.addPointsDmg();
        }
    }

    void die(){
        ps.addPointsKill();
        Destroy(this.gameObject);
    }

    void approachPlayer(){
        transform.position = Vector2.MoveTowards(transform.position, targetChase.transform.position, Time.deltaTime * speed);

    }
}
