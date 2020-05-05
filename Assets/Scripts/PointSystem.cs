using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointSystem : MonoBehaviour
{

    public Text points;
    int currentPoints;

    // Start is called before the first frame update
    void Start()
    {
        currentPoints = 0;
    }


    public void addPointsKill(){
        currentPoints += 50;
        points.text = currentPoints.ToString();
    }

    public void addPointsDmg(){
        currentPoints += 5;
        points.text = currentPoints.ToString();
    }

    public void addPointsBonus(){
        currentPoints += 100;
        points.text = currentPoints.ToString();
    }
}
