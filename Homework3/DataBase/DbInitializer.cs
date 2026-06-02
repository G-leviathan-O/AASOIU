using Homework3.Models;

namespace Homework3.DataBase
{
    /// <summary>
    /// Заполнение базы начальными данными
    /// </summary>
    internal class DbInitializer
    {
        /// <summary>
        /// Создаёт тестовые данные
        /// </summary>
        public static void SeedData(AppDbContext context)
        {
            if (context.Countries.Any())
                return;

            var countries = new List<Country>
            {
                new() { Name = "Germany" },
                new() { Name = "France" },
                new() { Name = "Japan" },
                new() { Name = "Canada" }
            };

            context.Countries.AddRange(countries);
            context.SaveChanges();

            var cities = new List<City>
            {
                new() { Name = "Berlin", CountryId = countries[0].Id, PopulationK = 3769 },
                new() { Name = "Hamburg", CountryId = countries[0].Id, PopulationK = 1841 },
                new() { Name = "Munich", CountryId = countries[0].Id, PopulationK = 1472 },

                new() { Name = "Paris", CountryId = countries[1].Id, PopulationK = 2161 },
                new() { Name = "Lyon", CountryId = countries[1].Id, PopulationK = 522 },
                new() { Name = "Marseille", CountryId = countries[1].Id, PopulationK = 870 },

                new() { Name = "Tokyo", CountryId = countries[2].Id, PopulationK = 13960 },
                new() { Name = "Osaka", CountryId = countries[2].Id, PopulationK = 2691 },
                new() { Name = "Kyoto", CountryId = countries[2].Id, PopulationK = 1475 },

                new() { Name = "Toronto", CountryId = countries[3].Id, PopulationK = 2930 },
                new() { Name = "Montreal", CountryId = countries[3].Id, PopulationK = 1760 },
                new() { Name = "Vancouver", CountryId = countries[3].Id, PopulationK = 675 }
            };

            context.Cities.AddRange(cities);
            context.SaveChanges();
        }
    }
}
