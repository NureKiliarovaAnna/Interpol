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
using System.Security.Cryptography;

namespace Interpol.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text;
            string password = txtPassword.Text;

            if (AuthenticateUser(login, password))
            {
                // Якщо логін і пароль правильні, відкриваємо головну форму
                MainForm mainForm = new MainForm();
                this.Hide(); // Ховаємо вікно авторизації
                mainForm.ShowDialog();
                this.Close(); // Закриваємо програму, якщо головна форма закрита
            }
            else
            {
                MessageBox.Show("Логін або пароль введено неправильно.", "Помилка авторизації", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private bool AuthenticateUser(string login, string password)
        {
            // Підключення до бази даних
            string query = "SELECT COUNT(*) FROM admin WHERE login = @login AND password = @password";

            using (OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\ХНУРЕ\База даних\Interpol\Interpol\Interpol.accdb;"))
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand(query, connection);
                command.Parameters.AddWithValue("@login", login);
                command.Parameters.AddWithValue("@password", password);

                int userCount = Convert.ToInt32(command.ExecuteScalar());
                return userCount > 0; // Повертає true, якщо є збіг
            }
        }

        public string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}