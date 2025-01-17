using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace InventoryApp
{
    public partial class Form1 : Form
    {
        private List<Product> inventory = new List<Product>();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtName.Text) && int.TryParse(txtQuantity.Text, out int quantity) && double.TryParse(txtPrice.Text, out double price))
            {
                Product product = new Product
                {
                    Id = inventory.Count + 1,
                    Name = txtName.Text,
                    Quantity = quantity,
                    Price = price
                };

                inventory.Add(product);
                MessageBox.Show("کالا اضافه شد!");
                RefreshGrid();
                ClearInputs();
            }
            else
            {
                MessageBox.Show("ورودی نامعتبر است!");
            }
        }

        private void RefreshGrid()
        {
            dgvProducts.DataSource = null;
            dgvProducts.DataSource = inventory;
        }

        private void ClearInputs()
        {
            txtName.Text = "";
            txtQuantity.Text = "";
            txtPrice.Text = "";
        }
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}
