using UnityEngine;
using System.Collections;

public class PauseButton : MonoBehaviour {
	
	public Texture pauseTexture1, pauseTexture2;
	private float size;
	private float scale;
	
	void Start(){
		size = Screen.width/20;
		scale = Time.timeScale;
	}
	[SerializeField] bool paused = false;
	
	void OnGUI(){
		if(!pauseTexture1){
			string butText = "Pause";
			if(paused)
				butText = "Play";
			if (GUI.Button(new Rect(10,size*2+30,size,size), butText))
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
