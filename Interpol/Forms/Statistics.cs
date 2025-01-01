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
    public partial class Statistics : Form
    {
        private const string ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\\ХНУРЕ\\База даних\\Interpol\\Interpol\\Interpol.accdb;";

        public Statistics(int num)
        {
            InitializeComponent();

            // Очищення попередніх елементів, якщо є
            ClearDynamicControls();

            // Відображення статистики відповідно до вибору
            switch (num)
            {
                case 1:
                    this.Text = "Статистика про злочинців";
                    CriminalStatistics();
                    break;
                case 2:
                    this.Text = "Статистика про злочини";
                    CrimeStatistics();
                    break;
                case 3:
                    this.Text = "Статистика про міжнародні ордери";
                    WarrantStatistics();
                    break;
                case 4:
                    this.Text = "Статистика про судові справи";
                    CourtCaseStatistics();
                    break;
                default:
                    MessageBox.Show("Невідомий тип статистики.");
                    break;
            }
        }

        private void CriminalStatistics()
        {
            // Загальна інформація
            string generalInfoQuery = @"
                SELECT 'Кількість злочинців' AS Метрика, COUNT(*) AS Значення 
                FROM criminal
                UNION ALL
                SELECT 'Середній вік', AVG(DATEDIFF('yyyy', p.birth_date, DATE())) 
                FROM person p
                INNER JOIN criminal c ON p.person_id = c.person_id";

            CreateAndFillGrid("Загальна інформація", generalInfoQuery);

            // Національність
            string nationalityQuery = @"
                SELECT p.nationality AS Національність, COUNT(*) AS Кількість 
                FROM person p
                INNER JOIN criminal c ON p.person_id = c.person_id
                GROUP BY p.nationality";

            CreateAndFillGrid("Національність", nationalityQuery);

            // Статус розслідування
            string investigationStatusQuery = @"
                SELECT 'Активне' AS Статус, COUNT(*) AS Кількість 
                FROM crime 
                WHERE investigations_status = 'Активне'
                UNION ALL
                SELECT 'Закрите', COUNT(*) 
                FROM crime 
                WHERE investigations_status = 'Закрите'
                UNION ALL
                SELECT 'В очікуванні', COUNT(*) 
                FROM crime 
                WHERE investigations_status = 'В очікуванні'";

            CreateAndFillGrid("Статус розслідування", investigationStatusQuery);
        }

        private void CrimeStatistics()
        {
            // Загальна інформація про злочини
            string generalInfoQuery = @"
                SELECT 'Кількість злочинів' AS Метрика, COUNT(*) AS Значення 
                FROM crime
                UNION ALL
                SELECT 'Середня кількість доказів на злочин', AVG(ЗагальнаКількістьДоказів)
                FROM (
                    SELECT COUNT(ec.evidence_id) AS ЗагальнаКількістьДоказів
                    FROM crime c
                    LEFT JOIN evidence_crime ec ON c.crime_id = ec.crime_id
                    GROUP BY c.crime_id
                )";

            CreateAndFillGrid("Загальна інформація", generalInfoQuery);

            // Типи злочинів
            string crimeTypeQuery = @"
                SELECT crime_type AS Тип, COUNT(*) AS Кількість 
                FROM crime 
                GROUP BY crime_type";

            CreateAndFillGrid("Типи злочинів", crimeTypeQuery);

            // Локації злочинів
            string crimeLocationQuery = @"
                SELECT crime_location AS Локація, COUNT(*) AS Кількість 
                FROM crime 
                GROUP BY crime_location";

            CreateAndFillGrid("Локації злочинів", crimeLocationQuery);
        }

        private void WarrantStatistics()
        {
            // Загальна інформація про ордери
            string generalInfoQuery = @"
                SELECT 'Кількість ордерів' AS Метрика, COUNT(*) AS Значення 
                FROM international_warrant";

            CreateAndFillGrid("Загальна інформація", generalInfoQuery);

            // Ордери за країнами
            string warrantCountryQuery = @"
                SELECT warrant_country AS Країна, COUNT(*) AS Кількість 
                FROM international_warrant 
                GROUP BY warrant_country";

            CreateAndFillGrid("Ордери за країнами", warrantCountryQuery);

            // Ордери за роками
            string warrantYearQuery = @"
                SELECT FORMAT(warrant_issue_date, 'yyyy') AS Рік, COUNT(*) AS Кількість 
                FROM international_warrant 
                GROUP BY FORMAT(warrant_issue_date, 'yyyy')";

            CreateAndFillGrid("Ордери за роками", warrantYearQuery);
        }

        private void CourtCaseStatistics()
        {
            // Загальна інформація про судові справи
            string generalInfoQuery = @"
                SELECT 'Кількість судових справ' AS Метрика, COUNT(*) AS Значення 
                FROM court_case";

            CreateAndFillGrid("Загальна інформація", generalInfoQuery);

            // Судові справи за судами
            string courtNameQuery = @"
                SELECT court_name AS Суд, COUNT(*) AS Кількість 
                FROM court_case 
                GROUP BY court_name";

            CreateAndFillGrid("Судові справи за судами", courtNameQuery);

            // Судові справи за роками
            string hearingYearQuery = @"
                SELECT FORMAT(hearing_date, 'yyyy') AS Рік, COUNT(*) AS Кількість 
                FROM court_case 
                GROUP BY FORMAT(hearing_date, 'yyyy')";

            CreateAndFillGrid("Судові справи за роками", hearingYearQuery);
        }

        private void CreateAndFillGrid(string title, string query)
        {
            // Динамічно створюємо заголовок
            Label titleLabel = new Label
            {
                Text = title,
                Font = new Font("Montserrat", 14, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true,
                Padding = new Padding(5),
            };
            titleLabel.Top = CalculateNextControlTop();
            titleLabel.Left = 10;
            this.Controls.Add(titleLabel);

            // Динамічно створюємо DataGridView
            DataGridView gridView = new DataGridView
            {
                Width = this.ClientSize.Width - 20,
                Height = 200,
                Top = titleLabel.Bottom + 10,
                Left = 10,
                AutoGenerateColumns = true,
                ColumnHeadersHeight = 50
            };
            this.Controls.Add(gridView);

            // Заповнюємо DataGridView даними
            try
            {
                using (OleDbConnection connection = new OleDbConnection(ConnectionString))
                {
                    connection.Open();
                    OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    gridView.DataSource = dt;

                    CustomizeDataGridView(gridView);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка: " + ex.Message);
            }
        }

        private void ClearDynamicControls()
        {
            // Видаляємо всі динамічно створені елементи
            var controlsToRemove = this.Controls.OfType<Control>().Where(c => !(c is MenuStrip));
            foreach (var control in controlsToRemove)
            {
                this.Controls.Remove(control);
            }
        }

        private int CalculateNextControlTop()
        {
            // Визначаємо наступну позицію для верхнього краю нового елемента
            if (this.Controls.Count == 0) return 10;
            var lastControl = this.Controls.Cast<Control>().OrderByDescending(c => c.Bottom).FirstOrDefault();
            return lastControl == null ? 10 : lastControl.Bottom + 20;
        }

        private void CustomizeDataGridView(DataGridView gridView)
        {
            gridView.ColumnHeadersDefaultCellStyle.Font = new Font("Montserrat", 12, FontStyle.Bold);
            gridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridView.DefaultCellStyle.Font = new Font("Montserrat", 10);
            gridView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            gridView.ReadOnly = true;
            gridView.AllowUserToAddRows = false;
            gridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            gridView.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            gridView.DefaultCellStyle.BackColor = Color.White;
            gridView.DefaultCellStyle.SelectionBackColor = Color.DarkBlue;
            gridView.DefaultCellStyle.SelectionForeColor = Color.White;
            gridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
}