using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 2D player movement, script handles input and sends it to the controller (PlayerControler2D)
public class Surf : MonoBehaviour
{

    public Animator animator;
    public float speed = 40f;
    public GameObject spawnPoint;
    
    float h;
    float v;
    Rigidbody2D rb;


    void Start(){
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

    }

    void OnTriggerEnter2D(Collider2D col){


        if(col.gameObject.tag == "Floor"){
            //splash animation

            //spawn at top of map
            rb.position = spawnPoint.transform.position;

            //velocity and gravity set to 0
            rb.gravityScale = 0;
            rb.velocity = new Vector2(0,0);

            //flash coroutine
            StartCoroutine("respawn");
        }
    }
    void FixedUpdate(){
        rb.velocity = new Vector3 (h * speed, rb.velocity.y, v * speed);
    }

    public IEnumerator respawn(){
        gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;   // spawn
        yield return new WaitForSeconds(2f);
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;   // back to normal
        rb.gravityScale = 2;
    }

    
}
