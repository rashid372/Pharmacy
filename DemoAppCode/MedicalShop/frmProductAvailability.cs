using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;

namespace MedicalShop
{
	public class frmProductAvailability : Form
	{
		private IContainer components = null;

		private Panel panel1;

		private Panel panel8;

		private Panel panel6;

		private Label label1;

		private Panel panel7;

		private Panel panel5;

		private Panel panel4;

		private Panel panel3;

		private Panel panel2;

		private Button btnClose;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;

		private Button btnViewDetails;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn21;

		private Button btnReset;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn19;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn20;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn22;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn23;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn24;

		private ComboBox cmbSearch;

		private TextBox txtSearchFor;

		private Label label6;

		private ComboBox cmbSearchBy;

		private Label lblSearc;

		private DataGridView dgvLowStock;

		private CheckBox cbxStatus;

		private DataGridViewTextBoxColumn ProductCode;

		private DataGridViewTextBoxColumn Product;

		private DataGridViewTextBoxColumn CurrentStock;

		private DataGridViewTextBoxColumn MinimumLEvel;

		private DataGridViewTextBoxColumn Shelf;

		private DataGridViewTextBoxColumn Group;

		private DataGridViewTextBoxColumn Manufacture;

		private DataGridViewTextBoxColumn GenericName;

		private DataGridViewTextBoxColumn MedicineFor;

		private DataGridViewTextBoxColumn Unit;

		public frmProductAvailability()
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

		private void btnReset_Click(object sender, EventArgs e)
		{
			try
			{
				this.RefreshForm();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void btnViewDetails_Click(object sender, EventArgs e)
		{
			this.ViewProductDetails();
		}

		private void cmbSearch_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				this.FillLowStockGridAccordingToSearch();
				this.txtSearchFor.Clear();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void cmbSearchBy_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				this.FillSerachComboOfLowStock();
				this.txtSearchFor.Clear();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void dgvLowStock_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			this.ViewProductDetails();
		}

		protected override void Dispose(bool disposing)
		{
			if ((!disposing ? false : this.components != null))
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		public void FillLowStockGridAccordingToSearch()
		{
			if (!(this.cmbSearchBy.Text != "All"))
			{
				this.FillProductGrid();
				this.cmbSearch.Visible = false;
			}
			else
			{
				int num = 0;
				if (this.cmbSearchBy.Text == "Product Group")
				{
					num = 5;
				}
				else if (this.cmbSearchBy.Text == "Generic Name")
				{
					num = 7;
				}
				else if (this.cmbSearchBy.Text == "Shelf")
				{
					num = 4;
				}
				else if (this.cmbSearchBy.Text == "Medicine For")
				{
					num = 8;
				}
				else if (this.cmbSearchBy.Text == "Manufacture")
				{
					num = 6;
				}
				for (int i = 0; i < this.dgvLowStock.Rows.Count; i++)
				{
					if (!this.dgvLowStock.Rows[i].Cells[num].Value.ToString().ToLower().StartsWith(this.cmbSearch.Text.ToLower()))
					{
						this.dgvLowStock.Rows[i].Visible = false;
					}
					else
					{
						this.dgvLowStock.Rows[i].Visible = true;
					}
				}
				this.cmbSearch.Visible = true;
			}
			foreach (DataGridViewRow row in (IEnumerable)this.dgvLowStock.Rows)
			{
				decimal num1 = new decimal(0);
				try
				{
					num1 = decimal.Parse(row.Cells[2].Value.ToString().Trim());
				}
				catch (Exception exception)
				{
					num1 = new decimal(0);
				}
				if (row.Visible)
				{
					if (this.cbxStatus.Checked)
					{
						if (!(num1 <= new decimal(0)))
						{
							row.Visible = true;
						}
						else
						{
							row.Visible = false;
						}
					}
				}
			}
		}

		public void FillProductGrid()
		{
			ProductSP productSP = new ProductSP();
			DataTable dataTable = new DataTable();
			dataTable = productSP.AllProductsStockForProductAvailibilitySearch();
			this.dgvLowStock.Rows.Clear();
			int str = 0;
			foreach (DataRow row in dataTable.Rows)
			{
				this.dgvLowStock.Rows.Add();
				this.dgvLowStock.Rows[str].Cells["ProductCode"].Value = row.ItemArray[3].ToString();
				this.dgvLowStock.Rows[str].Cells["Product"].Value = row.ItemArray[0].ToString();
				this.dgvLowStock.Rows[str].Cells["CurrentStock"].Value = row.ItemArray[1].ToString();
				this.dgvLowStock.Rows[str].Cells["MinimumLEvel"].Value = row.ItemArray[2].ToString();
				this.dgvLowStock.Rows[str].Cells["Shelf"].Value = row.ItemArray[4].ToString();
				this.dgvLowStock.Rows[str].Cells["Group"].Value = row.ItemArray[5].ToString();
				this.dgvLowStock.Rows[str].Cells["Manufacture"].Value = row.ItemArray[6].ToString();
				this.dgvLowStock.Rows[str].Cells["GenericName"].Value = row.ItemArray[7].ToString();
				this.dgvLowStock.Rows[str].Cells["MedicineFor"].Value = row.ItemArray[8].ToString();
				this.dgvLowStock.Rows[str].Cells["Unit"].Value = row.ItemArray[9].ToString();
				str++;
			}
		}

		public void FillSerachComboOfLowStock()
		{
			if (this.cmbSearchBy.Text == "Product Group")
			{
				ProductGroupSP productGroupSP = new ProductGroupSP();
				DataTable dataTable = new DataTable();
				dataTable = productGroupSP.ProductGroupViewAll();
				this.cmbSearch.DataSource = dataTable;
				this.cmbSearch.DisplayMember = "Name";
				this.cmbSearch.ValueMember = "ID";
				this.cmbSearch.SelectedValue = "1";
			}
			else if (this.cmbSearchBy.Text == "Generic Name")
			{
				GenericNameSP genericNameSP = new GenericNameSP();
				DataTable dataTable1 = new DataTable();
				dataTable1 = genericNameSP.GenericNameViewAll();
				this.cmbSearch.DataSource = dataTable1;
				this.cmbSearch.DisplayMember = "Name";
				this.cmbSearch.ValueMember = "ID";
				this.cmbSearch.SelectedValue = "0";
			}
			else if (this.cmbSearchBy.Text == "Shelf")
			{
				ShelfSP shelfSP = new ShelfSP();
				DataTable dataTable2 = new DataTable();
				dataTable2 = shelfSP.ShelfViewAll();
				this.cmbSearch.DataSource = dataTable2;
				this.cmbSearch.DisplayMember = "Shelf Name";
				this.cmbSearch.ValueMember = "Shelf Id";
				this.cmbSearch.SelectedValue = "0";
			}
			else if (this.cmbSearchBy.Text == "Medicine For")
			{
				ProductSP productSP = new ProductSP();
				DataTable dataTable3 = new DataTable();
				dataTable3 = productSP.MedicineForViewAll();
				this.cmbSearch.DataSource = dataTable3;
				this.cmbSearch.DisplayMember = "MedicineFor";
			}
			else if (!(this.cmbSearchBy.Text == "Manufacture"))
			{
				this.cmbSearch.SelectedIndex = -1;
			}
			else
			{
				ManufacturerSP manufacturerSP = new ManufacturerSP();
				DataTable dataTable4 = new DataTable();
				dataTable4 = manufacturerSP.ManufacturerViewAll();
				this.cmbSearch.DataSource = dataTable4;
				this.cmbSearch.DisplayMember = "Name";
				this.cmbSearch.ValueMember = "ID";
				this.cmbSearch.SelectedValue = "0";
			}
		}

		private void frmReminderView_Load(object sender, EventArgs e)
		{
			try
			{
				this.RefreshForm();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void InitializeComponent()
		{
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmProductAvailability));
			this.btnClose = new Button();
			this.panel1 = new Panel();
			this.btnReset = new Button();
			this.btnViewDetails = new Button();
			this.panel8 = new Panel();
			this.cbxStatus = new CheckBox();
			this.cmbSearch = new ComboBox();
			this.txtSearchFor = new TextBox();
			this.dgvLowStock = new DataGridView();
			this.ProductCode = new DataGridViewTextBoxColumn();
			this.Product = new DataGridViewTextBoxColumn();
			this.CurrentStock = new DataGridViewTextBoxColumn();
			this.MinimumLEvel = new DataGridViewTextBoxColumn();
			this.Shelf = new DataGridViewTextBoxColumn();
			this.Group = new DataGridViewTextBoxColumn();
			this.Manufacture = new DataGridViewTextBoxColumn();
			this.GenericName = new DataGridViewTextBoxColumn();
			this.MedicineFor = new DataGridViewTextBoxColumn();
			this.Unit = new DataGridViewTextBoxColumn();
			this.lblSearc = new Label();
			this.cmbSearchBy = new ComboBox();
			this.label6 = new Label();
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
			this.dataGridViewTextBoxColumn7 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn8 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn9 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn10 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn11 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn12 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn13 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn14 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn15 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn16 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn17 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn18 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn19 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn20 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn21 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn22 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn23 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn24 = new DataGridViewTextBoxColumn();
			this.panel1.SuspendLayout();
			this.panel8.SuspendLayout();
			((ISupportInitialize)this.dgvLowStock).BeginInit();
			this.panel6.SuspendLayout();
			base.SuspendLayout();
			this.btnClose.BackColor = Color.FromArgb(255, 209, 150);
			this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnClose.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 1);
			this.btnClose.FlatStyle = FlatStyle.Flat;
			this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.btnClose.Location = new Point(696, 399);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(75, 23);
			this.btnClose.TabIndex = 6;
			this.btnClose.Text = "&Close";
			this.btnClose.UseVisualStyleBackColor = false;
			this.btnClose.Click += new EventHandler(this.btnClose_Click);
			this.panel1.BackColor = Color.Transparent;
			this.panel1.BackgroundImage = (Image)componentResourceManager.GetObject("panel1.BackgroundImage");
			this.panel1.BackgroundImageLayout = ImageLayout.Stretch;
			this.panel1.Controls.Add(this.btnReset);
			this.panel1.Controls.Add(this.btnViewDetails);
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
			this.panel1.Size = new System.Drawing.Size(778, 445);
			this.panel1.TabIndex = 1;
			this.btnReset.BackColor = Color.FromArgb(255, 209, 150);
			this.btnReset.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnReset.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 1);
			this.btnReset.FlatStyle = FlatStyle.Flat;
			this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.btnReset.Location = new Point(575, 399);
			this.btnReset.Name = "btnReset";
			this.btnReset.Size = new System.Drawing.Size(110, 23);
			this.btnReset.TabIndex = 5;
			this.btnReset.Text = "&Reset";
			this.btnReset.UseVisualStyleBackColor = false;
			this.btnReset.Click += new EventHandler(this.btnReset_Click);
			this.btnViewDetails.BackColor = Color.FromArgb(255, 209, 150);
			this.btnViewDetails.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnViewDetails.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 1);
			this.btnViewDetails.FlatStyle = FlatStyle.Flat;
			this.btnViewDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.btnViewDetails.Location = new Point(455, 399);
			this.btnViewDetails.Name = "btnViewDetails";
			this.btnViewDetails.Size = new System.Drawing.Size(110, 23);
			this.btnViewDetails.TabIndex = 4;
			this.btnViewDetails.Text = "&View Details";
			this.btnViewDetails.UseVisualStyleBackColor = false;
			this.btnViewDetails.Click += new EventHandler(this.btnViewDetails_Click);
			this.panel8.BackgroundImage = (Image)componentResourceManager.GetObject("panel8.BackgroundImage");
			this.panel8.BackgroundImageLayout = ImageLayout.Stretch;
			this.panel8.Controls.Add(this.cbxStatus);
			this.panel8.Controls.Add(this.cmbSearch);
			this.panel8.Controls.Add(this.txtSearchFor);
			this.panel8.Controls.Add(this.dgvLowStock);
			this.panel8.Controls.Add(this.lblSearc);
			this.panel8.Controls.Add(this.cmbSearchBy);
			this.panel8.Controls.Add(this.label6);
			this.panel8.Dock = DockStyle.Top;
			this.panel8.Location = new Point(1, 34);
			this.panel8.Name = "panel8";
			this.panel8.Padding = new System.Windows.Forms.Padding(5);
			this.panel8.Size = new System.Drawing.Size(776, 359);
			this.panel8.TabIndex = 0;
			this.cbxStatus.AutoSize = true;
			this.cbxStatus.Location = new Point(636, 19);
			this.cbxStatus.Name = "cbxStatus";
			this.cbxStatus.Size = new System.Drawing.Size(138, 17);
			this.cbxStatus.TabIndex = 104;
			this.cbxStatus.Text = "Available Products Only";
			this.cbxStatus.UseVisualStyleBackColor = true;
			this.cbxStatus.CheckedChanged += new EventHandler(this.cmbSearch_SelectedIndexChanged);
			this.cmbSearch.DropDownStyle = ComboBoxStyle.DropDownList;
			this.cmbSearch.FormattingEnabled = true;
			this.cmbSearch.Location = new Point(245, 17);
			this.cmbSearch.Name = "cmbSearch";
			this.cmbSearch.Size = new System.Drawing.Size(148, 21);
			this.cmbSearch.TabIndex = 1;
			this.cmbSearch.TabStop = false;
			this.cmbSearch.SelectedIndexChanged += new EventHandler(this.cmbSearch_SelectedIndexChanged);
			this.txtSearchFor.Location = new Point(484, 17);
			this.txtSearchFor.MaxLength = 50;
			this.txtSearchFor.Name = "txtSearchFor";
			this.txtSearchFor.Size = new System.Drawing.Size(148, 20);
			this.txtSearchFor.TabIndex = 2;
			this.txtSearchFor.TabStop = false;
			this.txtSearchFor.TextChanged += new EventHandler(this.txtSearchFor_TextChanged);
			this.dgvLowStock.AllowUserToAddRows = false;
			this.dgvLowStock.AllowUserToDeleteRows = false;
			this.dgvLowStock.AllowUserToResizeColumns = false;
			this.dgvLowStock.AllowUserToResizeRows = false;
			this.dgvLowStock.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvLowStock.BackgroundColor = Color.White;
			this.dgvLowStock.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			DataGridViewColumnCollection columns = this.dgvLowStock.Columns;
			DataGridViewColumn[] productCode = new DataGridViewColumn[] { this.ProductCode, this.Product, this.CurrentStock, this.MinimumLEvel, this.Shelf, this.Group, this.Manufacture, this.GenericName, this.MedicineFor, this.Unit };
			columns.AddRange(productCode);
			this.dgvLowStock.GridColor = Color.WhiteSmoke;
			this.dgvLowStock.Location = new Point(14, 44);
			this.dgvLowStock.MultiSelect = false;
			this.dgvLowStock.Name = "dgvLowStock";
			this.dgvLowStock.ReadOnly = true;
			this.dgvLowStock.RowHeadersVisible = false;
			this.dgvLowStock.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			this.dgvLowStock.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			this.dgvLowStock.Size = new System.Drawing.Size(754, 307);
			this.dgvLowStock.TabIndex = 3;
			this.dgvLowStock.CellDoubleClick += new DataGridViewCellEventHandler(this.dgvLowStock_CellDoubleClick);
			this.ProductCode.DataPropertyName = "Product Code";
			this.ProductCode.FillWeight = 104.1793f;
			this.ProductCode.HeaderText = "Product Code";
			this.ProductCode.Name = "ProductCode";
			this.ProductCode.ReadOnly = true;
			this.Product.DataPropertyName = "Product";
			this.Product.FillWeight = 89.82806f;
			this.Product.HeaderText = "Product";
			this.Product.Name = "Product";
			this.Product.ReadOnly = true;
			this.CurrentStock.DataPropertyName = "CurrentStock";
			this.CurrentStock.FillWeight = 117.7665f;
			this.CurrentStock.HeaderText = "Current Stock";
			this.CurrentStock.Name = "CurrentStock";
			this.CurrentStock.ReadOnly = true;
			this.MinimumLEvel.DataPropertyName = "Stock Minimum Level";
			this.MinimumLEvel.HeaderText = "Stock Minimum Level";
			this.MinimumLEvel.Name = "MinimumLEvel";
			this.MinimumLEvel.ReadOnly = true;
			this.MinimumLEvel.Visible = false;
			this.Shelf.DataPropertyName = "Shelf";
			this.Shelf.FillWeight = 89.82806f;
			this.Shelf.HeaderText = "shelf";
			this.Shelf.Name = "Shelf";
			this.Shelf.ReadOnly = true;
			this.Group.DataPropertyName = "Group";
			this.Group.FillWeight = 89.82806f;
			this.Group.HeaderText = "Group";
			this.Group.Name = "Group";
			this.Group.ReadOnly = true;
			this.Manufacture.DataPropertyName = "Manufacture";
			this.Manufacture.FillWeight = 89.82806f;
			this.Manufacture.HeaderText = "Manufacture";
			this.Manufacture.Name = "Manufacture";
			this.Manufacture.ReadOnly = true;
			this.GenericName.DataPropertyName = "Generic Name";
			this.GenericName.FillWeight = 107.8759f;
			this.GenericName.HeaderText = "Generic Name";
			this.GenericName.Name = "GenericName";
			this.GenericName.ReadOnly = true;
			this.MedicineFor.DataPropertyName = "Medicine For";
			this.MedicineFor.FillWeight = 110.8661f;
			this.MedicineFor.HeaderText = "Medicine For";
			this.MedicineFor.Name = "MedicineFor";
			this.MedicineFor.ReadOnly = true;
			this.Unit.DataPropertyName = "Unit";
			this.Unit.HeaderText = "Unit";
			this.Unit.Name = "Unit";
			this.Unit.ReadOnly = true;
			this.Unit.Visible = false;
			this.lblSearc.AutoSize = true;
			this.lblSearc.Location = new Point(13, 17);
			this.lblSearc.Name = "lblSearc";
			this.lblSearc.Size = new System.Drawing.Size(59, 13);
			this.lblSearc.TabIndex = 22;
			this.lblSearc.Text = "Search By:";
			this.cmbSearchBy.DropDownStyle = ComboBoxStyle.DropDownList;
			this.cmbSearchBy.FormattingEnabled = true;
			ComboBox.ObjectCollection items = this.cmbSearchBy.Items;
			object[] objArray = new object[] { "All", "Product Group", "Generic Name", "Shelf", "Medicine For", "Manufacture" };
			items.AddRange(objArray);
			this.cmbSearchBy.Location = new Point(90, 17);
			this.cmbSearchBy.Name = "cmbSearchBy";
			this.cmbSearchBy.Size = new System.Drawing.Size(148, 21);
			this.cmbSearchBy.TabIndex = 0;
			this.cmbSearchBy.TabStop = false;
			this.cmbSearchBy.SelectedIndexChanged += new EventHandler(this.cmbSearchBy_SelectedIndexChanged);
			this.label6.AutoSize = true;
			this.label6.Location = new Point(406, 17);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(62, 13);
			this.label6.TabIndex = 23;
			this.label6.Text = "Search For:";
			this.panel6.BackgroundImage = (Image)componentResourceManager.GetObject("panel6.BackgroundImage");
			this.panel6.Controls.Add(this.label1);
			this.panel6.Controls.Add(this.panel7);
			this.panel6.Dock = DockStyle.Top;
			this.panel6.Location = new Point(1, 1);
			this.panel6.Name = "panel6";
			this.panel6.Size = new System.Drawing.Size(776, 33);
			this.panel6.TabIndex = 3;
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label1.Location = new Point(11, 7);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(177, 15);
			this.label1.TabIndex = 4;
			this.label1.Text = "Product Availability Search";
			this.panel7.BackColor = Color.FromArgb(136, 136, 136);
			this.panel7.Dock = DockStyle.Bottom;
			this.panel7.Location = new Point(0, 32);
			this.panel7.Name = "panel7";
			this.panel7.Size = new System.Drawing.Size(776, 1);
			this.panel7.TabIndex = 3;
			this.panel5.BackColor = Color.FromArgb(136, 136, 136);
			this.panel5.Dock = DockStyle.Bottom;
			this.panel5.Location = new Point(1, 444);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(776, 1);
			this.panel5.TabIndex = 2;
			this.panel4.BackColor = Color.FromArgb(136, 136, 136);
			this.panel4.Dock = DockStyle.Top;
			this.panel4.Location = new Point(1, 0);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(776, 1);
			this.panel4.TabIndex = 1;
			this.panel3.BackColor = Color.FromArgb(136, 136, 136);
			this.panel3.Dock = DockStyle.Right;
			this.panel3.Location = new Point(777, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(1, 445);
			this.panel3.TabIndex = 1;
			this.panel2.BackColor = Color.FromArgb(136, 136, 136);
			this.panel2.Dock = DockStyle.Left;
			this.panel2.Location = new Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(1, 445);
			this.panel2.TabIndex = 0;
			this.dataGridViewTextBoxColumn1.DataPropertyName = "Product Code";
			this.dataGridViewTextBoxColumn1.HeaderText = "Product Code";
			this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn1.ReadOnly = true;
			this.dataGridViewTextBoxColumn1.Width = 148;
			this.dataGridViewTextBoxColumn2.DataPropertyName = "Product";
			this.dataGridViewTextBoxColumn2.HeaderText = "Product";
			this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
			this.dataGridViewTextBoxColumn2.ReadOnly = true;
			this.dataGridViewTextBoxColumn2.Width = 148;
			this.dataGridViewTextBoxColumn3.DataPropertyName = "CurrentStock";
			this.dataGridViewTextBoxColumn3.HeaderText = "Current Stock";
			this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
			this.dataGridViewTextBoxColumn3.ReadOnly = true;
			this.dataGridViewTextBoxColumn3.Width = 149;
			this.dataGridViewTextBoxColumn4.DataPropertyName = "Stock Minimum Level";
			this.dataGridViewTextBoxColumn4.HeaderText = "Stock Minimum Level";
			this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
			this.dataGridViewTextBoxColumn4.ReadOnly = true;
			this.dataGridViewTextBoxColumn4.Width = 148;
			this.dataGridViewTextBoxColumn5.DataPropertyName = "Shelf";
			this.dataGridViewTextBoxColumn5.HeaderText = "shelf";
			this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
			this.dataGridViewTextBoxColumn5.ReadOnly = true;
			this.dataGridViewTextBoxColumn5.Visible = false;
			this.dataGridViewTextBoxColumn5.Width = 148;
			this.dataGridViewTextBoxColumn6.DataPropertyName = "Group";
			this.dataGridViewTextBoxColumn6.HeaderText = "Group";
			this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
			this.dataGridViewTextBoxColumn6.ReadOnly = true;
			this.dataGridViewTextBoxColumn6.Visible = false;
			this.dataGridViewTextBoxColumn6.Width = 92;
			this.dataGridViewTextBoxColumn7.DataPropertyName = "Manufacture";
			this.dataGridViewTextBoxColumn7.HeaderText = "Manufacture";
			this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
			this.dataGridViewTextBoxColumn7.ReadOnly = true;
			this.dataGridViewTextBoxColumn7.Visible = false;
			this.dataGridViewTextBoxColumn7.Width = 93;
			this.dataGridViewTextBoxColumn8.DataPropertyName = "Generic Name";
			this.dataGridViewTextBoxColumn8.HeaderText = "Generic Name";
			this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
			this.dataGridViewTextBoxColumn8.ReadOnly = true;
			this.dataGridViewTextBoxColumn8.Visible = false;
			this.dataGridViewTextBoxColumn8.Width = 92;
			this.dataGridViewTextBoxColumn9.DataPropertyName = "Medicine For";
			this.dataGridViewTextBoxColumn9.HeaderText = "Medicine For";
			this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
			this.dataGridViewTextBoxColumn9.ReadOnly = true;
			this.dataGridViewTextBoxColumn9.Visible = false;
			this.dataGridViewTextBoxColumn9.Width = 93;
			this.dataGridViewTextBoxColumn10.DataPropertyName = "Unit";
			this.dataGridViewTextBoxColumn10.HeaderText = "Unit";
			this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
			this.dataGridViewTextBoxColumn10.ReadOnly = true;
			this.dataGridViewTextBoxColumn10.Visible = false;
			this.dataGridViewTextBoxColumn10.Width = 123;
			this.dataGridViewTextBoxColumn11.DataPropertyName = "Product Code";
			this.dataGridViewTextBoxColumn11.HeaderText = "Product Code";
			this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
			this.dataGridViewTextBoxColumn11.ReadOnly = true;
			this.dataGridViewTextBoxColumn11.Width = 124;
			this.dataGridViewTextBoxColumn12.DataPropertyName = "Product";
			this.dataGridViewTextBoxColumn12.HeaderText = "Product";
			this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
			this.dataGridViewTextBoxColumn12.ReadOnly = true;
			this.dataGridViewTextBoxColumn12.Width = 123;
			this.dataGridViewTextBoxColumn13.DataPropertyName = "CurrentStock";
			this.dataGridViewTextBoxColumn13.HeaderText = "Current Stock";
			this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
			this.dataGridViewTextBoxColumn13.ReadOnly = true;
			this.dataGridViewTextBoxColumn13.Width = 124;
			this.dataGridViewTextBoxColumn14.DataPropertyName = "Expiry Date";
			this.dataGridViewTextBoxColumn14.HeaderText = "Expiry Date";
			this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
			this.dataGridViewTextBoxColumn14.ReadOnly = true;
			this.dataGridViewTextBoxColumn14.Width = 125;
			this.dataGridViewTextBoxColumn15.DataPropertyName = "Group";
			this.dataGridViewTextBoxColumn15.HeaderText = "Group";
			this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
			this.dataGridViewTextBoxColumn15.ReadOnly = true;
			this.dataGridViewTextBoxColumn15.Visible = false;
			this.dataGridViewTextBoxColumn15.Width = 124;
			this.dataGridViewTextBoxColumn16.DataPropertyName = "Manufacture";
			this.dataGridViewTextBoxColumn16.HeaderText = "Manufacture";
			this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
			this.dataGridViewTextBoxColumn16.ReadOnly = true;
			this.dataGridViewTextBoxColumn16.Visible = false;
			this.dataGridViewTextBoxColumn16.Width = 123;
			this.dataGridViewTextBoxColumn17.DataPropertyName = "Generic Name";
			this.dataGridViewTextBoxColumn17.HeaderText = "Generic Name";
			this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
			this.dataGridViewTextBoxColumn17.ReadOnly = true;
			this.dataGridViewTextBoxColumn17.Visible = false;
			this.dataGridViewTextBoxColumn17.Width = 52;
			this.dataGridViewTextBoxColumn18.DataPropertyName = "Medicine For";
			this.dataGridViewTextBoxColumn18.HeaderText = "Medicine For";
			this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
			this.dataGridViewTextBoxColumn18.ReadOnly = true;
			this.dataGridViewTextBoxColumn18.Visible = false;
			this.dataGridViewTextBoxColumn18.Width = 53;
			this.dataGridViewTextBoxColumn19.DataPropertyName = "Unit";
			this.dataGridViewTextBoxColumn19.HeaderText = "Unit";
			this.dataGridViewTextBoxColumn19.Name = "dataGridViewTextBoxColumn19";
			this.dataGridViewTextBoxColumn19.ReadOnly = true;
			this.dataGridViewTextBoxColumn19.Visible = false;
			this.dataGridViewTextBoxColumn19.Width = 53;
			this.dataGridViewTextBoxColumn20.DataPropertyName = "Batch";
			this.dataGridViewTextBoxColumn20.HeaderText = "Batch";
			this.dataGridViewTextBoxColumn20.Name = "dataGridViewTextBoxColumn20";
			this.dataGridViewTextBoxColumn20.ReadOnly = true;
			this.dataGridViewTextBoxColumn20.Visible = false;
			this.dataGridViewTextBoxColumn20.Width = 124;
			this.dataGridViewTextBoxColumn21.DataPropertyName = "Unit";
			this.dataGridViewTextBoxColumn21.HeaderText = "Unit";
			this.dataGridViewTextBoxColumn21.Name = "dataGridViewTextBoxColumn21";
			this.dataGridViewTextBoxColumn21.ReadOnly = true;
			this.dataGridViewTextBoxColumn21.Visible = false;
			this.dataGridViewTextBoxColumn21.Width = 123;
			this.dataGridViewTextBoxColumn22.DataPropertyName = "PurchasRate";
			this.dataGridViewTextBoxColumn22.HeaderText = "PurchasRate";
			this.dataGridViewTextBoxColumn22.Name = "dataGridViewTextBoxColumn22";
			this.dataGridViewTextBoxColumn22.ReadOnly = true;
			this.dataGridViewTextBoxColumn22.Visible = false;
			this.dataGridViewTextBoxColumn22.Width = 53;
			this.dataGridViewTextBoxColumn23.DataPropertyName = "SalesRate";
			this.dataGridViewTextBoxColumn23.HeaderText = "SalesRate";
			this.dataGridViewTextBoxColumn23.Name = "dataGridViewTextBoxColumn23";
			this.dataGridViewTextBoxColumn23.ReadOnly = true;
			this.dataGridViewTextBoxColumn23.Visible = false;
			this.dataGridViewTextBoxColumn23.Width = 53;
			this.dataGridViewTextBoxColumn24.DataPropertyName = "MRP";
			this.dataGridViewTextBoxColumn24.HeaderText = "MRP";
			this.dataGridViewTextBoxColumn24.Name = "dataGridViewTextBoxColumn24";
			this.dataGridViewTextBoxColumn24.ReadOnly = true;
			this.dataGridViewTextBoxColumn24.Visible = false;
			this.dataGridViewTextBoxColumn24.Width = 53;
			base.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.BackColor = Color.White;
			base.CancelButton = this.btnClose;
			base.ClientSize = new System.Drawing.Size(792, 459);
			base.Controls.Add(this.panel1);
			base.Icon = (System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.Name = "frmProductAvailability";
			base.Padding = new System.Windows.Forms.Padding(7);
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "Product Availability Search";
			base.Load += new EventHandler(this.frmReminderView_Load);
			this.panel1.ResumeLayout(false);
			this.panel8.ResumeLayout(false);
			this.panel8.PerformLayout();
			((ISupportInitialize)this.dgvLowStock).EndInit();
			this.panel6.ResumeLayout(false);
			this.panel6.PerformLayout();
			base.ResumeLayout(false);
		}

		public void RefreshForm()
		{
			SettingsSP settingsSP = new SettingsSP();
			SettingsInfo settingsInfo = new SettingsInfo();
			settingsInfo = settingsSP.SettingsView("1");
			this.cmbSearchBy.Text = "All";
			this.cmbSearch.Visible = false;
			this.txtSearchFor.Clear();
			this.cbxStatus.Checked = true;
			this.FillLowStockGridAccordingToSearch();
		}

		public void ReturnFromProductDetails()
		{
			base.Activate();
			base.WindowState = FormWindowState.Normal;
		}

		private void txtSearchFor_TextChanged(object sender, EventArgs e)
		{
			try
			{
				this.FillLowStockGridAccordingToSearch();
				for (int i = 0; i < this.dgvLowStock.Rows.Count; i++)
				{
					if (this.dgvLowStock.Rows[i].Visible)
					{
						if (!this.dgvLowStock.Rows[i].Cells[1].Value.ToString().ToLower().StartsWith(this.txtSearchFor.Text.ToLower()))
						{
							this.dgvLowStock.Rows[i].Visible = false;
						}
						else
						{
							this.dgvLowStock.Rows[i].Visible = true;
						}
					}
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		public void ViewProductDetails()
		{
			try
			{
				if (this.dgvLowStock.CurrentRow != null)
				{
					string str = this.dgvLowStock.CurrentRow.Cells["ProductCode"].Value.ToString();
					string str1 = this.dgvLowStock.CurrentRow.Cells["Product"].Value.ToString();
					decimal num = new decimal(0);
					try
					{
						num = decimal.Parse(this.dgvLowStock.CurrentRow.Cells["CurrentStock"].Value.ToString().Trim());
					}
					catch (Exception exception)
					{
						num = new decimal(0);
					}
					num = Math.Round(num, 2);
					string str2 = string.Concat(num.ToString(), " ", this.dgvLowStock.CurrentRow.Cells["Unit"].Value.ToString().Trim());
					string str3 = "";
					try
					{
						str3 = this.dgvLowStock.CurrentRow.Cells[4].Value.ToString();
					}
					catch (Exception exception1)
					{
					}
					string str4 = this.dgvLowStock.CurrentRow.Cells[5].Value.ToString();
					string str5 = "";
					try
					{
						str5 = this.dgvLowStock.CurrentRow.Cells[6].Value.ToString();
					}
					catch (Exception exception2)
					{
					}
					string str6 = "";
					try
					{
						str6 = this.dgvLowStock.CurrentRow.Cells[7].Value.ToString();
					}
					catch (Exception exception3)
					{
					}
					string str7 = "";
					try
					{
						str7 = this.dgvLowStock.CurrentRow.Cells[8].Value.ToString();
					}
					catch (Exception exception4)
					{
					}
					frmProductDetails frmProductDetail = new frmProductDetails();
					frmProductDetails item = Application.OpenForms["frmProductDetails"] as frmProductDetails;
					if (item != null)
					{
						item.MdiParent = MDIMedicalShop.MDIObj;
						item.WindowState = FormWindowState.Normal;
						item.Activate();
						item.CallThisFormFromProductAvailabilityForm(this, str, str1, str2, str3, str4, str5, str6, str7);
					}
					else
					{
						frmProductDetail.WindowState = FormWindowState.Normal;
						frmProductDetail.MdiParent = MDIMedicalShop.MDIObj;
						frmProductDetail.Show();
						frmProductDetail.CallThisFormFromProductAvailabilityForm(this, str, str1, str2, str3, str4, str5, str6, str7);
					}
				}
			}
			catch (Exception exception6)
			{
				Exception exception5 = exception6;
				MessageBox.Show(exception5.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}
	}
}