using UnityEngine;
using System.Collections;


/*
	entre accion y los movimientos podria haber clase Ataque (hereda de Accion, se le agrega src y target)
*/
public class Temblor : Ataque {
	//public Monstruo targ,src;
	public Temblor(Monstruo source, Monstruo target){
		src = source;
		targ = target;
		stg = Stage.atq3;
		ac = Efecto;
	}
	
	public void Efecto(){
		Log.AddLine(src.nombre+" hizo temblar la tierra a su alrededor");
		targ.GetDamage(DamageFormula(src.estado.statActual.fespecial,targ.estado.statActual.defensa,src.lv,50),tipos.tierra,src.estado.statActual.punteria);
	}
}
