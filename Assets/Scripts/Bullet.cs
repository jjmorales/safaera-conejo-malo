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
    public bool isPlayer = true;
    public GameObject particle;
 
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

                // particle effect for bullet
                Instantiate(particle, gameObject.transform.position, gameObject.transform.rotation);

                // destroy particle after hitstop
                StartCoroutine(WaitForDestroy());
            }
        }else if(!isPlayer){    // enemy damage player
            if(col.gameObject.tag == "Player") GameObject.FindObjectOfType<Player>().TakeDamage(attackDamage);
        }

        // insert instantiation of a collision blaster effect here
    }

    IEnumerator WaitForDestroy(){   // wait for time to be reset from hit stop effect
        while(Time.timeScale != 1){
            yield return null;
        }
        Destroy(gameObject);
    }
}
