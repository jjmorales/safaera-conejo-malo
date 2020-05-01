using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyObj;
    public GameObject spawner;

    // Update is called once per frame
    void Update()
    {
       if(GameObject.FindGameObjectsWithTag("Enemy").Length == 0){
           Instantiate(enemyObj, new Vector2 (spawner.transform.position.x, spawner.transform.position.y), Quaternion.identity);
       }

    
    }
}
