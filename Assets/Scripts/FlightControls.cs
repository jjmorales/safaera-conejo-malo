using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlightControls : MonoBehaviour
{

    public int speed;

    private Rigidbody2D rb;
    private Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.y = Input.GetAxisRaw("Vertical");
        movement.x = Input.GetAxisRaw("Horizontal");
        
        if(GameObject.FindGameObjectWithTag("HealthBar")){
            if(GameObject.FindGameObjectWithTag("HealthBar").GetComponent<LifeBar>().currentHealth == 0){
                StartCoroutine("Die");
            }
        }
    }

    public IEnumerator Die(){
        gameObject.GetComponent<Animator>().SetTrigger("Die");

        yield return new WaitForSeconds(this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);

        GameObject.FindGameObjectWithTag("SceneLoader").GetComponent<SceneLoader>().LoadStartMenu();
    }

    void FixedUpdate(){
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
}
