using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{

    PointSystem ps;

    void Start(){
        ps = GameObject.FindGameObjectWithTag("Scoreboard").GetComponent<PointSystem>();
    }
    void OnTriggerEnter2D(Collider2D col){
        Debug.Log("enter");
        ps.addPointsBonus();

        // point sound effect
        
        Destroy(gameObject);

    }
}
