using Homework3.DataBase;
using Homework3.Models;
using Microsoft.EntityFrameworkCore;

namespace Homework3.Forms
{
    /// <summary>
    /// Форма работы со странами
    /// </summary>
    public partial class CountriesForm : Form
    {
        public CountriesForm()
        {
            InitializeComponent();
            LoadCountries();
        }

        private void LoadCountries()
        {
            using var context = new AppDbContext();

            dataGridView1.DataSource = context.Countries
                .Select(c => new
                {
                    c.Id,
                    c.Name,
                    Cities = string.Join(", ",
                        c.Cities.Select(x => x.Name))
                })
                .ToList();
            dataGridView1.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxName.Text))
            {
                MessageBox.Show("Введите название страны");
                return;
            }

            using var context = new AppDbContext();

            context.Countries.Add(new Country
            {
                Name = textBoxName.Text.Trim()
            });

            context.SaveChanges();
            LoadCountries();
            textBoxName.Clear();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBoxName.Text, out int id))
            {
                MessageBox.Show(
                    "Введите id для удаления страны",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            using var context = new AppDbContext();

            var country = context.Countries
                .Include(c => c.Cities)
                .FirstOrDefault(c => c.Id == id);

            if (country == null)
            {
                MessageBox.Show(
                    "Введите существующий id",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (country.Cities.Any())
            {
                MessageBox.Show(
                    "Нельзя удалить страну с городами",
                    "Удаление запрещено",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            var result = MessageBox.Show(
                $"Удалить страну \"{country.Name}\"?",
                "Подтверждение удаления",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            context.Countries.Remove(country);
            context.SaveChanges();

            MessageBox.Show(
                "Страна успешно удалена",
                "Успех",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            LoadCountries();

            textBoxName.Clear();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBoxId.Text, out int id))
            {
                MessageBox.Show("Введите ID страны");
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxName.Text))
            {
                MessageBox.Show("Введите новое название страны");
                return;
            }

            using var context = new AppDbContext();

            var country = context.Countries.Find(id);

            if (country == null)
            {
                MessageBox.Show("Введите существующий Id");
                return;
            }

            country.Name = textBoxName.Text.Trim();

            context.SaveChanges();

            MessageBox.Show("Страна изменена");

            LoadCountries();
        }
    }
}
