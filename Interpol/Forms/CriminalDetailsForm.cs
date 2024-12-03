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
    public partial class CriminalDetailsForm : Form
    {
        private string criminalId;

        public CriminalDetailsForm(string id)
        {
            InitializeComponent();
            criminalId = id;
        }

        private void CriminalDetailsForm_Load(object sender, EventArgs e)
        {
            // Завантажте дані злочинця з бази даних за ID
            LoadCriminalDetails();
        }

        private void LoadCriminalDetails()
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\ХНУРЕ\База даних\Interpol\Interpol\Interpol.accdb;";
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                string query = "SELECT * FROM Criminal WHERE criminal_id = @CriminalId";
                OleDbCommand command = new OleDbCommand(query, connection);
                command.Parameters.AddWithValue("@CriminalId", criminalId);

                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    // ... інші поля
                }

                reader.Close();
            }
        }
    }
}
