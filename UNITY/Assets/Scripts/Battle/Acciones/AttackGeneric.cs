using UnityEngine;
using System.Collections;

public class AttackGeneric : Accion {

	public AttackGeneric(){
		stg = Stage.atq2;
		ac = Efecto;
	}
	
	public void Efecto(){
		Debug.Log("ATAQUE");
	}
}
