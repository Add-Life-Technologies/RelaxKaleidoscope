using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAmbientSound : MonoBehaviour {

	[Header("AudioSource & Clip")]
	public AudioSource Audio;
	public AudioClip AmbientAudio;
	public bool OnePlay = false;
	
	
	void OnTriggerEnter(){
		if(OnePlay == false){
			Audio.clip = AmbientAudio;
			Audio.Play();
			OnePlay = true;
		}		
		
	}
	
	
	// Use this for initialization
	void Start () {
		Audio = GetComponent<AudioSource>();
		Audio.loop = true;
	}
	
	// Update is called once per frame
	void Update () {

	}
}
