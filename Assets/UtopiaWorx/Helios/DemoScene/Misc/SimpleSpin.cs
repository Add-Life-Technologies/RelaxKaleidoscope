﻿using UnityEngine;
using System.Collections;

namespace Helios
{
public class SimpleSpin : MonoBehaviour {

	public Vector3 SpinVector;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Rotate(SpinVector);
	}
}
}