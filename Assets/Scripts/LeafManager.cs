using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafManager : MonoBehaviour {

	public List<GameObject> leaves;
	private List<ParticleSystem> leafParticles;
	private List<float> startSpeed;
	public float startSlowTime;
	public float endSlowTime;
	public float endSimulationSpeed;
	private float m_currentTime = 0f;
	private float timeToFade;

	void Start () {
		// initialization
		leafParticles = new List<ParticleSystem> ();
		startSpeed = new List<float> ();
		// record start simulation speed and components
		foreach (GameObject leaf in leaves) {
			ParticleSystem tmpPs = leaf.GetComponent<ParticleSystem> ();
			leafParticles.Add (tmpPs);
			var tmpMain = leaf.GetComponent<ParticleSystem> ().main;
			startSpeed.Add (tmpMain.simulationSpeed);
		}

		// setup fade time
		timeToFade = endSlowTime - startSlowTime;
		if (timeToFade <= 0f) {
			Debug.Log ("timeToFade is less than zero");
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.realtimeSinceStartup >= startSlowTime) {
			m_currentTime += Time.deltaTime;
			for (int leafIndex = 0; leafIndex < leafParticles.Count; leafIndex++) {
				var tmpParticleMain = leafParticles[leafIndex].main;
				// update time frame

				// update new simulation speed
				float tmpSpeed = Mathf.Lerp (startSpeed[leafIndex], endSimulationSpeed, m_currentTime/timeToFade);
				tmpParticleMain.simulationSpeed = tmpSpeed;
			}
		} else if (Time.realtimeSinceStartup >= endSlowTime) {
			foreach (ParticleSystem ps in leafParticles) {
				var tmpParticleMain = ps.main;
				tmpParticleMain.simulationSpeed = endSimulationSpeed;
			}
		}
	}
}
