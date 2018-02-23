using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextUpdateMessage : MonoBehaviour {

	public float XPos;
	public float Ypos;

	public float Width;
	public float Height;
	
	public string TextToDisplay;

	public GameObject NUM;

	public void OnTriggerEnter(){
		NUM.SetActive(true);
		TextToDisplay = "This area will be developed in the next update.";
	}
	
	
	public void OnGUI() {
        GUI.Label(new Rect(XPos, Ypos, Width, Height), TextToDisplay);
    }
	
	
	
	
	
	// Use this for initialization
	void Start () {
		TextToDisplay = "";
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
