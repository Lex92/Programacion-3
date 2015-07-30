using UnityEngine;
using System.Collections;

public abstract class Ataque : Accion {
	
	protected Monstruo src, targ;
	protected int DamageFormula(int ataque, int defensa, int lv, int b){
		return ( ((2*lv+10)/250)*(ataque/defensa)*b+2);
	}
}
