using UnityEngine;
using System.Collections;

public class TrapShow : MonoBehaviour 
{
	private Renderer thisRenderer;

	void OnTriggerEnter(Collider other)
	{

		if (other.gameObject.name == "player") {
			thisRenderer = GetComponent<Renderer> ();
			thisRenderer.enabled = true;	
		}
	}
}