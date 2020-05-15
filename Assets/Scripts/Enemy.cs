using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Enemy : MonoBehaviour
{

    public int maxHealth = 100;
    public int AttackDamage = 20;
    public float speed = 2f;
    int currHealth;
    PointSystem ps;
 
    




    // Start is called before the first frame update
    void Start()
    {
        currHealth = maxHealth;
        ps = GameObject.FindGameObjectWithTag("Scoreboard").GetComponent<PointSystem>();

    
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
        ps.addPointsKill();
        Destroy(this.gameObject);
    }

    // tint enemy red on hit
    IEnumerator RedOnHit(){
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;   // damaged
        yield return new WaitForSeconds(0.2f);
        
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;   // back to normal
    }

    // void approachPlayer(){
    //     transform.position = Vector2.MoveTowards(transform.position, targetChase.transform.position, Time.deltaTime * speed);

    // }
}
