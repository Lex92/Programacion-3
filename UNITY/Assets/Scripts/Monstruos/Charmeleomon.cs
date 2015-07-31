using UnityEngine;
using System.Collections;

public class Charmeleomon : Monstruo {
	
	private string nesp = "Charmeleomon";
	private Stats stat = new Stats(64,58,80,65,80,58,80);
	private Tipo t = new Tipo(tipos.aire);
	private MovLv[] movs = new MovLv[]{
		new MovLv("Placaje",3),
		new MovLv("Llamarada",5),
		new MovLv("Tornado",7),
	};
	public Charmeleomon(string elNombre, int nivel){
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
	
	public Charmeleomon(string elNombre, int experiencia, Stats modifStats, Estado estad){
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