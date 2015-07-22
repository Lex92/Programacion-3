using UnityEngine;
using System.Collections;
using System.IO;


public class sqlScript : MonoBehaviour {
	public string URIDataBase = "";
	
	public string databaseName = "DBase";
	
	public dbConection _connector;

	public dbConection conectarDB(){
		_connector = new dbConection ();
		
		
		if(Application.platform == RuntimePlatform.Android){
			Debug.Log("1");
			URIDataBase =Application.persistentDataPath + "/" + databaseName;
			Debug.Log (URIDataBase);
		}else{
			URIDataBase = "Assets/"+databaseName;
		}
		if(!File.Exists(URIDataBase)){
			Debug.Log("2");
			string path = "jar:file://"+Application.dataPath+"!/assets/"+databaseName;
			WWW loadDB = new WWW(path);
			while(!loadDB.isDone){
			}
			Debug.Log("3");
			Debug.Log(URIDataBase);
			File.WriteAllBytes(URIDataBase,loadDB.bytes);
			_connector.OpenDB("URI=file:"+URIDataBase);
			Debug.Log("crear tabla");
			_connector.CrearTabla("continar");
			_connector.InsertData("0","0");
		}else{
			_connector.OpenDB("URI=file:"+URIDataBase);
		}
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
