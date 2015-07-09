using UnityEngine;
using System.Collections;

public enum accionesEntrenador{
	AtaqueListo,Ataque,Cambio,CambioListo,Huir,Item,nula
}
public enum menus{
	capa1, capaAtaque, capaCambio, ninguno
}

public class ClaseJugador : Entrenador {

	public ClaseJugador(string name){
		nombre = name;
		accionEntrenador = AccionPlayer;
		equipo = new Monstruo[]{Monstruo.CreateMonster("Bulbamon","bulba",10),Monstruo.CreateMonster("Batmon","batu",11)};
	}
	
	public menus menuActivo = menus.capa1;
	public accionesEntrenador clicks = accionesEntrenador.nula;
	public int nroMovimiento = 0;
	
	public Accion AccionPlayer(){
		switch(clicks){
			case(accionesEntrenador.Huir):
				menuActivo = menus.ninguno;
				clicks = accionesEntrenador.nula;
				return Accion.CreateAccion("Huir");
			case(accionesEntrenador.Ataque):
				menuActivo = menus.capaAtaque;
				return Accion.CreateAccion("Elegir");
			case(accionesEntrenador.AtaqueListo):
				menuActivo = menus.ninguno;
				clicks = accionesEntrenador.nula;
				return Accion.CreateAccion(equipo[activo].GetMov()[nroMovimiento],source,target);
			case(accionesEntrenador.Cambio):
				menuActivo = menus.capaCambio;
				return Accion.CreateAccion("Elegir");
			case(accionesEntrenador.CambioListo):
				menuActivo = menus.ninguno;
				clicks = accionesEntrenador.nula;
				activo = nroMovimiento;
				return Accion.CreateAccion("Cambio");
		};
		menuActivo = menus.capa1;
		return Accion.CreateAccion("Elegir");
	}
}
