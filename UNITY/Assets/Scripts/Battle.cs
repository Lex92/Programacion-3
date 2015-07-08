using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public enum Stage{
	/*	en inicio/fin aplicar daños de veneno/etc, revisar si alguno esta muerto	*/
	inicio, elegir, entrenador, atq1, atq2, atq3, resultado, victoria, derrota
}

public class Battle : MonoBehaviour {

	protected int battleStage;
	protected bool waiting = false;
	protected GameObject actionPanel;
	public Accion act1; //protected
	public Accion act2; //protected
	
	public Monstruo userMon, opoMon;
	// Use this for initialization
	void Start () {
		battleStage = (int)Stage.elegir;
		//act1.stg = act2.stg = Stage.elegir;
		actionPanel = GameObject.Find("ActionPanel");
		act1 = Accion.CreateAccion("Elegir");
		act2 = Accion.CreateAccion("Elegir");
		
		//antes cargar datos desde save
		userMon = Monstruo.CreateMonster("Bulbamon","bulba",10);
		opoMon = Monstruo.CreateMonster("Batmon","bati",20);
		
		string[] ataquesbulba = userMon.GetMov(10);
		Debug.Log("cantidad ataques bulba a lv10: "+ataquesbulba.Length);
		int i = 0;
		for(i=0;i<ataquesbulba.Length;i++){
			Debug.Log("["+i+"] " + ataquesbulba[i]);
		}
		
		
		Debug.Log(opoMon.imgDir);
		GameObject.Find("OponentIm").GetComponent<Image>().sprite = Resources.Load(opoMon.imgDir, typeof(Sprite)) as Sprite;
		GameObject.Find("UserIm").GetComponent<Image>().sprite = Resources.Load(userMon.imgDir, typeof(Sprite)) as Sprite;
		userMon.ImprimirStats();
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
	}
	
	IEnumerator Wait(){
		Debug.Log(Time.time);
		yield return new WaitForSeconds(1);
		Debug.Log(Time.time);
		battleStage++;
		waiting = false;
	}
}
