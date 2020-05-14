﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlasterShot : MonoBehaviour
{
    public Transform firePoint;
    public GameObject blaster;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp("q")){
            Shoot();
        }
    }

    void Shoot(){
        Instantiate(blaster, firePoint.transform.position, firePoint.transform.rotation);
    }
}