﻿using UnityEngine;
using System.Collections;

public class Huir : Accion {

	public Huir(){
		stg = Stage.entrenador;
		ac = Escape;
	}
	void Escape(){
		Debug.Log("Escape");
		if(Random.Range(0,100) < 75){
			Debug.Log("Lograste escapar!!");
			Application.LoadLevel(0);
		}else{
			Debug.Log("no se pudo escapar");
		}
	}
}