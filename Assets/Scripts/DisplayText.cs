using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayText : MonoBehaviour
{

    public GameObject [] text;
    public int delay;

    int curr = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("display");
    }

    IEnumerator display(){
        
        text[curr].gameObject.GetComponent<Text>().enabled = true;

        yield return new WaitForSeconds(delay);

        text[curr].gameObject.GetComponent<Text>().enabled = false;
        curr++;

        if(curr > text.Length){
            //fade 
        }else{
            StartCoroutine("display");
        }

    }


}
