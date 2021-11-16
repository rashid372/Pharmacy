
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
            this.dbVendorProducts = new System.Windows.Forms.DataGridView();
            this.ProductCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VendorId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vendor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Product = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PurchaseRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbVendor = new System.Windows.Forms.ComboBox();
            this.lblVendor = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgdSearch)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbVendorProducts)).BeginInit();
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
            this.groupBox1.Size = new System.Drawing.Size(363, 377);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select Vendor Products";
            // 
            // dgdSearch
            // 
            this.dgdSearch.AllowUserToAddRows = false;
            this.dgdSearch.AllowUserToDeleteRows = false;
            this.dgdSearch.AllowUserToOrderColumns = true;
            this.dgdSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgdSearch.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SelectRow,
            this.Name,
            this.Code});
            this.dgdSearch.Location = new System.Drawing.Point(7, 115);
            this.dgdSearch.Name = "dgdSearch";
            this.dgdSearch.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgdSearch.Size = new System.Drawing.Size(341, 256);
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
            this.groupBox2.Controls.Add(this.dbVendorProducts);
            this.groupBox2.Controls.Add(this.cmbVendor);
            this.groupBox2.Controls.Add(this.lblVendor);
            this.groupBox2.Location = new System.Drawing.Point(459, 51);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(385, 377);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Vendor Products";
            // 
            // dbVendorProducts
            // 
            this.dbVendorProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dbVendorProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProductCode,
            this.VendorId,
            this.Vendor,
            this.Product,
            this.PurchaseRate});
            this.dbVendorProducts.Location = new System.Drawing.Point(21, 115);
            this.dbVendorProducts.Name = "dbVendorProducts";
            this.dbVendorProducts.Size = new System.Drawing.Size(358, 256);
            this.dbVendorProducts.TabIndex = 2;
            // 
            // ProductCode
            // 
            this.ProductCode.HeaderText = "Product Code";
            this.ProductCode.Name = "ProductCode";
            this.ProductCode.Visible = false;
            // 
            // VendorId
            // 
            this.VendorId.HeaderText = "VendorId";
            this.VendorId.Name = "VendorId";
            this.VendorId.Visible = false;
            // 
            // Vendor
            // 
            this.Vendor.HeaderText = "Vendor";
            this.Vendor.Name = "Vendor";
            // 
            // Product
            // 
            this.Product.HeaderText = "Product";
            this.Product.Name = "Product";
            // 
            // PurchaseRate
            // 
            this.PurchaseRate.HeaderText = "Purchase Rate";
            this.PurchaseRate.Name = "PurchaseRate";
            this.PurchaseRate.Width = 150;
            // 
            // cmbVendor
            // 
            this.cmbVendor.FormattingEnabled = true;
            this.cmbVendor.Location = new System.Drawing.Point(71, 28);
            this.cmbVendor.Name = "cmbVendor";
            this.cmbVendor.Size = new System.Drawing.Size(253, 21);
            this.cmbVendor.TabIndex = 1;
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
            this.btnAdd.Location = new System.Drawing.Point(378, 240);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Add >>";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(378, 269);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 4;
            this.btnRemove.Text = "Remove <<";
            this.btnRemove.UseVisualStyleBackColor = true;
            // 
            // frmVendorProducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 450);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Text = "formVendorProducts";
            this.Load += new System.EventHandler(this.frmVendorProducts_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgdSearch)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbVendorProducts)).EndInit();
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
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn VendorId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vendor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Product;
        private System.Windows.Forms.DataGridViewTextBoxColumn PurchaseRate;
    }
}