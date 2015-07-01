using UnityEngine;
using System.Collections;

public class InteractButton : MonoBehaviour {
	
	public Texture2D ButtonNormal;
	public Texture2D ButtonPressed;
	
	public GameObject character;
	private CharMove charMove;
	
	void Start(){
		GetComponent<GUITexture>().texture = ButtonNormal;
		if(character == null)
			character = GameObject.FindGameObjectWithTag("Player");
		charMove = character.GetComponent<CharMove>();
	}
	void Update (){
		foreach( Touch touch in Input.touches){
			if(touch.phase == TouchPhase.Ended)
				charMove.isInteracting = GetComponent<GUITexture>().HitTest(touch.position);
		}
	}

}