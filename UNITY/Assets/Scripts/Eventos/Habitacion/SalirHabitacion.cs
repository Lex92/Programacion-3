using UnityEngine;
using System.Collections;

public class SalirHabitacion : MonoBehaviour {
	void OnTriggerEnter2D(Collider2D c){
		if(c.tag=="Player"){
			c.SendMessage("SavePos2",new Vector2(-8f,-18f));
			Application.LoadLevel("Sc01");
			Log.AddLine("Ah, el aire libre... No me gusta...");
		}
	}
}
