using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// provides hit stop mechanic on bullet collision
// attach to bullet object
public class HitStop : MonoBehaviour {
	bool waiting = false;
	public void Stop(float duration, float timeScale){
		if (waiting)				// to not call more than once per frame
			return;
		Time.timeScale = timeScale;
		StartCoroutine(Wait(duration));
	}


	public void Stop(float duration){
		Stop(duration, 0.0f);
	}
	IEnumerator Wait(float duration){
		waiting = true;
		yield return new WaitForSecondsRealtime(duration);
		Debug.Log("here");
		Time.timeScale = 1.0f;
		waiting = false;
	}
}
