using UnityEngine;
using System.Collections;

public class Placaje : Accion {
	public Placaje(){
		stg = Stage.atq2;
		ac = Efecto;
	}
	
	public void Efecto(){
		Debug.Log("placaje");
	}
}
