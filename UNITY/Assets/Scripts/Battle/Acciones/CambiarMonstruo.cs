using UnityEngine;
using System.Collections;

public class CambiarMonstruo : Accion {

	public Monstruo targ;
	
	public CambiarMonstruo(){
		stg = Stage.entrenador;
		ac = Cambio;
	}
	
	private void Cambio(){
		//la funcion esta vacia, en Battle se tiene que revisar si hubo cambios en "activo" de entrenadores
	}
}
