using MySqlConnector;
using System;
using System.Data;
using System.Windows.Forms;

namespace PCStoreMenagement
{
    public partial class CustomerForm : Form
    {
        private string connectionString = Properties.Settings.Default.conStr;
        private string _username;

        private DataTable productsTable = new DataTable();
        private DataTable cartTable = new DataTable();

        public CustomerForm(string username)
        {
            InitializeComponent();
            _username = username;
            dobrodosliLabel.Text = $"Dobrodošli, {_username}";

            SetupProductsGrid();
            SetupCartGrid();
            LoadProducts();
            dgvCart.Visible = false;
            btnMakePurchase.Visible = false;
            removeSelectedBtn.Visible = false;

        }
        #region NEGENERICKE METODE
        private void ClearFields()
        {
            txtName.Clear();
            txtBrand.Clear();
            txtDescription.Clear();
            txtPrice.Clear();
            txtStock.Clear();
        }

        private void SetupProductsGrid()
        {
            productsTable.Columns.Add("product_id", typeof(int));
            productsTable.Columns.Add("name", typeof(string));
            productsTable.Columns.Add("brand", typeof(string));
            productsTable.Columns.Add("category", typeof(string));
            productsTable.Columns.Add("description", typeof(string));
            productsTable.Columns.Add("price", typeof(int));
            productsTable.Columns.Add("stock_quantity", typeof(int));

            dgvProducts.DataSource = productsTable;
            dgvProducts.Columns["product_id"].Visible = false;
            dgvProducts.Columns["price"].DefaultCellStyle.Format = "C2";
        }

        private void SetupCartGrid()
        {
            cartTable.Columns.Add("product_id", typeof(int));
            cartTable.Columns.Add("name", typeof(string));
            cartTable.Columns.Add("brand", typeof(string));
            cartTable.Columns.Add("price", typeof(int));
            cartTable.Columns.Add("quantity", typeof(int));
            cartTable.Columns.Add("total", typeof(int), "price * quantity");

            dgvCart.DataSource = cartTable;
            dgvCart.Columns["product_id"].Visible = false;
            dgvCart.Columns["price"].DefaultCellStyle.Format = "C2";
            dgvCart.Columns["total"].DefaultCellStyle.Format = "C2";
        }

        private void LoadProducts()
        {
            productsTable.Clear();

            using (var con = new MySqlConnection(connectionString))
            {
                con.Open();
                string query = @"SELECT
                                p.*,
                                c.name AS category,
                                b.name AS brand
                                FROM product p
                                JOIN category c ON p.category_id = c.category_id
                                JOIN brand b ON p.brand_id = b.brand_id;";
                using (var cmd = new MySqlCommand(query, con))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        productsTable.Rows.Add(
                            reader.GetInt32("product_id"),
                            reader.GetString("name"),
                            reader.GetString("brand"),
                            reader.GetString("category"),
                            reader.GetString("description"),
                            reader.GetInt32("price"),
                            reader.GetInt32("stock_quantity")
                        );
                    }
                }
            }
        }
        #endregion

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvProducts.Rows[e.RowIndex];
            txtName.Text = row.Cells["name"].Value.ToString();
            txtBrand.Text = row.Cells["brand"].Value.ToString();
            txtDescription.Text = row.Cells["description"].Value.ToString();
            txtPrice.Text = row.Cells["price"].Value.ToString();
            txtStock.Text = row.Cells["stock_quantity"].Value.ToString();
        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Please select a product first.");
                return;
            }

            int productId = (int)dgvProducts.CurrentRow.Cells["product_id"].Value;
            string name = txtName.Text;
            string brand = txtBrand.Text;
            int price = int.Parse(txtPrice.Text);
            int stock = int.Parse(txtStock.Text);

            if (stock <= 0)
            {
                MessageBox.Show("Product out of stock.");
                return;
            }

            var existingRow = cartTable.Select($"product_id = {productId}");
            if (existingRow.Length > 0)
            {
                var row = existingRow[0];
                int currentQty = (int)row["quantity"];
                if (currentQty + 1 > stock)
                {
                    MessageBox.Show("Not enough stock available.");
                    return;
                }
                row["quantity"] = currentQty + 1;
            }
            else
            {
                cartTable.Rows.Add(productId, name, brand, price, 1);
            }
            btnViewCart.BackColor = Color.Orange;
            btnViewCart.ForeColor = Color.White;
        }

        private void btnMakePurchase_Click(object sender, EventArgs e)
        {
            if (cartTable.Rows.Count == 0)
            {
                MessageBox.Show("Cart is empty.");
                return;
            }


            using (var con = new MySqlConnection(connectionString))
            {
                con.Open();
                var transaction = con.BeginTransaction();

                try
                {
                    int customerId = 0;
                    using (var cmd = new MySqlCommand("SELECT customer_id FROM customer WHERE username = @username", con, transaction))
                    {
                        cmd.Parameters.AddWithValue("@username", _username);
                        var result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            customerId = Convert.ToInt32(result);
                        }
                        else
                        {
                            throw new Exception("Customer not found.");
                        }
                    }

                    string orderInsert = "INSERT INTO `order` (customer_id, total_amount) VALUES (@customer_id, @total)";
                    int totalAmount = 0;
                    foreach (DataRow row in cartTable.Rows)
                        totalAmount += (int)row["total"];

                    using (var cmdOrder = new MySqlCommand(orderInsert, con, transaction))
                    {
                        cmdOrder.Parameters.AddWithValue("@customer_id", customerId);
                        cmdOrder.Parameters.AddWithValue("@total", totalAmount);
                        cmdOrder.ExecuteNonQuery();
                    }


                    long orderId = 0;
                    using (var cmdLastId = new MySqlCommand("SELECT LAST_INSERT_ID()", con, transaction))
                    {
                        orderId = Convert.ToInt64(cmdLastId.ExecuteScalar());
                    }

                    string itemInsert = "INSERT INTO order_item (order_id, product_id, quantity) VALUES (@order_id, @product_id, @qty)";
                    string stockUpdate = "UPDATE product SET stock_quantity = stock_quantity - @qty WHERE product_id = @product_id";

                    foreach (DataRow row in cartTable.Rows)
                    {
                        int productId = (int)row["product_id"];
                        int qty = (int)row["quantity"];

                        using (var cmdItem = new MySqlCommand(itemInsert, con, transaction))
                        {
                            cmdItem.Parameters.AddWithValue("@order_id", orderId);
                            cmdItem.Parameters.AddWithValue("@product_id", productId);
                            cmdItem.Parameters.AddWithValue("@qty", qty);
                            cmdItem.ExecuteNonQuery();
                        }

                        using (var cmdStock = new MySqlCommand(stockUpdate, con, transaction))
                        {
                            cmdStock.Parameters.AddWithValue("@qty", qty);
                            cmdStock.Parameters.AddWithValue("@product_id", productId);
                            cmdStock.ExecuteNonQuery();
                        }
                    }

                    transaction.Commit();

                    MessageBox.Show("Purchase successful!");
                    cartTable.Clear();
                    btnViewCart.BackColor = SystemColors.Control;
                    btnViewCart.ForeColor = SystemColors.ControlText;

                    LoadProducts();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Purchase failed: " + ex.Message);
                }
                ClearFields();
            }


        }

        private void btnViewCart_Click(object sender, EventArgs e)
        {
            bool isCartVisible = dgvCart.Visible;
            dgvCart.Visible = !isCartVisible;
            btnMakePurchase.Visible = !isCartVisible;
            removeSelectedBtn.Visible = !isCartVisible;
            btnViewCart.Text = isCartVisible ? "View Cart" : "Hide Cart";

        }

        private void removeSelectedBtn_Click(object sender, EventArgs e)
        {
            if (dgvCart.SelectedRows.Count>0)
            {
                dgvCart.Rows.RemoveAt(dgvCart.SelectedRows[0].Index);
            }
            else
            {
                MessageBox.Show("Please select a product to remove from the cart.");
            }
        }
    }
}
