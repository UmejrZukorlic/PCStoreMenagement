namespace PCStoreMenagement
{
    partial class CustomerForm
    {
        private System.ComponentModel.IContainer components = null;

        private Label dobrodosliLabel;
        private DataGridView dgvProducts;
        private TextBox txtName;
        private TextBox txtBrand;
        private TextBox txtDescription;
        private TextBox txtPrice;
        private TextBox txtStock;
        private Label lblName;
        private Label lblBrand;
        private Label lblDescription;
        private Label lblPrice;
        private Label lblStock;

        private DataGridView dgvCart;
        private Button btnAddToCart;
        private Button btnMakePurchase;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            dobrodosliLabel = new Label();
            dgvProducts = new DataGridView();
            txtName = new TextBox();
            txtBrand = new TextBox();
            txtDescription = new TextBox();
            txtPrice = new TextBox();
            txtStock = new TextBox();
            lblName = new Label();
            lblBrand = new Label();
            lblDescription = new Label();
            lblPrice = new Label();
            lblStock = new Label();
            dgvCart = new DataGridView();
            btnAddToCart = new Button();
            btnMakePurchase = new Button();
            btnViewCart = new Button();
            removeSelectedBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvCart).BeginInit();
            SuspendLayout();
            // 
            // dobrodosliLabel
            // 
            dobrodosliLabel.AutoSize = true;
            dobrodosliLabel.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            dobrodosliLabel.Location = new Point(12, 16);
            dobrodosliLabel.Name = "dobrodosliLabel";
            dobrodosliLabel.Size = new Size(134, 31);
            dobrodosliLabel.TabIndex = 0;
            dobrodosliLabel.Text = "Dobrodošli";
            // 
            // dgvProducts
            // 
            dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProducts.Location = new Point(12, 56);
            dgvProducts.Name = "dgvProducts";
            dgvProducts.RowHeadersWidth = 51;
            dgvProducts.Size = new Size(1044, 160);
            dgvProducts.TabIndex = 1;
            dgvProducts.CellClick += dgvProducts_CellClick;
            // 
            // txtName
            // 
            txtName.Location = new Point(103, 229);
            txtName.Name = "txtName";
            txtName.ReadOnly = true;
            txtName.Size = new Size(241, 27);
            txtName.TabIndex = 3;
            // 
            // txtBrand
            // 
            txtBrand.Location = new Point(471, 229);
            txtBrand.Name = "txtBrand";
            txtBrand.ReadOnly = true;
            txtBrand.Size = new Size(241, 27);
            txtBrand.TabIndex = 5;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(103, 279);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.ReadOnly = true;
            txtDescription.Size = new Size(241, 73);
            txtDescription.TabIndex = 7;
            // 
            // txtPrice
            // 
            txtPrice.Font = new Font("Segoe UI", 12F);
            txtPrice.Location = new Point(471, 322);
            txtPrice.Name = "txtPrice";
            txtPrice.ReadOnly = true;
            txtPrice.Size = new Size(241, 34);
            txtPrice.TabIndex = 9;
            // 
            // txtStock
            // 
            txtStock.Location = new Point(471, 279);
            txtStock.Name = "txtStock";
            txtStock.ReadOnly = true;
            txtStock.Size = new Size(241, 27);
            txtStock.TabIndex = 11;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(19, 232);
            lblName.Name = "lblName";
            lblName.Size = new Size(52, 20);
            lblName.TabIndex = 2;
            lblName.Text = "Name:";
            // 
            // lblBrand
            // 
            lblBrand.AutoSize = true;
            lblBrand.Location = new Point(359, 236);
            lblBrand.Name = "lblBrand";
            lblBrand.Size = new Size(51, 20);
            lblBrand.TabIndex = 4;
            lblBrand.Text = "Brand:";
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Location = new Point(11, 279);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(88, 20);
            lblDescription.TabIndex = 6;
            lblDescription.Text = "Description:";
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Font = new Font("Segoe UI", 12F);
            lblPrice.Location = new Point(359, 328);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(58, 28);
            lblPrice.TabIndex = 8;
            lblPrice.Text = "Price:";
            // 
            // lblStock
            // 
            lblStock.AutoSize = true;
            lblStock.Location = new Point(359, 282);
            lblStock.Name = "lblStock";
            lblStock.Size = new Size(108, 20);
            lblStock.TabIndex = 10;
            lblStock.Text = "Stock Quantity:";
            // 
            // dgvCart
            // 
            dgvCart.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCart.Location = new Point(283, 377);
            dgvCart.Name = "dgvCart";
            dgvCart.RowHeadersWidth = 51;
            dgvCart.Size = new Size(768, 120);
            dgvCart.TabIndex = 12;
            // 
            // btnAddToCart
            // 
            btnAddToCart.Location = new Point(804, 265);
            btnAddToCart.Name = "btnAddToCart";
            btnAddToCart.Size = new Size(172, 55);
            btnAddToCart.TabIndex = 13;
            btnAddToCart.Text = "Add to Cart";
            btnAddToCart.UseVisualStyleBackColor = true;
            btnAddToCart.Click += btnAddToCart_Click;
            // 
            // btnMakePurchase
            // 
            btnMakePurchase.Location = new Point(753, 503);
            btnMakePurchase.Name = "btnMakePurchase";
            btnMakePurchase.Size = new Size(150, 35);
            btnMakePurchase.TabIndex = 14;
            btnMakePurchase.Text = "Make Purchase";
            btnMakePurchase.UseVisualStyleBackColor = true;
            btnMakePurchase.Click += btnMakePurchase_Click;
            // 
            // btnViewCart
            // 
            btnViewCart.Location = new Point(909, 503);
            btnViewCart.Name = "btnViewCart";
            btnViewCart.Size = new Size(142, 35);
            btnViewCart.TabIndex = 15;
            btnViewCart.Text = "View Cart";
            btnViewCart.UseVisualStyleBackColor = true;
            btnViewCart.Click += btnViewCart_Click;
            // 
            // removeSelectedBtn
            // 
            removeSelectedBtn.Location = new Point(580, 503);
            removeSelectedBtn.Name = "removeSelectedBtn";
            removeSelectedBtn.Size = new Size(167, 35);
            removeSelectedBtn.TabIndex = 16;
            removeSelectedBtn.Text = "Remove Selected";
            removeSelectedBtn.UseVisualStyleBackColor = true;
            removeSelectedBtn.Click += removeSelectedBtn_Click;
            // 
            // CustomerForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1063, 550);
            Controls.Add(removeSelectedBtn);
            Controls.Add(btnViewCart);
            Controls.Add(dobrodosliLabel);
            Controls.Add(dgvProducts);
            Controls.Add(lblName);
            Controls.Add(txtName);
            Controls.Add(lblBrand);
            Controls.Add(txtBrand);
            Controls.Add(lblDescription);
            Controls.Add(txtDescription);
            Controls.Add(lblPrice);
            Controls.Add(txtPrice);
            Controls.Add(lblStock);
            Controls.Add(txtStock);
            Controls.Add(dgvCart);
            Controls.Add(btnAddToCart);
            Controls.Add(btnMakePurchase);
            Name = "CustomerForm";
            Text = "CustomerForm";
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvCart).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        private Button btnViewCart;
        private Button removeSelectedBtn;
    }
}
