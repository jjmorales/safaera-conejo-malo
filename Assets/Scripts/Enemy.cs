using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int maxHealth = 100;
    public float speed = 2f;
    GameObject targetChase;
    int currHealth;

    // Start is called before the first frame update
    void Start()
    {
        targetChase = GameObject.FindGameObjectWithTag("Player");
        currHealth = maxHealth;
    
    }

    void Update(){
        approachPlayer();
    }

    public void takeDamage(int damageTaken){
        currHealth -= damageTaken;

        // hurt animation

        if(currHealth <= 0){
            die();
        }
    }

    void die(){
        Destroy(this.gameObject);
    }

    void approachPlayer(){
        transform.position = Vector2.MoveTowards(transform.position, targetChase.transform.position, Time.deltaTime * speed);

    }
}
