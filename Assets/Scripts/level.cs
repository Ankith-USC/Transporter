using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;
using System.Text;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;

public class level : MonoBehaviour {
	public Button LA;
	public Button LON;
	public Button BOM;
	
	public static string filePath = "";
	
	private static int[] levelNumber;
	private static string[] levelStatus;
	private static int[] levelStars;
	private string[] temp;
	
	//Star Count
	public int starCount;
	
	public Sprite[] StarSprites;
	public Image StarLAUI;
	public Image StarLONUI;
	public Image StarBOMUI;

	public Image lockLevel2;
	public Image lockLevel3;

	public Image lonCityImage;
	public Image bomCityImage;

	public static StreamReader inputStream;
	public static StreamWriter outPutstream;

	public void Start () {

		filePath = Application.persistentDataPath + "/mapper.txt";

		if (!File.Exists (filePath))
			reset ();

		levelNumber = new int[3];
		levelStatus = new string[3];
		levelStars = new int[3];

		readTextFile ();

		LA = LA.GetComponent<Button>();
		LON = LON.GetComponent<Button>();
		BOM = BOM.GetComponent<Button>();

		lockLevel2 = lockLevel2.GetComponent<Image>();
		lockLevel3 = lockLevel3.GetComponent<Image>();

		lonCityImage = lonCityImage.GetComponent<Image>();
		bomCityImage = bomCityImage.GetComponent<Image>();

		LON.enabled = true;
		BOM.enabled = true;

		lockLevel2.enabled = true;
		lockLevel3.enabled = true;

		lonCityImage.color = Color.gray;
		bomCityImage.color = Color.gray;

	}
	
	
	public void Update(){
		
		StarLAUI.sprite = StarSprites[levelStars[0]];
		StarLONUI.sprite = StarSprites[levelStars[1]];
		StarBOMUI.sprite = StarSprites[levelStars[2]];

		if (levelStatus [0] == "y") {
			LON.enabled = true;
			lockLevel2.enabled = false;
			lonCityImage.color = Color.white;
		}
		if (levelStatus [1] == "y") {
			BOM.enabled = true;
			lockLevel3.enabled = false;
			bomCityImage.color = Color.white;
		}

		if (xa.levelNumber > 0)
			menuAudio.playAudio = false; 
		else 
			menuAudio.playAudio = true; 
	}

	public void los(){
		SceneManager.LoadScene("LA_SplashScreen");
		xa.levelNumber = 1;
		xa.levelStatus = levelStatus[0];
		xa.levelStars = levelStars [0];
		xa.scene = "LA_SplashScreen";
	}
	
	public void lon(){
		SceneManager.LoadScene("splash_LON");
		xa.levelNumber = 2;
		xa.levelStatus = levelStatus [1];
		xa.levelStars = levelStars [1];
		xa.scene = "splash_LON";
	}

	public void bom(){
		SceneManager.LoadScene("Bom_splash");
		xa.levelNumber = 3;
		xa.levelStatus = levelStatus [2];
		xa.levelStars = levelStars [2];
		xa.scene = "Bom_splash";
	}

	public void readTextFile()
	{
		inputStream = new StreamReader(filePath);
		int i =0;
		while(!inputStream.EndOfStream)
		{
			string line = inputStream.ReadLine();
			temp = line.Split(',');

			levelNumber[i] = int.Parse(temp[0]);
			levelStatus[i] = temp[1];
			levelStars[i] = int.Parse(temp[2]);
			i++;
		}
	}

	public static void  updateConfig(int levelNo, string status, int stars)
	{
		levelStatus[levelNo-1] = status;
		levelStars[levelNo-1] = stars;
		writeConfigFile ();
	}

	public static void writeConfigFile()
	{
		if(File.Exists(filePath))
			File.Delete(filePath);

		outPutstream = new StreamWriter(filePath);

		for(int j = 0; j <3; j++)
		{
			outPutstream.WriteLine(levelNumber[j] + "," + levelStatus[j] + "," + levelStars[j]);	
		}
		outPutstream.Close();
	}

	public void reset()
	{
		if(File.Exists(filePath))
			File.Delete(filePath);

		outPutstream = new StreamWriter(filePath);

		for(int j = 0; j <3; j++)
		{
			outPutstream.WriteLine(j+1 + ",n," + 0 );	
		}
		outPutstream.Close();
		SceneManager.LoadScene("Level Selection");
	}
}
