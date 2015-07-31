using UnityEngine;
using System.Collections;

public class Absorber : Ataque {
	public Absorber(Monstruo source, Monstruo target){
		src = source;
		targ = target;
		stg = Stage.atq2;
		ac = Efecto;
	}
	
	public void Efecto(){
		AttackAnimations.SetProjectile(direccion.mismo,"Absorber",src);
		Log.AddLine(src.nombre+" succiona la vida de "+targ.nombre);
		targ.GetDamage(DamageFormula(src.estado.statActual.fespecial,targ.estado.statActual.despecial,src.lv,35),tipos.tierra,src.estado.statActual.punteria+src.estado.statActual.velocidad);
		src.Restaurar(DamageFormula(src.estado.statActual.fespecial,targ.estado.statActual.despecial,src.lv,35)/2);		
	}
}
