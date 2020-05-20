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


    // Start is called before the first frame update

    void Start(){
        m_Renderer = GetComponent<Renderer>();
        pointSystem = GameObject.FindGameObjectWithTag("Scoreboard").GetComponent<PointSystem>();
    }

    void Update(){
        if(working == false && m_Renderer.isVisible == false) Destroy(gameObject);
    }
    void OnTriggerEnter2D(Collider2D col){
        if(col.tag == "Player"){
            if(!col.GetComponent<Player>().isImmune()){
                StartCoroutine(col.GetComponent<Runner>().slowDown(slowAmount, slowTime));
                StartCoroutine(col.GetComponent<Player>().RedOnHit());
                
            }else{
                if(deathImage){
                this.GetComponent<SpriteRenderer>().sprite = deathImage;
                }
                pointSystem.addPointsKill();
            }
            working = false;
        }
    }
}
