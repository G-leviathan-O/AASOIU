namespace Homework3.Models
{
    /// <summary>
    /// Страна
    /// </summary>
    public class Country
    {
        /// <summary>
        /// ID страны
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название страны
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Города страны
        /// </summary>
        public ICollection<City> Cities { get; set; } = new List<City>();

        public Country(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public Country() : this(0, "") { }
    }
}
