using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
[SerializeField] private float thrust;
[SerializeField] private float knockbackTime;

 private void OnTriggerEnter2D(Collider2D collision)
 {
  if (collision.gameObject.CompareTag("Enemy"))
  {
   Rigidbody2D enemy = collision.GetComponent<Rigidbody2D>();
   if (enemy != null)
   {
        enemy.gameObject.GetComponent<Patrol>().toggleKnockback();
        Vector2 difference = enemy.transform.position - transform.position;
        difference = transform.right * thrust;
        enemy.AddForce(difference, ForceMode2D.Impulse);

        StartCoroutine(KnockCoroutine(enemy));
   }
  }
 }

 private IEnumerator KnockCoroutine(Rigidbody2D enemy)
 {
    if(enemy != null){
        yield return new WaitForSeconds(knockbackTime);
        if(enemy) enemy.gameObject.GetComponent<Patrol>().toggleKnockback();
        gameObject.GetComponent<Bullet>().knockingBackDone();
    }
    
 }
}
