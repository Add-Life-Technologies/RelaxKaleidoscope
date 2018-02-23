using UnityEngine;
using System.Collections;

public class Flashlight : MonoBehaviour {
//*************************************
//        Light & Components
//*************************************
	[Header("Light & Components")]
	public Light FLight;
	public float LightStep;
	public float MaxIntensity;
	public float MinIntensity;
	public bool LightOn;
	public bool LightOff;


//*************************************
//        AudioS & Clip
//*************************************
    [Header("AudioS & Clip")]
    public AudioSource AudioS;
    public AudioClip FL_Clip;

//*************************************


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Flashlight")){

			if(FLight.intensity == MinIntensity){
				LightOn = true;
                AudioS.PlayOneShot(FL_Clip);
			}
			if(FLight.intensity == MaxIntensity){
				LightOff = true;
                AudioS.PlayOneShot(FL_Clip);
			}
		}

		if(LightOn == true){
			FLight.intensity += LightStep * Time.deltaTime;
			
			if(FLight.intensity >= MaxIntensity){
				FLight.intensity = MaxIntensity;				
				LightOn = false;
			}
		}

		if(LightOff == true){
			FLight.intensity -= LightStep *Time.deltaTime;
			
			if(FLight.intensity <= MinIntensity){
				FLight.intensity = MinIntensity;				
				LightOff = false;
			}
		}

	}
}
