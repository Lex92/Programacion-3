using UnityEngine;
using System.Collections;

public class compu : MonoBehaviour {
	
	void OnMouseOver(){	
		if(Input.GetMouseButtonDown(0)){
			Log.AddLine("No funca, el cosito de la cosa debe estar andando mal.");
		}
	}
}
