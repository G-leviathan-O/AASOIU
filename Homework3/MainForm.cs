using Homework3.DataBase;

namespace Homework3
{
    /// <summary>
    /// Основная форма
    /// </summary>
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonCountries_Click(object sender, EventArgs e)
        {
            new Forms.CountriesForm().ShowDialog();
        }

        private void buttonCities_Click(object sender, EventArgs e)
        {
            new Forms.CitiesForm().ShowDialog();
        }

        private void buttonReports_Click(object sender, EventArgs e)
        {
            new Forms.ReportsForm().ShowDialog();
        }

        private void buttonResetDatabase_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "Удалить базу данных и создать заново?",
                "Подтверждение",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
                return;

            using var context = new AppDbContext();

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            DbInitializer.SeedData(context);

            MessageBox.Show("База данных успешно пересоздана.");
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
