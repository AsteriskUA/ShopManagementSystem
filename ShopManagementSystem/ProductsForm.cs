using System;
using System.Data;
using System.Data.Entity;
using System.Data.SQLite;
using System.Windows.Forms;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Text;



namespace ShopManagementSystem
{
    public partial class ProductsForm : Form
    {
        public ProductsForm()
        {
            InitializeComponent();
        }

        private void ProductsForm_Load(object sender, EventArgs e)
        {
            LoadProducts();
        }

        public void LoadProducts()
        {
            if (dataGridView1.Columns.Count == 0)
            {
                dataGridView1.Columns.Add("Id", "ID");
                dataGridView1.Columns.Add("Name", "Назва");
                dataGridView1.Columns.Add("Price", "Ціна");
                dataGridView1.Columns.Add("Quantity", "Кількість");
                dataGridView1.Columns.Add("IsForSale", "У продажу");
            }

            dataGridView1.Rows.Clear();

            using (var connection = new SQLiteConnection(Users.ConnectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Products WHERE 1 = 1";

                if (chkShowOnlyForSale.Checked)
                {
                    query += " AND IsForSale = 1";
                }

                if (!string.IsNullOrWhiteSpace(txtSearch.Text))
                {
                    query += " AND Name LIKE @search";
                }

                using (var command = new SQLiteCommand(query, connection))
                {
                    if (!string.IsNullOrWhiteSpace(txtSearch.Text))
                    {
                        command.Parameters.AddWithValue("@search", "%" + txtSearch.Text + "%");
                    }

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dataGridView1.Rows.Add(
                                reader["Id"],
                                reader["Name"],
                                reader["Price"],
                                reader["Quantity"],
                                Convert.ToBoolean(reader["IsForSale"]) ? "Так" : "Ні"
                            );

                        }
                    }
                }
            }
        }



        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Оберіть товар для редагування.");
                return;
            }

            var row = dataGridView1.SelectedRows[0];

            int id = Convert.ToInt32(row.Cells["Id"].Value);
            string name = row.Cells["Name"].Value.ToString();
            decimal price = Convert.ToDecimal(row.Cells["Price"].Value);
            int quantity = Convert.ToInt32(row.Cells["Quantity"].Value);

            var editForm = new EditProductForm(id, name, price, quantity, this);
            editForm.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Оберіть товар для видалення.");
                return;
            }

            var result = MessageBox.Show("Ви впевнені, що хочете видалити цей товар?", "Підтвердження", MessageBoxButtons.YesNo);
            if (result != DialogResult.Yes)
                return;

            var row = dataGridView1.SelectedRows[0];
            int id = Convert.ToInt32(row.Cells["Id"].Value);

            using (var connection = new SQLiteConnection(Users.ConnectionString))
            {
                connection.Open();
                using (var command = new SQLiteCommand("DELETE FROM Products WHERE Id = @id", connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Товар видалено.");
            LoadProducts(); // оновлюємо таблицю
        }

        private void btnMarkForSale_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Оберіть товар для виставлення на продаж.");
                return;
            }

            var row = dataGridView1.SelectedRows[0];
            int id = Convert.ToInt32(row.Cells["Id"].Value);

            using (var connection = new SQLiteConnection(Users.ConnectionString))
            {
                connection.Open();
                using (var command = new SQLiteCommand("UPDATE Products SET IsForSale = 1 WHERE Id = @id", connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Товар виставлено на продаж.");
            LoadProducts();
        }

        private void btnViewForSale_Click(object sender, EventArgs e)
        {
            var form = new ProductsForSaleForm();
            form.ShowDialog();
        }

        private void btnUnmarkForSale_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Оберіть товар для зняття з продажу.");
                return;
            }

            var row = dataGridView1.SelectedRows[0];
            int id = Convert.ToInt32(row.Cells["Id"].Value);

            using (var connection = new SQLiteConnection(Users.ConnectionString))
            {
                connection.Open();
                using (var command = new SQLiteCommand("UPDATE Products SET IsForSale = 0 WHERE Id = @id", connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Товар знято з продажу.");
            LoadProducts();
        }

        private void chkShowOnlyForSale_CheckedChanged(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadProducts(); // перезавантажити товари з урахуванням пошуку
        }



        private void btnExportToPdf_Click_1(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF файли (*.pdf)|*.pdf";
            saveFileDialog.Title = "Зберегти як PDF";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                Document doc = new Document(PageSize.A4);
                PdfWriter.GetInstance(doc, new FileStream(saveFileDialog.FileName, FileMode.Create));
                doc.Open();

                // Підключення шрифту з кирилицею
                string fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "arial.ttf");
                BaseFont baseFont = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                Font font = new Font(baseFont, 12);

                PdfPTable table = new PdfPTable(dataGridView1.Columns.Count);

                // Заголовки
                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    PdfPCell headerCell = new PdfPCell(new Phrase(column.HeaderText, font));
                    table.AddCell(headerCell);
                }

                // Дані таблиці
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            string cellText = cell.Value?.ToString() ?? "";
                            PdfPCell dataCell = new PdfPCell(new Phrase(cellText, font));
                            table.AddCell(dataCell);
                        }
                    }
                }

                // Додати таблицю до документу (одну!)
                doc.Add(table);

                doc.Close();

                MessageBox.Show("Експорт завершено успішно!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }

}

