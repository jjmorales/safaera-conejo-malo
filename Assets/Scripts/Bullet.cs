using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 20f;
    public int attackDamage = 30;
    public Rigidbody2D rb;
    public string direction;

    // Start is called before the first frame update
    void Start()
    {

        if(direction == "Up"){
            rb.velocity = transform.right * speed;
        }else{
            rb.velocity = transform.up * speed;
        }
     
    }

    void OnTriggerEnter2D(Collider2D col){
        Enemy enemy = col.GetComponent<Enemy>();

        Debug.Log("hit " + col);
        Debug.Log(direction);
        // check if collision was on an enemy
        if(enemy != null){
            enemy.takeDamage(attackDamage);
        }

        Destroy(gameObject);

        // insert instantiation of a collision blaster effect here

    }
}
