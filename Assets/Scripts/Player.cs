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
    bool immune = false;
    
    
 
    // Start is called before the first frame update
    void Start()
    {
        currHealth = maxHealth;
        ps = GameObject.FindGameObjectWithTag("Scoreboard").GetComponent<PointSystem>();    // link score board
        healthBar = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<Slider>();

    }

    void OnCollisionEnter2D(Collision2D col){

        if(col.gameObject.tag == "Enemy" && !immune){
            TakeDamage(col.gameObject.GetComponent<Enemy>().AttackDamage);
        }

            if(currHealth <= 0){
                immune = true;
                currHealth = 0;
                healthBar.value = currHealth;
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

        if(currHealth > 0){
            StartCoroutine(RedOnHit());
        }
    }

    // tint red on hit
    public IEnumerator RedOnHit(){
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;   // damaged
        yield return new WaitForSeconds(0.2f);
        
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;   // back to normal
    }

    public IEnumerator PlayerImmune(){
        immune = true;
        yield return new WaitForSeconds(1f);
        immune = false;
    }

    public bool isImmune(){
        return immune;
    }
}
