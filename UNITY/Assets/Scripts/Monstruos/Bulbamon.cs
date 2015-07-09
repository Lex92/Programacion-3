using UnityEngine;
using System.Collections;

public class Bulbamon : Monstruo {
	
	//usado principalmente para randomizar salvajes/entrenador
	public Bulbamon(string elNombre, int nivel){
		imgDir = "Bulbamon";
		nombre = elNombre;
		lv = nivel;
		//exp = getExp(lv);
		//estado = new Estado();
		movPosibles = new MovLv[]{
			new MovLv("Placaje",3),
			new MovLv("Derribo",5),
			new MovLv("Coletazo",7),
			new MovLv("Sintesis",9),
			new MovLv("Defensa",11),
			new MovLv("Mal de ojo",15),
		};
		especie = "Bulbamon";
		baseStats = new Stats(5,6,7,8,9);
		estado.statActual = GetStats();
	}
	
	//estos son los datos que se guardan/cargan para persistir un monstruo
	public Bulbamon(string elNombre, float experiencia, Stats modifStats, Estado estad){
		imgDir = "Bulbamon";
		nombre = elNombre;
		exp = experiencia;
		//lv = getLv(exp);
		modStats = modifStats;
		estado = estad;
		movPosibles = new MovLv[]{
			new MovLv("Placaje",3),
			new MovLv("Derribo",5),
			new MovLv("Coletazo",7),
			new MovLv("Sintesis",9),
			new MovLv("Defensa",11),
			new MovLv("Mal de ojo",15),
		};
		especie = "Bulbamon";
		baseStats = new Stats(5,6,7,8,9);
		estado.statActual = GetStats();
	}
}
