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
		Log.AddLine(src.nombre+" lanzo una bocanada de fuego contra "+targ.nombre);
		targ.GetDamage(DamageFormula(src.estado.statActual.fespecial,targ.estado.statActual.despecial,src.lv,60),tipos.fuego,src.estado.statActual.punteria+src.estado.statActual.velocidad);
	}
}
