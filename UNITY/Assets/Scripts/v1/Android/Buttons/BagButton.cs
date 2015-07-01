using UnityEngine;
using System.Collections;

public class BagButton : MonoBehaviour {	
	
	/*
	public GameObject character;
	private CharMove charMove;
	*/
	public bool openBag;

	void OnGUI(){
		if(openBag){
			for(int i = 0;i<30;++i){
				if (GUI.Button(new Rect(Screen.width-10, 10+i*40, 50, 30), i.ToString()))
					openBag = !openBag;
			}
		}
	}
	
	void Update (){
		Color colorT = GetComponent<GUITexture>().color;
		if(openBag){
			colorT.a = 0.2f;
		}else{
			colorT.a = 0.8f;
		}
		GetComponent<GUITexture>().color = colorT;
		foreach( Touch touch in Input.touches){
			if(GetComponent<GUITexture>().HitTest(touch.position)){
				if(touch.phase == TouchPhase.Ended){
					openBag = !openBag;
				}
			}
		}
	}
}
