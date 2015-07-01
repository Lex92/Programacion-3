using UnityEngine;
using System.Collections;

public class RunButton : MonoBehaviour {

	public GameObject character;
	private CharMove charMove;
	
	void Start(){
		if(character == null)
			character = GameObject.FindGameObjectWithTag("Player");
		charMove = character.GetComponent<CharMove>();
	}
	
	
	void Update (){
		Color colorT = GetComponent<GUITexture>().color;
		if(!charMove.canMove){
			colorT.a = 0.05f;
		}else{
			colorT.a = 0.5f;
		}
		GetComponent<GUITexture>().color = colorT;
		foreach( Touch touch in Input.touches){
			charMove.isRunning = GetComponent<GUITexture>().HitTest(touch.position);
			if(charMove.isRunning)
				charMove.text.GetComponent<GUIText>().text = "Running";
		}
	}
}
