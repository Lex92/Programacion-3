using UnityEngine;
using System.Collections;
using Mono.Data.Sqlite;

public class dbConection : MonoBehaviour {
	private SqliteConnection _conexion;
	private SqliteCommand _command;
	private SqliteDataReader _reader;


	private string _query;

	public void OpenDB(string _dbName){
		_conexion = new SqliteConnection (_dbName);
		_conexion.Open ();
	}

	public void SelectData(){
		_query = "Select * From continar where name='PEPE'";
		_command = _conexion.CreateCommand ();
		_command.CommandText = _query;
		_reader = _command.ExecuteReader ();

		if(_reader != null){
			while(_reader.Read()){
				print(_reader.GetValue(1).ToString() + " - " + _reader.GetValue(2).ToString() );
				PlayerPrefs.SetFloat("positionX",float.Parse(_reader.GetValue(1).ToString()));
				PlayerPrefs.SetFloat("positionY",float.Parse(_reader.GetValue(2).ToString()));

			}
		}
	}

	public void InsertData(string posx,string posy){
		_query = "INSERT INTO continar VALUES('PEPE','"+posx+"','"+ posy +"')";
		_command = _conexion.CreateCommand ();
		_command.CommandText = _query;
		_command.ExecuteReader ();
	}

	public void UpdateData(string posx, string posy){
		_query = "UPDATE continar SET posicionX='"+posx+"',posicionY='"+posy+"' where name='PEPE'" ;
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

}
