using UnityEngine;
using System.Collections;

public class continueButton : MonoBehaviour {
		
	private sqlScript db = new sqlScript();
	public void Cargar(){
		PlayerPrefs.SetString ("botonPresionado","load");
		db.cargarPartida();
		db.updateMonsters();
	}
}
