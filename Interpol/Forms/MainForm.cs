using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace Interpol.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadDataToGrid();
        }

        private void LoadDataToGrid()
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\ХНУРЕ\База даних\Interpol\Interpol\Interpol.accdb;";
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                string query = "SELECT * FROM CriminalsFullQuery"; // Назва запиту в Access
                OleDbCommand command = new OleDbCommand(query, connection);
                OleDbDataAdapter adapter = new OleDbDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dgvCriminals.DataSource = dataTable;

                // Приховуємо непотрібні для користувача поля
                if (dgvCriminals.Columns["person_id"] != null)
                    dgvCriminals.Columns["person_id"].Visible = false;
                if (dgvCriminals.Columns["crime_id"] != null)
                    dgvCriminals.Columns["crime_id"].Visible = false;
                if (dgvCriminals.Columns["criminal_id"] != null)
                    dgvCriminals.Columns["criminal_id"].Visible = false;
                if (dgvCriminals.Columns["wanted_status_id"] != null)
                    dgvCriminals.Columns["wanted_status_id"].Visible = false;
                if (dgvCriminals.Columns["court_case_id"] != null)
                    dgvCriminals.Columns["court_case_id"].Visible = false;
            }
        }

        private void btnClearFilters_Click(object sender, EventArgs e)
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtNickname.Text = "";
            cmbGender.SelectedIndex = -1;
            txtResidence.Text = "";
            txtNationality.Text = "";
            cmbCrimeType.SelectedIndex = -1;
            txtCrimeLocation.Text = "";
            txtStatusCountry.Text = "";
            txtCaseNumber.Text = "";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\ХНУРЕ\База даних\Interpol\Interpol\Interpol.accdb;";
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                // Базовий запит
                string query = "SELECT * FROM CriminalsFullQuery WHERE 1=1";

                // Список параметрів
                List<OleDbParameter> parameters = new List<OleDbParameter>();

                // Додавання умов для фільтрації
                if (!string.IsNullOrWhiteSpace(txtFirstName.Text))
                {
                    query += " AND [Ім'я] = @FirstName";
                    parameters.Add(new OleDbParameter("@FirstName", txtFirstName.Text));
                }
                if (!string.IsNullOrWhiteSpace(txtLastName.Text))
                {
                    query += " AND [Прізвище] = @LastName";
                    parameters.Add(new OleDbParameter("@LastName", txtLastName.Text));
                }
                if (!string.IsNullOrWhiteSpace(txtNickname.Text))
                {
                    query += " AND [Псевдонім] = @Nickname"; // Приклад псевдоніма
                    parameters.Add(new OleDbParameter("@Nickname", txtNickname.Text));
                }
                if (cmbGender.SelectedIndex >= 0)
                {
                    query += " AND [Стать] = @Gender";
                    parameters.Add(new OleDbParameter("@Gender", cmbGender.SelectedItem.ToString()));
                }
                if (!string.IsNullOrWhiteSpace(txtResidence.Text))
                {
                    query += " AND [Місце проживання] = @Residence";
                    parameters.Add(new OleDbParameter("@Residence", txtResidence.Text));
                }
                if (!string.IsNullOrWhiteSpace(txtNationality.Text))
                {
                    query += " AND [Національність] = @Nationality";
                    parameters.Add(new OleDbParameter("@Nationality", txtNationality.Text));
                }
                if (cmbCrimeType.SelectedIndex >= 0)
                {
                    query += " AND [Тип злочину] = @CrimeType";
                    parameters.Add(new OleDbParameter("@CrimeType", cmbCrimeType.SelectedItem.ToString()));
                }
                if (!string.IsNullOrWhiteSpace(txtCrimeLocation.Text))
                {
                    query += " AND [Місце злочину] = @CrimeLocation";
                    parameters.Add(new OleDbParameter("@CrimeLocation", txtCrimeLocation.Text));
                }
                if (!string.IsNullOrWhiteSpace(txtStatusCountry.Text))
                {
                    query += " AND [Країна статусу] = @StatusCountry";
                    parameters.Add(new OleDbParameter("@StatusCountry", txtStatusCountry.Text));
                }
                if (!string.IsNullOrWhiteSpace(txtCaseNumber.Text))
                {
                    query += " AND [Номер справи] = @CaseNumber";
                    parameters.Add(new OleDbParameter("@CaseNumber", txtCaseNumber.Text));
                }
                if (dtpBirthDate.Checked)
                {
                    query += " AND [Дата народження] = @BirthDate";
                    parameters.Add(new OleDbParameter("@BirthDate", dtpBirthDate.Value.Date));
                }
                if (dtpCrimeDate.Checked)
                {
                    query += " AND [Дата злочину] = @CrimeDate";
                    parameters.Add(new OleDbParameter("@CrimeDate", dtpCrimeDate.Value.Date));
                }

                // Додавання сортування
                string sortByColumn = "";
                if (cmbSortBy.SelectedIndex >= 0)
                {
                    switch (cmbSortBy.SelectedItem.ToString())
                    {
                        case "Ім'я":
                            sortByColumn = "[Ім'я]";
                            break;
                        case "Прізвище":
                            sortByColumn = "[Прізвище]";
                            break;
                        case "Дата народження":
                            sortByColumn = "[Дата народження]";
                            break;
                        case "Дата злочину":
                            sortByColumn = "[Дата злочину]";
                            break;
                    }
                }

                if (!string.IsNullOrEmpty(sortByColumn))
                {
                    query += " ORDER BY " + sortByColumn;
                    if (cmbSortOrder.SelectedItem?.ToString() == "За спаданням")
                    {
                        query += " DESC";
                    }
                    else
                    {
                        query += " ASC";
                    }
                }

                // Виконання запиту
                OleDbCommand command = new OleDbCommand(query, connection);
                command.Parameters.AddRange(parameters.ToArray());
                OleDbDataAdapter adapter = new OleDbDataAdapter(command);
                DataTable dataTable = new DataTable();

                connection.Open();
                
                adapter.Fill(dataTable);
                connection.Close();

                // Оновлення DataGridView
                dgvCriminals.DataSource = dataTable;
            }
        }

        private void cmbSortBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnSearch_Click(sender, e); // Перезавантажуємо таблицю
        }

        private void cmbSortOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnSearch_Click(sender, e); // Перезавантажуємо таблицю
        }

        private void dgvCriminals_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string personId = dgvCriminals.Rows[e.RowIndex].Cells["person_id"].Value.ToString();
                string crimeId = dgvCriminals.Rows[e.RowIndex].Cells["crime_id"].Value.ToString();
                CriminalDetailsForm detailsForm = new CriminalDetailsForm(personId, crimeId);
                detailsForm.ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddCriminalForm addForm = new AddCriminalForm();
            addForm.ShowDialog();
        }

        private void criminalsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Statistics statistics = new Statistics(1);
            statistics.ShowDialog();
        }

        private void crimesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Statistics statistics = new Statistics(2);
            statistics.ShowDialog();
        }

        private void warrantToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Statistics statistics = new Statistics(3);
            statistics.ShowDialog();
        }

        private void courtCaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Statistics statistics = new Statistics(4);
            statistics.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void проПрограмуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Програму виконала студентка групи ПЗПІ-23-6 Кілярова А. П.");
        }

        private void label10_Click(object sender, EventArgs e)
        {
            // Запит на підтвердження виходу
            DialogResult result = MessageBox.Show(
                "Ви впевнені, що хочете вийти з акаунту?",
                "Підтвердження виходу",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            // Якщо користувач підтвердив вихід
            if (result == DialogResult.Yes)
            {
                // Відображаємо форму авторизації
                LoginForm loginForm = new LoginForm();
                this.Hide(); // Ховаємо головну форму
                loginForm.ShowDialog(); // Показуємо форму авторизації як модальне вікно
                this.Close(); // Закриваємо головну форму після завершення роботи форми авторизації
            }
        }

        private void label1_MouseEnter(object sender, EventArgs e)
        {
            // Змінюємо курсор при наведенні
            label1.Cursor = Cursors.Hand; // Використовуємо стандартний курсор "рука"
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            // Повертаємо стандартний курсор
            label1.Cursor = Cursors.Default;
        }
    }
}