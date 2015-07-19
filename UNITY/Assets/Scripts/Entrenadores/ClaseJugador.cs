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
		equipo = new Monstruo[]{Monstruo.CreateMonster("Charmon","Charmi",Monstruo.GetLv(1728)),Monstruo.CreateMonster("Bulbamon","Bulba",Monstruo.GetExp(10),new Stats(0,0,0,0,0,0,0),new Estado(new Stats(2,5,3,2,2,10,80),Est.normal)),Monstruo.CreateMonster("Venomon","Venom",11)};
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
				return Accion.CreateAccion("CambiarMonstruo");
		};
		menuActivo = menus.capa1;
		return Accion.CreateAccion("Elegir");
	}
}
