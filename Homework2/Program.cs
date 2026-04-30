using System.Text;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        var db = new DatabaseManager("data.db");
        db.InitializeDatabase("countries.csv", "cities.csv");

        while (true)
        {
            Console.WriteLine("\n1 Countries\n2 Cities\n3 Add\n4 Edit\n5 Delete\n6 Reports\n0 Exit");
            var choice = Console.ReadLine();

            if (choice == "0")
                break;

            if (choice == "1")
            {
                db.GetAllCountries().ForEach(x => Console.WriteLine(x));
            }

            if (choice == "2")
            {
                db.GetAllCities().ForEach(x => Console.WriteLine(x));
            }

            if (choice == "3")
            {
                Console.WriteLine("Countries:");
                db.GetAllCountries().ForEach(x => Console.WriteLine(x));

                Console.Write("CountryId: ");
                if (!int.TryParse(Console.ReadLine(), out int cid)) return;

                Console.Write("Name: ");
                string name = Console.ReadLine();

                Console.Write("Population (K): ");
                if (!int.TryParse(Console.ReadLine(), out int pop)) return;

                db.AddCity(new City(0, cid, name, pop));
            }

            if (choice == "4")
            {
                Console.WriteLine("Cities:");
                db.GetAllCities().ForEach(x => Console.WriteLine(x));

                Console.Write("Id: ");
                if (!int.TryParse(Console.ReadLine(), out int id)) return;

                var c = db.GetCityById(id);

                Console.Write($"Name ({c.Name}): ");
                var n = Console.ReadLine();
                if (!string.IsNullOrEmpty(n)) c.Name = n;

                Console.Write($"Pop ({c.PopulationK}): ");
                if (int.TryParse(Console.ReadLine(), out int p)) c.PopulationK = p;

                db.UpdateCity(c);
            }

            if (choice == "5")
            {
                Console.WriteLine("Cities:");
                db.GetAllCities().ForEach(x => Console.WriteLine(x));

                Console.Write("Id: ");
                if (int.TryParse(Console.ReadLine(), out int id))
                    db.DeleteCity(id);
            }

            if (choice == "6")
            {
                new ReportBuilder(db)
                    .Query(@"SELECT city_name, country_name, population_k
                             FROM city
                             JOIN country ON city.country_id = country.country_id
                             ORDER BY city_name")
                    .Title("Cities")
                    .Print();

                // 2 COUNT
                new ReportBuilder(db)
                    .Query(@"SELECT country_name, COUNT(*)
                        FROM city
                        JOIN country ON city.country_id = country.country_id
                        GROUP BY country_name")
                    .Title("Count")
                    .Print();

                // 3 AVG + SaveToFile (требование группы)
                new ReportBuilder(db)
                    .Query(@"SELECT country_name, AVG(population_k)
                        FROM city
                        JOIN country ON city.country_id = country.country_id
                        GROUP BY country_name
                        ORDER BY AVG(population_k) DESC")
                    .Title("Average")
                    .SaveToFile("report.txt");
            }
        }
    }
}