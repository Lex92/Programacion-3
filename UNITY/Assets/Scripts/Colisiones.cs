using UnityEngine;
using System.Collections;

public class Colisiones : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D c){
		if(c.gameObject.tag == "Player")
			RestaurarEquipo();
			c.gameObject.SendMessage ("Print","Equipo restaurado");
	}
	
	void RestaurarEquipo(){
		string[] nombres = SaveMonster.GetMonsterList();
		Monstruo aux;
		for( int i = 0; i<nombres.Length; ++i ){
			aux = SaveMonster.LoadMonster(nombres[i]);
			aux.Restaurar();
			SaveMonster.AddMonster(aux,false);
		}
	}
}
