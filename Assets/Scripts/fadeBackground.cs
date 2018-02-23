using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fadeBackground : MonoBehaviour {

	private Camera thisCam;
	public float fadeSpeed = 0.0001f;
	public float timeSwitch = 5f;
	public float longSwitchGap = 30f;
	public float timeStamp;
	public enum backgroundState {
		Color01ToColor02,
		Color02ToColor03,
		Color03ToColor01
	}
	public Color stateColor01;
	public Color stateColor02;
	public Color stateColor03;
	public backgroundState CurrentState = backgroundState.Color01ToColor02;

	// Use this for initialization
	void Start () {
		thisCam = GetComponent<Camera> ();
	}
	
	// Update is called once per frame
	void Update () {
		// debug print
		//print("BColor: " + thisCam.backgroundColor);

		if (CurrentState == backgroundState.Color01ToColor02) {
			// change color
			Color tmpColor = thisCam.backgroundColor;
			tmpColor.r = Mathf.Lerp (tmpColor.r, stateColor01.r, Time.deltaTime * fadeSpeed);
			tmpColor.g = Mathf.Lerp (tmpColor.g, stateColor01.g, Time.deltaTime * fadeSpeed);
			tmpColor.b = Mathf.Lerp (tmpColor.b, stateColor01.b, Time.deltaTime * fadeSpeed);
			thisCam.backgroundColor = tmpColor;
			// switch state
			if (Time.time > timeStamp + timeSwitch) {
				CurrentState = backgroundState.Color02ToColor03;
				timeStamp = Time.time + timeSwitch;
			}
		} else if (CurrentState == backgroundState.Color02ToColor03) {
			// change color
			Color tmpColor = thisCam.backgroundColor;
			tmpColor.r = Mathf.Lerp (tmpColor.r, stateColor02.r, Time.deltaTime * fadeSpeed);
			tmpColor.g = Mathf.Lerp (tmpColor.g, stateColor02.g, Time.deltaTime * fadeSpeed);
			tmpColor.b = Mathf.Lerp (tmpColor.b, stateColor02.b, Time.deltaTime * fadeSpeed);
			thisCam.backgroundColor = tmpColor;
			// switch state
			if (Time.time > timeStamp + timeSwitch) {
				CurrentState = backgroundState.Color03ToColor01;
				timeStamp = Time.time + timeSwitch;
			}
		} else if (CurrentState == backgroundState.Color03ToColor01) {
			// change color
			Color tmpColor = thisCam.backgroundColor;
			tmpColor.r = Mathf.Lerp (tmpColor.r, stateColor03.r, Time.deltaTime * fadeSpeed);
			tmpColor.g = Mathf.Lerp (tmpColor.g, stateColor03.g, Time.deltaTime * fadeSpeed);
			tmpColor.b = Mathf.Lerp (tmpColor.b, stateColor03.b, Time.deltaTime * fadeSpeed);
			thisCam.backgroundColor = tmpColor;
			// switch state
			if (Time.time > timeStamp + longSwitchGap) {
				CurrentState = backgroundState.Color01ToColor02;
				timeStamp = Time.time + longSwitchGap;
			}
		}
	}
}
