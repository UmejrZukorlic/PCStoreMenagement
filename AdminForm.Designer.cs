namespace PCStoreMenagement
{
    partial class AdminForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.DataGridView dgvCustomers;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.DataGridView dgvOrders;
        private System.Windows.Forms.DataGridView dgvOrderItems;
        private System.Windows.Forms.ComboBox statusBox;
        private System.Windows.Forms.Button updateStatusButton;


        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            dgvCustomers = new DataGridView();
            dgvProducts = new DataGridView();
            dgvOrders = new DataGridView();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            dgvOrderItems = new DataGridView();
            statusBox = new ComboBox();
            updateStatusButton = new Button();
            tabPage2 = new TabPage();
            deleteButton = new Button();
            AIButton = new Button();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            brandBox = new ComboBox();
            categoryBox = new ComboBox();
            quantityBox = new NumericUpDown();
            priceBox = new NumericUpDown();
            descBox = new TextBox();
            nameBox = new TextBox();
            tabPage3 = new TabPage();
            customerDeleteButton = new Button();
            customerAIButton = new Button();
            emailBox = new TextBox();
            addressBox = new TextBox();
            lastNameBox = new TextBox();
            firstNameBox = new TextBox();
            passwordBox = new TextBox();
            usernameBox = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvOrders).BeginInit();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOrderItems).BeginInit();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)quantityBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)priceBox).BeginInit();
            tabPage3.SuspendLayout();
            SuspendLayout();
            // 
            // dgvCustomers
            // 
            dgvCustomers.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dgvCustomers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCustomers.Location = new Point(3, 6);
            dgvCustomers.Name = "dgvCustomers";
            dgvCustomers.RowHeadersWidth = 51;
            dgvCustomers.Size = new Size(1054, 140);
            dgvCustomers.TabIndex = 0;
            dgvCustomers.CellClick += dgvCustomers_CellClick;
            // 
            // dgvProducts
            // 
            dgvProducts.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProducts.Location = new Point(6, 63);
            dgvProducts.Name = "dgvProducts";
            dgvProducts.RowHeadersWidth = 51;
            dgvProducts.Size = new Size(1054, 140);
            dgvProducts.TabIndex = 1;
            dgvProducts.CellClick += dgvProducts_CellClick;
            // 
            // dgvOrders
            // 
            dgvOrders.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dgvOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOrders.Location = new Point(6, 6);
            dgvOrders.Name = "dgvOrders";
            dgvOrders.RowHeadersWidth = 51;
            dgvOrders.Size = new Size(1053, 177);
            dgvOrders.TabIndex = 2;
            dgvOrders.CellClick += dgvOrders_CellClick;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Location = new Point(4, 4);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1073, 476);
            tabControl1.TabIndex = 3;
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(dgvOrders);
            tabPage1.Controls.Add(dgvOrderItems);
            tabPage1.Controls.Add(statusBox);
            tabPage1.Controls.Add(updateStatusButton);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1065, 443);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Orders";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvOrderItems
            // 
            dgvOrderItems.ColumnHeadersHeight = 29;
            dgvOrderItems.Location = new Point(6, 189);
            dgvOrderItems.Name = "dgvOrderItems";
            dgvOrderItems.RowHeadersWidth = 51;
            dgvOrderItems.Size = new Size(1053, 150);
            dgvOrderItems.TabIndex = 3;
            // 
            // statusBox
            // 
            statusBox.Items.AddRange(new object[] { "primljena porudzbina", "poslato", "otkazano", "vraceno" });
            statusBox.Location = new Point(6, 370);
            statusBox.Name = "statusBox";
            statusBox.Size = new Size(200, 28);
            statusBox.TabIndex = 4;
            // 
            // updateStatusButton
            // 
            updateStatusButton.Location = new Point(220, 370);
            updateStatusButton.Name = "updateStatusButton";
            updateStatusButton.Size = new Size(75, 28);
            updateStatusButton.TabIndex = 5;
            updateStatusButton.Text = "Update Status";
            updateStatusButton.Click += updateStatusButton_Click;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(deleteButton);
            tabPage2.Controls.Add(AIButton);
            tabPage2.Controls.Add(label4);
            tabPage2.Controls.Add(label3);
            tabPage2.Controls.Add(label2);
            tabPage2.Controls.Add(label1);
            tabPage2.Controls.Add(brandBox);
            tabPage2.Controls.Add(categoryBox);
            tabPage2.Controls.Add(quantityBox);
            tabPage2.Controls.Add(priceBox);
            tabPage2.Controls.Add(descBox);
            tabPage2.Controls.Add(nameBox);
            tabPage2.Controls.Add(dgvProducts);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1065, 443);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Products";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // deleteButton
            // 
            deleteButton.Location = new Point(416, 325);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(94, 29);
            deleteButton.TabIndex = 14;
            deleteButton.Text = "DELETE";
            deleteButton.UseVisualStyleBackColor = true;
            deleteButton.Click += deleteButton_Click;
            // 
            // AIButton
            // 
            AIButton.Location = new Point(303, 325);
            AIButton.Name = "AIButton";
            AIButton.Size = new Size(94, 29);
            AIButton.TabIndex = 13;
            AIButton.Text = "ADD";
            AIButton.UseVisualStyleBackColor = true;
            AIButton.Click += AIButton_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(746, 244);
            label4.Name = "label4";
            label4.Size = new Size(48, 20);
            label4.TabIndex = 12;
            label4.Text = "Brand";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(589, 244);
            label3.Name = "label3";
            label3.Size = new Size(69, 20);
            label3.TabIndex = 11;
            label3.Text = "Category";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(433, 244);
            label2.Name = "label2";
            label2.Size = new Size(65, 20);
            label2.TabIndex = 10;
            label2.Text = "Quantity";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(277, 244);
            label1.Name = "label1";
            label1.Size = new Size(41, 20);
            label1.TabIndex = 9;
            label1.Text = "Price";
            // 
            // brandBox
            // 
            brandBox.FormattingEnabled = true;
            brandBox.Location = new Point(746, 267);
            brandBox.Name = "brandBox";
            brandBox.Size = new Size(151, 28);
            brandBox.TabIndex = 8;
            // 
            // categoryBox
            // 
            categoryBox.FormattingEnabled = true;
            categoryBox.Location = new Point(589, 267);
            categoryBox.Name = "categoryBox";
            categoryBox.Size = new Size(151, 28);
            categoryBox.TabIndex = 7;
            // 
            // quantityBox
            // 
            quantityBox.Location = new Point(433, 267);
            quantityBox.Name = "quantityBox";
            quantityBox.Size = new Size(150, 27);
            quantityBox.TabIndex = 6;
            // 
            // priceBox
            // 
            priceBox.Location = new Point(277, 267);
            priceBox.Name = "priceBox";
            priceBox.Size = new Size(150, 27);
            priceBox.TabIndex = 5;
            // 
            // descBox
            // 
            descBox.Location = new Point(146, 266);
            descBox.Name = "descBox";
            descBox.PlaceholderText = "description";
            descBox.Size = new Size(125, 27);
            descBox.TabIndex = 4;
            // 
            // nameBox
            // 
            nameBox.Location = new Point(15, 266);
            nameBox.Name = "nameBox";
            nameBox.PlaceholderText = "name";
            nameBox.Size = new Size(125, 27);
            nameBox.TabIndex = 2;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(customerDeleteButton);
            tabPage3.Controls.Add(customerAIButton);
            tabPage3.Controls.Add(emailBox);
            tabPage3.Controls.Add(addressBox);
            tabPage3.Controls.Add(lastNameBox);
            tabPage3.Controls.Add(firstNameBox);
            tabPage3.Controls.Add(passwordBox);
            tabPage3.Controls.Add(usernameBox);
            tabPage3.Controls.Add(dgvCustomers);
            tabPage3.Location = new Point(4, 29);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(1065, 443);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Customers";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // customerDeleteButton
            // 
            customerDeleteButton.Location = new Point(555, 294);
            customerDeleteButton.Name = "customerDeleteButton";
            customerDeleteButton.Size = new Size(94, 29);
            customerDeleteButton.TabIndex = 8;
            customerDeleteButton.Text = "DELETE";
            customerDeleteButton.UseVisualStyleBackColor = true;
            customerDeleteButton.Click += customerDeleteButton_Click;
            // 
            // customerAIButton
            // 
            customerAIButton.Location = new Point(401, 294);
            customerAIButton.Name = "customerAIButton";
            customerAIButton.Size = new Size(94, 29);
            customerAIButton.TabIndex = 7;
            customerAIButton.Text = "ADD";
            customerAIButton.UseVisualStyleBackColor = true;
            customerAIButton.Click += customerAIButton_Click;
            // 
            // emailBox
            // 
            emailBox.Location = new Point(768, 207);
            emailBox.Name = "emailBox";
            emailBox.PlaceholderText = "email@email.com";
            emailBox.Size = new Size(154, 27);
            emailBox.TabIndex = 6;
            // 
            // addressBox
            // 
            addressBox.Location = new Point(637, 207);
            addressBox.Name = "addressBox";
            addressBox.PlaceholderText = "address";
            addressBox.Size = new Size(125, 27);
            addressBox.TabIndex = 5;
            // 
            // lastNameBox
            // 
            lastNameBox.Location = new Point(506, 207);
            lastNameBox.Name = "lastNameBox";
            lastNameBox.PlaceholderText = "Last Name";
            lastNameBox.Size = new Size(125, 27);
            lastNameBox.TabIndex = 4;
            // 
            // firstNameBox
            // 
            firstNameBox.Location = new Point(375, 207);
            firstNameBox.Name = "firstNameBox";
            firstNameBox.PlaceholderText = "First Name";
            firstNameBox.Size = new Size(125, 27);
            firstNameBox.TabIndex = 3;
            // 
            // passwordBox
            // 
            passwordBox.Location = new Point(244, 207);
            passwordBox.Name = "passwordBox";
            passwordBox.PlaceholderText = "password";
            passwordBox.Size = new Size(125, 27);
            passwordBox.TabIndex = 2;
            // 
            // usernameBox
            // 
            usernameBox.Location = new Point(113, 207);
            usernameBox.Name = "usernameBox";
            usernameBox.PlaceholderText = "username";
            usernameBox.Size = new Size(125, 27);
            usernameBox.TabIndex = 1;
            // 
            // AdminForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1077, 486);
            Controls.Add(tabControl1);
            Name = "AdminForm";
            Text = "AdminForm";
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvOrders).EndInit();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvOrderItems).EndInit();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)quantityBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)priceBox).EndInit();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private NumericUpDown quantityBox;
        private NumericUpDown priceBox;
        private TextBox descBox;
        private TextBox nameBox;
        private ComboBox brandBox;
        private ComboBox categoryBox;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button deleteButton;
        private Button AIButton;
        private TextBox emailBox;
        private TextBox addressBox;
        private TextBox lastNameBox;
        private TextBox firstNameBox;
        private TextBox passwordBox;
        private TextBox usernameBox;
        private Button customerDeleteButton;
        private Button customerAIButton;
    }
}
