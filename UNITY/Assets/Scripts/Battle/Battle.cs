using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public enum Stage{
	/*	en inicio/fin aplicar daños de veneno/etc, revisar si alguno esta muerto	*/
	inicio, elegir, entrenador, atq1, atq2, atq3, resultado, victoria, derrota
}

public class Battle : MonoBehaviour {

	//catchRate se carga en la escena, 0 para entrenadores, N para salvajes
	public int catchRate = 0;

	protected int battleStage,battleStageOp;
	protected bool waiting = false;
	protected GameObject actionPanel, atkPanel,chgPanel;
	protected Accion act1;
	protected Accion act2;
	public Monstruo userMon, opoMon;
	
	public ClaseJugador user = (ClaseJugador)Entrenador.CreateTrainer("ClaseJugador","pepe");
	private string opoN;
	public Entrenador oponent;
	
	[SerializeField] Slider userCauge;
	[SerializeField] Slider opoCauge;
	[SerializeField] Text userName;
	[SerializeField] Text opoName;
	
	void Start () {
		opoN = PlayerPrefs.GetString("Entrenador");
		oponent = (Entrenador)Entrenador.CreateTrainer(opoN,opoN);
		PlayerPrefs.DeleteKey("Entrenador");
		battleStageOp = battleStage = (int)Stage.elegir;
		actionPanel = GameObject.Find("ActionPanel");
		atkPanel = GameObject.Find("AtkPanel");
		chgPanel = GameObject.Find("ChgPanel");
		atkPanel.SetActive(false);
		chgPanel.SetActive(false);
		userMon = user.equipo[user.activo];
		opoMon = oponent.equipo[oponent.activo];
		act1 = user.accionEntrenador();
		act2 = Accion.CreateAccion("Elegir");
		
		GameObject.Find("OponentIm").GetComponent<Image>().sprite = Resources.Load(opoMon.imgDir, typeof(Sprite)) as Sprite;
		GameObject.Find("UserIm").GetComponent<Image>().sprite = Resources.Load(userMon.imgDir, typeof(Sprite)) as Sprite;
	}
	
	void Update () {
		if(userMon.estado.statActual.vida == 0){
			act1.stg = act2.stg = Stage.elegir;
			if( user.Change() < 0){
				battleStage = (int) Stage.derrota;
			}
		}
		if(opoMon.estado.statActual.vida == 0){
			userMon.AddExp(opoMon.exp);
			act1.stg = act2.stg = Stage.elegir;
			if( oponent.Change() < 0){
				battleStage = (int) Stage.victoria;
			}
		}
		if((battleStage == (int)Stage.resultado) || (battleStage == (int)Stage.derrota) || (battleStage == (int)Stage.victoria)){
			Debug.Log((Stage)battleStage);
			Salir(battleStage);
		}
		InitPanels();
		if(act1.stg == Stage.elegir){
			battleStage = (int)Stage.elegir;
			act1 = user.accionEntrenador();
		}
		if(userMon.estado.statActual.vida == 0){
			if( user.Change() < 0){
				battleStage = (int) Stage.resultado;
			}
		}
		if(act2.stg == Stage.elegir){
			battleStageOp = (int)Stage.elegir;
			act2 = oponent.accionEntrenador();
		}
		if(opoMon.estado.statActual.vida == 0){
		}
		if(act1.stg != Stage.elegir){
			if(battleStage == (int)act1.stg){
				act1.ac();
				act1.stg = Stage.elegir;
			}else{
				if(!waiting){
					waiting = true;	
					StartCoroutine(Wait(0));
				}
			}
		}
		if(act2.stg != Stage.elegir){
			if(battleStageOp == (int)act2.stg){
				act2.ac();
				act2.stg = Stage.elegir;
			}else{
				if(!waiting){
					waiting = true;	
					StartCoroutine(Wait(1));
				}
			}
		}
	}
	
	void OnGUI(){
		userCauge.maxValue = userMon.GetStats().vida;
		opoCauge.maxValue = opoMon.GetStats().vida;
		opoName.text = opoMon.nombre+" LV:"+opoMon.lv;
		userName.text = userMon.nombre+" LV:"+userMon.lv;
		if(userCauge.value > userMon.estado.statActual.vida)
			userCauge.value-=0.5f;
		if(userCauge.value < userMon.estado.statActual.vida)
			userCauge.value+=0.5f;
		if(opoCauge.value > opoMon.estado.statActual.vida)
			opoCauge.value-=0.5f;
		if(opoCauge.value < opoMon.estado.statActual.vida)
			opoCauge.value+=0.5f;
		
	}
	
	IEnumerator Wait(int i){
		float t;
		if(i==0){
			t = opoMon.estado.statActual.velocidad/userMon.estado.statActual.velocidad;
			if(t > 1f){
				t = 1f;
			}
			if(t < 0.5f){
				t = 0.5f;
			}
			yield return new WaitForSeconds(t);
			battleStage++;
		}else {
			t = userMon.estado.statActual.velocidad/opoMon.estado.statActual.velocidad;
			if(t > 1f){
				t = 1f;
			}
			if(t < 0.5f){
				t = 0.5f;
			}
			yield return new WaitForSeconds(t);
			battleStageOp++;
		}
		waiting = false;
	}
	
	private void InitPanels(){
		if(userMon != user.equipo[user.activo]){
			userMon = user.equipo[user.activo];
			act1.stg = Stage.elegir;
		}
		if(opoMon != oponent.equipo[oponent.activo]){
			opoMon = oponent.equipo[oponent.activo];
			act2.stg = Stage.elegir;
		}
		GameObject.Find("OponentIm").GetComponent<Image>().sprite = Resources.Load(opoMon.imgDir, typeof(Sprite)) as Sprite;
		GameObject.Find("UserIm").GetComponent<Image>().sprite = Resources.Load(userMon.imgDir, typeof(Sprite)) as Sprite;
		
		oponent.target = userMon;
		oponent.source = opoMon;
		if(user.menuActivo == menus.capa1){
			actionPanel.SetActive(true);
		}else{
			actionPanel.SetActive(false);
		}
		if(user.menuActivo == menus.capaAtaque){
			atkPanel.SetActive(true);
		}else{
			atkPanel.SetActive(false);
		}
		if(user.menuActivo == menus.capaCambio){
			chgPanel.SetActive(true);
		}else{
			chgPanel.SetActive(false);
		}
	}
	
	private void Salir(int res){
		string result = "?";
		switch(res){
			case (int)Stage.victoria:
				result = "Victoria";
			break;
			case (int)Stage.derrota:
				result = "Derrota";
			break;
		}
		PlayerPrefs.SetString("Result",result);
		Application.LoadLevel("battleResult");
	}
}
