using MySqlConnector;  // Dodaj na vrhu
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        }

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
            string query = "SELECT * FROM product";
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
                p.name AS ProductName,
                oi.quantity AS Quantity,
                p.price AS UnitPrice,
                (oi.quantity * p.price) AS TotalPrice
            FROM `order` o
            JOIN customer c ON o.customer_id = c.customer_id
            JOIN order_item oi ON o.order_id = oi.order_id
            JOIN product p ON oi.product_id = p.product_id
            ORDER BY o.order_id, p.name
            ";



            DataTable dt = GetDataTableFromDB(query);
            dgvOrders.DataSource = dt;
        }



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
    }
}
