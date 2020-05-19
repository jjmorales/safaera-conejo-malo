using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost : MonoBehaviour
{

    public float boostTimer;
    float lastClick;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("d") && (Time.time - lastClick >= boostTimer)){

            // boost animation trigger
        
            //Debug.Log(" last click->" + lastClick);
            StartCoroutine(GameObject.FindObjectOfType<Player>().PlayerImmune());
            lastClick = Time.time;
        }
    }
}
