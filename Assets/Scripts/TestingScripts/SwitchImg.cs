using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchImg : MonoBehaviour {

	// user defined sprites
	public Sprite sp01;
	public Sprite sp02;
	public Sprite sp03;
	public Sprite sp04;

	// attached sprite render
	public SpriteRenderer thisRenderer;
	public float TimeGap = 0.25f;

	// time changing gap
	private float Timer;

	// Update is called once per frame
	void Update () {
		this.Timer += Time.deltaTime;
		if (Timer >= 0f && Timer <= TimeGap) {
			thisRenderer.sprite = sp02;
		} else if (Timer > TimeGap && Timer <= TimeGap * 2f) {
			thisRenderer.sprite = sp03;
		} else if (Timer > TimeGap * 2f && Timer <= TimeGap * 3f) {
			thisRenderer.sprite = sp04;
		} else if (Timer > TimeGap * 3f && Timer <= TimeGap * 4f) {
			thisRenderer.sprite = sp03;
		} else if (Timer > TimeGap * 4f && Timer <= TimeGap * 5f) {
			thisRenderer.sprite = sp02;
		} else if (Timer > TimeGap * 5f && Timer <= TimeGap * 6f) {
			thisRenderer.sprite = sp01;
		} else if (Timer > TimeGap * 6f && Timer <= TimeGap * 7f) {
			//print ("reset");
			this.Timer = 0f;
		}
	}
}
