using UnityEngine;
using System.Collections;

public static class Log {


	private static string texto = "Bienvenido";
	private static int maxLength = 512;
	public static void AddLine(string line){
		texto=line+"\n"+texto;
		if(texto.Length>maxLength){
			texto = texto.Substring(0,maxLength);
		}
	}
	
	public static string GetText(){
		return texto;
	}
}
