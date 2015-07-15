using UnityEngine;
using System.Collections;

public class Esperar : Accion {

	public Esperar(){
		Debug.Log("Espero");
		ac = Nada;
		stg = Stage.atq1;
	}
	private void Nada(){
	}
}
