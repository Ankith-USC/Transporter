using UnityEngine;
using System.Collections;

public class Freeze : MonoBehaviour {

	private float oldspeed;
	private float oldflyspeed;
	private GameObject[] enemies;
	// Use this for initialization
	void Start () {
	
	}

	public void onFreeze()
	{
		if (xa.fPower) {
			GameObject.FindGameObjectWithTag ("Freeze").GetComponent<CanvasRenderer> ().SetAlpha (0);
			xa.fPower = false;
			oldspeed = enemymovement.enemy_moveSpeed;
			oldflyspeed = FlyingEnemy.enemy_flySpeed;
			enemymovement.enemy_moveSpeed = 0;
			FlyingEnemy.enemy_flySpeed = 0;
			enemies = GameObject.FindGameObjectsWithTag ("Enemy");
			Enemy.freezeOn = true;
			foreach (GameObject enemy in enemies) {
				enemy.GetComponent<BoxCollider> ().enabled = false;
				enemy.GetComponent<Animator> ().enabled = false;
			}
			Invoke ("endFreeze", 6);
		}
	}

	private void endFreeze()
	{	
		enemies = GameObject.FindGameObjectsWithTag ("Enemy");
		foreach (GameObject enemy in enemies) {
			enemy.GetComponent<BoxCollider> ().enabled = true;
			enemy.GetComponent<Animator> ().enabled = true;
		}
		enemymovement.enemy_moveSpeed = oldspeed;
		FlyingEnemy.enemy_flySpeed = oldflyspeed;
		Enemy.freezeOn = false;
	}

	public static void end()
	{	
		
		enemymovement.enemy_moveSpeed = 6f;
		FlyingEnemy.enemy_flySpeed = 3f;
		Enemy.freezeOn = false;
	}
}
