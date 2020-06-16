using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
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
}
