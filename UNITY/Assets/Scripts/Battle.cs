using UnityEngine;
using System.Collections;

public enum Stage{
	inicio, elegir, cambio, item, atq1, atq2, resultado
}

public class Battle : MonoBehaviour {

	public GameObject monst1,monst2;
	public int battleStage = 0;
	
	// Use this for initialization
	void Start () {
		/*	Copia ambos monstruos en sus respectivas esquinas	*/
		Instantiate (monst1,new Vector3(-6,-3,0),Quaternion.identity);
		Instantiate (monst2,new Vector3(6,3,0),Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
		switch(battleStage){
		case Stage.inicio:
		battleStage++;
			break;
		case Stage.elegir:
			//elegir accion
			break;
		case Stage.cambio:
			//en caso de pedirse un cambio
			break;
		case Stage.item:
			//en caso de querer utilizar un item
			break;
		case Stage.atq1:
			//en caso de tener prioridad alta
			break;
		case Stage.atq2:
			//ataques normales
			break;
		case Stage.resultado:
			//al finalizar la batalla sale, si no vuelve a battleStage = Stage.elegir
			break;
		}
	}
}
