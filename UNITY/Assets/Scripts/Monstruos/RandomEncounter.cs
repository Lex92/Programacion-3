using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RandomEncounter : MonoBehaviour {

	public string habName;
	private Habitat habitat;
	//private System.Random Rnd = new System.Random();
	public int posible;
	protected bool waiting;
	
	void Start(){
		Debug.Log("START");
		habitat = Habitat.CreateHabitat(habName,5,6);
		//habitat = GetComponent<Habitat>();
		waiting = true;
		StartCoroutine(Wait(3));
	}
	
	void OnTriggerEnter2D(Collider2D col){
		Debug.Log(col.tag);
	}
	
	void OnTriggerStay2D(Collider2D col){
		if(col.CompareTag("Player")){
			if(!waiting){
				waiting = true;
				if((int)Random.Range(0,100)<posible){
					CreateEncounter(habitat.GetMonstruo());
					col.gameObject.SendMessage ("Battle");
				}else{
					Debug.Log("ninguno");
				}
				StartCoroutine(Wait(2));
			}
		}
	}
	private void CreateEncounter(Monstruo m){
		PlayerPrefs.SetString("Entrenador","Salvaje");
		PlayerPrefs.SetString("SalvajeMon",m.nombre);
		PlayerPrefs.SetInt("SalvajeMonLv",m.lv);
		PlayerPrefs.Save();
	}
	
	IEnumerator Wait(int i){
		yield return new WaitForSeconds(i);
		waiting = false;
	}
}
