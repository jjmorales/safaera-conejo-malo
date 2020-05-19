using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runner : MonoBehaviour
{
    public int speed;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.right * speed;
    }

    public IEnumerator slowDown(int slowAmount, float slowTime){
        int currSpeed = speed;

        speed -= slowAmount;

        yield return new WaitForSeconds(1f);

        speed = currSpeed;
    }
}
