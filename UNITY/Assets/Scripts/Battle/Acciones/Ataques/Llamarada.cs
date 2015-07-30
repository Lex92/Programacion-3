using UnityEngine;
using System.Collections;

public class Llamarada : Ataque {
	
	public Llamarada(Monstruo source, Monstruo target){
		src = source;
		targ = target;
		stg = Stage.atq3;
		ac = Efecto;
	}
	public void Efecto(){
		targ.GetDamage(DamageFormula(src.GetStats().fespecial,targ.GetStats().despecial,src.lv,60),tipos.fuego,src.GetStats().punteria);
	}
}
