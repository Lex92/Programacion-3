using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class EventPP {

	public static void NewEvent(string nombre, string aclaracion){
		if(!PlayerPrefs.HasKey("Eventos")){
			PlayerPrefs.SetString("Eventos","");
		}
		string[] eventos = GetEventList();
		bool esta = false;
		nombre = "Eventos"+nombre;
		for(int i = 0; i < eventos.Length; ++i){
			Debug.Log(eventos[i]);
			if(eventos[i] == nombre){
				esta = true;
				break;
			}
		}
		if(!esta){
			PlayerPrefs.SetString("Eventos",PlayerPrefs.GetString("Eventos")+nombre+",");
		}
		PlayerPrefs.SetString(nombre,aclaracion);
	}
	
	public static void NewEvent(string nombre){
		NewEvent(nombre,"");
	}
	public static string[] GetEventList(){
		string eventos = PlayerPrefs.GetString("Eventos");
		List<string> list = new List<string>();
		int j1 = 0;
		int j2 = 0;
		for(int i = 0; i < eventos.Length; ++i){
			if(eventos[i] == ','){
				list.Add(eventos.Substring(j1,j2));
				j1 = i+1;
				j2 = 0;
			}else{
				j2++;
			}
		}
		return (string[])list.ToArray();
	}
	
	public static bool HasEvent(string nombre){
		return PlayerPrefs.HasKey("Eventos"+nombre);
	}
	public static string GetAclaracion(string nombre){
		return PlayerPrefs.GetString("Eventos"+nombre);
	}
	
	public static void SetTrainer(string type){
		PlayerPrefs.SetString("Entrenador",type);
		PlayerPrefs.Save();
	}
	
	public static void DeleteEvent(string nombre){
		nombre="Eventos"+nombre;
		PlayerPrefs.DeleteKey(nombre);
	}
}