using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class battleResult : MonoBehaviour {
	[SerializeField] Text t;
	void Start () {
		t.text = PlayerPrefs.GetString("Result");
		PlayerPrefs.DeleteKey("Result");
		Application.LoadLevel("Sc01");
	}
}
