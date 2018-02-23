using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class casting : MonoBehaviour
{
	// range of the cast
	public float range;
	// store all kaleidoscopes
	public List<GameObject> group01;
	public List<GameObject> group02;
	public List<GameObject> group03;

	// internal clock for the time gap between triggers
	private float timeBetweenTriggers = 1f;
	private float timeStamp;

	// Update is called once per frame
	void Update ()
	{
		// setup variables
		RaycastHit hit;
		float theDistance;
		Vector3 forward = transform.TransformDirection (Vector3.forward) * 10;
		// setup debug visualization
		Debug.DrawRay (transform.position, forward, Color.green);

		// check cast if hit colliders
		if (Physics.Raycast (transform.position, forward, out hit)) {
			theDistance = hit.distance;
			//print (theDistance + " " + hit.collider.gameObject.tag);
			range = theDistance;

			// triggers the rotation of images
			if (hit.collider.gameObject.tag == "group01_rotateImg01_cw") {
				group01_rotateImg01_CW ();
			} else if (hit.collider.gameObject.tag == "group01_rotateImg02_cw") {
				group01_rotateImg02_CW ();
			} else if (hit.collider.gameObject.tag == "group01_rotateImg03_cw") {
				group01_rotateImg03_CW ();
			} else if (hit.collider.gameObject.tag == "group01_rotateImg04_cw") {
				group01_rotateImg04_CW ();
			} else if (hit.collider.gameObject.tag == "group01_rotateImg01_ccw") {
				group01_rotateImg01_CCW ();
			} else if (hit.collider.gameObject.tag == "group01_rotateImg02_ccw") {
				group01_rotateImg02_CCW ();
			} else if (hit.collider.gameObject.tag == "group01_rotateImg03_ccw") {
				group01_rotateImg03_CCW ();
			} else if (hit.collider.gameObject.tag == "group01_rotateImg04_ccw") {
				group01_rotateImg04_CCW ();
			} else if (hit.collider.gameObject.tag == "group01_switchImage01") {
				group01_switchImage ();
			} // group 2
			else if (hit.collider.gameObject.tag == "group02_rotateImg01_cw") {
				group02_rotateImg01_CW ();
			} else if (hit.collider.gameObject.tag == "group02_rotateImg02_cw") {
				group02_rotateImg02_CW ();
			} else if (hit.collider.gameObject.tag == "group02_rotateImg03_cw") {
				group02_rotateImg03_CW ();
			} else if (hit.collider.gameObject.tag == "group02_rotateImg04_cw") {
				group02_rotateImg04_CW ();
			} else if (hit.collider.gameObject.tag == "group02_rotateImg01_ccw") {
				group02_rotateImg01_CCW ();
			} else if (hit.collider.gameObject.tag == "group02_rotateImg02_ccw") {
				group02_rotateImg02_CCW ();
			} else if (hit.collider.gameObject.tag == "group02_rotateImg03_ccw") {
				group02_rotateImg03_CCW ();
			} else if (hit.collider.gameObject.tag == "group02_rotateImg04_ccw") {
				group02_rotateImg04_CCW ();
			} else if (hit.collider.gameObject.tag == "group02_switchImage01") {
				group02_switchImage ();
			} // group 3
			else if (hit.collider.gameObject.tag == "group03_rotateImg01_cw") {
				group03_rotateImg01_CW ();
			} else if (hit.collider.gameObject.tag == "group03_rotateImg02_cw") {
				group03_rotateImg02_CW ();
			} else if (hit.collider.gameObject.tag == "group03_rotateImg03_cw") {
				group03_rotateImg03_CW ();
			} else if (hit.collider.gameObject.tag == "group03_rotateImg04_cw") {
				group03_rotateImg04_CW ();
			} else if (hit.collider.gameObject.tag == "group03_rotateImg01_ccw") {
				group03_rotateImg01_CCW ();
			} else if (hit.collider.gameObject.tag == "group03_rotateImg02_ccw") {
				group03_rotateImg02_CCW ();
			} else if (hit.collider.gameObject.tag == "group03_rotateImg03_ccw") {
				group03_rotateImg03_CCW ();
			} else if (hit.collider.gameObject.tag == "group03_rotateImg04_ccw") {
				group03_rotateImg04_CCW ();
			} else if (hit.collider.gameObject.tag == "group03_switchImage01") {
				group03_switchImage ();
			}

		} else {
			theDistance = 0f;
			range = 0f;
		}
	}

	// group 1 cw
	public void group01_rotateImg01_CW ()
	{
		foreach (GameObject Kale in group01) {
			Kale.GetComponent<autoRotateImg> ().rotateImg01_cw ();
		}
	}

	public void group01_rotateImg02_CW ()
	{
		foreach (GameObject Kale in group01) {
			Kale.GetComponent<autoRotateImg> ().rotateImg02_cw ();
		}
	}

	public void group01_rotateImg03_CW ()
	{
		foreach (GameObject Kale in group01) {
			Kale.GetComponent<autoRotateImg> ().rotateImg03_cw ();
		}
	}

	public void group01_rotateImg04_CW ()
	{
		foreach (GameObject Kale in group01) {
			Kale.GetComponent<autoRotateImg> ().rotateImg04_cw ();
		}
	}

	// group 1 ccw
	public void group01_rotateImg01_CCW ()
	{
		foreach (GameObject Kale in group01) {
			Kale.GetComponent<autoRotateImg> ().rotateImg01_ccw ();
		}
	}

	public void group01_rotateImg02_CCW ()
	{
		foreach (GameObject Kale in group01) {
			Kale.GetComponent<autoRotateImg> ().rotateImg02_ccw ();
		}
	}

	public void group01_rotateImg03_CCW ()
	{
		foreach (GameObject Kale in group01) {
			Kale.GetComponent<autoRotateImg> ().rotateImg03_ccw ();
		}
	}

	public void group01_rotateImg04_CCW ()
	{
		foreach (GameObject Kale in group01) {
			Kale.GetComponent<autoRotateImg> ().rotateImg04_ccw ();
		}
	}

	// group 1 switch images
	public void group01_switchImage ()
	{
		foreach (GameObject Kale in group01) {
			Kale.GetComponent<autoRotateImg> ().randomSwitchImages ();
		}
	}

	public void group01_fastSwitchImage ()
	{
		foreach (GameObject Kale in group01) {
			Kale.GetComponent<autoRotateImg> ().randomSwitchImages ();
		}
	}

	// group 2 cw
	public void group02_rotateImg01_CW ()
	{
		foreach (GameObject Kale in group02) {
			Kale.GetComponent<autoRotateImg> ().rotateImg01_cw ();
		}
	}

	public void group02_rotateImg02_CW ()
	{
		foreach (GameObject Kale in group02) {
			Kale.GetComponent<autoRotateImg> ().rotateImg02_cw ();
		}
	}

	public void group02_rotateImg03_CW ()
	{
		foreach (GameObject Kale in group02) {
			Kale.GetComponent<autoRotateImg> ().rotateImg03_cw ();
		}
	}

	public void group02_rotateImg04_CW ()
	{
		foreach (GameObject Kale in group02) {
			Kale.GetComponent<autoRotateImg> ().rotateImg04_cw ();
		}
	}
	// group 2 ccw
	public void group02_rotateImg01_CCW ()
	{
		foreach (GameObject Kale in group02) {
			Kale.GetComponent<autoRotateImg> ().rotateImg01_ccw ();
		}
	}

	public void group02_rotateImg02_CCW ()
	{
		foreach (GameObject Kale in group02) {
			Kale.GetComponent<autoRotateImg> ().rotateImg02_ccw ();
		}
	}

	public void group02_rotateImg03_CCW ()
	{
		foreach (GameObject Kale in group02) {
			Kale.GetComponent<autoRotateImg> ().rotateImg03_ccw ();
		}
	}

	public void group02_rotateImg04_CCW ()
	{
		foreach (GameObject Kale in group02) {
			Kale.GetComponent<autoRotateImg> ().rotateImg04_ccw ();
		}
	}
	// group 2 switch images
	public void group02_switchImage ()
	{
		foreach (GameObject Kale in group02) {
			Kale.GetComponent<autoRotateImg> ().randomSwitchImages ();
		}
	}

	// group 3 cw
	public void group03_rotateImg01_CW ()
	{
		foreach (GameObject Kale in group03) {
			Kale.GetComponent<autoRotateImg> ().rotateImg01_cw ();
		}
	}

	public void group03_rotateImg02_CW ()
	{
		foreach (GameObject Kale in group03) {
			Kale.GetComponent<autoRotateImg> ().rotateImg02_cw ();
		}
	}

	public void group03_rotateImg03_CW ()
	{
		foreach (GameObject Kale in group03) {
			Kale.GetComponent<autoRotateImg> ().rotateImg03_cw ();
		}
	}

	public void group03_rotateImg04_CW ()
	{
		foreach (GameObject Kale in group03) {
			Kale.GetComponent<autoRotateImg> ().rotateImg04_cw ();
		}
	}
	// group 3 ccw
	public void group03_rotateImg01_CCW ()
	{
		foreach (GameObject Kale in group03) {
			Kale.GetComponent<autoRotateImg> ().rotateImg01_ccw ();
		}
	}

	public void group03_rotateImg02_CCW ()
	{
		foreach (GameObject Kale in group03) {
			Kale.GetComponent<autoRotateImg> ().rotateImg02_ccw ();
		}
	}

	public void group03_rotateImg03_CCW ()
	{
		foreach (GameObject Kale in group03) {
			Kale.GetComponent<autoRotateImg> ().rotateImg03_ccw ();
		}
	}

	public void group03_rotateImg04_CCW ()
	{
		foreach (GameObject Kale in group03) {
			Kale.GetComponent<autoRotateImg> ().rotateImg04_ccw ();
		}
	}
	// group 3 switch images
	public void group03_switchImage ()
	{
		foreach (GameObject Kale in group03) {
			Kale.GetComponent<autoRotateImg> ().randomSwitchImages ();
		}
	}
}
