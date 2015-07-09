using UnityEngine;
using System.Collections;

public class Coletazo : Accion {
	public Monstruo targ,src;
	public Coletazo(Monstruo source, Monstruo target){
		src = source;
		targ = target;
		stg = Stage.atq2;
		ac = Efecto;
	}
	
	public void Efecto(){
		Debug.Log("coletazo");
	}
}
