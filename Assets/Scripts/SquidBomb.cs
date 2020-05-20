using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquidBomb : MonoBehaviour
{
    public int AttackDamage;
    public int speed;
    public float chaseTime;
    public Vector2 rangeRandomAttack;
    public Animator animator;
    public Collider2D col;
    private float launchTime;
    private bool launching = false;
    private Transform lastPlayerPos;
    private bool isDying = false;

    // Start is called before the first frame update
    void Start()
    {
        launchTime = Random.Range(rangeRandomAttack.x, rangeRandomAttack.y);
        Invoke("attack", launchTime);
    }

    // Update is called once per frame
    void Update()
    {
        if(launching){
            transform.position = Vector2.MoveTowards(transform.position, lastPlayerPos.transform.position, Time.deltaTime * speed);
        }
    }

    void OnTriggerEnter2D(Collider2D col){
        
        if(col.gameObject.tag == "Player"){
            launching = false;
            animator.SetTrigger("Explode");
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().TakeDamage(AttackDamage);
            Destroy (gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length - 2); 

        }
    }

    void attack(){
        lastPlayerPos = GameObject.FindGameObjectWithTag("Player").transform;
        launching = true;
        Invoke("selfDestruct", chaseTime);
    }

    void selfDestruct(){
        launching = false;
        animator.SetTrigger("Explode");        
        Destroy (gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length - 2); 
    }


}
