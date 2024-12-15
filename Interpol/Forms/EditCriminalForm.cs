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
                    string query = @"
                        SELECT 
                            person.first_name, 
                            person.last_name, 
                            person.birth_date, 
                            person.birth_location, 
                            person.gender, 
                            person.last_known_residence, 
                            person.nationality, 
                            person.status, 
                            person.passport, 
                            person.photo, 
                            person.email_addr, 
                            person.phone_num, 
                            criminal.criminal_nickname, 
                            criminal.criminal_distinctive_features, 
                            criminal.article_of_accusation 
                        FROM 
                            person 
                        INNER JOIN 
                            criminal ON person.person_id = criminal.person_id 
                        WHERE 
                            person.person_id = @PersonId";

                    OleDbCommand command = new OleDbCommand(query, connection);
                    command.Parameters.AddWithValue("@PersonId", _personId);

                    connection.Open();
                    OleDbDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        txtFirstName.Text = reader["first_name"].ToString();
                        txtLastName.Text = reader["last_name"].ToString();
                        dtpBirthDate.Value = DateTime.Parse(reader["birth_date"].ToString());
                        txtBirthLocation.Text = reader["birth_location"].ToString();
                        txtResidence.Text = reader["last_known_residence"].ToString();
                        txtNationality.Text = reader["nationality"].ToString();
                        txtPassport.Text = reader["passport"].ToString();
                        txtEmail.Text = reader["email_addr"].ToString();
                        txtPhone.Text = reader["phone_num"].ToString();
                        txtNickname.Text = reader["criminal_nickname"].ToString();
                        txtDistinctiveFeatures.Text = reader["criminal_distinctive_features"].ToString();
                        txtArticle.Text = reader["article_of_accusation"].ToString();

                        // Завантаження фото
                        if (reader["photo"] != DBNull.Value)
                        {
                            string photoPath = Path.Combine(Application.StartupPath, reader["photo"].ToString());
                            if (File.Exists(photoPath))
                            {
                                pbPhoto.Image = Image.FromFile(photoPath);
                                pbPhoto.ImageLocation = photoPath;
                            }
                        }
                        else
                        {
                            pbPhoto.Image = null;
                            pbPhoto.ImageLocation = string.Empty;
                        }

                        // Перевірка та додавання до ComboBox введених значень
                        string genderValue = reader["gender"].ToString();
                        if (!cmbGender.Items.Contains(genderValue) && !string.IsNullOrEmpty(genderValue))
                        {
                            cmbGender.Items.Add(genderValue);
                        }
                        cmbGender.Text = genderValue;

                        string statusValue = reader["status"].ToString();
                        if (!cmbStatus.Items.Contains(statusValue) && !string.IsNullOrEmpty(statusValue))
                        {
                            cmbStatus.Items.Add(statusValue);
                        }
                        cmbStatus.Text = statusValue;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка завантаження інформації про злочинця: " + ex.Message);
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
                    string query = @"
                SELECT 
                    criminal_crime.crime_date, 
                    criminal_crime.criminal_degree_participation, 
                    crime.crime_type, 
                    crime.crime_location, 
                    crime.crime_method, 
                    crime.investigations_status 
                FROM 
                    criminal_crime 
                INNER JOIN 
                    crime ON criminal_crime.crime_id = crime.crime_id 
                WHERE 
                    criminal_crime.crime_id = @CrimeId";

                    OleDbCommand command = new OleDbCommand(query, connection);
                    command.Parameters.AddWithValue("@CrimeId", _crimeId);

                    connection.Open();
                    OleDbDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        // Заповнення DateTimePicker
                        dtpCrimeDate.Value = reader["crime_date"] != DBNull.Value
                            ? Convert.ToDateTime(reader["crime_date"])
                            : DateTime.Now;

                        // Заповнення ComboBox для типу злочину
                        string crimeType = reader["crime_type"].ToString();
                        if (!cmbCrimeType.Items.Contains(crimeType) && !string.IsNullOrEmpty(crimeType))
                        {
                            cmbCrimeType.Items.Add(crimeType);
                        }
                        cmbCrimeType.Text = crimeType;

                        // Заповнення текстових полів
                        txtCrimeLocation.Text = reader["crime_location"].ToString();
                        txtCrimeMethod.Text = reader["crime_method"].ToString();

                        // Заповнення ComboBox для ступеня участі
                        string degreeParticipation = reader["criminal_degree_participation"].ToString();
                        if (!cmbDegreeParticipation.Items.Contains(degreeParticipation) && !string.IsNullOrEmpty(degreeParticipation))
                        {
                            cmbDegreeParticipation.Items.Add(degreeParticipation);
                        }
                        cmbDegreeParticipation.Text = degreeParticipation;

                        // Заповнення ComboBox для статусу розслідування
                        string investigationStatus = reader["investigations_status"].ToString();
                        if (!cmbInvestigationStatus.Items.Contains(investigationStatus) && !string.IsNullOrEmpty(investigationStatus))
                        {
                            cmbInvestigationStatus.Items.Add(investigationStatus);
                        }
                        cmbInvestigationStatus.Text = investigationStatus;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка завантаження інформації про злочин: " + ex.Message);
                }
            }
        }

        private void LoadVictims()
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\ХНУРЕ\База даних\Interpol\Interpol\Interpol.accdb;";
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                try
                {
                    string query = @"
        SELECT 
            p.person_id,
            p.first_name, 
            p.last_name, 
            p.birth_date, 
            p.gender, 
            p.birth_location, 
            p.last_known_residence, 
            p.nationality, 
            p.status, 
            p.passport, 
            p.email_addr, 
            p.phone_num, 
            p.photo, 
            v.victim_testimony, 
            v.victim_testimony_date, 
            v.victim_injury
        FROM 
            victim v
        LEFT JOIN 
            person p ON v.person_id = p.person_id
        WHERE 
            v.crime_id = @CrimeId";

                    OleDbCommand command = new OleDbCommand(query, connection);
                    command.Parameters.AddWithValue("@CrimeId", _crimeId);

                    connection.Open();
                    OleDbDataReader reader = command.ExecuteReader();

                    int yOffset = 0;

                    while (reader.Read())
                    {
                        var victimPanel = new VictimPanel(reader, yOffset, RemoveVictimPanel);
                        tabVictims.Controls.Add(victimPanel);
                        yOffset += victimPanel.Height + 10;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка завантаження потерпілих: " + ex.Message);
                }
            }

            // Кнопка додавання нового потерпілого
            Button btnAddVictim = new Button
            {
                Text = "Додати потерпілого",
                Location = new Point(10, tabVictims.Controls.Count * 490),
                Size = new Size(200, 30)
            };

            btnAddVictim.Click += (s, e) =>
            {
                // Додаємо нову панель на основі класу VictimPanel
                var newPanel = new VictimPanel(null, 0, RemoveVictimPanel);
                tabVictims.Controls.Add(newPanel);

                // Оновлюємо розташування панелей
                UpdateVictimPanelPositions();
            };

            tabVictims.Controls.Add(btnAddVictim);

            UpdateVictimPanelPositions();
        }

        private void RemoveVictimPanel(VictimPanel panel)
        {
            if (panel.PersonId != 0) // Якщо панель пов'язана з існуючим записом у базі
            {
                string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\ХНУРЕ\База даних\Interpol\Interpol\Interpol.accdb;";
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    try
                    {
                        connection.Open();

                        // Видаляємо запис із таблиці `victim`
                        string deleteVictimQuery = "DELETE FROM victim WHERE person_id = @PersonId AND crime_id = @CrimeId";
                        using (OleDbCommand command = new OleDbCommand(deleteVictimQuery, connection))
                        {
                            command.Parameters.AddWithValue("@PersonId", panel.PersonId);
                            command.Parameters.AddWithValue("@CrimeId", _crimeId); // Використовуємо ідентифікатор злочину
                            command.ExecuteNonQuery();
                        }

                        // Видаляємо запис із таблиці `person` (якщо це необхідно)
                        string deletePersonQuery = "DELETE FROM person WHERE person_id = @PersonId";
                        using (OleDbCommand command = new OleDbCommand(deletePersonQuery, connection))
                        {
                            command.Parameters.AddWithValue("@PersonId", panel.PersonId);
                            command.ExecuteNonQuery();
                        }

                        MessageBox.Show($"Потерпілий з ID {panel.PersonId} успішно видалений з бази даних.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Помилка видалення потерпілого з бази даних: " + ex.Message);
                    }
                }
            }

            // Видаляємо панель з інтерфейсу
            tabVictims.Controls.Remove(panel);
            panel.Dispose();
            UpdateVictimPanelPositions();
        }

        private void UpdateVictimPanelPositions()
        {
            int yOffset = 10; // Початковий відступ зверху

            // Розташовуємо всі панелі типу VictimPanel
            foreach (Control control in tabVictims.Controls)
            {
                if (control is VictimPanel victimPanel)
                {
                    victimPanel.Location = new Point(10, yOffset);
                    yOffset += victimPanel.Height + 10; // Додаємо висоту панелі + відступ
                }
            }

            // Розміщуємо кнопку "Додати потерпілого" після всіх панелей
            foreach (Control control in tabVictims.Controls)
            {
                if (control is Button btn && btn.Text == "Додати потерпілого")
                {
                    btn.Location = new Point(10, yOffset);
                    break; // Завершуємо пошук після знаходження кнопки
                }
            }
        }

        public class VictimPanel : Panel
        {
            // Поля панелі
            public TextBox txtFirstName;
            public TextBox txtLastName;
            public DateTimePicker dtpBirthDate;
            public ComboBox cmbGender;
            public TextBox txtBirthLocation;
            public TextBox txtResidence;
            public TextBox txtNationality;
            public ComboBox cmbStatus;
            public TextBox txtPassport;
            public TextBox txtEmail;
            public TextBox txtPhone;
            public DateTimePicker dtpTestimonyDate;
            public TextBox txtInjury;
            public PictureBox pbPhoto;
            public Button btnDelete;
            public Button btnLoadPhoto;
            public Button btnLoadTestimony;
            public Button btnOpenPdf;

            public int PersonId { get; private set; } = 0;

            public VictimPanel(OleDbDataReader reader, int yOffset, Action<VictimPanel> onDelete)
            {
                // Налаштування панелі
                Size = new Size(800, 480);
                Location = new Point(10, yOffset);
                BorderStyle = BorderStyle.FixedSingle;

                // Зчитування ID потерпілого
                if (reader != null && reader["person_id"] != DBNull.Value)
                {
                    PersonId = Convert.ToInt32(reader["person_id"]);
                }

                // Ініціалізація елементів
                txtFirstName = CreateTextBox("Ім'я: ", reader?["first_name"], 10, 10);
                txtLastName = CreateTextBox("Прізвище: ", reader?["last_name"], 10, 40);
                dtpBirthDate = CreateDateTimePicker("Дата народження: ", reader?["birth_date"], 10, 70);
                cmbGender = CreateComboBox("Стать: ", new[] { "Чоловіча", "Жіноча", "Інша" }, reader?["gender"], 10, 100);
                txtBirthLocation = CreateTextBox("Місце народження: ", reader?["birth_location"], 10, 130);
                txtResidence = CreateTextBox("Місце проживання: ", reader?["last_known_residence"], 10, 160);
                txtNationality = CreateTextBox("Національність: ", reader?["nationality"], 10, 190);
                cmbStatus = CreateComboBox("Статус: ", new[] { "Живий", "Помер", "Зниклий" }, reader?["status"], 10, 220);
                txtPassport = CreateTextBox("Паспорт: ", reader?["passport"], 10, 250);
                txtEmail = CreateTextBox("Email: ", reader?["email_addr"], 10, 280);
                txtPhone = CreateTextBox("Телефон: ", reader?["phone_num"], 10, 310);
                dtpTestimonyDate = CreateDateTimePicker("Дата свідчень: ", reader?["victim_testimony_date"], 10, 340);
                txtInjury = CreateTextBox("Ушкодження: ", reader?["victim_injury"], 10, 370);

                // PictureBox для фото
                pbPhoto = new PictureBox
                {
                    Size = new Size(200, 200),
                    Location = new Point(420, 10),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    BorderStyle = BorderStyle.FixedSingle
                };

                if (reader != null && reader["photo"] != DBNull.Value)
                {
                    string photoPath = reader["photo"].ToString();
                    if (File.Exists(photoPath))
                    {
                        pbPhoto.Image = Image.FromFile(photoPath);
                    }
                }
                Controls.Add(pbPhoto);

                // Кнопка завантаження фото
                btnLoadPhoto = new Button
                {
                    Text = "Нове фото",
                    Location = new Point(420, 220),
                    Size = new Size(200, 30)
                };
                btnLoadPhoto.Click += (s, e) =>
                {
                    using (OpenFileDialog openFileDialog = new OpenFileDialog())
                    {
                        openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                        if (openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            string sourcePath = openFileDialog.FileName;
                            string destinationPath = Path.Combine(Application.StartupPath, @"Sources\Images\", Path.GetFileName(sourcePath));
                            try
                            {
                                if (!File.Exists(destinationPath))
                                {
                                    File.Copy(sourcePath, destinationPath, true);
                                }
                                if (pbPhoto.Image != null)
                                {
                                    pbPhoto.Image.Dispose();
                                }
                                pbPhoto.Image = Image.FromFile(destinationPath);
                                pbPhoto.ImageLocation = destinationPath;
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Помилка копіювання файлу: " + ex.Message);
                            }
                        }
                    }
                };
                Controls.Add(btnLoadPhoto);

                // Кнопка завантаження PDF
                btnLoadTestimony = new Button
                {
                    Text = "Нове свідчення",
                    Location = new Point(420, 260),
                    Size = new Size(200, 30)
                };
                btnLoadTestimony.Click += (s, e) =>
                {
                    using (OpenFileDialog openFileDialog = new OpenFileDialog())
                    {
                        openFileDialog.Filter = "PDF Files|*.pdf";
                        if (openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            string sourcePath = openFileDialog.FileName;
                            string destinationPath = Path.Combine(Application.StartupPath, @"Sources\PDF\", Path.GetFileName(sourcePath));
                            try
                            {
                                File.Copy(sourcePath, destinationPath, true);
                                btnOpenPdf.Tag = Path.Combine(@"Sources\PDF\", Path.GetFileName(sourcePath));
                                btnOpenPdf.Enabled = true;
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Помилка копіювання файлу: " + ex.Message);
                            }
                        }
                    }
                };
                Controls.Add(btnLoadTestimony);

                // Кнопка відкриття PDF
                btnOpenPdf = new Button
                {
                    Text = "Свідчення",
                    Location = new Point(420, 300),
                    Size = new Size(200, 30),
                    Enabled = reader != null && reader["victim_testimony"] != DBNull.Value
                };
                btnOpenPdf.Click += (s, e) =>
                {
                    if (btnOpenPdf.Tag is string pdfPath && File.Exists(Path.Combine(Application.StartupPath, pdfPath)))
                    {
                        try
                        {
                            System.Diagnostics.Process.Start(Path.Combine(Application.StartupPath, pdfPath));
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Не вдалося відкрити файл: {ex.Message}");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Файл свідчення не знайдено або не завантажено.");
                    }
                };
                Controls.Add(btnOpenPdf);

                // Кнопка видалення панелі
                btnDelete = new Button
                {
                    Text = "Видалити",
                    Location = new Point(420, 340),
                    Size = new Size(200, 30)
                };
                btnDelete.Click += (s, e) => onDelete(this);
                Controls.Add(btnDelete);
            }

            private TextBox CreateTextBox(string labelText, object value, int x, int y)
            {
                Label label = new Label { Text = labelText, Location = new Point(x, y), AutoSize = true };
                Controls.Add(label);

                TextBox textBox = new TextBox
                {
                    Text = value != DBNull.Value ? value?.ToString() : "",
                    Location = new Point(x + 165, y),
                    Size = new Size(200, 20)
                };
                Controls.Add(textBox);
                return textBox;
            }

            private ComboBox CreateComboBox(string labelText, string[] items, object value, int x, int y)
            {
                // Додаємо мітку
                Label label = new Label
                {
                    Text = labelText,
                    Location = new Point(x, y),
                    AutoSize = true
                };
                Controls.Add(label);

                // Створюємо ComboBox
                ComboBox comboBox = new ComboBox
                {
                    Location = new Point(x + 165, y),
                    Size = new Size(200, 20),
                    DropDownStyle = ComboBoxStyle.DropDown
                };

                // Додаємо елементи, якщо вони не null
                if (items != null)
                {
                    comboBox.Items.AddRange(items);
                }

                // Встановлюємо значення, якщо воно не null
                if (value != null && value != DBNull.Value)
                {
                    string valueAsString = value.ToString();
                    // Якщо значення немає в списку, додаємо його
                    if (!comboBox.Items.Contains(valueAsString))
                    {
                        comboBox.Items.Add(valueAsString);
                    }
                    comboBox.Text = valueAsString;
                }

                Controls.Add(comboBox);
                return comboBox;
            }

            private DateTimePicker CreateDateTimePicker(string labelText, object value, int x, int y)
            {
                // Додаємо мітку
                Label label = new Label
                {
                    Text = labelText,
                    Location = new Point(x, y),
                    AutoSize = true
                };
                Controls.Add(label);

                // Створюємо DateTimePicker
                DateTimePicker dateTimePicker = new DateTimePicker
                {
                    Location = new Point(x + 165, y),
                    Size = new Size(200, 20),
                    Format = DateTimePickerFormat.Short
                };

                // Перевіряємо, чи є значення коректним
                if (value != null && value != DBNull.Value && DateTime.TryParse(value.ToString(), out DateTime parsedDate))
                {
                    // Якщо значення валідне, встановлюємо його
                    dateTimePicker.Value = parsedDate;
                }
                else
                {
                    // Інакше встановлюємо значення за замовчуванням (поточна дата або будь-яка інша логіка)
                    dateTimePicker.Value = DateTime.Now;
                }

                Controls.Add(dateTimePicker);
                return dateTimePicker;
            }
        }

        private void LoadWitnesses()
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\ХНУРЕ\База даних\Interpol\Interpol\Interpol.accdb;";
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                try
                {
                    string query = @"
                SELECT 
                    p.person_id,
                    p.first_name, 
                    p.last_name, 
                    p.birth_date, 
                    p.gender, 
                    p.birth_location, 
                    p.last_known_residence, 
                    p.nationality, 
                    p.status, 
                    p.passport, 
                    p.email_addr, 
                    p.phone_num, 
                    p.photo, 
                    w.witness_testimony, 
                    w.witness_testimony_date
                FROM 
                    witness w
                LEFT JOIN 
                    person p ON w.person_id = p.person_id
                WHERE 
                    w.crime_id = @CrimeId";

                    OleDbCommand command = new OleDbCommand(query, connection);
                    command.Parameters.AddWithValue("@CrimeId", _crimeId);

                    connection.Open();
                    OleDbDataReader reader = command.ExecuteReader();

                    int yOffset = 0;

                    while (reader.Read())
                    {
                        string testimonyPath = null;

                        // Завантаження відносного шляху до PDF-файлу
                        if (reader["witness_testimony"] != DBNull.Value)
                        {
                            testimonyPath = reader["witness_testimony"].ToString();
                            if (!Path.IsPathRooted(testimonyPath)) // Якщо шлях відносний
                            {
                                testimonyPath = Path.Combine(Application.StartupPath, testimonyPath);
                            }
                        }

                        var witnessPanel = new WitnessPanel(reader, yOffset, RemoveWitnessPanel)
                        {
                            TestimonyPath = testimonyPath // Передаємо шлях до панелі
                        };

                        tabWitnesses.Controls.Add(witnessPanel);
                        yOffset += witnessPanel.Height + 10;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка завантаження свідків: " + ex.Message);
                }
            }

            // Кнопка додавання нового свідка
            Button btnAddWitness = new Button
            {
                Text = "Додати свідка",
                Location = new Point(10, tabWitnesses.Controls.Count * 490),
                Size = new Size(200, 30)
            };

            btnAddWitness.Click += (s, e) =>
            {
                var newPanel = new WitnessPanel(null, tabWitnesses.Controls.Count * 490, RemoveWitnessPanel);
                tabWitnesses.Controls.Add(newPanel);
                UpdateWitnessPanelPositions();
            };

            tabWitnesses.Controls.Add(btnAddWitness);

            UpdateWitnessPanelPositions();
        }

        private void RemoveWitnessPanel(WitnessPanel panel)
        {
            if (panel.PersonId != 0)
            {
                string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\ХНУРЕ\База даних\Interpol\Interpol\Interpol.accdb;";
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    try
                    {
                        connection.Open();

                        // Видаляємо запис із таблиці `witness`
                        string deleteWitnessQuery = "DELETE FROM witness WHERE person_id = @PersonId AND crime_id = @CrimeId";
                        using (OleDbCommand command = new OleDbCommand(deleteWitnessQuery, connection))
                        {
                            command.Parameters.AddWithValue("@PersonId", panel.PersonId);
                            command.Parameters.AddWithValue("@CrimeId", _crimeId);
                            command.ExecuteNonQuery();
                        }

                        // Видаляємо запис із таблиці `person`
                        string deletePersonQuery = "DELETE FROM person WHERE person_id = @PersonId";
                        using (OleDbCommand command = new OleDbCommand(deletePersonQuery, connection))
                        {
                            command.Parameters.AddWithValue("@PersonId", panel.PersonId);
                            command.ExecuteNonQuery();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Помилка видалення свідка з бази даних: " + ex.Message);
                    }
                }
            }

            tabWitnesses.Controls.Remove(panel);
            panel.Dispose();
            UpdateWitnessPanelPositions();
        }

        private void UpdateWitnessPanelPositions()
        {
            int yOffset = 0;

            foreach (Control control in tabWitnesses.Controls)
            {
                if (control is WitnessPanel witnessPanel)
                {
                    witnessPanel.Location = new Point(10, yOffset);
                    yOffset += witnessPanel.Height + 10;
                }
            }

            foreach (Control control in tabWitnesses.Controls)
            {
                if (control is Button btn && btn.Text == "Додати свідка")
                {
                    btn.Location = new Point(10, yOffset);
                }
            }
        }

        public class WitnessPanel : Panel
        {
            public TextBox txtFirstName;
            public TextBox txtLastName;
            public DateTimePicker dtpBirthDate;
            public ComboBox cmbGender;
            public TextBox txtBirthLocation;
            public TextBox txtResidence;
            public TextBox txtNationality;
            public ComboBox cmbStatus;
            public TextBox txtPassport;
            public TextBox txtEmail;
            public TextBox txtPhone;
            public DateTimePicker dtpTestimonyDate;
            public PictureBox pbPhoto;
            public Button btnDelete;
            public Button btnLoadPhoto;
            public Button btnLoadTestimony;
            public Button btnOpenTestimony;
            public int PersonId { get; private set; }
            public string TestimonyPath
            {
                get => btnOpenTestimony.Tag?.ToString();
                set
                {
                    btnOpenTestimony.Tag = value;
                    btnOpenTestimony.Enabled = !string.IsNullOrEmpty(value) && File.Exists(value);
                }
            }

            public WitnessPanel(OleDbDataReader reader, int yOffset, Action<WitnessPanel> onDelete)
            {
                Size = new Size(800, 480);
                Location = new Point(10, yOffset);
                BorderStyle = BorderStyle.FixedSingle;

                PersonId = reader != null && reader["person_id"] != DBNull.Value ? Convert.ToInt32(reader["person_id"]) : 0;

                txtFirstName = CreateTextBox("Ім'я: ", reader?["first_name"], 10, 10);
                txtLastName = CreateTextBox("Прізвище: ", reader?["last_name"], 10, 40);
                dtpBirthDate = CreateDateTimePicker("Дата народження: ", reader?["birth_date"], 10, 70);
                cmbGender = CreateComboBox("Стать: ", new[] { "Чоловіча", "Жіноча", "Інше" }, reader?["gender"], 10, 100);
                txtBirthLocation = CreateTextBox("Місце народження: ", reader?["birth_location"], 10, 130);
                txtResidence = CreateTextBox("Місце проживання: ", reader?["last_known_residence"], 10, 160);
                txtNationality = CreateTextBox("Національність: ", reader?["nationality"], 10, 190);
                cmbStatus = CreateComboBox("Статус: ", new[] { "Живий", "Мертвий", "Зниклий" }, reader?["status"], 10, 220);
                txtPassport = CreateTextBox("Паспорт: ", reader?["passport"], 10, 250);
                txtEmail = CreateTextBox("Email: ", reader?["email_addr"], 10, 280);
                txtPhone = CreateTextBox("Телефон: ", reader?["phone_num"], 10, 310);
                dtpTestimonyDate = CreateDateTimePicker("Дата свідчень: ", reader?["witness_testimony_date"], 10, 340);

                pbPhoto = new PictureBox
                {
                    Size = new Size(200, 200),
                    Location = new Point(420, 10),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    BorderStyle = BorderStyle.FixedSingle
                };

                if (reader != null && reader["photo"] != DBNull.Value)
                {
                    string photoPath = reader["photo"].ToString();
                    if (!Path.IsPathRooted(photoPath))
                    {
                        photoPath = Path.Combine(Application.StartupPath, photoPath);
                    }
                    if (File.Exists(photoPath))
                    {
                        pbPhoto.Image = Image.FromFile(photoPath);
                    }
                }

                Controls.Add(pbPhoto);

                btnLoadPhoto = new Button
                {
                    Text = "Нове фото",
                    Location = new Point(420, 220),
                    Size = new Size(200, 30)
                };

                btnLoadPhoto.Click += (s, e) =>
                {
                    using (OpenFileDialog openFileDialog = new OpenFileDialog())
                    {
                        openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                        if (openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            string sourcePath = openFileDialog.FileName;
                            string destinationPath = Path.Combine(Application.StartupPath, @"Sources\Images\", Path.GetFileName(sourcePath));

                            try
                            {
                                if (!File.Exists(destinationPath))
                                {
                                    File.Copy(sourcePath, destinationPath, true);
                                }

                                if (pbPhoto.Image != null)
                                {
                                    pbPhoto.Image.Dispose();
                                }

                                pbPhoto.Image = Image.FromFile(destinationPath);
                                pbPhoto.ImageLocation = destinationPath;
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Помилка копіювання файлу: " + ex.Message);
                            }
                        }
                    }
                };

                Controls.Add(btnLoadPhoto);

                btnLoadTestimony = new Button
                {
                    Text = "Нове свідчення",
                    Location = new Point(420, 260),
                    Size = new Size(200, 30)
                };

                btnLoadTestimony.Click += (s, e) =>
                {
                    using (OpenFileDialog openFileDialog = new OpenFileDialog())
                    {
                        openFileDialog.Filter = "PDF Files|*.pdf";
                        if (openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            string sourcePath = openFileDialog.FileName;
                            string destinationPath = Path.Combine(Application.StartupPath, @"Sources\PDF\", Path.GetFileName(sourcePath));

                            try
                            {
                                File.Copy(sourcePath, destinationPath, true);
                                TestimonyPath = Path.Combine(@"Sources\PDF\", Path.GetFileName(sourcePath));
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Помилка копіювання файлу: " + ex.Message);
                            }
                        }
                    }
                };

                Controls.Add(btnLoadTestimony);

                btnOpenTestimony = new Button
                {
                    Text = "Свідчення",
                    Location = new Point(420, 300),
                    Size = new Size(200, 30),
                    Enabled = false
                };

                btnOpenTestimony.Click += (s, e) =>
                {
                    if (btnOpenTestimony.Tag is string pdfPath && File.Exists(pdfPath))
                    {
                        try
                        {
                            System.Diagnostics.Process.Start(pdfPath);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Не вдалося відкрити файл: {ex.Message}");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Файл свідчення не знайдено або не завантажено.");
                    }
                };

                Controls.Add(btnOpenTestimony);

                btnDelete = new Button
                {
                    Text = "Видалити",
                    Location = new Point(420, 340),
                    Size = new Size(200, 30)
                };

                btnDelete.Click += (s, e) => onDelete(this);

                Controls.Add(btnDelete);
            }

            private TextBox CreateTextBox(string labelText, object value, int x, int y)
            {
                Label label = new Label
                {
                    Text = labelText,
                    Location = new Point(x, y),
                    AutoSize = true
                };
                Controls.Add(label);

                TextBox textBox = new TextBox
                {
                    Text = value != DBNull.Value ? value?.ToString() : "",
                    Location = new Point(x + 165, y),
                    Size = new Size(200, 20)
                };
                Controls.Add(textBox);
                return textBox;
            }

            private ComboBox CreateComboBox(string labelText, string[] items, object value, int x, int y)
            {
                Label label = new Label
                {
                    Text = labelText,
                    Location = new Point(x, y),
                    AutoSize = true
                };
                Controls.Add(label);

                ComboBox comboBox = new ComboBox
                {
                    Location = new Point(x + 165, y),
                    Size = new Size(200, 20),
                    DropDownStyle = ComboBoxStyle.DropDown
                };

                if (items != null)
                {
                    comboBox.Items.AddRange(items);
                }

                if (value != null && value != DBNull.Value)
                {
                    string valueAsString = value.ToString();
                    if (!comboBox.Items.Contains(valueAsString))
                    {
                        comboBox.Items.Add(valueAsString);
                    }
                    comboBox.Text = valueAsString;
                }

                Controls.Add(comboBox);
                return comboBox;
            }

            private DateTimePicker CreateDateTimePicker(string labelText, object value, int x, int y)
            {
                Label label = new Label
                {
                    Text = labelText,
                    Location = new Point(x, y),
                    AutoSize = true
                };
                Controls.Add(label);

                DateTimePicker dateTimePicker = new DateTimePicker
                {
                    Location = new Point(x + 165, y),
                    Size = new Size(200, 20),
                    Format = DateTimePickerFormat.Short
                };

                if (value != null && value != DBNull.Value)
                {
                    dateTimePicker.Value = Convert.ToDateTime(value);
                }

                Controls.Add(dateTimePicker);
                return dateTimePicker;
            }
        }

        private void LoadEvidence()
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\ХНУРЕ\База даних\Interpol\Interpol\Interpol.accdb;";
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                try
                {
                    string query = @"
    SELECT 
        e.evidence_id,
        e.evidence_type, 
        e.evidence_description, 
        e.evidence_discovery_date, 
        e.evidence_location, 
        e.evidence_storage_location, 
        e.evidence_analysis_result, 
        ec.evidence_date_attachment
    FROM 
        evidence e
    LEFT JOIN 
        evidence_crime ec ON e.evidence_id = ec.evidence_id
    WHERE 
        ec.crime_id = @CrimeId";

                    OleDbCommand command = new OleDbCommand(query, connection);
                    command.Parameters.AddWithValue("@CrimeId", _crimeId);

                    connection.Open();
                    OleDbDataReader reader = command.ExecuteReader();

                    int yOffset = 0;

                    while (reader.Read())
                    {
                        var evidencePanel = new EvidencePanel(reader, yOffset, RemoveEvidencePanel);
                        tabEvidence.Controls.Add(evidencePanel);
                        yOffset += evidencePanel.Height + 10;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка завантаження доказів: " + ex.Message);
                }
            }

            // Кнопка додавання нового доказу
            Button btnAddEvidence = new Button
            {
                Text = "Додати доказ",
                Location = new Point(10, tabEvidence.Controls.Count * 310),
                Size = new Size(200, 30)
            };

            btnAddEvidence.Click += (s, e) =>
            {
                var newPanel = new EvidencePanel(null, tabEvidence.Controls.Count * 310, RemoveEvidencePanel);
                tabEvidence.Controls.Add(newPanel);
                UpdateEvidencePanelPositions();
            };

            tabEvidence.Controls.Add(btnAddEvidence);

            UpdateEvidencePanelPositions();
        }

        private void RemoveEvidencePanel(EvidencePanel panel)
        {
            if (panel.EvidenceId != 0) // Якщо це існуючий запис у базі
            {
                string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\ХНУРЕ\База даних\Interpol\Interpol\Interpol.accdb;";
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    try
                    {
                        connection.Open();

                        // Видаляємо запис із таблиці `evidence_crime`
                        string deleteEvidenceCrimeQuery = "DELETE FROM evidence_crime WHERE evidence_id = @EvidenceId AND crime_id = @CrimeId";
                        using (OleDbCommand command = new OleDbCommand(deleteEvidenceCrimeQuery, connection))
                        {
                            command.Parameters.AddWithValue("@EvidenceId", panel.EvidenceId);
                            command.Parameters.AddWithValue("@CrimeId", _crimeId);
                            command.ExecuteNonQuery();
                        }

                        // Видаляємо запис із таблиці `evidence`
                        string deleteEvidenceQuery = "DELETE FROM evidence WHERE evidence_id = @EvidenceId";
                        using (OleDbCommand command = new OleDbCommand(deleteEvidenceQuery, connection))
                        {
                            command.Parameters.AddWithValue("@EvidenceId", panel.EvidenceId);
                            command.ExecuteNonQuery();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Помилка видалення доказу з бази даних: " + ex.Message);
                    }
                }
            }

            tabEvidence.Controls.Remove(panel);
            panel.Dispose();
            UpdateEvidencePanelPositions();
        }

        private void UpdateEvidencePanelPositions()
        {
            int yOffset = 0;
            foreach (Control control in tabEvidence.Controls)
            {
                if (control is EvidencePanel evidencePanel)
                {
                    evidencePanel.Location = new Point(10, yOffset);
                    yOffset += evidencePanel.Height + 10;
                }
            }

            foreach (Control control in tabEvidence.Controls)
            {
                if (control is Button btn && btn.Text == "Додати доказ")
                {
                    btn.Location = new Point(10, yOffset);
                }
            }
        }

        public class EvidencePanel : Panel
        {
            public ComboBox cmbType;
            public TextBox txtDescription;
            public DateTimePicker dtpDiscoveryDate;
            public TextBox txtLocation;
            public TextBox txtStorageLocation;
            public TextBox txtAnalysisResult;
            public DateTimePicker dtpDateAttachment;
            public Button btnDelete;

            public int EvidenceId { get; private set; }

            public EvidencePanel(OleDbDataReader reader, int yOffset, Action<EvidencePanel> onDelete)
            {
                Size = new Size(800, 300);
                Location = new Point(10, yOffset);
                BorderStyle = BorderStyle.FixedSingle;

                // Зчитуємо EvidenceId, якщо є
                EvidenceId = reader != null && reader["evidence_id"] != DBNull.Value ? Convert.ToInt32(reader["evidence_id"]) : 0;

                // Ініціалізація полів
                cmbType = CreateComboBox("Тип доказу: ", new[] { "Фізичний", "Документальний", "Електронний", "Інше" }, reader?["evidence_type"], 10, 10);
                txtDescription = CreateTextBox("Опис: ", reader?["evidence_description"], 10, 40);
                dtpDiscoveryDate = CreateDateTimePicker("Дата виявлення: ", reader?["evidence_discovery_date"], 10, 70);
                txtLocation = CreateTextBox("Місце виявлення: ", reader?["evidence_location"], 10, 100);
                txtStorageLocation = CreateTextBox("Місце зберігання: ", reader?["evidence_storage_location"], 10, 130);
                txtAnalysisResult = CreateTextBox("Результат аналізу: ", reader?["evidence_analysis_result"], 10, 160);
                dtpDateAttachment = CreateDateTimePicker("Дата додавання до злочину: ", reader?["evidence_date_attachment"], 10, 190);

                // Кнопка видалення панелі
                btnDelete = new Button
                {
                    Text = "Видалити",
                    Location = new Point(490, 240),
                    Size = new Size(150, 30)
                };

                btnDelete.Click += (s, e) => onDelete(this);

                Controls.Add(btnDelete);
            }

            private TextBox CreateTextBox(string labelText, object value, int x, int y)
            {
                Label label = new Label
                {
                    Text = labelText,
                    Location = new Point(x, y),
                    AutoSize = true
                };
                Controls.Add(label);

                TextBox textBox = new TextBox
                {
                    Text = value != DBNull.Value ? value?.ToString() : "",
                    Location = new Point(x + 230, y),
                    Size = new Size(400, 20)
                };
                Controls.Add(textBox);
                return textBox;
            }

            private ComboBox CreateComboBox(string labelText, string[] items, object value, int x, int y)
            {
                Label label = new Label
                {
                    Text = labelText,
                    Location = new Point(x, y),
                    AutoSize = true
                };
                Controls.Add(label);

                ComboBox comboBox = new ComboBox
                {
                    Location = new Point(x + 230, y),
                    Size = new Size(400, 20),
                    DropDownStyle = ComboBoxStyle.DropDown
                };
                comboBox.Items.AddRange(items);
                comboBox.Text = value != DBNull.Value ? value?.ToString() : "";

                Controls.Add(comboBox);
                return comboBox;
            }

            private DateTimePicker CreateDateTimePicker(string labelText, object value, int x, int y)
            {
                Label label = new Label
                {
                    Text = labelText,
                    Location = new Point(x, y),
                    AutoSize = true
                };
                Controls.Add(label);

                DateTimePicker dateTimePicker = new DateTimePicker
                {
                    Location = new Point(x + 230, y),
                    Size = new Size(400, 20),
                    Format = DateTimePickerFormat.Short
                };

                if (value != DBNull.Value && DateTime.TryParse(value?.ToString(), out DateTime parsedDate))
                {
                    dateTimePicker.Value = parsedDate;
                }

                Controls.Add(dateTimePicker);
                return dateTimePicker;
            }
        }

        private void LoadWantedStatus()
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\ХНУРЕ\База даних\Interpol\Interpol\Interpol.accdb;";
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                try
                {
                    string query = @"
            SELECT 
                ws.status_date, 
                ws.status_country, 
                ws.issuing_authority, 
                ws.status_type
            FROM 
                wanted_status ws
            LEFT JOIN 
                criminal_crime cc ON ws.criminal_crime_id = cc.criminal_crime_id
            WHERE 
                cc.crime_id = @CrimeId";

                    OleDbCommand command = new OleDbCommand(query, connection);
                    command.Parameters.AddWithValue("@CrimeId", _crimeId);

                    connection.Open();
                    OleDbDataReader reader = command.ExecuteReader();

                    int yOffset = 0; // Відступ для кожного елементу
                    while (reader.Read())
                    {
                        Panel wantedPanel = new Panel
                        {
                            Size = new Size(800, 200),
                            Location = new Point(10, yOffset),
                            BorderStyle = BorderStyle.FixedSingle
                        };

                        // DateTimePicker для дати статусу
                        DateTimePicker dtpStatusDate = new DateTimePicker
                        {
                            Location = new Point(160, 10),
                            Size = new Size(200, 20),
                            Format = DateTimePickerFormat.Short,
                            Value = reader["status_date"] != DBNull.Value ? Convert.ToDateTime(reader["status_date"]) : DateTime.Now
                        };
                        wantedPanel.Controls.Add(new Label
                        {
                            Text = "Дата статусу:",
                            Location = new Point(10, 10),
                            AutoSize = true
                        });
                        wantedPanel.Controls.Add(dtpStatusDate);

                        // TextBox для країни розшуку
                        TextBox txtWantedCountry = new TextBox
                        {
                            Name = "txtWantedCountry",
                            Location = new Point(160, 40),
                            Size = new Size(200, 20),
                            Text = reader["status_country"]?.ToString() ?? ""
                        };
                        wantedPanel.Controls.Add(new Label
                        {
                            Text = "Країна розшуку:",
                            Location = new Point(10, 40),
                            AutoSize = true
                        });
                        wantedPanel.Controls.Add(txtWantedCountry);

                        // TextBox для органу, що видав розшук
                        TextBox txtIssuingAuthority = new TextBox
                        {
                            Name = "txtIssuingAuthority",
                            Location = new Point(160, 70),
                            Size = new Size(200, 20),
                            Text = reader["issuing_authority"]?.ToString() ?? ""
                        };
                        wantedPanel.Controls.Add(new Label
                        {
                            Text = "Орган видачі:",
                            Location = new Point(10, 70),
                            AutoSize = true
                        });
                        wantedPanel.Controls.Add(txtIssuingAuthority);

                        // ComboBox для типу статусу
                        ComboBox cmbStatusType = new ComboBox
                        {
                            Name = "cmbStatusType",
                            Location = new Point(160, 100),
                            Size = new Size(200, 20),
                            DropDownStyle = ComboBoxStyle.DropDown,
                            Text = reader["status_type"]?.ToString() ?? ""
                        };
                        cmbStatusType.Items.AddRange(new string[] { "Активний", "Закритий", "Очікує перевірки" });
                        wantedPanel.Controls.Add(new Label
                        {
                            Text = "Тип статусу:",
                            Location = new Point(10, 100),
                            AutoSize = true
                        });
                        wantedPanel.Controls.Add(cmbStatusType);

                        tabWanted.Controls.Add(wantedPanel);
                        yOffset += 210; // Збільшуємо відступ
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка завантаження розшуків: " + ex.Message);
                }
            }
        }

        private void LoadWarrants()
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\ХНУРЕ\База даних\Interpol\Interpol\Interpol.accdb;";
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Крок 1: Отримати всі court_case_id
                    string getCourtCasesQuery = @"
                SELECT 
                    cc.court_case_id
                FROM 
                    court_case cc
                LEFT JOIN 
                    criminal_crime cc_crime ON cc.criminal_crime_id = cc_crime.criminal_crime_id
                WHERE 
                    cc_crime.crime_id = @CrimeId";

                    OleDbCommand getCourtCasesCommand = new OleDbCommand(getCourtCasesQuery, connection);
                    getCourtCasesCommand.Parameters.AddWithValue("@CrimeId", _crimeId);

                    List<int> courtCaseIds = new List<int>();
                    OleDbDataReader courtCaseReader = getCourtCasesCommand.ExecuteReader();

                    while (courtCaseReader.Read())
                    {
                        courtCaseIds.Add(Convert.ToInt32(courtCaseReader["court_case_id"]));
                    }

                    courtCaseReader.Close();

                    // Крок 2: Отримати ордери за кожним court_case_id
                    int yOffset = 0; // Відступ для кожного елементу
                    foreach (int courtCaseId in courtCaseIds)
                    {
                        string getWarrantsQuery = @"
                    SELECT 
                        iw.warrant_issue_date, 
                        iw.warrant_country, 
                        iw.warrant_type
                    FROM 
                        international_warrant iw
                    WHERE 
                        iw.court_case_id = @CourtCaseId";

                        OleDbCommand getWarrantsCommand = new OleDbCommand(getWarrantsQuery, connection);
                        getWarrantsCommand.Parameters.AddWithValue("@CourtCaseId", courtCaseId);

                        OleDbDataReader warrantReader = getWarrantsCommand.ExecuteReader();

                        while (warrantReader.Read())
                        {
                            // Створюємо панель для кожного ордера
                            Panel warrantPanel = new Panel
                            {
                                Size = new Size(800, 150),
                                Location = new Point(10, yOffset),
                                BorderStyle = BorderStyle.FixedSingle
                            };

                            // DateTimePicker для дати видачі ордера
                            DateTimePicker dtpWarrantIssueDate = new DateTimePicker
                            {
                                Location = new Point(170, 10),
                                Size = new Size(200, 20),
                                Format = DateTimePickerFormat.Short,
                                Value = warrantReader["warrant_issue_date"] != DBNull.Value ? Convert.ToDateTime(warrantReader["warrant_issue_date"]) : DateTime.Now
                            };
                            warrantPanel.Controls.Add(new Label
                            {
                                Text = "Дата видачі ордера:",
                                Location = new Point(10, 10),
                                AutoSize = true
                            });
                            warrantPanel.Controls.Add(dtpWarrantIssueDate);

                            // TextBox для країни видачі
                            TextBox txtWarrantCountry = new TextBox
                            {
                                Name = "txtWarrantCountry",
                                Location = new Point(170, 40),
                                Size = new Size(200, 20),
                                Text = warrantReader["warrant_country"]?.ToString() ?? ""
                            };
                            warrantPanel.Controls.Add(new Label
                            {
                                Text = "Країна видачі:",
                                Location = new Point(10, 40),
                                AutoSize = true
                            });
                            warrantPanel.Controls.Add(txtWarrantCountry);

                            // ComboBox для типу ордера
                            ComboBox cmbWarrantType = new ComboBox
                            {
                                Name = "cmbWarrantType",
                                Location = new Point(170, 70),
                                Size = new Size(200, 20),
                                DropDownStyle = ComboBoxStyle.DropDown,
                                Text = warrantReader["warrant_type"]?.ToString() ?? ""
                            };
                            cmbWarrantType.Items.AddRange(new string[] { "Національний", "Міжнародний", "Інше" }); // Приклад варіантів
                            warrantPanel.Controls.Add(new Label
                            {
                                Text = "Тип ордера:",
                                Location = new Point(10, 70),
                                AutoSize = true
                            });
                            warrantPanel.Controls.Add(cmbWarrantType);

                            // Додаємо панель до вкладки
                            tabWarrants.Controls.Add(warrantPanel);

                            yOffset += 160; // Збільшуємо відступ для наступної панелі
                        }

                        warrantReader.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка завантаження ордерів: " + ex.Message);
                }
            }
        }

        private int _courtCaseId;
        private string _currentCasePath;

        private void LoadCourtCase()
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\ХНУРЕ\База даних\Interpol\Interpol\Interpol.accdb;";
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                try
                {
                    string query = @"
                        SELECT 
                            cc.court_case_id, 
                            cc.decision_number, 
                            cc.case_number, 
                            cc.registration_date, 
                            cc.hearing_date, 
                            cc.court_decision_form, 
                            cc.court_hearing_form, 
                            cc.court_name, 
                            cc.case_decision
                        FROM 
                            court_case cc
                        LEFT JOIN 
                            criminal_crime cc_crime ON cc.criminal_crime_id = cc_crime.criminal_crime_id
                        WHERE 
                            cc_crime.crime_id = @CrimeId";

                    OleDbCommand command = new OleDbCommand(query, connection);
                    command.Parameters.AddWithValue("@CrimeId", _crimeId);

                    connection.Open();
                    OleDbDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        // Зчитуємо court_case_id заздалегідь
                        if (reader["court_case_id"] != DBNull.Value)
                        {
                            _courtCaseId = Convert.ToInt32(reader["court_case_id"]);
                        }

                        _currentCasePath = reader["case_decision"] != DBNull.Value ? reader["case_decision"].ToString() : null;

                        Panel courtCasePanel = new Panel
                        {
                            Size = new Size(800, 350),
                            Location = new Point(0, 10),
                            BorderStyle = BorderStyle.FixedSingle
                        };

                        courtCasePanel.Controls.Add(CreateTextBox6("txtDecisionNumber", "Номер рішення: ", reader["decision_number"], 20, 10));
                        courtCasePanel.Controls.Add(CreateTextBox6("txtCaseNumber", "Номер справи: ", reader["case_number"], 20, 40));
                        courtCasePanel.Controls.Add(CreateTextBox6("txtRegistrationDate", "Дата реєстрації: ", reader["registration_date"], 20, 70));
                        courtCasePanel.Controls.Add(CreateTextBox6("txtHearingDate", "Дата слухання: ", reader["hearing_date"], 20, 100));
                        courtCasePanel.Controls.Add(CreateTextBox6("txtCourtDecisionForm", "Форма рішення: ", reader["court_decision_form"], 20, 130));
                        courtCasePanel.Controls.Add(CreateTextBox6("txtCourtHearingForm", "Форма слухання: ", reader["court_hearing_form"], 20, 160));
                        courtCasePanel.Controls.Add(CreateTextBox6("txtCourtName", "Назва суду: ", reader["court_name"], 20, 190));

                        Button btnOpenCase = new Button
                        {
                            Text = "Cудова справа",
                            Location = new Point(20, 230),
                            Size = new Size(150, 30),
                            Enabled = !string.IsNullOrEmpty(_currentCasePath) && File.Exists(_currentCasePath)
                        };

                        btnOpenCase.Click += (s, e) =>
                        {
                            if (!string.IsNullOrEmpty(_currentCasePath) && File.Exists(_currentCasePath))
                            {
                                System.Diagnostics.Process.Start(_currentCasePath);
                            }
                            else
                            {
                                MessageBox.Show("Файл справи не знайдено або не завантажено.");
                            }
                        };

                        courtCasePanel.Controls.Add(btnOpenCase);

                        Button btnUploadCase = new Button
                        {
                            Text = "Нова справа",
                            Location = new Point(220, 230),
                            Size = new Size(150, 30)
                        };

                        btnUploadCase.Click += (s, e) =>
                        {
                            using (OpenFileDialog openFileDialog = new OpenFileDialog())
                            {
                                openFileDialog.Filter = "PDF Files|*.pdf";
                                openFileDialog.Title = "Оберіть PDF-файл для судової справи";

                                if (openFileDialog.ShowDialog() == DialogResult.OK)
                                {
                                    string sourcePath = openFileDialog.FileName;
                                    string destinationPath = Path.Combine(Application.StartupPath, @"Sources\PDF\", Path.GetFileName(sourcePath));

                                    try
                                    {
                                        File.Copy(sourcePath, destinationPath, true);
                                        _currentCasePath = Path.Combine(@"Sources\PDF\", Path.GetFileName(sourcePath));

                                        // Відкриття нового підключення для оновлення
                                        using (OleDbConnection updateConnection = new OleDbConnection(connectionString))
                                        {
                                            updateConnection.Open();

                                            string updateQuery = @"
                                                UPDATE court_case
                                                SET case_decision = @CaseDecision
                                                WHERE court_case_id = @CourtCaseId";

                                            using (OleDbCommand updateCommand = new OleDbCommand(updateQuery, updateConnection))
                                            {
                                                updateCommand.Parameters.AddWithValue("@CaseDecision", _currentCasePath);
                                                updateCommand.Parameters.AddWithValue("@CourtCaseId", _courtCaseId);
                                                updateCommand.ExecuteNonQuery();
                                            }
                                        }

                                        MessageBox.Show("Новий файл судової справи завантажено успішно.");
                                        btnOpenCase.Enabled = true; // Дозволяємо відкриття нового файлу
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Помилка копіювання файлу: " + ex.Message);
                                    }
                                }
                            }
                        };

                        courtCasePanel.Controls.Add(btnUploadCase);

                        tabCourtCase.Controls.Add(courtCasePanel);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка завантаження судової справи: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        private void UploadCaseHandler(object sender, EventArgs e)
        {
            if (_courtCaseId == 0)
            {
                MessageBox.Show("Не вдалося знайти ідентифікатор судової справи. Завантаження неможливе.");
                return;
            }

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "PDF Files|*.pdf";
                openFileDialog.Title = "Оберіть PDF-файл для судової справи";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string sourcePath = openFileDialog.FileName;
                    string destinationPath = Path.Combine(Application.StartupPath, @"Sources\PDF\", Path.GetFileName(sourcePath));

                    try
                    {
                        File.Copy(sourcePath, destinationPath, true);
                        string newCasePath = Path.Combine(@"Sources\PDF\", Path.GetFileName(sourcePath));

                        string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\ХНУРЕ\База даних\Interpol\Interpol\Interpol.accdb;";
                        using (OleDbConnection connection = new OleDbConnection(connectionString))
                        {
                            connection.Open();

                            string updateQuery = @"
                        UPDATE court_case
                        SET case_decision = @CaseDecision
                        WHERE court_case_id = @CourtCaseId";

                            using (OleDbCommand updateCommand = new OleDbCommand(updateQuery, connection))
                            {
                                updateCommand.Parameters.AddWithValue("@CaseDecision", newCasePath);
                                updateCommand.Parameters.AddWithValue("@CourtCaseId", _courtCaseId);
                                updateCommand.ExecuteNonQuery();
                            }
                        }

                        MessageBox.Show("Новий файл судової справи успішно збережено в базі даних.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Помилка копіювання файлу: " + ex.Message);
                    }
                }
            }
        }

        private TextBox CreateTextBox6(string name, string labelText, object value, int x, int y)
        {
            // Додаємо мітку
            Label label = new Label
            {
                Text = labelText,
                Location = new Point(x, y + 10),
                AutoSize = true
            };
            tabCourtCase.Controls.Add(label);

            // Додаємо текстове поле
            TextBox textBox = new TextBox
            {
                Name = name,
                Text = value?.ToString(),
                Location = new Point(x + 150, y),
                Size = new Size(200, 20)
            };

            return textBox;
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
                    string destinationFileName = Path.GetFileName(sourcePath);
                    string destinationPath = Path.Combine(Application.StartupPath, @"Sources\Images\", destinationFileName);

                    try
                    {
                        // Перевірка наявності фото
                        if (!File.Exists(destinationPath))
                        {
                            File.Copy(sourcePath, destinationPath);
                        }

                        // Оновлюємо шлях до фото
                        txtPhotoPath.Text = Path.Combine(@"Sources\Images\", destinationFileName);
                        pbPhoto.Image = Image.FromFile(destinationPath);

                        // Зберігаємо шлях до фото у базу даних
                        string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\ХНУРЕ\База даних\Interpol\Interpol\Interpol.accdb;";
                        using (OleDbConnection connection = new OleDbConnection(connectionString))
                        {
                            connection.Open();

                            string updateQuery = @"
                        UPDATE person
                        SET photo = @PhotoPath
                        WHERE person_id = @PersonId";

                            using (OleDbCommand command = new OleDbCommand(updateQuery, connection))
                            {
                                command.Parameters.AddWithValue("@PhotoPath", Path.Combine(@"Sources\Images\", destinationFileName));
                                command.Parameters.AddWithValue("@PersonId", _personId);
                                command.ExecuteNonQuery();
                            }
                        }
                    }
                    catch (IOException ioEx)
                    {
                        MessageBox.Show($"Помилка копіювання файлу: {ioEx.Message}");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Сталася помилка: {ex.Message}");
                    }
                }
            }
        }

        private void EditCriminalForm_Load(object sender, EventArgs e)
        {
            LoadCriminalInfo();
            LoadCrimeInfo();
            LoadVictims();
            LoadWitnesses();
            LoadEvidence();
            LoadWantedStatus();
            LoadWarrants();
            LoadCourtCase();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveCriminalInfo()
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\ХНУРЕ\База даних\Interpol\Interpol\Interpol.accdb;";
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string relativePhotoPath = string.Empty;

                    // Перевірка і копіювання фото тільки якщо змінено
                    if (!string.IsNullOrEmpty(pbPhoto.ImageLocation) && File.Exists(pbPhoto.ImageLocation))
                    {
                        string sourcePhotoPath = pbPhoto.ImageLocation;
                        string destinationPhotoPath = Path.Combine(Application.StartupPath, @"Sources\Images\", Path.GetFileName(sourcePhotoPath));

                        if (!File.Exists(destinationPhotoPath))
                        {
                            File.Copy(sourcePhotoPath, destinationPhotoPath, true);
                        }

                        relativePhotoPath = Path.Combine(@"Sources\Images\", Path.GetFileName(sourcePhotoPath));
                    }

                    // Оновлення таблиці person
                    string updatePersonQuery = @"
                UPDATE person
                SET 
                    first_name = @FirstName,
                    last_name = @LastName,
                    birth_date = @BirthDate,
                    birth_location = @BirthLocation,
                    gender = @Gender,
                    last_known_residence = @Residence,
                    nationality = @Nationality,
                    status = @Status,
                    passport = @Passport,
                    email_addr = @Email,
                    phone_num = @Phone,
                    photo = IIF(@PhotoPath = '', photo, @PhotoPath) 
                WHERE 
                    person_id = @PersonId";

                    using (OleDbCommand command = new OleDbCommand(updatePersonQuery, connection))
                    {
                        command.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                        command.Parameters.AddWithValue("@LastName", txtLastName.Text);
                        command.Parameters.AddWithValue("@BirthDate", dtpBirthDate.Value.ToString("yyyy-MM-dd")); // Формат дати
                        command.Parameters.AddWithValue("@BirthLocation", txtBirthLocation.Text);
                        command.Parameters.AddWithValue("@Gender", cmbGender.Text);
                        command.Parameters.AddWithValue("@Residence", txtResidence.Text);
                        command.Parameters.AddWithValue("@Nationality", txtNationality.Text);
                        command.Parameters.AddWithValue("@Status", cmbStatus.Text);
                        command.Parameters.AddWithValue("@Passport", txtPassport.Text);
                        command.Parameters.AddWithValue("@Email", txtEmail.Text);
                        command.Parameters.AddWithValue("@Phone", txtPhone.Text);
                        command.Parameters.AddWithValue("@PhotoPath", relativePhotoPath);
                        command.Parameters.AddWithValue("@PersonId", _personId);

                        command.ExecuteNonQuery();
                    }

                    // Оновлення таблиці criminal
                    string updateCriminalQuery = @"
                UPDATE criminal
                SET 
                    criminal_nickname = @Nickname,
                    criminal_distinctive_features = @DistinctiveFeatures,
                    article_of_accusation = @Article
                WHERE 
                    person_id = @PersonId";

                    using (OleDbCommand command = new OleDbCommand(updateCriminalQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Nickname", txtNickname.Text);
                        command.Parameters.AddWithValue("@DistinctiveFeatures", txtDistinctiveFeatures.Text);
                        command.Parameters.AddWithValue("@Article", txtArticle.Text);
                        command.Parameters.AddWithValue("@PersonId", _personId);

                        command.ExecuteNonQuery();
                    }

                    // Оновлення таблиці crime
                    string updateCrimeQuery = @"
                UPDATE crime
                SET 
                    crime_type = @CrimeType,
                    crime_location = @CrimeLocation,
                    crime_method = @CrimeMethod,
                    investigations_status = @InvestigationStatus
                WHERE 
                    crime_id = @CrimeId";

                    using (OleDbCommand command = new OleDbCommand(updateCrimeQuery, connection))
                    {
                        command.Parameters.AddWithValue("@CrimeType", cmbCrimeType.Text);
                        command.Parameters.AddWithValue("@CrimeLocation", txtCrimeLocation.Text);
                        command.Parameters.AddWithValue("@CrimeMethod", txtCrimeMethod.Text);
                        command.Parameters.AddWithValue("@InvestigationStatus", cmbInvestigationStatus.Text);
                        command.Parameters.AddWithValue("@CrimeId", _crimeId);

                        command.ExecuteNonQuery();
                    }

                    // Оновлення таблиці criminal_crime
                    string updateCriminalCrimeQuery = @"
                UPDATE criminal_crime
                SET 
                    crime_date = @CrimeDate,
                    criminal_degree_participation = @DegreeParticipation
                WHERE 
                    crime_id = @CrimeId";

                    using (OleDbCommand command = new OleDbCommand(updateCriminalCrimeQuery, connection))
                    {
                        command.Parameters.AddWithValue("@CrimeDate", dtpCrimeDate.Value.ToString("yyyy-MM-dd")); // Формат дати
                        command.Parameters.AddWithValue("@DegreeParticipation", cmbDegreeParticipation.Text);
                        command.Parameters.AddWithValue("@CrimeId", _crimeId);

                        command.ExecuteNonQuery();
                    }

                    //MessageBox.Show("Дані про злочинця та злочин успішно збережено.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка збереження даних: " + ex.Message);
                }
            }
        }

        private void SaveVictims()
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\ХНУРЕ\База даних\Interpol\Interpol\Interpol.accdb;";
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Отримуємо список всіх поточних person_id для жертв, прив'язаних до crime_id
                    string existingVictimsQuery = "SELECT person_id FROM victim WHERE crime_id = @CrimeId";
                    OleDbCommand existingVictimsCommand = new OleDbCommand(existingVictimsQuery, connection);
                    existingVictimsCommand.Parameters.AddWithValue("@CrimeId", _crimeId);

                    List<int> existingVictimIds = new List<int>();
                    OleDbDataReader reader = existingVictimsCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        existingVictimIds.Add(Convert.ToInt32(reader["person_id"]));
                    }
                    reader.Close();

                    // Видаляємо жертв, які були видалені у формі
                    foreach (int victimId in existingVictimIds)
                    {
                        bool isVictimInUI = false;
                        foreach (Control control in tabVictims.Controls)
                        {
                            if (control is VictimPanel victimPanel && victimPanel.PersonId == victimId)
                            {
                                isVictimInUI = true;
                                break;
                            }
                        }

                        if (!isVictimInUI)
                        {
                            string deleteVictimQuery = "DELETE FROM victim WHERE person_id = @PersonId AND crime_id = @CrimeId";
                            OleDbCommand deleteVictimCommand = new OleDbCommand(deleteVictimQuery, connection);
                            deleteVictimCommand.Parameters.AddWithValue("@PersonId", victimId);
                            deleteVictimCommand.Parameters.AddWithValue("@CrimeId", _crimeId);
                            deleteVictimCommand.ExecuteNonQuery();

                            string deletePersonQuery = "DELETE FROM person WHERE person_id = @PersonId";
                            OleDbCommand deletePersonCommand = new OleDbCommand(deletePersonQuery, connection);
                            deletePersonCommand.Parameters.AddWithValue("@PersonId", victimId);
                            deletePersonCommand.ExecuteNonQuery();
                        }
                    }

                    // Додаємо або оновлюємо жертв
                    foreach (Control control in tabVictims.Controls)
                    {
                        if (control is VictimPanel victimPanel)
                        {
                            if (victimPanel.PersonId == 0)
                            {
                                // Додаємо нову особу
                                string insertPersonQuery = @"
                            INSERT INTO person 
                            (first_name, last_name, birth_date, gender, birth_location, 
                             last_known_residence, nationality, status, passport, email_addr, 
                             phone_num, photo) 
                            VALUES 
                            (@FirstName, @LastName, @BirthDate, @Gender, @BirthLocation, 
                             @Residence, @Nationality, @Status, @Passport, @Email, 
                             @Phone, @PhotoPath)";

                                OleDbCommand insertPersonCommand = new OleDbCommand(insertPersonQuery, connection);
                                insertPersonCommand.Parameters.AddWithValue("@FirstName", victimPanel.txtFirstName.Text);
                                insertPersonCommand.Parameters.AddWithValue("@LastName", victimPanel.txtLastName.Text);
                                insertPersonCommand.Parameters.AddWithValue("@BirthDate", victimPanel.dtpBirthDate.Value.ToString("yyyy-MM-dd"));
                                insertPersonCommand.Parameters.AddWithValue("@Gender", victimPanel.cmbGender.Text);
                                insertPersonCommand.Parameters.AddWithValue("@BirthLocation", victimPanel.txtBirthLocation.Text);
                                insertPersonCommand.Parameters.AddWithValue("@Residence", victimPanel.txtResidence.Text);
                                insertPersonCommand.Parameters.AddWithValue("@Nationality", victimPanel.txtNationality.Text);
                                insertPersonCommand.Parameters.AddWithValue("@Status", victimPanel.cmbStatus.Text);
                                insertPersonCommand.Parameters.AddWithValue("@Passport", victimPanel.txtPassport.Text);
                                insertPersonCommand.Parameters.AddWithValue("@Email", victimPanel.txtEmail.Text);
                                insertPersonCommand.Parameters.AddWithValue("@Phone", victimPanel.txtPhone.Text);
                                insertPersonCommand.Parameters.AddWithValue("@PhotoPath", victimPanel.pbPhoto.ImageLocation ?? "");
                                insertPersonCommand.ExecuteNonQuery();

                                string selectPersonIdQuery = "SELECT @@IDENTITY";
                                OleDbCommand selectPersonIdCommand = new OleDbCommand(selectPersonIdQuery, connection);
                                int newPersonId = Convert.ToInt32(selectPersonIdCommand.ExecuteScalar());

                                string insertVictimQuery = @"
                            INSERT INTO victim 
                            (person_id, crime_id, victim_testimony, victim_testimony_date, victim_injury) 
                            VALUES 
                            (@PersonId, @CrimeId, @TestimonyPath, @TestimonyDate, @Injury)";
                                OleDbCommand insertVictimCommand = new OleDbCommand(insertVictimQuery, connection);
                                insertVictimCommand.Parameters.AddWithValue("@PersonId", newPersonId);
                                insertVictimCommand.Parameters.AddWithValue("@CrimeId", _crimeId);
                                insertVictimCommand.Parameters.AddWithValue("@TestimonyPath", victimPanel.btnOpenPdf.Tag?.ToString() ?? "");
                                insertVictimCommand.Parameters.AddWithValue("@TestimonyDate", victimPanel.dtpTestimonyDate.Value.ToString("yyyy-MM-dd"));
                                insertVictimCommand.Parameters.AddWithValue("@Injury", victimPanel.txtInjury.Text);
                                insertVictimCommand.ExecuteNonQuery();
                            }
                            else
                            {
                                // Оновлюємо існуючу особу
                                string updatePersonQuery = @"
                            UPDATE person 
                            SET 
                                first_name = @FirstName, 
                                last_name = @LastName, 
                                birth_date = @BirthDate, 
                                gender = @Gender, 
                                birth_location = @BirthLocation, 
                                last_known_residence = @Residence, 
                                nationality = @Nationality, 
                                status = @Status, 
                                passport = @Passport, 
                                email_addr = @Email, 
                                phone_num = @Phone, 
                                photo = IIF(@PhotoPath = '', photo, @PhotoPath) 
                            WHERE person_id = @PersonId";

                                OleDbCommand updatePersonCommand = new OleDbCommand(updatePersonQuery, connection);
                                updatePersonCommand.Parameters.AddWithValue("@FirstName", victimPanel.txtFirstName.Text);
                                updatePersonCommand.Parameters.AddWithValue("@LastName", victimPanel.txtLastName.Text);
                                updatePersonCommand.Parameters.AddWithValue("@BirthDate", victimPanel.dtpBirthDate.Value.ToString("yyyy-MM-dd"));
                                updatePersonCommand.Parameters.AddWithValue("@Gender", victimPanel.cmbGender.Text);
                                updatePersonCommand.Parameters.AddWithValue("@BirthLocation", victimPanel.txtBirthLocation.Text);
                                updatePersonCommand.Parameters.AddWithValue("@Residence", victimPanel.txtResidence.Text);
                                updatePersonCommand.Parameters.AddWithValue("@Nationality", victimPanel.txtNationality.Text);
                                updatePersonCommand.Parameters.AddWithValue("@Status", victimPanel.cmbStatus.Text);
                                updatePersonCommand.Parameters.AddWithValue("@Passport", victimPanel.txtPassport.Text);
                                updatePersonCommand.Parameters.AddWithValue("@Email", victimPanel.txtEmail.Text);
                                updatePersonCommand.Parameters.AddWithValue("@Phone", victimPanel.txtPhone.Text);
                                updatePersonCommand.Parameters.AddWithValue("@PhotoPath", victimPanel.pbPhoto.ImageLocation ?? "");
                                updatePersonCommand.Parameters.AddWithValue("@PersonId", victimPanel.PersonId);
                                updatePersonCommand.ExecuteNonQuery();
                            }
                        }
                    }

                    //MessageBox.Show("Дані про потерпілих успішно збережено.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка збереження даних про потерпілих: " + ex.Message);
                }
            }
        }

        private void SaveWitnesses()
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\ХНУРЕ\База даних\Interpol\Interpol\Interpol.accdb;";
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Отримуємо список поточних свідків
                    string existingWitnessesQuery = "SELECT person_id FROM witness WHERE crime_id = @CrimeId";
                    OleDbCommand existingWitnessesCommand = new OleDbCommand(existingWitnessesQuery, connection);
                    existingWitnessesCommand.Parameters.AddWithValue("@CrimeId", _crimeId);

                    List<int> existingWitnessIds = new List<int>();
                    OleDbDataReader reader = existingWitnessesCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        existingWitnessIds.Add(Convert.ToInt32(reader["person_id"]));
                    }
                    reader.Close();

                    // Видалення свідків, яких немає у формі
                    foreach (int witnessId in existingWitnessIds)
                    {
                        bool isWitnessInUI = false;
                        foreach (Control control in tabWitnesses.Controls)
                        {
                            if (control is WitnessPanel witnessPanel && witnessPanel.PersonId == witnessId)
                            {
                                isWitnessInUI = true;
                                break;
                            }
                        }

                        if (!isWitnessInUI)
                        {
                            string deleteWitnessQuery = "DELETE FROM witness WHERE person_id = @PersonId AND crime_id = @CrimeId";
                            OleDbCommand deleteWitnessCommand = new OleDbCommand(deleteWitnessQuery, connection);
                            deleteWitnessCommand.Parameters.AddWithValue("@PersonId", witnessId);
                            deleteWitnessCommand.Parameters.AddWithValue("@CrimeId", _crimeId);
                            deleteWitnessCommand.ExecuteNonQuery();

                            string deletePersonQuery = "DELETE FROM person WHERE person_id = @PersonId";
                            OleDbCommand deletePersonCommand = new OleDbCommand(deletePersonQuery, connection);
                            deletePersonCommand.Parameters.AddWithValue("@PersonId", witnessId);
                            deletePersonCommand.ExecuteNonQuery();
                        }
                    }

                    // Збереження нових/оновлення свідків
                    foreach (Control control in tabWitnesses.Controls)
                    {
                        if (control is WitnessPanel witnessPanel)
                        {
                            string relativeTestimonyPath = string.Empty;

                            // Зберігаємо свідчення
                            if (!string.IsNullOrEmpty(witnessPanel.TestimonyPath) && File.Exists(witnessPanel.TestimonyPath))
                            {
                                string sourcePath = witnessPanel.TestimonyPath;
                                string destinationPath = Path.Combine(Application.StartupPath, @"Sources\PDF\", Path.GetFileName(sourcePath));

                                if (!File.Exists(destinationPath))
                                {
                                    File.Copy(sourcePath, destinationPath, true);
                                }

                                relativeTestimonyPath = Path.Combine(@"Sources\PDF\", Path.GetFileName(sourcePath));
                            }

                            if (witnessPanel.PersonId == 0)
                            {
                                // Додавання нової особи
                                string insertPersonQuery = @"
                    INSERT INTO person 
                    (first_name, last_name, birth_date, gender, birth_location, 
                     last_known_residence, nationality, status, passport, email_addr, 
                     phone_num, photo) 
                    VALUES 
                    (@FirstName, @LastName, @BirthDate, @Gender, @BirthLocation, 
                     @Residence, @Nationality, @Status, @Passport, @Email, 
                     @Phone, @PhotoPath)";

                                OleDbCommand insertPersonCommand = new OleDbCommand(insertPersonQuery, connection);
                                insertPersonCommand.Parameters.AddWithValue("@FirstName", witnessPanel.txtFirstName.Text);
                                insertPersonCommand.Parameters.AddWithValue("@LastName", witnessPanel.txtLastName.Text);
                                insertPersonCommand.Parameters.AddWithValue("@BirthDate", witnessPanel.dtpBirthDate.Value.ToString("yyyy-MM-dd"));
                                insertPersonCommand.Parameters.AddWithValue("@Gender", witnessPanel.cmbGender.Text);
                                insertPersonCommand.Parameters.AddWithValue("@BirthLocation", witnessPanel.txtBirthLocation.Text);
                                insertPersonCommand.Parameters.AddWithValue("@Residence", witnessPanel.txtResidence.Text);
                                insertPersonCommand.Parameters.AddWithValue("@Nationality", witnessPanel.txtNationality.Text);
                                insertPersonCommand.Parameters.AddWithValue("@Status", witnessPanel.cmbStatus.Text);
                                insertPersonCommand.Parameters.AddWithValue("@Passport", witnessPanel.txtPassport.Text);
                                insertPersonCommand.Parameters.AddWithValue("@Email", witnessPanel.txtEmail.Text);
                                insertPersonCommand.Parameters.AddWithValue("@Phone", witnessPanel.txtPhone.Text);
                                insertPersonCommand.Parameters.AddWithValue("@PhotoPath", witnessPanel.pbPhoto.ImageLocation ?? "");
                                insertPersonCommand.ExecuteNonQuery();

                                string selectPersonIdQuery = "SELECT @@IDENTITY";
                                OleDbCommand selectPersonIdCommand = new OleDbCommand(selectPersonIdQuery, connection);
                                int newPersonId = Convert.ToInt32(selectPersonIdCommand.ExecuteScalar());

                                string insertWitnessQuery = @"
                    INSERT INTO witness 
                    (person_id, crime_id, witness_testimony, witness_testimony_date) 
                    VALUES 
                    (@PersonId, @CrimeId, @TestimonyPath, @TestimonyDate)";
                                OleDbCommand insertWitnessCommand = new OleDbCommand(insertWitnessQuery, connection);
                                insertWitnessCommand.Parameters.AddWithValue("@PersonId", newPersonId);
                                insertWitnessCommand.Parameters.AddWithValue("@CrimeId", _crimeId);
                                insertWitnessCommand.Parameters.AddWithValue("@TestimonyPath", relativeTestimonyPath);
                                insertWitnessCommand.Parameters.AddWithValue("@TestimonyDate", witnessPanel.dtpTestimonyDate.Value.ToString("yyyy-MM-dd"));
                                insertWitnessCommand.ExecuteNonQuery();
                            }
                            else
                            {
                                // Оновлення існуючої особи
                                string updatePersonQuery = @"
                    UPDATE person 
                    SET 
                        first_name = @FirstName, 
                        last_name = @LastName, 
                        birth_date = @BirthDate, 
                        gender = @Gender, 
                        birth_location = @BirthLocation, 
                        last_known_residence = @Residence, 
                        nationality = @Nationality, 
                        status = @Status, 
                        passport = @Passport, 
                        email_addr = @Email, 
                        phone_num = @Phone, 
                        photo = IIF(@PhotoPath = '', photo, @PhotoPath) 
                    WHERE person_id = @PersonId";

                                OleDbCommand updatePersonCommand = new OleDbCommand(updatePersonQuery, connection);
                                updatePersonCommand.Parameters.AddWithValue("@FirstName", witnessPanel.txtFirstName.Text);
                                updatePersonCommand.Parameters.AddWithValue("@LastName", witnessPanel.txtLastName.Text);
                                updatePersonCommand.Parameters.AddWithValue("@BirthDate", witnessPanel.dtpBirthDate.Value.ToString("yyyy-MM-dd"));
                                updatePersonCommand.Parameters.AddWithValue("@Gender", witnessPanel.cmbGender.Text);
                                updatePersonCommand.Parameters.AddWithValue("@BirthLocation", witnessPanel.txtBirthLocation.Text);
                                updatePersonCommand.Parameters.AddWithValue("@Residence", witnessPanel.txtResidence.Text);
                                updatePersonCommand.Parameters.AddWithValue("@Nationality", witnessPanel.txtNationality.Text);
                                updatePersonCommand.Parameters.AddWithValue("@Status", witnessPanel.cmbStatus.Text);
                                updatePersonCommand.Parameters.AddWithValue("@Passport", witnessPanel.txtPassport.Text);
                                updatePersonCommand.Parameters.AddWithValue("@Email", witnessPanel.txtEmail.Text);
                                updatePersonCommand.Parameters.AddWithValue("@Phone", witnessPanel.txtPhone.Text);
                                updatePersonCommand.Parameters.AddWithValue("@PhotoPath", witnessPanel.pbPhoto.ImageLocation ?? "");
                                updatePersonCommand.Parameters.AddWithValue("@PersonId", witnessPanel.PersonId);
                                updatePersonCommand.ExecuteNonQuery();

                                string updateWitnessQuery = @"
                    UPDATE witness 
                    SET 
                        witness_testimony = @TestimonyPath, 
                        witness_testimony_date = @TestimonyDate 
                    WHERE person_id = @PersonId AND crime_id = @CrimeId";
                                OleDbCommand updateWitnessCommand = new OleDbCommand(updateWitnessQuery, connection);
                                updateWitnessCommand.Parameters.AddWithValue("@TestimonyPath", relativeTestimonyPath);
                                updateWitnessCommand.Parameters.AddWithValue("@TestimonyDate", witnessPanel.dtpTestimonyDate.Value.ToString("yyyy-MM-dd"));
                                updateWitnessCommand.Parameters.AddWithValue("@PersonId", witnessPanel.PersonId);
                                updateWitnessCommand.Parameters.AddWithValue("@CrimeId", _crimeId);
                                updateWitnessCommand.ExecuteNonQuery();
                            }
                        }
                    }

                    //MessageBox.Show("Дані про свідків успішно збережено.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка збереження даних про свідків: " + ex.Message);
                }
            }
        }

        private void SaveEvidence()
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\ХНУРЕ\База даних\Interpol\Interpol\Interpol.accdb;";
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Отримуємо список всіх поточних evidence_id для доказів, прив'язаних до crime_id
                    string existingEvidenceQuery = "SELECT evidence_id FROM evidence_crime WHERE crime_id = @CrimeId";
                    OleDbCommand existingEvidenceCommand = new OleDbCommand(existingEvidenceQuery, connection);
                    existingEvidenceCommand.Parameters.AddWithValue("@CrimeId", _crimeId);

                    List<int> existingEvidenceIds = new List<int>();
                    OleDbDataReader reader = existingEvidenceCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        existingEvidenceIds.Add(Convert.ToInt32(reader["evidence_id"]));
                    }
                    reader.Close();

                    // Видаляємо докази, які були видалені у формі
                    foreach (int evidenceId in existingEvidenceIds)
                    {
                        bool isEvidenceInUI = false;
                        foreach (Control control in tabEvidence.Controls)
                        {
                            if (control is EvidencePanel evidencePanel && evidencePanel.EvidenceId == evidenceId)
                            {
                                isEvidenceInUI = true;
                                break;
                            }
                        }

                        if (!isEvidenceInUI)
                        {
                            // Видаляємо запис із таблиці `evidence_crime`
                            string deleteEvidenceCrimeQuery = "DELETE FROM evidence_crime WHERE evidence_id = @EvidenceId AND crime_id = @CrimeId";
                            using (OleDbCommand deleteEvidenceCrimeCommand = new OleDbCommand(deleteEvidenceCrimeQuery, connection))
                            {
                                deleteEvidenceCrimeCommand.Parameters.AddWithValue("@EvidenceId", evidenceId);
                                deleteEvidenceCrimeCommand.Parameters.AddWithValue("@CrimeId", _crimeId);
                                deleteEvidenceCrimeCommand.ExecuteNonQuery();
                            }

                            // Видаляємо запис із таблиці `evidence`
                            string deleteEvidenceQuery = "DELETE FROM evidence WHERE evidence_id = @EvidenceId";
                            using (OleDbCommand deleteEvidenceCommand = new OleDbCommand(deleteEvidenceQuery, connection))
                            {
                                deleteEvidenceCommand.Parameters.AddWithValue("@EvidenceId", evidenceId);
                                deleteEvidenceCommand.ExecuteNonQuery();
                            }
                        }
                    }

                    // Додаємо або оновлюємо докази
                    foreach (Control control in tabEvidence.Controls)
                    {
                        if (control is EvidencePanel evidencePanel)
                        {
                            if (evidencePanel.EvidenceId == 0)
                            {
                                // Додаємо новий доказ
                                string insertEvidenceQuery = @"
                INSERT INTO evidence 
                (evidence_type, evidence_description, evidence_discovery_date, evidence_location, 
                 evidence_storage_location, evidence_analysis_result) 
                VALUES 
                (@Type, @Description, @DiscoveryDate, @Location, @StorageLocation, @AnalysisResult)";

                                OleDbCommand insertEvidenceCommand = new OleDbCommand(insertEvidenceQuery, connection);
                                insertEvidenceCommand.Parameters.AddWithValue("@Type", evidencePanel.cmbType.Text);
                                insertEvidenceCommand.Parameters.AddWithValue("@Description", evidencePanel.txtDescription.Text);
                                insertEvidenceCommand.Parameters.AddWithValue("@DiscoveryDate", evidencePanel.dtpDiscoveryDate.Value.ToString("yyyy-MM-dd"));
                                insertEvidenceCommand.Parameters.AddWithValue("@Location", evidencePanel.txtLocation.Text);
                                insertEvidenceCommand.Parameters.AddWithValue("@StorageLocation", evidencePanel.txtStorageLocation.Text);
                                insertEvidenceCommand.Parameters.AddWithValue("@AnalysisResult", evidencePanel.txtAnalysisResult.Text);
                                insertEvidenceCommand.ExecuteNonQuery();

                                // Отримуємо ID нового доказу
                                string selectEvidenceIdQuery = "SELECT @@IDENTITY";
                                OleDbCommand selectEvidenceIdCommand = new OleDbCommand(selectEvidenceIdQuery, connection);
                                int newEvidenceId = Convert.ToInt32(selectEvidenceIdCommand.ExecuteScalar());

                                // Додаємо зв'язок між доказом і злочином
                                string insertEvidenceCrimeQuery = @"
                INSERT INTO evidence_crime (evidence_id, crime_id, evidence_date_attachment) 
                VALUES (@EvidenceId, @CrimeId, @DateAttachment)";
                                OleDbCommand insertEvidenceCrimeCommand = new OleDbCommand(insertEvidenceCrimeQuery, connection);
                                insertEvidenceCrimeCommand.Parameters.AddWithValue("@EvidenceId", newEvidenceId);
                                insertEvidenceCrimeCommand.Parameters.AddWithValue("@CrimeId", _crimeId);
                                insertEvidenceCrimeCommand.Parameters.AddWithValue("@DateAttachment", evidencePanel.dtpDateAttachment.Value.ToString("yyyy-MM-dd"));
                                insertEvidenceCrimeCommand.ExecuteNonQuery();
                            }
                            else
                            {
                                // Оновлюємо існуючий доказ
                                string updateEvidenceQuery = @"
                UPDATE evidence 
                SET 
                    evidence_type = @Type, 
                    evidence_description = @Description, 
                    evidence_discovery_date = @DiscoveryDate, 
                    evidence_location = @Location, 
                    evidence_storage_location = @StorageLocation, 
                    evidence_analysis_result = @AnalysisResult 
                WHERE evidence_id = @EvidenceId";

                                OleDbCommand updateEvidenceCommand = new OleDbCommand(updateEvidenceQuery, connection);
                                updateEvidenceCommand.Parameters.AddWithValue("@Type", evidencePanel.cmbType.Text);
                                updateEvidenceCommand.Parameters.AddWithValue("@Description", evidencePanel.txtDescription.Text);
                                updateEvidenceCommand.Parameters.AddWithValue("@DiscoveryDate", evidencePanel.dtpDiscoveryDate.Value.ToString("yyyy-MM-dd"));
                                updateEvidenceCommand.Parameters.AddWithValue("@Location", evidencePanel.txtLocation.Text);
                                updateEvidenceCommand.Parameters.AddWithValue("@StorageLocation", evidencePanel.txtStorageLocation.Text);
                                updateEvidenceCommand.Parameters.AddWithValue("@AnalysisResult", evidencePanel.txtAnalysisResult.Text);
                                updateEvidenceCommand.Parameters.AddWithValue("@EvidenceId", evidencePanel.EvidenceId);
                                updateEvidenceCommand.ExecuteNonQuery();

                                // Оновлюємо зв'язок із таблицею `evidence_crime`
                                string updateEvidenceCrimeQuery = @"
                UPDATE evidence_crime 
                SET evidence_date_attachment = @DateAttachment 
                WHERE evidence_id = @EvidenceId AND crime_id = @CrimeId";

                                OleDbCommand updateEvidenceCrimeCommand = new OleDbCommand(updateEvidenceCrimeQuery, connection);
                                updateEvidenceCrimeCommand.Parameters.AddWithValue("@DateAttachment", evidencePanel.dtpDateAttachment.Value.ToString("yyyy-MM-dd"));
                                updateEvidenceCrimeCommand.Parameters.AddWithValue("@EvidenceId", evidencePanel.EvidenceId);
                                updateEvidenceCrimeCommand.Parameters.AddWithValue("@CrimeId", _crimeId);
                                updateEvidenceCrimeCommand.ExecuteNonQuery();
                            }
                        }
                    }

                    //MessageBox.Show("Дані про докази успішно збережено.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка збереження даних про докази: " + ex.Message);
                }
            }
        }

        private void SaveWantedStatus()
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\ХНУРЕ\База даних\Interpol\Interpol\Interpol.accdb;";
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string getCriminalCrimeIdQuery = @"
            SELECT TOP 1 criminal_crime_id 
            FROM criminal_crime 
            WHERE crime_id = @CrimeId";

                    int criminalCrimeId;
                    using (OleDbCommand getIdCommand = new OleDbCommand(getCriminalCrimeIdQuery, connection))
                    {
                        getIdCommand.Parameters.AddWithValue("@CrimeId", _crimeId);
                        var result = getIdCommand.ExecuteScalar();
                        if (result == null)
                        {
                            MessageBox.Show("Не знайдено відповідного criminal_crime_id.");
                            return;
                        }
                        criminalCrimeId = Convert.ToInt32(result);
                    }

                    string deleteQuery = "DELETE FROM wanted_status WHERE criminal_crime_id = @CriminalCrimeId";
                    using (OleDbCommand deleteCommand = new OleDbCommand(deleteQuery, connection))
                    {
                        deleteCommand.Parameters.AddWithValue("@CriminalCrimeId", criminalCrimeId);
                        deleteCommand.ExecuteNonQuery();
                    }

                    foreach (Control control in tabWanted.Controls)
                    {
                        if (control is Panel wantedPanel)
                        {
                            DateTimePicker dtpStatusDate = wantedPanel.Controls.OfType<DateTimePicker>().FirstOrDefault();
                            TextBox txtWantedCountry = wantedPanel.Controls.OfType<TextBox>().FirstOrDefault(t => t.Name == "txtWantedCountry");
                            TextBox txtIssuingAuthority = wantedPanel.Controls.OfType<TextBox>().FirstOrDefault(t => t.Name == "txtIssuingAuthority");
                            ComboBox cmbStatusType = wantedPanel.Controls.OfType<ComboBox>().FirstOrDefault();

                            if (dtpStatusDate == null || txtWantedCountry == null || txtIssuingAuthority == null || cmbStatusType == null)
                            {
                                MessageBox.Show("Один або кілька полів не знайдено на панелі розшуку.");
                                continue;
                            }

                            string insertQuery = @"
                    INSERT INTO wanted_status (status_date, status_country, issuing_authority, status_type, criminal_crime_id)
                    VALUES (@StatusDate, @StatusCountry, @IssuingAuthority, @StatusType, @CriminalCrimeId)";

                            using (OleDbCommand insertCommand = new OleDbCommand(insertQuery, connection))
                            {
                                insertCommand.Parameters.AddWithValue("@StatusDate", dtpStatusDate.Value.Date);
                                insertCommand.Parameters.AddWithValue("@StatusCountry", txtWantedCountry.Text);
                                insertCommand.Parameters.AddWithValue("@IssuingAuthority", txtIssuingAuthority.Text);
                                insertCommand.Parameters.AddWithValue("@StatusType", cmbStatusType.Text);
                                insertCommand.Parameters.AddWithValue("@CriminalCrimeId", criminalCrimeId);

                                insertCommand.ExecuteNonQuery();
                            }
                        }
                    }

                    //MessageBox.Show("Дані про розшуки успішно збережено.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка збереження даних про розшуки: " + ex.Message);
                }
            }
        }

        private void SaveWarrants()
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\ХНУРЕ\База даних\Interpol\Interpol\Interpol.accdb;";
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    foreach (Control control in tabWarrants.Controls)
                    {
                        if (control is Panel warrantPanel)
                        {
                            // Отримання значень з полів
                            DateTimePicker dtpWarrantIssueDate = warrantPanel.Controls.OfType<DateTimePicker>().FirstOrDefault();
                            TextBox txtWarrantCountry = warrantPanel.Controls.OfType<TextBox>().FirstOrDefault(t => t.Name == "txtWarrantCountry");
                            ComboBox cmbWarrantType = warrantPanel.Controls.OfType<ComboBox>().FirstOrDefault();

                            if (dtpWarrantIssueDate == null || txtWarrantCountry == null || cmbWarrantType == null)
                            {
                                MessageBox.Show("Один або кілька полів не знайдено на панелі ордерів.");
                                continue;
                            }

                            DateTime warrantIssueDate = dtpWarrantIssueDate.Value;
                            string warrantCountry = txtWarrantCountry.Text;
                            string warrantType = cmbWarrantType.Text;

                            // Отримання court_case_id
                            string getCourtCaseIdQuery = @"
                SELECT TOP 1 court_case_id
                FROM court_case
                WHERE criminal_crime_id = (SELECT TOP 1 criminal_crime_id FROM criminal_crime WHERE crime_id = @CrimeId)";

                            OleDbCommand getCourtCaseIdCommand = new OleDbCommand(getCourtCaseIdQuery, connection);
                            getCourtCaseIdCommand.Parameters.AddWithValue("@CrimeId", _crimeId);

                            object courtCaseIdObj = getCourtCaseIdCommand.ExecuteScalar();

                            if (courtCaseIdObj == null)
                            {
                                throw new Exception("Не вдалося знайти відповідний court_case_id.");
                            }

                            int courtCaseId = Convert.ToInt32(courtCaseIdObj);

                            // Перевірка, чи існує ордер
                            string checkWarrantQuery = @"
                SELECT COUNT(*)
                FROM international_warrant
                WHERE warrant_issue_date = @WarrantIssueDate AND court_case_id = @CourtCaseId";

                            OleDbCommand checkWarrantCommand = new OleDbCommand(checkWarrantQuery, connection);
                            checkWarrantCommand.Parameters.AddWithValue("@WarrantIssueDate", warrantIssueDate);
                            checkWarrantCommand.Parameters.AddWithValue("@CourtCaseId", courtCaseId);

                            int existingWarrantCount = (int)checkWarrantCommand.ExecuteScalar();

                            if (existingWarrantCount > 0)
                            {
                                // Якщо ордер вже існує, оновлюємо його
                                string updateWarrantQuery = @"
                    UPDATE international_warrant
                    SET warrant_country = @WarrantCountry, warrant_type = @WarrantType
                    WHERE warrant_issue_date = @WarrantIssueDate AND court_case_id = @CourtCaseId";

                                OleDbCommand updateWarrantCommand = new OleDbCommand(updateWarrantQuery, connection);
                                updateWarrantCommand.Parameters.AddWithValue("@WarrantCountry", warrantCountry);
                                updateWarrantCommand.Parameters.AddWithValue("@WarrantType", warrantType);
                                updateWarrantCommand.Parameters.AddWithValue("@WarrantIssueDate", warrantIssueDate);
                                updateWarrantCommand.Parameters.AddWithValue("@CourtCaseId", courtCaseId);

                                updateWarrantCommand.ExecuteNonQuery();
                            }
                            else
                            {
                                // Якщо ордер не існує, додаємо його
                                string insertWarrantQuery = @"
                    INSERT INTO international_warrant (warrant_issue_date, warrant_country, warrant_type, court_case_id)
                    VALUES (@WarrantIssueDate, @WarrantCountry, @WarrantType, @CourtCaseId)";

                                OleDbCommand insertWarrantCommand = new OleDbCommand(insertWarrantQuery, connection);
                                insertWarrantCommand.Parameters.AddWithValue("@WarrantIssueDate", warrantIssueDate);
                                insertWarrantCommand.Parameters.AddWithValue("@WarrantCountry", warrantCountry);
                                insertWarrantCommand.Parameters.AddWithValue("@WarrantType", warrantType);
                                insertWarrantCommand.Parameters.AddWithValue("@CourtCaseId", courtCaseId);

                                insertWarrantCommand.ExecuteNonQuery();
                            }
                        }
                    }

                    //MessageBox.Show("Дані про ордери успішно збережено.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка збереження даних про ордери: " + ex.Message);
                }
            }
        }

        private void SaveCourtCase()
        {
            if (_courtCaseId == 0)
            {
                MessageBox.Show("Судову справу не знайдено для оновлення.");
                return;
            }

            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\ХНУРЕ\База даних\Interpol\Interpol\Interpol.accdb;";
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Запит для оновлення даних про судову справу
                    string updateCourtCaseQuery = @"
                UPDATE court_case
                SET 
                    decision_number = @DecisionNumber,
                    case_number = @CaseNumber,
                    registration_date = @RegistrationDate,
                    hearing_date = @HearingDate,
                    court_decision_form = @DecisionForm,
                    court_hearing_form = @HearingForm,
                    court_name = @CourtName,
                    case_decision = @CaseDecision
                WHERE 
                    court_case_id = @CourtCaseId";

                    using (OleDbCommand command = new OleDbCommand(updateCourtCaseQuery, connection))
                    {
                        // Додаємо параметри до запиту
                        command.Parameters.AddWithValue("@DecisionNumber", GetControlText("txtDecisionNumber"));
                        command.Parameters.AddWithValue("@CaseNumber", GetControlText("txtCaseNumber"));
                        command.Parameters.AddWithValue("@RegistrationDate", GetControlText("txtRegistrationDate"));
                        command.Parameters.AddWithValue("@HearingDate", GetControlText("txtHearingDate"));
                        command.Parameters.AddWithValue("@DecisionForm", GetControlText("txtCourtDecisionForm"));
                        command.Parameters.AddWithValue("@HearingForm", GetControlText("txtCourtHearingForm"));
                        command.Parameters.AddWithValue("@CourtName", GetControlText("txtCourtName"));
                        command.Parameters.AddWithValue("@CaseDecision", _currentCasePath ?? (object)DBNull.Value); // Якщо PDF немає, зберігаємо NULL
                        command.Parameters.AddWithValue("@CourtCaseId", _courtCaseId);

                        command.ExecuteNonQuery();
                    }

                    //MessageBox.Show("Дані про судову справу успішно збережено.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка збереження даних про судову справу: " + ex.Message);
                }
            }
        }

        // Метод для отримання тексту з TextBox за його іменем
        private string GetControlText(string controlName)
        {
            var control = tabCourtCase.Controls.Find(controlName, true).FirstOrDefault() as TextBox;
            return control?.Text ?? string.Empty;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveCriminalInfo();
            SaveVictims();
            SaveWitnesses();
            SaveEvidence();
            SaveWantedStatus();
            SaveWarrants();
            SaveCourtCase();

            this.Close();
        }
    }
}