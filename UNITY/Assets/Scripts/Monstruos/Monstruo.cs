using UnityEngine;
using System.Collections;
using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

public struct Stats {
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
}

public enum Est{veneno,dormir,normal};

[System.Serializable]
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
	public Tipo tipo;
	public int lv;
	public int exp;
	public Stats baseStats;
	public Stats modStats;
	public Estado estado;
	public MovLv[] movPosibles;
	public string imgDir;	
	
	public static Monstruo CreateMonster(string monster, string name, int lv){
		Type types = Type.GetType(monster);
		
		if (types == null)
			throw new InvalidOperationException("The given monster does not have a Type associated with it.");
		
		return Activator.CreateInstance(types,name,lv) as Monstruo;
	}	
	public static Monstruo CreateMonster(string monster, string name, int exp, Stats modS,Estado estado){
		Type types = Type.GetType(monster);
		
		if (types == null)
			throw new InvalidOperationException("The given monster does not have a Type associated with it.");
		
		return Activator.CreateInstance(types,name,exp,modS,estado) as Monstruo;
	}
	
	
	private System.Random Rnd = new System.Random();
	
	public int GetDamage(int dam, tipos t, tipos2 t2, int punteria){
		float pexito = Rnd.Next(0,100)+estado.statActual.velocidad;
		dam = Mathf.RoundToInt(dam*tipo.Modificador(t));
		if((pexito > punteria)||(pexito>98)){
			Debug.Log("esquivo");
			return estado.statActual.vida;
		}
		if(t2 == tipos2.fisico){
			dam -= estado.statActual.defensa/2;
		}else{
			dam -= estado.statActual.despecial/2;
		}
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
	
	public void Restaurar(){
		estado.statActual = GetStats();
		estado.est = Est.normal;
	}
	
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
		temp.fuerza += Mathf.RoundToInt(temp.fuerza*nivel*0.05f);
		temp.fespecial += Mathf.RoundToInt(temp.fespecial*nivel*0.05f);
		temp.defensa += Mathf.RoundToInt(temp.defensa*nivel*0.05f);
		temp.despecial += Mathf.RoundToInt(temp.despecial*nivel*0.05f);
		temp.velocidad += Mathf.RoundToInt(temp.velocidad*nivel*0.05f);
		temp.vida += Mathf.RoundToInt(temp.vida*nivel*0.05f);
		return temp;
	}
	public Stats GetStats(){
		return GetStats(lv);
	}
	
	public void AddExp(int e){
		exp += (int) e/lv;
		if(lv < GetLv(exp)){
			int hp = estado.statActual.vida;
			lv = GetLv(exp);
			estado.statActual = GetStats();
			estado.statActual.vida = hp;
		}
	}
	
	public static int GetExp(int nivel){
		return (int) Mathf.Pow(nivel,5f);
	}
	public static int GetLv(int exp){
	
		return (int) Mathf.Pow(exp,0.2f);
	}
	
	/*
		metodos:
			daño, restaurar, getExp(lv), getLv(exp), getMov(lv)<-movAprendidos, string[] getMovimientos();
	*/
}
