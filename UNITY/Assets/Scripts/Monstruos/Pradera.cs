using UnityEngine;
using System.Collections;

public class Pradera : Habitat {
	public Pradera(int lMin, int lMax){
		Nombre = "Pradera";
		lvMin = lMin;
		lvMax = lMax;
		posibles = new string[] {"Bulbamon","Venomon"};
	}
}
