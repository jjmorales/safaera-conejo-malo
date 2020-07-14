using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Animator animator;
    public float delay = 0f;

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "Player"){
            animator.SetTrigger("enterPortal");
            StartCoroutine(col.GetComponent<Player>().Die());
        }
    }
}
