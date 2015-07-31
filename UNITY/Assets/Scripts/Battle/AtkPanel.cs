using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class AtkPanel : MonoBehaviour {

	
	[SerializeField] GameObject buttonPrefab;
	protected Battle battle;
	[SerializeField] GameObject[] paneles;
	
	void OnEnable(){
		battle = FindObjectOfType<Battle>();
		if(battle.userMon == null){
			return;
		}
		string[] moves = battle.userMon.GetMov();
		int i;
		for(i=0;i<moves.Length;i++){
			int index = i;
			GameObject button = (GameObject)Instantiate(buttonPrefab);
			button.GetComponentInChildren<Text>().text = moves[i];
			button.GetComponent<Button>().onClick.AddListener(
				() => (SetMove(index))
				);
			button.transform.SetParent(paneles[i%paneles.Length].transform,false);
		}
	}
	
	void OnDisable(){
	//borrar botones
		int childs;
		for(int i=0;i<paneles.Length;i++){
			childs = paneles[i].transform.childCount;
			for(int j = childs -1; j >= 0; j--){
				Destroy(paneles[i].transform.GetChild(j).gameObject);
			}
		}
	}
	public void SetMove(int i){
		battle.user.nroMovimiento = i;
		battle.user.source = battle.userMon;
		battle.user.target = battle.opoMon;
		battle.user.clicks = accionesEntrenador.AtaqueListo;
	}
}
