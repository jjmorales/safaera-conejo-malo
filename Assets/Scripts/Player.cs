using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// player health and life state
public class Player : MonoBehaviour
{   
    public int maxHealth = 100;
    int currHealth;
    PointSystem ps;
    HealthBar healthBar;
    bool immune = false;
    SceneLoader sceneLoader;
    
    
 
    // Start is called before the first frame update
    void Start()
    {
        currHealth = maxHealth;
        
        healthBar = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<HealthBar>();
        sceneLoader = GameObject.FindGameObjectWithTag("SceneLoader").GetComponent<SceneLoader>();
        ps = GameObject.FindGameObjectWithTag("Scoreboard").GetComponent<PointSystem>();    // link score board

        if(healthBar) healthBar.setMaxHealth(maxHealth);

    }

    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag == "Enemy" && !immune){
            TakeDamage(col.gameObject.GetComponent<Enemy>().AttackDamage);
        }
    }

    public void Die(){
        if(healthBar) healthBar.setHealth(0);
        //sceneLoader.LoadLevelSelection();

        // play death animation
        gameObject.GetComponent<Animator>().SetTrigger("Die");
        Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + 0.5f);
    }

    public void TakeDamage(int dmg){
        currHealth -= dmg;

        if(currHealth > 0){
            if(healthBar) healthBar.setHealth(currHealth);
            immune = true;
            StartCoroutine(RedOnHit());
        }

        if(currHealth <= 0) Die();
    }

    public void heal(int healAmount){
        currHealth += healAmount;
        if(healthBar) healthBar.setHealth(currHealth); 
    }

    // tint red on hit
    public IEnumerator RedOnHit(){
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;   // damaged
        immune = true;
        yield return new WaitForSeconds(0.2f);
        
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;   // back to normal
        immune = false;
    }

    public IEnumerator PlayerImmune(){
        immune = true;
        yield return new WaitForSeconds(1f);
        immune = false;
    }

    public bool isImmune(){
        return immune;
    }

    public int getCurrHealth(){
        return currHealth;
    }
}
