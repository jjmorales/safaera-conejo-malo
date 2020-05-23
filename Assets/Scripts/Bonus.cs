using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{

    PointSystem ps;
    Player player;
    public bool isHealth;
    public int healthPoints = 0;
    public bool isPoints;
    public int scorePoints;

    void Start(){
        ps = GameObject.FindGameObjectWithTag("Scoreboard").GetComponent<PointSystem>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    void OnTriggerEnter2D(Collider2D col){

        if(col.gameObject.tag == "Player"){

        if(isPoints){
            ps.customPoint(scorePoints);
        }

        if(isHealth){
            player.heal(healthPoints);
        }
        Destroy(gameObject);

        // point sound effect
        }
    }
}
