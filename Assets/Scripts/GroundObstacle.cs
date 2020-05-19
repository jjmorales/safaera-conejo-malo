﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundObstacle : MonoBehaviour
{

    public Sprite deathImage;
    public int slowAmount;
    public int slowTime;
    public PointSystem pointSystem;
    Renderer m_Renderer;
    bool working = true;


    // Start is called before the first frame update

    void Start(){
        m_Renderer = GetComponent<Renderer>();
    }

    void Update(){
        if(working == false && m_Renderer.isVisible == false) Destroy(gameObject);
    }
    void OnTriggerEnter2D(Collider2D col){
        if(!col.GetComponent<Player>().isImmune()){
            Debug.Log("HIT");
            StartCoroutine(col.GetComponent<Runner>().slowDown(slowAmount, slowTime));
            StartCoroutine(col.GetComponent<Player>().PlayerImmune());
        }else{
            this.GetComponent<SpriteRenderer>().sprite = deathImage;
            pointSystem.addPointsKill();
        }

        working = false;
    }
}
