using UnityEngine;
using System.Collections;

public class Accion : MonoBehaviour {
	
	public delegate void Act();
	
	public Stage stg = Stage.elegir;
	public string s;
	public Act ac;
}
