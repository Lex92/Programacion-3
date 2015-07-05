using UnityEngine;
using System.Collections;

public enum tipos{fuego,tierra,agua,viento,rayo};
public abstract class Tipo {
	
	public tipos tipo;

	public float modificador(tipos ataque, tipos tipo1){
		return 1;
	}
	
	public float modificador(tipos ataque, tipos tipo1, tipos tipo2){
		return modificador(ataque,tipo1)*modificador(ataque,tipo2);
	}
	
}
