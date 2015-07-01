using UnityEngine;
using System.Collections;

public class TintColor : MonoBehaviour {
	
	public void ChangeColor (Color c) {
		GetComponent<SpriteRenderer>().material.color = c;
	}
}
