using Homework3.DataBase;
using Microsoft.EntityFrameworkCore;

namespace Homework3.Forms
{
    /// <summary>
    /// Форма работы с отчётами
    /// </summary>
    public partial class ReportsForm : Form
    {
        public ReportsForm()
        {
            InitializeComponent();
            LoadReports();
        }

        private void LoadReports()
        {
            using var context = new AppDbContext();

            var report1 = context.Cities
                .Include(c => c.Country)
                .OrderBy(c => c.Name)
                .Select(c => new
                {
                    c.Name,
                    Country = c.Country!.Name,
                    c.PopulationK
                })
                .ToList();

            dataGridView1.DataSource = report1;

            var report2 = context.Cities
                .GroupBy(c => c.Country!.Name)
                .Select(g => new
                {
                    Country = g.Key,
                    Count = g.Count()
                })
                .OrderBy(g => g.Country)
                .ToList();

            dataGridView2.DataSource = report2;

            var report3 = context.Cities
                .GroupBy(c => c.Country!.Name)
                .Select(g => new
                {
                    Country = g.Key,
                    AveragePopulation = g.Average(c => c.PopulationK)
                })
                .OrderByDescending(g => g.AveragePopulation)
                .ToList();

            dataGridView3.DataSource = report3;


            dataGridView1.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.AllCells;

            dataGridView2.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.AllCells;

            dataGridView3.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.AllCells;
        }
    }
}
