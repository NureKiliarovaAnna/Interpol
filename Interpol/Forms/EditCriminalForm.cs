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

                        // Завантаження фото
                        if (reader["photo"] != DBNull.Value)
                        {
                            string photoPath = Path.Combine(Application.StartupPath, reader["photo"].ToString());
                            if (File.Exists(photoPath))
                            {
                                pbPhoto.Image = Image.FromFile(photoPath);
                                pbPhoto.ImageLocation = photoPath; // Збереження шляху до фото
                            }
                        }
                        else
                        {
                            pbPhoto.Image = null; // Якщо фото немає
                            pbPhoto.ImageLocation = string.Empty;
                        }
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
            public TextBox txtBirthDate;
            public TextBox txtGender;
            public TextBox txtBirthLocation;
            public TextBox txtResidence;
            public TextBox txtNationality;
            public TextBox txtStatus;
            public TextBox txtPassport;
            public TextBox txtEmail;
            public TextBox txtPhone;
            public TextBox txtTestimonyDate;
            public TextBox txtInjury;
            public PictureBox pbPhoto;
            public Button btnDelete;
            public Button btnLoadPhoto;
            public Button btnLoadTestimony;
            public Button btnOpenPdf;

            // Додано поле для збереження ID особи
            public int PersonId { get; private set; } = 0; // Значення за замовчуванням

            // Властивості для збереження даних
            public string TestimonyText => txtTestimonyDate.Text;
            public string InjuryText => txtInjury.Text;
            public string TestimonyDateText => txtTestimonyDate.Text;

            public VictimPanel(OleDbDataReader reader, int yOffset, Action<VictimPanel> onDelete)
            {
                // Налаштування панелі
                Size = new Size(600, 480);
                Location = new Point(10, yOffset);
                BorderStyle = BorderStyle.FixedSingle;

                // Зчитування ID потерпілого, якщо є
                if (reader != null && reader["person_id"] != DBNull.Value)
                {
                    PersonId = Convert.ToInt32(reader["person_id"]);
                }

                // Ініціалізація текстових полів
                txtFirstName = CreateTextBox("Ім'я: ", reader?["first_name"], 10, 10);
                txtLastName = CreateTextBox("Прізвище: ", reader?["last_name"], 10, 40);
                txtBirthDate = CreateTextBox("Дата народження: ", reader?["birth_date"], 10, 70);
                txtGender = CreateTextBox("Стать: ", reader?["gender"], 10, 100);
                txtBirthLocation = CreateTextBox("Місце народження: ", reader?["birth_location"], 10, 130);
                txtResidence = CreateTextBox("Місце проживання: ", reader?["last_known_residence"], 10, 160);
                txtNationality = CreateTextBox("Національність: ", reader?["nationality"], 10, 190);
                txtStatus = CreateTextBox("Статус: ", reader?["status"], 10, 220);
                txtPassport = CreateTextBox("Паспорт: ", reader?["passport"], 10, 250);
                txtEmail = CreateTextBox("Email: ", reader?["email_addr"], 10, 280);
                txtPhone = CreateTextBox("Телефон: ", reader?["phone_num"], 10, 310);
                txtTestimonyDate = CreateTextBox("Дата свідчень: ", reader?["victim_testimony_date"], 10, 340);
                txtInjury = CreateTextBox("Ушкодження: ", reader?["victim_injury"], 10, 370);

                // PictureBox для фото
                pbPhoto = new PictureBox
                {
                    Size = new Size(100, 100),
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

                // Кнопка для завантаження фото
                btnLoadPhoto = new Button
                {
                    Text = "Завантажити фото",
                    Location = new Point(420, 120),
                    Size = new Size(150, 30)
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
                                // Перевіряємо, чи файл вже існує
                                if (!File.Exists(destinationPath))
                                {
                                    File.Copy(sourcePath, destinationPath, true);
                                }

                                // Звільняємо попередній ресурс зображення
                                if (pbPhoto.Image != null)
                                {
                                    pbPhoto.Image.Dispose();
                                }

                                pbPhoto.Image = Image.FromFile(destinationPath);
                                pbPhoto.ImageLocation = destinationPath; // Зберігаємо шлях
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Помилка копіювання файлу: " + ex.Message);
                            }
                        }
                    }
                };

                Controls.Add(btnLoadPhoto);

                // Кнопка для завантаження PDF-файлу
                btnLoadTestimony = new Button
                {
                    Text = "Завантажити свідчення",
                    Location = new Point(420, 160),
                    Size = new Size(150, 30)
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
                                btnOpenPdf.Tag = Path.Combine(@"Sources\PDF\", Path.GetFileName(sourcePath)); // Зберігаємо шлях
                                btnOpenPdf.Enabled = true;
                                MessageBox.Show("Свідчення завантажено успішно.");
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Помилка копіювання файлу: " + ex.Message);
                            }
                        }
                    }
                };

                Controls.Add(btnLoadTestimony);

                // Кнопка для відкриття PDF-файлу
                btnOpenPdf = new Button
                {
                    Text = "Відкрити свідчення",
                    Location = new Point(420, 200),
                    Size = new Size(150, 30),
                    Enabled = false // Спочатку вимкнена
                };

                if (reader != null && reader["victim_testimony"] != DBNull.Value)
                {
                    string testimonyPath = reader["victim_testimony"].ToString();
                    btnOpenPdf.Tag = testimonyPath;
                    btnOpenPdf.Enabled = true;
                }

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
                    Location = new Point(420, 240),
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
                    Location = new Point(x + 150, y),
                    Size = new Size(200, 20)
                };
                Controls.Add(textBox);
                return textBox;
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
            public TextBox txtBirthDate;
            public TextBox txtGender;
            public TextBox txtBirthLocation;
            public TextBox txtResidence;
            public TextBox txtNationality;
            public TextBox txtStatus;
            public TextBox txtPassport;
            public TextBox txtEmail;
            public TextBox txtPhone;
            public TextBox txtTestimonyDate;
            public PictureBox pbPhoto;
            public Button btnDelete;
            public Button btnLoadPhoto;
            public Button btnLoadTestimony;
            public Button btnOpenTestimony;
            public int PersonId { get; private set; }
            public string TestimonyPath
            {
                get => btnOpenTestimony.Tag?.ToString(); // Отримуємо значення з Tag
                set
                {
                    btnOpenTestimony.Tag = value; // Встановлюємо значення в Tag
                    btnOpenTestimony.Enabled = !string.IsNullOrEmpty(value) && File.Exists(value); // Активуємо кнопку, якщо шлях валідний
                }
            }

            public WitnessPanel(OleDbDataReader reader, int yOffset, Action<WitnessPanel> onDelete)
            {
                Size = new Size(600, 480);
                Location = new Point(10, yOffset);
                BorderStyle = BorderStyle.FixedSingle;

                PersonId = reader != null && reader["person_id"] != DBNull.Value ? Convert.ToInt32(reader["person_id"]) : 0;

                txtFirstName = CreateTextBox("Ім'я: ", reader?["first_name"], 10, 10);
                txtLastName = CreateTextBox("Прізвище: ", reader?["last_name"], 10, 40);
                txtBirthDate = CreateTextBox("Дата народження: ", reader?["birth_date"], 10, 70);
                txtGender = CreateTextBox("Стать: ", reader?["gender"], 10, 100);
                txtBirthLocation = CreateTextBox("Місце народження: ", reader?["birth_location"], 10, 130);
                txtResidence = CreateTextBox("Місце проживання: ", reader?["last_known_residence"], 10, 160);
                txtNationality = CreateTextBox("Національність: ", reader?["nationality"], 10, 190);
                txtStatus = CreateTextBox("Статус: ", reader?["status"], 10, 220);
                txtPassport = CreateTextBox("Паспорт: ", reader?["passport"], 10, 250);
                txtEmail = CreateTextBox("Email: ", reader?["email_addr"], 10, 280);
                txtPhone = CreateTextBox("Телефон: ", reader?["phone_num"], 10, 310);
                txtTestimonyDate = CreateTextBox("Дата свідчень: ", reader?["witness_testimony_date"], 10, 340);

                pbPhoto = new PictureBox
                {
                    Size = new Size(100, 100),
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
                    Text = "Завантажити фото",
                    Location = new Point(420, 120),
                    Size = new Size(150, 30)
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
                    Text = "Завантажити свідчення",
                    Location = new Point(420, 160),
                    Size = new Size(150, 30)
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
                                btnOpenTestimony.Tag = Path.Combine(@"Sources\PDF\", Path.GetFileName(sourcePath));
                                btnOpenTestimony.Enabled = true;
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
                    Text = "Відкрити свідчення",
                    Location = new Point(420, 200),
                    Size = new Size(150, 30),
                    Enabled = false
                };

                if (reader != null && reader["witness_testimony"] != DBNull.Value)
                {
                    string testimonyPath = reader["witness_testimony"].ToString();
                    if (!Path.IsPathRooted(testimonyPath))
                    {
                        testimonyPath = Path.Combine(Application.StartupPath, testimonyPath);
                    }
                    btnOpenTestimony.Tag = testimonyPath;
                    btnOpenTestimony.Enabled = File.Exists(testimonyPath);
                }

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
                    Location = new Point(420, 240),
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
                    Location = new Point(x + 150, y),
                    Size = new Size(200, 20)
                };
                Controls.Add(textBox);
                return textBox;
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
            public TextBox txtType;
            public TextBox txtDescription;
            public TextBox txtDiscoveryDate;
            public TextBox txtLocation;
            public TextBox txtStorageLocation;
            public TextBox txtAnalysisResult;
            public TextBox txtDateAttachment;
            public Button btnDelete;

            public int EvidenceId { get; private set; }

            public EvidencePanel(OleDbDataReader reader, int yOffset, Action<EvidencePanel> onDelete)
            {
                Size = new Size(600, 300);
                Location = new Point(10, yOffset);
                BorderStyle = BorderStyle.FixedSingle;

                // Зчитуємо EvidenceId, якщо є
                if (reader != null && reader["evidence_id"] != DBNull.Value)
                {
                    EvidenceId = Convert.ToInt32(reader["evidence_id"]);
                }

                // Ініціалізація текстових полів
                txtType = CreateTextBox("Тип доказу: ", reader?["evidence_type"], 10, 10);
                txtDescription = CreateTextBox("Опис: ", reader?["evidence_description"], 10, 40);
                txtDiscoveryDate = CreateTextBox("Дата виявлення: ", reader?["evidence_discovery_date"], 10, 70);
                txtLocation = CreateTextBox("Місце виявлення: ", reader?["evidence_location"], 10, 100);
                txtStorageLocation = CreateTextBox("Місце зберігання: ", reader?["evidence_storage_location"], 10, 130);
                txtAnalysisResult = CreateTextBox("Результат аналізу: ", reader?["evidence_analysis_result"], 10, 160);
                txtDateAttachment = CreateTextBox("Дата додавання до злочину: ", reader?["evidence_date_attachment"], 10, 190);

                // Кнопка видалення панелі
                btnDelete = new Button
                {
                    Text = "Видалити",
                    Location = new Point(420, 240),
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
                    Location = new Point(x + 150, y),
                    Size = new Size(400, 20)
                };
                Controls.Add(textBox);
                return textBox;
            }
        }

        private void LoadWantedStatus()
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\ХНУРЕ\База даних\Interpol\Interpol\Interpol.accdb;";
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                try
                {
                    // Запит для отримання даних розшуку
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

                    // Відображення кожного розшуку
                    int yOffset = 0; // Відступ для кожного елементу
                    while (reader.Read())
                    {
                        // Створюємо панель для кожного розшуку
                        Panel wantedPanel = new Panel
                        {
                            Size = new Size(600, 200),
                            Location = new Point(10, yOffset),
                            BorderStyle = BorderStyle.FixedSingle
                        };

                        // Створюємо текстові поля
                        wantedPanel.Controls.Add(CreateTextBox4("txtWantedStatusDate", "Дата статусу: ", reader["status_date"], 10, 10));
                        wantedPanel.Controls.Add(CreateTextBox4("txtWantedCountry", "Країна розшуку: ", reader["status_country"], 10, 40));
                        wantedPanel.Controls.Add(CreateTextBox4("txtIssuingAuthority", "Орган, що видав розшук: ", reader["issuing_authority"], 10, 70));
                        wantedPanel.Controls.Add(CreateTextBox4("txtStatusType", "Тип статусу: ", reader["status_type"], 10, 100));

                        // Додаємо панель до вкладки
                        tabWanted.Controls.Add(wantedPanel);

                        yOffset += 210; // Збільшуємо відступ для наступної панелі
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка завантаження розшуків: " + ex.Message);
                }
                finally
                {
                    connection.Close();
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

                        int yOffset = 0; // Відступ для кожного елементу
                        while (warrantReader.Read())
                        {
                            // Створюємо панель для кожного ордера
                            Panel warrantPanel = new Panel
                            {
                                Size = new Size(600, 150),
                                Location = new Point(10, yOffset),
                                BorderStyle = BorderStyle.FixedSingle
                            };

                            // Створюємо текстові поля
                            warrantPanel.Controls.Add(CreateTextBox5("txtWarrantIssueDate", "Дата видачі ордера: ", warrantReader["warrant_issue_date"], 10, 10));
                            warrantPanel.Controls.Add(CreateTextBox5("txtWarrantCountry", "Країна видачі: ", warrantReader["warrant_country"], 10, 40));
                            warrantPanel.Controls.Add(CreateTextBox5("txtWarrantType", "Тип ордера: ", warrantReader["warrant_type"], 10, 70));

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
                finally
                {
                    connection.Close();
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
                            Size = new Size(600, 350),
                            Location = new Point(10, 10),
                            BorderStyle = BorderStyle.FixedSingle
                        };

                        courtCasePanel.Controls.Add(CreateTextBox6("txtDecisionNumber", "Номер рішення: ", reader["decision_number"], 10, 10));
                        courtCasePanel.Controls.Add(CreateTextBox6("txtCaseNumber", "Номер справи: ", reader["case_number"], 10, 40));
                        courtCasePanel.Controls.Add(CreateTextBox6("txtRegistrationDate", "Дата реєстрації: ", reader["registration_date"], 10, 70));
                        courtCasePanel.Controls.Add(CreateTextBox6("txtHearingDate", "Дата слухання: ", reader["hearing_date"], 10, 100));
                        courtCasePanel.Controls.Add(CreateTextBox6("txtCourtDecisionForm", "Форма рішення: ", reader["court_decision_form"], 10, 130));
                        courtCasePanel.Controls.Add(CreateTextBox6("txtCourtHearingForm", "Форма слухання: ", reader["court_hearing_form"], 10, 160));
                        courtCasePanel.Controls.Add(CreateTextBox6("txtCourtName", "Назва суду: ", reader["court_name"], 10, 190));

                        Button btnOpenCase = new Button
                        {
                            Text = "Відкрити судову справу",
                            Location = new Point(10, 260),
                            Size = new Size(200, 30),
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
                            Text = "Завантажити нову справу",
                            Location = new Point(220, 260),
                            Size = new Size(200, 30)
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

        private TextBox CreateTextBox4(string name, string labelText, object value, int x, int y)
        {
            // Додаємо мітку
            Label label = new Label
            {
                Text = labelText,
                Location = new Point(x, y),
                AutoSize = true
            };
            tabWanted.Controls.Add(label);

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

        private TextBox CreateTextBox5(string name, string labelText, object value, int x, int y)
        {
            // Додаємо мітку
            Label label = new Label
            {
                Text = labelText,
                Location = new Point(x, y),
                AutoSize = true
            };
            tabWarrants.Controls.Add(label);

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

        private TextBox CreateTextBox6(string name, string labelText, object value, int x, int y)
        {
            // Додаємо мітку
            Label label = new Label
            {
                Text = labelText,
                Location = new Point(x, y),
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
                        command.Parameters.AddWithValue("@BirthDate", txtBirthDate.Text);
                        command.Parameters.AddWithValue("@BirthLocation", txtBirthLocation.Text);
                        command.Parameters.AddWithValue("@Gender", txtGender.Text);
                        command.Parameters.AddWithValue("@Residence", txtResidence.Text);
                        command.Parameters.AddWithValue("@Nationality", txtNationality.Text);
                        command.Parameters.AddWithValue("@Status", txtStatus.Text);
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

                    MessageBox.Show("Дані про злочинця успішно збережено.");
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
                                insertPersonCommand.Parameters.AddWithValue("@BirthDate", victimPanel.txtBirthDate.Text);
                                insertPersonCommand.Parameters.AddWithValue("@Gender", victimPanel.txtGender.Text);
                                insertPersonCommand.Parameters.AddWithValue("@BirthLocation", victimPanel.txtBirthLocation.Text);
                                insertPersonCommand.Parameters.AddWithValue("@Residence", victimPanel.txtResidence.Text);
                                insertPersonCommand.Parameters.AddWithValue("@Nationality", victimPanel.txtNationality.Text);
                                insertPersonCommand.Parameters.AddWithValue("@Status", victimPanel.txtStatus.Text);
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
                                insertVictimCommand.Parameters.AddWithValue("@TestimonyDate", victimPanel.txtTestimonyDate.Text);
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
                                updatePersonCommand.Parameters.AddWithValue("@BirthDate", victimPanel.txtBirthDate.Text);
                                updatePersonCommand.Parameters.AddWithValue("@Gender", victimPanel.txtGender.Text);
                                updatePersonCommand.Parameters.AddWithValue("@BirthLocation", victimPanel.txtBirthLocation.Text);
                                updatePersonCommand.Parameters.AddWithValue("@Residence", victimPanel.txtResidence.Text);
                                updatePersonCommand.Parameters.AddWithValue("@Nationality", victimPanel.txtNationality.Text);
                                updatePersonCommand.Parameters.AddWithValue("@Status", victimPanel.txtStatus.Text);
                                updatePersonCommand.Parameters.AddWithValue("@Passport", victimPanel.txtPassport.Text);
                                updatePersonCommand.Parameters.AddWithValue("@Email", victimPanel.txtEmail.Text);
                                updatePersonCommand.Parameters.AddWithValue("@Phone", victimPanel.txtPhone.Text);
                                updatePersonCommand.Parameters.AddWithValue("@PhotoPath", victimPanel.pbPhoto.ImageLocation ?? "");
                                updatePersonCommand.Parameters.AddWithValue("@PersonId", victimPanel.PersonId);
                                updatePersonCommand.ExecuteNonQuery();
                            }
                        }
                    }

                    MessageBox.Show("Дані про потерпілих успішно збережено.");
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
                                insertPersonCommand.Parameters.AddWithValue("@BirthDate", witnessPanel.txtBirthDate.Text);
                                insertPersonCommand.Parameters.AddWithValue("@Gender", witnessPanel.txtGender.Text);
                                insertPersonCommand.Parameters.AddWithValue("@BirthLocation", witnessPanel.txtBirthLocation.Text);
                                insertPersonCommand.Parameters.AddWithValue("@Residence", witnessPanel.txtResidence.Text);
                                insertPersonCommand.Parameters.AddWithValue("@Nationality", witnessPanel.txtNationality.Text);
                                insertPersonCommand.Parameters.AddWithValue("@Status", witnessPanel.txtStatus.Text);
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
                                insertWitnessCommand.Parameters.AddWithValue("@TestimonyDate", witnessPanel.txtTestimonyDate.Text);
                                insertWitnessCommand.ExecuteNonQuery();
                            }
                            else
                            {
                                // Оновлення існуючої особи
                                string updateWitnessQuery = @"
                        UPDATE witness 
                        SET 
                            witness_testimony = @TestimonyPath, 
                            witness_testimony_date = @TestimonyDate 
                        WHERE person_id = @PersonId AND crime_id = @CrimeId";
                                OleDbCommand updateWitnessCommand = new OleDbCommand(updateWitnessQuery, connection);
                                updateWitnessCommand.Parameters.AddWithValue("@TestimonyPath", relativeTestimonyPath);
                                updateWitnessCommand.Parameters.AddWithValue("@TestimonyDate", witnessPanel.txtTestimonyDate.Text);
                                updateWitnessCommand.Parameters.AddWithValue("@PersonId", witnessPanel.PersonId);
                                updateWitnessCommand.Parameters.AddWithValue("@CrimeId", _crimeId);
                                updateWitnessCommand.ExecuteNonQuery();
                            }
                        }
                    }

                    MessageBox.Show("Дані про свідків успішно збережено.");
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
                                insertEvidenceCommand.Parameters.AddWithValue("@Type", evidencePanel.txtType.Text);
                                insertEvidenceCommand.Parameters.AddWithValue("@Description", evidencePanel.txtDescription.Text);
                                insertEvidenceCommand.Parameters.AddWithValue("@DiscoveryDate", evidencePanel.txtDiscoveryDate.Text);
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
                                insertEvidenceCrimeCommand.Parameters.AddWithValue("@DateAttachment", evidencePanel.txtDateAttachment.Text);
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
                                updateEvidenceCommand.Parameters.AddWithValue("@Type", evidencePanel.txtType.Text);
                                updateEvidenceCommand.Parameters.AddWithValue("@Description", evidencePanel.txtDescription.Text);
                                updateEvidenceCommand.Parameters.AddWithValue("@DiscoveryDate", evidencePanel.txtDiscoveryDate.Text);
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
                                updateEvidenceCrimeCommand.Parameters.AddWithValue("@DateAttachment", evidencePanel.txtDateAttachment.Text);
                                updateEvidenceCrimeCommand.Parameters.AddWithValue("@EvidenceId", evidencePanel.EvidenceId);
                                updateEvidenceCrimeCommand.Parameters.AddWithValue("@CrimeId", _crimeId);
                                updateEvidenceCrimeCommand.ExecuteNonQuery();
                            }
                        }
                    }

                    MessageBox.Show("Дані про докази успішно збережено.");
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

                    // Отримуємо criminal_crime_id
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

                    // Очищуємо попередні записи
                    string deleteQuery = "DELETE FROM wanted_status WHERE criminal_crime_id = @CriminalCrimeId";
                    using (OleDbCommand deleteCommand = new OleDbCommand(deleteQuery, connection))
                    {
                        deleteCommand.Parameters.AddWithValue("@CriminalCrimeId", criminalCrimeId);
                        deleteCommand.ExecuteNonQuery();
                    }

                    // Додаємо нові записи
                    foreach (Control control in tabWanted.Controls)
                    {
                        if (control is Panel wantedPanel)
                        {
                            // Отримуємо дані з полів
                            string statusDate = GetTextBoxValue(wantedPanel, "txtWantedStatusDate");
                            string statusCountry = GetTextBoxValue(wantedPanel, "txtWantedCountry");
                            string issuingAuthority = GetTextBoxValue(wantedPanel, "txtIssuingAuthority");
                            string statusType = GetTextBoxValue(wantedPanel, "txtStatusType");

                            // Запит для вставки
                            string insertQuery = @"
                        INSERT INTO wanted_status (status_date, status_country, issuing_authority, status_type, criminal_crime_id)
                        VALUES (@StatusDate, @StatusCountry, @IssuingAuthority, @StatusType, @CriminalCrimeId)";

                            using (OleDbCommand insertCommand = new OleDbCommand(insertQuery, connection))
                            {
                                insertCommand.Parameters.AddWithValue("@StatusDate", string.IsNullOrEmpty(statusDate) ? DBNull.Value : (object)statusDate);
                                insertCommand.Parameters.AddWithValue("@StatusCountry", statusCountry);
                                insertCommand.Parameters.AddWithValue("@IssuingAuthority", issuingAuthority);
                                insertCommand.Parameters.AddWithValue("@StatusType", statusType);
                                insertCommand.Parameters.AddWithValue("@CriminalCrimeId", criminalCrimeId);

                                insertCommand.ExecuteNonQuery();
                            }
                        }
                    }

                    MessageBox.Show("Дані про розшуки успішно збережено.");
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
                            DateTime warrantIssueDate = DateTime.Parse(((TextBox)warrantPanel.Controls["txtWarrantIssueDate"]).Text);
                            string warrantCountry = ((TextBox)warrantPanel.Controls["txtWarrantCountry"]).Text;
                            string warrantType = ((TextBox)warrantPanel.Controls["txtWarrantType"]).Text;

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

                    MessageBox.Show("Дані про ордери успішно збережено.");
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

                    MessageBox.Show("Дані про судову справу успішно збережено.");
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

        // Метод для отримання значення з текстового поля у панелі
        private string GetTextBoxValue(Panel panel, string textBoxName)
        {
            foreach (Control control in panel.Controls)
            {
                if (control is TextBox textBox && textBox.Name == textBoxName)
                {
                    return textBox.Text;
                }
            }
            return string.Empty;
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