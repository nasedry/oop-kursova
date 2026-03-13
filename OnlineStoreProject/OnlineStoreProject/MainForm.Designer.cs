namespace OnlineStoreProject
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            _dgvProducts = new DataGridView();
            lblQty = new Label();
            _numQuantity = new NumericUpDown();
            _btnAddToCart = new Button();
            lblCart = new Label();
            _lstCart = new ListBox();
            _lblTotal = new Label();
            grpCheckout = new GroupBox();
            lblName = new Label();
            _txtName = new TextBox();
            lblAddress = new Label();
            _txtAddress = new TextBox();
            _btnCheckout = new Button();
            BtnClearCart = new Button();
            BtnShowHistory = new Button();
            chkDiscount = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)_dgvProducts).BeginInit();
            ((System.ComponentModel.ISupportInitialize)_numQuantity).BeginInit();
            grpCheckout.SuspendLayout();
            SuspendLayout();
            // 
            // _dgvProducts
            // 
            _dgvProducts.AllowUserToAddRows = false;
            _dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            _dgvProducts.Location = new Point(20, 20);
            _dgvProducts.Name = "_dgvProducts";
            _dgvProducts.ReadOnly = true;
            _dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            _dgvProducts.Size = new Size(320, 200);
            _dgvProducts.TabIndex = 0;
            // 
            // lblQty
            // 
            lblQty.AutoSize = true;
            lblQty.Location = new Point(20, 235);
            lblQty.Name = "lblQty";
            lblQty.Size = new Size(59, 15);
            lblQty.TabIndex = 1;
            lblQty.Text = "Кількість:";
            // 
            // _numQuantity
            // 
            _numQuantity.Location = new Point(85, 232);
            _numQuantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            _numQuantity.Name = "_numQuantity";
            _numQuantity.Size = new Size(50, 23);
            _numQuantity.TabIndex = 2;
            _numQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // _btnAddToCart
            // 
            _btnAddToCart.Location = new Point(174, 230);
            _btnAddToCart.Name = "_btnAddToCart";
            _btnAddToCart.Size = new Size(166, 28);
            _btnAddToCart.TabIndex = 3;
            _btnAddToCart.Text = "Додати в кошик";
            _btnAddToCart.UseVisualStyleBackColor = true;
            _btnAddToCart.Click += BtnAddToCart_Click;
            // 
            // lblCart
            // 
            lblCart.AutoSize = true;
            lblCart.Location = new Point(370, 20);
            lblCart.Name = "lblCart";
            lblCart.Size = new Size(74, 15);
            lblCart.TabIndex = 4;
            lblCart.Text = "Ваш кошик:";
            // 
            // _lstCart
            // 
            _lstCart.FormattingEnabled = true;
            _lstCart.ItemHeight = 15;
            _lstCart.Location = new Point(370, 40);
            _lstCart.Name = "_lstCart";
            _lstCart.Size = new Size(280, 169);
            _lstCart.TabIndex = 5;
            // 
            // _lblTotal
            // 
            _lblTotal.Font = new Font("Arial", 10F, FontStyle.Bold);
            _lblTotal.Location = new Point(370, 230);
            _lblTotal.Name = "_lblTotal";
            _lblTotal.Size = new Size(280, 23);
            _lblTotal.TabIndex = 6;
            _lblTotal.Text = "Загальна сума: 0 грн";
            // 
            // grpCheckout
            // 
            grpCheckout.Controls.Add(lblName);
            grpCheckout.Controls.Add(_txtName);
            grpCheckout.Controls.Add(lblAddress);
            grpCheckout.Controls.Add(_txtAddress);
            grpCheckout.Controls.Add(_btnCheckout);
            grpCheckout.Location = new Point(20, 310);
            grpCheckout.Name = "grpCheckout";
            grpCheckout.Size = new Size(630, 120);
            grpCheckout.TabIndex = 7;
            grpCheckout.TabStop = false;
            grpCheckout.Text = "Оформлення замовлення";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(20, 35);
            lblName.Name = "lblName";
            lblName.Size = new Size(29, 15);
            lblName.TabIndex = 0;
            lblName.Text = "ПІБ:";
            // 
            // _txtName
            // 
            _txtName.Location = new Point(80, 32);
            _txtName.Name = "_txtName";
            _txtName.Size = new Size(220, 23);
            _txtName.TabIndex = 1;
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Location = new Point(20, 75);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(49, 15);
            lblAddress.TabIndex = 2;
            lblAddress.Text = "Адреса:";
            // 
            // _txtAddress
            // 
            _txtAddress.Location = new Point(80, 72);
            _txtAddress.Name = "_txtAddress";
            _txtAddress.Size = new Size(220, 23);
            _txtAddress.TabIndex = 3;
            // 
            // _btnCheckout
            // 
            _btnCheckout.BackColor = Color.LightGreen;
            _btnCheckout.Font = new Font("Arial", 9.75F, FontStyle.Bold);
            _btnCheckout.Location = new Point(350, 32);
            _btnCheckout.Name = "_btnCheckout";
            _btnCheckout.Size = new Size(250, 63);
            _btnCheckout.TabIndex = 4;
            _btnCheckout.Text = "ОФОРМИТИ ЗАМОВЛЕННЯ";
            _btnCheckout.UseVisualStyleBackColor = false;
            _btnCheckout.Click += BtnCheckout_Click;
            // 
            // BtnClearCart
            // 
            BtnClearCart.Location = new Point(20, 264);
            BtnClearCart.Name = "BtnClearCart";
            BtnClearCart.Size = new Size(148, 28);
            BtnClearCart.TabIndex = 8;
            BtnClearCart.Text = "Очистити кошик";
            BtnClearCart.UseVisualStyleBackColor = true;
            BtnClearCart.Click += BtnClearCart_Click;
            // 
            // BtnShowHistory
            // 
            BtnShowHistory.Location = new Point(174, 264);
            BtnShowHistory.Name = "BtnShowHistory";
            BtnShowHistory.Size = new Size(166, 28);
            BtnShowHistory.TabIndex = 9;
            BtnShowHistory.Text = "Історія замовлень";
            BtnShowHistory.UseVisualStyleBackColor = true;
            BtnShowHistory.Click += BtnShowHistory_Click;
            // 
            // chkDiscount
            // 
            chkDiscount.AutoSize = true;
            chkDiscount.Location = new Point(373, 270);
            chkDiscount.Name = "chkDiscount";
            chkDiscount.Size = new Size(212, 19);
            chkDiscount.TabIndex = 10;
            chkDiscount.Text = "Застосувати святкову знижку 10%";
            chkDiscount.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(684, 442);
            Controls.Add(chkDiscount);
            Controls.Add(BtnShowHistory);
            Controls.Add(BtnClearCart);
            Controls.Add(grpCheckout);
            Controls.Add(_lblTotal);
            Controls.Add(_lstCart);
            Controls.Add(lblCart);
            Controls.Add(_btnAddToCart);
            Controls.Add(_numQuantity);
            Controls.Add(lblQty);
            Controls.Add(_dgvProducts);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Прототип інтернет-магазину";
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)_dgvProducts).EndInit();
            ((System.ComponentModel.ISupportInitialize)_numQuantity).EndInit();
            grpCheckout.ResumeLayout(false);
            grpCheckout.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }


        // Оголошення елементів управління 
        private System.Windows.Forms.DataGridView _dgvProducts;
        private System.Windows.Forms.Label lblQty;
        private System.Windows.Forms.NumericUpDown _numQuantity;
        private System.Windows.Forms.Button _btnAddToCart;
        private System.Windows.Forms.Label lblCart;
        private System.Windows.Forms.ListBox _lstCart;
        private System.Windows.Forms.Label _lblTotal;
        private System.Windows.Forms.GroupBox grpCheckout;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox _txtName;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox _txtAddress;
        private System.Windows.Forms.Button _btnCheckout;
        private Button BtnClearCart;
        private Button BtnShowHistory;
        private CheckBox chkDiscount;
    }
}