using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int maxHealth = 100;
    int currHealth;

    // Start is called before the first frame update
    void Start()
    {
        currHealth = maxHealth;
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
}
