using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundObstacle : MonoBehaviour
{

    public Sprite deathImage;
    public int slowAmount;
    public float slowTime;
     PointSystem pointSystem;
    Renderer m_Renderer;
    bool working = true;
    public int AttackDamage = 0;
    bool point = true;


    // Start is called before the first frame update

    void Start(){
        m_Renderer = GetComponent<Renderer>();
        pointSystem = GameObject.FindGameObjectWithTag("Scoreboard").GetComponent<PointSystem>();
    }

    void Update(){
        if(GameObject.FindGameObjectWithTag("Player")){
            if(point == true && (gameObject.transform.position.x - GameObject.FindGameObjectWithTag("Player").transform.position.x) < 0){
            Invoke("givePoint", 0.5f);
            point = false;
            }
        }
    }

    void givePoint(){
        GameObject.FindGameObjectWithTag("Scoreboard").GetComponent<PointSystem>().customPoint(1);
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.tag == "Player"){

            point = false;

            if(!col.GetComponent<Player>().isImmune()){
                StartCoroutine(col.GetComponent<Runner>().slowDown(slowAmount, slowTime));
                StartCoroutine(col.GetComponent<Player>().RedOnHit());
                
            }
            working = false;
        }
    }
}
