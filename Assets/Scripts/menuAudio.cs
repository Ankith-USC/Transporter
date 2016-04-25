using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;
using System.Text;

public class menuAudio : MonoBehaviour {

	public static float volume;
	public static menuAudio instance = null;
	private static GameObject volumeSlider;
	public static bool playAudio;
	public static string filePath = "";
	public static StreamReader inputStream;
	public static StreamWriter outPutstream;

	public static menuAudio Instance{
		get {
			return instance; 
		}
	}
	void Awake() {
		if (instance != null && instance != this) {
			Destroy(this.gameObject);
			return;
		} else {
			instance = this;
		}
		if(playAudio)
		DontDestroyOnLoad(this.gameObject);
	}

	void Start () {

		filePath = Application.persistentDataPath + "/menuAudio.txt";

		if (!File.Exists (filePath))
			reset ();
		
		playAudio = true;
		readTextFile ();
	}

	public void Update () {
		volume = AudioListener.volume;
	}

	public void updateVolume()
	{
		AudioListener.volume = GameObject.Find ("Slider").GetComponent<Slider> ().value;
		writeConfigFile (AudioListener.volume);
	}

	public void readTextFile()
	{
		inputStream = new StreamReader(filePath);
		while(!inputStream.EndOfStream)
		{
			string line = inputStream.ReadLine();
			AudioListener.volume = float.Parse(line);
			GameObject.Find ("Slider").GetComponent<Slider> ().value = AudioListener.volume;
		}
	}

	public static void writeConfigFile(float volume)
	{
		if(File.Exists(filePath))
			File.Delete(filePath);

		outPutstream = new StreamWriter(filePath);
		outPutstream.WriteLine(volume);	
		outPutstream.Close();
	}

	public void reset()
	{
		if(File.Exists(filePath))
			File.Delete(filePath);

		outPutstream = new StreamWriter(filePath);
		float temp = 1;
		outPutstream.WriteLine(temp);	
		outPutstream.Close();
	}

}
