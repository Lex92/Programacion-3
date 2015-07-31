using UnityEngine;
using System.Collections;
using System.IO;


public class sqlScript {
	private string URIDataBase = "";
	private string databaseName = "BaseDatos";
	private dbConection _connector;
	private string tablaPosicion="continar";
	private string tablaMonstruos="tablaMonstruos";

	private dbConection conectarDB(){
		_connector = new dbConection ();
		string folderPath;
		
		if(Application.platform == RuntimePlatform.Android){
			folderPath = Application.persistentDataPath+"/DB";
		}else{
			folderPath = "Assets/DB";
		}
		URIDataBase = folderPath + "/" + databaseName;
		if(!File.Exists(URIDataBase)){
			System.IO.Directory.CreateDirectory(folderPath);
			string path = "jar:file://"+folderPath+"!/assets/"+databaseName;
			WWW loadDB = new WWW(path);
			while(!loadDB.isDone){
			}
			File.WriteAllBytes(URIDataBase,loadDB.bytes);
			_connector.OpenDB("URI=file:"+URIDataBase);
			_connector.CrearTabla(tablaPosicion);
			_connector.CrearTablaMonstruos(tablaMonstruos);
			_connector.InsertData("Sc01","0","0");
		}else{
			_connector.OpenDB("URI=file:"+URIDataBase);
		}
		return _connector;
	}

	public void cargarPartida(){
		_connector = conectarDB ();
		_connector.SelectData ();
		_connector.SelectMonsterTable();
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
	
	public void updateMonsters(){
		_connector = conectarDB();
		_connector.InsertMonsters();
		_connector.SelectMonsterTable();
		_connector.CloseDB();
	}
	public void DeleteMonsters(){
		_connector = conectarDB();
		_connector.DeleteMonsters();
		_connector.SelectData ();
		_connector.CloseDB();
	}
}
