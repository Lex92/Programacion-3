using UnityEngine;
using System.Collections;

public class GuiScript : MonoBehaviour {

	public bool bagEnabled = true, exitEnabled = true, interactEnabled = true;
	public Texture bagTexture, exitTexture, interactTexture;
	
	void OnGUI(){
		if(bagEnabled){
			if(!bagTexture){
				if (GUI.Button(new Rect(10, 10, 50, 50), "BAG"))
					Debug.Log("Clicked the button BAG");
			}else if (GUI.Button(new Rect(10, 10, 50, 50), bagTexture,GUIStyle.none))
				Debug.Log("Clicked the button with an image BAG");
		}
		if(exitEnabled){
			if(!exitTexture){
				if (GUI.Button(new Rect(Screen.width-60, 10, 50, 50), "EXIT"))
					//Debug.Log("Clicked the button EXIT");
					Application.Quit();
			}else if (GUI.Button(new Rect(Screen.width-(10+Screen.width/10), 10, Screen.height/5, Screen.height/5), exitTexture,GUIStyle.none)){
				Debug.Log("Clicked the button with an image EXIT");
				exitTexture = interactTexture;
				Application.Quit();
				}
		}
		if(interactEnabled){
			if(!interactTexture){
				if (GUI.Button(new Rect(Screen.width-60, Screen.height-60, 50, 50), "INTERACT"))
					Debug.Log("Clicked the button INTERACT");
			}else if (GUI.Button(new Rect(Screen.width-60, Screen.height-60, 50, 50), interactTexture,GUIStyle.none))
				Debug.Log("Clicked the button with an image INTERACT");
		}
	}
}
