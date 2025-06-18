using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace ShopManagementSystem
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            using (var connection = new SQLiteConnection(Users.ConnectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT COUNT(*) FROM Users WHERE Username = @username AND Password = @password";
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);

                var count = Convert.ToInt32(command.ExecuteScalar());

                if (count > 0)
                {
                    // Успішна авторизація
                    this.Hide();
                    var productsForm = new ProductsForm();
                    productsForm.FormClosed += (s, args) => this.Close(); // закриє LoginForm при виході з ProductsForm
                    productsForm.Show();
                }
                else
                {
                    MessageBox.Show("Невірний логін або пароль.");
                }
            }
        }
    }
}
