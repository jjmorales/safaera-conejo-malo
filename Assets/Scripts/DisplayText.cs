using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class DisplayText : MonoBehaviour
{

    public GameObject [] text;
    public int delay;

    int curr = 0;
    AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("display");
        audio = GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>();
    }

    IEnumerator display(){
        
        text[curr].gameObject.GetComponent<Text>().enabled = true;

        yield return new WaitForSeconds(delay);

        text[curr].gameObject.GetComponent<Text>().enabled = false;
        curr++;

        if(curr >= text.Length){
            //fade 
            StartCoroutine(FadeAudioSource.StartFade(audio, 5, 0));
        }else{
            StartCoroutine("display");
        }

    }


}
