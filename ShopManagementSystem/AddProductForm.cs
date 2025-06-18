using System;
using System.Data.Entity;
using System.Data.SQLite;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ShopManagementSystem
{
    public partial class AddProductForm : Form
    {
        public AddProductForm(AddProductForm addProductForm)
        {
            InitializeComponent();
            LoadProducts();
        }
        private ProductsForm _productsForm;

        public AddProductForm(ProductsForm productsForm)
        {
            InitializeComponent();
            _productsForm = productsForm;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            decimal price = decimal.Parse(txtPrice.Text.Trim());
            int quantity = int.Parse(txtQuantity.Text.Trim());

            AddProduct(name, price, quantity);

            _productsForm.LoadProducts(); // <--- додано: оновити таблицю
            this.Close(); // закрити форму додавання
        }


        private void AddProduct(string name, decimal price, int quantity)
        {
            using (var connection = new SQLiteConnection(Users.ConnectionString))
            {
                connection.Open();

                using (var command = new SQLiteCommand(connection))
                {
                    command.CommandText = "INSERT INTO Products (Name, Price, Quantity) VALUES (@name, @price, @quantity)";
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@price", price);
                    command.Parameters.AddWithValue("@quantity", quantity);

                    command.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Товар додано успішно");
        }

        private void LoadProducts()
        {
            // тут код для оновлення таблиці
        }
    }

}

