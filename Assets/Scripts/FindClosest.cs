using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindClosest : MonoBehaviour {

	public GameObject getClosestEnemy()
	{
		float distanceToClosestEnemy = Mathf.Infinity;
		GameObject closestEnemy = null;
		GameObject[] allEnemies = GameObject.FindGameObjectsWithTag("Enemy");

		foreach (GameObject currentEnemy in allEnemies) {
			float distanceToEnemy = (currentEnemy.transform.position - this.gameObject.transform.position).sqrMagnitude;
			if (distanceToEnemy < distanceToClosestEnemy) {
				distanceToClosestEnemy = distanceToEnemy;
				closestEnemy = currentEnemy;
			}
		}

		return closestEnemy;
	}

	public float getDistanceFromEnemy(GameObject enemy){
		if(enemy == null){
			return -1;
		}else{
		return (enemy.transform.position - this.gameObject.transform.position).sqrMagnitude;
		}
	}
}
