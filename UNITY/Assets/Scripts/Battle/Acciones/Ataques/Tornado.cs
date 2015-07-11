using UnityEngine;
using System.Collections;


/*
	entre accion y los movimientos podria haber clase Ataque (hereda de Accion, se le agrega src y target)
*/
public class Tornado : Ataque {
	//public Monstruo targ,src;
	public Tornado(Monstruo source, Monstruo target){
		src = source;
		targ = target;
		stg = Stage.atq3;
		ac = Efecto;
	}
	
	public void Efecto(){
		Debug.Log(targ.estado.statActual.vida);
		targ.GetDamage(4+src.estado.statActual.fespecial, tipos.aire,tipos2.especial,100);
		Debug.Log(src.nombre+" Tornado "+targ.nombre);
		Debug.Log(targ.estado.statActual.vida);
	}
}
