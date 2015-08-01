using UnityEngine;
using System.Collections;
using Mono.Data.Sqlite;

public class dbConection {
	private SqliteConnection _conexion;
	private SqliteCommand _command;
	private SqliteDataReader _reader;


	private string _query;

	public void OpenDB(string _dbName){
		_conexion = new SqliteConnection (_dbName);
		_conexion.Open ();
	}

	public void SelectData(){
		_query = "Select * From continar where name='PEPE'";//continar?
		_command = _conexion.CreateCommand ();
		_command.CommandText = _query;
		_reader = _command.ExecuteReader ();

		if(_reader != null){
			while(_reader.Read()){
				PlayerPrefs.SetString("Scene",_reader.GetValue(1).ToString());
				PlayerPrefs.SetFloat("positionX",float.Parse(_reader.GetValue(2).ToString()));
				PlayerPrefs.SetFloat("positionY",float.Parse(_reader.GetValue(3).ToString()));

			}
		}
	}
	
	//pasa todos los monstruos de la bd a playerprefs
	public void SelectMonsterTable(){
		_query = "Select * From tablaMonstruos where owner='PEPE'";
		_command = _conexion.CreateCommand ();
		_command.CommandText = _query;
		_reader = _command.ExecuteReader ();
		Monstruo temp;
		if(_reader != null){
			while(_reader.Read()){
				temp = Monstruo.CreateMonster(_reader.GetValue(1).ToString(),_reader.GetValue(0).ToString(),int.Parse(_reader.GetValue(2).ToString()),new Stats(_reader.GetValue(3).ToString()),new Estado(_reader.GetValue(4).ToString()));
				SaveMonster.AddMonster(temp,false);
			}
		}
	}
	
	public void DeleteMonsters(){
		_query = "DELETE FROM tablaMonstruos WHERE owner='PEPE'";
		_command = _conexion.CreateCommand ();
		_command.CommandText = _query;
		_command.ExecuteReader ();
	}
	
	public void InsertMonsters(){
		string[] nombres = SaveMonster.GetMonsterList();
		Monstruo temp;

		if (PlayerPrefs.GetString ("botonPresionado") == "new") {
			DeleteMonsters();
		}


		for(int i = 0;i < nombres.Length;++i){
			temp = SaveMonster.LoadMonster(nombres[i]);
			_query="SELECT * FROM tablaMonstruos WHERE owner='PEPE' and name='"+temp.nombre+"'";
			_command = _conexion.CreateCommand ();
			_command.CommandText = _query;
			_reader = _command.ExecuteReader ();
			int cont=0;
			if(_reader != null){
				while(_reader.Read()){
					cont++;
				}
				if(cont!=0){
					_query= "UPDATE tablaMonstruos set specie='"+temp.especie+"',exp='"+temp.exp.ToString()+"',modStats='"+temp.modStats.ToString()+"',estado='"+temp.estado.ToString()+"' WHERE owner='PEPE' and name='"+temp.nombre+"'";
				}else{
					_query = "INSERT INTO tablaMonstruos VALUES('"+temp.nombre+"','"+temp.especie+"','"+temp.exp.ToString()+"','"+temp.modStats.ToString()+"','"+temp.estado.ToString()+"','PEPE')";
				}
				
			}
			_command = _conexion.CreateCommand();
			_command.CommandText = _query;
			_command.ExecuteReader();
		}
	}
	
	public void CrearTabla(string tabla){
		_query = "CREATE TABLE "+tabla+"(name CHAR(20) NOT NULL, scene CHAR(20), posicionX CHAR (20), posicionY CHAR(20));";
		_command = _conexion.CreateCommand();
		_command.CommandText = _query;
		_command.ExecuteReader();
	}
	
	public void InsertData(string scene, string posx,string posy){
		_query = "INSERT INTO continar VALUES('PEPE','"+scene+"','"+posx+"','"+ posy +"')";//continar?
		_command = _conexion.CreateCommand ();
		_command.CommandText = _query;
		_command.ExecuteReader ();
	}

	public void UpdateData(string scene,string posx, string posy){
		_query = "UPDATE continar SET scene='"+scene+"',posicionX='"+posx+"',posicionY='"+posy+"' where name='PEPE'" ;//continar?
		_command = _conexion.CreateCommand ();
		_command.CommandText = _query;
		_command.ExecuteReader ();
	}

	public void CloseDB(){
		_reader.Close ();
		_reader = null;
		_command = null;
		_conexion.Close ();
		_conexion = null;

	}
	
	public void CrearTablaMonstruos(string tabla){
		_query = "CREATE TABLE "+tabla+" (name CHAR(20), specie CHAR(20), exp CHAR(40), modstats CHAR(100), estado CHAR(100), owner CHAR(20));";
		_command = _conexion.CreateCommand();
		_command.CommandText = _query;
		_command.ExecuteReader();
	}
}
