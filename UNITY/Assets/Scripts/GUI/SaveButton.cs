using UnityEngine;
using System.Collections;

public class SaveButton : MonoBehaviour {	
	public bool exitEnabled = true;
	public Texture exitTexture1, exitTexture2;
	public GameObject player;
	public sqlScript db=new sqlScript();
	string posX,posY;

	void OnGUI(){
		if(exitTexture1){
			if(GUI.Button(new Rect(Screen.width-1350, 10, 50, 50), "Save")){
				player = GameObject.Find("Player");
				posX=player.transform.position.x.ToString();
				posY=player.transform.position.y.ToString();
				db.updatePosition(posX,posY);
				print("Partida Guardada");
			}		
		}
	}
}
