using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{   
    public int maxHealth = 100;
    int currHealth;
    PointSystem ps;
    Slider healthBar; 
    
 
    // Start is called before the first frame update
    void Start()
    {
        currHealth = maxHealth;
        ps = GameObject.FindGameObjectWithTag("Scoreboard").GetComponent<PointSystem>();    // link score board
        healthBar = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<Slider>();

    }

    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag == "Enemy"){
            TakeDamage(col.gameObject.GetComponent<Enemy>().AttackDamage);
        }

        if(currHealth <= 0){
            Die();
        }
    }

    void Die(){
        ps.deductPointsDeath();

        // play death animation
    }

    public void TakeDamage(int dmg){
        currHealth -= dmg;
        healthBar.value = currHealth;
        StartCoroutine(RedOnHit());
    }

    // tint enemy red on hit
    IEnumerator RedOnHit(){
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;   // damaged
        yield return new WaitForSeconds(0.2f);
        
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;   // back to normal
    }
}
