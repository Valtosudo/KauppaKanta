namespace KauppaKanta;

using System.Runtime.InteropServices;
using Microsoft.Data.Sqlite;

public class KauppaDP
{
    private String _connectionString = "Data Source=kauppa.db";

    public KauppaDP()
    {
        //Luodaan Yhteys tietokantaan
        var connection = new SqliteConnection(_connectionString);
        connection.Open();
        //Luodaan Taulut, jos niitä ei vielä ole
        //Yksikertainen tietokanta, jossa on yksi taulu
        //Taulu tuotteet sarakkeet id, nimi, hinta
        var commandForTableCreation = connection.CreateCommand();
        commandForTableCreation.CommandText = "CREATE TABLE IF NOT EXISTS tuotteet (id INTEGER PRIMARY KEY, nimi TEXT, hinta REAL)";
        commandForTableCreation.ExecuteNonQuery();
        connection.Close();
    }
}