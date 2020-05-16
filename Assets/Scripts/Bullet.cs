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
    public GameObject self;
    public bool isPlayer = true;
 
    // Start is called before the first frame update
    void Start()
    {
        if(direction == "Horz"){
            rb.velocity = transform.right * speed;
        }else{
            rb.velocity = transform.up * speed;
        }

        Destroy(self, 3f);
    }
    void OnTriggerEnter2D(Collider2D col){

        if(isPlayer){
            Enemy enemy = col.gameObject.GetComponent<Enemy>();

            // check if collision was on an enemy
            if(enemy != null){
                if(HitStop) FindObjectOfType<HitStop>().Stop(0.1f);     // hit stop effect

                enemy.takeDamage(attackDamage);
            }
        }else if(!isPlayer){
            if(col.gameObject.tag == "Player") GameObject.FindObjectOfType<Player>().TakeDamage(attackDamage);
        }

        if(col.gameObject.tag == "Player" || col.gameObject.tag == "Enemy") StartCoroutine(WaitForDestroy());

        // insert instantiation of a collision blaster effect here
    }

    IEnumerator WaitForDestroy(){
        while(Time.timeScale != 1){
            yield return null;
        }
        Destroy(gameObject);
    }
}
