using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    public GameObject generate;
    public Transform spawnPoint;

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "Player"){
            Instantiate(generate, spawnPoint.position, gameObject.transform.rotation);
            Destroy(transform.parent.gameObject);
        }
    }
}
