using System;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        DatabaseManager db = new DatabaseManager("data.db");

        db.InitializeDatabase("countries.csv", "cities.csv");

        while (true)
        {
            Console.WriteLine("\n1. Countries");
            Console.WriteLine("2. Cities");
            Console.WriteLine("3. Add city");
            Console.WriteLine("4. Report");
            Console.WriteLine("0. Exit");

            string choice = Console.ReadLine();

            if (choice == "0")
                break;

            if (choice == "1")
            {
                var countries = db.GetAllCountries();
                foreach (var c in countries)
                    Console.WriteLine(c);
            }

            if (choice == "2")
            {
                var cities = db.GetAllCities();
                foreach (var c in cities)
                    Console.WriteLine(c);
            }

            if (choice == "3")
            {
                Console.Write("CountryId: ");
                int cid = int.Parse(Console.ReadLine());

                Console.Write("Name: ");
                string name = Console.ReadLine();

                Console.Write("PopulationK: ");
                int pop = int.Parse(Console.ReadLine());

                db.AddCity(new City(0, cid, name, pop));
            }

            if (choice == "4")
            {
                new ReportBuilder(db)
                    .Query(@"
                        SELECT city_name, country_name, population_k
                        FROM city
                    ")
                    .Title("Cities Report")
                    .Header("City", "Country", "Population")
                    .ColumnWidths(20, 20, 15)
                    .Numbered()
                    .Print();
            }
        }
    }
}