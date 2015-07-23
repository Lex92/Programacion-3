using UnityEngine;
using System.Collections;
using System.IO;


public class sqlScript : MonoBehaviour {
	public string URIDataBase = "";
	
	public string databaseName = "";
	
	public dbConection _connector;

	public dbConection conectarDB(){
		_connector = new dbConection ();
		databaseName = "DBase";
		
		if(Application.platform == RuntimePlatform.Android){
			Debug.Log("1");
			URIDataBase =Application.persistentDataPath + "/" + databaseName;
			Debug.Log (URIDataBase);
		}else{
			Debug.Log("2");
			URIDataBase = "Assets/"+databaseName;
		}
		if(!File.Exists(URIDataBase)){
			Debug.Log("3");
			string path = "jar:file://"+Application.dataPath+"!/assets/"+databaseName;
			WWW loadDB = new WWW(path);
			while(!loadDB.isDone){
			}
			Debug.Log("4");
			Debug.Log(URIDataBase);
			File.WriteAllBytes(URIDataBase,loadDB.bytes);
			_connector.OpenDB("URI=file:"+URIDataBase);
			Debug.Log("crear tabla");
			_connector.CrearTabla("continar");
			_connector.InsertData("0","0");
		}else{
			Debug.Log("5");
			_connector.OpenDB("URI=file:"+URIDataBase);
			Debug.Log ("URIDataBase: "+URIDataBase);
		}
		Debug.Log("6");
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
