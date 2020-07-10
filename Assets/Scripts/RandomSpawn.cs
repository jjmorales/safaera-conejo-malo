using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    public Transform spawnPoint;

    public GameObject spawnee;
    public Vector2 randomSpawnRange;
    public float spawnTime = 0.0f;
   
    void Update()
    {
        if(Time.timeSinceLevelLoad > this.spawnTime)
        {
            this.spawnTime = Time.timeSinceLevelLoad + (float)Random.Range(this.randomSpawnRange.x, this.randomSpawnRange.y);
            Instantiate(spawnee, spawnPoint.position, spawnPoint.rotation);
        }
    }

}
