using UnityEngine;
using System.Collections;


/*
	entre accion y los movimientos podria haber clase Ataque (hereda de Accion, se le agrega src y target)
*/
public class Placaje : Accion {
	public Monstruo targ,src;
	public Placaje(Monstruo source, Monstruo target){
		src = source;
		targ = target;
		stg = Stage.atq2;
		ac = Efecto;
	}
	
	public void Efecto(){
		Debug.Log(targ.estado.statActual.vida);
		targ.GetDamage(src.estado.statActual.fuerza);
		Debug.Log(src.nombre+" Placaje "+targ.nombre);
		Debug.Log(targ.estado.statActual.vida);
	}
}
