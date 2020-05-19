using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    public Transform spawnPoint;

    public GameObject spawnee;
    public Vector2 randomSpawnRange;
    private float spawnTime = 0.0f;
   
    void Update()
    {
        if(Time.time > this.spawnTime)
        {
            this.spawnTime = Time.time + (float)Random.Range(this.randomSpawnRange.x, this.randomSpawnRange.y);
            Instantiate(spawnee, spawnPoint.position, spawnPoint.rotation);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }
}
