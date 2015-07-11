using UnityEngine;
using System.Collections;

public class ItemBtn : MonoBehaviour {
	
	protected Battle battle;
	
	public void Click(){
		battle = GetComponentInParent<Battle>();
		Debug.Log("click Item");
		//battle.act1 = Accion.CreateAccion("Item",battle.userMon);
	}
}
