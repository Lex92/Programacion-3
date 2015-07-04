using UnityEngine;
using System.Collections;

public class ItemBtn : MonoBehaviour {
	
	protected Accion act;
	
	public void Click(){
		act = GetComponentInParent<Battle>().act1;
		Debug.Log("click Item");
		act.stg = Stage.entrenador;
		act.ac = Item;
	}
	
	void Item(){
		Debug.Log("Item");
	}
}
