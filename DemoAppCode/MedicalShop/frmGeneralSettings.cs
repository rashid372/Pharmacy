using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;

namespace MedicalShop
{
	public class frmGeneralSettings : Form
	{
		private bool isFromFinance = false;

		private IContainer components = null;

		private Panel panel1;

		private Button btnSave;

		private Button btnReset;

		private Button btnClose;

		private Panel panel8;

		private GroupBox gpbRegister;

		private Panel panel6;

		private Label label1;

		private Panel panel7;

		private Panel panel5;

		private Panel panel4;

		private Panel panel3;

		private Panel panel2;

		private GroupBox groupBox2;

		private RadioButton rbtnEx3;

		private RadioButton rbtnEx2;

		private RadioButton rbtnEx1;

		private GroupBox groupBox1;

		private RadioButton rbtnStock3;

		private RadioButton rbtnStock2;

		private RadioButton rbtnstock1;

		private CheckBox cbExpiry;

		private CheckBox cbProduct;

		private ComboBox cmbLimit;

		private TextBox txtLimit;

		private GroupBox gpbLimit;

		private CheckBox cbLowStock;

		public frmGeneralSettings()
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
				this.Fill();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void btnSave_Click(object sender, EventArgs e)
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

		public void CallThisFormFromFinancialYearForm(bool isFromfinance)
		{
			this.isFromFinance = isFromfinance;
			base.Show();
			base.Activate();
		}

		private void cbExpiry_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				if (!this.cbExpiry.Checked)
				{
					this.gpbLimit.Enabled = false;
				}
				else
				{
					this.gpbLimit.Enabled = true;
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void cmbLimit_KeyDown(object sender, KeyEventArgs e)
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

		protected override void Dispose(bool disposing)
		{
			if ((!disposing ? false : this.components != null))
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		public void Fill()
		{
			this.cbProduct.Enabled = true;
			this.cbProduct.Checked = false;
			this.cbExpiry.Checked = false;
			this.cbLowStock.Checked = false;
			this.txtLimit.Text = "1";
			this.cmbLimit.Text = "Days";
			this.rbtnstock1.Checked = false;
			this.rbtnStock2.Checked = false;
			this.rbtnStock3.Checked = false;
			this.rbtnEx1.Checked = false;
			this.rbtnEx2.Checked = false;
			this.rbtnEx3.Checked = false;
			SettingsSP settingsSP = new SettingsSP();
			SettingsInfo settingsInfo = new SettingsInfo();
			settingsInfo = settingsSP.SettingsView("1");
			if (settingsInfo.AutomaticProductIdGeneration)
			{
				this.cbProduct.Checked = true;
			}
			else if (!(new ProductSP()).ProductGetMax1())
			{
				this.cbProduct.Enabled = false;
			}
			else
			{
				this.cbProduct.Enabled = true;
			}
			if (settingsInfo.LowStockAlertStatus)
			{
				this.cbLowStock.Checked = true;
			}
			if (settingsInfo.ExpiryProductTransactionStatus == "Ignore")
			{
				this.rbtnEx1.Checked = true;
			}
			else if (settingsInfo.ExpiryProductTransactionStatus == "Warn")
			{
				this.rbtnEx2.Checked = true;
			}
			else if (settingsInfo.ExpiryProductTransactionStatus == "Block")
			{
				this.rbtnEx3.Checked = true;
			}
			if (settingsInfo.NegativeStockAlertStatus == "Ignore")
			{
				this.rbtnstock1.Checked = true;
			}
			else if (settingsInfo.NegativeStockAlertStatus == "Warn")
			{
				this.rbtnStock2.Checked = true;
			}
			else if (settingsInfo.NegativeStockAlertStatus == "Block")
			{
				this.rbtnStock3.Checked = true;
			}
			if (!settingsInfo.ExpiryReminderNeeded)
			{
				this.cbExpiry.Checked = false;
				this.gpbLimit.Enabled = false;
			}
			else
			{
				string expiryReminderWithin = settingsInfo.ExpiryReminderWithin;
				this.gpbLimit.Enabled = true;
				string[] strArrays = expiryReminderWithin.Split(new char[] { '+' });
				this.txtLimit.Text = strArrays[0].ToString();
				this.cmbLimit.Text = strArrays[1].ToString();
				this.cbExpiry.Checked = true;
			}
		}
        public void UpdateSetting()
        {
            this.cbProduct.Enabled = true;
            this.cbProduct.Checked = false;
            this.cbExpiry.Checked = false;
            this.cbLowStock.Checked = false;
            this.txtLimit.Text = "1";
            this.cmbLimit.Text = "Days";
            this.rbtnstock1.Checked = false;
            this.rbtnStock2.Checked = false;
            this.rbtnStock3.Checked = false;
            this.rbtnEx1.Checked = false;
            this.rbtnEx2.Checked = false;
            this.rbtnEx3.Checked = false;
            SettingsSP settingsSP = new SettingsSP();
            SettingsInfo settingsInfo = new SettingsInfo();
            settingsInfo = settingsSP.SettingsView("1");
            if (settingsInfo.AutomaticProductIdGeneration)
            {
                this.cbProduct.Checked = true;
            }
            else if (!(new ProductSP()).ProductGetMax1())
            {
                this.cbProduct.Enabled = false;
            }
            else
            {
                this.cbProduct.Enabled = true;
            }
            if (settingsInfo.LowStockAlertStatus)
            {
                this.cbLowStock.Checked = true;
            }
            if (settingsInfo.ExpiryProductTransactionStatus == "Ignore")
            {
                this.rbtnEx1.Checked = true;
            }
            else if (settingsInfo.ExpiryProductTransactionStatus == "Warn")
            {
                this.rbtnEx2.Checked = true;
            }
            else if (settingsInfo.ExpiryProductTransactionStatus == "Block")
            {
                this.rbtnEx3.Checked = true;
            }
            if (settingsInfo.NegativeStockAlertStatus == "Ignore")
            {
                this.rbtnstock1.Checked = true;
            }
            else if (settingsInfo.NegativeStockAlertStatus == "Warn")
            {
                this.rbtnStock2.Checked = true;
            }
            else if (settingsInfo.NegativeStockAlertStatus == "Block")
            {
                this.rbtnStock3.Checked = true;
            }
            if (!settingsInfo.ExpiryReminderNeeded)
            {
                this.cbExpiry.Checked = false;
                this.gpbLimit.Enabled = false;
            }
            else
            {
                string expiryReminderWithin = settingsInfo.ExpiryReminderWithin;
                this.gpbLimit.Enabled = true;
                string[] strArrays = expiryReminderWithin.Split(new char[] { '+' });
                this.txtLimit.Text = strArrays[0].ToString();
                this.cmbLimit.Text = strArrays[1].ToString();
                this.cbExpiry.Checked = true;
            }
        }
        //private void saveOrEditDetails()
        //{
        //    frmGeneralSettings frmGeneralSetting;
        //    frmGeneralSettings item;
        //    try
        //    {
        //        DataTable dataTable = new DataTable();
        //        if (!FinacialYearInfo._activeOrNot)
        //        {
        //            MessageBox.Show("Selected finacial year has been closed", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        //        }
        //        else
        //        {
        //            this.cbProduct.Text = this.cbProduct.Text.Trim();

        //            if (!(this.cbProduct.Text != ""))
        //            {
        //                MessageBox.Show("Enter product code", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        //                this.txtProductCode.Select();
        //                this.txtProductCode.Focus();
        //            }
        //            else if (!(this.txtProductName.Text != ""))
        //            {
        //                MessageBox.Show("Enter product name", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        //                this.txtProductName.Select();
        //                this.txtProductName.Focus();
        //            }
        //            else if (!(decimal.Parse(this.txtStockMinLevel.Text.Trim()) <= decimal.Parse(this.txtStockMaxLevel.Text)))
        //            {
        //                MessageBox.Show("Stock Min level should not be greater than stock max level", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        //                this.txtStockMinLevel.Select();
        //                this.txtStockMinLevel.Focus();
        //            }
        //            else if ((this.cmbUnit.SelectedValue == null || !(this.cmbUnit.SelectedValue.ToString() != "") ? true : this.cmbUnit.SelectedIndex == -1))
        //            {
        //                MessageBox.Show("Select unit", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        //                this.cmbUnit.Select();
        //                this.cmbUnit.Focus();
        //            }
        //            else
        //            {
        //                this.ProductInfo.ProductName = this.txtProductName.Text;
        //                if (this.cmbProductGroup.SelectedValue == null)
        //                {
        //                    this.ProductInfo.ProductGroupId = "";
        //                }
        //                else
        //                {
        //                    this.ProductInfo.ProductGroupId = this.cmbProductGroup.SelectedValue.ToString();
        //                }
        //                if (this.cmbManufacture.SelectedValue == null)
        //                {
        //                    this.ProductInfo.ManufactureId = "";
        //                }
        //                else
        //                {
        //                    this.ProductInfo.ManufactureId = this.cmbManufacture.SelectedValue.ToString();
        //                }
        //                if (this.cmbShelf.SelectedValue == null)
        //                {
        //                    this.ProductInfo.ShelfId = "";
        //                }
        //                else
        //                {
        //                    this.ProductInfo.ShelfId = this.cmbShelf.SelectedValue.ToString();
        //                }
        //                if (this.cmbGenericName.SelectedValue == null)
        //                {
        //                    this.ProductInfo.GenericNameId = "";
        //                }
        //                else
        //                {
        //                    this.ProductInfo.GenericNameId = this.cmbGenericName.SelectedValue.ToString();
        //                }
        //                this.ProductInfo.StockMinimumLevel = decimal.Parse(this.txtStockMinLevel.Text);
        //                this.ProductInfo.StockMaximumLevel = decimal.Parse(this.txtStockMaxLevel.Text);
        //                if (!(this.cmbMedicineFor.Text != ""))
        //                {
        //                    this.ProductInfo.MedicineFor = "";
        //                }
        //                else
        //                {
        //                    this.ProductInfo.MedicineFor = this.cmbMedicineFor.Text;
        //                }
        //                if (this.cmbUnit.SelectedValue == null)
        //                {
        //                    this.ProductInfo.UnitId = "";
        //                }
        //                else
        //                {
        //                    this.ProductInfo.UnitId = this.cmbUnit.SelectedValue.ToString();
        //                }
        //                this.ProductInfo.Description = this.txtDescription.Text;
        //                this.ProductInfo.ProductId = this.txtProductCode.Text.Trim();
        //                this.ProductInfo.ProductName = this.txtProductName.Text.Trim();
        //                this.ProductBatchInfo.ProductId = this.txtProductCode.Text;
        //                this.ProductBatchInfo.BatchName = "NA";
        //                this.ProductBatchInfo.ExpiryDate = DateTime.Parse("1/1/1753");
        //                this.ProductBatchInfo.PurchaseRate = new decimal(0);
        //                this.ProductBatchInfo.SalesRate = new decimal(0);
        //                this.ProductBatchInfo.MRP = new decimal(0);
        //                this.ProductBatchInfo.Description = "";
        //                if (this.isAutoGenerate)
        //                {
        //                    if (this.CheckExistanceOfProductName())
        //                    {
        //                        MessageBox.Show("Product name already exist", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        //                        this.txtProductName.Focus();
        //                        this.txtProductName.SelectAll();
        //                    }
        //                    else if (!(this.btnSave.Text == "&Save"))
        //                    {
        //                        this.ProductSP.ProductEdit(this.ProductInfo);
        //                        MessageBox.Show("Updated successfully", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        //                        this.clear();
        //                    }
        //                    else
        //                    {
        //                        this.ProductSP.ProductAdd(this.ProductInfo);
        //                        this.ProductBatchSP.ProductBatchAdd(this.ProductBatchInfo);
        //                        MessageBox.Show("Saved successfully", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        //                        frmGeneralSetting = new frmGeneralSettings();
        //                        item = Application.OpenForms["frmGeneralSettings"] as frmGeneralSettings;
        //                        if (item != null)
        //                        {
        //                            item.Fill();
        //                        }
        //                        this.clear();
        //                    }
        //                }
        //                else if (this.CheckExistanceOfProductCode())
        //                {
        //                    MessageBox.Show("Product code already exist", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        //                    this.txtProductCode.Focus();
        //                    this.txtProductCode.SelectAll();
        //                }
        //                else if (this.CheckExistanceOfProductName())
        //                {
        //                    MessageBox.Show("Product name already exist", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        //                    this.txtProductName.Focus();
        //                    this.txtProductName.SelectAll();
        //                }
        //                else if (!(this.btnSave.Text == "&Save"))
        //                {
        //                    this.ProductSP.ProductEdit(this.ProductInfo);
        //                    MessageBox.Show("Updated successfully", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        //                    frmGeneralSetting = new frmGeneralSettings();
        //                    item = Application.OpenForms["frmGeneralSettings"] as frmGeneralSettings;
        //                    if (item != null)
        //                    {
        //                        item.Fill();
        //                    }
        //                    this.clear();
        //                }
        //                else
        //                {
        //                    this.ProductSP.ProductAdd(this.ProductInfo);
        //                    this.ProductBatchSP.ProductBatchAdd(this.ProductBatchInfo);
        //                    MessageBox.Show("Saved successfully", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        //                    frmGeneralSetting = new frmGeneralSettings();
        //                    item = Application.OpenForms["frmGeneralSettings"] as frmGeneralSettings;
        //                    if (item != null)
        //                    {
        //                        item.Fill();
        //                    }
        //                    this.clear();
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception exception1)
        //    {
        //        Exception exception = exception1;
        //        MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        //    }
        //}
        private void frmGeneralSettings_Load(object sender, EventArgs e)
		{
			try
			{
				this.Fill();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void InitializeComponent()
		{
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel8 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbtnEx3 = new System.Windows.Forms.RadioButton();
            this.rbtnEx2 = new System.Windows.Forms.RadioButton();
            this.rbtnEx1 = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbtnStock3 = new System.Windows.Forms.RadioButton();
            this.rbtnStock2 = new System.Windows.Forms.RadioButton();
            this.rbtnstock1 = new System.Windows.Forms.RadioButton();
            this.gpbRegister = new System.Windows.Forms.GroupBox();
            this.cbLowStock = new System.Windows.Forms.CheckBox();
            this.gpbLimit = new System.Windows.Forms.GroupBox();
            this.cmbLimit = new System.Windows.Forms.ComboBox();
            this.txtLimit = new System.Windows.Forms.TextBox();
            this.cbExpiry = new System.Windows.Forms.CheckBox();
            this.cbProduct = new System.Windows.Forms.CheckBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel8.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gpbRegister.SuspendLayout();
            this.gpbLimit.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnReset);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.panel8);
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(7, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(651, 400);
            this.panel1.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(209)))), ((int)(((byte)(150)))));
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(1)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(407, 351);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(209)))), ((int)(((byte)(150)))));
            this.btnReset.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(1)))));
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Location = new System.Drawing.Point(488, 351);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 9;
            this.btnReset.Text = "&Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(209)))), ((int)(((byte)(150)))));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(1)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(569, 351);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panel8
            // 
            this.panel8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel8.Controls.Add(this.groupBox2);
            this.panel8.Controls.Add(this.groupBox1);
            this.panel8.Controls.Add(this.gpbRegister);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(1, 34);
            this.panel8.Name = "panel8";
            this.panel8.Padding = new System.Windows.Forms.Padding(5);
            this.panel8.Size = new System.Drawing.Size(649, 311);
            this.panel8.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.rbtnEx3);
            this.groupBox2.Controls.Add(this.rbtnEx2);
            this.groupBox2.Controls.Add(this.rbtnEx1);
            this.groupBox2.Location = new System.Drawing.Point(8, 206);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox2.Size = new System.Drawing.Size(633, 97);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Product Expiry Alert Status";
            // 
            // rbtnEx3
            // 
            this.rbtnEx3.AutoSize = true;
            this.rbtnEx3.Location = new System.Drawing.Point(8, 67);
            this.rbtnEx3.Name = "rbtnEx3";
            this.rbtnEx3.Size = new System.Drawing.Size(203, 17);
            this.rbtnEx3.TabIndex = 7;
            this.rbtnEx3.TabStop = true;
            this.rbtnEx3.Text = "Block Transaction Of Expired Product";
            this.rbtnEx3.UseVisualStyleBackColor = true;
            // 
            // rbtnEx2
            // 
            this.rbtnEx2.AutoSize = true;
            this.rbtnEx2.Location = new System.Drawing.Point(8, 44);
            this.rbtnEx2.Name = "rbtnEx2";
            this.rbtnEx2.Size = new System.Drawing.Size(76, 17);
            this.rbtnEx2.TabIndex = 6;
            this.rbtnEx2.TabStop = true;
            this.rbtnEx2.Text = "Warn User";
            this.rbtnEx2.UseVisualStyleBackColor = true;
            // 
            // rbtnEx1
            // 
            this.rbtnEx1.AutoSize = true;
            this.rbtnEx1.Location = new System.Drawing.Point(8, 21);
            this.rbtnEx1.Name = "rbtnEx1";
            this.rbtnEx1.Size = new System.Drawing.Size(173, 17);
            this.rbtnEx1.TabIndex = 5;
            this.rbtnEx1.TabStop = true;
            this.rbtnEx1.Text = "Ignore Product Expiry Condition";
            this.rbtnEx1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.rbtnStock3);
            this.groupBox1.Controls.Add(this.rbtnStock2);
            this.groupBox1.Controls.Add(this.rbtnstock1);
            this.groupBox1.Location = new System.Drawing.Point(8, 104);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox1.Size = new System.Drawing.Size(633, 97);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Negative Stock Alert Status";
            // 
            // rbtnStock3
            // 
            this.rbtnStock3.AutoSize = true;
            this.rbtnStock3.Location = new System.Drawing.Point(8, 67);
            this.rbtnStock3.Name = "rbtnStock3";
            this.rbtnStock3.Size = new System.Drawing.Size(229, 17);
            this.rbtnStock3.TabIndex = 4;
            this.rbtnStock3.TabStop = true;
            this.rbtnStock3.Text = "Block Transaction While Stock Is Negative";
            this.rbtnStock3.UseVisualStyleBackColor = true;
            // 
            // rbtnStock2
            // 
            this.rbtnStock2.AutoSize = true;
            this.rbtnStock2.Location = new System.Drawing.Point(8, 44);
            this.rbtnStock2.Name = "rbtnStock2";
            this.rbtnStock2.Size = new System.Drawing.Size(76, 17);
            this.rbtnStock2.TabIndex = 3;
            this.rbtnStock2.TabStop = true;
            this.rbtnStock2.Text = "Warn User";
            this.rbtnStock2.UseVisualStyleBackColor = true;
            // 
            // rbtnstock1
            // 
            this.rbtnstock1.AutoSize = true;
            this.rbtnstock1.Location = new System.Drawing.Point(8, 21);
            this.rbtnstock1.Name = "rbtnstock1";
            this.rbtnstock1.Size = new System.Drawing.Size(179, 17);
            this.rbtnstock1.TabIndex = 2;
            this.rbtnstock1.TabStop = true;
            this.rbtnstock1.Text = "Ignore Negative Stock Condition";
            this.rbtnstock1.UseVisualStyleBackColor = true;
            // 
            // gpbRegister
            // 
            this.gpbRegister.BackColor = System.Drawing.Color.Transparent;
            this.gpbRegister.Controls.Add(this.cbLowStock);
            this.gpbRegister.Controls.Add(this.gpbLimit);
            this.gpbRegister.Controls.Add(this.cbExpiry);
            this.gpbRegister.Controls.Add(this.cbProduct);
            this.gpbRegister.Location = new System.Drawing.Point(8, 8);
            this.gpbRegister.Name = "gpbRegister";
            this.gpbRegister.Padding = new System.Windows.Forms.Padding(5);
            this.gpbRegister.Size = new System.Drawing.Size(633, 90);
            this.gpbRegister.TabIndex = 0;
            this.gpbRegister.TabStop = false;
            // 
            // cbLowStock
            // 
            this.cbLowStock.AutoSize = true;
            this.cbLowStock.Location = new System.Drawing.Point(6, 65);
            this.cbLowStock.Name = "cbLowStock";
            this.cbLowStock.Size = new System.Drawing.Size(143, 17);
            this.cbLowStock.TabIndex = 14;
            this.cbLowStock.Text = "Reminder For Low Stock";
            this.cbLowStock.UseVisualStyleBackColor = true;
            // 
            // gpbLimit
            // 
            this.gpbLimit.BackColor = System.Drawing.Color.Transparent;
            this.gpbLimit.Controls.Add(this.cmbLimit);
            this.gpbLimit.Controls.Add(this.txtLimit);
            this.gpbLimit.Location = new System.Drawing.Point(250, 31);
            this.gpbLimit.Name = "gpbLimit";
            this.gpbLimit.Padding = new System.Windows.Forms.Padding(5);
            this.gpbLimit.Size = new System.Drawing.Size(149, 40);
            this.gpbLimit.TabIndex = 13;
            this.gpbLimit.TabStop = false;
            // 
            // cmbLimit
            // 
            this.cmbLimit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLimit.FormattingEnabled = true;
            this.cmbLimit.Items.AddRange(new object[] {
            "Days",
            "Months",
            "Year"});
            this.cmbLimit.Location = new System.Drawing.Point(68, 11);
            this.cmbLimit.Name = "cmbLimit";
            this.cmbLimit.Size = new System.Drawing.Size(73, 21);
            this.cmbLimit.TabIndex = 11;
            this.cmbLimit.TabStop = false;
            this.cmbLimit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbLimit_KeyDown);
            // 
            // txtLimit
            // 
            this.txtLimit.Location = new System.Drawing.Point(9, 12);
            this.txtLimit.MaxLength = 2;
            this.txtLimit.Name = "txtLimit";
            this.txtLimit.Size = new System.Drawing.Size(55, 20);
            this.txtLimit.TabIndex = 12;
            this.txtLimit.TabStop = false;
            this.txtLimit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLimit_KeyPress);
            this.txtLimit.Leave += new System.EventHandler(this.txtLimit_Leave);
            // 
            // cbExpiry
            // 
            this.cbExpiry.AutoSize = true;
            this.cbExpiry.Location = new System.Drawing.Point(6, 44);
            this.cbExpiry.Name = "cbExpiry";
            this.cbExpiry.Size = new System.Drawing.Size(222, 17);
            this.cbExpiry.TabIndex = 1;
            this.cbExpiry.Text = "Reminder For Products That Will Expire in";
            this.cbExpiry.UseVisualStyleBackColor = true;
            this.cbExpiry.CheckedChanged += new System.EventHandler(this.cbExpiry_CheckedChanged);
            // 
            // cbProduct
            // 
            this.cbProduct.AutoSize = true;
            this.cbProduct.Location = new System.Drawing.Point(6, 21);
            this.cbProduct.Name = "cbProduct";
            this.cbProduct.Size = new System.Drawing.Size(171, 17);
            this.cbProduct.TabIndex = 0;
            this.cbProduct.Text = "Auto Product Code Generation";
            this.cbProduct.UseVisualStyleBackColor = true;
            this.cbProduct.CheckedChanged += new System.EventHandler(this.cbProduct_CheckedChanged);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.label1);
            this.panel6.Controls.Add(this.panel7);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(1, 1);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(649, 33);
            this.panel6.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "General Settings";
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            this.panel7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel7.Location = new System.Drawing.Point(0, 32);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(649, 1);
            this.panel7.TabIndex = 3;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(1, 399);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(649, 1);
            this.panel5.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(1, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(649, 1);
            this.panel4.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(650, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1, 400);
            this.panel3.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1, 400);
            this.panel2.TabIndex = 0;
            // 
            // frmGeneralSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(665, 414);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "frmGeneralSettings";
            this.Padding = new System.Windows.Forms.Padding(7);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "General Settings";
            this.Load += new System.EventHandler(this.frmGeneralSettings_Load);
            this.panel1.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gpbRegister.ResumeLayout(false);
            this.gpbRegister.PerformLayout();
            this.gpbLimit.ResumeLayout(false);
            this.gpbLimit.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);

		}

		private void txtLimit_KeyPress(object sender, KeyPressEventArgs e)
		{
			try
			{
				if ((e.KeyChar <= '/' || e.KeyChar >= ':' ? e.KeyChar != '\b' : false))
				{
					e.Handled = true;
				}
				else
				{
					e.Handled = false;
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void txtLimit_Leave(object sender, EventArgs e)
		{
			try
			{
				int.Parse(this.txtLimit.Text);
			}
			catch (Exception exception)
			{
				if (this.gpbLimit.Enabled)
				{
					this.txtLimit.Text = "1";
				}
			}
		}

        private void cbProduct_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}