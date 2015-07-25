using UnityEngine;
using System.Collections;

public static class SaveMonster {
	public static void saveMonster(Monstruo m){
		if(!PlayerPrefs.HasKey("Monstruos")){
			PlayerPrefs.SetString("Monstruos","");
		}
		PlayerPrefs.SetString("Monstruos",PlayerPrefs.GetString("Monstruos")+m.nombre+",");
		PlayerPrefs.SetString(m.nombre,m.especie);
		PlayerPrefs.SetString(m.nombre+"exp",m.exp.ToString());
		PlayerPrefs.SetString(m.nombre+"modS",m.modStats.ToString());
		PlayerPrefs.SetString(m.nombre+"est",m.estado.ToString());
	}
	
	public static Monstruo LoadMonster(string name){
		Monstruo m;
		if(PlayerPrefs.HasKey(name)){
			m = Monstruo.CreateMonster(PlayerPrefs.GetString(name),name,int.Parse(PlayerPrefs.GetString(name+"exp")),new Stats(PlayerPrefs.GetString(name+"modS")), new Estado(PlayerPrefs.GetString(name+"est")));
		}else
			return null;
		return m;
	}
	
	public static string[] getMonsterList(){
		//separar csv de PP "Monstruos"
		return new string[0];
	}
}

//en Monstruos, anotar como csv los nombres de los monstruos. luego en cada uno grabar un nuevo string con los datos serializados
//para cargar, se puede cargar lista de nombres (separando la csv y devolviendo string[]) y con esa string[] tambien los monstruos)