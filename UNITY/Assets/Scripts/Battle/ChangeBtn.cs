using UnityEngine;
using System.Collections;

public class ChangeBtn : MonoBehaviour {
	
	protected Accion act;
	
	public void Click(){
		act = GetComponentInParent<Battle>().act1;
		Debug.Log("click Cambio");
		act.stg = Stage.entrenador;
		act.ac = Cambio;
	}
	
	void Cambio(){
		Debug.Log("Change!");
	}
}
