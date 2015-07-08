using UnityEngine;
using System.Collections;

public class MoveChar : MonoBehaviour {
	
	protected Animator anim;
	public float originalSpeed = 10f;
	public float runSpeed = 1.8f;
	
	
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	//moves and animates the character, given a direction
	public void Move(Direction dir, bool isRunning){
		float speed = originalSpeed;
		if(isRunning)
			speed = speed * runSpeed;
		switch(dir){
		case Direction.down:
			transform.Translate(-Vector2.up*speed*Time.deltaTime);
			break;
		case Direction.up:
			transform.Translate(Vector2.up*speed*Time.deltaTime);
			break;
		case Direction.left:
			transform.Translate(-Vector2.right*speed*Time.deltaTime);
			break;
		case Direction.right:
			transform.Translate(Vector2.right*speed*Time.deltaTime);
			break;
		case Direction.none:
			//if the direction is none, then the character didn't move
			anim.SetBool("IsMoving",false);
			//function returns before modifying once again "IsMoving" and "Direction"
			return;
		}
		// (int) dir gets the index of Direction variable (0=down, 1=left, 2=up, 3=right)
		anim.SetInteger("Direction",(int) dir);
		anim.SetBool("IsMoving",true);
	}
}
