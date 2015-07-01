using UnityEngine;
using System.Collections;

public class CharacterMain : MonoBehaviour {
	
	public Direction dir = Direction.down;
	//public bool canMove = true;
	public string charName = "default";
	public Color hairTint;
	public Color hatTint;
	// move "graphical user interface", gets the movement from screen interaction
	protected MoveGUI moveGui;
	
	void Start(){
		int i;
		moveGui = GameObject.Find("MoveGUIGO").GetComponent<MoveGUI>();
		Input.simulateMouseWithTouches = true;
		
		TintColor[] colores = GetComponentsInChildren<TintColor>(true);
		
		hairTint.a=1;
		hairTint.b=Random.Range(0.0f,1.0f);
		hairTint.r=Random.Range(0.0f,1.0f);
		hairTint.g=Random.Range(0.0f,1.0f);
		hatTint.a=1;
		hatTint.b=Random.Range(0.0f,1.0f);
		hatTint.r=Random.Range(0.0f,1.0f);
		hatTint.g=Random.Range(0.0f,1.0f);
		
		Debug.Log(colores.Length);
		for(i=0;i<colores.Length;i++){
			if(colores[i].name.StartsWith("Hair")){
				colores[i].ChangeColor(hairTint);
			}
			if(colores[i].name.StartsWith("Hat")){
				colores[i].ChangeColor(hatTint);
			}
		}
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
}

public enum Direction{
	down,
	left,
	up,
	right,
	none
};
