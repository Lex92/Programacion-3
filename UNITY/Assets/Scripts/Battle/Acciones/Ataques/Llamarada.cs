using UnityEngine;
using System.Collections;

public class Llamarada : Ataque {
	
	public Llamarada(Monstruo source, Monstruo target){
		src = source;
		targ = target;
		stg = Stage.atq2;
		ac = Efecto;
	}
	public void Efecto(){
		Debug.Log(targ.estado.statActual.vida);
		targ.GetDamage(5+src.estado.statActual.fespecial, tipos.fuego,tipos2.especial,src.estado.statActual.punteria);
		Debug.Log(src.nombre+" Llamarada "+targ.nombre);
		Debug.Log(targ.estado.statActual.vida);
	}
}
