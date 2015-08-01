using UnityEngine;
using System.Collections;

public class Charmon : Monstruo {
	
	private string nesp = "Charmon";
	private Stats stat = new Stats(52,43,60,50,65,39,80);
	private Tipo t = new Tipo(tipos.aire);
	private MovLv[] movs = new MovLv[]{
		new MovLv("Placaje",3),
		new MovLv("Llamarada",5),
	};
	public Charmon(string elNombre, int nivel){
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
	
	public Charmon(string elNombre, int experiencia, Stats modifStats, Estado estad){
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
	override protected void Evolve(){
		if(lv > 5){
			especie = "Charmeleomon";
			Log.AddLine(nombre+" esta listo para evolucionar!");
		}
	}
}
