using UnityEngine;
using System.Collections;


/*
	este boton deberia desplegar un menu que se llene con un boton para cada userMon.GetMov(lv).
	
	cada uno de esos botones deberian llamar al createAccion (button.name)
*/
public class AttackBtn : MonoBehaviour {
	protected Battle battle;
	
	public void Click(){
		battle = GetComponentInParent<Battle>();
		Debug.Log("click Atk");
		//battle.act1 = Accion.CreateAccion("AttackGeneric");
		
		battle.act1 = Accion.CreateAccion(battle.userMon.GetMov(battle.userMon.lv)[0]);
	}
}
