using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LifeCauge : MonoBehaviour {

	[SerializeField] Slider cauge;
	[SerializeField] Image Fill;
	private Color maxHealthColor = Color.green;
	private Color minHealthColor = Color.red;
	void Update () {
		Fill.color = Color.Lerp (minHealthColor,maxHealthColor,(float)cauge.value/(float)cauge.maxValue);
	}
}
