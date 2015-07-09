using UnityEngine;
using System.Collections;

public class Sintesis : Accion {
	public Monstruo targ,src;
	public Sintesis(Monstruo source, Monstruo target){
		src = source;
		targ = target;
		stg = Stage.atq2;
		ac = Efecto;
	}
	
	public void Efecto(){
		Debug.Log(src.estado.statActual.vida);
		Debug.Log(src.nombre+" sintesis");
		src.Restaurar(src.baseStats.vida);
		Debug.Log(src.estado.statActual.vida);
	}
}
