using UnityEngine;
using System.Collections;

public class Flymon: Monstruo {
	
	private string nesp = "Flymon";
	private Stats stat = new Stats(3,2,2,2,5,3,80);
	private Tipo t = new Tipo(tipos.aire);
	private MovLv[] movs = new MovLv[]{
		new MovLv("Tornado",3),
		new MovLv("Placaje",3),
		new MovLv("Derribo",5),
		new MovLv("Coletazo",7),
		new MovLv("Sintesis",9),
		new MovLv("Defensa",11),
		new MovLv("Mal de ojo",15),
	};
	
	public Flymon(string elNombre, int nivel){
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
	public Flymon(string elNombre, float experiencia, Stats modifStats, Estado estad){
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
