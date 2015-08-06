using UnityEngine;
using System.Collections;

public class menuMonstruos : MonoBehaviour {

	private float size;
	
	void Start(){
		size = Screen.width/20;
	}

	void OnGUI(){
		GUI.depth = 0;
		if (GUI.Button(new Rect(size-52,size+170,size+30,size-30), "Monstruos")){

			string[] nombres = SaveMonster.GetMonsterList();
			Monstruo temp;
			
			for(int i = 0;i < nombres.Length;++i){
				temp = SaveMonster.LoadMonster(nombres[i]);
				Debug.Log("ADDDDD "+temp.nombre+" "+temp.especie);


			}
			PlayerPrefs.SetFloat("positionX",transform.position.x);
			PlayerPrefs.SetFloat("positionY",transform.position.y);
			PlayerPrefs.Save();
			Application.LoadLevel("menuMounstros");
		
		}
	
	
	}
}
