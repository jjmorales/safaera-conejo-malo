using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;


public class BackgroundMusic : MonoBehaviour
{

    public AudioSource sound;
    bool done = true;

    // Update is called once per frame
    void Update()
    {
        if((SceneManager.GetActiveScene().buildIndex >= 1 && SceneManager.GetActiveScene().buildIndex <= 6) && sound.isPlaying){
            sound.Stop();
        }else{
            if(!sound.isPlaying && done){
                sound.Play();
            }
        }

        if(SceneManager.GetActiveScene().buildIndex == 1){
            done = true;
        }
    }

    public void turnOffBG(){
        sound.Stop();
        done = false;
    }
}
