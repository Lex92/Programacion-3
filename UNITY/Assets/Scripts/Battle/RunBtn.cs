using UnityEngine;
using System.Collections;

public class RunBtn : MonoBehaviour {
	
	protected Accion act;
	
	public void Click(){
		act = GetComponentInParent<Battle>().act1;
		Debug.Log("click Escape");
		act.stg = Stage.entrenador;
		act.ac = Escape;
	}
	
	void Escape(){
		Debug.Log("Escape");
		if(Random.Range(0,100) < 75){
			Debug.Log("Lograste escapar!!");
			Application.LoadLevel(0);
		}else{
			Debug.Log("no se pudo escapar");
		}
	}
}
