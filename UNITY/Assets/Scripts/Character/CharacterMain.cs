using UnityEngine;
using System.Collections;

public class CharacterMain : MonoBehaviour {

		/*	Separar funciones en otras clases. por ejemplo las save/load y las interacciones, Color(), etc	*/
	
	public Direction dir = Direction.down;
	public string charName = "default";
	public Color hairTint;
	public Color hatTint;
	
	public Monstruo[] team;
	// move "graphical user interface", gets the movement from screen interaction
	protected MoveGUI moveGui;
	
	void Start(){
		moveGui = GameObject.Find("MoveGUIGO").GetComponent<MoveGUI>();
		Input.simulateMouseWithTouches = true;
		Cargar();
	}
	void Update(){
		//gets movement and saves direction
		moveGui.GetMove(ref dir);
	}
	
	public void Save(){
		Debug.Log(charName);
	}
	
	public void Load(string ID){
		charName = ID;
	}
	public IEnumerator Print(string msj){
		Debug.Log(msj);
		moveGui.StopMove();
		Debug.Log(Time.time);
		yield return new WaitForSeconds(1);
		Debug.Log(Time.time);
		moveGui.EnableMove();
	}
	private void Cargar(){
	
		//team[0] = Monstruo.CreateMonster("Bulbamon","Bulbi",10);
	
		LoadPos();
		Colorear();
	}
	private void Colorear(){
		int i;
		TintColor[] colores = GetComponentsInChildren<TintColor>(true);
		if(!LoadColor()){
			Debug.Log("no loadcolor");
			hairTint.a=1;
			hairTint.b=Random.Range(0.0f,1.0f);
			hairTint.r=Random.Range(0.0f,1.0f);
			hairTint.g=Random.Range(0.0f,1.0f);
			hatTint.a=1;
			hatTint.b=Random.Range(0.0f,1.0f);
			hatTint.r=Random.Range(0.0f,1.0f);
			hatTint.g=Random.Range(0.0f,1.0f);
			SaveColor();
		}
		for(i=0;i<colores.Length;i++){
			if(colores[i].name.StartsWith("Hair")){
				colores[i].ChangeColor(hairTint);
			}
			if(colores[i].name.StartsWith("Hat")){
				colores[i].ChangeColor(hatTint);
			}
		}
	}
	
	public void Battle(){
		SavePos();
		Application.LoadLevel("battLoad");
	}
	
	void SaveColor(){
		if(!PlayerPrefs.HasKey("Tint")){
			PlayerPrefs.SetInt("Tint",0);
			PlayerPrefs.SetFloat("hairTint.b",hairTint.b);
			PlayerPrefs.SetFloat("hairTint.r",hairTint.r);
			PlayerPrefs.SetFloat("hairTint.g",hairTint.g);
			PlayerPrefs.SetFloat("hatTint.b",hatTint.b);
			PlayerPrefs.SetFloat("hatTint.r",hatTint.r);
			PlayerPrefs.SetFloat("hatTint.g",hatTint.g);
			PlayerPrefs.Save();
			Debug.Log("Se guardaron los colores de pelo");
		}
		Debug.Log(name);
		//PlayerPrefs.SetFloat("positionX",c.transform.position.x);
		//PlayerPrefs.SetFloat("positionY",c.transform.position.y);
	}
	void SavePos(){
		PlayerPrefs.DeleteKey("positionX");
		PlayerPrefs.DeleteKey("positionY");
		PlayerPrefs.SetFloat("positionX",transform.position.x);
		PlayerPrefs.SetFloat("positionY",transform.position.y);
		//PlayerPrefs.SetFloat("positionZ",pos.z);
		PlayerPrefs.Save();
	}
	void LoadPos(){
			if (PlayerPrefs.HasKey ("positionX")) {
				transform.position = new Vector3 (PlayerPrefs.GetFloat ("positionX"), PlayerPrefs.GetFloat ("positionY"), 0);
			} else {
				//transform.position = new Vector3(float.Parse("30"),float.Parse("30"),0);
				Debug.Log ("No hay posicion guardada");
			}
	}
	
	bool LoadColor(){
		if(PlayerPrefs.HasKey("Tint")){
			hairTint.a=1;
			hairTint.b=PlayerPrefs.GetFloat("hairTint.b");
			hairTint.r=PlayerPrefs.GetFloat("hairTint.r");
			hairTint.g=PlayerPrefs.GetFloat("hairTint.g");
			hatTint.a=1;
			hatTint.b=PlayerPrefs.GetFloat("hatTint.b");
			hatTint.r=PlayerPrefs.GetFloat("hatTint.r");
			hatTint.g=PlayerPrefs.GetFloat("hatTint.g");
			Debug.Log("Se cargaron los colores de pelo");
			return true;
		}else{
			return false;
		}
	}
	void OnApplicationQuit(){
		SavePos();
		PlayerPrefs.DeleteAll();
	}
}

public enum Direction{
	down,
	left,
	up,
	right,
	none
};
