using UnityEngine;
using System.Collections;

public class mainMenu : MonoBehaviour {
	void Start(){
		PlayerPrefs.DeleteAll();
		Input.simulateMouseWithTouches = true;
	}

	public void cambiarEscenario(){
		Application.LoadLevel ("Sc01");
	}
}
