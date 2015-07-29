using UnityEngine;
using System.Collections;

public class mainMenu : MonoBehaviour {
	void Start(){
		PlayerPrefs.DeleteAll();
		Input.simulateMouseWithTouches = true;
	}

	public void cambiarEscenario(){
		//setea monstruos iniciales
		Monstruo ma = Monstruo.CreateMonster("Venomon","Venomon",15);
		Monstruo mb = Monstruo.CreateMonster("Batmon","Batmon",15);
		Monstruo mc = Monstruo.CreateMonster("Bulbamon","Bulbamon",15);
		SaveMonster.NewMonster(ma.nombre,ma.especie,ma.exp.ToString(),ma.modStats.ToString(),ma.estado.ToString());
		SaveMonster.NewMonster(mb.nombre,mb.especie,mb.exp.ToString(),mb.modStats.ToString(),mb.estado.ToString());
		SaveMonster.NewMonster(mc.nombre,mc.especie,mc.exp.ToString(),mc.modStats.ToString(),mc	.estado.ToString());
		
		Application.LoadLevel ("Sc01");
	}
}
