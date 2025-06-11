using MySqlConnector;
using System;
using System.Windows.Forms;

namespace PCStoreMenagement
{
    public partial class RegistrationForm : Form // Ensure partial and inheritance
    {
        public RegistrationForm()
        {
            InitializeComponent(); // Ensure this call exists
            this.AcceptButton = buttonRegister;

        }

        private bool passwordVisible = false;
        private bool rePasswordVisible = false;
        string conStr = Properties.Settings.Default.conStr;


        private void buttonShowPassword_Click(object sender, EventArgs e)
        {
            passwordVisible = !passwordVisible;
            rePasswordVisible = !rePasswordVisible;
            textBoxPassword.UseSystemPasswordChar = !passwordVisible;
            textBoxRePassword.UseSystemPasswordChar = !rePasswordVisible;
            buttonShowPassword.Text = passwordVisible ? "🙈" : "👁";
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            string firstName = textBoxFirstName.Text.Trim();
            string lastName = textBoxLastName.Text.Trim();
            string username = textBoxUsername.Text.Trim();
            string address = textBoxAddress.Text.Trim();
            string email = textBoxEmail.Text.Trim();
            string password = textBoxPassword.Text;
            string rePassword = textBoxRePassword.Text;

            if (string.IsNullOrWhiteSpace(firstName) ||
                string.IsNullOrWhiteSpace(lastName) ||
                string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(rePassword))
            {
                MessageBox.Show("Sva polja su obavezna!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (password.Length < 4)
            {
                MessageBox.Show("Password mora biti minimum 4 karatera.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (password != rePassword)
            {
                MessageBox.Show("Šifre se ne poklapaju.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            using (MySqlConnection conn = new MySqlConnection(conStr))
            {
                conn.Open();
                string query = @"
                    INSERT INTO customer (username, password, first_name, last_name, email, address)
                    VALUES (@username, @password, @firstName, @lastName, @email, @address)";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@firstName", firstName);
                    cmd.Parameters.AddWithValue("@lastName", lastName);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@address", address);

                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
            MessageBox.Show("Registracija uspješna!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var Form1 = new Form1(); 
            this.Close(); 
        }
    }
}