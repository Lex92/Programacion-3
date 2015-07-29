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
		SaveMonster.NewMonster(ma.nombre,ma.especie,ma.exp.ToString(),ma.modStats.ToString(),ma.estado.ToString());
		
		Application.LoadLevel ("Sc01");
	}
}
