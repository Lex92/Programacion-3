using UnityEngine;
using System.Collections;

public class ChangeBtn : MonoBehaviour {
	protected Battle battle;
	
	public void Click(){
		battle = GetComponentInParent<Battle>();
		Debug.Log("click Change");
		battle.user.clicks = accionesEntrenador.Cambio;
	}
}
