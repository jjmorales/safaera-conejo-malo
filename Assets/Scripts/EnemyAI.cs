using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{
    public Transform target;    // chase this target
    public float speed = 200f;  // movement speed of enemy
    public float nextWaypointDistance = 3f; // final distance from target to enemy
    public Transform enemySprite;   // enemy sprite asset


    public Animator animator;   // animator for enemy
    Path path;  // temp path of enemy to target
    int currentWaypoint;    // current waypoint in current path
    bool endOfPath = false; // check for out of bounds

    Seeker seeker;  // access from A* class
    Rigidbody2D rb; // this enemy's rigid body for movemement


    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();    // set seeker
        rb = GetComponent<Rigidbody2D>();   // set rigid body

        InvokeRepeating("UpdatePath", 0f, 0.5f);    // update path continuously
    }

    // if seeker path is completed, generate a new one
    void UpdatePath(){
        if(seeker.IsDone()){
            seeker.StartPath(rb.position, target.position, OnPathComplete);
        }
    }

    // generate new path
    void OnPathComplete(Path p){
        if(!p.error){
            path = p;
            currentWaypoint = 0;
        }
    }

    void FixedUpdate()
    {
        if(path == null){   // check for invalid path or path finished
            return;
        }

        if(currentWaypoint >= path.vectorPath.Count){   // stop waypoints from generating out of bounds of path
            endOfPath = true;
            return;
        }else{
            endOfPath = false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;   // directon of path

        Vector2 force = direction * speed * Time.deltaTime; // calculate speed for force to move enemy
        rb.AddForce(force); // move enemy

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);   // distance between enemy and next waypoint

        if(distance < nextWaypointDistance){    // next point in path
            currentWaypoint++;
        }

        // flip sprite depending on x direciton
        if(force.x >= 0.01f){
            enemySprite.localScale = new Vector3(-1f,1f,1f);
        }else if (force.x <= -0.1f){
            enemySprite.localScale = new Vector3(1f,1f,1f);
        }
    }
}
