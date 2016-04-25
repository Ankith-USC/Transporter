using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class goal : MonoBehaviour {

	public static bool showMsg = false;
	public AudioSource goalSound;
	GameObject[] reinforcements;

	void Start ()
	{
		showMsg = false;
	}

	void OnTriggerEnter(Collider other)
	{

		if (other.gameObject.name == "player") {
			xa.goal1 = 1;
			if (xa.levelNumber == 1) {
				reinforcements = GameObject.FindGameObjectsWithTag ("Reinforce");
				foreach (GameObject obj in reinforcements) {
					obj.tag = "Enemy";
					obj.GetComponent<SpriteRenderer> ().enabled = true;
				}
			}
			//4-23
			goalSound.Play();
			showMsg = true;
			if (GameObject.Find ("F") != null) {
				//4-23
				goalSound.Play();
				GameObject.Find ("F").GetComponent<SpriteRenderer> ().enabled = true;
				GameObject.Find ("F").GetComponent<BoxCollider> ().enabled = true;
			}
			if (GameObject.Find ("G") != null) {
				//4-23
				goalSound.Play();
				GameObject.Find ("G").GetComponent<SpriteRenderer> ().enabled = true;
				GameObject.Find ("G").GetComponent<BoxCollider> ().enabled = true;
			}
			if (GameObject.Find ("S") != null) {
				//4-23
				goalSound.Play();
				GameObject.Find ("S").GetComponent<SpriteRenderer> ().enabled = true;
				GameObject.Find ("S").GetComponent<BoxCollider> ().enabled = true;
			}
			ExitGate.Show();
			Destroy (gameObject);
			enemymovement.enemy_moveSpeed = 6f;
		}
	}
		
}