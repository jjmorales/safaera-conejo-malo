using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    public int maxHealth = 100;
    public float speed = 2f;
    public Text points;
    GameObject targetChase;
    int currHealth;

    // Start is called before the first frame update
    void Start()
    {
        targetChase = GameObject.FindGameObjectWithTag("Player");
        currHealth = maxHealth;
    
    }

    void Update(){
        //approachPlayer();
    }

    public void takeDamage(int damageTaken){
        currHealth -= damageTaken;

        // hurt animation

        addPointsDmg();
        if(currHealth <= 0){
            die();
        }
    }

    void die(){
        addPointsKill();
        Destroy(this.gameObject);
    }

    void addPointsKill(){
        int totalPoints = int.Parse(points.text) + 100;
        points.text = totalPoints.ToString();
    }

    void addPointsDmg(){
        int totalPoints = int.Parse(points.text) + 25;
        points.text = totalPoints.ToString();
    }

    void approachPlayer(){
        transform.position = Vector2.MoveTowards(transform.position, targetChase.transform.position, Time.deltaTime * speed);

    }
}
