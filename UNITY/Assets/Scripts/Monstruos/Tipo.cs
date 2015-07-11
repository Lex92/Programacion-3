using UnityEngine;
using System.Collections;

public enum tipos{fuego,tierra,agua,aire,luz,oscuridad,normal};
public enum tipos2{fisico,especial};
public class Tipo {	
	public tipos tipo;
	public Tipo(tipos t){
		tipo = t;
	}

	public float Modificador(tipos ataque){
		switch(tipo){
			case(tipos.fuego):
				if(ataque == tipos.agua){
					Debug.Log("Superefectivo");
					return 2;
				}
			break;
			case(tipos.tierra):
				if(ataque == tipos.aire){
					Debug.Log("Superefectivo");
					return 2;
				}
				break;
			case(tipos.agua):
				if(ataque == tipos.tierra){
					Debug.Log("Superefectivo");
						return 2;
					}
				break;
			case(tipos.aire):
				if(ataque == tipos.fuego){
					Debug.Log("Superefectivo");
							return 2;
						}
				break;
			case(tipos.luz):
				if(ataque == tipos.oscuridad){
					Debug.Log("Superefectivo");
								return 2;
							}
				break;
			case(tipos.oscuridad):
				if(ataque == tipos.luz){
					Debug.Log("Superefectivo");
					return 2;
				}
			break;
		}
		return 1;
	}	
}
