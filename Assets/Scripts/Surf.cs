using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 2D player movement, script handles input and sends it to the controller (PlayerControler2D)
public class Surf : MonoBehaviour
{

    public Animator animator;
    public float speed = 40f;
    public GameObject spawnPoint;
    public GameObject splash;
    
    
    float h;
    float v;
    Rigidbody2D rb;
    SceneLoader sceneLoader;


    void Start(){
        rb = gameObject.GetComponent<Rigidbody2D>();
        sceneLoader = GameObject.FindGameObjectWithTag("SceneLoader").GetComponent<SceneLoader>();
        StartCoroutine("respawn");
    }

    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

    }

    void OnTriggerEnter2D(Collider2D col){


        if(col.gameObject.tag == "Floor"){
            //splash animation
            Instantiate(splash, GameObject.FindGameObjectWithTag("Player").gameObject.transform.position, GameObject.FindGameObjectWithTag("Player").gameObject.transform.rotation);

            GameObject.FindGameObjectWithTag("HealthBar").GetComponent<LifeBar>().hit();

            if(GameObject.FindGameObjectWithTag("HealthBar").GetComponent<LifeBar>().currentHealth == 0){
                StartCoroutine("Die");
            }else{
            //flash coroutine
            StartCoroutine("respawn");
            }
        }
    }
    void FixedUpdate(){
        rb.velocity = new Vector3 (h * speed, rb.velocity.y, v * speed);
    }

    public IEnumerator Die(){
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        


        yield return new WaitForSeconds(1);

        sceneLoader.LoadLevelSelection();
    }

    public IEnumerator respawn(){
        //spawn at top of map
        rb.position = spawnPoint.transform.position;

        //velocity and gravity set to 0
        rb.gravityScale = 0;
        rb.velocity = new Vector2(0,0);

        gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;   // spawn
        yield return new WaitForSeconds(2f);
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;   // back to normal
        rb.gravityScale = 2;
    }

    
}
