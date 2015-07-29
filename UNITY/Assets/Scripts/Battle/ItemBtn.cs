using UnityEngine;
using System.Collections;

public class ItemBtn : MonoBehaviour {
	
	protected Battle battle;
	
	public void Click(){
		battle = GetComponentInParent<Battle>();
		battle.user.clicks = accionesEntrenador.Item;
	}
}
