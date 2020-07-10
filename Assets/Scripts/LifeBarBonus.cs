using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeBarBonus : MonoBehaviour
{
    void Start(){
        Destroy(gameObject, 4);
    }
    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "Player"){
            if(GameObject.FindGameObjectWithTag("HealthBar")) GameObject.FindGameObjectWithTag("HealthBar").GetComponent<LifeBar>().heal();
            Destroy(gameObject);
        }
    }
}
