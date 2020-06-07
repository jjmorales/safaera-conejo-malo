using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUp : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        Destroy(gameObject, 6);
    }

    // Update is called once per frame
    void Update()
    {
        rb.MovePosition(transform.position + transform.up * speed * Time.fixedDeltaTime);
 
    }
}
