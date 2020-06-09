using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleRandomSpawn : MonoBehaviour
{

    public Transform [] spawnPoints;
    public GameObject spawnee;
    public float startFrame = 0;

    public float cycleSpawn;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawn", startFrame, cycleSpawn);
    }

    void spawn(){
        if(spawnPoints.Length > 0){
        int temp = Random.Range(0,spawnPoints.Length);
        Instantiate(spawnee, spawnPoints[temp].transform.position,  spawnPoints[temp].transform.rotation);
        }
    }
}
