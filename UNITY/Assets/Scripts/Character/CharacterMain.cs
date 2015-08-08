using UnityEngine;
using System.Collections;

public class CharacterMain : MonoBehaviour {

	public Direction dir = Direction.down;
	public string charName = "PEPE";
	public Color hairTint;
	public Color hatTint;
	
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
	
	public IEnumerator Wait(int i){
		moveGui.StopMove();
		yield return new WaitForSeconds(i);
		moveGui.EnableMove();
	}
	
	private void Cargar(){
		LoadPos();
		Colorear();
	}
	private void Colorear(){
		int i;
		TintColor[] colores = GetComponentsInChildren<TintColor>(true);
		if(!LoadColor()){
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
		}
	}
	void SavePos(){
		PlayerPrefs.SetFloat("positionX",transform.position.x);
		PlayerPrefs.SetFloat("positionY",transform.position.y);
		PlayerPrefs.Save();
	}
	void SavePos2(Vector2 v){
		PlayerPrefs.SetFloat("positionX",v.x);
		PlayerPrefs.SetFloat("positionY",v.y);
		PlayerPrefs.Save();
	}
	void LoadPos(){
			if (PlayerPrefs.HasKey ("positionX")) {
				transform.position = new Vector3 (PlayerPrefs.GetFloat ("positionX"), PlayerPrefs.GetFloat ("positionY"), 0);
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
			return true;
		}else{
			return false;
		}
	}
}

public enum Direction{
	down,
	left,
	up,
	right,
	none
};
