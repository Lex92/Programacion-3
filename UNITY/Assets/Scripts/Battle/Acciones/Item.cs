using UnityEngine;
using System.Collections;

public class Item : Ataque {
	public Item(Monstruo source, Monstruo target){
		src = source;
		targ = target;
		stg = Stage.entrenador;
		ac = Atrapar;
	}
	
	public void Atrapar(){
		targ.GetCatched(100);
	}
}