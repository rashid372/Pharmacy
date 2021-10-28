using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;

namespace MedicalShop
{
	public class frmProductBatch : Form
	{
		private IContainer components = null;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;

		private Panel panel1;

		private Button btnView;

		private Button btnClose;

		private Panel panel8;

		private DataGridView dgvRegister;

		private TextBox txtSearch;

		private Label label4;

		private Panel panel6;

		private Label label1;

		private Panel panel7;

		private Panel panel5;

		private Panel panel4;

		private Panel panel3;

		private Panel panel2;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;

		private Button btnRefresh;

		private ComboBox cmbGroup;

		private Label label5;

		private Label label2;

		private ComboBox cmbProduct;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;

		private DataGridViewCheckBoxColumn Column1;

		private DataGridViewTextBoxColumn ID;

		private DataGridViewTextBoxColumn Batch;

		private DataGridViewTextBoxColumn ExpiryDate;

		private DataGridViewTextBoxColumn PurchaseRate;

		private DataGridViewTextBoxColumn SalesRate;

		private DataGridViewTextBoxColumn MRP;

		private SalesMasterSP mastersp = new SalesMasterSP();

		public frmProductBatch()
		{
			this.InitializeComponent();
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			try
			{
				if (MessageBox.Show("Do you want to close?", "Pharmacy", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
				{
					base.Close();
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void btnView_Click(object sender, EventArgs e)
		{
			try
			{
				MessageBox.Show("Thank you for using Pharmacy.To gain access please buy full version", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void cmbGroup_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				if (e.KeyCode == Keys.Space)
				{
					SendKeys.Send("{F4}");
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void cmbGroup_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				this.FillProduct();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void cmbProduct_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				this.txtSearch.Clear();
				this.FillRegister();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		protected override void Dispose(bool disposing)
		{
			if ((!disposing ? false : this.components != null))
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void dtpFromDate_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				if (e.KeyCode == Keys.Space)
				{
					SendKeys.Send("{F4}");
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void dtpFromDate_ValueChanged(object sender, EventArgs e)
		{
			try
			{
				this.FillRegister();
				this.txtSearch.Clear();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		public void FillProduct()
		{
			ProductSP productSP = new ProductSP();
			DataTable dataTable = new DataTable();
			dataTable = productSP.ProductViewByGroup(this.cmbGroup.SelectedValue.ToString());
			this.cmbProduct.DataSource = dataTable;
			this.cmbProduct.DisplayMember = "ProductName";
			this.cmbProduct.ValueMember = "ProductID";
		}

		public void FillProductGroupCombo()
		{
			ProductGroupSP productGroupSP = new ProductGroupSP();
			DataTable dataTable = new DataTable();
			dataTable = productGroupSP.ProductGroupViewAll();
			this.cmbGroup.DataSource = dataTable;
			this.cmbGroup.ValueMember = "ID";
			this.cmbGroup.DisplayMember = "Name";
			this.cmbGroup.SelectedValue = 1;
		}

		public void FillRegister()
		{
			DataTable dataTable = new DataTable();
			ProductBatchSP productBatchSP = new ProductBatchSP();
			if (this.cmbProduct.SelectedValue != null)
			{
				dataTable = productBatchSP.ProductBatchViewAllByProductId(this.cmbProduct.SelectedValue.ToString());
				this.dgvRegister.Rows.Clear();
				foreach (DataRow row in dataTable.Rows)
				{
					if (row.ItemArray[2].ToString().Trim() != "NA")
					{
						this.dgvRegister.Rows.Add();
						this.dgvRegister.Rows[this.dgvRegister.Rows.Count - 1].Cells[1].Value = row.ItemArray[0].ToString();
						this.dgvRegister.Rows[this.dgvRegister.Rows.Count - 1].Cells[2].Value = row.ItemArray[2].ToString();
						DataGridViewCell item = this.dgvRegister.Rows[this.dgvRegister.Rows.Count - 1].Cells[3];
						DateTime dateTime = DateTime.Parse(row.ItemArray[3].ToString());
						item.Value = dateTime.ToString("dd-MMM-yyyy");
						this.dgvRegister.Rows[this.dgvRegister.Rows.Count - 1].Cells[4].Value = row.ItemArray[4].ToString();
						this.dgvRegister.Rows[this.dgvRegister.Rows.Count - 1].Cells[5].Value = row.ItemArray[5].ToString();
						this.dgvRegister.Rows[this.dgvRegister.Rows.Count - 1].Cells[6].Value = row.ItemArray[6].ToString();
						this.dgvRegister.Rows[this.dgvRegister.Rows.Count - 1].Cells[0].Value = false;
					}
				}
			}
		}

		private void frmProductBatch_Load(object sender, EventArgs e)
		{
			try
			{
				this.FillProductGroupCombo();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void InitializeComponent()
		{
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmProductBatch));
			this.panel1 = new Panel();
			this.btnRefresh = new Button();
			this.btnView = new Button();
			this.btnClose = new Button();
			this.panel8 = new Panel();
			this.label2 = new Label();
			this.cmbProduct = new ComboBox();
			this.cmbGroup = new ComboBox();
			this.label5 = new Label();
			this.dgvRegister = new DataGridView();
			this.Column1 = new DataGridViewCheckBoxColumn();
			this.ID = new DataGridViewTextBoxColumn();
			this.Batch = new DataGridViewTextBoxColumn();
			this.ExpiryDate = new DataGridViewTextBoxColumn();
			this.PurchaseRate = new DataGridViewTextBoxColumn();
			this.SalesRate = new DataGridViewTextBoxColumn();
			this.MRP = new DataGridViewTextBoxColumn();
			this.txtSearch = new TextBox();
			this.label4 = new Label();
			this.panel6 = new Panel();
			this.label1 = new Label();
			this.panel7 = new Panel();
			this.panel5 = new Panel();
			this.panel4 = new Panel();
			this.panel3 = new Panel();
			this.panel2 = new Panel();
			this.dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
			this.panel1.SuspendLayout();
			this.panel8.SuspendLayout();
			((ISupportInitialize)this.dgvRegister).BeginInit();
			this.panel6.SuspendLayout();
			base.SuspendLayout();
			this.panel1.BackColor = Color.Transparent;
			this.panel1.BackgroundImage = (Image)componentResourceManager.GetObject("panel1.BackgroundImage");
			this.panel1.BackgroundImageLayout = ImageLayout.Stretch;
			this.panel1.Controls.Add(this.btnRefresh);
			this.panel1.Controls.Add(this.btnView);
			this.panel1.Controls.Add(this.btnClose);
			this.panel1.Controls.Add(this.panel8);
			this.panel1.Controls.Add(this.panel6);
			this.panel1.Controls.Add(this.panel5);
			this.panel1.Controls.Add(this.panel4);
			this.panel1.Controls.Add(this.panel3);
			this.panel1.Controls.Add(this.panel2);
			this.panel1.Dock = DockStyle.Fill;
			this.panel1.Location = new Point(7, 7);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(642, 342);
			this.panel1.TabIndex = 6;
			this.btnRefresh.BackColor = Color.FromArgb(255, 209, 150);
			this.btnRefresh.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 1);
			this.btnRefresh.FlatStyle = FlatStyle.Flat;
			this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.btnRefresh.Location = new Point(269, 295);
			this.btnRefresh.Name = "btnRefresh";
			this.btnRefresh.Size = new System.Drawing.Size(107, 23);
			this.btnRefresh.TabIndex = 9;
			this.btnRefresh.Text = "&Refresh";
			this.btnRefresh.UseVisualStyleBackColor = false;
			this.btnRefresh.Click += new EventHandler(this.frmProductBatch_Load);
			this.btnView.BackColor = Color.FromArgb(255, 209, 150);
			this.btnView.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 1);
			this.btnView.FlatStyle = FlatStyle.Flat;
			this.btnView.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.btnView.Location = new Point(156, 295);
			this.btnView.Name = "btnView";
			this.btnView.Size = new System.Drawing.Size(107, 23);
			this.btnView.TabIndex = 8;
			this.btnView.Text = "&Delete";
			this.btnView.UseVisualStyleBackColor = false;
			this.btnView.Click += new EventHandler(this.btnView_Click);
			this.btnClose.BackColor = Color.FromArgb(255, 209, 150);
			this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnClose.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 1);
			this.btnClose.FlatStyle = FlatStyle.Flat;
			this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.btnClose.Location = new Point(382, 295);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(75, 23);
			this.btnClose.TabIndex = 10;
			this.btnClose.Text = "&Close";
			this.btnClose.UseVisualStyleBackColor = false;
			this.btnClose.Click += new EventHandler(this.btnClose_Click);
			this.panel8.BackgroundImage = (Image)componentResourceManager.GetObject("panel8.BackgroundImage");
			this.panel8.BackgroundImageLayout = ImageLayout.Stretch;
			this.panel8.Controls.Add(this.label2);
			this.panel8.Controls.Add(this.cmbProduct);
			this.panel8.Controls.Add(this.cmbGroup);
			this.panel8.Controls.Add(this.label5);
			this.panel8.Controls.Add(this.dgvRegister);
			this.panel8.Controls.Add(this.txtSearch);
			this.panel8.Controls.Add(this.label4);
			this.panel8.Dock = DockStyle.Top;
			this.panel8.Location = new Point(1, 34);
			this.panel8.Name = "panel8";
			this.panel8.Padding = new System.Windows.Forms.Padding(5);
			this.panel8.Size = new System.Drawing.Size(640, 255);
			this.panel8.TabIndex = 4;
			this.label2.AutoSize = true;
			this.label2.Location = new Point(202, 22);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(47, 13);
			this.label2.TabIndex = 59;
			this.label2.Text = "Product:";
			this.cmbProduct.DropDownStyle = ComboBoxStyle.DropDownList;
			this.cmbProduct.FormattingEnabled = true;
			this.cmbProduct.Location = new Point(261, 15);
			this.cmbProduct.Name = "cmbProduct";
			this.cmbProduct.Size = new System.Drawing.Size(148, 21);
			this.cmbProduct.TabIndex = 58;
			this.cmbProduct.TabStop = false;
			this.cmbProduct.SelectedIndexChanged += new EventHandler(this.cmbProduct_SelectedIndexChanged);
			this.cmbProduct.KeyDown += new KeyEventHandler(this.cmbGroup_KeyDown);
			this.cmbGroup.DropDownStyle = ComboBoxStyle.DropDownList;
			this.cmbGroup.FormattingEnabled = true;
			this.cmbGroup.Location = new Point(48, 15);
			this.cmbGroup.Name = "cmbGroup";
			this.cmbGroup.Size = new System.Drawing.Size(148, 21);
			this.cmbGroup.TabIndex = 57;
			this.cmbGroup.TabStop = false;
			this.cmbGroup.SelectedIndexChanged += new EventHandler(this.cmbGroup_SelectedIndexChanged);
			this.cmbGroup.KeyDown += new KeyEventHandler(this.cmbGroup_KeyDown);
			this.label5.AutoSize = true;
			this.label5.Location = new Point(8, 22);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(39, 13);
			this.label5.TabIndex = 56;
			this.label5.Text = "Group:";
			this.dgvRegister.AllowUserToAddRows = false;
			this.dgvRegister.AllowUserToDeleteRows = false;
			this.dgvRegister.AllowUserToResizeColumns = false;
			this.dgvRegister.AllowUserToResizeRows = false;
			this.dgvRegister.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvRegister.BackgroundColor = Color.White;
			this.dgvRegister.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			DataGridViewColumnCollection columns = this.dgvRegister.Columns;
			DataGridViewColumn[] column1 = new DataGridViewColumn[] { this.Column1, this.ID, this.Batch, this.ExpiryDate, this.PurchaseRate, this.SalesRate, this.MRP };
			columns.AddRange(column1);
			this.dgvRegister.GridColor = Color.WhiteSmoke;
			this.dgvRegister.Location = new Point(11, 41);
			this.dgvRegister.MultiSelect = false;
			this.dgvRegister.Name = "dgvRegister";
			this.dgvRegister.RowHeadersVisible = false;
			this.dgvRegister.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			this.dgvRegister.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			this.dgvRegister.Size = new System.Drawing.Size(621, 200);
			this.dgvRegister.TabIndex = 55;
			this.Column1.HeaderText = "";
			this.Column1.Name = "Column1";
			this.Column1.Visible = false;
			this.ID.HeaderText = "ID";
			this.ID.Name = "ID";
			this.ID.ReadOnly = true;
			this.ID.Visible = false;
			this.Batch.HeaderText = "Batch";
			this.Batch.Name = "Batch";
			this.Batch.ReadOnly = true;
			this.ExpiryDate.HeaderText = "Expiry Date";
			this.ExpiryDate.Name = "ExpiryDate";
			this.ExpiryDate.ReadOnly = true;
			this.PurchaseRate.HeaderText = "Purchase Rate";
			this.PurchaseRate.Name = "PurchaseRate";
			this.PurchaseRate.ReadOnly = true;
			this.SalesRate.HeaderText = "Sales Rate";
			this.SalesRate.Name = "SalesRate";
			this.SalesRate.ReadOnly = true;
			this.MRP.HeaderText = "MRP";
			this.MRP.Name = "MRP";
			this.MRP.ReadOnly = true;
			this.txtSearch.Location = new Point(491, 15);
			this.txtSearch.MaxLength = 50;
			this.txtSearch.Name = "txtSearch";
			this.txtSearch.Size = new System.Drawing.Size(141, 20);
			this.txtSearch.TabIndex = 54;
			this.txtSearch.KeyPress += new KeyPressEventHandler(this.txtSearch_KeyPress);
			this.txtSearch.TextChanged += new EventHandler(this.txtSearch_TextChanged);
			this.label4.AutoSize = true;
			this.label4.Location = new Point(422, 22);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(62, 13);
			this.label4.TabIndex = 53;
			this.label4.Text = "Search For:";
			this.panel6.BackgroundImage = (Image)componentResourceManager.GetObject("panel6.BackgroundImage");
			this.panel6.Controls.Add(this.label1);
			this.panel6.Controls.Add(this.panel7);
			this.panel6.Dock = DockStyle.Top;
			this.panel6.Location = new Point(1, 1);
			this.panel6.Name = "panel6";
			this.panel6.Size = new System.Drawing.Size(640, 33);
			this.panel6.TabIndex = 4;
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label1.Location = new Point(11, 7);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(96, 15);
			this.label1.TabIndex = 4;
			this.label1.Text = "Product Batch";
			this.panel7.BackColor = Color.FromArgb(136, 136, 136);
			this.panel7.Dock = DockStyle.Bottom;
			this.panel7.Location = new Point(0, 32);
			this.panel7.Name = "panel7";
			this.panel7.Size = new System.Drawing.Size(640, 1);
			this.panel7.TabIndex = 3;
			this.panel5.BackColor = Color.FromArgb(136, 136, 136);
			this.panel5.Dock = DockStyle.Bottom;
			this.panel5.Location = new Point(1, 341);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(640, 1);
			this.panel5.TabIndex = 2;
			this.panel4.BackColor = Color.FromArgb(136, 136, 136);
			this.panel4.Dock = DockStyle.Top;
			this.panel4.Location = new Point(1, 0);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(640, 1);
			this.panel4.TabIndex = 1;
			this.panel3.BackColor = Color.FromArgb(136, 136, 136);
			this.panel3.Dock = DockStyle.Right;
			this.panel3.Location = new Point(641, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(1, 342);
			this.panel3.TabIndex = 1;
			this.panel2.BackColor = Color.FromArgb(136, 136, 136);
			this.panel2.Dock = DockStyle.Left;
			this.panel2.Location = new Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(1, 342);
			this.panel2.TabIndex = 0;
			this.dataGridViewTextBoxColumn1.HeaderText = "Voucher No";
			this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn1.ReadOnly = true;
			this.dataGridViewTextBoxColumn1.Resizable = DataGridViewTriState.False;
			this.dataGridViewTextBoxColumn1.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.dataGridViewTextBoxColumn1.Visible = false;
			this.dataGridViewTextBoxColumn1.Width = 111;
			this.dataGridViewTextBoxColumn2.HeaderText = "Cash/Bank Account";
			this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
			this.dataGridViewTextBoxColumn2.ReadOnly = true;
			this.dataGridViewTextBoxColumn2.Resizable = DataGridViewTriState.False;
			this.dataGridViewTextBoxColumn2.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.dataGridViewTextBoxColumn2.Width = 110;
			this.dataGridViewTextBoxColumn3.HeaderText = "Amount";
			this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
			this.dataGridViewTextBoxColumn3.ReadOnly = true;
			this.dataGridViewTextBoxColumn3.Resizable = DataGridViewTriState.False;
			this.dataGridViewTextBoxColumn3.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.dataGridViewTextBoxColumn3.Width = 111;
			this.dataGridViewTextBoxColumn4.HeaderText = "Date";
			this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
			this.dataGridViewTextBoxColumn4.ReadOnly = true;
			this.dataGridViewTextBoxColumn4.Resizable = DataGridViewTriState.False;
			this.dataGridViewTextBoxColumn4.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.dataGridViewTextBoxColumn4.Width = 110;
			this.dataGridViewTextBoxColumn5.HeaderText = "Amount";
			this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
			this.dataGridViewTextBoxColumn5.ReadOnly = true;
			this.dataGridViewTextBoxColumn5.Resizable = DataGridViewTriState.False;
			this.dataGridViewTextBoxColumn5.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.dataGridViewTextBoxColumn5.Width = 88;
			this.dataGridViewTextBoxColumn6.HeaderText = "MRP";
			this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
			this.dataGridViewTextBoxColumn6.ReadOnly = true;
			this.dataGridViewTextBoxColumn6.Width = 103;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.BackColor = Color.White;
			base.CancelButton = this.btnClose;
			base.ClientSize = new System.Drawing.Size(656, 356);
			base.Controls.Add(this.panel1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.Icon = (System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.Name = "frmProductBatch";
			base.Padding = new System.Windows.Forms.Padding(7);
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "Product Batch";
			base.Load += new EventHandler(this.frmProductBatch_Load);
			this.panel1.ResumeLayout(false);
			this.panel8.ResumeLayout(false);
			this.panel8.PerformLayout();
			((ISupportInitialize)this.dgvRegister).EndInit();
			this.panel6.ResumeLayout(false);
			this.panel6.PerformLayout();
			base.ResumeLayout(false);
		}

		private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
		{
			try
			{
				if (e.KeyChar == '\r')
				{
					if (this.dgvRegister.RowCount > 0)
					{
						this.dgvRegister.Rows[0].Selected = true;
					}
					this.dgvRegister.Focus();
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void txtSearch_TextChanged(object sender, EventArgs e)
		{
			try
			{
				for (int i = 0; i < this.dgvRegister.Rows.Count; i++)
				{
					if (!this.dgvRegister[2, i].Value.ToString().ToLower().StartsWith(this.txtSearch.Text.ToLower()))
					{
						this.dgvRegister.Rows[i].Visible = false;
					}
					else
					{
						this.dgvRegister.Rows[i].Visible = true;
					}
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}
	}
}