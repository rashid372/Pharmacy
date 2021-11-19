
namespace MedicalShop
{
    partial class frmVendorProducts
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVendorProducts));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgdSearch = new System.Windows.Forms.DataGridView();
            this.SelectRow = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtSearchFor = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbSearch = new System.Windows.Forms.ComboBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.cmbSearchBy = new System.Windows.Forms.ComboBox();
            this.lblSearc = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtVendorProductFilter = new System.Windows.Forms.TextBox();
            this.lblFilterVvendorProducts = new System.Windows.Forms.Label();
            this.dbVendorProducts = new System.Windows.Forms.DataGridView();
            this.delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.cmbVendor = new System.Windows.Forms.ComboBox();
            this.lblVendor = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.productNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.purchaseRateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productPurchaseRateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendorNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendorProductResponseBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgdSearch)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbVendorProducts)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vendorProductResponseBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgdSearch);
            this.groupBox1.Controls.Add(this.txtSearchFor);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmbSearch);
            this.groupBox1.Controls.Add(this.lblSearch);
            this.groupBox1.Controls.Add(this.cmbSearchBy);
            this.groupBox1.Controls.Add(this.lblSearc);
            this.groupBox1.Location = new System.Drawing.Point(12, 51);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(363, 442);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select Vendor Products";
            // 
            // dgdSearch
            // 
            this.dgdSearch.AllowUserToAddRows = false;
            this.dgdSearch.AllowUserToDeleteRows = false;
            this.dgdSearch.AllowUserToOrderColumns = true;
            this.dgdSearch.BackgroundColor = System.Drawing.Color.White;
            this.dgdSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgdSearch.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SelectRow,
            this.Name,
            this.Code});
            this.dgdSearch.Location = new System.Drawing.Point(7, 115);
            this.dgdSearch.Name = "dgdSearch";
            this.dgdSearch.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgdSearch.Size = new System.Drawing.Size(341, 321);
            this.dgdSearch.TabIndex = 6;
            // 
            // SelectRow
            // 
            this.SelectRow.HeaderText = "Select";
            this.SelectRow.Name = "SelectRow";
            this.SelectRow.Width = 40;
            // 
            // Name
            // 
            this.Name.DataPropertyName = "Name";
            this.Name.HeaderText = "Name";
            this.Name.Name = "Name";
            this.Name.Width = 180;
            // 
            // Code
            // 
            this.Code.DataPropertyName = "Code";
            this.Code.HeaderText = "Product Code";
            this.Code.Name = "Code";
            // 
            // txtSearchFor
            // 
            this.txtSearchFor.Location = new System.Drawing.Point(96, 84);
            this.txtSearchFor.Name = "txtSearchFor";
            this.txtSearchFor.Size = new System.Drawing.Size(180, 20);
            this.txtSearchFor.TabIndex = 5;
            this.txtSearchFor.TextChanged += new System.EventHandler(this.txtSearchFor_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Search For";
            // 
            // cmbSearch
            // 
            this.cmbSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSearch.FormattingEnabled = true;
            this.cmbSearch.Location = new System.Drawing.Point(94, 56);
            this.cmbSearch.Name = "cmbSearch";
            this.cmbSearch.Size = new System.Drawing.Size(182, 21);
            this.cmbSearch.TabIndex = 3;
            this.cmbSearch.SelectedIndexChanged += new System.EventHandler(this.cmbSearch_SelectedIndexChanged);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(28, 60);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(56, 13);
            this.lblSearch.TabIndex = 2;
            this.lblSearch.Text = "Search By";
            // 
            // cmbSearchBy
            // 
            this.cmbSearchBy.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbSearchBy.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSearchBy.FormattingEnabled = true;
            this.cmbSearchBy.Items.AddRange(new object[] {
            "All",
            "Product Group",
            "Generic Name",
            "Shelf",
            "Medicine For",
            "Manufacture"});
            this.cmbSearchBy.Location = new System.Drawing.Point(94, 28);
            this.cmbSearchBy.Name = "cmbSearchBy";
            this.cmbSearchBy.Size = new System.Drawing.Size(182, 21);
            this.cmbSearchBy.TabIndex = 1;
            this.cmbSearchBy.SelectedIndexChanged += new System.EventHandler(this.cmbSearchBy_SelectedIndexChanged_1);
            // 
            // lblSearc
            // 
            this.lblSearc.AutoSize = true;
            this.lblSearc.Location = new System.Drawing.Point(28, 32);
            this.lblSearc.Name = "lblSearc";
            this.lblSearc.Size = new System.Drawing.Size(56, 13);
            this.lblSearc.TabIndex = 0;
            this.lblSearc.Text = "Search By";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtVendorProductFilter);
            this.groupBox2.Controls.Add(this.lblFilterVvendorProducts);
            this.groupBox2.Controls.Add(this.dbVendorProducts);
            this.groupBox2.Controls.Add(this.cmbVendor);
            this.groupBox2.Controls.Add(this.lblVendor);
            this.groupBox2.Location = new System.Drawing.Point(459, 51);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(513, 442);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Vendor Products";
            // 
            // txtVendorProductFilter
            // 
            this.txtVendorProductFilter.Location = new System.Drawing.Point(71, 58);
            this.txtVendorProductFilter.Name = "txtVendorProductFilter";
            this.txtVendorProductFilter.Size = new System.Drawing.Size(385, 20);
            this.txtVendorProductFilter.TabIndex = 4;
            this.txtVendorProductFilter.TextChanged += new System.EventHandler(this.txtVendorProductFilter_TextChanged);
            // 
            // lblFilterVvendorProducts
            // 
            this.lblFilterVvendorProducts.AutoSize = true;
            this.lblFilterVvendorProducts.Location = new System.Drawing.Point(21, 63);
            this.lblFilterVvendorProducts.Name = "lblFilterVvendorProducts";
            this.lblFilterVvendorProducts.Size = new System.Drawing.Size(32, 13);
            this.lblFilterVvendorProducts.TabIndex = 3;
            this.lblFilterVvendorProducts.Text = "Filter ";
            // 
            // dbVendorProducts
            // 
            this.dbVendorProducts.AutoGenerateColumns = false;
            this.dbVendorProducts.BackgroundColor = System.Drawing.Color.White;
            this.dbVendorProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dbVendorProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.productNameDataGridViewTextBoxColumn,
            this.purchaseRateDataGridViewTextBoxColumn,
            this.productPurchaseRateDataGridViewTextBoxColumn,
            this.vendorNameDataGridViewTextBoxColumn,
            this.delete});
            this.dbVendorProducts.DataSource = this.vendorProductResponseBindingSource;
            this.dbVendorProducts.Location = new System.Drawing.Point(6, 115);
            this.dbVendorProducts.Name = "dbVendorProducts";
            this.dbVendorProducts.Size = new System.Drawing.Size(501, 321);
            this.dbVendorProducts.TabIndex = 2;
            this.dbVendorProducts.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellContentClick);
            // 
            // delete
            // 
            this.delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.delete.HeaderText = "Delete";
            this.delete.Name = "delete";
            this.delete.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.delete.Text = "Delete";
            this.delete.ToolTipText = "Delete Vendor Product";
            this.delete.UseColumnTextForButtonValue = true;
            this.delete.Width = 70;
            // 
            // cmbVendor
            // 
            this.cmbVendor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbVendor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbVendor.FormattingEnabled = true;
            this.cmbVendor.Location = new System.Drawing.Point(71, 28);
            this.cmbVendor.Name = "cmbVendor";
            this.cmbVendor.Size = new System.Drawing.Size(385, 21);
            this.cmbVendor.TabIndex = 1;
            this.cmbVendor.SelectedIndexChanged += new System.EventHandler(this.cmbVendor_SelectedIndexChanged);
            // 
            // lblVendor
            // 
            this.lblVendor.AutoSize = true;
            this.lblVendor.Location = new System.Drawing.Point(18, 32);
            this.lblVendor.Name = "lblVendor";
            this.lblVendor.Size = new System.Drawing.Size(41, 13);
            this.lblVendor.TabIndex = 0;
            this.lblVendor.Text = "Vendor";
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(209)))), ((int)(((byte)(150)))));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(378, 240);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 46);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Add >>";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(984, 561);
            this.panel1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(18, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Vendor Products Management";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(209)))), ((int)(((byte)(150)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Location = new System.Drawing.Point(465, 517);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = global::Properties.Resources.panel8_BackgroundImage;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(984, 45);
            this.panel2.TabIndex = 2;
            // 
            // productNameDataGridViewTextBoxColumn
            // 
            this.productNameDataGridViewTextBoxColumn.DataPropertyName = "ProductName";
            this.productNameDataGridViewTextBoxColumn.HeaderText = "ProductName";
            this.productNameDataGridViewTextBoxColumn.Name = "productNameDataGridViewTextBoxColumn";
            this.productNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // purchaseRateDataGridViewTextBoxColumn
            // 
            this.purchaseRateDataGridViewTextBoxColumn.DataPropertyName = "PurchaseRate";
            this.purchaseRateDataGridViewTextBoxColumn.HeaderText = "PurchaseRate";
            this.purchaseRateDataGridViewTextBoxColumn.Name = "purchaseRateDataGridViewTextBoxColumn";
            // 
            // productPurchaseRateDataGridViewTextBoxColumn
            // 
            this.productPurchaseRateDataGridViewTextBoxColumn.DataPropertyName = "ProductPurchaseRate";
            this.productPurchaseRateDataGridViewTextBoxColumn.HeaderText = "ProductPurchaseRate";
            this.productPurchaseRateDataGridViewTextBoxColumn.Name = "productPurchaseRateDataGridViewTextBoxColumn";
            this.productPurchaseRateDataGridViewTextBoxColumn.ReadOnly = true;
            this.productPurchaseRateDataGridViewTextBoxColumn.Width = 70;
            // 
            // vendorNameDataGridViewTextBoxColumn
            // 
            this.vendorNameDataGridViewTextBoxColumn.DataPropertyName = "VendorName";
            this.vendorNameDataGridViewTextBoxColumn.HeaderText = "VendorName";
            this.vendorNameDataGridViewTextBoxColumn.Name = "vendorNameDataGridViewTextBoxColumn";
            this.vendorNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // vendorProductResponseBindingSource
            // 
            this.vendorProductResponseBindingSource.DataSource = typeof(MedicalShop.VendorProductResponse);
            // 
            // frmVendorProducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vendor Products";
            this.Load += new System.EventHandler(this.frmVendorProducts_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgdSearch)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbVendorProducts)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vendorProductResponseBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgdSearch;
        private System.Windows.Forms.TextBox txtSearchFor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.ComboBox cmbSearchBy;
        private System.Windows.Forms.Label lblSearc;
        private System.Windows.Forms.DataGridViewCheckBoxColumn SelectRow;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Code;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dbVendorProducts;
        private System.Windows.Forms.ComboBox cmbVendor;
        private System.Windows.Forms.Label lblVendor;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.BindingSource vendorProductResponseBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn productNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn purchaseRateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productPurchaseRateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn delete;
        private System.Windows.Forms.TextBox txtVendorProductFilter;
        private System.Windows.Forms.Label lblFilterVvendorProducts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
    }
}