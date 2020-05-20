using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// clamps sides of screen so that player cannot move outside of those clamps
public class CamClamp : MonoBehaviour
{
    public float clampTop;
    public float clampBot;
    public float clampLeft;
    public float clampRight;
    public bool clamp;

    // Update is called once per frame
    void Update()
    {
        if(clamp){
            transform.position = new Vector2(Mathf.Clamp(transform.position.x, clampLeft, clampRight), Mathf.Clamp(transform.position.y, clampBot, clampTop));
        }
    }
}
