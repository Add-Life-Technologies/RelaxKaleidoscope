using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ReadMeButton : MonoBehaviour, ISelectHandler , IPointerEnterHandler, IPointerExitHandler 
{
	public int TargetImg;
	public enum direction {
		cw,
		ccw
	}
	public direction RotateDirection;
	// When highlighted with mouse.
	public void OnPointerEnter(PointerEventData eventData)
	{
		// Do something.
		// Debug.Log("<color=red>Event:</color> Completed mouse highlight.");
		if (RotateDirection == direction.cw) {
			switch (TargetImg) {
			case 1:
				InvokeRepeating ("rotateCW01", 0f, .3f);
				break;
			case 2:
				InvokeRepeating ("rotateCW02", 0f, .3f);
				break;
			case 3:
				InvokeRepeating ("rotateCW03", 0f, .3f);
				break;
			case 4:
				InvokeRepeating ("rotateCW04", 0f, .3f);
				break;
			}
		} else if (RotateDirection == direction.ccw) {
			switch (TargetImg) {
			case 1:
				InvokeRepeating ("rotateCCW01", 0f, .3f);
				break;
			case 2:
				InvokeRepeating ("rotateCCW02", 0f, .3f);
				break;
			case 3:
				InvokeRepeating ("rotateCCW03", 0f, .3f);
				break;
			case 4:
				InvokeRepeating ("rotateCCW04", 0f, .3f);
				break;
			}
		}
	}

	public void OnPointerExit (PointerEventData eventData) {
		CancelInvoke ();
		print ("CancelInvoke: " + TargetImg);
	}

	public void rotateCW01 () {
		//autoRotateImg.instance.rotateImg01_cw ();
	}

	public void rotateCW02 () {
		//autoRotateImg.instance.rotateImg02_cw ();
	}

	public void rotateCW03 () {
		//autoRotateImg.instance.rotateImg03_cw ();
	}

	public void rotateCW04 () {
		//autoRotateImg.instance.rotateImg04_cw ();
	}

	public void rotateCCW01 () {
		//autoRotateImg.instance.rotateImg01_ccw ();
	}
	public void rotateCCW02 () {
		//autoRotateImg.instance.rotateImg02_ccw ();
	}
	public void rotateCCW03 () {
		//autoRotateImg.instance.rotateImg03_ccw ();
	}
	public void rotateCCW04 () {
		//autoRotateImg.instance.rotateImg04_ccw ();
	}
	// When selected.
	public void OnSelect(BaseEventData eventData)
	{
		// Do something.
		// Debug.Log("<color=red>Event:</color> Completed selection.");
	}
}