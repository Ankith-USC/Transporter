using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using System.Collections;

public class uiManager : MonoBehaviour {


	public Canvas gameoverMenu;
	public Canvas pauseMenu;
	public Canvas midway_message;
	public Image about;
	public Canvas gamefinish;
	public Text contin;
	public Text topic;
	public Text main;
	public static Canvas dupGamefinish;
	public static float volume = 1;

	public static Canvas backUpGameOver;

	// Use this for initialization
	void Start () {
		gameoverMenu = gameoverMenu.GetComponent<Canvas>();
		pauseMenu = pauseMenu.GetComponent<Canvas>();
		gamefinish = gamefinish.GetComponent<Canvas>();
		about = about.GetComponent<Image>();
		contin = contin.GetComponent<Text>();
		topic = topic.GetComponent<Text>();
		main = main.GetComponent<Text>();
		topic.enabled = false;
		main.enabled = false;
		contin.enabled = false;
		about.enabled = false;
		pauseMenu.enabled = false;
		gameoverMenu.enabled = false;
		gamefinish.enabled = false;
		midway_message = GameObject.Find ("Midway Message").GetComponent<Canvas> ();
		midway_message.enabled = false;
		dupGamefinish = gamefinish;
		Time.timeScale = 1;
		backUpGameOver = gameoverMenu;
		AudioListener.volume = menuAudio.volume;
	}

	// Update is called once per frame
	void Update () {

		if (Player.alive == false && Player.lifeCount==0) {
			if (gameoverMenu == null)
				gameoverMenu = backUpGameOver;
			gameoverMenu.enabled = true;
		}			
	}
	
	public void ques(){
		about.enabled = true;
		contin.enabled = true;
		topic.enabled = true;
		main.enabled = true;
		goal.showMsg = false;
	}

	public void Pause(){
		if(Time.timeScale == 1){
			Time.timeScale = 0;
			pauseMenu.enabled = true;
		}
		else if(Time.timeScale == 0){
			Time.timeScale = 1;
			pauseMenu.enabled = false;
			about.enabled = false;
			contin.enabled = false;
			topic.enabled = false;
			main.enabled = false;
		}

	}
		

	public void reload(){
		Time.timeScale = 1;
		SceneManager.LoadScene(xa.scene);
		//Application.LoadLevel(Application.loadedLevel);
		goal.showMsg = false;
	}

	public void Menu(){
		DontDestroyOnLoad(this.gameObject);
		SceneManager.LoadScene("UI");
		goal.showMsg = false;
	}
	public void Quit(){
		Application.Quit ();
	}

	public void timerOver(){
		gameoverMenu.enabled = true;
	}

	public IEnumerator message(){
		midway_message.enabled = true;
		Time.timeScale = 0.1f;
		float pauseEndTime = Time.realtimeSinceStartup + 1;
		while (Time.realtimeSinceStartup < pauseEndTime)
		{
			yield return 0;
		}
		Time.timeScale = 1;
	}

	public void loadLON(){
		SceneManager.LoadScene ("Level Selection");
	}

	public Canvas getCanvas()
	{
		if (gamefinish == null)
			return gamefinish = dupGamefinish;
		else
			return gamefinish;
	}

	public void muteAudio(){

		if (AudioListener.pause == true) 
		{
			AudioListener.pause = false;
			AudioListener.volume = volume;
		} 
		else 
		{
			AudioListener.pause = true;
			volume = AudioListener.volume;
			AudioListener.volume = 0;
		}
	}
}