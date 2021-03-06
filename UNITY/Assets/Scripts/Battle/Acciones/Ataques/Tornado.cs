﻿using UnityEngine;
using System.Collections;


/*
	entre accion y los movimientos podria haber clase Ataque (hereda de Accion, se le agrega src y target)
*/
public class Tornado : Ataque {
	public Tornado(Monstruo source, Monstruo target){
		src = source;
		targ = target;
		stg = Stage.atq3;
		ac = Efecto;
	}
	
	public void Efecto(){
		AttackAnimations.SetProjectile(direccion.otro,"Tornado",src);
		Log.AddLine(src.nombre+" agita fuertemente sus alas, generando un tornado!");
		targ.GetDamage(DamageFormula(src.estado.statActual.fespecial,targ.estado.statActual.defensa,src.lv,45),tipos.aire,100);
	}
}
