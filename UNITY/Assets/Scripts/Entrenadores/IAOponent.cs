﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class IAOponent : Entrenador{

	private System.Random Rnd = new System.Random();
	public IAOponent(string n){
		nombre = n;
		equipo = RandomizeTeam();
		//equipo = new Monstruo[] {Monstruo.CreateMonster("Batmon","bati",10)};
		accionEntrenador = RandomAttack;
		Debug.Log(RandomizeTeam()[0].nombre);
	}
	//new Monstruo[]{Monstruo.CreateMonster("Batmon","Batichulo",(int)Rnd.Next(5,8)),Monstruo.CreateMonster("Flymon","Fly",5),Monstruo.CreateMonster("Ciclopmon","Ciclope",5)};
	
	public Accion RandomAttack(){
		string[] moves = source.GetMov();
		//return Accion.CreateAccion(moves[(int)Random.Range(0,moves.Length)],source,target);
		return Accion.CreateAccion(moves[0],source,target);
	}
	public int cantidad = 4;
	public int lvMin = 5;
	public int lvMax = 10;
	private string[] MonstruosPosibles = {"Batmon","Ciclopmon","Flymon"};
	
	private Monstruo[] RandomizeTeam(){
		List<Monstruo> listMonst = new List<Monstruo>();
		string mnst;
		for(int i=0;i<cantidad;i++){
			mnst = MonstruosPosibles[(int)Rnd.Next(0,MonstruosPosibles.Length)];
			listMonst.Add(Monstruo.CreateMonster(mnst,mnst,(int)Rnd.Next(lvMin,lvMax)));
		}
		return (Monstruo[])listMonst.ToArray();
	}
}
