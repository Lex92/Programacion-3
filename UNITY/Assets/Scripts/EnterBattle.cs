using UnityEngine;
using System.Collections;

public class EnterBattle : MonoBehaviour {
	
	/*
	public bool used = false;
	
	void Start(){
		used = PlayerPrefs.HasKey("used");
	}*/
	/*
	void OnTriggerEnter2D(Collider2D c){
		if((c.gameObject.tag == "Player")&&(!used)){
			PlayerPrefs.SetInt("used",1);
			PlayerPrefs.SetString("Entrenador","IAOponent");
			PlayerPrefs.Save();
			Log.AddLine("Has sido retado a un duelo!");
			c.gameObject.SendMessage ("Battle");
		}
	}
	*/
	
	void OnTriggerEnter2D(Collider2D c){
		if((c.gameObject.tag == "Player")&&(!(EventPP.HasEvent("Lucha1")))){
			EventPP.NewEvent("Lucha1");
			EventPP.SetTrainer("IAOponent");
			Log.AddLine("Has sido retado a un duelo!");
			c.gameObject.SendMessage("Battle");
		}
	}
}
