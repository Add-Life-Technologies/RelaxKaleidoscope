using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadChapter2 : MonoBehaviour {

	[Header("GameObject Player")]
	public GameObject Player_C1;
	public bool IsFalling = false;

	[Header("Crosshair")]
	public Canvas Crosshair;
	
	[Header("NextLevelUI")]
	public Canvas NextLevelUI;

//***************Buttons Functions*************** 
	public void YES(){
		IsFalling = false;
		Time.timeScale = 1f;
		SceneManager.LoadScene("Chapter #2");
		GameObject.Find("Player_C1").GetComponent<PlayerEngine>().enabled = true; //Enable again the PlayerEngine to keep working the FPC in the new Chapter#2.
	}

	public void NO(){
		GameObject.Find("Player_C1").GetComponent<PlayerEngine>().enabled = true; //Enable again the PlayerEngine to keep working the FPC.
		GameObject.Find("Player_C1").GetComponent<PlayerEngine>().X_Rotation = 0f;
		GameObject.Find("Player_C1").GetComponent<PlayerEngine>().Y_Rotation = 0f; 

		NextLevelUI.enabled = false;
		Crosshair.enabled = true;

		IsFalling = false;

		Time.timeScale = 1f;

		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.Locked;

		Player_C1.transform.position = new Vector3(-175.875f, 136.08f, -126.5f); 
		Player_C1.transform.rotation = new Quaternion(0f, -0.7071068f, 0f, 0.7071068f);
	}
//***********************************************

	void OnTriggerEnter(){
		IsFalling = true;
	}
		

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(IsFalling == true){
			GameObject.Find("Player_C1").GetComponent<PlayerEngine>().enabled = false; //Find and disable the PlayerEngine to stop the camera's rotation.
			
			Crosshair.enabled = false;
			NextLevelUI.enabled = true;

			Time.timeScale = 0f;

			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
		}
	}
}