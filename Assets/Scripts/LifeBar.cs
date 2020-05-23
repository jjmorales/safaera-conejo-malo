using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{
    public GameObject [] healthPoints;
    public Sprite hollow;
    int currentHealth = 4;

    public void hit(){
        if(currentHealth > 0){
        healthPoints[currentHealth - 1].GetComponent<SpriteRenderer>().sprite = hollow;
        currentHealth--;
        }
    }
}
