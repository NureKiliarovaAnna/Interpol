using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interpol.Forms
{
    public partial class CriminalDetailsForm : Form
    {
        private string _personId;
        private string _crimeId;

        public CriminalDetailsForm(string personId, string crimeId)
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

        private void LoadVictims()
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\ХНУРЕ\База даних\Interpol\Interpol\Interpol.accdb;";
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                try
                {
                    // Запит для отримання даних потерпілих
                    string query = @"
                SELECT 
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

                    // Відображення кожного потерпілого
                    int yOffset = 0; // Відступ для кожного елементу
                    while (reader.Read())
                    {
                        // Створюємо панель для кожного потерпілого
                        Panel victimPanel = new Panel
                        {
                            Size = new Size(900, 480), // Збільшуємо ширину панелі
                            Location = new Point(10, yOffset),
                            BorderStyle = BorderStyle.FixedSingle
                        };

                        // Додаємо текстові поля з мітками
                        victimPanel.Controls.Add(CreateTextBoxWithLabel("txtVictimFirstName", "Ім'я: ", reader["first_name"], 10, 10));
                        victimPanel.Controls.Add(CreateTextBoxWithLabel("txtVictimLastName", "Прізвище: ", reader["last_name"], 10, 40));
                        victimPanel.Controls.Add(CreateTextBoxWithLabel("txtVictimBirthDate", "Дата народження: ", reader["birth_date"], 10, 70));
                        victimPanel.Controls.Add(CreateTextBoxWithLabel("txtVictimGender", "Стать: ", reader["gender"], 10, 100));
                        victimPanel.Controls.Add(CreateTextBoxWithLabel("txtVictimBirthLocation", "Місце народження: ", reader["birth_location"], 10, 130));
                        victimPanel.Controls.Add(CreateTextBoxWithLabel("txtVictimResidence", "Місце проживання: ", reader["last_known_residence"], 10, 160));
                        victimPanel.Controls.Add(CreateTextBoxWithLabel("txtVictimNationality", "Національність: ", reader["nationality"], 10, 190));
                        victimPanel.Controls.Add(CreateTextBoxWithLabel("txtVictimStatus", "Статус: ", reader["status"], 10, 220));
                        victimPanel.Controls.Add(CreateTextBoxWithLabel("txtVictimPassport", "Паспорт: ", reader["passport"], 10, 250));
                        victimPanel.Controls.Add(CreateTextBoxWithLabel("txtVictimEmail", "Email: ", reader["email_addr"], 10, 280));
                        victimPanel.Controls.Add(CreateTextBoxWithLabel("txtVictimPhone", "Телефон: ", reader["phone_num"], 10, 310));
                        victimPanel.Controls.Add(CreateTextBoxWithLabel("txtVictimTestimonyDate", "Дата свідчень: ", reader["victim_testimony_date"], 10, 340));
                        victimPanel.Controls.Add(CreateTextBoxWithLabel("txtVictimInjury", "Ушкодження: ", reader["victim_injury"], 10, 370));

                        // Додаємо PictureBox для фото
                        PictureBox pbPhoto = new PictureBox
                        {
                            Size = new Size(200, 200),
                            Location = new Point(650, 10), // Зміщуємо до правого краю
                            SizeMode = PictureBoxSizeMode.StretchImage,
                            BorderStyle = BorderStyle.FixedSingle
                        };

                        if (reader["photo"] != DBNull.Value)
                        {
                            string photoPath = reader["photo"].ToString();
                            if (File.Exists(photoPath))
                            {
                                pbPhoto.Image = Image.FromFile(photoPath);
                            }
                        }

                        victimPanel.Controls.Add(pbPhoto);

                        // Додаємо кнопку для відкриття PDF
                        if (reader["victim_testimony"] != DBNull.Value)
                        {
                            string testimonyPath = reader["victim_testimony"].ToString();

                            Button btnTestimony = new Button
                            {
                                Text = "Свідчення",
                                Location = new Point(650, 220), // Зміщуємо до правого краю під фото
                                Size = new Size(200, 30)
                            };

                            btnTestimony.Click += (s, e) =>
                            {
                                if (File.Exists(testimonyPath))
                                {
                                    System.Diagnostics.Process.Start(testimonyPath);
                                }
                                else
                                {
                                    MessageBox.Show("Файл свідчення не знайдено: " + testimonyPath);
                                }
                            };

                            victimPanel.Controls.Add(btnTestimony);
                        }

                        // Додаємо панель до вкладки
                        tabVictims.Controls.Add(victimPanel);

                        yOffset += 490; // Збільшуємо відступ для наступної панелі
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка завантаження потерпілих: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        private Control CreateTextBoxWithLabel(string textBoxName, string labelText, object value, int x, int y)
        {
            Panel container = new Panel
            {
                Location = new Point(x, y),
                Size = new Size(570, 25) // Розмір контейнера
            };

            Label label = new Label
            {
                Text = labelText,
                Location = new Point(0, 5),
                AutoSize = true
            };

            TextBox textBox = new TextBox
            {
                Name = textBoxName,
                Text = value != DBNull.Value ? value?.ToString() : "",
                Location = new Point(200, 0),
                Size = new Size(400, 20)
            };

            container.Controls.Add(label);
            container.Controls.Add(textBox);

            return container;
        }

        private void LoadWitnesses()
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\ХНУРЕ\База даних\Interpol\Interpol\Interpol.accdb;";
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                try
                {
                    // Запит для отримання даних свідків
                    string query = @"
                SELECT 
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

                    // Відображення кожного свідка
                    int yOffset = 0; // Відступ для кожного елементу
                    while (reader.Read())
                    {
                        // Створюємо панель для кожного свідка
                        Panel witnessPanel = new Panel
                        {
                            Size = new Size(900, 480), // Збільшуємо ширину панелі
                            Location = new Point(10, yOffset),
                            BorderStyle = BorderStyle.FixedSingle
                        };

                        // Додаємо текстові поля з мітками
                        witnessPanel.Controls.Add(CreateTextBoxWithLabel("txtWitnessFirstName", "Ім'я: ", reader["first_name"], 10, 10));
                        witnessPanel.Controls.Add(CreateTextBoxWithLabel("txtWitnessLastName", "Прізвище: ", reader["last_name"], 10, 40));
                        witnessPanel.Controls.Add(CreateTextBoxWithLabel("txtWitnessBirthDate", "Дата народження: ", reader["birth_date"], 10, 70));
                        witnessPanel.Controls.Add(CreateTextBoxWithLabel("txtWitnessGender", "Стать: ", reader["gender"], 10, 100));
                        witnessPanel.Controls.Add(CreateTextBoxWithLabel("txtWitnessBirthLocation", "Місце народження: ", reader["birth_location"], 10, 130));
                        witnessPanel.Controls.Add(CreateTextBoxWithLabel("txtWitnessResidence", "Місце проживання: ", reader["last_known_residence"], 10, 160));
                        witnessPanel.Controls.Add(CreateTextBoxWithLabel("txtWitnessNationality", "Національність: ", reader["nationality"], 10, 190));
                        witnessPanel.Controls.Add(CreateTextBoxWithLabel("txtWitnessStatus", "Статус: ", reader["status"], 10, 220));
                        witnessPanel.Controls.Add(CreateTextBoxWithLabel("txtWitnessPassport", "Паспорт: ", reader["passport"], 10, 250));
                        witnessPanel.Controls.Add(CreateTextBoxWithLabel("txtWitnessEmail", "Email: ", reader["email_addr"], 10, 280));
                        witnessPanel.Controls.Add(CreateTextBoxWithLabel("txtWitnessPhone", "Телефон: ", reader["phone_num"], 10, 310));
                        witnessPanel.Controls.Add(CreateTextBoxWithLabel("txtWitnessTestimonyDate", "Дата свідчень: ", reader["witness_testimony_date"], 10, 340));

                        // Додаємо PictureBox для фото
                        PictureBox pbPhoto = new PictureBox
                        {
                            Size = new Size(200, 200),
                            Location = new Point(650, 10), // Зміщуємо до правого краю
                            SizeMode = PictureBoxSizeMode.StretchImage,
                            BorderStyle = BorderStyle.FixedSingle
                        };

                        if (reader["photo"] != DBNull.Value)
                        {
                            string photoPath = reader["photo"].ToString();
                            if (File.Exists(photoPath))
                            {
                                pbPhoto.Image = Image.FromFile(photoPath);
                            }
                        }

                        witnessPanel.Controls.Add(pbPhoto);

                        // Додаємо кнопку для відкриття свідчень
                        if (reader["witness_testimony"] != DBNull.Value)
                        {
                            string testimonyPath = reader["witness_testimony"].ToString();

                            Button btnTestimony = new Button
                            {
                                Text = "Свідчення",
                                Location = new Point(650, 220), // Зміщуємо до правого краю під фото
                                Size = new Size(200, 30)
                            };

                            btnTestimony.Click += (s, e) =>
                            {
                                if (File.Exists(testimonyPath))
                                {
                                    System.Diagnostics.Process.Start(testimonyPath);
                                }
                                else
                                {
                                    MessageBox.Show("Файл свідчення не знайдено: " + testimonyPath);
                                }
                            };

                            witnessPanel.Controls.Add(btnTestimony);
                        }

                        // Додаємо панель до вкладки
                        tabWitnesses.Controls.Add(witnessPanel);

                        yOffset += 490; // Збільшуємо відступ для наступної панелі
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка завантаження свідків: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        private void LoadEvidence()
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\ХНУРЕ\База даних\Interpol\Interpol\Interpol.accdb;";
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                try
                {
                    // Запит для отримання даних доказів
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

                    // Відображення кожного доказу
                    int yOffset = 0; // Відступ для кожного елементу
                    while (reader.Read())
                    {
                        // Створюємо панель для кожного доказу
                        Panel evidencePanel = new Panel
                        {
                            Size = new Size(900, 300), // Збільшено ширину панелі
                            Location = new Point(10, yOffset),
                            BorderStyle = BorderStyle.FixedSingle
                        };

                        // Додаємо текстові поля з мітками
                        evidencePanel.Controls.Add(CreateTextBoxWithLabel("txtEvidenceType", "Тип доказу: ", reader["evidence_type"], 10, 10));
                        evidencePanel.Controls.Add(CreateTextBoxWithLabel("txtEvidenceDescription", "Опис: ", reader["evidence_description"], 10, 40));
                        evidencePanel.Controls.Add(CreateTextBoxWithLabel("txtEvidenceDiscoveryDate", "Дата виявлення: ", reader["evidence_discovery_date"], 10, 70));
                        evidencePanel.Controls.Add(CreateTextBoxWithLabel("txtEvidenceLocation", "Місце виявлення: ", reader["evidence_location"], 10, 100));
                        evidencePanel.Controls.Add(CreateTextBoxWithLabel("txtEvidenceStorageLocation", "Місце зберігання: ", reader["evidence_storage_location"], 10, 130));
                        evidencePanel.Controls.Add(CreateTextBoxWithLabel("txtEvidenceAnalysisResult", "Результат аналізу: ", reader["evidence_analysis_result"], 10, 160));
                        evidencePanel.Controls.Add(CreateTextBoxWithLabel("txtEvidenceDateAttachment", "Дата додавання: ", reader["evidence_date_attachment"], 10, 190));

                        // Додаємо панель до вкладки
                        tabEvidence.Controls.Add(evidencePanel);

                        yOffset += 310; // Збільшуємо відступ для наступної панелі
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка завантаження доказів: " + ex.Message);
                }
                finally
                {
                    connection.Close();
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
                            Size = new Size(900, 200),
                            Location = new Point(10, yOffset),
                            BorderStyle = BorderStyle.FixedSingle
                        };

                        // Створюємо текстові поля
                        wantedPanel.Controls.Add(CreateTextBox4("txtWantedStatusDate", "Дата статусу: ", reader["status_date"], 20, 10));
                        wantedPanel.Controls.Add(CreateTextBox4("txtWantedCountry", "Країна розшуку: ", reader["status_country"], 20, 40));
                        wantedPanel.Controls.Add(CreateTextBox4("txtIssuingAuthority", "Орган видачі: ", reader["issuing_authority"], 20, 70));
                        wantedPanel.Controls.Add(CreateTextBox4("txtStatusType", "Тип статусу: ", reader["status_type"], 20, 100));

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
                                Size = new Size(900, 150),
                                Location = new Point(10, yOffset),
                                BorderStyle = BorderStyle.FixedSingle
                            };

                            // Створюємо текстові поля
                            warrantPanel.Controls.Add(CreateTextBox5("txtWarrantIssueDate", "Дата видачі ордера: ", warrantReader["warrant_issue_date"], 20, 10));
                            warrantPanel.Controls.Add(CreateTextBox5("txtWarrantCountry", "Країна видачі: ", warrantReader["warrant_country"], 20, 40));
                            warrantPanel.Controls.Add(CreateTextBox5("txtWarrantType", "Тип ордера: ", warrantReader["warrant_type"], 20, 70));

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

        private void LoadCourtCase()
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\ХНУРЕ\База даних\Interpol\Interpol\Interpol.accdb;";
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                try
                {
                    // Запит для отримання даних судової справи
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
                    criminal_crime cc_crime ON cc.criminal_crime_id = cc_crime.criminal_crime_id
                WHERE 
                    cc_crime.crime_id = @CrimeId";

                    OleDbCommand command = new OleDbCommand(query, connection);
                    command.Parameters.AddWithValue("@CrimeId", _crimeId);

                    connection.Open();
                    OleDbDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        // Створюємо панель для судової справи
                        Panel courtCasePanel = new Panel
                        {
                            Size = new Size(900, 350),
                            Location = new Point(10, 10),
                            BorderStyle = BorderStyle.FixedSingle
                        };

                        // Створюємо текстові поля
                        courtCasePanel.Controls.Add(CreateTextBox6("txtDecisionNumber", "Номер рішення: ", reader["decision_number"], 20, 20));
                        courtCasePanel.Controls.Add(CreateTextBox6("txtCaseNumber", "Номер справи: ", reader["case_number"], 20, 50));
                        courtCasePanel.Controls.Add(CreateTextBox6("txtRegistrationDate", "Дата реєстрації: ", reader["registration_date"], 20, 80));
                        courtCasePanel.Controls.Add(CreateTextBox6("txtHearingDate", "Дата слухання: ", reader["hearing_date"], 20, 110));
                        courtCasePanel.Controls.Add(CreateTextBox6("txtCourtDecisionForm", "Форма рішення: ", reader["court_decision_form"], 20, 140));
                        courtCasePanel.Controls.Add(CreateTextBox6("txtCourtHearingForm", "Форма слухання: ", reader["court_hearing_form"], 20, 170));
                        courtCasePanel.Controls.Add(CreateTextBox6("txtCourtName", "Назва суду: ", reader["court_name"], 20, 200));

                        if (reader["case_decision"] != DBNull.Value)
                        {
                            string casePath = reader["case_decision"].ToString();

                            Button btnCase = new Button
                            {
                                Text = "Судова справа",
                                Location = new Point(10, 230),
                                Size = new Size(200, 30)
                            };

                            btnCase.Click += (s, e) =>
                            {
                                if (File.Exists(casePath))
                                {
                                    System.Diagnostics.Process.Start(casePath);
                                }
                                else
                                {
                                    MessageBox.Show("Файл свідчення не знайдено: " + casePath);
                                }
                            };

                            courtCasePanel.Controls.Add(btnCase);
                        }

                        // Додаємо панель до вкладки
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
                Location = new Point(x + 160, y),
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
                Location = new Point(x + 150, y - 10),
                Size = new Size(200, 20)
            };

            return textBox;
        }

        private void CriminalDetailsForm_Load(object sender, EventArgs e)
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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            // Відкриваємо форму для редагування
            EditCriminalForm editForm = new EditCriminalForm(_personId, _crimeId);
            editForm.ShowDialog();

            // Після закриття форми оновлюємо дані у вкладках
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Ви впевнені, що хочете видалити цього злочинця та всі пов'язані дані?",
        "Підтвердження видалення", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                DeleteCriminalData();
            }
        }

        private void DeleteCriminalData()
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\ХНУРЕ\База даних\Interpol\Interpol\Interpol.accdb;";
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Видаляємо дані з кожної таблиці по черзі
                    ExecuteDeleteCommand(connection, "DELETE FROM evidence_crime WHERE crime_id = @CrimeId");
                    ExecuteDeleteCommand(connection, "DELETE FROM victim WHERE crime_id = @CrimeId");
                    ExecuteDeleteCommand(connection, "DELETE FROM witness WHERE crime_id = @CrimeId");
                    ExecuteDeleteCommand(connection, @"
                DELETE FROM wanted_status 
                WHERE criminal_crime_id IN 
                (SELECT criminal_crime_id FROM criminal_crime WHERE crime_id = @CrimeId)");
                    ExecuteDeleteCommand(connection, @"
                DELETE FROM international_warrant 
                WHERE court_case_id IN 
                (SELECT court_case_id FROM court_case 
                 WHERE criminal_crime_id IN 
                 (SELECT criminal_crime_id FROM criminal_crime WHERE crime_id = @CrimeId))");
                    ExecuteDeleteCommand(connection, @"
                DELETE FROM court_case 
                WHERE criminal_crime_id IN 
                (SELECT criminal_crime_id FROM criminal_crime WHERE crime_id = @CrimeId)");
                    ExecuteDeleteCommand(connection, "DELETE FROM criminal_crime WHERE crime_id = @CrimeId");
                    ExecuteDeleteCommand(connection, "DELETE FROM crime WHERE crime_id = @CrimeId");
                    ExecuteDeleteCommand(connection, "DELETE FROM criminal WHERE person_id = @PersonId");
                    ExecuteDeleteCommand(connection, "DELETE FROM person WHERE person_id = @PersonId");

                    MessageBox.Show("Злочинець та всі пов'язані дані успішно видалені.");
                    this.Close(); // Закриваємо форму після видалення
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка видалення даних: " + ex.Message);
                }
            }
        }

        private void ExecuteDeleteCommand(OleDbConnection connection, string query)
        {
            using (OleDbCommand command = new OleDbCommand(query, connection))
            {
                command.Parameters.AddWithValue("@CrimeId", _crimeId);
                command.Parameters.AddWithValue("@PersonId", _personId);
                command.ExecuteNonQuery();
            }
        }
    }
}