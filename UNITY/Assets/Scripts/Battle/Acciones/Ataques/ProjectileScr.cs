using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ProjectileScr : MonoBehaviour {	
	public string imgName = "Fireball";
	private Animator animator;
	void Start () {
		GetComponent<Image>().sprite  = Resources.Load(imgName, typeof(Sprite)) as Sprite;
		animator = GetComponent<Animator>();
		StartCoroutine(Die ());
	}
	IEnumerator Die() {
		while (!(animator.GetCurrentAnimatorStateInfo(0).IsName("Ended"))) { // or whatever this property is called
			yield return null;
		}
		Object.Destroy(this.gameObject);
	}
}
