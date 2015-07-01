using UnityEngine;
using System.Collections;

public class MonsterEncounter : MonoBehaviour {

	private int stepsTaken = 0;
	private Vector2 lastPosition;
	private CharMove charMove;
	public int rate = 90;
	public float smoothMove = 2.0f;
	
	void OnTriggerStay2D(Collider2D col){
		int encounter;
		int maxSteps = 20;
		Vector2 position;
		if(col.CompareTag("Player")){
			position = col.transform.position;
			if(charMove != null && Moved(lastPosition,position,smoothMove)){
				lastPosition = position;
				encounter = stepsTaken + Random.Range(0,100);
				if(stepsTaken < maxSteps)
					stepsTaken++;
				if(encounter > rate){
					stepsTaken = 0;
					charMove.EnterBattle();
				}
			}
		}
	}
		
	void OnTriggerEnter2D(Collider2D col){
		if(col.CompareTag("Player")){
			stepsTaken++;
			lastPosition = col.transform.position;
			charMove = col.GetComponent<CharMove>();
		}
	}
	void OnTriggerExit2D(Collider2D col){
		if(col.CompareTag("Player"))
			stepsTaken = 0;
	}
	
	private bool Moved(Vector2 pos1, Vector2 pos2, float smooth){
		if(Vector2.Distance(pos1,pos2) > smooth){
			return true;
		}
		return false;
	}
}
