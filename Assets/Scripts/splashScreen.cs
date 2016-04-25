using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class splashScreen : MonoBehaviour {

	public float delayTime = 4;
	IEnumerator Start(){
		yield return new WaitForSeconds (delayTime);
		SceneManager.LoadScene("LA_SplashScreen");
	}
}
