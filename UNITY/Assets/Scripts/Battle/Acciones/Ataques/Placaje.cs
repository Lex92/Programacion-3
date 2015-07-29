using UnityEngine;
using System.Collections;


/*
	entre accion y los movimientos podria haber clase Ataque (hereda de Accion, se le agrega src y target)
*/
public class Placaje : Ataque {
	public Placaje(Monstruo source, Monstruo target){
		src = source;
		targ = target;
		stg = Stage.atq2;
		ac = Efecto;
	}
	
	public void Efecto(){
		targ.GetDamage(5+src.estado.statActual.fuerza, tipos.normal,tipos2.fisico,src.estado.statActual.punteria+src.estado.statActual.velocidad);
	}
}
