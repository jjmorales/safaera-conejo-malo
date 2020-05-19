using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost : MonoBehaviour
{

    public float boostTimer;
    float lastClick;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("d") && (Time.time - lastClick >= boostTimer)){

            // boost animation trigger
            animator.SetTrigger("Boost");
        
            //Debug.Log(" last click->" + lastClick);
            StartCoroutine(GameObject.FindObjectOfType<Player>().PlayerImmune());
            lastClick = Time.time;
        }
    }


}
