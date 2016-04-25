using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class bom_splash : MonoBehaviour {
	
	public Button cont;	
	void Start () {
		cont = cont.GetComponent<Button>();
	}
	
	public void nextLevel(){
		SceneManager.LoadScene("level3");
	}
	
}
