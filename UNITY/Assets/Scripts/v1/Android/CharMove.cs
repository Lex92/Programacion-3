using UnityEngine;
using System.Collections;

public class CharMove : MonoBehaviour {

	public enum dir : int{
		abajo,
		izquierda,
		arriba,
		derecha,
		ninguna
	};


	public float originalSpeed = 10f;
	public float smooth = 1.5f;
	public bool isRunning = false;
	public bool isInteracting = false;
	public float runSpeed = 1.5f;
	public dir direction = dir.abajo;
	public bool canMove = true;
	public bool inBattle = false;
	protected Animator animator;
	
	void Start(){
		animator = GetComponent<Animator>();
	}
	

	/*	tiempo para volver a "interactuar"	*/
	public int waitTime = 10;
	private int interactTime = 0;
	/**/
	
	void FixedUpdate(){
		//interacciones
		if(interactTime>=0)
			interactTime--;
		else if(isInteracting){
			Interact();
			interactTime = waitTime;
			isInteracting = false;
		}	
	}
	void Update(){
		//movimiento
		if(canMove){
			Move();
		}else
			//Hace que la animacion no se este moviendo
			Mover(dir.ninguna);
			
		if(inBattle){
			text.GetComponent<GUIText>().text =("BATTLE");
			inBattle = false;
		}
	}
	
	/*	PARA DEBUG	*/
	private int cantidadCol = 0;
	void OnCollisionEnter2D(Collision2D col){
		text.GetComponent<GUIText>().text = (++cantidadCol).ToString();
	}
	/*	Poner sonidos por cada choque	*/
	/**/
	
	
	/*	ini => coordenadas donde inicia el toque	*/
	/*	pointer => toque actual - toque inicial	*/
	private Vector2 ini = new Vector2(0,0);
	private Vector2 pointer = new Vector2(0,0);
	
	private int touchID = -1;
	private void Move(){
		bool moved = false;
		
		if(touchID <0){
			foreach(Touch t in Input.touches){
				if(t.phase == TouchPhase.Began && t.position.x < Screen.width*0.6f && t.position.y < Screen.height*0.6f){
					touchID = t.fingerId;
				}
			}
		}
		if(touchID >= 0){
			Touch touch = Input.GetTouch(touchID);
			if(touch.phase == TouchPhase.Began){
				ini = touch.position;
			}
			pointer = touch.position-ini;
			if(touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled){
				pointer = Vector2.zero;
				touchID = -1;
			}
		}
		/*	Muestra "JoyStick" del jugador	*/
		ShowMovement(ini,pointer);
		
		//mover solo en cruz
		if(Mathf.Abs(pointer.x) < Mathf.Abs(pointer.y)){
			if(pointer.y < -smooth){
				Mover (dir.abajo);
				moved = true;
			}
			if(pointer.y > smooth){
				Mover (dir.arriba);
				moved = true;
			}
		}else{
			if(pointer.x < -smooth){
				Mover (dir.izquierda);
				moved = true;
			}
			if(pointer.x > smooth){
				Mover (dir.derecha);
				moved = true;
			}
		}
		if(!moved){
			Mover (dir.ninguna);
		}
	}
	
	/*	Mueve y maneja las animaciones */
	public void Mover(dir direcciones){
		float speed = originalSpeed;
		if(isRunning){
			speed = speed*runSpeed;
		}
		if(direcciones != dir.ninguna)
			direction = direcciones;
		switch((int)direcciones){
		case (int)dir.ninguna:
			animator.SetBool("IsMoving",false);
		break;
		case (int)dir.abajo:
			transform.Translate(-Vector2.up*Time.deltaTime*speed);
			animator.SetBool("IsMoving",true);
			animator.SetInteger("Direction",(int)direcciones);
		break;
		case (int)dir.izquierda:
			transform.Translate(-Vector2.right*Time.deltaTime*speed);
			animator.SetBool("IsMoving",true);
			animator.SetInteger("Direction",(int)direcciones);
		break;
		case (int)dir.arriba:
			transform.Translate(Vector2.up*Time.deltaTime*speed);
			animator.SetBool("IsMoving",true);
			animator.SetInteger("Direction",(int)direcciones);
		break;
		case (int)dir.derecha: 
			transform.Translate(Vector2.right*Time.deltaTime*speed);
			animator.SetBool("IsMoving",true);
			animator.SetInteger("Direction",(int)direcciones);
		break;
		}
	}
	
	/* PARA DEBUG */
	public GUIText text;
	/**/
	
	public void Interact(){
		text.GetComponent<GUIText>().text = "recieve pressed";
		float range = (GetComponent<BoxCollider2D>().size.y)*2f;
		Vector2 direcciones = -Vector2.up;
		switch(direction){/*
		case dir.abajo: direcciones = -Vector2.up;
		break;*/
		case dir.izquierda: direcciones = -Vector2.right;
		break;
		case dir.arriba: direcciones = Vector2.up;
		break;
		case dir.derecha: direcciones = Vector2.right;
		break;
		}
		/*	enmascara la capa "Interactive" para ser la unica buscada	*/
		LayerMask mask = 1<<LayerMask.NameToLayer("Interactive");
		RaycastHit2D hit = Physics2D.Raycast(transform.position,direcciones,range,mask);
		/* PARA DEBUG: dibuja la linea proyectada por el raycast	*/
		Debug.DrawLine(transform.position,new Vector3 (transform.position.x + direcciones.x * range, transform.position.y + direcciones.y*range),Color.red,1.0f);
		if(hit.collider != null){
			/* PARA DEBUG	*/
			text.GetComponent<GUIText>().text = hit.collider.gameObject.name;
			hit.collider.SendMessage("Interact", direcciones,SendMessageOptions.DontRequireReceiver);
		}
	}
	
	public void EnterBattle(){
		inBattle = true;
	}
	/*	Muestra "JoyStick" del jugador	*/
	public GameObject iniTexture;
	public GameObject movedTexture;
	private void ShowMovement(Vector2 ini, Vector2 moved){
		float smooth = 1f;
		moved += ini;
		if(Vector2.Distance(ini,moved) > smooth){
			iniTexture.SetActive(true);
			movedTexture.SetActive(true);
			iniTexture.transform.position = new Vector2(ini.x/Screen.width,ini.y/Screen.height);
			movedTexture.transform.position = new Vector2(moved.x/Screen.width,moved.y/Screen.height);
		}else{
			iniTexture.SetActive(false);
			movedTexture.SetActive(false);
		}
	}
}