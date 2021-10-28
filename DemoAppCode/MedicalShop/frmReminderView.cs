using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;

namespace MedicalShop
{
	public class frmReminderView : Form
	{
		private bool isFromReminder = false;

		private string strTabName = "";

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

		private TabControl tcReminder;

		private TabPage tpLowStock;

		private DataGridView dgvLowStock;

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

		private ComboBox cmbSearchStock;

		private TextBox txtSearchForStock;

		private Label label6;

		private ComboBox cmbSearchByStock;

		private Label lblSearc;

		private Button btnViewDetails;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn21;

		private Button btnReset;

		private TabPage tpExpiry;

		private ComboBox cmbSearchExp;

		private TextBox txtSearchForExp;

		private Label label2;

		private ComboBox cmbSearchByExp;

		private Label label3;

		private DataGridView dgvExpiry;

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

		private Label lblStatus;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn22;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn23;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn24;

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

		private DataGridViewTextBoxColumn ProductCode1;

		private DataGridViewTextBoxColumn Product1;

		private DataGridViewTextBoxColumn Batch;

		private DataGridViewTextBoxColumn ExpiryDate;

		private DataGridViewTextBoxColumn Stock;

		private DataGridViewTextBoxColumn Shelf1;

		private DataGridViewTextBoxColumn Group1;

		private DataGridViewTextBoxColumn Manufacture1;

		private DataGridViewTextBoxColumn GenericName1;

		private DataGridViewTextBoxColumn MedicineFor1;

		private DataGridViewTextBoxColumn Unit1;

		private DataGridViewTextBoxColumn PurchasRate;

		private DataGridViewTextBoxColumn SalesRate;

		private DataGridViewTextBoxColumn MRP;

		public frmReminderView()
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
			try
			{
				this.ViewProductDetails();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		public void CallFromReminderPopUp(string strTab)
		{
			this.isFromReminder = true;
			this.strTabName = strTab;
			foreach (TabPage tabPage in this.tcReminder.TabPages)
			{
				if (tabPage.Name == this.strTabName)
				{
					this.tcReminder.SelectedTab = tabPage;
					break;
				}
			}
		}

		private void cmbSearchByExp_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				this.FillSerachComboOfExpiry();
				this.txtSearchForExp.Clear();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void cmbSearchByStock_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				this.FillSerachComboOfLowStock();
				this.txtSearchForStock.Clear();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void cmbSearchExp_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				this.FillExpiryGridAccordingToSearch();
				this.txtSearchForExp.Clear();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void cmbSearchStock_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				this.FillLowStockGridAccordingToSearch();
				this.txtSearchForStock.Clear();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void dgvExpiry_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				this.ViewProductDetails();
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

		public void FillExpiryGrid()
		{
			SettingsInfo settingsInfo = new SettingsInfo();
			SettingsSP settingsSP = new SettingsSP();
			DateTime today = DateTime.Today;
			string[] strArrays = settingsSP.SettingsView("1").ExpiryReminderWithin.Split(new char[] { '+' });
			if (strArrays[1].ToString() == "Days")
			{
				today = today.AddDays((double)int.Parse(strArrays[0].ToString()));
			}
			else if (strArrays[1].ToString() == "Months")
			{
				today = today.AddMonths(int.Parse(strArrays[0].ToString()));
			}
			else if (strArrays[1].ToString() == "Year")
			{
				today = today.AddYears(int.Parse(strArrays[0].ToString()));
			}
			this.lblStatus.Text = string.Concat("Products that will expire within ", strArrays[0].ToString(), " ", strArrays[1].ToString());
			ProductBatchSP productBatchSP = new ProductBatchSP();
			DataTable dataTable = new DataTable();
			dataTable = productBatchSP.ShortExpiryBatchGet(today);
			this.dgvExpiry.Rows.Clear();
			int str = 0;
			foreach (DataRow row in dataTable.Rows)
			{
				this.dgvExpiry.Rows.Add();
				this.dgvExpiry.Rows[str].Cells[0].Value = row.ItemArray[0].ToString();
				this.dgvExpiry.Rows[str].Cells[1].Value = row.ItemArray[1].ToString();
				this.dgvExpiry.Rows[str].Cells[2].Value = row.ItemArray[3].ToString();
				this.dgvExpiry.Rows[str].Cells[3].Value = row.ItemArray[4].ToString();
				this.dgvExpiry.Rows[str].Cells[4].Value = row.ItemArray[2].ToString();
				this.dgvExpiry.Rows[str].Cells[5].Value = row.ItemArray[5].ToString();
				this.dgvExpiry.Rows[str].Cells[6].Value = row.ItemArray[6].ToString();
				this.dgvExpiry.Rows[str].Cells[7].Value = row.ItemArray[7].ToString();
				this.dgvExpiry.Rows[str].Cells[8].Value = row.ItemArray[8].ToString();
				this.dgvExpiry.Rows[str].Cells[9].Value = row.ItemArray[9].ToString();
				this.dgvExpiry.Rows[str].Cells[10].Value = row.ItemArray[10].ToString();
				this.dgvExpiry.Rows[str].Cells[11].Value = row.ItemArray[11].ToString();
				this.dgvExpiry.Rows[str].Cells[12].Value = row.ItemArray[12].ToString();
				this.dgvExpiry.Rows[str].Cells[13].Value = row.ItemArray[13].ToString();
				str++;
			}
		}

		public void FillExpiryGridAccordingToSearch()
		{
			if (!(this.cmbSearchByExp.Text != "All"))
			{
				this.FillExpiryGrid();
				this.cmbSearchExp.Visible = false;
			}
			else
			{
				int num = 0;
				if (this.cmbSearchByExp.Text == "Product Group")
				{
					num = 6;
				}
				else if (this.cmbSearchByExp.Text == "Generic Name")
				{
					num = 8;
				}
				else if (this.cmbSearchByExp.Text == "Shelf")
				{
					num = 5;
				}
				else if (this.cmbSearchByExp.Text == "Medicine For")
				{
					num = 9;
				}
				else if (this.cmbSearchByExp.Text == "Manufacture")
				{
					num = 7;
				}
				for (int i = 0; i < this.dgvExpiry.Rows.Count; i++)
				{
					if (!this.dgvExpiry.Rows[i].Cells[num].Value.ToString().ToLower().StartsWith(this.cmbSearchExp.Text.ToLower()))
					{
						this.dgvExpiry.Rows[i].Visible = false;
					}
					else
					{
						this.dgvExpiry.Rows[i].Visible = true;
					}
				}
				this.cmbSearchExp.Visible = true;
			}
		}

		public void FillLowStockGrid()
		{
			ProductSP productSP = new ProductSP();
			DataTable dataTable = new DataTable();
			dataTable = productSP.GetAllLowStockProduct();
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

		public void FillLowStockGridAccordingToSearch()
		{
			if (!(this.cmbSearchByStock.Text != "All"))
			{
				this.FillLowStockGrid();
				this.cmbSearchStock.Visible = false;
			}
			else
			{
				int num = 0;
				if (this.cmbSearchByStock.Text == "Product Group")
				{
					num = 5;
				}
				else if (this.cmbSearchByStock.Text == "Generic Name")
				{
					num = 7;
				}
				else if (this.cmbSearchByStock.Text == "Shelf")
				{
					num = 4;
				}
				else if (this.cmbSearchByStock.Text == "Medicine For")
				{
					num = 8;
				}
				else if (this.cmbSearchByStock.Text == "Manufacture")
				{
					num = 6;
				}
				for (int i = 0; i < this.dgvLowStock.Rows.Count; i++)
				{
					if (!this.dgvLowStock.Rows[i].Cells[num].Value.ToString().ToLower().StartsWith(this.cmbSearchStock.Text.ToLower()))
					{
						this.dgvLowStock.Rows[i].Visible = false;
					}
					else
					{
						this.dgvLowStock.Rows[i].Visible = true;
					}
				}
				this.cmbSearchStock.Visible = true;
			}
		}

		public void FillSerachComboOfExpiry()
		{
			if (this.cmbSearchByExp.Text == "Product Group")
			{
				ProductGroupSP productGroupSP = new ProductGroupSP();
				DataTable dataTable = new DataTable();
				dataTable = productGroupSP.ProductGroupViewAll();
				this.cmbSearchExp.DataSource = dataTable;
				this.cmbSearchExp.DisplayMember = "Name";
				this.cmbSearchExp.ValueMember = "ID";
				this.cmbSearchExp.SelectedValue = "1";
			}
			else if (this.cmbSearchByExp.Text == "Generic Name")
			{
				GenericNameSP genericNameSP = new GenericNameSP();
				DataTable dataTable1 = new DataTable();
				dataTable1 = genericNameSP.GenericNameViewAll();
				this.cmbSearchExp.DataSource = dataTable1;
				this.cmbSearchExp.DisplayMember = "Name";
				this.cmbSearchExp.ValueMember = "ID";
				this.cmbSearchExp.SelectedValue = "0";
			}
			else if (this.cmbSearchByExp.Text == "Shelf")
			{
				ShelfSP shelfSP = new ShelfSP();
				DataTable dataTable2 = new DataTable();
				dataTable2 = shelfSP.ShelfViewAll();
				this.cmbSearchExp.DataSource = dataTable2;
				this.cmbSearchExp.DisplayMember = "Shelf Name";
				this.cmbSearchExp.ValueMember = "Shelf Id";
				this.cmbSearchExp.SelectedValue = "0";
			}
			else if (this.cmbSearchByExp.Text == "Medicine For")
			{
				ProductSP productSP = new ProductSP();
				DataTable dataTable3 = new DataTable();
				dataTable3 = productSP.MedicineForViewAll();
				this.cmbSearchExp.DataSource = dataTable3;
				this.cmbSearchExp.DisplayMember = "MedicineFor";
			}
			else if (!(this.cmbSearchByExp.Text == "Manufacture"))
			{
				this.cmbSearchExp.SelectedIndex = -1;
			}
			else
			{
				ManufacturerSP manufacturerSP = new ManufacturerSP();
				DataTable dataTable4 = new DataTable();
				dataTable4 = manufacturerSP.ManufacturerViewAll();
				this.cmbSearchExp.DataSource = dataTable4;
				this.cmbSearchExp.DisplayMember = "Name";
				this.cmbSearchExp.ValueMember = "ID";
				this.cmbSearchExp.SelectedValue = "0";
			}
		}

		public void FillSerachComboOfLowStock()
		{
			if (this.cmbSearchByStock.Text == "Product Group")
			{
				ProductGroupSP productGroupSP = new ProductGroupSP();
				DataTable dataTable = new DataTable();
				dataTable = productGroupSP.ProductGroupViewAll();
				this.cmbSearchStock.DataSource = dataTable;
				this.cmbSearchStock.DisplayMember = "Name";
				this.cmbSearchStock.ValueMember = "ID";
				this.cmbSearchStock.SelectedValue = "1";
			}
			else if (this.cmbSearchByStock.Text == "Generic Name")
			{
				GenericNameSP genericNameSP = new GenericNameSP();
				DataTable dataTable1 = new DataTable();
				dataTable1 = genericNameSP.GenericNameViewAll();
				this.cmbSearchStock.DataSource = dataTable1;
				this.cmbSearchStock.DisplayMember = "Name";
				this.cmbSearchStock.ValueMember = "ID";
				this.cmbSearchStock.SelectedValue = "0";
			}
			else if (this.cmbSearchByStock.Text == "Shelf")
			{
				ShelfSP shelfSP = new ShelfSP();
				DataTable dataTable2 = new DataTable();
				dataTable2 = shelfSP.ShelfViewAll();
				this.cmbSearchStock.DataSource = dataTable2;
				this.cmbSearchStock.DisplayMember = "Shelf Name";
				this.cmbSearchStock.ValueMember = "Shelf Id";
				this.cmbSearchStock.SelectedValue = "0";
			}
			else if (this.cmbSearchByStock.Text == "Medicine For")
			{
				ProductSP productSP = new ProductSP();
				DataTable dataTable3 = new DataTable();
				dataTable3 = productSP.MedicineForViewAll();
				this.cmbSearchStock.DataSource = dataTable3;
				this.cmbSearchStock.DisplayMember = "MedicineFor";
			}
			else if (!(this.cmbSearchByStock.Text == "Manufacture"))
			{
				this.cmbSearchStock.SelectedIndex = -1;
			}
			else
			{
				ManufacturerSP manufacturerSP = new ManufacturerSP();
				DataTable dataTable4 = new DataTable();
				dataTable4 = manufacturerSP.ManufacturerViewAll();
				this.cmbSearchStock.DataSource = dataTable4;
				this.cmbSearchStock.DisplayMember = "Name";
				this.cmbSearchStock.ValueMember = "ID";
				this.cmbSearchStock.SelectedValue = "0";
			}
		}

		private void frmReminderView_Load(object sender, EventArgs e)
		{
			try
			{
				this.RefreshForm();
				if (this.isFromReminder)
				{
					foreach (TabPage tabPage in this.tcReminder.TabPages)
					{
						if (tabPage.Name == this.strTabName)
						{
							this.tcReminder.SelectedTab = tabPage;
							break;
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

		private void InitializeComponent()
		{
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmReminderView));
			this.btnClose = new Button();
			this.panel1 = new Panel();
			this.btnReset = new Button();
			this.btnViewDetails = new Button();
			this.panel8 = new Panel();
			this.tcReminder = new TabControl();
			this.tpLowStock = new TabPage();
			this.cmbSearchStock = new ComboBox();
			this.txtSearchForStock = new TextBox();
			this.label6 = new Label();
			this.cmbSearchByStock = new ComboBox();
			this.lblSearc = new Label();
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
			this.tpExpiry = new TabPage();
			this.lblStatus = new Label();
			this.cmbSearchExp = new ComboBox();
			this.txtSearchForExp = new TextBox();
			this.label2 = new Label();
			this.cmbSearchByExp = new ComboBox();
			this.label3 = new Label();
			this.dgvExpiry = new DataGridView();
			this.ProductCode1 = new DataGridViewTextBoxColumn();
			this.Product1 = new DataGridViewTextBoxColumn();
			this.Batch = new DataGridViewTextBoxColumn();
			this.ExpiryDate = new DataGridViewTextBoxColumn();
			this.Stock = new DataGridViewTextBoxColumn();
			this.Shelf1 = new DataGridViewTextBoxColumn();
			this.Group1 = new DataGridViewTextBoxColumn();
			this.Manufacture1 = new DataGridViewTextBoxColumn();
			this.GenericName1 = new DataGridViewTextBoxColumn();
			this.MedicineFor1 = new DataGridViewTextBoxColumn();
			this.Unit1 = new DataGridViewTextBoxColumn();
			this.PurchasRate = new DataGridViewTextBoxColumn();
			this.SalesRate = new DataGridViewTextBoxColumn();
			this.MRP = new DataGridViewTextBoxColumn();
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
			this.tcReminder.SuspendLayout();
			this.tpLowStock.SuspendLayout();
			((ISupportInitialize)this.dgvLowStock).BeginInit();
			this.tpExpiry.SuspendLayout();
			((ISupportInitialize)this.dgvExpiry).BeginInit();
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
			this.panel8.Controls.Add(this.tcReminder);
			this.panel8.Dock = DockStyle.Top;
			this.panel8.Location = new Point(1, 34);
			this.panel8.Name = "panel8";
			this.panel8.Padding = new System.Windows.Forms.Padding(5);
			this.panel8.Size = new System.Drawing.Size(776, 359);
			this.panel8.TabIndex = 0;
			this.tcReminder.Controls.Add(this.tpLowStock);
			this.tcReminder.Controls.Add(this.tpExpiry);
			this.tcReminder.Dock = DockStyle.Top;
			this.tcReminder.Location = new Point(5, 5);
			this.tcReminder.Name = "tcReminder";
			this.tcReminder.SelectedIndex = 0;
			this.tcReminder.Size = new System.Drawing.Size(766, 346);
			this.tcReminder.TabIndex = 0;
			this.tcReminder.Selecting += new TabControlCancelEventHandler(this.tcReminder_Selecting);
			this.tcReminder.SelectedIndexChanged += new EventHandler(this.tcReminder_SelectedIndexChanged);
			this.tpLowStock.BackColor = Color.White;
			this.tpLowStock.Controls.Add(this.cmbSearchStock);
			this.tpLowStock.Controls.Add(this.txtSearchForStock);
			this.tpLowStock.Controls.Add(this.label6);
			this.tpLowStock.Controls.Add(this.cmbSearchByStock);
			this.tpLowStock.Controls.Add(this.lblSearc);
			this.tpLowStock.Controls.Add(this.dgvLowStock);
			this.tpLowStock.Location = new Point(4, 22);
			this.tpLowStock.Name = "tpLowStock";
			this.tpLowStock.Padding = new System.Windows.Forms.Padding(7);
			this.tpLowStock.Size = new System.Drawing.Size(758, 320);
			this.tpLowStock.TabIndex = 0;
			this.tpLowStock.Text = "Low Stock";
			this.tpLowStock.UseVisualStyleBackColor = true;
			this.cmbSearchStock.DropDownStyle = ComboBoxStyle.DropDownList;
			this.cmbSearchStock.FormattingEnabled = true;
			this.cmbSearchStock.Location = new Point(261, 15);
			this.cmbSearchStock.Name = "cmbSearchStock";
			this.cmbSearchStock.Size = new System.Drawing.Size(148, 21);
			this.cmbSearchStock.TabIndex = 1;
			this.cmbSearchStock.TabStop = false;
			this.cmbSearchStock.SelectedIndexChanged += new EventHandler(this.cmbSearchStock_SelectedIndexChanged);
			this.txtSearchForStock.Location = new Point(502, 15);
			this.txtSearchForStock.MaxLength = 50;
			this.txtSearchForStock.Name = "txtSearchForStock";
			this.txtSearchForStock.Size = new System.Drawing.Size(148, 20);
			this.txtSearchForStock.TabIndex = 2;
			this.txtSearchForStock.TabStop = false;
			this.txtSearchForStock.TextChanged += new EventHandler(this.txtSearchForStock_TextChanged);
			this.label6.AutoSize = true;
			this.label6.Location = new Point(422, 15);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(62, 13);
			this.label6.TabIndex = 23;
			this.label6.Text = "Search For:";
			this.cmbSearchByStock.DropDownStyle = ComboBoxStyle.DropDownList;
			this.cmbSearchByStock.FormattingEnabled = true;
			ComboBox.ObjectCollection items = this.cmbSearchByStock.Items;
			object[] objArray = new object[] { "All", "Product Group", "Generic Name", "Shelf", "Medicine For", "Manufacture" };
			items.AddRange(objArray);
			this.cmbSearchByStock.Location = new Point(107, 15);
			this.cmbSearchByStock.Name = "cmbSearchByStock";
			this.cmbSearchByStock.Size = new System.Drawing.Size(148, 21);
			this.cmbSearchByStock.TabIndex = 0;
			this.cmbSearchByStock.TabStop = false;
			this.cmbSearchByStock.SelectedIndexChanged += new EventHandler(this.cmbSearchByStock_SelectedIndexChanged);
			this.lblSearc.AutoSize = true;
			this.lblSearc.Location = new Point(27, 15);
			this.lblSearc.Name = "lblSearc";
			this.lblSearc.Size = new System.Drawing.Size(59, 13);
			this.lblSearc.TabIndex = 22;
			this.lblSearc.Text = "Search By:";
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
			this.dgvLowStock.Dock = DockStyle.Bottom;
			this.dgvLowStock.GridColor = Color.WhiteSmoke;
			this.dgvLowStock.Location = new Point(7, 50);
			this.dgvLowStock.MultiSelect = false;
			this.dgvLowStock.Name = "dgvLowStock";
			this.dgvLowStock.ReadOnly = true;
			this.dgvLowStock.RowHeadersVisible = false;
			this.dgvLowStock.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			this.dgvLowStock.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			this.dgvLowStock.Size = new System.Drawing.Size(744, 263);
			this.dgvLowStock.TabIndex = 3;
			this.dgvLowStock.CellDoubleClick += new DataGridViewCellEventHandler(this.dgvLowStock_CellDoubleClick);
			this.ProductCode.DataPropertyName = "Product Code";
			this.ProductCode.FillWeight = 98.68021f;
			this.ProductCode.HeaderText = "Product Code";
			this.ProductCode.Name = "ProductCode";
			this.ProductCode.ReadOnly = true;
			this.Product.DataPropertyName = "Product";
			this.Product.FillWeight = 98.68021f;
			this.Product.HeaderText = "Product";
			this.Product.Name = "Product";
			this.Product.ReadOnly = true;
			this.CurrentStock.DataPropertyName = "CurrentStock";
			this.CurrentStock.FillWeight = 98.68021f;
			this.CurrentStock.HeaderText = "Current Stock";
			this.CurrentStock.Name = "CurrentStock";
			this.CurrentStock.ReadOnly = true;
			this.MinimumLEvel.DataPropertyName = "Stock Minimum Level";
			this.MinimumLEvel.FillWeight = 106.599f;
			this.MinimumLEvel.HeaderText = "Stock Minimum Level";
			this.MinimumLEvel.Name = "MinimumLEvel";
			this.MinimumLEvel.ReadOnly = true;
			this.Shelf.DataPropertyName = "Shelf";
			this.Shelf.FillWeight = 98.68021f;
			this.Shelf.HeaderText = "shelf";
			this.Shelf.Name = "Shelf";
			this.Shelf.ReadOnly = true;
			this.Group.DataPropertyName = "Group";
			this.Group.FillWeight = 98.68021f;
			this.Group.HeaderText = "Group";
			this.Group.Name = "Group";
			this.Group.ReadOnly = true;
			this.Manufacture.DataPropertyName = "Manufacture";
			this.Manufacture.HeaderText = "Manufacture";
			this.Manufacture.Name = "Manufacture";
			this.Manufacture.ReadOnly = true;
			this.Manufacture.Visible = false;
			this.GenericName.DataPropertyName = "Generic Name";
			this.GenericName.HeaderText = "Generic Name";
			this.GenericName.Name = "GenericName";
			this.GenericName.ReadOnly = true;
			this.GenericName.Visible = false;
			this.MedicineFor.DataPropertyName = "Medicine For";
			this.MedicineFor.HeaderText = "Medicine For";
			this.MedicineFor.Name = "MedicineFor";
			this.MedicineFor.ReadOnly = true;
			this.MedicineFor.Visible = false;
			this.Unit.DataPropertyName = "Unit";
			this.Unit.HeaderText = "Unit";
			this.Unit.Name = "Unit";
			this.Unit.ReadOnly = true;
			this.Unit.Visible = false;
			this.tpExpiry.BackColor = Color.White;
			this.tpExpiry.Controls.Add(this.dgvExpiry);
			this.tpExpiry.Controls.Add(this.lblStatus);
			this.tpExpiry.Controls.Add(this.cmbSearchExp);
			this.tpExpiry.Controls.Add(this.txtSearchForExp);
			this.tpExpiry.Controls.Add(this.label2);
			this.tpExpiry.Controls.Add(this.cmbSearchByExp);
			this.tpExpiry.Controls.Add(this.label3);
			this.tpExpiry.Location = new Point(4, 22);
			this.tpExpiry.Name = "tpExpiry";
			this.tpExpiry.Padding = new System.Windows.Forms.Padding(7);
			this.tpExpiry.Size = new System.Drawing.Size(758, 320);
			this.tpExpiry.TabIndex = 1;
			this.tpExpiry.Text = "Short Expiry";
			this.lblStatus.AutoSize = true;
			this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.lblStatus.Location = new Point(10, 44);
			this.lblStatus.Name = "lblStatus";
			this.lblStatus.Size = new System.Drawing.Size(104, 15);
			this.lblStatus.TabIndex = 5;
			this.lblStatus.Text = "Reminder View";
			this.cmbSearchExp.DropDownStyle = ComboBoxStyle.DropDownList;
			this.cmbSearchExp.FormattingEnabled = true;
			this.cmbSearchExp.Location = new Point(261, 8);
			this.cmbSearchExp.Name = "cmbSearchExp";
			this.cmbSearchExp.Size = new System.Drawing.Size(148, 21);
			this.cmbSearchExp.TabIndex = 2;
			this.cmbSearchExp.TabStop = false;
			this.cmbSearchExp.SelectedIndexChanged += new EventHandler(this.cmbSearchExp_SelectedIndexChanged);
			this.txtSearchForExp.Location = new Point(502, 8);
			this.txtSearchForExp.Name = "txtSearchForExp";
			this.txtSearchForExp.Size = new System.Drawing.Size(148, 20);
			this.txtSearchForExp.TabIndex = 3;
			this.txtSearchForExp.TabStop = false;
			this.txtSearchForExp.TextChanged += new EventHandler(this.txtSearchForExp_TextChanged);
			this.label2.AutoSize = true;
			this.label2.Location = new Point(429, 15);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(62, 13);
			this.label2.TabIndex = 29;
			this.label2.Text = "Search For:";
			this.cmbSearchByExp.DropDownStyle = ComboBoxStyle.DropDownList;
			this.cmbSearchByExp.FormattingEnabled = true;
			ComboBox.ObjectCollection objectCollections = this.cmbSearchByExp.Items;
			objArray = new object[] { "All", "Product Group", "Generic Name", "Shelf", "Medicine For", "Manufacture" };
			objectCollections.AddRange(objArray);
			this.cmbSearchByExp.Location = new Point(107, 8);
			this.cmbSearchByExp.Name = "cmbSearchByExp";
			this.cmbSearchByExp.Size = new System.Drawing.Size(148, 21);
			this.cmbSearchByExp.TabIndex = 1;
			this.cmbSearchByExp.TabStop = false;
			this.cmbSearchByExp.SelectedIndexChanged += new EventHandler(this.cmbSearchByExp_SelectedIndexChanged);
			this.label3.AutoSize = true;
			this.label3.Location = new Point(34, 15);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(59, 13);
			this.label3.TabIndex = 28;
			this.label3.Text = "Search By:";
			this.dgvExpiry.AllowUserToAddRows = false;
			this.dgvExpiry.AllowUserToDeleteRows = false;
			this.dgvExpiry.AllowUserToResizeColumns = false;
			this.dgvExpiry.AllowUserToResizeRows = false;
			this.dgvExpiry.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvExpiry.BackgroundColor = Color.White;
			this.dgvExpiry.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			DataGridViewColumnCollection dataGridViewColumnCollections = this.dgvExpiry.Columns;
			productCode = new DataGridViewColumn[] { this.ProductCode1, this.Product1, this.Batch, this.ExpiryDate, this.Stock, this.Shelf1, this.Group1, this.Manufacture1, this.GenericName1, this.MedicineFor1, this.Unit1, this.PurchasRate, this.SalesRate, this.MRP };
			dataGridViewColumnCollections.AddRange(productCode);
			this.dgvExpiry.Dock = DockStyle.Bottom;
			this.dgvExpiry.GridColor = Color.WhiteSmoke;
			this.dgvExpiry.Location = new Point(7, 62);
			this.dgvExpiry.MultiSelect = false;
			this.dgvExpiry.Name = "dgvExpiry";
			this.dgvExpiry.ReadOnly = true;
			this.dgvExpiry.RowHeadersVisible = false;
			this.dgvExpiry.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			this.dgvExpiry.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			this.dgvExpiry.Size = new System.Drawing.Size(744, 251);
			this.dgvExpiry.TabIndex = 4;
			this.dgvExpiry.CellDoubleClick += new DataGridViewCellEventHandler(this.dgvExpiry_CellDoubleClick);
			this.ProductCode1.DataPropertyName = "Product Code";
			this.ProductCode1.FillWeight = 131.9674f;
			this.ProductCode1.HeaderText = "Product Code";
			this.ProductCode1.Name = "ProductCode1";
			this.ProductCode1.ReadOnly = true;
			this.Product1.DataPropertyName = "Product";
			this.Product1.FillWeight = 74.0658f;
			this.Product1.HeaderText = "Product";
			this.Product1.Name = "Product1";
			this.Product1.ReadOnly = true;
			this.Batch.DataPropertyName = "Batch";
			this.Batch.FillWeight = 56.28286f;
			this.Batch.HeaderText = "Batch";
			this.Batch.Name = "Batch";
			this.Batch.ReadOnly = true;
			this.ExpiryDate.DataPropertyName = "Expiry Date";
			this.ExpiryDate.FillWeight = 127.4996f;
			this.ExpiryDate.HeaderText = "Expiry Date";
			this.ExpiryDate.Name = "ExpiryDate";
			this.ExpiryDate.ReadOnly = true;
			this.Stock.DataPropertyName = "CurrentStock";
			this.Stock.FillWeight = 129.0576f;
			this.Stock.HeaderText = "Current Stock";
			this.Stock.Name = "Stock";
			this.Stock.ReadOnly = true;
			this.Shelf1.DataPropertyName = "Shelf";
			this.Shelf1.FillWeight = 56.28286f;
			this.Shelf1.HeaderText = "shelf";
			this.Shelf1.Name = "Shelf1";
			this.Shelf1.ReadOnly = true;
			this.Group1.DataPropertyName = "Group";
			this.Group1.FillWeight = 56.28286f;
			this.Group1.HeaderText = "Group";
			this.Group1.Name = "Group1";
			this.Group1.ReadOnly = true;
			this.Manufacture1.DataPropertyName = "Manufacture";
			this.Manufacture1.FillWeight = 102.6253f;
			this.Manufacture1.HeaderText = "Manufacture";
			this.Manufacture1.Name = "Manufacture1";
			this.Manufacture1.ReadOnly = true;
			this.GenericName1.DataPropertyName = "Generic Name";
			this.GenericName1.FillWeight = 133.9558f;
			this.GenericName1.HeaderText = "Generic Name";
			this.GenericName1.Name = "GenericName1";
			this.GenericName1.ReadOnly = true;
			this.MedicineFor1.DataPropertyName = "Medicine For";
			this.MedicineFor1.FillWeight = 131.9797f;
			this.MedicineFor1.HeaderText = "Medicine For";
			this.MedicineFor1.Name = "MedicineFor1";
			this.MedicineFor1.ReadOnly = true;
			this.Unit1.DataPropertyName = "Unit";
			this.Unit1.HeaderText = "Unit";
			this.Unit1.Name = "Unit1";
			this.Unit1.ReadOnly = true;
			this.Unit1.Visible = false;
			this.PurchasRate.DataPropertyName = "PurchasRate";
			this.PurchasRate.HeaderText = "PurchasRate";
			this.PurchasRate.Name = "PurchasRate";
			this.PurchasRate.ReadOnly = true;
			this.PurchasRate.Visible = false;
			this.SalesRate.DataPropertyName = "SalesRate";
			this.SalesRate.HeaderText = "SalesRate";
			this.SalesRate.Name = "SalesRate";
			this.SalesRate.ReadOnly = true;
			this.SalesRate.Visible = false;
			this.MRP.DataPropertyName = "MRP";
			this.MRP.HeaderText = "MRP";
			this.MRP.Name = "MRP";
			this.MRP.ReadOnly = true;
			this.MRP.Visible = false;
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
			this.label1.Size = new System.Drawing.Size(104, 15);
			this.label1.TabIndex = 4;
			this.label1.Text = "Reminder View";
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
			base.Name = "frmReminderView";
			base.Padding = new System.Windows.Forms.Padding(7);
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "Reminder View";
			base.Load += new EventHandler(this.frmReminderView_Load);
			this.panel1.ResumeLayout(false);
			this.panel8.ResumeLayout(false);
			this.tcReminder.ResumeLayout(false);
			this.tpLowStock.ResumeLayout(false);
			this.tpLowStock.PerformLayout();
			((ISupportInitialize)this.dgvLowStock).EndInit();
			this.tpExpiry.ResumeLayout(false);
			this.tpExpiry.PerformLayout();
			((ISupportInitialize)this.dgvExpiry).EndInit();
			this.panel6.ResumeLayout(false);
			this.panel6.PerformLayout();
			base.ResumeLayout(false);
		}

		public void RefreshForm()
		{
			SettingsSP settingsSP = new SettingsSP();
			SettingsInfo settingsInfo = new SettingsInfo();
			settingsInfo = settingsSP.SettingsView("1");
			this.cmbSearchByStock.Text = "All";
			this.cmbSearchByExp.Text = "All";
			this.cmbSearchStock.Visible = false;
			this.cmbSearchExp.Visible = false;
			this.txtSearchForExp.Clear();
			this.txtSearchForStock.Clear();
			this.FillLowStockGrid();
			this.FillExpiryGrid();
			if (settingsInfo.LowStockAlertStatus)
			{
				this.tcReminder.SelectedTab = this.tpLowStock;
				this.dgvLowStock.Focus();
			}
			else
			{
				this.tcReminder.SelectedTab = this.tpExpiry;
				this.dgvExpiry.Focus();
			}
		}

		public void ReturnFromProductDetails(string TabName)
		{
			base.Activate();
			base.WindowState = FormWindowState.Normal;
			foreach (TabPage tabPage in this.tcReminder.TabPages)
			{
				if (tabPage.Name == TabName)
				{
					this.tcReminder.SelectedTab = tabPage;
					break;
				}
			}
		}

		private void tcReminder_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				if (this.tcReminder.SelectedTab == this.tpLowStock)
				{
					this.dgvLowStock.Focus();
				}
				else if (this.tcReminder.SelectedTab == this.tpExpiry)
				{
					this.dgvExpiry.Focus();
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void tcReminder_Selecting(object sender, TabControlCancelEventArgs e)
		{
			try
			{
				SettingsSP settingsSP = new SettingsSP();
				SettingsInfo settingsInfo = new SettingsInfo();
				settingsInfo = settingsSP.SettingsView("1");
				if (e.TabPage == this.tpLowStock)
				{
					if (!settingsInfo.LowStockAlertStatus)
					{
						e.Cancel = true;
					}
				}
				else if (e.TabPage == this.tpExpiry)
				{
					if (!settingsInfo.ExpiryReminderNeeded)
					{
						e.Cancel = true;
					}
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void txtSearchForExp_TextChanged(object sender, EventArgs e)
		{
			try
			{
				this.FillExpiryGridAccordingToSearch();
				for (int i = 0; i < this.dgvExpiry.Rows.Count; i++)
				{
					if (this.dgvExpiry.Rows[i].Visible)
					{
						if (!this.dgvExpiry.Rows[i].Cells[1].Value.ToString().ToLower().StartsWith(this.txtSearchForExp.Text.ToLower()))
						{
							this.dgvExpiry.Rows[i].Visible = false;
						}
						else
						{
							this.dgvExpiry.Rows[i].Visible = true;
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

		private void txtSearchForStock_TextChanged(object sender, EventArgs e)
		{
			try
			{
				this.FillLowStockGridAccordingToSearch();
				for (int i = 0; i < this.dgvLowStock.Rows.Count; i++)
				{
					if (this.dgvLowStock.Rows[i].Visible)
					{
						if (!this.dgvLowStock.Rows[i].Cells[1].Value.ToString().ToLower().StartsWith(this.txtSearchForStock.Text.ToLower()))
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
			string str;
			string str1;
			decimal num;
			string str2;
			string str3;
			string str4;
			string str5;
			Exception exception;
			string str6;
			string str7;
			frmProductDetails frmProductDetail;
			frmProductDetails item;
			try
			{
				if (this.tcReminder.SelectedTab == this.tpLowStock)
				{
					if (this.dgvLowStock.CurrentRow != null)
					{
						str = this.dgvLowStock.CurrentRow.Cells["ProductCode"].Value.ToString();
						str1 = this.dgvLowStock.CurrentRow.Cells["Product"].Value.ToString();
						num = new decimal(0);
						try
						{
							num = decimal.Parse(this.dgvLowStock.CurrentRow.Cells["CurrentStock"].Value.ToString().Trim());
						}
						catch (Exception exception1)
						{
							num = new decimal(0);
						}
						num = Math.Round(num, 2);
						str2 = string.Concat(num.ToString(), " ", this.dgvLowStock.CurrentRow.Cells["Unit"].Value.ToString().Trim());
						str3 = "";
						try
						{
							str3 = this.dgvLowStock.CurrentRow.Cells[4].Value.ToString();
						}
						catch (Exception exception2)
						{
						}
						str4 = this.dgvLowStock.CurrentRow.Cells[5].Value.ToString();
						str5 = "";
						try
						{
							str5 = this.dgvLowStock.CurrentRow.Cells[6].Value.ToString();
						}
						catch (Exception exception3)
						{
							exception = exception3;
						}
						str6 = "";
						try
						{
							str6 = this.dgvLowStock.CurrentRow.Cells[7].Value.ToString();
						}
						catch (Exception exception4)
						{
						}
						str7 = "";
						try
						{
							str7 = this.dgvLowStock.CurrentRow.Cells[8].Value.ToString();
						}
						catch (Exception exception5)
						{
						}
						frmProductDetail = new frmProductDetails();
						item = Application.OpenForms["frmProductDetails"] as frmProductDetails;
						if (item != null)
						{
							item.MdiParent = MDIMedicalShop.MDIObj;
							item.WindowState = FormWindowState.Normal;
							item.Activate();
							item.CallThisFormFromReminderForm(this, str, str1, str2, str3, str4, str5, str6, str7, "", "", "", "", "", true);
						}
						else
						{
							frmProductDetail.WindowState = FormWindowState.Normal;
							frmProductDetail.MdiParent = MDIMedicalShop.MDIObj;
							frmProductDetail.Show();
							frmProductDetail.CallThisFormFromReminderForm(this, str, str1, str2, str3, str4, str5, str6, str7, "", "", "", "", "", true);
						}
					}
				}
				else if (this.dgvExpiry.CurrentRow != null)
				{
					str = this.dgvExpiry.CurrentRow.Cells["ProductCode1"].Value.ToString();
					str1 = this.dgvExpiry.CurrentRow.Cells["Product1"].Value.ToString();
					num = new decimal(0);
					try
					{
						num = decimal.Parse(this.dgvExpiry.CurrentRow.Cells["Stock"].Value.ToString().Trim());
					}
					catch (Exception exception6)
					{
						num = new decimal(0);
					}
					num = Math.Round(num, 2);
					str2 = string.Concat(num.ToString(), " ", this.dgvExpiry.CurrentRow.Cells["Unit1"].Value.ToString().Trim());
					str3 = "";
					try
					{
						str3 = this.dgvExpiry.CurrentRow.Cells["Shelf1"].Value.ToString();
					}
					catch (Exception exception7)
					{
					}
					str4 = this.dgvExpiry.CurrentRow.Cells["Group1"].Value.ToString();
					str5 = "";
					try
					{
						str5 = this.dgvExpiry.CurrentRow.Cells["Manufacture1"].Value.ToString();
					}
					catch (Exception exception8)
					{
					}
					str6 = "";
					try
					{
						str6 = this.dgvExpiry.CurrentRow.Cells["GenericName1"].Value.ToString();
					}
					catch (Exception exception9)
					{
					}
					str7 = "";
					try
					{
						str7 = this.dgvExpiry.CurrentRow.Cells["MedicineFor1"].Value.ToString();
					}
					catch (Exception exception10)
					{
					}
					string str8 = "";
					try
					{
						str8 = this.dgvExpiry.CurrentRow.Cells["PurchasRate"].Value.ToString();
					}
					catch (Exception exception11)
					{
					}
					string str9 = "";
					try
					{
						str9 = this.dgvExpiry.CurrentRow.Cells["SalesRate"].Value.ToString();
					}
					catch (Exception exception12)
					{
					}
					string str10 = "";
					try
					{
						str10 = this.dgvExpiry.CurrentRow.Cells["MRP"].Value.ToString();
					}
					catch (Exception exception13)
					{
					}
					string str11 = "";
					try
					{
						str11 = this.dgvExpiry.CurrentRow.Cells["Batch"].Value.ToString();
					}
					catch (Exception exception14)
					{
					}
					string str12 = "";
					try
					{
						str12 = this.dgvExpiry.CurrentRow.Cells["ExpiryDate"].Value.ToString();
					}
					catch (Exception exception15)
					{
					}
					frmProductDetail = new frmProductDetails();
					item = Application.OpenForms["frmProductDetails"] as frmProductDetails;
					if (item != null)
					{
						item.MdiParent = MDIMedicalShop.MDIObj;
						item.WindowState = FormWindowState.Normal;
						item.Activate();
						item.CallThisFormFromReminderForm(this, str, str1, str2, str3, str4, str5, str6, str7, str8, str9, str10, str11, str12, false);
					}
					else
					{
						frmProductDetail.WindowState = FormWindowState.Normal;
						frmProductDetail.MdiParent = MDIMedicalShop.MDIObj;
						frmProductDetail.Show();
						frmProductDetail.CallThisFormFromReminderForm(this, str, str1, str2, str3, str4, str5, str6, str7, str8, str9, str10, str11, str12, false);
					}
				}
			}
			catch (Exception exception16)
			{
				exception = exception16;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}
	}
}