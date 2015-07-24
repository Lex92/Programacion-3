using UnityEngine;
using System.Collections;
using System.IO;


public class sqlScript {
	private string URIDataBase = "";
	
	private string databaseName = "PositionPlayer";
	
	private dbConection _connector;

	private dbConection conectarDB(){
		_connector = new dbConection ();
		string folderPath;
		
		if(Application.platform == RuntimePlatform.Android){
			folderPath = Application.persistentDataPath+"/DB";
			//URIDataBase = Application.persistentDataPath + "/" + databaseName;
		}else{
			folderPath = "Assets/DB";
		}
		URIDataBase = folderPath + "/" + databaseName;
		Debug.Log (URIDataBase);
		if(!File.Exists(URIDataBase)){
			System.IO.Directory.CreateDirectory(folderPath);
			Debug.Log("2");
			string path = "jar:file://"+folderPath+"!/assets/"+databaseName;
			WWW loadDB = new WWW(path);
			while(!loadDB.isDone){
			}
			Debug.Log("3");
			Debug.Log(URIDataBase);
			File.WriteAllBytes(URIDataBase,loadDB.bytes);
			_connector.OpenDB("URI=file:"+URIDataBase);
			Debug.Log("crear tabla");
			_connector.CrearTabla("continar");
			_connector.InsertData("Sc01","0","0");
		}else{
			_connector.OpenDB("URI=file:"+URIDataBase);
		}
		return _connector;
	}

	public void cargarPartida(){
		_connector = conectarDB ();
		_connector.SelectData ();
		_connector.CloseDB ();
		Application.LoadLevel(PlayerPrefs.GetString("Scene"));
		PlayerPrefs.DeleteKey("Scene");	
	}

	public void updatePosition(string scene,string posx,string posy){
		_connector = conectarDB ();
		_connector.UpdateData (scene,posx,posy);
		_connector.SelectData ();
		_connector.CloseDB ();
	}
}
