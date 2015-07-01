using UnityEngine;
using System.Collections;

public class IO : MonoBehaviour {
	
	
	void SaveChar(GameObject c){
		Debug.Log(c.name);
	}
	
	public void LoadScene(string sceneName){
		Debug.Log(sceneName);
		Application.LoadLevel(sceneName);
		Debug.Log(sceneName);
		Debug.Log("sigue ejecutando instrucciones luego de cargar el nivel");
	}
}
