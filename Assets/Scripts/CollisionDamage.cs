using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDamage : MonoBehaviour
{
    public int damage;

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "Player"){
            col.gameObject.GetComponent<Player>().TakeDamage(damage);

            //explosion animation
        }
    }
}
