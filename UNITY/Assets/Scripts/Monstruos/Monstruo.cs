using UnityEngine;
using System.Collections;
using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

public struct Stats {
	public int fuerza;
	public int defensa;
	public int velocidad;
	public int vida;
	public int energia;
	
	public Stats(int f, int d, int v, int hp, int e){
		fuerza = f;
		defensa = d;
		velocidad = v;
		vida = hp;
		energia = e;
	}
}

public enum Est{veneno,dormir,normal};

public struct Estado {
	public Stats statActual;
	public Est est;
	public Estado(Stats s, Est e){
		statActual = s;
		est = e;
	}
}

public struct MovLv{
	//public Movimiento mov;
	public string mov;
	public int lv;
	public MovLv(string m, int l){
		mov = m;
		lv = l;
	}
}

[System.Serializable]
public abstract class Monstruo {
	public string nombre;
	public string especie;
	//public Tipo tipo1;
	//public Tipo tipo2;
	//public Tipo.tipos tipo1,tipo2;
	public int lv;
	public float exp;
	public Stats baseStats;
	public Stats modStats;
	public Estado estado;
	public MovLv[] movPosibles;
	//public Movimiento[] movAprendidos;
	public string imgDir;
	
	public void ImprimirStats(){
		Debug.Log("F:"+baseStats.fuerza+"\tD:"+baseStats.defensa+"\tV:"+baseStats.velocidad);
		Debug.Log("HP:"+baseStats.vida+"\tE:"+baseStats.energia);
	}
	
	
	public static Monstruo CreateMonster(string monster, string name, int lv)
	{
		Type types = Type.GetType(monster);
		
		if (types == null)
			throw new InvalidOperationException("The given monster does not have a Type associated with it.");
		
		return Activator.CreateInstance(types,name,lv) as Monstruo;
	}
	
	/*	contemplar cuando muere	*/
	public int GetDamage(int dam){
		dam -= estado.statActual.defensa/2;
		if(dam <= 0){
			dam = 1;
			Debug.Log("Daño minimo");
		}
		estado.statActual.vida -= dam;
		if(estado.statActual.vida <= 0){
			estado.statActual.vida = 0;
			Debug.Log("Muerto");
		}
		return estado.statActual.vida;
	}
	
	/*	contemplar cuando supera el 100% de la vida	*/
	public int Restaurar(int hp){
		estado.statActual.vida += hp;
		if(estado.statActual.vida >= GetStats().vida){
			estado.statActual.vida = GetStats().vida;
			Debug.Log("completamente curado");
		}
		return estado.statActual.vida;
	}
	
	
	/*
		getMov devuelve todos los movimientos posibles en una lista string
		cada string crearia un boton con .name = el string
		al invocarse un movimiento, se invocaria createAccion(button.name)
	*/
	
	public string[]GetMov(int nivel){
		List<String> temp = new List<string>();
		int i;
		for(i=0;i<movPosibles.Length;i++){
			if(movPosibles[i].lv <= nivel){
				temp.Add(movPosibles[i].mov);
			}
		}
		return temp.ToArray();
	}	
	public string[]GetMov(){
		return GetMov(lv);;
	}
	
	public Stats GetStats(int nivel){
		Stats temp = baseStats;
		temp.fuerza += temp.fuerza*nivel/10;
		temp.defensa += temp.defensa*nivel/10;
		temp.velocidad += temp.velocidad*nivel/10;
		temp.vida += temp.vida*nivel/10;
		temp.energia += temp.energia*nivel/10;
		return temp;
	}
	public Stats GetStats(){
		return GetStats(lv);
	}
	/*
		metodos:
			daño, restaurar, getExp(lv), getLv(exp), getMov(lv)<-movAprendidos, string[] getMovimientos();
	*/
}
