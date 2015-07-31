using UnityEngine;
using System.Collections;

public class mainMenu : MonoBehaviour {
	void Start(){
		PlayerPrefs.DeleteAll();
		Input.simulateMouseWithTouches = true;
	}

	public void cambiarEscenario(){
		//borra la partida y setea monstruos iniciales
		sqlScript db = new sqlScript();
		db.DeleteMonsters ();
		Monstruo ma = Monstruo.CreateMonster("Charmon","Charmi",5);
		SaveMonster.AddMonster(ma,true);
		
		Application.LoadLevel ("Sc01");
	}
}
