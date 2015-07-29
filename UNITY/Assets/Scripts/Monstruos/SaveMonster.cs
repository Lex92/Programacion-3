using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class SaveMonster {


	//podria agregarse un NewCSV(string "Monstruos"/"Eventos", string nombre) para agregar al csv el dato
	public static void NewMonster(string nombre, string especie, string exp, string modStats, string estado){
		if(!PlayerPrefs.HasKey("Monstruos")){
			PlayerPrefs.SetString("Monstruos","");
		}
		string[] monstruos = GetMonsterList();
		bool esta = false;
		for(int i = 0; i < monstruos.Length; ++i){
			if(monstruos[i] == nombre){
				esta = true;
				break;
			}
		}
		if(!esta){
			PlayerPrefs.SetString("Monstruos",PlayerPrefs.GetString("Monstruos")+nombre+",");
		}
		PlayerPrefs.SetString(nombre,especie);
		PlayerPrefs.SetString(nombre+"exp",exp);
		Debug.Log("vida1: "+PlayerPrefs.GetString(nombre+"est"));
		PlayerPrefs.SetString(nombre+"est",estado);
		Debug.Log("vida2: "+PlayerPrefs.GetString(nombre+"est"));
	}
	public static void NewMonster(Monstruo m){
		SaveMonster.NewMonster(m.nombre,m.especie,m.exp.ToString(),m.modStats.ToString(),m.estado.ToString());
	}
	
	public static void AddMonster(Monstruo m, bool nuevo){
		if(nuevo){
			m.nombre = VerificarNombre(m);
		}
		NewMonster(m);
	}
	
	private static string VerificarNombre(Monstruo m){
		string[] nombres = GetMonsterList();
		bool esta;
		int posfijo = 0;
		string nombre = m.nombre;
		do{
			esta = false;
			for(int i = 0; i < nombres.Length; ++i){
				if(nombres[i] == nombre){
					esta = true;
					break;
				}
			}
			if(esta){
				nombre = m.nombre+posfijo++;
			}
		}while(esta);
		return nombre;
	}
	
	public static Monstruo LoadMonster(string name){
		Monstruo m;
		if(PlayerPrefs.HasKey(name)){
			m = Monstruo.CreateMonster(PlayerPrefs.GetString(name),name,int.Parse(PlayerPrefs.GetString(name+"exp")),new Stats(PlayerPrefs.GetString(name+"modS")), new Estado(PlayerPrefs.GetString(name+"est")));
		}else
			return null;
		return m;
	}
	
	//esta podria pasar a ser GetCSV(string "Monstruos"/"Eventos") y servir para guardar eventos tambien
	public static string[] GetMonsterList(){
		string monstruos = PlayerPrefs.GetString("Monstruos");
		List<string> list = new List<string>();
		int j1 = 0;
		int j2 = 0;
		for(int i = 0; i < monstruos.Length; ++i){
			if(monstruos[i] == ','){
				list.Add(monstruos.Substring(j1,j2));
				j1 = i+1;
				j2 = 0;
			}else{
				j2++;
			}
		}
		return (string[])list.ToArray();
	}
}