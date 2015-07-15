using UnityEngine;
using System.Collections;

public class Venomon: Monstruo {
	
	private string nesp = "Venomon";
	private Stats stat = new Stats(3,2,3,2,4,4,80);
	private Tipo t = new Tipo(tipos.aire);
	private MovLv[] movs = new MovLv[]{
		new MovLv("Placaje",3),
		new MovLv("Temblor",5),
		new MovLv("Sintesis",9),
	};
	public Venomon(string elNombre, int nivel){
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
	public Venomon(string elNombre, float experiencia, Stats modifStats, Estado estad){
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
