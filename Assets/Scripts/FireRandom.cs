﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRandom : MonoBehaviour
{

    public Animator animator;
    public Transform firePoint;

    public GameObject m_BulletObject;
    public Vector2 m_Offset;
    private float m_FireTime = 0.0f;
   
    void Update()
    {
        if(Time.time > this.m_FireTime)
        {
            animator.SetBool("Firing", true);
            this.m_FireTime = Time.time + (float)Random.Range(this.m_Offset.x, this.m_Offset.y);
            Invoke("createBullets",(this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length - 0.5f));
        }else{
            animator.SetBool("Firing", false);
        }
    }

    void createBullets(){
        Instantiate(m_BulletObject, firePoint.transform.position, firePoint.transform.rotation);
    }

  

}