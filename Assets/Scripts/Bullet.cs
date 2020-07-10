using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 20f;
    public int attackDamage = 30;
    public Rigidbody2D rb;
    public string direction;
    public bool HitStop = false;
    public bool knockBack = false;
    public bool isPlayer = true;
    public GameObject particle;
    private bool knockBackDone = true;
 
    // Start is called before the first frame update
    void Start()
    {
        if(direction == "Horz"){
            rb.velocity = transform.right * speed;
        }else{
            rb.velocity = transform.up * speed;
        }

        Destroy(gameObject, 2f);    // destroy bullet after x time
    }
    void OnTriggerEnter2D(Collider2D col){

        if(col.gameObject.tag == "Level"){
            StartCoroutine(WaitForDestroy());
        }

        if(isPlayer){   // player damage enemy
            Enemy enemy = col.gameObject.GetComponent<Enemy>();

            // check if collision was on an enemy
            if(enemy != null){

                enemy.takeDamage(attackDamage);
                                
                // hit stop effect
                if(HitStop) FindObjectOfType<HitStop>().Stop(0.1f);

                // knock back effect
                if(knockBack) knockBackDone = false;

                // particle effect for bullet
                if(particle != null){
                    GameObject effect = Instantiate(particle, gameObject.transform.position, gameObject.transform.rotation);
                    Destroy(effect, 0.2f);
                }

                // destroy particle after hitstop
                StartCoroutine(WaitForDestroy());
            }
        }else if(!isPlayer){    // enemy damage player
            if(col.gameObject.tag == "Player") GameObject.FindObjectOfType<Player>().TakeDamage(attackDamage);
            StartCoroutine(WaitForDestroy());
        }
    }

    IEnumerator WaitForDestroy(){   // wait for time to be reset from hit stop effect
        if(gameObject.GetComponent<SpriteRenderer>()) gameObject.GetComponent<SpriteRenderer>().enabled = false;  // remove sprite
        gameObject.GetComponent<CircleCollider2D>().enabled = false;    // remove collider

        if (transform.childCount > 0){
            if(gameObject.transform.GetChild(0)) Destroy(gameObject.transform.GetChild(0).gameObject);
            if(gameObject.transform.GetChild(1)) Destroy(gameObject.transform.GetChild(1).gameObject);
        }

        while(Time.timeScale != 1 || !knockBackDone){
            
            yield return null;
        }


        Destroy(gameObject);
    }

    public void knockingBackDone(){
        knockBackDone = true;
    }
}
