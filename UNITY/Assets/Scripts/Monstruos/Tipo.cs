using UnityEngine;
using System.Collections;

public enum tipos{fuego,tierra,agua,aire,luz,oscuridad,normal};
public class Tipo {	
	public tipos tipo;
	public Tipo(tipos t){
		tipo = t;
	}

	public float Modificador(tipos ataque){
		switch(tipo){
			case(tipos.fuego):
				if(ataque == tipos.agua){
					Log.AddLine("Fue un golpe superefectivo!");
					return 2;
				}
			break;
			case(tipos.tierra):
				if(ataque == tipos.aire){
					Log.AddLine("Fue un golpe superefectivo!");
					return 2;
				}
				break;
			case(tipos.agua):
				if(ataque == tipos.tierra){
					Log.AddLine("Fue un golpe superefectivo!");
					return 2;
				}
				break;
			case(tipos.aire):
				if(ataque == tipos.fuego){
					Log.AddLine("Fue un golpe superefectivo!");
					return 2;
				}
				break;
			case(tipos.luz):
				if(ataque == tipos.oscuridad){
					Log.AddLine("Fue un golpe superefectivo!");
						return 2;
					}
				break;
			case(tipos.oscuridad):
				if(ataque == tipos.luz){
					Log.AddLine("Fue un golpe superefectivo!");
					return 2;
				}
			break;
		}
		return 1;
	}	
}
