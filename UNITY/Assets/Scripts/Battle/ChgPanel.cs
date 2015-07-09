using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChgPanel : MonoBehaviour {
	
	[SerializeField] GameObject buttonPrefab;
	protected Battle battle;
	public ClaseJugador trainer;
	
	
	void OnEnable(){
		battle = FindObjectOfType<Battle>();
		trainer = battle.user;
		for(int i=0;i<trainer.equipo.Length;i++){
			if(trainer.equipo[i].estado.statActual.vida > 0){
				int index = i;
				GameObject button = (GameObject)Instantiate(buttonPrefab);
				button.GetComponentInChildren<Text>().text = trainer.equipo[i].nombre;
				button.GetComponent<Button>().onClick.AddListener(
					() => (SetActive(index))
					);
				button.transform.SetParent(this.transform,false);
			}
		}
		GameObject btnHuir = (GameObject)Instantiate(buttonPrefab);
		btnHuir.GetComponentInChildren<Text>().text = "HUIR";
		btnHuir.GetComponent<Button>().onClick.AddListener(
			() => (SetActive(-1))
			);
		btnHuir.transform.SetParent(this.transform,false);
		
	}
	
	void OnDisable(){
		//borrar botones
		int childs;
		childs = transform.childCount;
		for(int i = childs -1; i >= 0; i--){
			Destroy(transform.GetChild(i).gameObject);
		}
	}
	
	public void SetActive(int i){
		if(i == -1){
			trainer.clicks=accionesEntrenador.Huir;
		}else{
			trainer.nroMovimiento = i;
			trainer.clicks=accionesEntrenador.CambioListo;
		}		
	}
}
