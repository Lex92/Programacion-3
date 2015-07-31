using UnityEngine;
using System.Collections;


public enum direccion{ otro, mismo};
public class AttackAnimations : MonoBehaviour {

	private static Battle b;
	
	public static void SetProjectile(direccion dir, string imagen, Monstruo src){
		b = GameObject.Find("Battle").GetComponent<Battle>();
		b.Shoot(dir,imagen,src);
	}
}
