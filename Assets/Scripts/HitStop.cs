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
		Time.timeScale = timeScale;	// set time scale for "stop" effect
		StartCoroutine(Wait(duration));	//	wait for fixed duration before reseting time scale
	}


	public void Stop(float duration){
		Stop(duration, 0.0f);
	}
	IEnumerator Wait(float duration){
		waiting = true;	// wait for "stop" effect to finish
		yield return new WaitForSecondsRealtime(duration);
		Time.timeScale = 1.0f;	// reset time scale to normal
		waiting = false;	// toggle waiting
	}
}
