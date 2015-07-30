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
		if(exitTexture1){
			if(GUI.Button(new Rect(10, 10, size, size), "Save")){
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
