using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ActLog : MonoBehaviour {
	
	void Update () {
		GetComponent<Text>().text = Log.GetText();
	}
}
