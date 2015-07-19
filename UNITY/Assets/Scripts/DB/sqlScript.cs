using UnityEngine;
using System.Collections;


public class sqlScript : MonoBehaviour {
	public string URIDataBase;
	
	public dbConection _connector;

	public dbConection conectarDB(){
		_connector = new dbConection ();
		_connector.OpenDB ("URI=file:C:\\Users\\Luk\\Documents\\Unlu\\Programacion 3\\Proyecto\\Repositorio\\trunk\\UNITY\\Assets\\DB\\DB");
		return _connector;
	}

	public void cargarPartida(){
		_connector = conectarDB ();
		_connector.SelectData ();
		_connector.CloseDB ();
		Application.LoadLevel("Sc01");		
	}

	public void updatePosition(string posx,string posy){
		_connector = conectarDB ();
		_connector.UpdateData (posx,posy);
		_connector.SelectData ();
		_connector.CloseDB ();
	}
}
