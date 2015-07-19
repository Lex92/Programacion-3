using UnityEngine;
using System.Collections;

public class mainMenu : MonoBehaviour {
	void Start(){
		Input.simulateMouseWithTouches = true;
	}

	public void cambiarEscenario(){

		Application.LoadLevel ("Sc01");
	}
}
