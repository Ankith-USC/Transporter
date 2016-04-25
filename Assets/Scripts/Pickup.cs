using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour 
{
	//public AudioSource item;
	private GameObject thisGameObject;
	private Renderer thisRenderer;
	public AudioSource keySound;
	
	void Awake() 
	{
		thisGameObject = gameObject;
		thisRenderer = GetComponent<Renderer>();
	}
	
	// Called from Player.cs when the player enteres the pickup
	public void PickMeUp()
	{	
		//item.Play ();
		switch (thisGameObject.name) {
		case "G": 			//Gravity Powerup
			xa.gPower = true;
			xa.offGravity = true;
			//4-23
			keySound.Play();
			GameObject.FindGameObjectWithTag ("Gravity").GetComponent<CanvasRenderer> ().SetAlpha (0.4f);
			break;
		case "F":			//Freeze Powerup
			//4-23
			keySound.Play();
			xa.fPower = true;
			GameObject.FindGameObjectWithTag ("Freeze").GetComponent<CanvasRenderer> ().SetAlpha (0.4f);
			break;
		case "S":			//Freeze Powerup
			xa.sPower = true;
			//4-23
			keySound.Play();
			GameObject.FindGameObjectWithTag ("Super").GetComponent<CanvasRenderer> ().SetAlpha (0.4f);
			break;
		}

		switch (thisGameObject.tag) {
		case "Coin":	
			//4-23
			keySound.Play();
			xa.coinCount++;
			break;
		case "Key":
			//4-23
			keySound.Play();
			xa.keycount++;
			break;
		}

		Debug.Log (xa.coinCount);

		thisRenderer.enabled = false; // hide the pickup
		//thisGameObject.tag = "Untagged"; // untag the pickup so it won't get triggered again
		Destroy(thisGameObject);
	}
}
