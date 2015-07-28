using UnityEngine;
using System.Collections;



/*	Me lo imaginaba de la siguiente manera:
		un array en csv de los nombres de los monstruos del jugador, guardados como string en "Monstruos" (los nombres TIENEN que ser unicos, eso lo modificamos en el juego)
		
		para cada nombre estan los strings de los datos que usa para el constructor (especie,experiencia,modstats y estado)
		al cargar un monstruo con LoadMonster se le pasa el nombre y tendria que buscar y construir el monstruo de playerprefs (no esta testeado)
		
		GetMonsterList devolveria una lista string[] de los monstruos del usuario (ya use List<Monstruo> en otro .cs, pero no me acuerdo donde, para armar el string[])
		
		en la clase de entrenador del jugador, la lista de monstruos tendria que crearse con GetMonsterList() y un LoadMonster() para cada monstruo
			onda:
				string[] nombres = GetMonsterList();
				equipo = new Monstruos[nombres.Length];
				for(int i = 0; i < nombres.Length;i++)
					equipo[i] = SaveMonster.LoadMonster(nombres[i]);
			o algo asi (capaz ayuda revisar como se crea el equipo del IA
			
		y yo diria guardar los monstruos por lo menos al final de cada batalla
*/
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
	
	public static string[] GetMonsterList(){
		//separar csv de PP "Monstruos"
		//ir armando con List.Add() y devolver List.toString() o algo asi, tengo algo parecido hecho creo que con los moves o algo asi...
		//return new string[0];
		string[] listMonsters={"Venomon","Batmon","Bulbamon"};
		
		return listMonsters;
	}
}

//en Monstruos, anotar como csv los nombres de los monstruos. luego en cada uno grabar un nuevo string con los datos serializados
//para cargar, se puede cargar lista de nombres (separando la csv y devolviendo string[]) y con esa string[] tambien los monstruos)