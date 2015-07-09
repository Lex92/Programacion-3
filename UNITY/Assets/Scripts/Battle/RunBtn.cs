using UnityEngine;
using System.Collections;

public class RunBtn : MonoBehaviour {
	
	protected Battle battle;
	
	public void Click(){
		battle = GetComponentInParent<Battle>();
		Debug.Log("click Huir");
		battle.user.clicks = accionesEntrenador.Huir;
	}
}
