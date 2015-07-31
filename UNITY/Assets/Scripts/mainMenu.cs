using UnityEngine;
using System.Collections;

public class mainMenu : MonoBehaviour {
	void Start(){
		PlayerPrefs.DeleteAll();
		Input.simulateMouseWithTouches = true;
	}

	public void cambiarEscenario(){
		//setea monstruos iniciales
		Monstruo ma = Monstruo.CreateMonster("Charmon","Charmi",5);
		SaveMonster.AddMonster(ma,true);
		PlayerPrefs.SetString ("botonPresionado","new");
		Application.LoadLevel ("Sc01");
	}
}
