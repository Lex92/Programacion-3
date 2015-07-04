using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public enum Stage{
	inicio, elegir, entrenador, atq1, atq2, atq3, resultado
}

public class Battle : MonoBehaviour {

	public Monster monst1,monst2;
	public Accion acciones;
	protected int battleStage;
	public Accion act1,act2;
	protected bool waiting = false;
	protected GameObject actionPanel;
	// Use this for initialization
	void Start () {
		/*	Copia ambos monstruos en sus respectivas esquinas	*/
		Instantiate (monst1,new Vector3(-6,-3,0),Quaternion.identity);
		Instantiate (monst2,new Vector3(6,3,0),Quaternion.identity);
		act1 = Instantiate(acciones);
		act2 = Instantiate(acciones);
		GameObject.Find("OponentIm").GetComponent<Image>().sprite = monst2.spr;
		GameObject.Find("UserIm").GetComponent<Image>().sprite = monst1.spr;
		battleStage = (int)Stage.elegir;
		act1.stg = act2.stg = Stage.elegir;
		actionPanel = GameObject.Find("ActionPanel");
	}
	
	// Update is called once per frame
	void Update () {
		//battleStage++;
		if(battleStage == (int)Stage.elegir){
			actionPanel.SetActive(true);
			if(act1.stg != Stage.elegir){
				Debug.Log("eligio");
				battleStage++;
			}
		}else{
			actionPanel.SetActive(false);
			if(battleStage == (int)act1.stg){
				act1.ac();
				act1.stg = Stage.elegir;
				Debug.Log(battleStage);
				battleStage = (int)Stage.elegir;
			}else{
				if(!waiting){
					waiting = true;
					Debug.Log("esperando "+battleStage);
					StartCoroutine(Wait());
				}
			}
		}
		/* poner solo stage eleccion y accion,
		 y que se fije si accion.stg == battleStage-> battleStage++ y accion = null, 
		 if act1/2 == null, battleStage = eleccion
		 */	
		 /*void Update () {
			//battleStage++;
			switch(battleStage){
			case (int)Stage.inicio:
				//eliminarlo??
				break;
			case (int)Stage.elegir:
				//elegir accion
				// instantiate menu(opciones-> atacar, item, cambiar, escapar)
				if((act1.stg != Stage.elegir)){//&&(act2.stg != Stage.elegir)){
					Wait();
				}
				break;
			case (int)Stage.entrenador:
				if(act1.stg == Stage.entrenador){
					act1.Ac();
					act1.stg = Stage.elegir;
				}else{
					Wait();
				}
				//en caso de pedirse un cambio o escapar
				break;
			case (int)Stage.atq1:
				//en caso de tener prioridad alta
				Wait();
				break;
			case (int)Stage.atq2:
				//ataques normales
				Wait();
				break;
			case (int)Stage.atq3:
				//ataques prioridad baja
				Wait();
				break;
			case (int)Stage.resultado:
				battleStage = (int)Stage.elegir;
				//al finalizar la batalla sale, si no vuelve a battleStage = Stage.elegir
				break;
			}
			/* poner solo stage eleccion y accion,
		 y que se fije si accion.stg == battleStage-> battleStage++ y accion = null, 
		 if act1/2 == null, battleStage = eleccion
		 */
		
	}
	IEnumerator Wait(){
		Debug.Log(Time.time);
		yield return new WaitForSeconds(1);
		Debug.Log(Time.time);
		battleStage++;
		waiting = false;
	}
}
