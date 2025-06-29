﻿namespace PCStoreMenagement
{
    partial class RegistrationForm // Ensure partial and correct namespace
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed of; otherwise, false.</param>
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            labelFirstName = new Label();
            labelLastName = new Label();
            labelUsername = new Label();
            labelPassword = new Label();
            labelRePassword = new Label();
            textBoxFirstName = new TextBox();
            textBoxLastName = new TextBox();
            textBoxUsername = new TextBox();
            textBoxEmail = new TextBox();
            textBoxAddress = new TextBox();
            labelEmail = new Label();
            labelAddress = new Label();
            textBoxPassword = new TextBox();
            textBoxRePassword = new TextBox();
            buttonShowPassword = new Button();
            buttonRegister = new Button();
            button1 = new Button();
            SuspendLayout();
            // 
            // labelFirstName
            // 
            labelFirstName.AutoSize = true;
            labelFirstName.Location = new Point(29, 34);
            labelFirstName.Margin = new Padding(4, 0, 4, 0);
            labelFirstName.Name = "labelFirstName";
            labelFirstName.Size = new Size(97, 25);
            labelFirstName.TabIndex = 0;
            labelFirstName.Text = "First Name";
            // 
            // labelLastName
            // 
            labelLastName.AutoSize = true;
            labelLastName.Location = new Point(29, 91);
            labelLastName.Margin = new Padding(4, 0, 4, 0);
            labelLastName.Name = "labelLastName";
            labelLastName.Size = new Size(95, 25);
            labelLastName.TabIndex = 1;
            labelLastName.Text = "Last Name";
            // 
            // labelUsername
            // 
            labelUsername.AutoSize = true;
            labelUsername.Location = new Point(29, 150);
            labelUsername.Margin = new Padding(4, 0, 4, 0);
            labelUsername.Name = "labelUsername";
            labelUsername.Size = new Size(91, 25);
            labelUsername.TabIndex = 2;
            labelUsername.Text = "Username";
            // 
            // labelPassword
            // 
            labelPassword.AutoSize = true;
            labelPassword.Location = new Point(29, 316);
            labelPassword.Margin = new Padding(4, 0, 4, 0);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(87, 25);
            labelPassword.TabIndex = 5;
            labelPassword.Text = "Password";
            // 
            // labelRePassword
            // 
            labelRePassword.AutoSize = true;
            labelRePassword.Location = new Point(29, 373);
            labelRePassword.Margin = new Padding(4, 0, 4, 0);
            labelRePassword.Name = "labelRePassword";
            labelRePassword.Size = new Size(113, 25);
            labelRePassword.TabIndex = 6;
            labelRePassword.Text = "Re-Password";
            // 
            // textBoxFirstName
            // 
            textBoxFirstName.Location = new Point(171, 29);
            textBoxFirstName.Margin = new Padding(4, 5, 4, 5);
            textBoxFirstName.Name = "textBoxFirstName";
            textBoxFirstName.Size = new Size(255, 31);
            textBoxFirstName.TabIndex = 7;
            // 
            // textBoxLastName
            // 
            textBoxLastName.Location = new Point(171, 86);
            textBoxLastName.Margin = new Padding(4, 5, 4, 5);
            textBoxLastName.Name = "textBoxLastName";
            textBoxLastName.Size = new Size(255, 31);
            textBoxLastName.TabIndex = 8;
            // 
            // textBoxUsername
            // 
            textBoxUsername.Location = new Point(171, 145);
            textBoxUsername.Margin = new Padding(4, 5, 4, 5);
            textBoxUsername.Name = "textBoxUsername";
            textBoxUsername.Size = new Size(255, 31);
            textBoxUsername.TabIndex = 9;
            // 
            // textBoxEmail
            // 
            textBoxEmail.Location = new Point(171, 202);
            textBoxEmail.Margin = new Padding(4, 5, 4, 5);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(255, 31);
            textBoxEmail.TabIndex = 10;
            // 
            // textBoxAddress
            // 
            textBoxAddress.Location = new Point(171, 253);
            textBoxAddress.Margin = new Padding(4, 5, 4, 5);
            textBoxAddress.Name = "textBoxAddress";
            textBoxAddress.Size = new Size(255, 31);
            textBoxAddress.TabIndex = 11;
            // 
            // labelEmail
            // 
            labelEmail.AutoSize = true;
            labelEmail.Location = new Point(29, 208);
            labelEmail.Margin = new Padding(4, 0, 4, 0);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new Size(61, 25);
            labelEmail.TabIndex = 3;
            labelEmail.Text = "E-mail";
            // 
            // labelAddress
            // 
            labelAddress.AutoSize = true;
            labelAddress.Location = new Point(29, 259);
            labelAddress.Margin = new Padding(4, 0, 4, 0);
            labelAddress.Name = "labelAddress";
            labelAddress.Size = new Size(77, 25);
            labelAddress.TabIndex = 4;
            labelAddress.Text = "Address";
            // 
            // textBoxPassword
            // 
            textBoxPassword.Location = new Point(171, 311);
            textBoxPassword.Margin = new Padding(4, 5, 4, 5);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.PlaceholderText = "Min 4 karaktera";
            textBoxPassword.Size = new Size(198, 31);
            textBoxPassword.TabIndex = 12;
            textBoxPassword.UseSystemPasswordChar = true;
            // 
            // textBoxRePassword
            // 
            textBoxRePassword.Location = new Point(171, 368);
            textBoxRePassword.Margin = new Padding(4, 5, 4, 5);
            textBoxRePassword.Name = "textBoxRePassword";
            textBoxRePassword.PlaceholderText = "Ponovi lozinku (min 4 karaktera)";
            textBoxRePassword.Size = new Size(198, 31);
            textBoxRePassword.TabIndex = 13;
            textBoxRePassword.UseSystemPasswordChar = true;
            // 
            // buttonShowPassword
            // 
            buttonShowPassword.Location = new Point(386, 311);
            buttonShowPassword.Margin = new Padding(4, 5, 4, 5);
            buttonShowPassword.Name = "buttonShowPassword";
            buttonShowPassword.Size = new Size(42, 39);
            buttonShowPassword.TabIndex = 14;
            buttonShowPassword.Text = "👁";
            buttonShowPassword.UseVisualStyleBackColor = true;
            buttonShowPassword.Click += buttonShowPassword_Click;
            // 
            // buttonRegister
            // 
            buttonRegister.Location = new Point(171, 441);
            buttonRegister.Margin = new Padding(4, 5, 4, 5);
            buttonRegister.Name = "buttonRegister";
            buttonRegister.Size = new Size(258, 50);
            buttonRegister.TabIndex = 15;
            buttonRegister.Text = "Register";
            buttonRegister.UseVisualStyleBackColor = true;
            buttonRegister.Click += buttonRegister_Click;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(29, 441);
            button1.Name = "button1";
            button1.Size = new Size(115, 44);
            button1.TabIndex = 16;
            button1.Text = "<==";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // RegistrationForm
            // 
            AccessibleRole = AccessibleRole.None;
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Info;
            ClientSize = new Size(486, 510);
            Controls.Add(button1);
            Controls.Add(labelFirstName);
            Controls.Add(textBoxFirstName);
            Controls.Add(labelLastName);
            Controls.Add(textBoxLastName);
            Controls.Add(labelUsername);
            Controls.Add(textBoxUsername);
            Controls.Add(labelEmail);
            Controls.Add(textBoxEmail);
            Controls.Add(labelAddress);
            Controls.Add(textBoxAddress);
            Controls.Add(labelPassword);
            Controls.Add(textBoxPassword);
            Controls.Add(buttonShowPassword);
            Controls.Add(labelRePassword);
            Controls.Add(textBoxRePassword);
            Controls.Add(buttonRegister);
            Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 5, 4, 5);
            Name = "RegistrationForm";
            Text = "Registracija";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label labelFirstName;
        private System.Windows.Forms.Label labelLastName;
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.Label labelRePassword;
        private System.Windows.Forms.TextBox textBoxFirstName;
        private System.Windows.Forms.TextBox textBoxLastName;
        private System.Windows.Forms.TextBox textBoxUsername;
        private TextBox textBoxEmail;
        private TextBox textBoxAddress;
        private Label labelEmail;
        private Label labelAddress;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.TextBox textBoxRePassword;
        private System.Windows.Forms.Button buttonShowPassword;
        private System.Windows.Forms.Button buttonRegister;
        private Button button1;
    }
}