using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ExitGate : uiManager {

	private static BoxCollider bc; 
	uiManager uiM;
	int stars;
	public level levelObject;
	Image image;
	public Sprite[] starImages;

	void Start() 
	{
		Time.timeScale = 1;
		bc = GetComponent<BoxCollider> ();
		bc.enabled = false;
		levelObject = new level ();
	}

	public static void Show()
	{
		bc.enabled = true;
	}

	void OnTriggerEnter(Collider other)
	{
		if ((other.gameObject.name == "player" || other.gameObject.name == "SuperMan") && xa.goal1 == 1) {

			xa.gameFinish = true;

			switch (xa.levelNumber) {
			case 1:
				Player.end ();
				AccelerometerInput.end ();
				break;

			case 2:
				Player.end ();
				Freeze.end ();
				break;

			case 3:
				Player.end ();
				Super.end ();
				break;
			}

			Destroy (gameObject);

			if(xa.levelStatus != "y")
				xa.levelStatus = "y";

			int lc = Player.lifeCount;

			if (lc == 2) {
				if (xa.coinCount == Player.coinCount)
					stars = 3;
				else
					stars = 2; 
			} else if (lc == 1 || lc == 0) 
			{
				if (xa.coinCount == Player.coinCount)
					stars = 2;
				else
					stars = 1;
			}	

			if (xa.levelStars < stars)
				xa.levelStars = stars;

			level.updateConfig (xa.levelNumber,xa.levelStatus,xa.levelStars);
			if (gamefinish == null)
				gamefinish = getCanvas ();
			image = gamefinish.gameObject.GetComponentInChildren<Image>();
			image.sprite = starImages [stars - 1];
			gamefinish.enabled = true;
			Time.timeScale = 0;
			xa.levelNumber = 0;
		} 
	}

}
