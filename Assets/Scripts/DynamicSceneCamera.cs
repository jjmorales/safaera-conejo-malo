using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class DynamicSceneCamera : MonoBehaviour
{

    public GameObject player;
    public GameObject [] views;
    public Transform [] switchPoints;
    int currPoint = 0;

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.x >= switchPoints[currPoint].transform.position.x && player.transform.position.x < switchPoints[currPoint + 1].transform.position.x){

        }else if(player.transform.position.x < switchPoints[currPoint].transform.position.x){
            views[currPoint - 1].gameObject.GetComponent<CinemachineVirtualCamera>().enabled = true;
            views[currPoint].gameObject.GetComponent<CinemachineVirtualCamera>().enabled = false;
            currPoint--;
            Debug.Log("back");
        }else if(player.transform.position.x >= switchPoints[currPoint + 1].transform.position.x){
            views[currPoint + 1].gameObject.GetComponent<CinemachineVirtualCamera>().enabled = true;
            views[currPoint].gameObject.GetComponent<CinemachineVirtualCamera>().enabled = false;
            currPoint++;
            Debug.Log("forward");
        }
    }
}
