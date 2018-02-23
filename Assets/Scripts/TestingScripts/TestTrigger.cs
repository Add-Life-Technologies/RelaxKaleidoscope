using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTrigger : MonoBehaviour {

	// only for testing the trigger and raycast
	void OnTriggerEnter(Collider other) {
		print ("Triggered name: " + other.gameObject.name);
	}

}
