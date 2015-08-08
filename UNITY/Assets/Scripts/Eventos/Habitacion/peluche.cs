using UnityEngine;
using System.Collections;

public class peluche : MonoBehaviour {
	
	void OnMouseOver(){	
		if(Input.GetMouseButtonDown(0)){
			Log.AddLine("Es un peluche de mi juego favorito");
		}
	}
}
