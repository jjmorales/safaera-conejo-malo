﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 20f;
    public int attackDamage = 30;
    public Rigidbody2D rb;
    public string direction;
    public bool HitStop = false;
    public bool isPlayer;

    // Start is called before the first frame update
    void Start()
    {
        if(direction == "Horz"){
            rb.velocity = transform.right * speed;
        }else{
            rb.velocity = transform.up * speed;
        }
     
    }

    void OnTriggerEnter2D(Collider2D col){

        if(isPlayer){
            Enemy enemy = col.GetComponent<Enemy>();

            // check if collision was on an enemy
            if(enemy != null){
                col.GetComponent<SpriteRenderer>().color = Color.red;   // damaged

                if(HitStop)
                FindObjectOfType<HitStop>().Stop(0.1f);     // hit stop effect

                enemy.takeDamage(attackDamage);
            }
        }else{
            GameObject.FindObjectOfType<Player>().TakeDamage(attackDamage);
        }

        StartCoroutine(WaitForDestroy());

        // insert instantiation of a collision blaster effect here
    }

    IEnumerator WaitForDestroy(){
        while(Time.timeScale != 1){
            yield return null;
        }
        Destroy(gameObject);
    }
}
