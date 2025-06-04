namespace PCStoreMenagement
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private bool passwordVisible = false;

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string username = textBoxUsername.Text;
            string password = textBoxPassword.Text;

            // Simple authentication logic (replace with real authentication as needed)
            if (username == "admin" && password == "password")
            {
                MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Optionally, proceed to the next form or main application window
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
