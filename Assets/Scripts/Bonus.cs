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

        if(col.gameObject.tag == "Player"){
        ps.addPointsBonus();
        Destroy(gameObject);

        // point sound effect
        }
    }
}
