using UnityEngine;
using System.Collections;

public class Batmon : Monstruo {

	//usado principalmente para randomizar salvajes/entrenador
	public Batmon(string elNombre, int nivel){
		imgDir = "Batmon";
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
		especie = "Batmon";
		baseStats = new Stats(5,4,7,8,9);
		estado.statActual = GetStats();
	}
	
	//estos son los datos que se guardan/cargan para persistir un monstruo
	public Batmon(string elNombre, float experiencia, Stats modifStats, Estado estad){
		imgDir = "Batmon";
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
		especie = "Batmon";
		baseStats = new Stats(5,4,7,8,9);
		estado.statActual = GetStats();
	}
}
