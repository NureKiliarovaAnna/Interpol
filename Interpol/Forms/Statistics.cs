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
            dataGridView.AutoGenerateColumns = true;

            switch (num)
            {
                case 1:
                    {
                        label1.Text = "Статистика про злочинців";
                        CriminalStatistics();
                        break;
                    }
                case 2:
                    {
                        label1.Text = "Статистика про злочини";
                        CrimeStatistics();
                        break;
                    }
                case 3:
                    {
                        label1.Text = "Статистика про міжнародні ордери";
                        WarrantStatistics();
                        break;
                    }
                case 4:
                    {
                        label1.Text = "Статистика про судові справи";
                        CourtCaseStatistics();
                        break;
                    }
            }
        }

        private void FillData(string query)
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(ConnectionString))
                {
                    connection.Open();
                    OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView.DataSource = dt;

                    CustomizeDataGridView();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка: " + ex.Message);
            }
        }

        private void CriminalStatistics()
        {
            string query = @"
            SELECT 'Кількість злочинців' AS Метрика, COUNT(*) AS Значення FROM criminal
            UNION ALL
            SELECT 'Активне', COUNT(*) FROM crime WHERE investigations_status = 'Активне'
            UNION ALL
            SELECT 'Закрите', COUNT(*) FROM crime WHERE investigations_status = 'Закрите'
            UNION ALL
            SELECT 'В очікуванні', COUNT(*) FROM crime WHERE investigations_status = 'В очікуванні'
            UNION ALL
            SELECT 'Середній вік', AVG(DATEDIFF('yyyy', p.birth_date, DATE())) 
            FROM person p
            INNER JOIN criminal c ON p.person_id = c.person_id
            UNION ALL
            SELECT p.nationality AS Метрика, COUNT(*) AS Значення 
            FROM person p
            INNER JOIN criminal c ON p.person_id = c.person_id
            GROUP BY p.nationality";

            FillData(query);
        }

        private void CrimeStatistics()
        {
            string query = @"
                SELECT 'Кількість злочинів' AS Метрика, COUNT(*) AS Значення 
                FROM crime
                UNION ALL
                SELECT 'Середня кількість доказів на злочин', AVG(ЗагальнаКількістьДоказів)
                FROM (
                    SELECT COUNT(ec.evidence_id) AS ЗагальнаКількістьДоказів
                    FROM crime c
                    LEFT JOIN evidence_crime ec ON c.crime_id = ec.crime_id
                    GROUP BY c.crime_id
                )
                UNION ALL
                SELECT crime_type AS Метрика, COUNT(*) AS Значення 
                FROM crime 
                GROUP BY crime_type
                UNION ALL
                SELECT crime_location AS Метрика, COUNT(*) AS Значення 
                FROM crime 
                GROUP BY crime_location;
             ";

            FillData(query);
        }

        private void WarrantStatistics()
        {
            string query = @"
            SELECT 'Кількість ордерів' AS Метрика, COUNT(*) AS Значення FROM international_warrant
            UNION ALL
            SELECT warrant_country AS Країна, COUNT(*) AS Кількість FROM international_warrant GROUP BY warrant_country
            UNION ALL
            SELECT FORMAT(warrant_issue_date, 'yyyy') AS Рік, COUNT(*) AS Кількість FROM international_warrant GROUP BY FORMAT(warrant_issue_date, 'yyyy')";

            FillData(query);
        }

        private void CourtCaseStatistics()
        {
            string query = @"
            SELECT 'Кількість судових справ' AS Метрика, COUNT(*) AS Значення FROM court_case
            UNION ALL
            SELECT court_name AS Суд, COUNT(*) AS Кількість FROM court_case GROUP BY court_name
            UNION ALL
            SELECT FORMAT(hearing_date, 'yyyy') AS Рік, COUNT(*) AS Кількість FROM court_case GROUP BY FORMAT(hearing_date, 'yyyy')";

            FillData(query);
        }

        private void CustomizeDataGridView()
        {
            // Встановити стилі для DataGridView
            dataGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Montserrat", 12, FontStyle.Bold);
            dataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.DefaultCellStyle.Font = new Font("Montserrat", 10);
            dataGridView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            // Налаштувати колонки
            if (dataGridView.Columns.Count > 0)
            {
                dataGridView.Columns[0].HeaderText = "Метрика";
                dataGridView.Columns[0].Width = 300; // Ширина колонки
                dataGridView.Columns[1].HeaderText = "Значення";
                dataGridView.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView.Columns[1].Width = 200;
            }

            // Заборонити редагування таблиці
            dataGridView.ReadOnly = true;

            // Вимкнути можливість додавання нових рядків (останній порожній рядок)
            dataGridView.AllowUserToAddRows = false;

            // Автоматичне коригування висоти рядків
            dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            dataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            dataGridView.DefaultCellStyle.BackColor = Color.White;
            dataGridView.DefaultCellStyle.SelectionBackColor = Color.DarkBlue;
            dataGridView.DefaultCellStyle.SelectionForeColor = Color.White;

            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
}