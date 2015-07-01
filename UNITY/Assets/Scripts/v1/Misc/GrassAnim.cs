using UnityEngine;
using System.Collections;

public class GrassAnim : MonoBehaviour {
	
	protected Animator animator;
	void Start(){
		animator = GetComponent<Animator>();
	}
	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "Player") {
			animator.SetBool ("Stepped", true);
		}
	}
	void OnTriggerExit2D(Collider2D col){
		if (col.tag == "Player") {
			animator.SetBool ("Stepped", false);
		}
	}
}