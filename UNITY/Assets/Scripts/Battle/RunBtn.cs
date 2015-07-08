using UnityEngine;
using System.Collections;

public class RunBtn : MonoBehaviour {
	
	protected Battle battle;
	
	public void Click(){
		battle = GetComponentInParent<Battle>();
		Debug.Log(battle.act1.stg);
		Debug.Log("click Escape");
		battle.act1 = Accion.CreateAccion("Huir");
		Debug.Log(battle.act1.stg);
	}
	/*
	void Escape(){
		Debug.Log("Escape");
		if(Random.Range(0,100) < 75){
			Debug.Log("Lograste escapar!!");
			Application.LoadLevel(0);
		}else{
			Debug.Log("no se pudo escapar");
		}
	}*/
}
