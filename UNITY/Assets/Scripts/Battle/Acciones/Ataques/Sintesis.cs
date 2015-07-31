using UnityEngine;
using System.Collections;

public class Sintesis : Accion {
	public Monstruo targ,src;
	public Sintesis(Monstruo source, Monstruo target){
		src = source;
		targ = target;
		stg = Stage.atq2;
		ac = Efecto;
	}
	
	public void Efecto(){
		Log.AddLine(src.nombre+" restaura su salud con la luz solar");
		src.Restaurar((int)src.GetStats().vida/4);
	}
}
