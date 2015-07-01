using UnityEngine;
using System.Collections;

public class Monster : MonoBehaviour {

	public string especie;
	public int vidaMax, vidaAct;
	public int EnergiaMax, EnergiaAct;
	public Sprite spr;

	// Use this for initialization
	void Start () {
		/*	Busca sprite de la especie.	*/
		gameObject.AddComponent<SpriteRenderer>();
		gameObject.GetComponent<SpriteRenderer>().sprite = spr;
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
