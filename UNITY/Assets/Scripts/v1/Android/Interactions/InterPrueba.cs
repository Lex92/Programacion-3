using UnityEngine;
using System.Collections;

public class InterPrueba : InteractScript {

	protected override int Interaction(int num){
		switch(++num){
		case 1: Texto("Hola, soy el profesor Oak");
		break;
		case 2: Texto("Oak porque mis padres querian que sea un roble\nen realidad soy un pino");
		break;
		case 3:	Texto("Odio a mis padres por ponerme ese nombre,\nasi que ahora en mi tiempo libre atraigo\nniños para que vean mis pokemon");
		break;
		default: return 0;
		}
		return num;
	}
}
