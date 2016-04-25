using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class AccelerometerInput : MonoBehaviour {

	private static bool isGravityOn = false;

	void Start()
	{
		isGravityOn = false;
	}

	// Update is called once per frame
	void Update () {

		if (isGravityOn) {
			if (Input.acceleration.x != 0) {
				Player.moveSpeed = 0;
				enemymovement.enemy_moveSpeed = 0;
				transform.Translate (Input.acceleration.x, 0, 0);
			} 
			else {
				Player.moveSpeed = 5;
				enemymovement.enemy_moveSpeed = 6;
			}

			if (this.transform.position.x < -21.5f)
			{
				this.transform.position = new Vector3(16.5f, this.transform.position.y, this.transform.position.z);
			}

			if (this.transform.position.x > 16.5f)
			{
				this.transform.position = new Vector3(-21.5f, this.transform.position.y, this.transform.position.z);
			}

		}
	}

	public void onGravity(){
		if (xa.gPower && Player.grounded) {
			isGravityOn = true;
			xa.offGravity = false;
			Invoke ("endGravity", 8);
		}
	}

	private void endGravity()
	{
		xa.gPower = false;
		isGravityOn = false;
		Player.moveSpeed = 5;
		enemymovement.enemy_moveSpeed = 6;
	}

	public static void end()
	{
		isGravityOn = false;
	}
		
}

