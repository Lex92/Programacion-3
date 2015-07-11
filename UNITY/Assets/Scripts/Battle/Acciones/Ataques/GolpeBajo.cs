using UnityEngine;
using System.Collections;


/*
	entre accion y los movimientos podria haber clase Ataque (hereda de Accion, se le agrega src y target)
*/
public class GolpeBajo : Ataque {
	//public Monstruo targ,src;
	public GolpeBajo(Monstruo source, Monstruo target){
		src = source;
		targ = target;
		stg = Stage.atq1;
		ac = Efecto;
	}
	
	public void Efecto(){
		Debug.Log(targ.estado.statActual.vida);
		targ.GetDamage(3+src.estado.statActual.fuerza, tipos.oscuridad,tipos2.fisico,src.estado.statActual.punteria+src.estado.statActual.velocidad);
		Debug.Log(src.nombre+" GolpeBajo "+targ.nombre);
		Debug.Log(targ.estado.statActual.vida);
	}
}
