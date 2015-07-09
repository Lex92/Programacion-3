using UnityEngine;
using System.Collections;

public class Item : Accion {
	Monstruo targ;
	public Item(Monstruo target){
		targ = target;
		stg = Stage.entrenador;
		ac = Restaurar;
	}
	void Restaurar(){
		Debug.Log(targ.estado.statActual.vida);
		Debug.Log("Restaurar");
		targ.Restaurar(10);
		Debug.Log(targ.estado.statActual.vida);
	}

}
