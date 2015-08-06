using UnityEngine;
using System.Collections;

public class SaveButton : MonoBehaviour {	
	public bool exitEnabled = true;
	public Texture exitTexture1, exitTexture2;
	public GameObject player;
	public sqlScript db = new sqlScript();
	private string scene,posX,posY;
	private float size;
	
	void Start(){
		size = Screen.width/20;
	}

	void OnGUI(){
		GUI.depth = 0;
		if(exitTexture1){
			if(GUI.Button(new Rect(size-52, size+10, size+30, size-30), "Save")){
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
