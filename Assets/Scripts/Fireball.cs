using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public Vector2 velocity;
    public int speed;
    public int damage;
    Rigidbody2D rigidbody;


    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 6);
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity = gameObject.transform.right * -speed;
    }

    // Update is called once per frame
    void Update()
    {
        if(rigidbody.velocity.y < velocity.y){
            velocity = rigidbody.velocity;
        }
        
    }

    void OnCollisionEnter2D(Collision2D col){
        rigidbody.velocity = new Vector2(velocity.x , -velocity.y);

        if(col.gameObject.tag == "Player"){
            col.gameObject.GetComponent<Player>().TakeDamage(damage);
            explode();
        }

        if(col.contacts[0].normal.x != 0){
            explode();
        }

    }

    void explode(){
        Destroy(gameObject);
    }
}
