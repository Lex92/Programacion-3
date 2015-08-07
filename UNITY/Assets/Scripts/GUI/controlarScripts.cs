using UnityEngine;
using System.Collections;

public class controlarScripts : MonoBehaviour {
	private bool menuActivado=false;
	private float sizeX,sizeY;
	private Music m;
	private PauseButton pb;
	private SaveButton sb;
	
	void Start(){
		sizeX = Screen.width/12;
		sizeY = Screen.height;
		m = GetComponent<Music>();
		pb = GetComponent<PauseButton>();
		sb = GetComponent<SaveButton>();
		m.sizeX = pb.sizeX = sb.sizeX = sizeX;
		m.sizeY = pb.sizeY = sb.sizeY = sizeY/5;
		m.offsetX = pb.offsetX = sb.offsetX = 10;
		sb.offsetY = 10 + sizeY/5;
		pb.offsetY = 20 + sizeY/5*2;
		m.offsetY = 30 + sizeY/5*3;
	}

	void OnGUI(){  
		GUI.depth = 1;
		if (menuActivado) {
			GUI.Box (new Rect(10,10,sizeX,sizeY), "");
		}

		if (GUI.Button (new Rect (10, 10, sizeX, sizeY/10), "MENU")) {
			if(menuActivado){
				menuActivado = false;
			}else{
				menuActivado = true;				
			}
										
			if (sb.enabled) {
				sb.enabled = false;
			} else {
				sb.enabled = true;
			}

			if (pb.enabled) {
				pb.enabled = false;
			} else {
				pb.enabled = true;
			}

			if (m.enabled) {
				m.enabled = false;
			} else {
				m.enabled = true;
			}
/*
			if (GetComponent<menuMonstruos> ().enabled) {
				GetComponent<menuMonstruos> ().enabled = false;
			} else {
				GetComponent<menuMonstruos> ().enabled = true;
			}
			*/
		} 		
	}
}
