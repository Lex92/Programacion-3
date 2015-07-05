using UnityEngine;
using System.Collections;
using System;

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
	
	/*
		metodos:
			daño, restaurar, getExp(lv), getLv(exp), getMov(lv)<-movAprendidos, string[] getMovimientos();
	*/
}
