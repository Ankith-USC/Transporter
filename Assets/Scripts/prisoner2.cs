using UnityEngine;
using System.Collections;

public class prisoner2 : MonoBehaviour {
	private bool flip;
	private int moveDirX;
	private Vector3 movement;
	Animator myanimator;

	// Use this for initialization
	void Start () {
		flip = false;
		myanimator = GetComponent<Animator>();
		moveDirX = -1;
	
	}
	
	// Update is called once per frame
	void Update () {

		movement = new Vector3(moveDirX, 0f,0f) * Time.deltaTime*1.5f;
		transform.Translate(movement.x,movement.y, 0f);
	}

	void OnTriggerEnter(Collider other)
	{

		if (other.gameObject.CompareTag("prisColl")) {
			flip = !flip;
			myanimator.SetBool("flip", flip);
			moveDirX *= -1;
		}
	}
}
