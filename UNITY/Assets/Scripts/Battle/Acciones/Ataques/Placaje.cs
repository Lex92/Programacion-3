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
		AttackAnimations.SetProjectile(direccion.otro,"Placaje",src);
		Log.AddLine(src.nombre+" arrebatio contra "+targ.nombre);
		targ.GetDamage(DamageFormula(src.estado.statActual.fuerza,targ.estado.statActual.defensa,src.lv,50),tipos.normal,src.estado.statActual.punteria+src.estado.statActual.velocidad);
	}
}
