using UnityEngine;
using System.Collections;

public class Batmon : Monstruo {

	
	private System.Random Rnd = new System.Random();
	private string nesp = "Batmon";
	private Stats stat = new Stats(45,35,30,40,55,40,80);
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
		exp = GetExp(lv);
		//estado = new Estado();
		movPosibles = movs;
		especie = nesp;
		baseStats = stat;
		estado.statActual = GetStats();
		
		modStats.fuerza = (int)Rnd.Next(0,30);
		modStats.defensa = (int)Rnd.Next(0,30);
		modStats.fespecial = (int)Rnd.Next(0,30);
		modStats.despecial = (int)Rnd.Next(0,30);
		modStats.velocidad = (int)Rnd.Next(0,30);
		modStats.vida = (int)Rnd.Next(0,30);
	}
	
	//estos son los datos que se guardan/cargan para persistir un monstruo
	public Batmon(string elNombre, int experiencia, Stats modifStats, Estado estad){
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
		//estado.statActual = GetStats();//ojo
	}
}
