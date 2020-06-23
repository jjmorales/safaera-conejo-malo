using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minion : MonoBehaviour
{
    public int speed;
    Transform player;
    Rigidbody2D rigidbody;
    LookAt2D look;

    bool chase = false;


    // Start is called before the first frame update
    void Start()
    {
        look = GetComponent<LookAt2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update(){
        if(player != null){
            chase = true;
        }

        look.LookAtPlayer();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if(chase){
            Vector2 target = new Vector2(player.position.x , rigidbody.position.y);
            Vector2 newPos = Vector2.MoveTowards(rigidbody.position, target, speed * Time.fixedDeltaTime);
            rigidbody.MovePosition(newPos);
        }
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "Player"){
            player.GetComponent<Player>().TakeDamage(5);
        }
    }
}
