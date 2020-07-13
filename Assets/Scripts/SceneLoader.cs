using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    public float transitionTime;
    public GameObject gif;

    public GameObject center;

    public void StartGame(){
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>().Stop();
        GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>().volume = 1;
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
        
        if(gif) Instantiate(gif, center.transform.position, center.transform.rotation); 

        if(GameObject.FindGameObjectWithTag("Player")) Destroy(GameObject.FindGameObjectWithTag("Player").gameObject);

        yield return new WaitForSeconds(transitionTime);

        int load = SceneManager.GetActiveScene().buildIndex + 1;

        if(load > 6) load = 0;
        SceneManager.LoadScene(load);
    }

    public void LoadSaf(){
        SceneManager.LoadScene(7);
    }
    public void LoadTun(){
        SceneManager.LoadScene(8);
    }

    public void LoadSky(){
        SceneManager.LoadScene(9);
    }

    public void LoadOce(){
        SceneManager.LoadScene(10);
    }

    public void LoadPyr(){
        SceneManager.LoadScene(11);
    }
}
