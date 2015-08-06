using UnityEngine;
using System.Collections;

public class controlarScripts : MonoBehaviour {
	private bool menuActivado=false;
	private float size;
	
	void Start(){
		size = Screen.width/20;
	}

	void OnGUI(){  
		GUI.depth = 1;
		if (menuActivado) {
			GUI.Box (new Rect (10, 10, 110, 270), "");
		}

		if (GUI.Button (new Rect (size-52, size-50, size+30, size-30), "MENU")) {	
			if(menuActivado){
				menuActivado = false;
			}else{
				menuActivado = true;				
			}
										
			if (GetComponent<SaveButton> ().enabled) {
				GetComponent<SaveButton> ().enabled = false;
			} else {
				GetComponent<SaveButton> ().enabled = true;
			}

			if (GetComponent<PauseButton> ().enabled) {
				GetComponent<PauseButton> ().enabled = false;
			} else {
				GetComponent<PauseButton> ().enabled = true;
			}

			if (GetComponent<Music> ().enabled) {
				GetComponent<Music> ().enabled = false;
			} else {
				GetComponent<Music> ().enabled = true;
			}

			if (GetComponent<ExitButton> ().enabled) {
				GetComponent<ExitButton> ().enabled = false;
			} else {
				GetComponent<ExitButton> ().enabled = true;
			}

			if (GetComponent<menuMonstruos> ().enabled) {
				GetComponent<menuMonstruos> ().enabled = false;
			} else {
				GetComponent<menuMonstruos> ().enabled = true;
			}
		} 		

	}
}
