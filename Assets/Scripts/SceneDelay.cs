using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class SceneDelay : MonoBehaviour
{
    public float delayTime;


    void Start()
    {
        StartCoroutine(DelayLoadLevel(delayTime));
    }

    IEnumerator DelayLoadLevel(float seconds)
    {
        yield return new WaitForSeconds(seconds);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}