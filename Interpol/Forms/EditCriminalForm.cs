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

        //private void LoadVictims()
        //{
        //    string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\ХНУРЕ\База даних\Interpol\Interpol\Interpol.accdb;";
        //    using (OleDbConnection connection = new OleDbConnection(connectionString))
        //    {
        //        try
        //        {
        //            // SQL-запит для отримання інформації про потерпілих
        //            string query = @"
        //        SELECT 
        //            p.person_id,
        //            p.first_name, 
        //            p.last_name, 
        //            p.birth_date, 
        //            p.gender, 
        //            p.birth_location, 
        //            p.last_known_residence, 
        //            p.nationality, 
        //            p.status, 
        //            p.passport, 
        //            p.email_addr, 
        //            p.phone_num, 
        //            p.photo, 
        //            v.victim_testimony, 
        //            v.victim_testimony_date, 
        //            v.victim_injury
        //        FROM 
        //            victim v
        //        LEFT JOIN 
        //            person p ON v.person_id = p.person_id
        //        WHERE 
        //            v.crime_id = @CrimeId";

        //            OleDbCommand command = new OleDbCommand(query, connection);
        //            command.Parameters.AddWithValue("@CrimeId", _crimeId);

        //            connection.Open();
        //            OleDbDataReader reader = command.ExecuteReader();

        //            // Відображення кожного потерпілого
        //            int yOffset = 0; // Відступ для кожного елементу
        //            while (reader.Read())
        //            {
        //                // Панель для кожного потерпілого
        //                Panel victimPanel = new Panel
        //                {
        //                    Size = new Size(600, 480),
        //                    Location = new Point(10, yOffset),
        //                    BorderStyle = BorderStyle.FixedSingle
        //                };

        //                // Додавання текстових полів
        //                victimPanel.Controls.Add(CreateTextBox("txtVictimFirstName", "Ім'я: ", reader["first_name"], 10, 10));
        //                victimPanel.Controls.Add(CreateTextBox("txtVictimLastName", "Прізвище: ", reader["last_name"], 10, 40));
        //                victimPanel.Controls.Add(CreateTextBox("txtVictimBirthDate", "Дата народження: ", reader["birth_date"], 10, 70));
        //                victimPanel.Controls.Add(CreateTextBox("txtVictimGender", "Стать: ", reader["gender"], 10, 100));
        //                victimPanel.Controls.Add(CreateTextBox("txtVictimBirthLocation", "Місце народження: ", reader["birth_location"], 10, 130));
        //                victimPanel.Controls.Add(CreateTextBox("txtVictimResidence", "Місце проживання: ", reader["last_known_residence"], 10, 160));
        //                victimPanel.Controls.Add(CreateTextBox("txtVictimNationality", "Національність: ", reader["nationality"], 10, 190));
        //                victimPanel.Controls.Add(CreateTextBox("txtVictimStatus", "Статус: ", reader["status"], 10, 220));
        //                victimPanel.Controls.Add(CreateTextBox("txtVictimPassport", "Паспорт: ", reader["passport"], 10, 250));
        //                victimPanel.Controls.Add(CreateTextBox("txtVictimEmail", "Email: ", reader["email_addr"], 10, 280));
        //                victimPanel.Controls.Add(CreateTextBox("txtVictimPhone", "Телефон: ", reader["phone_num"], 10, 310));
        //                victimPanel.Controls.Add(CreateTextBox("txtVictimTestimonyDate", "Дата свідчень: ", reader["victim_testimony_date"], 10, 340));
        //                victimPanel.Controls.Add(CreateTextBox("txtVictimInjury", "Ушкодження: ", reader["victim_injury"], 10, 370));

        //                // Додавання PictureBox для фото
        //                PictureBox pbPhoto = new PictureBox
        //                {
        //                    Size = new Size(100, 100),
        //                    Location = new Point(420, 10),
        //                    SizeMode = PictureBoxSizeMode.StretchImage,
        //                    BorderStyle = BorderStyle.FixedSingle
        //                };

        //                if (reader["photo"] != DBNull.Value)
        //                {
        //                    string photoPath = reader["photo"].ToString();
        //                    if (File.Exists(photoPath))
        //                    {
        //                        pbPhoto.Image = Image.FromFile(photoPath);
        //                    }
        //                }

        //                victimPanel.Controls.Add(pbPhoto);

        //                // Кнопка завантаження нового фото
        //                Button btnLoadPhoto = new Button
        //                {
        //                    Text = "Завантажити фото",
        //                    Location = new Point(420, 150),
        //                    Size = new Size(150, 30)
        //                };

        //                btnLoadPhoto.Click += (s, e) =>
        //                {
        //                    using (OpenFileDialog openFileDialog = new OpenFileDialog())
        //                    {
        //                        openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
        //                        openFileDialog.Title = "Оберіть фото";

        //                        if (openFileDialog.ShowDialog() == DialogResult.OK)
        //                        {
        //                            string sourcePath = openFileDialog.FileName;
        //                            string destinationPath = Path.Combine(Application.StartupPath, @"Sources\Images\", Path.GetFileName(sourcePath));

        //                            try
        //                            {
        //                                File.Copy(sourcePath, destinationPath, true);
        //                                pbPhoto.Image = Image.FromFile(destinationPath);
        //                                pbPhoto.Tag = Path.Combine(@"Sources\Images\", Path.GetFileName(sourcePath)); // Зберігаємо шлях
        //                            }
        //                            catch (Exception ex)
        //                            {
        //                                MessageBox.Show("Помилка копіювання файлу: " + ex.Message);
        //                            }
        //                        }
        //                    }
        //                };

        //                victimPanel.Controls.Add(btnLoadPhoto);

        //                // Кнопка для відкриття свідчень
        //                if (reader["victim_testimony"] != DBNull.Value)
        //                {
        //                    string testimonyPath = reader["victim_testimony"].ToString();

        //                    Button btnTestimony = new Button
        //                    {
        //                        Text = "Відкрити свідчення",
        //                        Location = new Point(420, 120),
        //                        Size = new Size(150, 30)
        //                    };

        //                    btnTestimony.Click += (s, e) =>
        //                    {
        //                        if (File.Exists(testimonyPath))
        //                        {
        //                            System.Diagnostics.Process.Start(testimonyPath);
        //                        }
        //                        else
        //                        {
        //                            MessageBox.Show("Файл свідчення не знайдено: " + testimonyPath);
        //                        }
        //                    };

        //                    victimPanel.Controls.Add(btnTestimony);
        //                }

        //                // Кнопка для завантаження нового свідчення
        //                Button btnLoadTestimony = new Button
        //                {
        //                    Text = "Завантажити свідчення",
        //                    Location = new Point(420, 190),
        //                    Size = new Size(150, 30)
        //                };

        //                btnLoadTestimony.Click += (s, e) =>
        //                {
        //                    using (OpenFileDialog openFileDialog = new OpenFileDialog())
        //                    {
        //                        openFileDialog.Filter = "PDF Files|*.pdf";
        //                        openFileDialog.Title = "Оберіть файл свідчень";

        //                        if (openFileDialog.ShowDialog() == DialogResult.OK)
        //                        {
        //                            string sourcePath = openFileDialog.FileName;
        //                            string destinationPath = Path.Combine(Application.StartupPath, @"Sources\PDF\", Path.GetFileName(sourcePath));

        //                            try
        //                            {
        //                                File.Copy(sourcePath, destinationPath, true);
        //                                btnLoadTestimony.Tag = Path.Combine(@"Sources\PDF\", Path.GetFileName(sourcePath)); // Зберігаємо шлях
        //                            }
        //                            catch (Exception ex)
        //                            {
        //                                MessageBox.Show("Помилка копіювання файлу: " + ex.Message);
        //                            }
        //                        }
        //                    }
        //                };

        //                victimPanel.Controls.Add(btnLoadTestimony);

        //                // Додаємо панель до вкладки
        //                tabVictims.Controls.Add(victimPanel);

        //                yOffset += 490; // Збільшуємо відступ для наступної панелі
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show("Помилка завантаження потерпілих: " + ex.Message);
        //        }
        //        finally
        //        {
        //            connection.Close();
        //        }
        //    }
        //}

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
                var newPanel = new VictimPanel(null, tabVictims.Controls.Count * 490, RemoveVictimPanel);
                tabVictims.Controls.Add(newPanel);
                UpdateVictimPanelPositions();
            };

            tabVictims.Controls.Add(btnAddVictim);

            UpdateVictimPanelPositions();
        }

        private void RemoveVictimPanel(VictimPanel panel)
        {
            tabVictims.Controls.Remove(panel);
            UpdateVictimPanelPositions();
        }

        private void UpdateVictimPanelPositions()
        {
            int yOffset = 0; // Початковий відступ

            // Змінюємо позицію всіх панелей типу VictimPanel
            foreach (Control control in tabVictims.Controls)
            {
                if (control is VictimPanel)
                {
                    control.Location = new Point(10, yOffset);
                    yOffset += control.Height + 10; // Додаємо висоту панелі + відступ
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

            public VictimPanel(OleDbDataReader reader, int yOffset, Action<VictimPanel> onDelete)
            {
                // Налаштування панелі
                Size = new Size(600, 480);
                Location = new Point(10, yOffset);
                BorderStyle = BorderStyle.FixedSingle;

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
                                File.Copy(sourcePath, destinationPath, true);
                                pbPhoto.Image = Image.FromFile(destinationPath);
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
                        var witnessPanel = new WitnessPanel(reader, yOffset, RemoveWitnessPanel);
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
            tabWitnesses.Controls.Remove(panel);
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

            private string _pdfPath;

            public WitnessPanel(OleDbDataReader reader, int yOffset, Action<WitnessPanel> onDelete)
            {
                // Налаштування панелі
                Size = new Size(600, 480);
                Location = new Point(10, yOffset);
                BorderStyle = BorderStyle.FixedSingle;

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
                txtTestimonyDate = CreateTextBox("Дата свідчень: ", reader?["witness_testimony_date"], 10, 340);

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
                                File.Copy(sourcePath, destinationPath, true);
                                pbPhoto.Image = Image.FromFile(destinationPath);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Помилка копіювання файлу: " + ex.Message);
                            }
                        }
                    }
                };

                Controls.Add(btnLoadPhoto);

                // Кнопка для завантаження PDF
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
                                _pdfPath = destinationPath;
                                MessageBox.Show("Свідчення завантажено успішно.");
                                btnOpenTestimony.Enabled = true; // Активуємо кнопку відкриття
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Помилка копіювання файлу: " + ex.Message);
                            }
                        }
                    }
                };

                Controls.Add(btnLoadTestimony);

                // Кнопка для відкриття PDF
                btnOpenTestimony = new Button
                {
                    Text = "Відкрити свідчення",
                    Location = new Point(420, 200),
                    Size = new Size(150, 30),
                    Enabled = reader != null && reader["witness_testimony"] != DBNull.Value // Доступна тільки якщо є PDF
                };

                btnOpenTestimony.Click += (s, e) =>
                {
                    if (!string.IsNullOrEmpty(_pdfPath) && File.Exists(_pdfPath))
                    {
                        try
                        {
                            System.Diagnostics.Process.Start(_pdfPath);
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

                if (reader != null && reader["witness_testimony"] != DBNull.Value)
                {
                    _pdfPath = Path.Combine(Application.StartupPath, reader["witness_testimony"].ToString());
                }

                Controls.Add(btnOpenTestimony);

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

        private void LoadEvidence()
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\ХНУРЕ\База даних\Interpol\Interpol\Interpol.accdb;";
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                try
                {
                    string query = @"
            SELECT 
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
            tabEvidence.Controls.Remove(panel);
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

            public EvidencePanel(OleDbDataReader reader, int yOffset, Action<EvidencePanel> onDelete)
            {
                // Налаштування панелі
                Size = new Size(600, 300);
                Location = new Point(10, yOffset);
                BorderStyle = BorderStyle.FixedSingle;

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

        private TextBox CreateTextBox(string name, string labelText, object value, int x, int y)
        {
            // Додаємо мітку
            Label label = new Label
            {
                Text = labelText,
                Location = new Point(x, y),
                AutoSize = true
            };
            tabVictims.Controls.Add(label);

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

        private TextBox CreateTextBox2(string name, string labelText, object value, int x, int y)
        {
            // Додаємо мітку
            Label label = new Label
            {
                Text = labelText,
                Location = new Point(x, y),
                AutoSize = true
            };
            tabWitnesses.Controls.Add(label);

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

        private TextBox CreateTextBox3(string name, string labelText, object value, int x, int y)
        {
            // Додаємо мітку
            Label label = new Label
            {
                Text = labelText,
                Location = new Point(x, y),
                AutoSize = true
            };
            tabEvidence.Controls.Add(label);

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
            LoadVictims();
            LoadWitnesses();
            LoadEvidence();
            LoadWantedStatus();
            LoadWarrants();
            LoadCourtCase();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
