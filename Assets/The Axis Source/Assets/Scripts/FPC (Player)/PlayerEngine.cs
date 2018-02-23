using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerEngine : MonoBehaviour {

	CharacterController Player;
	
	[Header("Constant Values.")]
	public float WalkSpeed;
	public float RunSpeed;
	public float SpeedMovement = 2f;
	public float CamSensitivy = 5f;
	public float PlayerHeight;
	
	[Header("Maximum tilt angles in Y Axis.")]
	public float MinAngles = -80f;
	public float MaxAngles = 80f;

	[Header("Physics Iteration, Jump Values & Crouch Values")]
	public float VerticalVelocity;
	public float JumpDistance = 5f;
	public int JumpTimes;
	public bool IsCrouching;
	public bool IsJumping;

	[Header("The Player's Camera.")]
	public GameObject Cam;

	[Header("WASD Movement Values (Read Only).")]
	public float FB_Movement;
	public float RL_Movement;

	[Header("Camera Rotation Values (Read Only).")]
	public float X_Rotation;
	public float Y_Rotation;


	void Start () {
		Player = GetComponent<CharacterController>();	//The CharacterController Component will be our Player.
		PlayerHeight = Player.height; 					//Get the actual height of the CharacterController (Player).

		Cursor.lockState = CursorLockMode.Locked;      	//Hide and Lock the cursor to the center of the Screen.

		RunSpeed = SpeedMovement * 2;	//We store and establish original speed values for later use.
		WalkSpeed = RunSpeed / 2;

	}
	

	void Update () {

		//I set my axis to be used in WASD keys.
		RL_Movement = Input.GetAxis("Vertical") * SpeedMovement;  
		FB_Movement = Input.GetAxis("Horizontal") * SpeedMovement; 
		 	
		
		//I set my axis to be used by the current mouse rotation.
		X_Rotation = Input.GetAxis("Mouse X") * CamSensitivy;
		Y_Rotation -= Input.GetAxis("Mouse Y") * CamSensitivy;

		Y_Rotation = Mathf.Clamp (Y_Rotation, MinAngles, MaxAngles);	//Set the limiting angles for the vertical rotation axis.

		
		//Apply movement to the Player.
		Vector3 Movement = new Vector3(FB_Movement, VerticalVelocity, RL_Movement);
		Movement = transform.rotation * Movement;
		Player.Move(Movement * Time.deltaTime);
		
		
		//Apply rotation to the Player and the Camera.
		transform.Rotate(0f, X_Rotation, 0f);
		Cam.transform.localRotation = Quaternion.Euler(Y_Rotation, 0, 0);


		if(IsJumping == false){ //You can't crouch if you are Jumping.

			//Crouch functions.
			if(Input.GetButtonDown("Crouch")){
				if(IsCrouching == false){
					Player.height = Player.height / 2; //Get the Player's height and divide by 2 to get half.
					SpeedMovement = SpeedMovement / 2; //Reduce the Player's Speed.
					IsCrouching = true;
				} else{
					Player.height = Player.height * 2; //Restore the Player's height to the original value.
					SpeedMovement = SpeedMovement * 2; //Restore the Player's Speed.
					IsCrouching = false;
				}
			}

		}


		if(IsJumping == false && IsCrouching == false){	//You can't run if you are Jumping or Crouching.
			
			//Run functions.
			if(Input.GetButton("Run")){
				SpeedMovement = RunSpeed;
			}else{
				SpeedMovement = WalkSpeed;
			}
			
		}


	}

	void FixedUpdate(){
		if(Player.isGrounded == false){ // Detects if Player is grounded in order to determine whether you can fall.
			VerticalVelocity += Physics.gravity.y * Time.deltaTime;
		} else {
			VerticalVelocity = 0f;
		}


		if(IsCrouching == false){ // You can't jump if you are Crouching.

			//Jump functions..
			if(IsJumping == true){
				if(Player.isGrounded == true){ //Reset the JumpTimes to be able to jump twice again.
					JumpTimes = 0;
					IsJumping = false;	
				}
			}
			
			if(JumpTimes < 2){	//Allows to jump twice or double jump.
				if(Input.GetButtonDown("Jump")){
					VerticalVelocity += JumpDistance;
					JumpTimes += 1;
					IsJumping = true;
				}
			}
		}

	}
}
