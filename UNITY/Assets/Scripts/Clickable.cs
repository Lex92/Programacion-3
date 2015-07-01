using UnityEngine;
using System.Collections;

public class Clickable : MonoBehaviour {

	void OnMouseOver(){
		if(Input.GetMouseButtonDown(0)){
			Debug.Log("clickeado");
			Application.Quit();
			Debug.Log("quit");
		}
	}
}
