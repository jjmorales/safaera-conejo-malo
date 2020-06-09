using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropHealth : MonoBehaviour
{

    public GameObject drop;
    public float dropTime;
    public Transform dropPoint;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("dropBonus", dropTime);
    }

    void dropBonus(){
        Instantiate(drop, dropPoint.transform.position, dropPoint.transform.rotation);
    }
}
