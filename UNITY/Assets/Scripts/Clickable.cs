using UnityEngine;
using System.Collections;

public class Clickable : MonoBehaviour {
	
	#pragma warning disable 0618
	void OnMouseOver(){	
	#pragma warning restore 0618
		if(Input.GetMouseButtonDown(0)){
			Debug.Log("clickeado");
			Application.Quit();
			Debug.Log("quit");
		}
	}
}
