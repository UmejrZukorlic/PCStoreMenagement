namespace PCStoreMenagement
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            labelUsername = new Label();
            labelPassword = new Label();
            textBoxUsername = new TextBox();
            textBoxPassword = new TextBox();
            buttonLogin = new Button();
            buttonShowPassword = new Button();
            buttonRegister = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // labelUsername
            // 
            labelUsername.AutoSize = true;
            labelUsername.Location = new Point(239, 161);
            labelUsername.Margin = new Padding(4, 0, 4, 0);
            labelUsername.Name = "labelUsername";
            labelUsername.Size = new Size(95, 25);
            labelUsername.TabIndex = 0;
            labelUsername.Text = "Username:";
            // 
            // labelPassword
            // 
            labelPassword.AutoSize = true;
            labelPassword.Location = new Point(239, 211);
            labelPassword.Margin = new Padding(4, 0, 4, 0);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(91, 25);
            labelPassword.TabIndex = 2;
            labelPassword.Text = "Password:";
            // 
            // textBoxUsername
            // 
            textBoxUsername.Cursor = Cursors.IBeam;
            textBoxUsername.Location = new Point(351, 157);
            textBoxUsername.Margin = new Padding(4, 4, 4, 4);
            textBoxUsername.Name = "textBoxUsername";
            textBoxUsername.Size = new Size(186, 31);
            textBoxUsername.TabIndex = 1;
            // 
            // textBoxPassword
            // 
            textBoxPassword.Cursor = Cursors.IBeam;
            textBoxPassword.Location = new Point(351, 207);
            textBoxPassword.Margin = new Padding(4, 4, 4, 4);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new Size(186, 31);
            textBoxPassword.TabIndex = 3;
            textBoxPassword.UseSystemPasswordChar = true;
            // 
            // buttonLogin
            // 
            buttonLogin.Cursor = Cursors.Hand;
            buttonLogin.Location = new Point(239, 266);
            buttonLogin.Margin = new Padding(4, 4, 4, 4);
            buttonLogin.Name = "buttonLogin";
            buttonLogin.Size = new Size(161, 38);
            buttonLogin.TabIndex = 4;
            buttonLogin.Text = "Login";
            buttonLogin.UseVisualStyleBackColor = true;
            buttonLogin.Click += buttonLogin_Click;
            // 
            // buttonShowPassword
            // 
            buttonShowPassword.Cursor = Cursors.Hand;
            buttonShowPassword.Location = new Point(551, 207);
            buttonShowPassword.Margin = new Padding(4, 4, 4, 4);
            buttonShowPassword.Name = "buttonShowPassword";
            buttonShowPassword.Size = new Size(61, 34);
            buttonShowPassword.TabIndex = 5;
            buttonShowPassword.Text = "👁";
            buttonShowPassword.UseVisualStyleBackColor = true;
            buttonShowPassword.Click += buttonShowPassword_Click;
            // 
            // buttonRegister
            // 
            buttonRegister.Cursor = Cursors.Hand;
            buttonRegister.Location = new Point(434, 266);
            buttonRegister.Margin = new Padding(4, 4, 4, 4);
            buttonRegister.Name = "buttonRegister";
            buttonRegister.Size = new Size(188, 38);
            buttonRegister.TabIndex = 6;
            buttonRegister.Text = "Registruj se";
            buttonRegister.UseVisualStyleBackColor = true;
            buttonRegister.Click += buttonRegister_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(300, 49);
            label1.Name = "label1";
            label1.Size = new Size(277, 46);
            label1.TabIndex = 7;
            label1.Text = "PC Store System";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Info;
            ClientSize = new Size(895, 407);
            Controls.Add(label1);
            Controls.Add(labelUsername);
            Controls.Add(textBoxUsername);
            Controls.Add(labelPassword);
            Controls.Add(textBoxPassword);
            Controls.Add(buttonLogin);
            Controls.Add(buttonShowPassword);
            Controls.Add(buttonRegister);
            Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 4, 4, 4);
            Name = "Form1";
            Text = "Login Form";
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.Button buttonShowPassword;
        private System.Windows.Forms.Button buttonRegister;

        #endregion

        private Label label1;
    }
}
