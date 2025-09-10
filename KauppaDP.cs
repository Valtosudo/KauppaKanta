namespace KauppaKanta;

using Microsoft.Data.Sqlite;

public class KauppaDP
{
    private String _connectionString = "Data Source=kauppa.db";

    public KauppaDP()
    {
        //Luodaan Yhteys tietokantaan
        using (var connection = new SqliteConnection(_connectionString));
        {
            connection.Open();
            //Luodaan Taulut, jos niitä ei vielä ole
            //Yksikertainen tietokanta, jossa on yksi taulu
            //Taulu tuotteet sarakkeet id, nimi, hinta
            var commandForTableCreation = connection.CreateCommand();
            commandForTableCreation.CommandText = "CREATE TABLE IF NOT EXISTS tuotteet (id INTEGER PRIMARY KEY, nimi TEXT, hinta REAL)";
            commandForTableCreation.ExecuteNonQuery();
            //connection.Close();
        }
    }

    public void LisaaTuote(string nimi, double hinta)
    {
        //Luodaan Yhteys tietokantaan
        var connection = new SqliteConnection(_connectionString);
        connection.Open();
        //Lisätään tuote tietokantaan
        var commandForInsert = connection.CreateCommand();
        commandForInsert.CommandText = "INSERT INTO tuotteet (nimi, hinta) VALUES (@nimi, @hinta)";
        commandForInsert.Parameters.AddWithValue(@"nimi", nimi);
        commandForInsert.Parameters.AddWithValue(@"hinta", hinta);
        commandForInsert.ExecuteNonQuery();
        connection.Close();
    }

    public string HaeTuotteet(string nimi)
    {
        //Luodaan yhteys tietokantaan
        var connection = new SqliteConnection(_connectionString);
        connection.Open();
        var commandForSelect = connection.CreateCommand();
        commandForSelect.CommandText = "SELECT * FROM tuotteet WHERE nimi LIKE @Nimi";
        commandForSelect.Parameters.AddWithValue("Nimi", nimi);
        var reader = commandForSelect.ExecuteReader();
        string tuotteet = "";
        while (reader.Read())
        {
            tuotteet += $"id: {reader.GetInt32(0)}, nimi: {reader.GetString(1)}, Hinta: {reader.GetDouble(2)}\n";
        }
        reader.Close();
        connection.Close();

        if (tuotteet == "")
        {
            return "Tuotetta ei löytynyt.";
        }
        else
        {
            return tuotteet;
        }
    }
}