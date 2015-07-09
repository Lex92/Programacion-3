using UnityEngine;
using System.Collections;
using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

[System.Serializable]
public abstract class Entrenador {

	public string nombre;
	//public List<Monstruo> equipo;
	public Monstruo[] equipo;
	public int activo = 0;
	public Monstruo target,source;//designar en battle
	/*	para clase del jugador, en getAction se instanciarian los menus y crearian los botones para elegir la accion	*/
	public delegate Accion GetAction();
	public GetAction accionEntrenador;
	
	public static Entrenador CreateTrainer(string clase, string name){
		Type types = Type.GetType(clase);
		
		if (types == null)
			throw new InvalidOperationException("The given class does not have a Type associated with it.");
		
		return Activator.CreateInstance(types,name) as Entrenador;
	}
}
