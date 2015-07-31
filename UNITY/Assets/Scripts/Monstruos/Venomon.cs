using UnityEngine;
using System.Collections;

public class Venomon: Monstruo {
	
	private string nesp = "Venomon";
	private Stats stat = new Stats(55,50,40,55,45,60,80);
	private Tipo t = new Tipo(tipos.tierra);
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
		exp = GetExp(lv);
		movPosibles = movs;
		especie = nesp;
		baseStats = stat;
		estado.statActual = GetStats();
	}
	
	public Venomon(string elNombre, int experiencia, Stats modifStats, Estado estad){
		imgDir = nesp;
		nombre = elNombre;
		exp = experiencia;
		tipo = t;
		lv = GetLv(exp);
		modStats = modifStats;
		estado = estad;
		movPosibles = movs;
		especie = nesp;
		baseStats = stat;
	}
}
