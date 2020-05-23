using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveIndef : MonoBehaviour
{
    public int speed;
    public GameObject point;
    public int deathDelay;

    void Start(){
        Destroy(gameObject, deathDelay);
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, point.transform.position, Time.deltaTime * speed);
    }
}
