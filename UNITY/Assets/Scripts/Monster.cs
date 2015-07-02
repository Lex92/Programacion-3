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
		/*
		SpriteRenderer sr = gameObject.AddComponent<SpriteRenderer>();
		sr.enabled = false;
		sr.sprite = spr;
		*/
	}
}
