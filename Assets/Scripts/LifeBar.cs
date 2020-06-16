using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{
    public GameObject [] healthPoints;
    public Sprite full;
    public Sprite hollow;
    public int currentHealth;
    Player player;


    void Start(){
        currentHealth = healthPoints.Length;
    }

    public void hit(){
        if(currentHealth > 0){
            healthPoints[currentHealth - 1].GetComponent<SpriteRenderer>().sprite = hollow;
            currentHealth--;
        }
    }

    public void heal(){
        if(currentHealth < healthPoints.Length){
            currentHealth++;
            healthPoints[currentHealth - 1].GetComponent<SpriteRenderer>().sprite = full;
        }else{
            GameObject.FindGameObjectWithTag("Scoreboard").GetComponent<PointSystem>().customPoint(100);
        }
    }
}
