using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Data.Sqlite;

class DatabaseManager
{
    private string _connectionString;

    public DatabaseManager(string dbPath)
    {
        _connectionString = $"Data Source={dbPath}";
    }

    // ───── INIT ─────

    public void InitializeDatabase(string countryCsv, string cityCsv)
    {
        CreateTables();

        if (GetAllCountries().Count == 0)
            ImportCountries(countryCsv);

        if (GetAllCities().Count == 0)
            ImportCities(cityCsv);
    }

    private void CreateTables()
    {
        using (var conn = new SqliteConnection(_connectionString))
        {
            conn.Open();

            var cmd = conn.CreateCommand();
            cmd.CommandText =
            @"
            CREATE TABLE IF NOT EXISTS country (
                country_id INTEGER PRIMARY KEY,
                country_name TEXT NOT NULL
            );

            CREATE TABLE IF NOT EXISTS city (
                city_id INTEGER PRIMARY KEY,
                country_id INTEGER NOT NULL,
                city_name TEXT NOT NULL,
                population_k INTEGER NOT NULL
            );";

            cmd.ExecuteNonQuery();
        }
    }

    // ───── IMPORT CSV ─────

    private void ImportCountries(string path)
    {
        using (var conn = new SqliteConnection(_connectionString))
        {
            conn.Open();

            foreach (var line in File.ReadAllLines(path))
            {
                if (line.StartsWith("country_id")) continue;

                var p = line.Split(';');

                var cmd = conn.CreateCommand();
                cmd.CommandText =
                @"INSERT INTO country VALUES (@id, @name)";

                cmd.Parameters.AddWithValue("@id", int.Parse(p[0]));
                cmd.Parameters.AddWithValue("@name", p[1]);
                cmd.ExecuteNonQuery();
            }
        }
    }

    private void ImportCities(string path)
    {
        using (var conn = new SqliteConnection(_connectionString))
        {
            conn.Open();

            foreach (var line in File.ReadAllLines(path))
            {
                if (line.StartsWith("city_id")) continue;

                var p = line.Split(';');

                var cmd = conn.CreateCommand();
                cmd.CommandText =
                @"INSERT INTO city VALUES (@id, @cid, @name, @pop)";

                cmd.Parameters.AddWithValue("@id", int.Parse(p[0]));
                cmd.Parameters.AddWithValue("@cid", int.Parse(p[1]));
                cmd.Parameters.AddWithValue("@name", p[2]);
                cmd.Parameters.AddWithValue("@pop", int.Parse(p[3]));

                cmd.ExecuteNonQuery();
            }
        }
    }

    // ───── READ ─────

    public List<Country> GetAllCountries()
    {
        List<Country> list = new List<Country>();

        using (var conn = new SqliteConnection(_connectionString))
        {
            conn.Open();

            var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM country";

            var r = cmd.ExecuteReader();

            while (r.Read())
            {
                list.Add(new Country(
                    r.GetInt32(0),
                    r.GetString(1)
                ));
            }
        }

        return list;
    }

    public List<City> GetAllCities()
    {
        List<City> list = new List<City>();

        using (var conn = new SqliteConnection(_connectionString))
        {
            conn.Open();

            var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM city";

            var r = cmd.ExecuteReader();

            while (r.Read())
            {
                list.Add(new City(
                    r.GetInt32(0),
                    r.GetInt32(1),
                    r.GetString(2),
                    r.GetInt32(3)
                ));
            }
        }

        return list;
    }

    // ───── CRUD ─────

    public void AddCity(City c)
    {
        using (var conn = new SqliteConnection(_connectionString))
        {
            conn.Open();

            var cmd = conn.CreateCommand();
            cmd.CommandText =
            @"
            INSERT INTO city (country_id, city_name, population_k)
            VALUES (@cid, @name, @pop)";

            cmd.Parameters.AddWithValue("@cid", c.CountryId);
            cmd.Parameters.AddWithValue("@name", c.Name);
            cmd.Parameters.AddWithValue("@pop", c.PopulationK);

            cmd.ExecuteNonQuery();
        }
    }

    public void DeleteCity(int id)
    {
        using (var conn = new SqliteConnection(_connectionString))
        {
            conn.Open();

            var cmd = conn.CreateCommand();
            cmd.CommandText = "DELETE FROM city WHERE city_id=@id";
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
        }
    }

    // ───── REPORT EXEC ─────

    public (string[] cols, List<string[]> rows) ExecuteQuery(string sql)
    {
        List<string[]> rows = new List<string[]>();
        string[] cols;

        using (var conn = new SqliteConnection(_connectionString))
        {
            conn.Open();

            var cmd = conn.CreateCommand();
            cmd.CommandText = sql;

            var r = cmd.ExecuteReader();

            cols = new string[r.FieldCount];

            for (int i = 0; i < r.FieldCount; i++)
                cols[i] = r.GetName(i);

            while (r.Read())
            {
                string[] row = new string[r.FieldCount];

                for (int i = 0; i < r.FieldCount; i++)
                    row[i] = r.GetValue(i).ToString();

                rows.Add(row);
            }
        }

        return (cols, rows);
    }
}