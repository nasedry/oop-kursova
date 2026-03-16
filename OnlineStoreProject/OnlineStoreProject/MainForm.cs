using Microsoft.EntityFrameworkCore;
using OnlineStoreProject.Core;
using OnlineStoreProject.Data;
using OnlineStoreProject.Patterns;
using System;
using System.Linq;
using System.Windows.Forms;

namespace OnlineStoreProject
{
    public partial class MainForm : Form
    {
        private ApplicationDbContext _dbContext;
        private Cart _cart;

        public MainForm()
        {
            InitializeComponent();

            _dbContext = new ApplicationDbContext();
            _cart = new Cart();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadProductsFromDatabase();
        }

        private void LoadProductsFromDatabase()
        {
            var products = _dbContext.Products.ToList();
            _dgvProducts.DataSource = products;

            if (_dgvProducts.Columns["Id"] != null) _dgvProducts.Columns["Id"].Visible = false;
            if (_dgvProducts.Columns["Name"] != null)
            {
                _dgvProducts.Columns["Name"].HeaderText = "Назва товару";
                _dgvProducts.Columns["Name"].Width = 200;
            }
            if (_dgvProducts.Columns["Price"] != null)
            {
                _dgvProducts.Columns["Price"].HeaderText = "Ціна (грн)";
            }
        }

        private void BtnAddToCart_Click(object sender, EventArgs e)
        {
            if (_dgvProducts.SelectedRows.Count > 0)
            {
                var product = _dgvProducts.SelectedRows[0].DataBoundItem as Product;
                int quantity = (int)_numQuantity.Value;

                if (product != null)
                {
                    // Створюємо айтем кошика ТІЛЬКИ через ID, 
                    // щоб база не думала, що ми хочемо додати новий товар
                    _cart.AddProduct(product, quantity);
                    
                    UpdateCartUI();
                    MessageBox.Show($"Додано: {product.Name} ({quantity} шт.)");
                }
            }
            else
            {
                MessageBox.Show("Будь ласка, виберіть товар у таблиці.");
            }
        }

        private void UpdateCartUI()
        {
            _lstCart.Items.Clear();
            decimal totalSum = 0;

            IIterator<CartItem> iterator = _cart.GetIterator();

            while (iterator.HasNext())
            {
                var item = iterator.Next();
                decimal itemTotal = item.Product.Price * item.Quantity;
                totalSum += itemTotal;

                _lstCart.Items.Add($"{item.Product.Name} | {item.Quantity} шт. | {itemTotal} грн");
            }

            _lblTotal.Text = $"Загальна сума: {totalSum} грн";
        }

        private void BtnCheckout_Click(object sender, EventArgs e)
        {
            try
            {
                IOrderBuilder builder = new OrderBuilder();

                PricingStrategy strategy;
                if (chkDiscount.Checked)
                {
                    strategy = new PercentageDiscountStrategy(10); // 10% знижка
                }
                else
                {
                    strategy = new NoDiscountStrategy(); // Без знижки
                }

                Order newOrder = builder
                    .SetCustomer(_txtName.Text)
                    .SetAddress(_txtAddress.Text)
                    .SetPricingStrategy(strategy)
                    .AddItemsFromCart(_cart.GetIterator())
                    .Build();

                _dbContext.Orders.Add(newOrder);
                _dbContext.SaveChanges();

                MessageBox.Show(
                    $"Замовлення №{newOrder.Id} успішно оформлено!\n" +
                    $"Клієнт: {newOrder.CustomerName}\n" +
                    $"Сума до сплати: {newOrder.TotalPrice} грн.",
                    "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);

                _cart.Clear();
                UpdateCartUI();
                _txtName.Clear();
                _txtAddress.Clear();
                _numQuantity.Value = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка оформлення", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnShowHistory_Click(object sender, EventArgs e)
        {
            var orders = _dbContext.Orders.Include(o => o.Items).ToList();

            if (orders.Count == 0)
            {
                MessageBox.Show("Історія замовлень порожня.", "Історія");
                return;
            }

            string history = "Ваші попередні замовлення:\n\n";
            foreach (var order in orders)
            {
                history += $"Замовлення №{order.Id} від {order.OrderDate:dd.MM.yyyy HH:mm}\n";
                history += $"Клієнт: {order.CustomerName} ({order.Address})\n";
                history += $"Сума: {order.TotalPrice} грн\n";
                history += "---------------------------\n";
            }

            MessageBox.Show(history, "Історія замовлень", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnClearCart_Click(object sender, EventArgs e)
        {
            _cart.Clear();
            UpdateCartUI();
        }
    }
}