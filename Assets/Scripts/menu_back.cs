using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;
using System.Text;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;

public class menu_back : MonoBehaviour {

	public Canvas instra;
	public Canvas credits;
	public Canvas instructions;
	public Canvas shot1;
	public Canvas shot2;
	public Canvas shot3;
	public Canvas shot4;
	public Canvas shot1_1;
	public Canvas shot1_2;
	public Canvas shot1_3;
	public Canvas shot2_1;
	public Canvas shot2_2;
	public Canvas shot3_1;
	public Canvas shot3_2;
	public Canvas shot4_1;

	public static string filePath = "";

	public static StreamReader inputStream;
	public static StreamWriter outPutstream;

	void Start () {

		filePath = Application.persistentDataPath + "/mapper.txt";
		instra = instra.GetComponent<Canvas>();
		credits = credits.GetComponent<Canvas>();
		instructions = instructions.GetComponent<Canvas>();
		shot1 = shot1.GetComponent<Canvas>();
		shot2 = shot2.GetComponent<Canvas>();
		shot3 = shot3.GetComponent<Canvas>();
		shot4 = shot4.GetComponent<Canvas>();
		shot1_1 = shot1_1.GetComponent<Canvas>();
		shot1_2 = shot1_2.GetComponent<Canvas>();
		shot1_3 = shot1_3.GetComponent<Canvas>();
		shot2_1 = shot2_1.GetComponent<Canvas>();
		shot2_2 = shot2_2.GetComponent<Canvas>();
		shot3_1 = shot3_1.GetComponent<Canvas>();
		shot3_2 = shot3_2.GetComponent<Canvas>();
		shot4_1 = shot4_1.GetComponent<Canvas>();
		credits.enabled = false;
		instra.enabled = false;
		instructions.enabled = false;
		shot1.enabled = false;
		shot2.enabled = false;
		shot3.enabled = false;
		shot4.enabled = false;
		shot1_1.enabled = false;
		shot1_2.enabled = false;
		shot1_3.enabled = false;
		shot2_1.enabled = false;
		shot2_2.enabled = false;
		shot3_1.enabled = false;
		shot3_2.enabled = false;
		shot4_1.enabled = false;
	}
			
	public void showCan(){
		instra.enabled = true;
	}
	
	public void showCredits(){
		credits.enabled = true;
		instra.enabled = false;
	
	}

	public void showInstructions(){
		instructions.enabled = true;
		instra.enabled = false;
	}
		
	public void back(){
		instra.enabled = false;

	}
	
	//from credits to menu
	public void getBack(){
		credits.enabled = false;
		instra.enabled = true;
	}

	public void piche(){
		instructions.enabled = false;
		instra.enabled = true;
	}

	public void show_shot1(){
		instructions.enabled = false;
		shot1.enabled = true;
	}
	public void hide_shot1(){
		instructions.enabled = true;
		shot1.enabled = false;
	}

	public void show_shot1_1(){
		shot1.enabled = false;
		shot1_1.enabled = true;
	}
	public void hide_shot1_1(){
		shot1.enabled = true;
		shot1_1.enabled = false;
	}
	public void show_shot1_2(){
		shot1.enabled = false;
		shot1_2.enabled = true;
	}
	public void hide_shot1_2(){
		shot1.enabled = true;
		shot1_2.enabled = false;
	}
	public void show_shot1_3(){
		shot1.enabled = false;
		shot1_3.enabled = true;
	}
	public void hide_shot1_3(){
		shot1.enabled = true;
		shot1_3.enabled = false;
	}


	public void show_shot2(){
		instructions.enabled = false;
		shot2.enabled = true;
	}
	public void hide_shot2(){
		instructions.enabled = true;
		shot2.enabled = false;
	}
	public void show_shot2_1(){
		shot2.enabled = false;
		shot2_1.enabled = true;
	}
	public void hide_shot2_1(){
		shot2.enabled = true;
		shot2_1.enabled = false;
	}
	public void show_shot2_2(){
		shot2.enabled = false;
		shot2_2.enabled = true;
	}
	public void hide_shot2_2(){
		shot2.enabled = true;
		shot2_2.enabled = false;
	}

	public void show_shot3(){
		instructions.enabled = false;
		shot3.enabled = true;
	}
	public void hide_shot3(){
		instructions.enabled = true;
		shot3.enabled = false;
	}
	public void show_shot3_1(){
		shot3.enabled = false;
		shot3_1.enabled = true;
	}
	public void hide_shot3_1(){
		shot3.enabled = true;
		shot3_1.enabled = false;
	}
	public void show_shot3_2(){
		shot3.enabled = false;
		shot3_2.enabled = true;
	}
	public void hide_shot3_2(){
		shot3.enabled = true;
		shot3_2.enabled = false;
	}

	public void show_shot4(){
		instructions.enabled = false;
		shot4.enabled = true;
	}
	public void hide_shot4(){
		instructions.enabled = true;
		shot4.enabled = false;
	}
	public void show_shot4_1(){
		shot4.enabled = false;
		shot4_1.enabled = true;
	}
	public void hide_shot4_1(){
		shot4.enabled = true;
		shot4_1.enabled = false;
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
	}
	
}
