using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class splash_LA : MonoBehaviour {
	
	public Button conti;
	void Start () {
		conti = conti.GetComponent<Button>();
	}
	
	public void nextLevel(){
		if(xa.levelNumber == 1)
			SceneManager.LoadScene("level1");
		else if(xa.levelNumber == 2)
			SceneManager.LoadScene("level2");
		else if(xa.levelNumber == 3)
			SceneManager.LoadScene("level1");
	}
}
