using UnityEngine;
using System.Collections;

public class Trap : MonoBehaviour {
	//4-23
	public AudioSource trapVoice;

	void Start()
	{
		gameObject.GetComponent<BoxCollider> ().enabled = true;
	}

	void OnTriggerEnter(Collider other)
	{

		if (other.gameObject.name == "player") {
			this.transform.Translate (0, -1.79f, 0);
			Player.lifeCount = 0;
			Player.alive = false;
			gameObject.GetComponent<BoxCollider> ().enabled = false;
			trapVoice.Play ();
			Animator myAnimator = GameObject.Find ("player").GetComponent<Animator> ();
			myAnimator.SetBool ("trapdead", true);

		}
	}

}