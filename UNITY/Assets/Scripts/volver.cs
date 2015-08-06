using UnityEngine;
using System.Collections;

public class volver : MonoBehaviour {
	private float size;
	
	void Start(){
		size = Screen.width/20;
	}
	
	void OnGUI(){
		GUI.depth = 0;
		if (GUI.Button(new Rect(size-52,size+170,size+30,size-30), "Volver")){
			Application.LoadLevel("Sc01");			
		}
		
		
	}
}
