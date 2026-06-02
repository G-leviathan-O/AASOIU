using Homework3.Models;
using Microsoft.EntityFrameworkCore;

namespace Homework3.DataBase
{
    /// <summary>
    /// Контекст базы данных
    /// </summary>
    public class AppDbContext : DbContext
    {
        /// <summary>
        /// Таблица стран
        /// </summary>
        public DbSet<Country> Countries { get; set; }

        /// <summary>
        /// Таблица городов
        /// </summary>
        public DbSet<City> Cities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=app.db");
        }
    }
}
