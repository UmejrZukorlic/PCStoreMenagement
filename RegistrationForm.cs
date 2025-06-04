using System;
using System.Windows.Forms;

namespace PCStoreMenagement
{
    public partial class RegistrationForm : Form // Ensure partial and inheritance
    {
        public RegistrationForm()
        {
            InitializeComponent(); // Ensure this call exists
        }

        private bool passwordVisible = false;
        private bool rePasswordVisible = false;

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

            MessageBox.Show("Registracija uspješna!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}