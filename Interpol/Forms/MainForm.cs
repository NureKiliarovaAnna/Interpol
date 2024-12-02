using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
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
            MessageBox.Show("Форма завантажена успішно!");
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            cmbCrimeType.Items.AddRange(new string[] { "Кримінальний", "Економічний", "Терористичний" });
            cmbEvidenceType.Items.AddRange(new string[] { "Фото", "Відео", "Відбитки пальців", "Документ" });
            cmbGender.Items.AddRange(new string[] { "Чоловіча", "Жіноча" });
        }

        private void btnClearFilters_Click(object sender, EventArgs e)
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            numAgeFrom.Value = 0;
            numAgeTo.Value = 0;
            cmbGender.SelectedIndex = -1;
            txtResidence.Text = "";
            txtNationality.Text = "";
            cmbCrimeType.SelectedIndex = -1;
            dtpCrimeDateFrom.Value = DateTime.Now;
            dtpCrimeDateTo.Value = DateTime.Now;
            txtCrimeLocation.Text = "";
            txtWantedCountry.Text = "";
            txtCaseNumber.Text = "";
            cmbEvidenceType.SelectedIndex = -1;
            txtEvidenceStorage.Text = "";
        }

        private void SearchCriminals(string firstName, string lastName, int? ageFrom, int? ageTo,
                             string gender, string residence, string nationality,
                             string crimeType, DateTime? crimeDateFrom, DateTime? crimeDateTo,
                             string crimeLocation, string wantedCountry,
                             string caseNumber, string evidenceType, string evidenceStorage)
        {
            using (var connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\Interpol.accdb;Persist Security Info=True"))
            {
                connection.Open();

                // Створення SQL-запиту
                var query = new StringBuilder("SELECT * FROM Criminals INNER JOIN Persons ON Criminals.person_id = Persons.person_id WHERE 1=1");

                // Додаємо умови для фільтрів
                if (!string.IsNullOrEmpty(firstName))
                    query.Append(" AND Persons.first_name LIKE @FirstName");
                if (!string.IsNullOrEmpty(lastName))
                    query.Append(" AND Persons.last_name LIKE @LastName");
                if (ageFrom.HasValue)
                    query.Append(" AND DATEDIFF('yyyy', Persons.birth_date, Date()) >= @AgeFrom");
                if (ageTo.HasValue)
                    query.Append(" AND DATEDIFF('yyyy', Persons.birth_date, Date()) <= @AgeTo");
                if (!string.IsNullOrEmpty(gender))
                    query.Append(" AND Persons.gender = @Gender");
                if (!string.IsNullOrEmpty(residence))
                    query.Append(" AND Persons.last_known_residence LIKE @Residence");
                if (!string.IsNullOrEmpty(nationality))
                    query.Append(" AND Persons.nationality LIKE @Nationality");
                if (!string.IsNullOrEmpty(crimeType))
                    query.Append(" AND Criminals.crime_type LIKE @CrimeType");
                if (crimeDateFrom.HasValue)
                    query.Append(" AND Criminals.crime_date >= @CrimeDateFrom");
                if (crimeDateTo.HasValue)
                    query.Append(" AND Criminals.crime_date <= @CrimeDateTo");
                if (!string.IsNullOrEmpty(crimeLocation))
                    query.Append(" AND Criminals.crime_location LIKE @CrimeLocation");
                if (!string.IsNullOrEmpty(wantedCountry))
                    query.Append(" AND Wanted_status.status_country LIKE @WantedCountry");
                if (!string.IsNullOrEmpty(caseNumber))
                    query.Append(" AND Court_case.case_number LIKE @CaseNumber");
                if (!string.IsNullOrEmpty(evidenceType))
                    query.Append(" AND Evidence.evidence_type LIKE @EvidenceType");
                if (!string.IsNullOrEmpty(evidenceStorage))
                    query.Append(" AND Evidence.evidence_storage_location LIKE @EvidenceStorage");

                using (var command = new OleDbCommand(query.ToString(), connection))
                {
                    // Додаємо параметри до запиту
                    if (!string.IsNullOrEmpty(firstName))
                        command.Parameters.AddWithValue("@FirstName", $"%{firstName}%");
                    if (!string.IsNullOrEmpty(lastName))
                        command.Parameters.AddWithValue("@LastName", $"%{lastName}%");
                    if (ageFrom.HasValue)
                        command.Parameters.AddWithValue("@AgeFrom", ageFrom.Value);
                    if (ageTo.HasValue)
                        command.Parameters.AddWithValue("@AgeTo", ageTo.Value);
                    if (!string.IsNullOrEmpty(gender))
                        command.Parameters.AddWithValue("@Gender", gender);
                    if (!string.IsNullOrEmpty(residence))
                        command.Parameters.AddWithValue("@Residence", $"%{residence}%");
                    if (!string.IsNullOrEmpty(nationality))
                        command.Parameters.AddWithValue("@Nationality", $"%{nationality}%");
                    if (!string.IsNullOrEmpty(crimeType))
                        command.Parameters.AddWithValue("@CrimeType", $"%{crimeType}%");
                    if (crimeDateFrom.HasValue)
                        command.Parameters.AddWithValue("@CrimeDateFrom", crimeDateFrom.Value);
                    if (crimeDateTo.HasValue)
                        command.Parameters.AddWithValue("@CrimeDateTo", crimeDateTo.Value);
                    if (!string.IsNullOrEmpty(crimeLocation))
                        command.Parameters.AddWithValue("@CrimeLocation", $"%{crimeLocation}%");
                    if (!string.IsNullOrEmpty(wantedCountry))
                        command.Parameters.AddWithValue("@WantedCountry", $"%{wantedCountry}%");
                    if (!string.IsNullOrEmpty(caseNumber))
                        command.Parameters.AddWithValue("@CaseNumber", $"%{caseNumber}%");
                    if (!string.IsNullOrEmpty(evidenceType))
                        command.Parameters.AddWithValue("@EvidenceType", $"%{evidenceType}%");
                    if (!string.IsNullOrEmpty(evidenceStorage))
                        command.Parameters.AddWithValue("@EvidenceStorage", $"%{evidenceStorage}%");

                    // Виконання запиту
                    var adapter = new OleDbDataAdapter(command);
                    var dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Відображення результатів у DataGridView
                    dgvCriminals.DataSource = dataTable;
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchCriminals(
                txtFirstName.Text,
                txtLastName.Text,
                numAgeFrom.Value > 0 ? (int?)numAgeFrom.Value : null,
                numAgeTo.Value > 0 ? (int?)numAgeTo.Value : null,
                cmbGender.SelectedItem?.ToString(),
                txtResidence.Text,
                txtNationality.Text,
                cmbCrimeType.SelectedItem?.ToString(),
                dtpCrimeDateFrom.Checked ? (DateTime?)dtpCrimeDateFrom.Value : null,
                dtpCrimeDateTo.Checked ? (DateTime?)dtpCrimeDateTo.Value : null,
                txtCrimeLocation.Text,
                txtWantedCountry.Text,
                txtCaseNumber.Text,
                cmbEvidenceType.SelectedItem?.ToString(),
                txtEvidenceStorage.Text
            );
        }
    }
}