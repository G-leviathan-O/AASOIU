using Homework3.DataBase;

namespace Homework3
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            using (var context = new AppDbContext())
            {
                context.Database.EnsureCreated();

                if (!context.Countries.Any())
                {
                    DbInitializer.SeedData(context);
                }
            }

            Application.Run(new MainForm());
        }
    }
}
