using UnityEngine;
using System.Collections;

public class Super : MonoBehaviour {

	private float oldspeed;
	// Use this for initialization
	void Start () {

	}

	public void onSuper()
	{
		if (xa.sPower) {
			xa.isSuperOn = true;
			GameObject.FindGameObjectWithTag ("Super").GetComponent<CanvasRenderer> ().SetAlpha (0);
			xa.sPower = false;
			oldspeed = Player.moveSpeed;
			GameObject.Find ("player").name = "SuperMan";
			Player.moveSpeed = 9;
			GameObject.Find ("superanim").GetComponent<SpriteRenderer> ().enabled = true;
			GameObject.Find ("superanim").GetComponent<Animator> ().enabled = true;
			Invoke ("endSuper", 8);
		}
	}

	private void endSuper()
	{	xa.isSuperOn = false;
		GameObject.Find ("SuperMan").name = "player";
		Player.moveSpeed = oldspeed;
		GameObject.Find ("superanim").GetComponent<Animator> ().enabled = false;
		GameObject.Find ("superanim").GetComponent<SpriteRenderer> ().enabled = false;
	}

	public static void end()
	{	xa.isSuperOn = false;
		Player.moveSpeed = 5f;
		GameObject.Find ("superanim").GetComponent<Animator> ().enabled = false;
		GameObject.Find ("superanim").GetComponent<SpriteRenderer> ().enabled = false;
	}
}
