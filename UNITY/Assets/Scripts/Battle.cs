﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public enum Stage{
	/*	en inicio/fin aplicar daños de veneno/etc, revisar si alguno esta muerto	*/
	inicio, elegir, entrenador, atq1, atq2, atq3, resultado, victoria, derrota
}

public class Battle : MonoBehaviour {

	protected int battleStage,battleStageOp;
	protected bool waiting = false;
	protected GameObject actionPanel, atkPanel,chgPanel;
	public Accion act1; //protected
	public Accion act2; //protected
	public Monstruo userMon, opoMon;
	
	// cargar user y oponent de playerprefs (serializados)
	public ClaseJugador user = (ClaseJugador)Entrenador.CreateTrainer("ClaseJugador","pepe");
	public Entrenador oponent = (Entrenador)Entrenador.CreateTrainer("IAOponent","IA");
	[SerializeField] Slider userCauge,opoCauge;
	// Use this for initialization
	void Start () {
		battleStageOp = battleStage = (int)Stage.elegir;
		actionPanel = GameObject.Find("ActionPanel");
		atkPanel = GameObject.Find("AtkPanel");
		chgPanel = GameObject.Find("ChgPanel");
		atkPanel.SetActive(false);
		chgPanel.SetActive(false);
		//crear funciones para cargar monstruos activos (en caso de cambiar en la eleccion
		//antes cargar datos desde save
		userMon = user.equipo[user.activo];
		opoMon = oponent.equipo[oponent.activo];
		//opoMon = Monstruo.CreateMonster("Batmon","bati",10);
		act1 = user.accionEntrenador();
		act2 = Accion.CreateAccion("Elegir");
		
		GameObject.Find("OponentIm").GetComponent<Image>().sprite = Resources.Load(opoMon.imgDir, typeof(Sprite)) as Sprite;
		GameObject.Find("UserIm").GetComponent<Image>().sprite = Resources.Load(userMon.imgDir, typeof(Sprite)) as Sprite;
		userMon.ImprimirStats();
		opoMon.ImprimirStats();
	}
	
	void Update () {
		if(userMon.estado.statActual.vida == 0){
			//act1 = Accion.CreateAccion("Change");
			//mandar señal de cambio a user
			if( user.Change() < 0){
				battleStage = (int) Stage.derrota;
			}
		}
		if(opoMon.estado.statActual.vida == 0){
			//act1 = Accion.CreateAccion("Change");
			//mandar señal de cambio a user
			if( oponent.Change() < 0){
				battleStage = (int) Stage.victoria;
			}
		}
		if((battleStage == (int)Stage.resultado) || (battleStage == (int)Stage.derrota) || (battleStage == (int)Stage.victoria)){
			Debug.Log((Stage)battleStage);
			Application.LoadLevel(0);
		}
		InitPanels();
		if(act1.stg == Stage.elegir){
			battleStage = (int)Stage.elegir;
			act1 = user.accionEntrenador();
		}
		if(userMon.estado.statActual.vida == 0){
			//act1 = Accion.CreateAccion("Change");
			//mandar señal de cambio a user
			if( user.Change() < 0){
				battleStage = (int) Stage.resultado;
			}
		}
		if(act2.stg == Stage.elegir){
			battleStageOp = (int)Stage.elegir;
			act2 = oponent.accionEntrenador();
		}
		if(opoMon.estado.statActual.vida == 0){
			//act2 = Accion.CreateAccion("Change");
			//mandar señal de cambio a opo
		}
		if(act1.stg != Stage.elegir){
			if(battleStage == (int)act1.stg){
				act1.ac();
				act1.stg = Stage.elegir;
			}else{
				if(!waiting){
					waiting = true;	
					StartCoroutine(Wait(0));
				}
			}
		}
		if(act2.stg != Stage.elegir){
			if(battleStageOp == (int)act2.stg){
				act2.ac();
				act2.stg = Stage.elegir;
			}else{
				if(!waiting){
					waiting = true;	
					StartCoroutine(Wait(1));
				}
			}
		}
	}
	
	void OnGUI(){
		userCauge.maxValue = userMon.GetStats().vida;
		userCauge.value = userMon.estado.statActual.vida;
		opoCauge.maxValue = opoMon.GetStats().vida;
		opoCauge.value = opoMon.estado.statActual.vida;
	}
	
	IEnumerator Wait(int i){
		if(i==0){
			yield return new WaitForSeconds(opoMon.estado.statActual.velocidad/userMon.estado.statActual.velocidad);
			battleStage++;
		}else {
			yield return new WaitForSeconds(userMon.estado.statActual.velocidad/opoMon.estado.statActual.velocidad);
			battleStageOp++;
		}
		waiting = false;
	}
	
	private void InitPanels(){
		if(userMon != user.equipo[user.activo]){
			userMon = user.equipo[user.activo];
			act1.stg = Stage.elegir;
		}
		if(opoMon != oponent.equipo[oponent.activo]){
			opoMon = oponent.equipo[oponent.activo];
			act2.stg = Stage.elegir;
		}
		GameObject.Find("OponentIm").GetComponent<Image>().sprite = Resources.Load(opoMon.imgDir, typeof(Sprite)) as Sprite;
		GameObject.Find("UserIm").GetComponent<Image>().sprite = Resources.Load(userMon.imgDir, typeof(Sprite)) as Sprite;
		
		oponent.target = userMon;
		oponent.source = opoMon;
		if(user.menuActivo == menus.capa1){
			actionPanel.SetActive(true);
		}else{
			actionPanel.SetActive(false);
		}
		if(user.menuActivo == menus.capaAtaque){
			atkPanel.SetActive(true);
		}else{
			atkPanel.SetActive(false);
		}
		if(user.menuActivo == menus.capaCambio){
			chgPanel.SetActive(true);
		}else{
			chgPanel.SetActive(false);
		}
	}
}
