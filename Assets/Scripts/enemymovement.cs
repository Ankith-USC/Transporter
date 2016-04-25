using UnityEngine;
using System.Collections;

public class enemymovement : MonoBehaviour {

	public static float enemy_moveSpeed = 1.5f;
	private Transform thisTransform;
	private int moveDirX;
	private Vector3 movement;
	private Vector3 enemyPos;
	Animator myanimator;
	private bool flip;

	void Awake() 
	{
		thisTransform = transform;
	}

	void Start () {
		moveDirX = 1;
		enemy_moveSpeed = 1.5f;
		enemyPos = thisTransform.position;
		myanimator = GetComponent<Animator>();
		flip = false;
	}

	void Update () {
		movement = new Vector3(moveDirX, 0f,0f) * Time.deltaTime*enemy_moveSpeed;
		thisTransform.Translate(movement.x,movement.y, 0f);
	}

	void OnTriggerEnter(Collider other)
	{

		if (other.gameObject.name == "player" && gameObject.CompareTag("Enemy")) {
				Player.alive = false;
		}
		if (xa.isSuperOn) {
			if (other.gameObject.name=="SuperMan") {
				gameObject.SetActive (false);
				Invoke ("activateEnemy", 5);
			}
		}

		if (other.gameObject.CompareTag("Flame")) {
			gameObject.SetActive (false);
			Invoke ("activateEnemy", 5);
		}

		if (other.gameObject.CompareTag("EnemyBound")) {
			flip = !flip;
			myanimator.SetBool("flip", flip);
			if (moveDirX == 1)
				moveDirX = -1;
			else
				moveDirX = 1;
		}
	}

	void activateEnemy()
	{
		this.transform.position = new Vector3(enemyPos.x, enemyPos.y, enemyPos.z);
		gameObject.SetActive (true);
	}
		
}
