using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class IO{
	
	public static void SaveColor(CharacterMain c){
		if(!PlayerPrefs.HasKey("Tint")){
			PlayerPrefs.SetInt("Tint",0);
			PlayerPrefs.SetFloat("hairTint.b",c.hairTint.b);
			PlayerPrefs.SetFloat("hairTint.r",c.hairTint.r);
			PlayerPrefs.SetFloat("hairTint.g",c.hairTint.g);
			PlayerPrefs.SetFloat("hatTint.b",c.hatTint.b);
			PlayerPrefs.SetFloat("hatTint.r",c.hatTint.r);
			PlayerPrefs.SetFloat("hatTint.g",c.hatTint.g);
			PlayerPrefs.Save();
			Debug.Log("Se guardaron los colores de pelo");
		}
		Debug.Log(c.name);
		//PlayerPrefs.SetFloat("positionX",c.transform.position.x);
		//PlayerPrefs.SetFloat("positionY",c.transform.position.y);
	}/*
	public static void SavePos(){
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		PlayerPrefs.SetFloat("positionX",player.transform.position.x);
		PlayerPrefs.SetFloat("positionY",player.transform.position.y);
		//PlayerPrefs.SetFloat("positionZ",pos.z);
		PlayerPrefs.Save();
		Debug.Log("position saved");
	}
	public static void LoadPos(){
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		player.transform.position.Set(PlayerPrefs.GetFloat("positionX"),PlayerPrefs.GetFloat("positionX"),0);
	}*/
	
	
	public static bool LoadColor(CharacterMain c){
		if(PlayerPrefs.HasKey("Tint")){
			c.hairTint.a=1;
			c.hairTint.b=PlayerPrefs.GetFloat("hairTint.b");
			c.hairTint.r=PlayerPrefs.GetFloat("hairTint.r");
			c.hairTint.g=PlayerPrefs.GetFloat("hairTint.g");
			c.hatTint.a=1;
			c.hatTint.b=PlayerPrefs.GetFloat("hatTint.b");
			c.hatTint.r=PlayerPrefs.GetFloat("hatTint.r");
			c.hatTint.g=PlayerPrefs.GetFloat("hatTint.g");
			Debug.Log("Se cargaron los colores de pelo");
			//PlayerPrefs.DeleteAll();
			return true;
		}else{
			return false;
		}
	}
	
	public static void LoadScene(string sceneName){
		Debug.Log(sceneName);
		Application.LoadLevel(sceneName);
		Debug.Log(sceneName);
		Debug.Log("sigue ejecutando instrucciones luego de cargar el nivel");
	}
}
