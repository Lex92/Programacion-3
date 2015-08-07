using UnityEngine;
using System.Collections;

public class SaveButton : MonoBehaviour {	
	public bool exitEnabled = true;
	public Texture exitTexture1, exitTexture2;
	public GameObject player;
	public sqlScript db = new sqlScript();
	private string scene,posX,posY;
	public float sizeX,sizeY;
	public float offsetX,offsetY;

	void OnGUI(){
		GUI.depth = 0;
		if(exitTexture1){
			if(GUI.Button(new Rect(offsetX,offsetY,sizeX,sizeY), "Save")){
				player = GameObject.FindWithTag("Player");
				scene = Application.loadedLevelName;
				posX=player.transform.position.x.ToString();
				posY=player.transform.position.y.ToString();
				db.updatePosition(scene,posX,posY);
				db.updateMonsters();
			}		
		}
	}
}
