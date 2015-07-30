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
		src.Restaurar((int)src.GetStats().vida/4);
	}
}
