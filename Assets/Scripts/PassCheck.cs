using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassCheck : MonoBehaviour
{

    LifeBar lifeBar;
    // Start is called before the first frame update
    void Start()
    {
        lifeBar = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<LifeBar>();
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "Enemy"){
            lifeBar.hit();
        }
    }
}
