using UnityEngine;
using System.Collections;

public class ObjHide : MonoBehaviour {

	// Use this for initialization
	void Start () {

		gameObject.GetComponent<SpriteRenderer> ().enabled = false;
		gameObject.GetComponent<BoxCollider> ().enabled = false;
	
	}
}
