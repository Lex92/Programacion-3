using UnityEngine;
using System.Collections;

public class EnterBattle : MonoBehaviour {
	public bool used = false;
	
	void Start(){
		used = PlayerPrefs.HasKey("used");
		Debug.Log("used: "+used);
	}
	void OnTriggerEnter2D(Collider2D c){
		if((c.gameObject.tag == "Player")&&(!used)){
			
			PlayerPrefs.SetInt("used",1);
			PlayerPrefs.Save();
			c.gameObject.SendMessage ("Battle");
		}
	}
	
}
