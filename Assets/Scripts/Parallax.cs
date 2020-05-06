using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// apply to each background layer
public class Parallax : MonoBehaviour
{
    float length, startPos;
    public GameObject cam;
    public float parallax;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;  // length of x of the sprites
        
    }

    // Update is called once per frame
    void Update()
    {
        float temp = (cam.transform.position.x * (1- parallax));    // how far we have moved relative to the camera
        float dist = (cam.transform.position.x * parallax); // how far moved from start point
        transform.position = new Vector3(startPos + dist, transform.position.y, transform.position.z);  // parallax effect occurs here

        if(temp > startPos + length) startPos += length;
        else if (temp< startPos - length) startPos -= length;
    }
}
