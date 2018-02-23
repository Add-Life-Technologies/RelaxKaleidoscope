using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorEngine : MonoBehaviour {
	
	[Header("The User Player")]
	public GameObject Player_C2;
	
	[Header("Elevator UI")]
	public Canvas UseElevator;

	[Header("Elevator GameObject & Transform")]
	public GameObject Elevator;
	public Transform ElvtrTransform;

	[Header("Elevator Directions")]
	public float DirectionUp;
	public float DirectionDown;

	[Header("Elevator Limits")]
	public float UpLimit;
	public float DownLimit;

	[Header("Elevator Switches & States")]
	public bool GoUp = false;
	public bool GoDown = false;
	public bool IsUp = false;
	public bool IsDown = false;

	[Header("Player State Bool")]
	public bool IsOnElv;


	//To know when the player is in the elevator and when not.
	void OnTriggerEnter(){
		IsOnElv = true;
		UseElevator.enabled = true;
		Player_C2.transform.SetParent(ElvtrTransform);
	}
	
	void OnTriggerExit(){
		IsOnElv = false;
		UseElevator.enabled = false;
		Player_C2.transform.SetParent(null);
	}
	//********************************************************
	
	
	// Use this for initialization
	void Start () {
		IsOnElv = false;
		ElvtrTransform = Elevator.GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {


		//Elevator switches and states. 
		//To know when the player is in elevator and when he is not.
		//And to know when it is up and has to go down again, and vice versa.
		if(IsOnElv == true){
			if(Input.GetButtonDown("Use")){
				if(IsUp == true){
					GoDown = true;
					IsUp = false;
					UseElevator.enabled = false;
				}

				if(IsDown == true){
					GoUp = true;
					IsDown = false;
					UseElevator.enabled = false;
				}
			}
		}
		//***************************************************************

		//				Elevator movement and functions.
		if(GoUp == true && ElvtrTransform.position.y <= UpLimit){
			ElvtrTransform.Translate(0, DirectionUp * Time.deltaTime, 0);
			
		}
		else if(GoUp == true && ElvtrTransform.position.y >= UpLimit){
			ElvtrTransform.position = new Vector3(32.5f, 37.5f, 0f);
			UseElevator.enabled = true;
			IsUp = true;
			GoUp = false;
		}
		
		if(GoDown == true && ElvtrTransform.position.y >= DownLimit){
			ElvtrTransform.Translate(0, DirectionDown * Time.deltaTime, 0);
		}
		else if(GoDown == true && ElvtrTransform.position.y <= DownLimit){
			ElvtrTransform.position = new Vector3(32.5f, 1f, 0f);
			UseElevator.enabled = true;
			IsDown = true;
			GoDown = false;
		}
		//*****************************************************************



	}
}
