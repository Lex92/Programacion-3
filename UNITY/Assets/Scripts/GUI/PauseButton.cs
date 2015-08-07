using UnityEngine;
using System.Collections;

public class PauseButton : MonoBehaviour {
	
	public Texture pauseTexture1, pauseTexture2;
	public float sizeX,sizeY;
	public float offsetX,offsetY;
	private float scale;
	
	void Start(){
		scale = Time.timeScale;
	}
	[SerializeField] bool paused = false;
	
	void OnGUI(){
		GUI.depth = 0;
		if(!pauseTexture1){
			string butText = "Pause";
			if(paused)
				butText = "Play";
			if (GUI.Button(new Rect(offsetX,offsetY,sizeX,sizeY), butText))
				paused = !paused;
		}else if (GUI.Button(new Rect(Screen.width-(10+Screen.width/10), 10, Screen.height/5, Screen.height/5), pauseTexture1,GUIStyle.none)){
			Texture pauseTextureAux = pauseTexture1;
			pauseTexture1 = pauseTexture2;
			pauseTexture2 = pauseTextureAux;
			paused = !paused;
		}
	}
	
	void Update(){
		if(paused){
			Time.timeScale = 0;
		}else{
			Time.timeScale = scale;
		}
	}
}
