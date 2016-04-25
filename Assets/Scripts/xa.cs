using UnityEngine;
using System.Collections;
public class xa : MonoBehaviour {

	public static int keycount = 0; // scoring
	public static int goal1 = 0;	// Goal
	public static bool exitDoor = false;	//Finish door flag
	public static bool prisonDoor = false;	//Goal door flag
	public static bool gameFinish = false;	//Game finish flag
	public static bool gPower = false;		//Gravity powerup flag
	public static bool fPower = false;
	public static bool sPower = false;// Superpowerup flag
	public static int coinCount;
	public static int levelNumber;
	public static string levelStatus;
	public static int levelStars;
	public static string scene;
	public static bool isSuperOn;
	public static bool offGravity;

	void Start()
	{
		isSuperOn = false;
		coinCount = 0;
		keycount = 0;
		goal1 = 0;
		gPower = false;
		fPower = false;
		sPower = false;
		exitDoor = false;
	    prisonDoor = false;
	    gameFinish = false;
		offGravity = false;
	}

		
}
