
namespace MedicalShop
{
    partial class frmPurchaseOrder
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgOrderedItems = new System.Windows.Forms.DataGridView();
            this.txtOrderItemFilter = new System.Windows.Forms.TextBox();
            this.lblFilterVvendorProducts = new System.Windows.Forms.Label();
            this.lblProductCount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbVendor = new System.Windows.Forms.ComboBox();
            this.lblVendor = new System.Windows.Forms.Label();
            this.groupBoxOrderItems = new System.Windows.Forms.GroupBox();
            this.dgPurchaseOrder = new System.Windows.Forms.DataGridView();
            this.select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbPurchaseTitles = new System.Windows.Forms.ComboBox();
            this.Delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnSavveOrder = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.productNameDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.discountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.freeQtyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.purchaseOrderDetailsInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.quantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stockDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productRateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendorRateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.runningIndexDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.purchaseOrderInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgOrderedItems)).BeginInit();
            this.groupBoxOrderItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPurchaseOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.purchaseOrderDetailsInfoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.purchaseOrderInfoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = global::Properties.Resources.panel1_BackgroundImage;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.lblTotalAmount);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btnSavveOrder);
            this.panel1.Controls.Add(this.cmbPurchaseTitles);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.txtOrderItemFilter);
            this.panel1.Controls.Add(this.lblFilterVvendorProducts);
            this.panel1.Controls.Add(this.lblProductCount);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cmbVendor);
            this.panel1.Controls.Add(this.lblVendor);
            this.panel1.Controls.Add(this.groupBoxOrderItems);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1134, 561);
            this.panel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgOrderedItems);
            this.groupBox1.Location = new System.Drawing.Point(734, 60);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(399, 442);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ordered Items";
            // 
            // dgOrderedItems
            // 
            this.dgOrderedItems.AutoGenerateColumns = false;
            this.dgOrderedItems.BackgroundColor = System.Drawing.Color.White;
            this.dgOrderedItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgOrderedItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.productNameDataGridViewTextBoxColumn1,
            this.qtyDataGridViewTextBoxColumn,
            this.discountDataGridViewTextBoxColumn,
            this.freeQtyDataGridViewTextBoxColumn,
            this.rateDataGridViewTextBoxColumn,
            this.Delete});
            this.dgOrderedItems.DataSource = this.purchaseOrderDetailsInfoBindingSource;
            this.dgOrderedItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgOrderedItems.Location = new System.Drawing.Point(3, 16);
            this.dgOrderedItems.Name = "dgOrderedItems";
            this.dgOrderedItems.Size = new System.Drawing.Size(393, 423);
            this.dgOrderedItems.TabIndex = 0;
            this.dgOrderedItems.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewOrderItems_CellContentClick);
            // 
            // txtOrderItemFilter
            // 
            this.txtOrderItemFilter.Location = new System.Drawing.Point(65, 40);
            this.txtOrderItemFilter.Name = "txtOrderItemFilter";
            this.txtOrderItemFilter.Size = new System.Drawing.Size(385, 20);
            this.txtOrderItemFilter.TabIndex = 7;
            this.txtOrderItemFilter.TextChanged += new System.EventHandler(this.txtOrderItemFilter_TextChanged);
            // 
            // lblFilterVvendorProducts
            // 
            this.lblFilterVvendorProducts.AutoSize = true;
            this.lblFilterVvendorProducts.Location = new System.Drawing.Point(15, 45);
            this.lblFilterVvendorProducts.Name = "lblFilterVvendorProducts";
            this.lblFilterVvendorProducts.Size = new System.Drawing.Size(32, 13);
            this.lblFilterVvendorProducts.TabIndex = 6;
            this.lblFilterVvendorProducts.Text = "Filter ";
            // 
            // lblProductCount
            // 
            this.lblProductCount.AutoSize = true;
            this.lblProductCount.Location = new System.Drawing.Point(117, 512);
            this.lblProductCount.Name = "lblProductCount";
            this.lblProductCount.Size = new System.Drawing.Size(0, 13);
            this.lblProductCount.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 512);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Total Products : ";
            // 
            // cmbVendor
            // 
            this.cmbVendor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbVendor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbVendor.FormattingEnabled = true;
            this.cmbVendor.Location = new System.Drawing.Point(65, 14);
            this.cmbVendor.Name = "cmbVendor";
            this.cmbVendor.Size = new System.Drawing.Size(385, 21);
            this.cmbVendor.TabIndex = 3;
            this.cmbVendor.SelectedIndexChanged += new System.EventHandler(this.cmbVendor_SelectedIndexChanged);
            // 
            // lblVendor
            // 
            this.lblVendor.AutoSize = true;
            this.lblVendor.Location = new System.Drawing.Point(12, 18);
            this.lblVendor.Name = "lblVendor";
            this.lblVendor.Size = new System.Drawing.Size(41, 13);
            this.lblVendor.TabIndex = 2;
            this.lblVendor.Text = "Vendor";
            // 
            // groupBoxOrderItems
            // 
            this.groupBoxOrderItems.Controls.Add(this.dgPurchaseOrder);
            this.groupBoxOrderItems.Location = new System.Drawing.Point(12, 60);
            this.groupBoxOrderItems.Name = "groupBoxOrderItems";
            this.groupBoxOrderItems.Size = new System.Drawing.Size(716, 442);
            this.groupBoxOrderItems.TabIndex = 0;
            this.groupBoxOrderItems.TabStop = false;
            this.groupBoxOrderItems.Text = "Vendor Products";
            // 
            // dgPurchaseOrder
            // 
            this.dgPurchaseOrder.AutoGenerateColumns = false;
            this.dgPurchaseOrder.BackgroundColor = System.Drawing.Color.White;
            this.dgPurchaseOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPurchaseOrder.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.select,
            this.quantityDataGridViewTextBoxColumn,
            this.productNameDataGridViewTextBoxColumn,
            this.stockDataGridViewTextBoxColumn,
            this.productRateDataGridViewTextBoxColumn,
            this.vendorRateDataGridViewTextBoxColumn,
            this.runningIndexDataGridViewTextBoxColumn});
            this.dgPurchaseOrder.DataSource = this.purchaseOrderInfoBindingSource;
            this.dgPurchaseOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgPurchaseOrder.Location = new System.Drawing.Point(3, 16);
            this.dgPurchaseOrder.Name = "dgPurchaseOrder";
            this.dgPurchaseOrder.Size = new System.Drawing.Size(710, 423);
            this.dgPurchaseOrder.TabIndex = 0;
            this.dgPurchaseOrder.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellContentClick);
            // 
            // select
            // 
            this.select.HeaderText = "Select";
            this.select.Name = "select";
            this.select.Width = 50;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(734, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Order Title";
            // 
            // cmbPurchaseTitles
            // 
            this.cmbPurchaseTitles.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbPurchaseTitles.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbPurchaseTitles.FormattingEnabled = true;
            this.cmbPurchaseTitles.Location = new System.Drawing.Point(796, 10);
            this.cmbPurchaseTitles.Name = "cmbPurchaseTitles";
            this.cmbPurchaseTitles.Size = new System.Drawing.Size(276, 21);
            this.cmbPurchaseTitles.TabIndex = 10;
            // 
            // Delete
            // 
            this.Delete.HeaderText = "Delete";
            this.Delete.Name = "Delete";
            this.Delete.Text = "Delete";
            this.Delete.UseColumnTextForButtonValue = true;
            this.Delete.Width = 50;
            // 
            // btnSavveOrder
            // 
            this.btnSavveOrder.Location = new System.Drawing.Point(994, 507);
            this.btnSavveOrder.Name = "btnSavveOrder";
            this.btnSavveOrder.Size = new System.Drawing.Size(75, 23);
            this.btnSavveOrder.TabIndex = 11;
            this.btnSavveOrder.Text = "Save ";
            this.btnSavveOrder.UseVisualStyleBackColor = true;
            this.btnSavveOrder.Click += new System.EventHandler(this.btnSavveOrder_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(737, 510);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Total Amount : ";
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Location = new System.Drawing.Point(822, 512);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(0, 13);
            this.lblTotalAmount.TabIndex = 13;
            // 
            // productNameDataGridViewTextBoxColumn1
            // 
            this.productNameDataGridViewTextBoxColumn1.DataPropertyName = "ProductName";
            this.productNameDataGridViewTextBoxColumn1.HeaderText = "ProductName";
            this.productNameDataGridViewTextBoxColumn1.Name = "productNameDataGridViewTextBoxColumn1";
            // 
            // qtyDataGridViewTextBoxColumn
            // 
            this.qtyDataGridViewTextBoxColumn.DataPropertyName = "Qty";
            this.qtyDataGridViewTextBoxColumn.HeaderText = "Qty";
            this.qtyDataGridViewTextBoxColumn.Name = "qtyDataGridViewTextBoxColumn";
            this.qtyDataGridViewTextBoxColumn.Width = 50;
            // 
            // discountDataGridViewTextBoxColumn
            // 
            this.discountDataGridViewTextBoxColumn.DataPropertyName = "Discount";
            this.discountDataGridViewTextBoxColumn.HeaderText = "Discount";
            this.discountDataGridViewTextBoxColumn.Name = "discountDataGridViewTextBoxColumn";
            this.discountDataGridViewTextBoxColumn.Width = 50;
            // 
            // freeQtyDataGridViewTextBoxColumn
            // 
            this.freeQtyDataGridViewTextBoxColumn.DataPropertyName = "FreeQty";
            this.freeQtyDataGridViewTextBoxColumn.HeaderText = "FreeQty";
            this.freeQtyDataGridViewTextBoxColumn.Name = "freeQtyDataGridViewTextBoxColumn";
            this.freeQtyDataGridViewTextBoxColumn.Width = 50;
            // 
            // rateDataGridViewTextBoxColumn
            // 
            this.rateDataGridViewTextBoxColumn.DataPropertyName = "Rate";
            this.rateDataGridViewTextBoxColumn.HeaderText = "Rate";
            this.rateDataGridViewTextBoxColumn.Name = "rateDataGridViewTextBoxColumn";
            this.rateDataGridViewTextBoxColumn.Width = 50;
            // 
            // purchaseOrderDetailsInfoBindingSource
            // 
            this.purchaseOrderDetailsInfoBindingSource.DataSource = typeof(MedicalShop.PurchaseOrderDetailsInfo);
            // 
            // quantityDataGridViewTextBoxColumn
            // 
            this.quantityDataGridViewTextBoxColumn.DataPropertyName = "Quantity";
            this.quantityDataGridViewTextBoxColumn.HeaderText = "Quantity";
            this.quantityDataGridViewTextBoxColumn.Name = "quantityDataGridViewTextBoxColumn";
            this.quantityDataGridViewTextBoxColumn.Width = 70;
            // 
            // productNameDataGridViewTextBoxColumn
            // 
            this.productNameDataGridViewTextBoxColumn.DataPropertyName = "ProductName";
            this.productNameDataGridViewTextBoxColumn.HeaderText = "Product";
            this.productNameDataGridViewTextBoxColumn.Name = "productNameDataGridViewTextBoxColumn";
            this.productNameDataGridViewTextBoxColumn.Width = 180;
            // 
            // stockDataGridViewTextBoxColumn
            // 
            this.stockDataGridViewTextBoxColumn.DataPropertyName = "Stock";
            this.stockDataGridViewTextBoxColumn.HeaderText = "Stock";
            this.stockDataGridViewTextBoxColumn.Name = "stockDataGridViewTextBoxColumn";
            this.stockDataGridViewTextBoxColumn.Width = 70;
            // 
            // productRateDataGridViewTextBoxColumn
            // 
            this.productRateDataGridViewTextBoxColumn.DataPropertyName = "ProductRate";
            this.productRateDataGridViewTextBoxColumn.HeaderText = "Product Rate";
            this.productRateDataGridViewTextBoxColumn.Name = "productRateDataGridViewTextBoxColumn";
            // 
            // vendorRateDataGridViewTextBoxColumn
            // 
            this.vendorRateDataGridViewTextBoxColumn.DataPropertyName = "VendorRate";
            this.vendorRateDataGridViewTextBoxColumn.HeaderText = "Vendor Rate";
            this.vendorRateDataGridViewTextBoxColumn.Name = "vendorRateDataGridViewTextBoxColumn";
            // 
            // runningIndexDataGridViewTextBoxColumn
            // 
            this.runningIndexDataGridViewTextBoxColumn.DataPropertyName = "RunningIndex";
            this.runningIndexDataGridViewTextBoxColumn.HeaderText = "Running Index";
            this.runningIndexDataGridViewTextBoxColumn.Name = "runningIndexDataGridViewTextBoxColumn";
            // 
            // purchaseOrderInfoBindingSource
            // 
            this.purchaseOrderInfoBindingSource.DataSource = typeof(MedicalShop.PurchaseOrderInfo);
            // 
            // frmPurchaseOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1134, 561);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "frmPurchaseOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Purchase Order";
            this.Load += new System.EventHandler(this.frmPurchaseOrder_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgOrderedItems)).EndInit();
            this.groupBoxOrderItems.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgPurchaseOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.purchaseOrderDetailsInfoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.purchaseOrderInfoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBoxOrderItems;
        private System.Windows.Forms.DataGridView dgPurchaseOrder;
        private System.Windows.Forms.ComboBox cmbVendor;
        private System.Windows.Forms.Label lblVendor;
        private System.Windows.Forms.BindingSource purchaseOrderInfoBindingSource;
        private System.Windows.Forms.Label lblProductCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn select;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn stockDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productRateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorRateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn runningIndexDataGridViewTextBoxColumn;
        private System.Windows.Forms.TextBox txtOrderItemFilter;
        private System.Windows.Forms.Label lblFilterVvendorProducts;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgOrderedItems;
        private System.Windows.Forms.BindingSource purchaseOrderDetailsInfoBindingSource;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbPurchaseTitles;
        private System.Windows.Forms.DataGridViewTextBoxColumn productNameDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn discountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn freeQtyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn Delete;
        private System.Windows.Forms.Button btnSavveOrder;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Label label3;
    }
}