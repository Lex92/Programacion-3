using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CualquierPanel : MonoBehaviour {
	
	[SerializeField] GameObject buttonPrefab;
	protected string[] nombres;
	
	
	void OnEnable(){
		nombres = new string[]{"ejemplo1","ejemplo2"}; //inicializar nombres cargando de base de datos o lo que sea
		for(int i=0;i<nombres.Length;i++){
			if(nombres[i] != null/* no nulo, o lo que sea */){
				int index = i;
				GameObject button = (GameObject)Instantiate(buttonPrefab);
				button.GetComponentInChildren<Text>().text = "LOAD "+nombres[i];
				button.GetComponent<Button>().onClick.AddListener(
					() => (Load(index))
					);
				button.transform.SetParent(this.transform,false);
			}
		}
		GameObject btnNueva = (GameObject)Instantiate(buttonPrefab);
		btnNueva.GetComponentInChildren<Text>().text = "Nueva partida";
		btnNueva.GetComponent<Button>().onClick.AddListener(
			() => (Load(-1))
			);
		btnNueva.transform.SetParent(this.transform,false);
		
	}
	
	void OnDisable(){
		//borrar botones
		int childs;
		childs = transform.childCount;
		for(int i = childs -1; i >= 0; i--){
			Destroy(transform.GetChild(i).gameObject);
		}
	}
	
	public void Load(int i){
		if(i == -1){
			//nueva partida
		}else{
			//cargar nombres[i]
		}		
	}
}
