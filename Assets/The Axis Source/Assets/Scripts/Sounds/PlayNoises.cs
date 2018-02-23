using UnityEngine;
using System.Collections;

public class PlayNoises : MonoBehaviour {
//*************************************
//        AudioSource & Clips
//*************************************
	[Header("AudioSource & Clips")]
	public AudioSource AudioS;
	public AudioClip[] Noises;

//*************************************
//        Timer for Noises
//*************************************
	[Header("Timer for Noises")]
	public float TimeFloat;
    public int TimeInt;
	public int Delay; //The delay in seconds between the noises.
    public bool StartTime;

//*************************************
//          Start timer
//*************************************
	public void OnTriggerEnter(){
        if (StartTime==false){
            StartTime = true;
            //PlayNoise();
        }          
	}

//*************************************
//       PlayNoise Function
//*************************************
	public void PlayNoise(){
		int i = Random.Range(0, Noises.Length);
		AudioS.clip = Noises[i];
		AudioS.PlayOneShot(AudioS.clip);
		Noises[i] = Noises[0];
		Noises[0] = AudioS.clip;
	}
//*************************************

	// Use this for initializatino
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(StartTime==true){ //The timer begins.
            TimeFloat += Time.deltaTime; 
			TimeInt = (int) TimeFloat;
		}

		if(TimeInt>=Delay){ //Every "Delay" a noise is played and restart the timer.
			PlayNoise(); 
			TimeInt = 0;
			TimeFloat= 0f;
		}

	}
}
