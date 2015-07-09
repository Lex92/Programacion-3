using UnityEngine;
using System.Collections;

public class Derribo : Accion {
	public Monstruo targ,src;
	public Derribo(Monstruo source, Monstruo target){
		src = source;
		targ = target;
		stg = Stage.atq2;
		ac = Efecto;
	}
	
	public void Efecto(){
		Debug.Log("derribo");
	}
}
