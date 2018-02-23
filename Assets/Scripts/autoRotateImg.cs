using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoRotateImg : MonoBehaviour {

	public GameObject img_01;
	public GameObject img_02;
	public GameObject img_03;
	public GameObject img_04;

	public List<SpriteRenderer> layers;

	public float rotateSpeed_01 = 0f;
	public float rotateSpeed_02 = 0f;
	public float rotateSpeed_03 = 0f;
	public float rotateSpeed_04 = 0f;

	public float rotateSpeedLimit;

	// image index
	private int imgNum_01 = 1;
	private int imgNum_02 = 2;
	private int imgNum_03 = 3;
	private int imgNum_04 = 4;

	public bool isSwitching = false;
	public bool fadeOut = false;
	public bool fadeIn = false;

	// fade parameters
	public float fadeSpeed = 2f;

	public int randLayer;
	public int randImg;
	public int randColor;

	private object[] spriteBlue;
	private object[] spriteGreen;
	private object[] spritePurp;

	void Start () {
		spriteBlue = Resources.LoadAll ("Sprites/v2blue", typeof(Sprite));
		spriteGreen = Resources.LoadAll ("Sprites/v2green", typeof(Sprite));
		spritePurp = Resources.LoadAll ("Sprites/v2purp", typeof(Sprite));
	}

	void Update () {
		// constantly rotate imges
		img_01.transform.Rotate (Vector3.forward * rotateSpeed_01 * Time.deltaTime, Space.Self);
		img_02.transform.Rotate (Vector3.forward * rotateSpeed_02 * Time.deltaTime, Space.Self);
		img_03.transform.Rotate (Vector3.forward * rotateSpeed_03 * Time.deltaTime, Space.Self);
		img_04.transform.Rotate (Vector3.forward * rotateSpeed_04 * Time.deltaTime, Space.Self);

		// fade between different colors
		if (isSwitching) {
			if (fadeOut == false) {
				Color tmpColor = layers [randLayer].color;
				tmpColor.a = Mathf.Lerp (layers [randLayer].color.a, 0, Time.deltaTime * fadeSpeed);
				layers [randLayer].color = tmpColor;
				if (layers [randLayer].color.a <= 0.001f) {
					fadeOut = true;
					// switch image based on random number
					switch (randColor) {
					case 0:
						layers [randLayer].sprite = spriteBlue [randImg] as Sprite;
						//Debug.Log ("Color: " + randColor + " Img: " + layers [randLayer].sprite.name);
						break;
					case 1:
						layers [randLayer].sprite = spriteGreen [randImg] as Sprite;
						//Debug.Log ("Color: " + randColor + " Img: " + layers [randLayer].sprite.name);
						break;
					case 2:
						layers [randLayer].sprite = spritePurp [randImg] as Sprite;
						//Debug.Log ("Color: " + randColor + " Img: " + layers [randLayer].sprite.name);
						break;
					default:
						break;
					}
				}
			} else if (fadeOut == true && fadeIn == false) {
				Color tmpColor = layers [randLayer].color;
				tmpColor.a = Mathf.Lerp (layers [randLayer].color.a, 1, Time.deltaTime * fadeSpeed);
				layers [randLayer].color = tmpColor;
				if (layers [randLayer].color.a >= 0.99f) {
					layers [randLayer].color = new Color(layers [randLayer].color.r,
						layers [randLayer].color.g,
						layers [randLayer].color.b, 
						layers [randLayer].color.a);
					// reset other parameters
					fadeIn = true;
					isSwitching = false;
				}
			}
		}

		if (!isSwitching) {
			fadeIn = false;
			fadeOut = false;
		}

	}

	// rotate images
	public void rotateImg01_cw () {
		if (rotateSpeed_01 < rotateSpeedLimit) {
			rotateSpeed_01++;
		}
	}

	public void rotateImg02_cw () {
		if (rotateSpeed_02 < rotateSpeedLimit) {
			rotateSpeed_02++;
		}
	}

	public void rotateImg03_cw () {
		if (rotateSpeed_03 < rotateSpeedLimit) {
			rotateSpeed_03++;
		}
	}

	public void rotateImg04_cw () {
		if (rotateSpeed_04 < rotateSpeedLimit) {
			rotateSpeed_04++;
		}
	}

	public void rotateImg01_ccw () {
		if (Mathf.Abs(rotateSpeed_01) <= rotateSpeedLimit) {
			rotateSpeed_01--;
		}
	}

	public void rotateImg02_ccw () {
		if (Mathf.Abs(rotateSpeed_02) <= rotateSpeedLimit) {
			rotateSpeed_02--;
		}
	}

	public void rotateImg03_ccw () {
		if (Mathf.Abs(rotateSpeed_03) <= rotateSpeedLimit) {
			rotateSpeed_03--;
		}
	}

	public void rotateImg04_ccw () {
		if (Mathf.Abs(rotateSpeed_04) <= rotateSpeedLimit) {
			rotateSpeed_04--;
		}
	}

	// switch images
	public void randomSwitchImages ()
	{
		if (isSwitching == false) {
			isSwitching = true;
			// choose random layers
			// random integer is maximally exclusive
			randLayer = Random.Range (0, 4);
			// choose random colors
			randColor = Random.Range (0, 3);
			switch (randColor) {
			case 0: 
				randImg = Random.Range (0, spriteBlue.Length - 1);
				break;
			case 1:
				randImg = Random.Range (0, spriteGreen.Length - 1);
				break;
			case 2:
				randImg = Random.Range (0, spritePurp.Length - 1);
				break;
			default:
				break;
			}
		}
	}

//	// super fast switch images
//	public void FastrandomSwitchImages ()
//	{
//		if (allSprites.Count >= 1) {
//			// choose random layers
//			int fastRandLayer = Random.Range (0, 3);
//			if (fastRandLayer == 0) {
//				int fastRandImg = Random.Range (0, allSprites.Count - 1);
//				layers[fastRandLayer].sprite = allSprites [fastRandImg];
//			} else if (fastRandLayer == 1) {
//				int fastRandImg = Random.Range (0, allSprites.Count - 1);
//				layers[fastRandLayer].sprite = allSprites [fastRandImg];
//			} else if (fastRandLayer == 2) {
//				int fastRandImg = Random.Range (0, allSprites.Count - 1);
//				layers[fastRandLayer].sprite = allSprites [fastRandImg];
//			} else if (fastRandLayer == 3) {
//				int fastRandImg = Random.Range (0, allSprites.Count - 1);
//				layers[fastRandLayer].sprite = allSprites [fastRandImg];
//			}
//		} else {
//			print ("no sprite to switch.");
//		}
//	}
}
