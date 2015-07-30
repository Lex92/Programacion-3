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
		targ.GetDamage(DamageFormula(src.GetStats().fespecial,targ.GetStats().defensa,src.lv,45),tipos.aire,100);
	}
}
