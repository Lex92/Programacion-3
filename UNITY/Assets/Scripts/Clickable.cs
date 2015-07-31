using UnityEngine;
using System.Collections;

public class Clickable : MonoBehaviour {
	
	void OnMouseOver(){	
		if(Input.GetMouseButtonDown(0)){
			Log.AddLine("Lanzaste una piedra a la ventana");
		}
	}
}
