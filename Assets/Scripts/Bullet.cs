using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 20f;
    public int attackDamage = 30;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.up * speed;
    }
    
    void OnTriggerEnter2D(Collider2D col){
        col.GetComponent<Enemy>().takeDamage(attackDamage);
        Destroy(gameObject);

    }
}
