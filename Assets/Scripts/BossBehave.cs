using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.Experimental.Rendering.Universal;

public class BossBehave : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    public float speed;
    public float attackRange;
    public Animator animator;
    public Enemy enemy;

    // stage 1
    public Vector2 spawnOffset;
    public GameObject [] spawns;
    public GameObject [] spawnPoints;

    // stage 2
    public GameObject [] skyCometSpots;
    public GameObject comet;

    // stage 3
    public Transform firepoint;
    public GameObject fireball;

    LookAt2D look;
    Transform player;
    bool chase = true;
    bool stage1 = true;
    bool stage2 = false;
    bool stage3 = false;
    float fireTime = 5;
    HealthBar bossHP;
    Light2D light;
    
    



    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        look = GetComponent<LookAt2D>();
        bossHP = GameObject.FindGameObjectWithTag("BossHP").GetComponent<HealthBar>();
        bossHP.setMaxHealth(1000);
        light = GameObject.FindGameObjectWithTag("Lights").GetComponent<Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
        int hp = enemy.getEnemyHealth();
        bossHP.setHealth(hp);

        if(hp < 700 && hp >= 500){
            // lighting flicker orange
            //gameObject.transform.localScale = new Vector3(10,10,10);
            stage1 = false;
            stage2 = true;
            spawnOffset = new Vector2(3,8);
        }else if(hp < 500 && hp > 0){
            // lighting flicker red
            //gameObject.transform.localScale = new Vector3(5,5,5);
            stage2 = false;
            stage3 = true;
            spawnOffset = new Vector2(2,5);
        }else if(hp <= 0){
            chase = false;
            rigidbody.constraints = RigidbodyConstraints2D.FreezePositionY;
            animator.SetTrigger("Die");
        }
    }

    void FixedUpdate(){
        look.LookAtPlayer();

        if(Time.timeSinceLevelLoad > this.fireTime){
            // channel animation
            this.fireTime = Time.timeSinceLevelLoad + (float)Random.Range(this.spawnOffset.x, this.spawnOffset.y);

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

            if(stage2){
                animator.SetBool("Enraged", true);
            }

        }else{
            animator.SetBool("Move", false);
        }
    }

    IEnumerator attack1(){
        chase = false;

        animator.SetTrigger("Channel");
        light.color = new Color32(255,191,243,0);
        light.intensity = 1.15F;

        rigidbody.constraints = RigidbodyConstraints2D.FreezePositionY;


        // mummy animation

        for(int i = 0; i < spawns.Length; i++){
            Instantiate(spawns[i], spawnPoints[i].transform.position, spawnPoints[i].transform.rotation);
        }

        yield return new WaitForSeconds(1);

        light.color = new Color32(231,231,231,0);
        light.intensity = 1F;

        chase = true;
        animator.SetBool("Move", true);
        rigidbody.constraints = RigidbodyConstraints2D.None;

    }

    IEnumerator attack2(){
        chase = false;

        animator.SetTrigger("Channel");
        light.color = new Color32(255,204,131,0);
        light.intensity = 1.15F;


        rigidbody.constraints = RigidbodyConstraints2D.FreezePositionY;



        for(int i = 0; i < skyCometSpots.Length; i++){
            Instantiate(comet, skyCometSpots[i].transform.position, skyCometSpots[i].transform.rotation);
        }

        yield return new WaitForSeconds(2);

        light.color = new Color32(255,223,177,0);
        light.intensity = 1F;
        chase = true;
        animator.SetBool("Move", true);
        rigidbody.constraints = RigidbodyConstraints2D.None;

    }

    IEnumerator attack3(){
        chase = false;

        animator.SetTrigger("Channel");
        light.color = new Color32(199,149,149,0);
        light.intensity = 1.15F;


        rigidbody.constraints = RigidbodyConstraints2D.FreezePositionY;

        Instantiate(fireball, firepoint.transform.position, firepoint.transform.rotation);

        yield return new WaitForSeconds(1);

        light.color = new Color32(243,196,196,0);
        light.intensity = 1F;
        chase = true;
        animator.SetBool("Move", true);
        rigidbody.constraints = RigidbodyConstraints2D.None;

    }
}
