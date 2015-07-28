using UnityEngine;
using System.Collections;

public class Init : MonoBehaviour {
	
	public GameObject character;
	public string sceneID;
	// Use this for initialization
	void Start () {
		Debug.Log(sceneID);
		CharacterMain c = character.GetComponent<CharacterMain>();
		c.Load("PJ");
		c.Save();
		
		Monstruo ma = Monstruo.CreateMonster("Venomon","Venomon",15);
		Monstruo mb = Monstruo.CreateMonster("Batmon","Batmon",15);
		Monstruo mc = Monstruo.CreateMonster("Bulbamon","Bulbamon",15);
		SaveMonster.NewMonster(ma.nombre,ma.especie,ma.exp.ToString(),ma.modStats.ToString(),ma.estado.ToString());
		SaveMonster.NewMonster(mb.nombre,mb.especie,mb.exp.ToString(),mb.modStats.ToString(),mb.estado.ToString());
		SaveMonster.NewMonster(mc.nombre,mc.especie,mc.exp.ToString(),mc.modStats.ToString(),mc	.estado.ToString());
	}
}
