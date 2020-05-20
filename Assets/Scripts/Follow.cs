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
        Debug.Log(col.tag);
        if(endGameCatch && col.tag == "Player"){

            // end game

            Destroy(col.gameObject);
            speed = 0;
        }
    }
}
