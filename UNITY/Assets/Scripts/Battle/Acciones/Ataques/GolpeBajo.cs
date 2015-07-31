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
		AttackAnimations.SetProjectile(direccion.otro,"GolpeBajo",src);
		Log.AddLine(src.nombre+" lanzo un golpe sucio contra "+targ.nombre);
		targ.GetDamage(DamageFormula(src.estado.statActual.fuerza,targ.estado.statActual.defensa,src.lv,30),tipos.oscuridad,src.estado.statActual.punteria+src.estado.statActual.velocidad);
	}
}
