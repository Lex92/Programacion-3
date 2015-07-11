using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SkyColor : MonoBehaviour {

	[SerializeField] Color day;
	[SerializeField] Color night;
	void Update () {
		GetComponent<SpriteRenderer>().color = Color.Lerp(day,night,Mathf.Abs((Time.time/24)%2-1));
	}
}
