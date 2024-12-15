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
using static Interpol.Forms.EditCriminalForm;

namespace Interpol.Forms
{
    public partial class AddCriminalForm : Form
    {
        private int _crimeId;
        private int _criminalId;
        private int _criminalCrimeId;

        public AddCriminalForm()
        {
            InitializeComponent();

            InitializeCriminalInfo();
            InitializeCrimeInfo();
            InitializeVictimsTab();
            LoadWitnesses();
            LoadEvidence();
            LoadWantedStatus();
            LoadWarrants();
            LoadCourtCase();

            CreateNewCrimeRecord();
            CreateNewCriminalCrimeRecord();
        }

        private void CreateNewCrimeRecord()
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\ХНУРЕ\База даних\Interpol\Interpol\Interpol.accdb;";
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Створення нового запису в таблиці `crime`
                    string insertCrimeQuery = @"
                INSERT INTO crime (crime_type, crime_location, crime_method, investigations_status)
                VALUES (NULL, NULL, NULL, NULL)";

                    using (OleDbCommand command = new OleDbCommand(insertCrimeQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    // Отримання ID нового запису
                    string getLastCrimeIdQuery = "SELECT @@IDENTITY";
                    using (OleDbCommand command = new OleDbCommand(getLastCrimeIdQuery, connection))
                    {
                        _crimeId = Convert.ToInt32(command.ExecuteScalar());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка створення Crime ID: {ex.Message}");
                }
            }
        }

        private void CreateNewCriminalCrimeRecord()
        {
            if (_crimeId == 0)
            {
                MessageBox.Show("Не знайдено Crime ID. Перевірте створення злочину.");
                return;
            }

            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\ХНУРЕ\База даних\Interpol\Interpol\Interpol.accdb;";
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string insertCriminalCrimeQuery = @"
            INSERT INTO criminal_crime (crime_date, criminal_degree_participation, crime_id, criminal_id)
            VALUES (NULL, NULL, @CrimeId, NULL)";

                    using (OleDbCommand command = new OleDbCommand(insertCriminalCrimeQuery, connection))
                    {
                        command.Parameters.AddWithValue("@CrimeId", _crimeId);
                        command.ExecuteNonQuery();
                    }

                    string getLastCriminalCrimeIdQuery = "SELECT @@IDENTITY";
                    using (OleDbCommand command = new OleDbCommand(getLastCriminalCrimeIdQuery, connection))
                    {
                        _criminalCrimeId = Convert.ToInt32(command.ExecuteScalar());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка створення Criminal_Crime ID: {ex.Message}");
                }
            }
        }

        private void InitializeCriminalInfo()
        {
            // Очистка текстових полів
            txtFirstName.Text = "";
            txtLastName.Text = "";
            dtpBirthDate.Value = DateTime.Now;
            txtBirthLocation.Text = "";
            txtResidence.Text = "";
            txtNationality.Text = "";
            txtPassport.Text = "";
            txtEmail.Text = "";
            txtPhone.Text = "";
            txtNickname.Text = "";
            txtDistinctiveFeatures.Text = "";
            txtArticle.Text = "";

            // Ініціалізація ComboBox
            cmbGender.SelectedIndex = -1;
            cmbStatus.SelectedIndex = -1;

            // Очистка фото
            pbPhoto.Image = null;
            pbPhoto.ImageLocation = string.Empty;
        }

        private void InitializeCrimeInfo()
        {
            // Очистка текстових полів
            dtpCrimeDate.Value = DateTime.Now;
            txtCrimeLocation.Text = "";
            txtCrimeMethod.Text = "";

            // Ініціалізація ComboBox
            cmbCrimeType.SelectedIndex = -1;
            cmbDegreeParticipation.SelectedIndex = -1;
            cmbInvestigationStatus.SelectedIndex = -1;
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
                    string destinationDirectory = Path.Combine(Application.StartupPath, @"Sources\Images\");

                    try
                    {
                        // Створюємо папку, якщо вона не існує
                        if (!Directory.Exists(destinationDirectory))
                        {
                            Directory.CreateDirectory(destinationDirectory);
                        }

                        string destinationPath = Path.Combine(destinationDirectory, destinationFileName);

                        // Перевірка та копіювання файлу
                        if (!File.Exists(destinationPath))
                        {
                            File.Copy(sourcePath, destinationPath);
                        }

                        // Оновлення шляху та зображення
                        txtPhotoPath.Text = Path.Combine(@"Sources\Images\", destinationFileName);
                        pbPhoto.Image?.Dispose(); // Звільнення ресурсу, якщо вже є зображення
                        pbPhoto.Image = Image.FromFile(destinationPath);
                        pbPhoto.ImageLocation = destinationPath;
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

        private void SaveCriminalInfo()
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\ХНУРЕ\База даних\Interpol\Interpol\Interpol.accdb;";
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Копіювання фото, якщо воно вибране
                    string relativePhotoPath = string.Empty;
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

                    // 1. Збереження запису в `person`
                    int newPersonId;
                    string insertPersonQuery = @"
        INSERT INTO person 
        (first_name, last_name, birth_date, birth_location, gender, last_known_residence, nationality, status, passport, email_addr, phone_num, photo)
        VALUES 
        (@FirstName, @LastName, @BirthDate, @BirthLocation, @Gender, @Residence, @Nationality, @Status, @Passport, @Email, @Phone, @PhotoPath)";
                    using (OleDbCommand personCommand = new OleDbCommand(insertPersonQuery, connection))
                    {
                        personCommand.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                        personCommand.Parameters.AddWithValue("@LastName", txtLastName.Text);
                        personCommand.Parameters.AddWithValue("@BirthDate", dtpBirthDate.Value.ToString("yyyy-MM-dd"));
                        personCommand.Parameters.AddWithValue("@BirthLocation", txtBirthLocation.Text);
                        personCommand.Parameters.AddWithValue("@Gender", cmbGender.SelectedItem?.ToString() ?? DBNull.Value.ToString());
                        personCommand.Parameters.AddWithValue("@Residence", txtResidence.Text);
                        personCommand.Parameters.AddWithValue("@Nationality", txtNationality.Text);
                        personCommand.Parameters.AddWithValue("@Status", cmbStatus.SelectedItem?.ToString() ?? DBNull.Value.ToString());
                        personCommand.Parameters.AddWithValue("@Passport", txtPassport.Text);
                        personCommand.Parameters.AddWithValue("@Email", txtEmail.Text);
                        personCommand.Parameters.AddWithValue("@Phone", txtPhone.Text);
                        personCommand.Parameters.AddWithValue("@PhotoPath", relativePhotoPath);

                        personCommand.ExecuteNonQuery();
                        newPersonId = Convert.ToInt32(new OleDbCommand("SELECT @@IDENTITY", connection).ExecuteScalar());
                    }

                    // 2. Створення запису в `criminal`
                    int newCriminalId;
                    string insertCriminalQuery = @"
        INSERT INTO criminal 
        (criminal_nickname, criminal_distinctive_features, article_of_accusation, person_id)
        VALUES 
        (@Nickname, @DistinctiveFeatures, @Article, @PersonId)";
                    using (OleDbCommand criminalCommand = new OleDbCommand(insertCriminalQuery, connection))
                    {
                        criminalCommand.Parameters.AddWithValue("@Nickname", txtNickname.Text);
                        criminalCommand.Parameters.AddWithValue("@DistinctiveFeatures", txtDistinctiveFeatures.Text);
                        criminalCommand.Parameters.AddWithValue("@Article", txtArticle.Text);
                        criminalCommand.Parameters.AddWithValue("@PersonId", newPersonId);

                        criminalCommand.ExecuteNonQuery();
                        newCriminalId = Convert.ToInt32(new OleDbCommand("SELECT @@IDENTITY", connection).ExecuteScalar());
                    }

                    // 3. Оновлення запису в `criminal_crime`
                    string updateCriminalCrimeQuery = @"
        UPDATE criminal_crime 
        SET criminal_id = @CriminalId, 
            crime_date = @CrimeDate, 
            criminal_degree_participation = @DegreeParticipation
        WHERE criminal_crime_id = @CriminalCrimeId";
                    using (OleDbCommand updateCommand = new OleDbCommand(updateCriminalCrimeQuery, connection))
                    {
                        updateCommand.Parameters.AddWithValue("@CriminalId", newCriminalId);
                        updateCommand.Parameters.AddWithValue("@CrimeDate", dtpCrimeDate.Value.ToString("yyyy-MM-dd"));
                        updateCommand.Parameters.AddWithValue("@DegreeParticipation", cmbDegreeParticipation.SelectedItem?.ToString() ?? DBNull.Value.ToString());
                        updateCommand.Parameters.AddWithValue("@CriminalCrimeId", _criminalCrimeId);
                        updateCommand.ExecuteNonQuery();
                    }

                    string insertCrimeQuery = @"
INSERT INTO crime 
(crime_type, crime_location, crime_method, investigations_status) 
VALUES 
(@CrimeType, @CrimeLocation, @CrimeMethod, @InvestigationStatus)";

                    using (OleDbCommand crimeCommand = new OleDbCommand(insertCrimeQuery, connection))
                    {
                        crimeCommand.Parameters.AddWithValue("@CrimeType", cmbCrimeType.SelectedItem?.ToString() ?? DBNull.Value.ToString());
                        crimeCommand.Parameters.AddWithValue("@CrimeLocation", txtCrimeLocation.Text);
                        crimeCommand.Parameters.AddWithValue("@CrimeMethod", txtCrimeMethod.Text);
                        crimeCommand.Parameters.AddWithValue("@InvestigationStatus", cmbInvestigationStatus.SelectedItem?.ToString() ?? DBNull.Value.ToString());

                        crimeCommand.ExecuteNonQuery();
                    }

                    //MessageBox.Show("Злочинець успішно збережений.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка збереження даних: {ex.Message}");
                }
            }
        }

        private void InitializeVictimsTab()
        {
            // Кнопка додавання нового потерпілого
            Button btnAddVictim = new Button
            {
                Text = "Додати потерпілого",
                Location = new Point(10, 10), // Перший відступ
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
            UpdateVictimPanelPositions(); // Ініціалізація розташування панелей
        }

        private void RemoveVictimPanel(VictimPanel panel)
        {
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

        private void SaveVictims()
        {
            if (_crimeId == 0)
            {
                MessageBox.Show("Не знайдено Crime ID. Будь ласка, спершу збережіть інформацію про злочин.");
                return;
            }

            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\ХНУРЕ\База даних\Interpol\Interpol\Interpol.accdb;";
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    foreach (Control control in tabVictims.Controls)
                    {
                        if (control is VictimPanel victimPanel)
                        {
                            // Вставка нового запису в таблицю person
                            string insertPersonQuery = @"
                        INSERT INTO person 
                        (first_name, last_name, birth_date, gender, birth_location, 
                         last_known_residence, nationality, status, passport, email_addr, 
                         phone_num, photo) 
                        VALUES 
                        (@FirstName, @LastName, @BirthDate, @Gender, @BirthLocation, 
                         @Residence, @Nationality, @Status, @Passport, @Email, 
                         @Phone, @PhotoPath)";
                            using (OleDbCommand insertPersonCommand = new OleDbCommand(insertPersonQuery, connection))
                            {
                                insertPersonCommand.Parameters.AddWithValue("@FirstName", victimPanel.txtFirstName.Text);
                                insertPersonCommand.Parameters.AddWithValue("@LastName", victimPanel.txtLastName.Text);
                                insertPersonCommand.Parameters.AddWithValue("@BirthDate", victimPanel.dtpBirthDate.Value.ToString("yyyy-MM-dd"));
                                insertPersonCommand.Parameters.AddWithValue("@Gender", victimPanel.cmbGender.SelectedItem?.ToString() ?? DBNull.Value.ToString());
                                insertPersonCommand.Parameters.AddWithValue("@BirthLocation", victimPanel.txtBirthLocation.Text);
                                insertPersonCommand.Parameters.AddWithValue("@Residence", victimPanel.txtResidence.Text);
                                insertPersonCommand.Parameters.AddWithValue("@Nationality", victimPanel.txtNationality.Text);
                                insertPersonCommand.Parameters.AddWithValue("@Status", victimPanel.cmbStatus.SelectedItem?.ToString() ?? DBNull.Value.ToString());
                                insertPersonCommand.Parameters.AddWithValue("@Passport", victimPanel.txtPassport.Text);
                                insertPersonCommand.Parameters.AddWithValue("@Email", victimPanel.txtEmail.Text);
                                insertPersonCommand.Parameters.AddWithValue("@Phone", victimPanel.txtPhone.Text);
                                insertPersonCommand.Parameters.AddWithValue("@PhotoPath", victimPanel.pbPhoto.ImageLocation ?? "");

                                insertPersonCommand.ExecuteNonQuery();
                            }

                            // Отримуємо `person_id`
                            int newPersonId = Convert.ToInt32(new OleDbCommand("SELECT @@IDENTITY", connection).ExecuteScalar());

                            // Вставка запису в таблицю victim
                            string insertVictimQuery = @"
                        INSERT INTO victim 
                        (person_id, crime_id, victim_testimony, victim_testimony_date, victim_injury) 
                        VALUES 
                        (@PersonId, @CrimeId, @TestimonyPath, @TestimonyDate, @Injury)";
                            using (OleDbCommand insertVictimCommand = new OleDbCommand(insertVictimQuery, connection))
                            {
                                insertVictimCommand.Parameters.AddWithValue("@PersonId", newPersonId);
                                insertVictimCommand.Parameters.AddWithValue("@CrimeId", _crimeId); // Перевірити, чи `_crimeId` ініціалізований
                                insertVictimCommand.Parameters.AddWithValue("@TestimonyPath", victimPanel.btnOpenPdf.Tag?.ToString() ?? "");
                                insertVictimCommand.Parameters.AddWithValue("@TestimonyDate", victimPanel.dtpTestimonyDate.Value.ToString("yyyy-MM-dd"));
                                insertVictimCommand.Parameters.AddWithValue("@Injury", victimPanel.txtInjury.Text);

                                insertVictimCommand.ExecuteNonQuery();
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

        private void LoadWitnesses()
        {
            // Очищуємо вкладку свідків перед завантаженням
            tabWitnesses.Controls.Clear();

            // Кнопка додавання нового свідка
            Button btnAddWitness = new Button
            {
                Text = "Додати свідка",
                Location = new Point(10, 10),
                Size = new Size(200, 30)
            };

            btnAddWitness.Click += (s, e) =>
            {
                // Додаємо нову панель WitnessPanel для введення даних
                var newPanel = new WitnessPanel(null, tabWitnesses.Controls.Count * 490, RemoveWitnessPanel);
                tabWitnesses.Controls.Add(newPanel);
                UpdateWitnessPanelPositions();
            };

            tabWitnesses.Controls.Add(btnAddWitness);

            UpdateWitnessPanelPositions();
        }

        private void RemoveWitnessPanel(WitnessPanel panel)
        {
            // Видалення панелі з вкладки
            tabWitnesses.Controls.Remove(panel);
            panel.Dispose();
            UpdateWitnessPanelPositions();
        }

        private void UpdateWitnessPanelPositions()
        {
            int yOffset = 10;

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

        private void SaveWitnesses()
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\ХНУРЕ\База даних\Interpol\Interpol\Interpol.accdb;";
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Збереження нових свідків
                    foreach (Control control in tabWitnesses.Controls)
                    {
                        if (control is WitnessPanel witnessPanel)
                        {
                            string relativeTestimonyPath = string.Empty;

                            // Збереження свідчень
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

                            // Отримуємо ID нової особи
                            string selectPersonIdQuery = "SELECT @@IDENTITY";
                            OleDbCommand selectPersonIdCommand = new OleDbCommand(selectPersonIdQuery, connection);
                            int newPersonId = Convert.ToInt32(selectPersonIdCommand.ExecuteScalar());

                            // Додавання запису про свідка
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
                    }

                    //MessageBox.Show("Дані про свідків успішно збережено.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка збереження даних про свідків: " + ex.Message);
                }
            }
        }

        private void LoadEvidence()
        {
            // Кнопка додавання нового доказу
            Button btnAddEvidence = new Button
            {
                Text = "Додати доказ",
                Location = new Point(10, 10),
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

        private void SaveEvidence()
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\ХНУРЕ\База даних\Interpol\Interpol\Interpol.accdb;";
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Збереження нових/оновлення доказів
                    foreach (Control control in tabEvidence.Controls)
                    {
                        if (control is EvidencePanel evidencePanel)
                        {
                            if (evidencePanel.EvidenceId == 0)
                            {
                                // Додавання нового доказу
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

                                // Отримання ID нового доказу
                                string selectEvidenceIdQuery = "SELECT @@IDENTITY";
                                OleDbCommand selectEvidenceIdCommand = new OleDbCommand(selectEvidenceIdQuery, connection);
                                int newEvidenceId = Convert.ToInt32(selectEvidenceIdCommand.ExecuteScalar());

                                // Додавання зв'язку між доказом і злочином
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
                                // Оновлення існуючого доказу
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

                                // Оновлення зв'язку з таблицею `evidence_crime`
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

                    if (reader.Read())
                    {
                        // Заповнюємо елементи на панелі
                        dtpStatusDate.Value = reader["status_date"] != DBNull.Value
                            ? Convert.ToDateTime(reader["status_date"])
                            : DateTime.Now;

                        txtWantedCountry.Text = reader["status_country"]?.ToString() ?? "";

                        txtIssuingAuthority.Text = reader["issuing_authority"]?.ToString() ?? "";

                        cmbStatusType.Text = reader["status_type"]?.ToString() ?? "";
                    }
                    else
                    {
                        // Якщо записів немає, очищуємо поля
                        dtpStatusDate.Value = DateTime.Now;
                        txtWantedCountry.Clear();
                        txtIssuingAuthority.Clear();
                        cmbStatusType.SelectedIndex = -1;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка завантаження розшуків: " + ex.Message);
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

                    // Отримуємо `criminal_crime_id` для заданого `crime_id`
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

                    // Видаляємо попередній запис у `wanted_status`
                    string deleteQuery = "DELETE FROM wanted_status WHERE criminal_crime_id = @CriminalCrimeId";
                    using (OleDbCommand deleteCommand = new OleDbCommand(deleteQuery, connection))
                    {
                        deleteCommand.Parameters.AddWithValue("@CriminalCrimeId", criminalCrimeId);
                        deleteCommand.ExecuteNonQuery();
                    }

                    // Отримуємо дані зі статичної панелі
                    DateTime statusDate = dtpStatusDate.Value.Date;
                    string wantedCountry = txtWantedCountry.Text;
                    string issuingAuthority = txtIssuingAuthority.Text;
                    string statusType = cmbStatusType.Text;

                    // Вставляємо нові дані
                    string insertQuery = @"
    INSERT INTO wanted_status (status_date, status_country, issuing_authority, status_type, criminal_crime_id)
    VALUES (@StatusDate, @StatusCountry, @IssuingAuthority, @StatusType, @CriminalCrimeId)";

                    using (OleDbCommand insertCommand = new OleDbCommand(insertQuery, connection))
                    {
                        insertCommand.Parameters.AddWithValue("@StatusDate", statusDate);
                        insertCommand.Parameters.AddWithValue("@StatusCountry", wantedCountry);
                        insertCommand.Parameters.AddWithValue("@IssuingAuthority", issuingAuthority);
                        insertCommand.Parameters.AddWithValue("@StatusType", statusType);
                        insertCommand.Parameters.AddWithValue("@CriminalCrimeId", criminalCrimeId);

                        insertCommand.ExecuteNonQuery();
                    }

                    //MessageBox.Show("Дані про розшук успішно збережено.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка збереження даних про розшуки: " + ex.Message);
                }
            }
        }

        private void LoadWarrants()
        {
            try
            {
                int yOffset = 0; // Відступ для кожного елементу

                // Створюємо статичну панель для додавання нового ордера
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
                    Value = DateTime.Now // Значення за замовчуванням
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
                    Text = "" // Порожнє значення за замовчуванням
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
                    DropDownStyle = ComboBoxStyle.DropDown
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

                yOffset += 160; // Збільшуємо відступ для наступних елементів (якщо потрібно)
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка завантаження ордерів: " + ex.Message);
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
                            string warrantCountry = txtWarrantCountry.Text.Trim(); // Обрізаємо пробіли
                            string warrantType = cmbWarrantType.SelectedItem?.ToString() ?? string.Empty; // Перевірка на null

                            if (string.IsNullOrEmpty(warrantCountry) || string.IsNullOrEmpty(warrantType))
                            {
                                MessageBox.Show("Будь ласка, заповніть усі поля для ордера.");
                                continue;
                            }

                            // Додати правильний `court_case_id`
                            int courtCaseId = GetCourtCaseId(connection);

                            if (courtCaseId == 0)
                            {
                                MessageBox.Show("Не вдалося знайти відповідний `court_case_id`. Переконайтеся, що судова справа існує.");
                                continue;
                            }

                            // Створення нового запису в базі
                            string insertWarrantQuery = @"
                    INSERT INTO international_warrant (warrant_issue_date, warrant_country, warrant_type, court_case_id)
                    VALUES (@WarrantIssueDate, @WarrantCountry, @WarrantType, @CourtCaseId)";

                            using (OleDbCommand insertWarrantCommand = new OleDbCommand(insertWarrantQuery, connection))
                            {
                                insertWarrantCommand.Parameters.AddWithValue("@WarrantIssueDate", warrantIssueDate.ToString("yyyy-MM-dd")); // Формат дати
                                insertWarrantCommand.Parameters.AddWithValue("@WarrantCountry", string.IsNullOrEmpty(warrantCountry) ? (object)DBNull.Value : warrantCountry);
                                insertWarrantCommand.Parameters.AddWithValue("@WarrantType", string.IsNullOrEmpty(warrantType) ? (object)DBNull.Value : warrantType);
                                insertWarrantCommand.Parameters.AddWithValue("@CourtCaseId", courtCaseId); // Використовуємо реальне значення `court_case_id`

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

        private int GetCourtCaseId(OleDbConnection connection)
        {
            string query = @"
    SELECT TOP 1 court_case_id
    FROM court_case
    WHERE criminal_crime_id = @CriminalCrimeId";

            using (OleDbCommand command = new OleDbCommand(query, connection))
            {
                command.Parameters.AddWithValue("@CriminalCrimeId", _criminalCrimeId);

                object result = command.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : 0;
            }
        }

        private void LoadCourtCase()
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\ХНУРЕ\База даних\Interpol\Interpol\Interpol.accdb;";
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                try
                {
                    string query = @"
SELECT 
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
    criminal_crime ccr ON cc.criminal_crime_id = ccr.criminal_crime_id
WHERE 
    ccr.crime_id = @CrimeId";

                    OleDbCommand command = new OleDbCommand(query, connection);
                    command.Parameters.AddWithValue("@CrimeId", _crimeId);

                    connection.Open();
                    OleDbDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        txtDecisionNumber.Text = reader["decision_number"]?.ToString() ?? "";
                        txtCaseNumber.Text = reader["case_number"]?.ToString() ?? "";
                        dtpRegistrationDate.Value = reader["registration_date"] != DBNull.Value
                            ? Convert.ToDateTime(reader["registration_date"])
                            : DateTime.Now;
                        dtpHearingDate.Value = reader["hearing_date"] != DBNull.Value
                            ? Convert.ToDateTime(reader["hearing_date"])
                            : DateTime.Now;
                        txtCourtDecisionForm.Text = reader["court_decision_form"]?.ToString() ?? "";
                        txtCourtHearingForm.Text = reader["court_hearing_form"]?.ToString() ?? "";
                        txtCourtName.Text = reader["court_name"]?.ToString() ?? "";
                        lblCaseFilePath.Text = reader["case_decision"]?.ToString() ?? "Файл не завантажено";
                    }
                    else
                    {
                        txtDecisionNumber.Clear();
                        txtCaseNumber.Clear();
                        dtpRegistrationDate.Value = DateTime.Now;
                        dtpHearingDate.Value = DateTime.Now;
                        txtCourtDecisionForm.Clear();
                        txtCourtHearingForm.Clear();
                        txtCourtName.Clear();
                        lblCaseFilePath.Text = "Файл не завантажено";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка завантаження даних судової справи: " + ex.Message);
                }
            }
        }

        private void btnUploadCase_Click(object sender, EventArgs e)
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
                        lblCaseFilePath.Text = Path.Combine(@"Sources\PDF\", Path.GetFileName(sourcePath));
                        MessageBox.Show("Новий файл судової справи успішно завантажено.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Помилка копіювання файлу: " + ex.Message);
                    }
                }
            }
        }

        private void SaveCourtCase()
        {
            if (_crimeId == 0 || _criminalCrimeId == 0)
            {
                MessageBox.Show("Не знайдено Crime ID або Criminal Crime ID. Спочатку створіть запис про злочин.");
                return;
            }

            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\ХНУРЕ\База даних\Interpol\Interpol\Interpol.accdb;";
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string insertCourtCaseQuery = @"
                        INSERT INTO court_case 
                        (decision_number, case_number, registration_date, hearing_date, 
                         court_decision_form, court_hearing_form, court_name, case_decision, criminal_crime_id) 
                        VALUES 
                        (@DecisionNumber, @CaseNumber, @RegistrationDate, @HearingDate, 
                         @DecisionForm, @HearingForm, @CourtName, @CaseDecision, @CriminalCrimeId)";

                    using (OleDbCommand command = new OleDbCommand(insertCourtCaseQuery, connection))
                    {
                        command.Parameters.AddWithValue("@DecisionNumber", txtDecisionNumber.Text.Trim());
                        command.Parameters.AddWithValue("@CaseNumber", txtCaseNumber.Text.Trim());
                        command.Parameters.AddWithValue("@RegistrationDate", dtpRegistrationDate.Value.ToString("yyyy-MM-dd"));
                        command.Parameters.AddWithValue("@HearingDate", dtpHearingDate.Value.ToString("yyyy-MM-dd"));
                        command.Parameters.AddWithValue("@DecisionForm", txtCourtDecisionForm.Text.Trim());
                        command.Parameters.AddWithValue("@HearingForm", txtCourtHearingForm.Text.Trim());
                        command.Parameters.AddWithValue("@CourtName", txtCourtName.Text.Trim());

                        string caseDecision = string.IsNullOrEmpty(lblCaseFilePath.Text) ? null : lblCaseFilePath.Text;
                        command.Parameters.AddWithValue("@CaseDecision", (object)caseDecision ?? DBNull.Value);

                        command.Parameters.AddWithValue("@CriminalCrimeId", _criminalCrimeId);

                        command.ExecuteNonQuery();
                    }

                    //MessageBox.Show("Дані про судову справу успішно збережено.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка збереження даних судової справи: " + ex.Message);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            CreateNewCrimeRecord();
            CreateNewCriminalCrimeRecord();

            SaveCriminalInfo();
            SaveVictims();
            SaveWitnesses();
            SaveEvidence();
            SaveCourtCase();
            SaveWarrants();
            SaveWantedStatus();

            // Повідомлення про успішне збереження
            MessageBox.Show("Дані успішно збережено!");
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}