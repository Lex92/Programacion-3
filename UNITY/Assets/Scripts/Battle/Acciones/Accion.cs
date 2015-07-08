using UnityEngine;
using System.Collections;
using System;

public abstract class Accion {
	
	public delegate void Act();
	
	public Stage stg = Stage.elegir;
	public Act ac;
	/*
	public Accion(){
	}
	*/
	
	
	/*
		los botones de acciones se crearian dinamicamente con todas las acciones posibles
		al apretarse un boton, llamaria crateAccion(button.name)
		y ahi se crea la accion.
		
		parametros?? (target)
	
	*/
	public static Accion CreateAccion(string accion)
	{
		Type types = Type.GetType(accion);
		
		if (types == null)
			throw new InvalidOperationException("The given action does not have a Type associated with it.");
		
		return Activator.CreateInstance(types) as Accion;
	}
}
