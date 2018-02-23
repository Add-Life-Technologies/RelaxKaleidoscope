using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour {

	[Header("GameObject & Transform to Rotate")]
	public GameObject ObjToRotate;
	public Transform OTR_Transform;
	
	[Header("The Rotation to be applied")]
	public float RotationForce;
	
	// Use this for initialization
	void Start () {
		OTR_Transform = ObjToRotate.GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		OTR_Transform.Rotate(0f, RotationForce * Time.deltaTime, 0f, Space.World); //The rotation is applied to the Y Axis.
	}
}
