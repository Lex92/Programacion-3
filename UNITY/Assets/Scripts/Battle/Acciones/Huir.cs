using UnityEngine;
using System.Collections;

public class Huir : Accion {

	public Huir(){
		stg = Stage.entrenador;
		ac = Escape;
	}
	void Escape(){
		if(Random.Range(0,100) < 75){
			Application.LoadLevel("Sc01");//cargar la ultima escena en la que estuvo
		}
	}
}
