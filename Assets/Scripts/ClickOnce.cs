using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickOnce : MonoBehaviour
{
    public void NoButtons(){
        GameObject [] buttons = GameObject.FindGameObjectsWithTag("Button");

        for(int i = 0; i < buttons.Length; i++){
            Destroy(buttons[i]);
        }
    }
}
