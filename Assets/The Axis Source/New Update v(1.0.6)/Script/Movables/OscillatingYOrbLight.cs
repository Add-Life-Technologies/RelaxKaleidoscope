using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OscillatingYOrbLight : MonoBehaviour {

	[Header("Movement Variables")]
	public float MoveLimit;
	public float MoveSpeed;
	private Vector3 StartPos;

	// Use this for initialization
	void Start () {
		StartPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 Movement = StartPos;
		Movement.y += MoveLimit * Mathf.Sin (Time.time * MoveSpeed);
		transform.position = Movement;
	}
}
