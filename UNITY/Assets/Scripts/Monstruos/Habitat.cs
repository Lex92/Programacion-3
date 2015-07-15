using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public abstract class Habitat {

	public string Nombre;
	public string[] posibles;
	public int lvMin,lvMax;
	
	private System.Random Rnd = new System.Random();
	
	public Monstruo GetMonstruo(){
		string monst = posibles[(int)Rnd.Next(0,posibles.Length)];
		return Monstruo.CreateMonster(monst,monst,(int)Rnd.Next(lvMin,lvMax));
	}
	
	public static Habitat CreateHabitat(string hab,int lMin,int lMax)
	{
		Type types = Type.GetType(hab);
		
		if (types == null)
			throw new InvalidOperationException("The given habitat does not have a Type associated with it.");
		
		return Activator.CreateInstance(types,lMin,lMax) as Habitat;
	}
}
