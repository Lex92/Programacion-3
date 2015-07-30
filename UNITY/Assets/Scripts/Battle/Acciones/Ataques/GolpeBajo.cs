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
		targ.GetDamage(DamageFormula(src.GetStats().fuerza,targ.GetStats().defensa,src.lv,30),tipos.oscuridad,src.GetStats().punteria);
	}
}
