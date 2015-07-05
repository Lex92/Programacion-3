using UnityEngine;
using System.Collections;

public class Accion {
	
	public delegate void Act();
	
	public Stage stg = Stage.elegir;
	public Act ac;
	
	public Accion(){
	}
}
