using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public GameObject target;
    public float speed;
    public bool endGameCatch = false;

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, Time.deltaTime * speed);
    }

    void OnTriggerEnter2D(Collider2D col){
        if(endGameCatch && col.gameObject.tag == "Player"){

            // end game

            col.GetComponent<Player>().TakeDamage(col.GetComponent<Player>().maxHealth);
            speed = 0;
        }
    }
}
