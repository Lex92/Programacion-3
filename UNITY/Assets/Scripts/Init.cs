using UnityEngine;
using System.Collections;

public class Init : MonoBehaviour {
	
	public GameObject character;
	public string sceneID;
	// Use this for initialization
	void Start () {
		Debug.Log(sceneID);
		CharacterMain c = character.GetComponent<CharacterMain>();
		c.Load("PJ");
		c.Save();
	}
}
