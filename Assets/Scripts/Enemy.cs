using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	// Flag to check if freeze button is pressed
	public static bool freezeOn = false;

	void Start(){
		freezeOn = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (freezeOn && gameObject.CompareTag ("Enemy")) {
			gameObject.GetComponent<BoxCollider> ().isTrigger = false;
			gameObject.GetComponent<SpriteRenderer> ().color = new Color (0f, 150f, 255f, 1f);
		} else {
			gameObject.GetComponent<BoxCollider> ().isTrigger = true;
			gameObject.GetComponent<SpriteRenderer> ().color = new Color (255f, 255f, 255f, 1f);
		}
	}
}
