using UnityEngine;
using System.Collections;

public class BtnHide : MonoBehaviour {

	// Use this for initialization
	void Start () {
		gameObject.GetComponent<CanvasRenderer> ().SetAlpha (0);
	}

}
