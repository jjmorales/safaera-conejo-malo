using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class SceneLoader : MonoBehaviour
{

    public float transitionTime;
    public GameObject video;

    public void StartGame(){
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>().Stop();
        GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>().Play();

        StartCoroutine("playTransition");
    }
    public void LoadLevel1(){
        SceneManager.LoadScene(1);
    }

    public void LoadLevel2(){
        SceneManager.LoadScene(2);
    }
    public void LoadLevel3(){
        SceneManager.LoadScene(3);
    }
    public void LoadLevel4(){
        SceneManager.LoadScene(4);
    }
    public void LoadLevel5(){
        SceneManager.LoadScene(5);
    }
    public void LoadStartMenu(){
        SceneManager.LoadScene(0);
    }

    public void LoadLevelSelection(){
        SceneManager.LoadScene(7);
    }

    public void LoadCredits(){
        SceneManager.LoadScene(6);
    }

    public void Respawn(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void loadNext(){
        StartCoroutine("playTransition");
    }

    IEnumerator playTransition(){        
        
        GameObject.FindGameObjectWithTag("Transition").GetComponent<VideoPlayer>().Play();

        if(GameObject.FindGameObjectWithTag("Player")) Destroy(GameObject.FindGameObjectWithTag("Player").gameObject);

        yield return new WaitForSeconds(transitionTime);

        int load = SceneManager.GetActiveScene().buildIndex + 1;

        if(load > 6) load = 0;
        SceneManager.LoadScene(load);
    }
}
