using UnityEngine;
using System.Collections;

public class Ciclopmon: Monstruo {
	
	private string nesp = "Ciclopmon";
	private Stats stat = new Stats(7,3,3,3,2,5,80);
	private Tipo t = new Tipo(tipos.oscuridad);
	private MovLv[] movs = new MovLv[]{
		new MovLv("GolpeBajo",3),
		new MovLv("Placaje",5),
		new MovLv("Coletazo",7),
		new MovLv("Sintesis",9),
		new MovLv("Defensa",11),
		new MovLv("Mal de ojo",15),
	};
	public Ciclopmon(string elNombre, int nivel){
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
	public Ciclopmon(string elNombre, float experiencia, Stats modifStats, Estado estad){
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
