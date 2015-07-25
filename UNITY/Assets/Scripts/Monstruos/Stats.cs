using UnityEngine;
using System.Collections;

public class Stats {
	public int fuerza;
	public int fespecial;
	public int defensa;
	public int despecial;
	public int velocidad;
	public int vida;
	public int punteria;
	
	public Stats(int f, int fe, int d, int de, int v, int hp, int punt){
		fuerza = f;
		fespecial = fe;
		defensa = d;
		despecial = de;
		velocidad = v;
		vida = hp;
		punteria = punt;
	}
	
	override public string ToString(){
		return fuerza+","+fespecial+","+defensa+","+despecial+","+velocidad+","+vida+","+punteria;
	}
	
	public Stats(string s){
		int[] stats = {0,0,0,0,0,0,0};
		int j = 0;
		for(int i = 0; i < s.Length; i++){
			if(s[i] == ','){
				j++;
				if(j>stats.Length)
					break;
				continue;
			}
			stats[j] = stats[j]*10+(int)char.GetNumericValue(s[i]);
		}
		fuerza = stats[0];
		fespecial = stats[1];
		defensa = stats[2];
		despecial = stats[3];
		velocidad = stats[4];
		vida = stats[5];
		punteria = stats[6];
	}
}
