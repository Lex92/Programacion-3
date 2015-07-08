using UnityEngine;
using System.Collections;

public class ExitButton : MonoBehaviour {

	
	public bool exitEnabled = true;
	public Texture exitTexture1, exitTexture2;
	
	void OnGUI(){

		// exit button will only be avaiable on unity, as it has no own "exit button"
		/*#if UNITY_ANDROID || UNITY_IPHONE || UNITY_STANDALONE_LINUX || UNITY_WP8
		if(exitEnabled){
			if(!exitTexture1){
				if (GUI.Button(new Rect(Screen.width-60, 10, 50, 50), "EXIT"))
					//Debug.Log("Clicked the button EXIT");
					Application.Quit();
			}else if (GUI.Button(new Rect(Screen.width-(10+Screen.width/10), 10, Screen.height/5, Screen.height/5), exitTexture1,GUIStyle.none)){
				//Debug.Log("Clicked the button with an image EXIT");
				exitTexture1 = exitTexture2;
				Application.Quit();
			}
		}
		#endif*/
		if((Screen.fullScreen)&& exitEnabled){
			if(!exitTexture1){
				if (GUI.Button(new Rect(Screen.width-60, 10, 50, 50), "EXIT"))
					//Debug.Log("Clicked the button EXIT");
					Application.Quit();
			}else if (GUI.Button(new Rect(Screen.width-(10+Screen.width/10), 10, Screen.height/5, Screen.height/5), exitTexture1,GUIStyle.none)){
				//Debug.Log("Clicked the button with an image EXIT");
				exitTexture1 = exitTexture2;
				Application.Quit();
			}
		}
	}
	/*
	//Save before quitting
	void OnApplicationPause(){
		//Debug.Log("pause");
		//PlayerPrefs.Save ();
	}
	*/
	/*
	void OnApplicationQuit(){
		//Debug.Log("quit");
		//PlayerPrefs.Save();
	}
	*/
}
