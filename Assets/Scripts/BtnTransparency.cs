using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BtnTransparency : MonoBehaviour {
	// Use this for initialization
	void Start () {
		if(gameObject.name != "Gravity" && gameObject.name != "Freeze" && gameObject.name != "Super")
			gameObject.GetComponent<CanvasRenderer>().SetAlpha(0.4f);
	}

	public void Press(){
		if (xa.offGravity == false && gameObject.name == "Gravity")
			gameObject.GetComponent<CanvasRenderer> ().SetAlpha (0);
		else if (xa.fPower == false && gameObject.name == "Freeze")
			gameObject.GetComponent<CanvasRenderer> ().SetAlpha (0);
		else if (xa.sPower == false && gameObject.name == "Super")
			gameObject.GetComponent<CanvasRenderer> ().SetAlpha (0); 
		else
			gameObject.GetComponent<CanvasRenderer> ().SetAlpha (1f);

	}

	public void PressRelease(){
		if (xa.offGravity == false && gameObject.name == "Gravity")
			gameObject.GetComponent<CanvasRenderer> ().SetAlpha (0);
		else if (xa.fPower == false && gameObject.name == "Freeze")
			gameObject.GetComponent<CanvasRenderer> ().SetAlpha (0);
		else if (xa.sPower == false && gameObject.name == "Super")
			gameObject.GetComponent<CanvasRenderer> ().SetAlpha (0);
		else
			gameObject.GetComponent<CanvasRenderer> ().SetAlpha (0.4f);

	}

}