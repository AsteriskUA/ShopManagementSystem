using System;
using System.Windows.Forms;

namespace ShopManagementSystem
{
    partial class ProductsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnMarkForSale = new System.Windows.Forms.Button();
            this.btnViewForSale = new System.Windows.Forms.Button();
            this.btnUnmarkForSale = new System.Windows.Forms.Button();
            this.chkShowOnlyForSale = new System.Windows.Forms.CheckBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExportToPdf = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(9, 79);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(544, 693);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(576, 79);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(160, 52);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Додати товар";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(576, 146);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(160, 52);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "Редагувати товар";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(576, 217);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(160, 52);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Видалити товар";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnMarkForSale
            // 
            this.btnMarkForSale.Location = new System.Drawing.Point(576, 289);
            this.btnMarkForSale.Name = "btnMarkForSale";
            this.btnMarkForSale.Size = new System.Drawing.Size(159, 52);
            this.btnMarkForSale.TabIndex = 4;
            this.btnMarkForSale.Text = "Виставити на продаж";
            this.btnMarkForSale.UseVisualStyleBackColor = true;
            this.btnMarkForSale.Click += new System.EventHandler(this.btnMarkForSale_Click);
            // 
            // btnViewForSale
            // 
            this.btnViewForSale.Location = new System.Drawing.Point(327, 17);
            this.btnViewForSale.Name = "btnViewForSale";
            this.btnViewForSale.Size = new System.Drawing.Size(226, 44);
            this.btnViewForSale.TabIndex = 5;
            this.btnViewForSale.Text = "Перегляд товару для прожаду";
            this.btnViewForSale.UseVisualStyleBackColor = true;
            this.btnViewForSale.Click += new System.EventHandler(this.btnViewForSale_Click);
            // 
            // btnUnmarkForSale
            // 
            this.btnUnmarkForSale.Location = new System.Drawing.Point(576, 357);
            this.btnUnmarkForSale.Name = "btnUnmarkForSale";
            this.btnUnmarkForSale.Size = new System.Drawing.Size(160, 51);
            this.btnUnmarkForSale.TabIndex = 6;
            this.btnUnmarkForSale.Text = "Зняти з продажу";
            this.btnUnmarkForSale.UseVisualStyleBackColor = true;
            this.btnUnmarkForSale.Click += new System.EventHandler(this.btnUnmarkForSale_Click);
            // 
            // chkShowOnlyForSale
            // 
            this.chkShowOnlyForSale.AutoSize = true;
            this.chkShowOnlyForSale.Location = new System.Drawing.Point(9, 55);
            this.chkShowOnlyForSale.Name = "chkShowOnlyForSale";
            this.chkShowOnlyForSale.Size = new System.Drawing.Size(130, 17);
            this.chkShowOnlyForSale.TabIndex = 7;
            this.chkShowOnlyForSale.Text = "Товари для продажу";
            this.chkShowOnlyForSale.UseVisualStyleBackColor = true;
            this.chkShowOnlyForSale.CheckedChanged += new System.EventHandler(this.chkShowOnlyForSale_CheckedChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(12, 29);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(127, 20);
            this.txtSearch.TabIndex = 8;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(145, 29);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(71, 20);
            this.btnSearch.TabIndex = 9;
            this.btnSearch.Text = "Пошук";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Пошук товару";
            // 
            // btnExportToPdf
            // 
            this.btnExportToPdf.Location = new System.Drawing.Point(576, 697);
            this.btnExportToPdf.Name = "btnExportToPdf";
            this.btnExportToPdf.Size = new System.Drawing.Size(159, 73);
            this.btnExportToPdf.TabIndex = 11;
            this.btnExportToPdf.Text = "Експорт у PDF";
            this.btnExportToPdf.UseVisualStyleBackColor = true;
            this.btnExportToPdf.Click += new System.EventHandler(this.btnExportToPdf_Click_1);
            // 
            // ProductsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(757, 782);
            this.Controls.Add(this.btnExportToPdf);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.chkShowOnlyForSale);
            this.Controls.Add(this.btnUnmarkForSale);
            this.Controls.Add(this.btnViewForSale);
            this.Controls.Add(this.btnMarkForSale);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dataGridView1);
            this.Name = "ProductsForm";
            this.Text = "ProductsForm";
            this.Load += new System.EventHandler(this.ProductsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void ChkShowOnlyForSale_CheckedChanged(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var addForm = new AddProductForm(this);
            addForm.ShowDialog(); 
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion
        private System.Windows.Forms.Button btnExportToPdf;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private Button btnMarkForSale;
        private Button btnViewForSale;
        private Button btnUnmarkForSale;
        private CheckBox chkShowOnlyForSale;
        private TextBox txtSearch;
        private Button btnSearch;
        private Label label1;

    }
}