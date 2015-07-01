using UnityEngine;
using System.Collections;

public class Colisiones : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D c){
		if(c.gameObject.tag == "Player")
			c.gameObject.SendMessage ("Print","colisin "+this.name);
	}
}
