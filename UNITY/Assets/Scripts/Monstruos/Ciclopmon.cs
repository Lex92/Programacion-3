﻿using UnityEngine;
using System.Collections;

public class Ciclopmon: Monstruo {
	
	private string nesp = "Ciclopmon";
	private Stats stat = new Stats(95,55,35,75,115,55,80);
	private Tipo t = new Tipo(tipos.oscuridad);
	private MovLv[] movs = new MovLv[]{
		new MovLv("GolpeBajo",3),
		new MovLv("Placaje",5),
	};
	public Ciclopmon(string elNombre, int nivel){
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
	
	public Ciclopmon(string elNombre, int experiencia, Stats modifStats, Estado estad){
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
