﻿using UnityEngine;
using System.Collections;

public class SaveButton : MonoBehaviour {	
	public bool exitEnabled = true;
	public Texture exitTexture1, exitTexture2;
	public GameObject player;
	public sqlScript db = new sqlScript();
	private string scene,posX,posY;

	void OnGUI(){
		if(exitTexture1){
			if(GUI.Button(new Rect(10, 10, 50, 50), "Save")){
				player = GameObject.FindWithTag("Player");
				scene = Application.loadedLevelName;
				Debug.Log(scene);
				posX=player.transform.position.x.ToString();
				posY=player.transform.position.y.ToString();
				db.updatePosition(scene,posX,posY);
				print("Partida Guardada");
			}		
		}
	}
}
