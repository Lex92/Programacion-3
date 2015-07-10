﻿using UnityEngine;
using System.Collections;

public class Music : MonoBehaviour {

	public Texture audioTexture1, audioTexture2;
	public AudioClip theme;
	private AudioSource song;
	void Start () {
		song = gameObject.AddComponent<AudioSource>();//("AudioSource") as AudioSource;
		if(!theme)
			theme = Resources.Load("Music/Misc/Back in Black") as AudioClip;
		song.clip = theme;
		song.spatialBlend = 0;
		song.Play();
	}
		
	private bool muted = false;
	void OnGUI(){
		if(!audioTexture1){
			string butText = "MUTE";
			if(muted)
				butText = "Play";
			if (GUI.Button(new Rect(Screen.width-60, Screen.height-60, 50, 50), butText))
				muted = !muted;
		}else if (GUI.Button(new Rect(Screen.width-(10+Screen.width/10), 10, Screen.height/5, Screen.height/5), audioTexture1,GUIStyle.none)){
			Texture audioTextureAux = audioTexture1;
			audioTexture1 = audioTexture2;
			audioTexture2 = audioTextureAux;
			muted = !muted;
		}
	}
	
	void Update(){
		song.mute = muted;
	}
}