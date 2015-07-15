using UnityEngine;
using System.Collections;

public class Batmon : Monstruo {
	private string nesp = "Batmon";
	private Stats stat = new Stats(5,2,3,2,5,5,80);
	private Tipo t = new Tipo(tipos.aire);
	private MovLv[] movs = new MovLv[]{
		new MovLv("Tornado",3),
		new MovLv("Placaje",3),
	};
	//usado principalmente para randomizar salvajes/entrenador
	public Batmon(string elNombre, int nivel){
		imgDir = nesp;
		nombre = elNombre;
		lv = nivel;
		tipo = t;
		//exp = getExp(lv);
		//estado = new Estado();
		movPosibles = movs;
		especie = nesp;
		baseStats = stat;
		estado.statActual = GetStats();
	}
	
	//estos son los datos que se guardan/cargan para persistir un monstruo
	public Batmon(string elNombre, float experiencia, Stats modifStats, Estado estad){
		imgDir = nesp;
		nombre = elNombre;
		exp = experiencia;
		tipo = t;
		//lv = getLv(exp);
		modStats = modifStats;
		estado = estad;
		movPosibles = movs;
		especie = nesp;
		baseStats = stat;
		estado.statActual = GetStats();
	}
}
