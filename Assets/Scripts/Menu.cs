using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {
	
	public Canvas ExitMenu;
	public Button playtext;
	public Button optionstext;
	public Button quittext;
	public Image instr;
	//public Button back;
	 
	// Use this for initialization
	void Start () {
		ExitMenu = ExitMenu.GetComponent<Canvas>();
		playtext = playtext.GetComponent<Button>();
		optionstext = optionstext.GetComponent<Button>();
		quittext = quittext.GetComponent<Button>();
		instr = instr.GetComponent<Image>();

		instr.enabled = false;
		ExitMenu.enabled = false;
		}
		
		public void ExitPress(){
			ExitMenu.enabled = true;
			playtext.enabled = false;
			optionstext.enabled = false;
			quittext.enabled = false;
	//		back.enabled = false;
		}
		
		public void NoPress(){
			ExitMenu.enabled = false;
			playtext.enabled = true;
			optionstext.enabled = true;
			quittext.enabled = true;
	//		back.enabled = false;
						
		}
		
		public void startLevel(){
		SceneManager.LoadScene("Level Selection");
		}
		
		public void QuitGame(){
			Application.Quit();
		}
		
		public void OptionPress(){
			instr.enabled = true;
	//		back.enabled = false;	
		
		}
	}
