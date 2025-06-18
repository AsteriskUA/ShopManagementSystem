using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace ShopManagementSystem
{
    public partial class EditProductForm : Form
    {
        private int _productId;
        private ProductsForm _productsForm;

        public EditProductForm(int id, string name, decimal price, int quantity, ProductsForm productsForm)
        {
            InitializeComponent();

            _productId = id;
            _productsForm = productsForm;

            txtName.Text = name;
            txtPrice.Text = price.ToString();
            txtQuantity.Text = quantity.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            decimal price = decimal.Parse(txtPrice.Text.Trim());
            int quantity = int.Parse(txtQuantity.Text.Trim());

            using (var connection = new SQLiteConnection(Users.ConnectionString))
            {
                connection.Open();
                using (var command = new SQLiteCommand(connection))
                {
                    command.CommandText = "UPDATE Products SET Name = @name, Price = @price, Quantity = @quantity WHERE Id = @id";
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@price", price);
                    command.Parameters.AddWithValue("@quantity", quantity);
                    command.Parameters.AddWithValue("@id", _productId);
                    command.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Товар оновлено!");
            _productsForm.LoadProducts();
            this.Close();
        }
    }
}
