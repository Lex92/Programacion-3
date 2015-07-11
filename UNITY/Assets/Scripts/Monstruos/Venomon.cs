using UnityEngine;
using System.Collections;

public class Venomon: Monstruo {
	
	//usado principalmente para randomizar salvajes/entrenador
	
	private MovLv[] mpos = new MovLv[]{
		new MovLv("Placaje",3),
		new MovLv("Derribo",5),
		new MovLv("Coletazo",7),
		new MovLv("Sintesis",9),
		new MovLv("Defensa",11),
		new MovLv("Mal de ojo",15),
	};
	private Stats stat = new Stats(8,4,10,8,4);
	private string nam = "Venomon";
	
	
	public Venomon(string elNombre, int nivel){
		imgDir = nam;
		nombre = elNombre;
		lv = nivel;
		//exp = getExp(lv);
		//estado = new Estado();
		movPosibles = mpos;
		especie = nam;
		baseStats = stat;
		estado.statActual = GetStats();
	}
	
	//estos son los datos que se guardan/cargan para persistir un monstruo
	public Venomon(string elNombre, float experiencia, Stats modifStats, Estado estad){
		imgDir = nam;
		nombre = elNombre;
		exp = experiencia;
		//lv = getLv(exp);
		modStats = modifStats;
		estado = estad;
		movPosibles = mpos;
		especie = nam;
		baseStats = stat;
		estado.statActual = GetStats();
	}
}
