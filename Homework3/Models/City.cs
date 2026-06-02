namespace Homework3.Models
{
    /// <summary>
    /// Город
    /// </summary>
    public class City
    {
        /// <summary>
        /// ID города
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// ID страны
        /// </summary>
        public int CountryId { get; set; }

        /// <summary>
        /// Название города
        /// </summary>
        public string Name { get; set; } = string.Empty;

        private int _population;

        /// <summary>
        /// Население в тысячах
        /// </summary>
        public int PopulationK
        {
            get => _population;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Population cannot be negative");

                _population = value;
            }
        }

        /// <summary>
        /// Страна
        /// </summary>
        public Country? Country { get; set; }

        public City(int id, int countryId, string name, int populationK)
        {
            Id = id;
            CountryId = countryId;
            Name = name;
            PopulationK = populationK;
        }

        public City() : this(0, 0, "", 0) { }
    }
}
