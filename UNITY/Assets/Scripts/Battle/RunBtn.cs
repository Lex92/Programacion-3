using UnityEngine;
using System.Collections;

public class RunBtn : MonoBehaviour {
	
	protected Battle battle;
	
	public void Click(){
		battle = GetComponentInParent<Battle>();
		battle.user.clicks = accionesEntrenador.Huir;
	}
}
