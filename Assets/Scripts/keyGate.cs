using UnityEngine;
using System.Collections;

public class keyGate : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{

		if (other.gameObject.name == "player" && xa.keycount == Player.keyCount) {
			xa.keycount = 0;
			Destroy (gameObject);
			xa.prisonDoor = false;
		}else 
			xa.prisonDoor = true;
	}
	void OnTriggerExit(Collider other){
		xa.prisonDoor = false;
	}
}
