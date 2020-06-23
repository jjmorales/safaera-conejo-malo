using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehave : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    public float speed;
    public float attackRange;
    public Animator animator;
    public Enemy enemy;
    public Vector2 spawnOffset;
    public Transform centerSpawn;
    public GameObject [] spawns;
    public GameObject [] spawnPoints;

    LookAt2D look;
    Transform player;
    bool chase = true;
    bool stage1 = true;
    bool stage2 = false;
    bool stage3 = false;
    float fireTime = 5;
    



    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        look = GetComponent<LookAt2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        int hp = enemy.getEnemyHealth();

        if(hp < 350){
            stage1 = false;
            stage2 = true;
        }else if(hp < 200){
            stage2 = false;
            stage3 = true;
        }
    }

    void FixedUpdate(){
        look.LookAtPlayer();

        if(Time.time > this.fireTime){
            // channel animation
            this.fireTime = Time.time + (float)Random.Range(this.spawnOffset.x, this.spawnOffset.y);

            if(stage1){
                StartCoroutine("attack1");
            }else if(stage2){
                StartCoroutine("attack2");
            }else if(stage3){
                StartCoroutine("attack3");
            }
        }

        if(chase){
            animator.SetBool("Move", true);
            
            // chase code
            Vector2 target = new Vector2(player.position.x, rigidbody.position.y);
		    Vector2 newPos = Vector2.MoveTowards(rigidbody.position, target, speed * Time.fixedDeltaTime);
		    rigidbody.MovePosition(newPos);

        }else{
            animator.SetBool("Move", false);
        }
    }

    IEnumerator attack1(){
        chase = false;
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;

        // mummy animation
        for(int i = 0; i < spawns.Length; i++){
            Instantiate(spawns[i], spawnPoints[i].transform.position, spawnPoints[i].transform.rotation);
        }

        yield return new WaitForSeconds(4);
        
        this.transform.position = centerSpawn.transform.position;
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<BoxCollider2D>().enabled = true;
        chase = true;
    }
}
