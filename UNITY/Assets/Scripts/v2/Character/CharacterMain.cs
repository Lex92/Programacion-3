using UnityEngine;
using System.Collections;

public class CharacterMain : MonoBehaviour {
	
	public Direction dir = Direction.down;
	public bool canMove = true;
	public string charName = "default";
	
	// move "graphical user interface", gets the movement from screen interaction
	protected MoveGUI moveGui;
	
	void Start(){
		moveGui = GameObject.Find("MoveGUIGO").GetComponent<MoveGUI>();
		Input.simulateMouseWithTouches = true;
	}
	void Update(){
		if(canMove){
			//gets movement and saves direction
			moveGui.GetMove(ref dir);
		}
	}
	
	public void Save(){
		Debug.Log(charName);
	}
	
	public void Load(string ID){
		charName = ID;
	}
}

public enum Direction{
	down,
	left,
	up,
	right,
	none
};
