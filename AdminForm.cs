using MySqlConnector;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace PCStoreMenagement
{
    public partial class AdminForm : Form
    {
        string conStr = Properties.Settings.Default.conStr;

        public AdminForm()
        {
            InitializeComponent();
            LoadAllData();
            LoadCategories();
            LoadBrands();
            deleteButton.Enabled = false;
            customerDeleteButton.Enabled = false;
        }

        private int selectedCustomerId = -1;


        #region NE GENERICKE METODE

        private DataTable GetDataTableFromDB(string query)
        {
            DataTable dt = new DataTable();

            using (MySqlConnection con = new MySqlConnection(conStr))
            {
                try
                {
                    con.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading data: " + ex.Message);
                }
            }

            return dt;
        }

        private void ClearFields()
        {
            nameBox.Text = "";
            descBox.Text = "";
            priceBox.Value = priceBox.Minimum;
            quantityBox.Value = quantityBox.Minimum;
            if (categoryBox.Items.Count > 0)
                categoryBox.SelectedIndex = 0;
            if (brandBox.Items.Count > 0)
                brandBox.SelectedIndex = 0;

            selectedProductId = -1;
            AIButton.Text = "ADD";
            deleteButton.Enabled = false;

        }
        private void ResetCustomerForm()
        {
            usernameBox.Text = "";
            passwordBox.Text = "";
            firstNameBox.Text = "";
            lastNameBox.Text = "";
            emailBox.Text = "";
            addressBox.Text = "";

            selectedCustomerId = -1;

            customerAIButton.Text = "ADD";
            customerDeleteButton.Enabled = false;
        }


        private int GetCategoryIdByName(string categoryName)
        {
            DataTable dt = (DataTable)categoryBox.DataSource;
            foreach (DataRow row in dt.Rows)
            {
                if (row["display_name"].ToString() == categoryName)
                    return Convert.ToInt32(row["category_id"]);
            }
            return -1;
        }

        private int GetBrandIdByName(string brandName)
        {
            DataTable dt = (DataTable)brandBox.DataSource;
            foreach (DataRow row in dt.Rows)
            {
                if (row["name"].ToString() == brandName)
                    return Convert.ToInt32(row["brand_id"]);
            }
            return -1;
        }
        private void LoadOrderItems(int orderId)
        {
            using (MySqlConnection conn = new MySqlConnection(conStr))
            {
                conn.Open();
                string query = @"
            SELECT 
                p.name AS ProductName,
                oi.quantity AS Quantity,
                p.price AS UnitPrice,
                (oi.quantity * p.price) AS Total
            FROM order_item oi
            JOIN product p ON oi.product_id = p.product_id
            WHERE oi.order_id = @orderId";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@orderId", orderId);
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvOrderItems.DataSource = dt;
                    }
                }
            }
        }
        #endregion

        private void LoadAllData()
        {
            LoadCustomers();
            LoadProducts();
            LoadOrders();
        }

        private void LoadCustomers()
        {
            string query = "SELECT * FROM customer";
            DataTable dt = GetDataTableFromDB(query);
            dgvCustomers.DataSource = dt;
        }

        private void LoadProducts()
        {
            string query = @"
                            SELECT
                                p.product_id,   
                                p.name,
                                p.description, 
                                p.price,
                                p.stock_quantity,
                                c.name AS 'Category',
                                b.name AS 'Brand'
                            FROM pc_store.product p
                            JOIN category c ON p.category_id = c.category_id
                            JOIN pc_store.brand b ON p.brand_id = b.brand_id;
                        ";

            DataTable dt = GetDataTableFromDB(query);
            dgvProducts.DataSource = dt;
        }

        private void LoadOrders()
        {
            string query = @"
                           SELECT 
                    o.order_id AS OrderID,
                    o.order_date AS OrderDate,
                    CONCAT(c.first_name, ' ', c.last_name) AS CustomerName,
                    GROUP_CONCAT(CONCAT(p.name, ' x', oi.quantity) SEPARATOR ', ') AS Products,
                    SUM(oi.quantity * p.price) AS TotalPrice,
                    o.status AS OrderStatus
                FROM `order` o
                JOIN customer c ON o.customer_id = c.customer_id
                JOIN order_item oi ON o.order_id = oi.order_id
                JOIN product p ON oi.product_id = p.product_id
                GROUP BY o.order_id, o.order_date, c.first_name, c.last_name, o.status
                ORDER BY o.order_id;
            ";

            DataTable dt = GetDataTableFromDB(query);
            dgvOrders.DataSource = dt;
        }

        private void LoadCategories()
        {
            using (MySqlConnection conn = new MySqlConnection(conStr))
            {
                conn.Open();
                string query = @"
                            SELECT 
                                category_id,
                                CASE 
                                    WHEN parent_id IS NULL THEN name
                                    ELSE CONCAT('   └ ', name)
                                END AS display_name
                            FROM category
                            ORDER BY 
                            COALESCE(parent_id, category_id), parent_id IS NOT NULL, name;
                        ";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Nema podataka u tabeli category!");
                }

                categoryBox.DataSource = dt;
                categoryBox.DisplayMember = "display_name";
                categoryBox.ValueMember = "category_id";
            }
        }

        private void LoadBrands()
        {
            using (MySqlConnection conn = new MySqlConnection(conStr))
            {
                conn.Open();
                string query = "SELECT brand_id, name FROM brand";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Nema podataka u tabeli brand!");
                }

                brandBox.DataSource = dt;
                brandBox.DisplayMember = "name";
                brandBox.ValueMember = "brand_id";
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCategories();
            LoadBrands();
        }

        private int selectedProductId = -1;

        private void AIButton_Click(object sender, EventArgs e)
        {
            if (categoryBox.SelectedValue == null || brandBox.SelectedValue == null)
            {
                MessageBox.Show("Morate izabrati kategoriju i brend!");
                return;
            }

            string name = nameBox.Text;
            string description = descBox.Text;
            decimal price = priceBox.Value;
            int quantity = (int)quantityBox.Value;
            int categoryId = Convert.ToInt32(categoryBox.SelectedValue);
            int brandId = Convert.ToInt32(brandBox.SelectedValue);

            using (MySqlConnection con = new MySqlConnection(conStr))
            {
                con.Open();

                MySqlCommand checkCategory = new MySqlCommand("SELECT COUNT(*) FROM category WHERE category_id = @catId", con);
                checkCategory.Parameters.AddWithValue("@catId", categoryId);
                long categoryExists = (long)checkCategory.ExecuteScalar();

                if (categoryExists == 0)
                {
                    MessageBox.Show("Izabrana kategorija ne postoji u bazi!");
                    return;
                }

                MySqlCommand checkBrand = new MySqlCommand("SELECT COUNT(*) FROM brand WHERE brand_id = @brandId", con);
                checkBrand.Parameters.AddWithValue("@brandId", brandId);
                long brandExists = (long)checkBrand.ExecuteScalar();

                if (brandExists == 0)
                {
                    MessageBox.Show("Izabrani brend ne postoji u bazi!");
                    return;
                }

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;

                if (AIButton.Text == "ADD")
                {
                    cmd.CommandText = @"INSERT INTO product 
                                (name, description, price, stock_quantity, category_id, brand_id) 
                                VALUES (@name, @desc, @price, @qty, @cat, @brand)";
                }
                else if (AIButton.Text == "UPDATE")
                {
                    if (selectedProductId == -1)
                    {
                        MessageBox.Show("Nije izabran proizvod za ažuriranje!");
                        return;
                    }

                    cmd.CommandText = @"UPDATE product 
                                SET name = @name,
                                    description = @desc,
                                    price = @price,
                                    stock_quantity = @qty,
                                    category_id = @cat,
                                    brand_id = @brand
                                WHERE product_id = @id";

                    cmd.Parameters.AddWithValue("@id", selectedProductId);
                }

                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@desc", description);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@qty", quantity);
                cmd.Parameters.AddWithValue("@cat", categoryId);
                cmd.Parameters.AddWithValue("@brand", brandId);

                cmd.ExecuteNonQuery();

                MessageBox.Show(AIButton.Text == "ADD" ? "Product added!" : "Product updated!");

                ClearFields();
                LoadProducts();
            }
        }

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvProducts.Rows[e.RowIndex];
                selectedProductId = Convert.ToInt32(row.Cells["product_id"].Value);

                nameBox.Text = row.Cells["name"].Value.ToString();
                descBox.Text = row.Cells["description"].Value.ToString();

                decimal price = Convert.ToDecimal(row.Cells["price"].Value);
                if (priceBox.Maximum < price)
                    priceBox.Maximum = price;
                priceBox.Value = price;

                int qty = Convert.ToInt32(row.Cells["stock_quantity"].Value);
                if (quantityBox.Maximum < qty)
                    quantityBox.Maximum = qty;
                quantityBox.Value = qty;

                categoryBox.SelectedValue = GetCategoryIdByName(row.Cells["Category"].Value.ToString());
                brandBox.SelectedValue = GetBrandIdByName(row.Cells["Brand"].Value.ToString());

                AIButton.Text = "UPDATE";
                deleteButton.Enabled = true;

            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (selectedProductId == -1)
            {
                MessageBox.Show("Nije izabran proizvod za brisanje!");
                return;
            }

            var result = MessageBox.Show("Da li ste sigurni da želite da obrišete ovaj proizvod?",
                                         "Potvrda brisanja",
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
                return;

            using (MySqlConnection con = new MySqlConnection(conStr))
            {
                con.Open();

                // 1. Proveri da li proizvod postoji u porudžbinama
                string checkQuery = "SELECT COUNT(*) FROM order_item WHERE product_id = @productId";
                using (var checkCmd = new MySqlCommand(checkQuery, con))
                {
                    checkCmd.Parameters.AddWithValue("@productId", selectedProductId);
                    int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                    if (count > 0)
                    {
                        MessageBox.Show("Ne možete obrisati proizvod jer postoji u porudžbinama.");
                        ClearFields();
                        return;
                    }
                }

                // 2. Ako nije u porudžbinama, obriši ga
                using (MySqlCommand cmd = new MySqlCommand("DELETE FROM product WHERE product_id = @id", con))
                {
                    cmd.Parameters.AddWithValue("@id", selectedProductId);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Proizvod je obrisan!");

                ClearFields();
                LoadProducts();
            }
        }


        private void dgvCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // da nije header kliknut
            {
                DataGridViewRow row = dgvCustomers.Rows[e.RowIndex];
                selectedCustomerId = Convert.ToInt32(row.Cells["customer_id"].Value); // Pretpostavljam da tabela ima kolonu "id"

                usernameBox.Text = row.Cells["username"].Value?.ToString();
                passwordBox.Text = row.Cells["password"].Value?.ToString();
                firstNameBox.Text = row.Cells["first_name"].Value?.ToString();
                lastNameBox.Text = row.Cells["last_name"].Value?.ToString();
                addressBox.Text = row.Cells["address"].Value?.ToString();
                emailBox.Text = row.Cells["email"].Value?.ToString();

                customerAIButton.Text = "UPDATE";
                customerDeleteButton.Enabled = true;
            }
        }

        private void customerAIButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(usernameBox.Text) ||
                string.IsNullOrWhiteSpace(passwordBox.Text))
            {
                MessageBox.Show("Username i Password su obavezni.");
                return;
            }

            using (var con = new MySqlConnection(conStr))
            {
                con.Open();
                MySqlCommand cmd;

                if (selectedCustomerId == -1)
                {
                    string insertQuery = "INSERT INTO customer (username, password, first_name, last_name, email, address) " +
                                         "VALUES (@username, @password, @firstName, @lastName, @email, @address)";
                    cmd = new MySqlCommand(insertQuery, con);
                }
                else
                {
                    string updateQuery = "UPDATE customer SET username=@username, password=@password, first_name=@firstName, last_name=@lastName, email=@email, address=@address " +
                                         "WHERE customer_id=@id";
                    cmd = new MySqlCommand(updateQuery, con);
                    cmd.Parameters.AddWithValue("@id", selectedCustomerId);
                }

                cmd.Parameters.AddWithValue("@username", usernameBox.Text);
                cmd.Parameters.AddWithValue("@password", passwordBox.Text);
                cmd.Parameters.AddWithValue("@firstName", firstNameBox.Text);
                cmd.Parameters.AddWithValue("@lastName", lastNameBox.Text);
                cmd.Parameters.AddWithValue("@email", emailBox.Text);
                cmd.Parameters.AddWithValue("@address", addressBox.Text);

                try
                {
                    cmd.ExecuteNonQuery();
                    LoadCustomers();
                    MessageBox.Show(selectedCustomerId == -1 ? "Korisnik dodat." : "Korisnik ažuriran.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Greška: " + ex.Message);
                }
                ResetCustomerForm();
            }
        }

        private void customerDeleteButton_Click(object sender, EventArgs e)
        {
            if (selectedCustomerId == -1)
            {
                MessageBox.Show("Nije odabran korisnik za brisanje.");
                return;
            }

            var confirm = MessageBox.Show("Da li ste sigurni da želite da obrišete ovog korisnika?", "Potvrda", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                using (var con = new MySqlConnection(conStr))
                {
                    con.Open();
                    string deleteQuery = @"DELETE oi FROM order_item oi
                                            JOIN `order` o ON oi.order_id = o.order_id
                                            WHERE o.customer_id = @id;
                                            DELETE FROM `order` WHERE customer_id = @id;
                                            DELETE FROM customer WHERE customer_id = @id;
                                            ";
                    MySqlCommand cmd = new MySqlCommand(deleteQuery, con);
                    cmd.Parameters.AddWithValue("@id", selectedCustomerId);
                    

                    try
                    {
                        cmd.ExecuteNonQuery();
                        LoadCustomers();
                        LoadOrders();

                        MessageBox.Show("Korisnik obrisan.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Greška: " + ex.Message);
                        
                    }
                    ResetCustomerForm();
                }
            }
        }

        
        private void updateStatusButton_Click(object sender, EventArgs e)
        {
            if (statusBox.SelectedItem == null || statusBox.Tag == null)
                return;

            string newStatus = statusBox.SelectedItem.ToString();
            int orderId = Convert.ToInt32(statusBox.Tag);

            using (MySqlConnection conn = new MySqlConnection(conStr))
            {
                conn.Open();
                string query = "UPDATE `order` SET status = @status WHERE order_id = @orderId";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@status", newStatus);
                    cmd.Parameters.AddWithValue("@orderId", orderId);
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Order status updated.");
            LoadOrders(); 
        }


        private void dgvOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int orderId = Convert.ToInt32(dgvOrders.Rows[e.RowIndex].Cells["OrderID"].Value);
                string currentStatus = dgvOrders.Rows[e.RowIndex].Cells["OrderStatus"].Value.ToString();

                LoadOrderItems(orderId); 
                statusBox.SelectedItem = currentStatus; 
                statusBox.Tag = orderId; 
            }
        
        }
    }
}
