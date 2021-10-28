using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;

namespace MedicalShop
{
	public class frmPopup : Form
	{
		private IContainer components = null;

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

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn21;

		private Button btnSelect;

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

		private DataGridView dgvStock;

		private CheckBox cbxStatus;

		private Button btnREfresh;

		private DataGridViewCheckBoxColumn c;

		private DataGridViewTextBoxColumn Code;

		private DataGridViewTextBoxColumn Product;

		private DataGridViewTextBoxColumn Batch;

		private DataGridViewTextBoxColumn ExpiryDate;

		private DataGridViewTextBoxColumn Stock;

		private DataGridViewTextBoxColumn Unit;

		private DataGridViewTextBoxColumn Rate;

		private DataGridViewTextBoxColumn Shelf;

		private DataGridViewTextBoxColumn Group;

		private DataGridViewTextBoxColumn Manufacture;

		private DataGridViewTextBoxColumn GenericName;

		private DataGridViewTextBoxColumn MedicineFor;

		private DataTable dtbl = new DataTable();

		private frmSalesInvoice frmsales;

		private bool isFromSales = false;

		private bool isFromPurchase = false;

		private bool isFromStock = false;

		private frmPurchaseInvoice frmpurchase;

		private frmStockEntry frmstock;

		public frmPopup()
		{
			this.InitializeComponent();
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			try
			{
				base.Close();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void btnREfresh_Click(object sender, EventArgs e)
		{
			try
			{
				this.RefreshForm();
				this.cmbSearch_SelectedIndexChanged(sender, e);
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void btnSelect_Click(object sender, EventArgs e)
		{
			try
			{
				this.GetSelectedRows();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		public void CallThisFormPurchase(frmPurchaseInvoice frm)
		{
			if (this.isFromStock)
			{
				this.isFromStock = false;
				this.frmstock.Enabled = true;
			}
			else if (this.isFromSales)
			{
				this.isFromSales = false;
				this.frmsales.Enabled = true;
			}
			this.isFromPurchase = true;
			this.frmpurchase = frm;
			base.Activate();
		}

		public void CallThisFormStock(frmStockEntry frm)
		{
			if (this.isFromPurchase)
			{
				this.isFromPurchase = false;
				this.frmpurchase.Enabled = true;
			}
			else if (this.isFromSales)
			{
				this.isFromSales = false;
				this.frmsales.Enabled = true;
			}
			this.isFromStock = true;
			this.frmstock = frm;
			base.Activate();
		}

		public void CallThisFromSales(frmSalesInvoice frm)
		{
			if (this.isFromStock)
			{
				this.isFromStock = false;
				this.frmstock.Enabled = true;
			}
			else if (this.isFromPurchase)
			{
				this.isFromPurchase = false;
				this.frmpurchase.Enabled = true;
			}
			this.isFromSales = true;
			this.frmsales = frm;
			base.Activate();
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

		protected override void Dispose(bool disposing)
		{
			if ((!disposing ? false : this.components != null))
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		public void DoWhenQuitingForm()
		{
			if (this.isFromSales)
			{
				this.frmsales.ReturnFromPopUp(this.dtbl);
			}
			else if (this.isFromStock)
			{
				this.frmstock.ReturnFromPopUp(this.dtbl);
			}
			else if (this.isFromPurchase)
			{
				this.frmpurchase.ReturnFromPopUp(this.dtbl);
			}
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
				string str = "";
				if (this.cmbSearchBy.Text == "Product Group")
				{
					str = "Group";
				}
				else if (this.cmbSearchBy.Text == "Generic Name")
				{
					str = "GenericName";
				}
				else if (this.cmbSearchBy.Text == "Shelf")
				{
					str = "Shelf";
				}
				else if (this.cmbSearchBy.Text == "Medicine For")
				{
					str = "MedicineFor";
				}
				else if (this.cmbSearchBy.Text == "Manufacture")
				{
					str = "Manufacture";
				}
				else if (this.cmbSearchBy.Text == "Product")
				{
					str = "Product";
				}
				else if (this.cmbSearchBy.Text == "Product Code")
				{
					str = "Code";
				}
				for (int i = 0; i < this.dgvStock.Rows.Count; i++)
				{
					if (!this.dgvStock.Rows[i].Cells[str].Value.ToString().ToLower().StartsWith(this.cmbSearch.Text.ToLower()))
					{
						this.dgvStock.Rows[i].Visible = false;
					}
					else
					{
						this.dgvStock.Rows[i].Visible = true;
					}
				}
				this.cmbSearch.Visible = true;
			}
			foreach (DataGridViewRow row in (IEnumerable)this.dgvStock.Rows)
			{
				decimal num = new decimal(0);
				try
				{
					num = decimal.Parse(row.Cells["Stock"].Value.ToString().Trim());
				}
				catch (Exception exception)
				{
					num = new decimal(0);
				}
				if (row.Visible)
				{
					if (this.cbxStatus.Checked)
					{
						if (!(num <= new decimal(0)))
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
			dataTable = productSP.ProductDetailsForPopUp();
			this.dgvStock.Rows.Clear();
			int str = 0;
			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				this.dgvStock.Rows.Add();
				this.dgvStock.Rows[str].Cells[0].Value = false;
				this.dgvStock.Rows[str].Cells["Code"].Value = dataTable.Rows[i]["ID"].ToString();
				this.dgvStock.Rows[str].Cells["Product"].Value = dataTable.Rows[i]["Product"].ToString();
				this.dgvStock.Rows[str].Cells["Stock"].Value = dataTable.Rows[i]["Stock"].ToString();
				this.dgvStock.Rows[str].Cells["Shelf"].Value = dataTable.Rows[i]["shelf"].ToString();
				this.dgvStock.Rows[str].Cells["Group"].Value = dataTable.Rows[i]["Group"].ToString();
				this.dgvStock.Rows[str].Cells["Manufacture"].Value = dataTable.Rows[i]["Man"].ToString();
				this.dgvStock.Rows[str].Cells["GenericName"].Value = dataTable.Rows[i]["Name"].ToString();
				this.dgvStock.Rows[str].Cells["MedicineFor"].Value = dataTable.Rows[i]["For"].ToString();
				this.dgvStock.Rows[str].Cells["Unit"].Value = dataTable.Rows[i]["Unit"].ToString();
				this.dgvStock.Rows[str].Cells["Batch"].Value = dataTable.Rows[i]["Batch"].ToString();
				if (!(this.dgvStock.Rows[str].Cells["Batch"].Value.ToString().ToLower() == "na"))
				{
					DataGridViewCell item = this.dgvStock.Rows[str].Cells["ExpiryDate"];
					DateTime dateTime = DateTime.Parse(dataTable.Rows[i]["ExDate"].ToString());
					item.Value = dateTime.ToString("dd-MMM-yyyy");
				}
				else
				{
					this.dgvStock.Rows[str].Cells["ExpiryDate"].Value = "";
				}
				this.dgvStock.Rows[str].Cells["Rate"].Value = dataTable.Rows[i]["Rate"].ToString();
				str++;
			}
		}

		public void FillSerachComboOfLowStock()
		{
			ProductSP productSP;
			DataTable dataTable;
			if (this.cmbSearchBy.Text == "Product Group")
			{
				ProductGroupSP productGroupSP = new ProductGroupSP();
				DataTable dataTable1 = new DataTable();
				dataTable1 = productGroupSP.ProductGroupViewAll();
				this.cmbSearch.DataSource = dataTable1;
				this.cmbSearch.DisplayMember = "Name";
				this.cmbSearch.ValueMember = "ID";
				this.cmbSearch.SelectedValue = "1";
			}
			else if (this.cmbSearchBy.Text == "Generic Name")
			{
				GenericNameSP genericNameSP = new GenericNameSP();
				DataTable dataTable2 = new DataTable();
				dataTable2 = genericNameSP.GenericNameViewAll();
				this.cmbSearch.DataSource = dataTable2;
				this.cmbSearch.DisplayMember = "Name";
				this.cmbSearch.ValueMember = "ID";
				this.cmbSearch.SelectedValue = "0";
			}
			else if (this.cmbSearchBy.Text == "Shelf")
			{
				ShelfSP shelfSP = new ShelfSP();
				DataTable dataTable3 = new DataTable();
				dataTable3 = shelfSP.ShelfViewAll();
				this.cmbSearch.DataSource = dataTable3;
				this.cmbSearch.DisplayMember = "Shelf Name";
				this.cmbSearch.ValueMember = "Shelf Id";
				this.cmbSearch.SelectedValue = "0";
			}
			else if (this.cmbSearchBy.Text == "Medicine For")
			{
				ProductSP productSP1 = new ProductSP();
				DataTable dataTable4 = new DataTable();
				dataTable4 = productSP1.MedicineForViewAll();
				this.cmbSearch.DataSource = dataTable4;
				this.cmbSearch.DisplayMember = "MedicineFor";
			}
			else if (this.cmbSearchBy.Text == "Manufacture")
			{
				ManufacturerSP manufacturerSP = new ManufacturerSP();
				DataTable dataTable5 = new DataTable();
				dataTable5 = manufacturerSP.ManufacturerViewAll();
				this.cmbSearch.DataSource = dataTable5;
				this.cmbSearch.DisplayMember = "Name";
				this.cmbSearch.ValueMember = "ID";
				this.cmbSearch.SelectedValue = "0";
			}
			else if (this.cmbSearchBy.Text == "Product")
			{
				productSP = new ProductSP();
				dataTable = new DataTable();
				dataTable = productSP.ProductViewAll();
				this.cmbSearch.DataSource = dataTable;
				this.cmbSearch.DisplayMember = "Name";
				this.cmbSearch.ValueMember = "ID";
			}
			else if (!(this.cmbSearchBy.Text == "Product Code"))
			{
				this.cmbSearch.Visible = false;
				this.FillLowStockGridAccordingToSearch();
			}
			else
			{
				productSP = new ProductSP();
				dataTable = new DataTable();
				dataTable = productSP.ProductViewAll();
				this.cmbSearch.DataSource = dataTable;
				this.cmbSearch.DisplayMember = "ID";
				this.cmbSearch.ValueMember = "ID";
			}
		}

		private void frmPopup_FormClosing(object sender, FormClosingEventArgs e)
		{
			try
			{
				this.DoWhenQuitingForm();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void frmPopup_Load(object sender, EventArgs e)
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

		public void GetSelectedRows()
		{
			this.dtbl = new DataTable();
			DataColumn dataColumn = new DataColumn();
			this.dtbl.Columns.Add(dataColumn);
			dataColumn = new DataColumn();
			this.dtbl.Columns.Add(dataColumn);
			dataColumn = new DataColumn();
			this.dtbl.Columns.Add(dataColumn);
			dataColumn = new DataColumn();
			this.dtbl.Columns.Add(dataColumn);
			dataColumn = new DataColumn();
			this.dtbl.Columns.Add(dataColumn);
			bool flag = false;
			foreach (DataGridViewRow row in (IEnumerable)this.dgvStock.Rows)
			{
				if (bool.Parse(row.Cells["c"].Value.ToString()))
				{
					flag = true;
					DataRow str = this.dtbl.NewRow();
					str[0] = row.Cells["Code"].Value.ToString();
					str[1] = row.Cells["Batch"].Value.ToString();
					str[2] = row.Cells["ExpiryDate"].Value.ToString();
					str[3] = row.Cells["Manufacture"].Value.ToString();
					str[4] = row.Cells["Unit"].Value.ToString();
					this.dtbl.Rows.Add(str);
				}
			}
			if (flag)
			{
				base.Close();
			}
			else
			{
				MessageBox.Show("Select product", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				this.dgvStock.Focus();
				int num = 0;
				if (this.dgvStock.Rows.Count > 0)
				{
					while (!this.dgvStock.Rows[num].Visible)
					{
						num++;
					}
					try
					{
						this.dgvStock.CurrentCell = this.dgvStock.Rows[num].Cells[1];
						this.dgvStock.CurrentRow.Selected = true;
					}
					catch (Exception exception)
					{
					}
				}
			}
		}

		private void InitializeComponent()
		{
			DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmPopup));
			this.btnClose = new Button();
			this.btnSelect = new Button();
			this.cbxStatus = new CheckBox();
			this.cmbSearch = new ComboBox();
			this.txtSearchFor = new TextBox();
			this.dgvStock = new DataGridView();
			this.c = new DataGridViewCheckBoxColumn();
			this.Code = new DataGridViewTextBoxColumn();
			this.Product = new DataGridViewTextBoxColumn();
			this.Batch = new DataGridViewTextBoxColumn();
			this.ExpiryDate = new DataGridViewTextBoxColumn();
			this.Stock = new DataGridViewTextBoxColumn();
			this.Unit = new DataGridViewTextBoxColumn();
			this.Rate = new DataGridViewTextBoxColumn();
			this.Shelf = new DataGridViewTextBoxColumn();
			this.Group = new DataGridViewTextBoxColumn();
			this.Manufacture = new DataGridViewTextBoxColumn();
			this.GenericName = new DataGridViewTextBoxColumn();
			this.MedicineFor = new DataGridViewTextBoxColumn();
			this.lblSearc = new Label();
			this.cmbSearchBy = new ComboBox();
			this.label6 = new Label();
			this.btnREfresh = new Button();
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
			((ISupportInitialize)this.dgvStock).BeginInit();
			base.SuspendLayout();
			this.btnClose.BackColor = Color.FromArgb(255, 209, 150);
			this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnClose.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 1);
			this.btnClose.FlatStyle = FlatStyle.Flat;
			this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.btnClose.Location = new Point(707, 533);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(75, 23);
			this.btnClose.TabIndex = 6;
			this.btnClose.Text = "&Close";
			this.btnClose.UseVisualStyleBackColor = false;
			this.btnClose.Click += new EventHandler(this.btnClose_Click);
			this.btnSelect.BackColor = Color.FromArgb(255, 209, 150);
			this.btnSelect.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnSelect.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 1);
			this.btnSelect.FlatStyle = FlatStyle.Flat;
			this.btnSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.btnSelect.Location = new Point(541, 533);
			this.btnSelect.Name = "btnSelect";
			this.btnSelect.Size = new System.Drawing.Size(74, 23);
			this.btnSelect.TabIndex = 5;
			this.btnSelect.Text = "&Select";
			this.btnSelect.UseVisualStyleBackColor = false;
			this.btnSelect.Click += new EventHandler(this.btnSelect_Click);
			this.cbxStatus.AutoSize = true;
			this.cbxStatus.Location = new Point(632, 16);
			this.cbxStatus.Name = "cbxStatus";
			this.cbxStatus.Size = new System.Drawing.Size(138, 17);
			this.cbxStatus.TabIndex = 104;
			this.cbxStatus.Text = "Available Products Only";
			this.cbxStatus.UseVisualStyleBackColor = true;
			this.cbxStatus.CheckedChanged += new EventHandler(this.cmbSearch_SelectedIndexChanged);
			this.cmbSearch.DropDownStyle = ComboBoxStyle.DropDownList;
			this.cmbSearch.FormattingEnabled = true;
			this.cmbSearch.Location = new Point(256, 9);
			this.cmbSearch.Name = "cmbSearch";
			this.cmbSearch.Size = new System.Drawing.Size(148, 21);
			this.cmbSearch.TabIndex = 1;
			this.cmbSearch.TabStop = false;
			this.cmbSearch.SelectedIndexChanged += new EventHandler(this.cmbSearch_SelectedIndexChanged);
			this.txtSearchFor.Location = new Point(478, 10);
			this.txtSearchFor.MaxLength = 50;
			this.txtSearchFor.Name = "txtSearchFor";
			this.txtSearchFor.Size = new System.Drawing.Size(148, 20);
			this.txtSearchFor.TabIndex = 2;
			this.txtSearchFor.TabStop = false;
			this.txtSearchFor.TextChanged += new EventHandler(this.txtSearchFor_TextChanged);
			this.dgvStock.AllowUserToAddRows = false;
			this.dgvStock.AllowUserToDeleteRows = false;
			this.dgvStock.AllowUserToResizeColumns = false;
			this.dgvStock.AllowUserToResizeRows = false;
			dataGridViewCellStyle.BackColor = Color.White;
			this.dgvStock.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle;
			this.dgvStock.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvStock.BackgroundColor = Color.White;
			this.dgvStock.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			DataGridViewColumnCollection columns = this.dgvStock.Columns;
			DataGridViewColumn[] code = new DataGridViewColumn[] { this.c, this.Code, this.Product, this.Batch, this.ExpiryDate, this.Stock, this.Unit, this.Rate, this.Shelf, this.Group, this.Manufacture, this.GenericName, this.MedicineFor };
			columns.AddRange(code);
			this.dgvStock.GridColor = Color.WhiteSmoke;
			this.dgvStock.Location = new Point(10, 50);
			this.dgvStock.MultiSelect = false;
			this.dgvStock.Name = "dgvStock";
			this.dgvStock.RowHeadersVisible = false;
			this.dgvStock.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			this.dgvStock.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			this.dgvStock.Size = new System.Drawing.Size(772, 477);
			this.dgvStock.TabIndex = 3;
			this.c.HeaderText = "";
			this.c.Name = "c";
			this.c.Resizable = DataGridViewTriState.True;
			this.Code.HeaderText = "Code";
			this.Code.Name = "Code";
			this.Code.ReadOnly = true;
			this.Product.HeaderText = "Product";
			this.Product.Name = "Product";
			this.Product.ReadOnly = true;
			this.Batch.HeaderText = "Batch";
			this.Batch.Name = "Batch";
			this.Batch.ReadOnly = true;
			this.ExpiryDate.HeaderText = "Ex.Date";
			this.ExpiryDate.Name = "ExpiryDate";
			this.ExpiryDate.ReadOnly = true;
			this.Stock.HeaderText = "Stock";
			this.Stock.Name = "Stock";
			this.Stock.ReadOnly = true;
			this.Unit.HeaderText = "Unit";
			this.Unit.Name = "Unit";
			this.Unit.ReadOnly = true;
			this.Rate.HeaderText = "Rate";
			this.Rate.Name = "Rate";
			this.Rate.ReadOnly = true;
			this.Shelf.HeaderText = "Shelf";
			this.Shelf.Name = "Shelf";
			this.Shelf.ReadOnly = true;
			this.Group.HeaderText = "Group";
			this.Group.Name = "Group";
			this.Group.ReadOnly = true;
			this.Manufacture.HeaderText = "Manufacture";
			this.Manufacture.Name = "Manufacture";
			this.Manufacture.ReadOnly = true;
			this.GenericName.HeaderText = "Generic Name";
			this.GenericName.Name = "GenericName";
			this.GenericName.ReadOnly = true;
			this.MedicineFor.HeaderText = "Medicine For";
			this.MedicineFor.Name = "MedicineFor";
			this.MedicineFor.ReadOnly = true;
			this.lblSearc.AutoSize = true;
			this.lblSearc.Location = new Point(10, 17);
			this.lblSearc.Name = "lblSearc";
			this.lblSearc.Size = new System.Drawing.Size(59, 13);
			this.lblSearc.TabIndex = 22;
			this.lblSearc.Text = "Search By:";
			this.cmbSearchBy.DropDownStyle = ComboBoxStyle.DropDownList;
			this.cmbSearchBy.FormattingEnabled = true;
			ComboBox.ObjectCollection items = this.cmbSearchBy.Items;
			object[] objArray = new object[] { "All", "Product Code", "Product", "Product Group", "Generic Name", "Shelf", "Medicine For", "Manufacture" };
			items.AddRange(objArray);
			this.cmbSearchBy.Location = new Point(91, 9);
			this.cmbSearchBy.Name = "cmbSearchBy";
			this.cmbSearchBy.Size = new System.Drawing.Size(148, 21);
			this.cmbSearchBy.TabIndex = 0;
			this.cmbSearchBy.TabStop = false;
			this.cmbSearchBy.SelectedIndexChanged += new EventHandler(this.cmbSearchBy_SelectedIndexChanged);
			this.label6.AutoSize = true;
			this.label6.Location = new Point(410, 17);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(62, 13);
			this.label6.TabIndex = 23;
			this.label6.Text = "Search For:";
			this.btnREfresh.BackColor = Color.FromArgb(255, 209, 150);
			this.btnREfresh.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnREfresh.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 1);
			this.btnREfresh.FlatStyle = FlatStyle.Flat;
			this.btnREfresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.btnREfresh.Location = new Point(626, 533);
			this.btnREfresh.Name = "btnREfresh";
			this.btnREfresh.Size = new System.Drawing.Size(74, 23);
			this.btnREfresh.TabIndex = 105;
			this.btnREfresh.Text = "&Refresh";
			this.btnREfresh.UseVisualStyleBackColor = false;
			this.btnREfresh.Click += new EventHandler(this.btnREfresh_Click);
			this.dataGridViewTextBoxColumn1.DataPropertyName = "Product Code";
			this.dataGridViewTextBoxColumn1.HeaderText = "Product Code";
			this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn1.ReadOnly = true;
			this.dataGridViewTextBoxColumn1.Visible = false;
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
			this.BackgroundImage = (Image)componentResourceManager.GetObject("$this.BackgroundImage");
			this.BackgroundImageLayout = ImageLayout.Stretch;
			base.CancelButton = this.btnClose;
			base.ClientSize = new System.Drawing.Size(792, 566);
			base.Controls.Add(this.btnREfresh);
			base.Controls.Add(this.btnSelect);
			base.Controls.Add(this.cbxStatus);
			base.Controls.Add(this.btnClose);
			base.Controls.Add(this.cmbSearch);
			base.Controls.Add(this.dgvStock);
			base.Controls.Add(this.label6);
			base.Controls.Add(this.txtSearchFor);
			base.Controls.Add(this.cmbSearchBy);
			base.Controls.Add(this.lblSearc);
			base.Icon = (System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "frmPopup";
			base.Padding = new System.Windows.Forms.Padding(7);
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "Search";
			base.FormClosing += new FormClosingEventHandler(this.frmPopup_FormClosing);
			base.Load += new EventHandler(this.frmPopup_Load);
			((ISupportInitialize)this.dgvStock).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		public void RefreshForm()
		{
			SettingsSP settingsSP = new SettingsSP();
			SettingsInfo settingsInfo = new SettingsInfo();
			settingsInfo = settingsSP.SettingsView("1");
			this.cmbSearchBy.Text = "All";
			this.cmbSearch.Visible = false;
			this.txtSearchFor.Clear();
			this.FillProductGrid();
			this.cbxStatus.Checked = true;
		}

		private void txtSearchFor_TextChanged(object sender, EventArgs e)
		{
			try
			{
				this.FillLowStockGridAccordingToSearch();
				for (int i = 0; i < this.dgvStock.Rows.Count; i++)
				{
					if (this.dgvStock.Rows[i].Visible)
					{
						if (!this.dgvStock.Rows[i].Cells[2].Value.ToString().ToLower().StartsWith(this.txtSearchFor.Text.ToLower()))
						{
							this.dgvStock.Rows[i].Visible = false;
						}
						else
						{
							this.dgvStock.Rows[i].Visible = true;
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
	}
}