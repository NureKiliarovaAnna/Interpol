using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interpol.Forms
{
    public partial class EditCriminalForm : Form
    {
        private string _personId;
        private string _crimeId;

        public EditCriminalForm(string personId, string crimeId)
        {
            InitializeComponent();
            _personId = personId;
            _crimeId = crimeId;
        }

        private void LoadCriminalInfo()
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\ХНУРЕ\База даних\Interpol\Interpol\Interpol.accdb;";
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                try
                {
                    // Запит для інформації про злочинця
                    string query = "SELECT person.first_name, person.last_name, person.birth_date, " +
                        "person.birth_location, person.gender, person.last_known_residence, " +
                        "person.nationality, person.status, person.passport, person.photo, " +
                        "person.email_addr, person.phone_num, criminal.criminal_nickname, " +
                        "criminal.criminal_distinctive_features, criminal.article_of_accusation " +
                        "FROM person INNER JOIN criminal ON person.person_id = criminal.person_id " +
                        "WHERE person.person_id = @PersonId";

                    OleDbCommand command = new OleDbCommand(query, connection);
                    command.Parameters.AddWithValue("@PersonId", _personId);

                    connection.Open();
                    OleDbDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        txtFirstName.Text = reader["first_name"].ToString();
                        txtLastName.Text = reader["last_name"].ToString();
                        txtBirthDate.Text = reader["birth_date"].ToString();
                        txtGender.Text = reader["gender"].ToString();
                        txtBirthLocation.Text = reader["birth_location"].ToString();
                        txtResidence.Text = reader["last_known_residence"].ToString();
                        txtNationality.Text = reader["nationality"].ToString();
                        txtStatus.Text = reader["status"].ToString();
                        txtPassport.Text = reader["passport"].ToString();
                        txtEmail.Text = reader["email_addr"].ToString();
                        txtPhone.Text = reader["phone_num"].ToString();
                        txtNickname.Text = reader["criminal_nickname"].ToString();
                        txtDistinctiveFeatures.Text = reader["criminal_distinctive_features"].ToString();
                        txtArticle.Text = reader["article_of_accusation"].ToString();

                        if (reader["photo"] != DBNull.Value)
                        {
                            string photoPath = reader["photo"].ToString();
                            pbPhoto.Image = Image.FromFile(photoPath);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка завантаження інформації про злочинця: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        private void LoadCrimeInfo()
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\ХНУРЕ\База даних\Interpol\Interpol\Interpol.accdb;";
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                try
                {
                    // Запит для злочину
                    string query = "SELECT criminal_crime.crime_date, criminal_crime.criminal_degree_participation, " +
                        "crime.crime_type, crime.crime_location, crime.crime_method, crime.investigations_status " +
                        "FROM criminal_crime INNER JOIN crime ON criminal_crime.crime_id = crime.crime_id " +
                        "WHERE criminal_crime.crime_id = @CrimeId";

                    OleDbCommand command = new OleDbCommand(query, connection);
                    command.Parameters.AddWithValue("@CriminalId", _crimeId);

                    connection.Open();
                    OleDbDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        // Заповнення текстових полів
                        txtCrimeDate.Text = reader["crime_date"].ToString();
                        txtCrimeType.Text = reader["crime_type"].ToString();
                        txtCrimeLocation.Text = reader["crime_location"].ToString();
                        txtCrimeMethod.Text = reader["crime_method"].ToString();
                        txtDegreeParticipation.Text = reader["criminal_degree_participation"].ToString();
                        txtInvestigationStatus.Text = reader["investigations_status"].ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка завантаження інформації про злочин: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        private void btnChoosePhoto_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                openFileDialog.Title = "Оберіть фото";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string sourcePath = openFileDialog.FileName;
                    string destinationPath = Path.Combine(Application.StartupPath, @"Sources\Images\", Path.GetFileName(sourcePath));

                    // Копіюємо файл до папки Images
                    try
                    {
                        File.Copy(sourcePath, destinationPath, true);
                        txtPhotoPath.Text = Path.Combine(@"Sources\Images\", Path.GetFileName(sourcePath));
                        pbPhoto.Image = Image.FromFile(destinationPath); // Відображення фото
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Помилка копіювання файлу: " + ex.Message);
                    }
                }
            }
        }

        private void EditCriminalForm_Load(object sender, EventArgs e)
        {
            LoadCriminalInfo();
            LoadCrimeInfo();
        }
    }
}
