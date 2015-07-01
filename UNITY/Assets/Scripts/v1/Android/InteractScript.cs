using UnityEngine;
using System.Collections;

public class InteractScript: MonoBehaviour{

	private int intNum = 0;
	CharMove charMove;
	public void Interact(Vector2 dir){
		//intNum++;
		if(texto!= null)
			Destroy(texto);
		/*
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		charMove = player.GetComponent<CharMove>();
		*/
		charMove = GameObject.FindGameObjectWithTag("Player").GetComponent<CharMove>();
		if(charMove == null)
			return;
		charMove.canMove = false;
		/*	PARA DEBUG	*/
		charMove.text.GetComponent<GUIText>().text = "Interact Script";
		
		intNum = Interaction(intNum);
		/* Si devolvio 0 fue para terminar la conversacion	*/
		if(intNum <=0){
			intNum = 0;
			charMove.canMove = true;
		}
	}
	protected GameObject texto = null;
	
	protected virtual int Interaction(int num){
		/* PARA DEBUG	*/
		charMove.text.GetComponent<GUIText>().text = "Interact SubScript";
		switch(++num){
		case 1:
			Texto("El hijo no tiene interacciones!");
		break;
		case 2:
			Texto ("texto2\nTexto2b");
		break;
		case 3:
			Texto ("texto3");
		break;
		default:
			return 0;	//devuelve 0 para terminar la conversacion
		}
		return num;
	}
	
	/* Muestra un texto estandar sobre un rectangulo en la zona inferior	*/
	public void Texto(string text){
		charMove.text.GetComponent<GUIText>().text = "Interact SubSubScript";
		texto = GameObject.Instantiate(Resources.Load("Textos")) as GameObject;
		texto.GetComponent<GUIText>().text = text;
	}	
}
