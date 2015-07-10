using UnityEngine;
using System.Collections;

public class IAOponent : Entrenador{
	public IAOponent(string n){
		nombre = n;
		equipo = new Monstruo[]{Monstruo.CreateMonster("Batmon","batichulo",8),Monstruo.CreateMonster("Bulbamon","bulboso",5)};
		accionEntrenador = RandomAttack;
	}
	
	
	public Accion RandomAttack(){
		string[] moves = source.GetMov();
		//return Accion.CreateAccion(moves[(int)Random.Range(0,moves.Length)],source,target);
		return Accion.CreateAccion(moves[0],source,target);
	}
	
	
}
