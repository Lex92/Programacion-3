using UnityEngine;
using System.Collections;

public class AttackBtn : MonoBehaviour {
	// crear ActionBtn del cual hereden los 4 botones, ahi poner todo menos asignacion de stg y ac
	protected Accion act;

	public void Click(){
		act = GetComponentInParent<Battle>().act1;
		Debug.Log("click Attack");
		act.stg = Stage.atq3;
		act.ac = Attack;
	}
	
	void Attack(){
		Debug.Log("Ataque");
	}
}
