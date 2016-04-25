using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class countDownTimer : MonoBehaviour {


	public Text timerText;
	public static float timeRemaining;
	public uiManager over;
	public static bool timeOver=false;
	public static bool timerOn = false;

	private float t; 
	private string minutes;
	private string seconds;


	// Use this for initialization
	void Start () {
		if (xa.levelNumber == 1)
			timeRemaining = 90;
		else if (xa.levelNumber == 2)
			timeRemaining = 120;
		else if (xa.levelNumber == 3)
			timeRemaining = 120;
		timeOver = false;
		timerOn = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(timerOn)
		{
			timeRemaining -= Time.deltaTime;
			t = timeRemaining;
			minutes = ((int)t / 60).ToString();
			seconds = (t % 60).ToString ("f0");

			if (timeRemaining < 0) {
				over.timerOver ();
				timeOver = true;
			} else {
				timerText.text = minutes +" : " + seconds;
			}
		}
	}

	public static void startTimer()
	{
		timerOn = true;
	}
}
