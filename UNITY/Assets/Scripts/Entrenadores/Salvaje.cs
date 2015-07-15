using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Salvaje : Entrenador {
	
	private System.Random Rnd = new System.Random();
	public Salvaje(string n){
		catchRate = 100;
		nombre = n;
		equipo = GetTeam();
		accionEntrenador = RandomAttack;
	}
	private bool canAttack = false;
	public Accion RandomAttack(){
		if(canAttack){
			string[] moves = source.GetMov();
			canAttack = false;
			return Accion.CreateAccion(moves[(int)Rnd.Next(0,moves.Length)],source,target);
		}
		canAttack=true;
		return Accion.CreateAccion("Esperar");
	}
	
	private Monstruo[] GetTeam(){
		List<Monstruo> listMonst = new List<Monstruo>();
		string mnst = PlayerPrefs.GetString("SalvajeMon");
		PlayerPrefs.DeleteKey("SalvajeMon");
		int mnstlv = PlayerPrefs.GetInt("SalvajeMonLv");
		PlayerPrefs.DeleteKey("SalvajeMonLv");
		listMonst.Add(Monstruo.CreateMonster(mnst,mnst,mnstlv));
		return (Monstruo[])listMonst.ToArray();
	}	
}
