using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbTest : MonoBehaviour {

	[Header("GameObjects Orbs & WallLight")]
	public GameObject SmallOrbA;
	public GameObject SmallOrbB;
	public GameObject MainOrb;
	public GameObject WallLight;

	[Header("GameObject OrbCases")]
	public GameObject[] OrbCases;

	[Header("AudioSources Orb & Player")]
	public AudioSource AS_MainOrb;
	public AudioSource AS_Player;

	[Header("Get Orb Clips")]
	public AudioClip GetOrbA;
	public AudioClip GetOrbB;
	public float DelayToPlay;

	[Header("Pick Orb Text")]
	public Canvas PickOrb;

	[Header("Player Camera Raycast Info")]
	public Transform PlayerCam;
	public float RayDistance;
	private RaycastHit Hit;

	[Header("Get Orb Bools")]
	public bool OrbA;
	public bool OrbB;

	// Use this for initialization
	void Start () {
		OrbA = true;
		OrbB = true;
	}
	
	// Update is called once per frame
	void Update () {

		//Turn off the main Orb once the two little ones are off.
		if(OrbA == false && OrbB == false){
			MainOrb.SetActive(false);
			WallLight.SetActive(false);
			
			//Stops the rotation of the Orb Cases.
			for(int i=0; i<OrbCases.Length; i++){
				OrbCases[i].GetComponent<RotateObject>().enabled = false; 
			}
			
			OrbA = true; //The variable is set to true to exit if.
		}
		
	}

	void FixedUpdate(){
		//How to know if the player is facing a small Orb and when not. 
		//And to know if you can take it and play a sound while doing it.	
        if (Physics.Raycast(PlayerCam.position, PlayerCam.forward, out Hit, RayDistance)){
			if(Hit.collider.name == "SmallOrbA"){
				PickOrb.enabled = true;
				if(Input.GetButton("Use")){
					SmallOrbA.SetActive(false);

					AS_Player.clip = GetOrbA;
					AS_Player.PlayDelayed(DelayToPlay);

					PickOrb.enabled = false;
					OrbA = false;
				}
			} 
			else if(Hit.collider.name == "SmallOrbB"){
				PickOrb.enabled = true;
				if(Input.GetButton("Use")){
					SmallOrbB.SetActive(false);

					AS_Player.clip = GetOrbB;
					AS_Player.PlayDelayed(DelayToPlay);

					PickOrb.enabled = false;
					OrbB = false;
				}
			} 	
			else{
				PickOrb.enabled = false;
			}

			if(Hit.collider == null){
				PickOrb.enabled = false;
			}
		}
		//***************************************************************


	
	}
}
