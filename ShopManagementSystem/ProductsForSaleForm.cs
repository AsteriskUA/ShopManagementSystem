using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace ShopManagementSystem
{
    public partial class ProductsForSaleForm : Form
    {
        public ProductsForSaleForm()
        {
            InitializeComponent();
        }

        private void ProductsForSaleForm_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns.Add("Id", "ID");
            dataGridView1.Columns.Add("Name", "Назва");
            dataGridView1.Columns.Add("Price", "Ціна");
            dataGridView1.Columns.Add("Quantity", "Кількість");

            using (var connection = new SQLiteConnection(Users.ConnectionString))
            {
                connection.Open();

                using (var command = new SQLiteCommand("SELECT * FROM Products WHERE IsForSale = 1", connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dataGridView1.Rows.Add(
                            reader["Id"],
                            reader["Name"],
                            reader["Price"],
                            reader["Quantity"]
                        );
                    }
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnBack_Click_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
