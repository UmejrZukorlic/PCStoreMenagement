using MySqlConnector;
using System.Data;

namespace PCStoreMenagement
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Enter dugme pokreće login dugme
            this.AcceptButton = buttonLogin;

            // Fokus na username pri pokretanju forme
            this.ActiveControl = textBoxUsername;
        }

        #region Metode

        /// <summary>
        /// Metoda za brisanje polja za unos
        /// </summary>
        private void ClearFields()
        {
            textBoxUsername.Clear();
            textBoxPassword.Clear();
        }

        #endregion

        private bool passwordVisible = false;
        string conStr = Properties.Settings.Default.conStr;

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string username = textBoxUsername.Text.Trim();
            string password = textBoxPassword.Text.Trim();

            // Provera da su polja popunjena
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Molimo unesite korisničko ime i lozinku.", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (MySqlConnection con = new MySqlConnection(conStr))
            {
                // Proveravamo da li postoji korisnik u tabeli customer
                string sql = "SELECT * FROM customer WHERE username = @u AND password = @p";
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@u", username);
                    cmd.Parameters.AddWithValue("@p", password);
                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            dr.Read();
                            username = dr["username"].ToString();
                            password = dr["password"].ToString();
                            MessageBox.Show("Uspešno ste se prijavili kao " + username);
                            ClearFields();
                            var customerForm = new CustomerForm(username);
                            customerForm.ShowDialog();
                            this.Close();
                            return;
                        }

                    }
                }
                // Ako nije nadjen u customer, proveravamo u admin
                string sqlAdmin = "SELECT * FROM admins WHERE username = @u AND password = @p";
                using (MySqlCommand cmd = new MySqlCommand(sqlAdmin, con))
                {
                    cmd.Parameters.AddWithValue("@u", username);
                    cmd.Parameters.AddWithValue("@p", password);

                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            dr.Read();
                            MessageBox.Show("Uspešno ste se prijavili kao administrator: " + dr["username"].ToString());
                            ClearFields();
                            var adminForm = new AdminForm();
                            adminForm.ShowDialog();
                            this.Close();
                            return;
                        }
                    }
                }
                // Ako nije ni u jednoj tabeli
                MessageBox.Show("Pogrešan username ili password.");
                ClearFields();
            }

        }
        

        public void buttonShowPassword_Click(object sender, EventArgs e)
        {
            passwordVisible = !passwordVisible;
            textBoxPassword.UseSystemPasswordChar = !passwordVisible;
            buttonShowPassword.Text = passwordVisible ? "🙈" : "👁";
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            var registrationForm = new RegistrationForm();
            registrationForm.ShowDialog();

        }
    }
}
