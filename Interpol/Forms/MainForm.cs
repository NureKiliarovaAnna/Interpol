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
            cmbCrimeType.Items.AddRange(new string[] { "Кримінальний", "Економічний", "Терористичний" });
            cmbEvidenceType.Items.AddRange(new string[] { "Фото", "Відео", "Відбитки пальців", "Документ" });
            cmbGender.Items.AddRange(new string[] { "Чоловіча", "Жіноча" });
        }

        private void LoadDataToGrid()
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\ХНУРЕ\База даних\Interpol\Interpol\Interpol.accdb;";
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                string query = "SELECT * FROM QueryCriminals"; // Назва вашого запиту в Access
                OleDbCommand command = new OleDbCommand(query, connection);
                OleDbDataAdapter adapter = new OleDbDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dgvCriminals.DataSource = dataTable;
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
            txtWantedCountry.Text = "";
            txtCaseNumber.Text = "";
            cmbEvidenceType.SelectedIndex = -1;
        }

        private void dgvCriminals_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Перевірка, чи рядок є валідним
            if (e.RowIndex >= 0)
            {
                // Отримання ID злочинця або іншого ключового поля
                string criminalId = dgvCriminals.Rows[e.RowIndex].Cells["criminal_id"].Value.ToString();

                // Відкриття нової форми та передача ID
                CriminalDetailsForm criminalForm = new CriminalDetailsForm(criminalId);
                criminalForm.ShowDialog();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\ХНУРЕ\База даних\Interpol\Interpol\Interpol.accdb;";
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                // Базовий запит
                string query = "SELECT * FROM QueryCriminals WHERE 1=1";

                // Список параметрів
                List<OleDbParameter> parameters = new List<OleDbParameter>();

                // Додавання умов для кожного поля
                if (!string.IsNullOrWhiteSpace(txtFirstName.Text))
                {
                    query += " AND first_name = @FirstName";
                    parameters.Add(new OleDbParameter("@FirstName", txtFirstName.Text));
                }

                if (!string.IsNullOrWhiteSpace(txtLastName.Text))
                {
                    query += " AND last_name = @LastName";
                    parameters.Add(new OleDbParameter("@LastName", txtLastName.Text));
                }

                if (!string.IsNullOrWhiteSpace(txtNickname.Text))
                {
                    query += " AND criminal_nickname = @Nickname";
                    parameters.Add(new OleDbParameter("@Nickname", txtNickname.Text));
                }

                if (cmbGender.SelectedIndex >= 0)
                {
                    query += " AND gender = @Gender";
                    parameters.Add(new OleDbParameter("@Gender", cmbGender.SelectedItem.ToString()));
                }

                if (!string.IsNullOrWhiteSpace(txtResidence.Text))
                {
                    query += " AND last_known_residence = @Residence";
                    parameters.Add(new OleDbParameter("@Residence", txtResidence.Text));
                }

                if (!string.IsNullOrWhiteSpace(txtNationality.Text))
                {
                    query += " AND nationality = @Nationality";
                    parameters.Add(new OleDbParameter("@Nationality", txtNationality.Text));
                }

                if (cmbCrimeType.SelectedIndex >= 0)
                {
                    query += " AND crime_type = @CrimeType";
                    parameters.Add(new OleDbParameter("@CrimeType", cmbCrimeType.SelectedItem.ToString()));
                }

                if (!string.IsNullOrWhiteSpace(txtCrimeLocation.Text))
                {
                    query += " AND crime_location = @CrimeLocation";
                    parameters.Add(new OleDbParameter("@CrimeLocation", txtCrimeLocation.Text));
                }

                if (!string.IsNullOrWhiteSpace(txtWantedCountry.Text))
                {
                    query += " AND wanted_country = @WantedCountry";
                    parameters.Add(new OleDbParameter("@WantedCountry", txtWantedCountry.Text));
                }

                if (!string.IsNullOrWhiteSpace(txtCaseNumber.Text))
                {
                    query += " AND case_number = @CaseNumber";
                    parameters.Add(new OleDbParameter("@CaseNumber", txtCaseNumber.Text));
                }

                if (cmbEvidenceType.SelectedIndex >= 0)
                {
                    query += " AND evidence_type = @EvidenceType";
                    parameters.Add(new OleDbParameter("@EvidenceType", cmbEvidenceType.SelectedItem.ToString()));
                }

                if (dtpBirthDate.Checked)
                {
                    query += " AND birth_date = @BirthDate";
                    parameters.Add(new OleDbParameter("@BirthDate", dtpBirthDate.Value.Date));
                }

                if (dtpCrimeDate.Checked)
                {
                    query += " AND crime_date = @CrimeDate";
                    parameters.Add(new OleDbParameter("@CrimeDate", dtpCrimeDate.Value.Date));
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
    }
}