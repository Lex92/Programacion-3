using UnityEngine;
using System.Collections;

public class EntrarHabitacion : MonoBehaviour {
	
	void OnTriggerEnter2D(Collider2D c){
		if(c.tag=="Player"){
			c.SendMessage("SavePos2",new Vector2(0f,-3.5f));
			Application.LoadLevel("habitacion");
			Log.AddLine("Mi preciosa habitacion, santuario de tranquilidad... Deberia ordenar un poco.");
		}
	}
}
