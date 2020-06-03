using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipBehave : MonoBehaviour
{

    public string direction;
    public int speed;
    public int deathDelay;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        //Destroy(gameObject, deathDelay);
    }

    // Update is called once per frame
    void Update()
    {
        if(direction == "Left" || direction == "Right"){
            rb.velocity = transform.right * speed;
        }else if(direction == "Down" || direction == "Up"){
            rb.velocity = transform.up * speed;

        }
    }
}
