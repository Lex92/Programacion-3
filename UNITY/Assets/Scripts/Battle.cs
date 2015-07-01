using UnityEngine;
using System.Collections;

public enum Stage{
	inicio, elegir, cambio, item, atq1, atq2, atq3, resultado
}

public class Battle : MonoBehaviour {

	public GameObject monst1,monst2;
	public int battleStage = (int)Stage.inicio;
	
	// Use this for initialization
	void Start () {
		/*	Copia ambos monstruos en sus respectivas esquinas	*/
		Instantiate (monst1,new Vector3(-6,-3,0),Quaternion.identity);
		Instantiate (monst2,new Vector3(6,3,0),Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
		battleStage++;
		Debug.Log(battleStage);
		switch(battleStage){
		case (int)Stage.inicio:
			//esto en realidad lo hace en Start()
			break;
		case (int)Stage.elegir:
			//elegir accion
			// instantiate menu(opciones-> atacar, item, cambiar, escapar)
			break;
		case (int)Stage.cambio:
			//en caso de pedirse un cambio o escapar
			break;
		case (int)Stage.item:
			//en caso de querer utilizar un item
			break;
		case (int)Stage.atq1:
			//en caso de tener prioridad alta
			break;
		case (int)Stage.atq2:
			//ataques normales
			break;
		case (int)Stage.atq3:
			//ataques prioridad baja
			break;
		case (int)Stage.resultado:
			battleStage = (int)Stage.inicio;
			//al finalizar la batalla sale, si no vuelve a battleStage = Stage.elegir
			break;
		}
	}
	
}
