using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfettiPoints : MonoBehaviour
{
    public Transform [] spawnPoints;
    public GameObject spawnee;

    public void spawnDrop(){

        foreach(Transform point in spawnPoints){
            Instantiate(spawnee, point.position, point.rotation);
        }
    }
}
