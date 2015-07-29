using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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
		equipo = GetTeam();
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
			case(accionesEntrenador.Item):
				menuActivo = menus.ninguno;
				clicks = accionesEntrenador.nula;
				return Accion.CreateAccion("Item",source,target);
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
	
	private Monstruo[] GetTeam(){
		List<Monstruo> listMonst = new List<Monstruo>();
		string[] nombres = SaveMonster.GetMonsterList();
		for (int i = 0; i < nombres.Length; i++) {
			listMonst.Add(SaveMonster.LoadMonster(nombres[i]));
		}
		return (Monstruo[])listMonst.ToArray();
	}
}
