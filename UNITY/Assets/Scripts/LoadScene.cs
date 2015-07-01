using UnityEngine;
using System.Collections;

public class LoadScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<IO>().LoadScene("Sc01");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
