using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameFinish : MonoBehaviour {
	
	public void reload(){
		SceneManager.LoadScene(xa.scene);
	}
	public void Menu(){
		SceneManager.LoadScene("UI");
	}
	public void NextLevel(){
		SceneManager.LoadScene("Level Selection");
	}
	
}
