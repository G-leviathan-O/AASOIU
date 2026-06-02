using Homework3.DataBase;
using Homework3.Models;
using Microsoft.EntityFrameworkCore;

namespace Homework3.Forms
{
    /// <summary>
    /// Форма работы с городами
    /// </summary>
    public partial class CitiesForm : Form
    {
        public CitiesForm()
        {
            InitializeComponent();
            LoadCountries();
            LoadCities();
        }

        private void LoadCountries()
        {
            using var context = new AppDbContext();

            comboBoxCountry.DataSource = context.Countries
                .OrderBy(c => c.Name)
                .ToList();

            comboBoxCountry.DisplayMember = "Name";
            comboBoxCountry.ValueMember = "Id";
        }

        private void LoadCities()
        {
            using var context = new AppDbContext();

            var cities = context.Cities
                .Include(c => c.Country)
                .OrderBy(c => c.Name)
                .Select(c => new
                {
                    c.Id,
                    c.Name,
                    Country = c.Country!.Name,
                    c.PopulationK
                })
                .ToList();

            dataGridView1.DataSource = cities;

            dataGridView1.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxName.Text))
            {
                MessageBox.Show("Введите название города");
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxPopulation.Text))
            {
                MessageBox.Show("Введите население");
                return;
            }

            if (!int.TryParse(textBoxPopulation.Text, out int population))
            {
                MessageBox.Show("Население должно быть числом");
                return;
            }

            if (population < 0)
            {
                MessageBox.Show("Население не может быть отрицательным");
                return;
            }

            if (comboBoxCountry.SelectedItem == null)
            {
                MessageBox.Show("Выберите страну");
                return;
            }

            using var context = new AppDbContext();

            var city = new City
            {
                Name = textBoxName.Text.Trim(),
                PopulationK = population,
                CountryId = (int)comboBoxCountry.SelectedValue
            };

            context.Cities.Add(city);
            context.SaveChanges();

            MessageBox.Show("Город добавлен");

            textBoxName.Clear();
            textBoxPopulation.Clear();
            LoadCities();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBoxId.Text, out int cityId))
            {
                MessageBox.Show("Введите ID города");
                return;
            }

            using var context = new AppDbContext();

            var city = context.Cities.Find(cityId);

            if (city == null)
            {
                MessageBox.Show("Введите существующий Id");
                return;
            }

            var result = MessageBox.Show(
                $"Удалить город \"{city.Name}\"?",
                "Подтверждение",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            context.Cities.Remove(city);

            context.SaveChanges();

            MessageBox.Show("Город удалён");

            textBoxId.Clear();
            LoadCities();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBoxId.Text, out int cityId))
            {
                MessageBox.Show("Введите ID города");
                return;
            }

            using var context = new AppDbContext();

            var city = context.Cities.Find(cityId);

            if (city == null)
            {
                MessageBox.Show("Введите существующий Id");
                return;
            }
            if (!string.IsNullOrWhiteSpace(textBoxName.Text))
            {
                city.Name = textBoxName.Text.Trim();
            }

            if (!string.IsNullOrWhiteSpace(textBoxPopulation.Text))
            {
                if (!int.TryParse(textBoxPopulation.Text, out int population))
                {
                    MessageBox.Show("Население должно быть числом");
                    return;
                }

                if (population < 0)
                {
                    MessageBox.Show("Население не может быть отрицательным");
                    return;
                }

                city.PopulationK = population;
            }

            if (comboBoxCountry.SelectedItem != null)
            {
                city.CountryId = (int)comboBoxCountry.SelectedValue;
            }

            context.SaveChanges();

            MessageBox.Show("Город изменён");

            textBoxId.Clear();
            textBoxName.Clear();
            textBoxPopulation.Clear();
            LoadCities();
        }
    }
}
