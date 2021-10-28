using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Resources;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MedicalShop
{
	public class frmVendor : Form
	{
        private VendorSP vendersp = new VendorSP();
        private VendorInfo venderinfo = new VendorInfo();
		private IContainer components = null;
        private Boolean isAutoGenerate = true;

        private Panel panel1;

		private Button btnSave;

		private Button btnDelete;

		private Button btnClear;

		private Button btnClose;

		private Panel panel8;

		private Label label5;

		private TextBox txtDescription;

		private TextBox txtState;

		private TextBox txtPincode;

		private TextBox txtAddress;

		private Label label8;

		private Label label7;

		private GroupBox gpbRegister;

		private Label label4;

		private Label label3;

		private TextBox txtVendorName;

		private Label label2;

		private Panel panel6;

		private Label label1;

		private Panel panel7;

		private Panel panel5;

		private Panel panel4;

		private Panel panel3;

		private Panel panel2;

		private ComboBox cmbCountry;

		private Label label12;

		private ComboBox cmbDebitOrCredit;

		private TextBox txtOpeningBalance;

		private Label label11;

		private Label label10;

		private TextBox txtMobile;

		private TextBox txtPhone;

		private Label label13;

		private Label label14;

		private TextBox txtEmail;

		private Panel pnlRegister;

		private DataGridView dgvVendors;

		private TextBox txtSearch;

		private Label label6;

		private DataGridViewTextBoxColumn ID;

		private DataGridViewTextBoxColumn VendorName;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;

		private VendorSP vendorsp = new VendorSP();

		private bool isFormClose = false;

		private bool isInEditMode = false;

		private bool isFromPurchaseInvoice = false;

		private string strVendorIdForEdit = "";

		private string strVendorIdForOtherForms = "";

		private string strVendorName = "";

		private string strLedgerId = "";

		private int inDescriptionCount = 0;

		private int inAddressCount = 0;

		private bool isFromOtherForms = false;

		public frmVendor()
		{
			this.InitializeComponent();
		}

		private void btnClear_Click(object sender, EventArgs e)
		{
			try
			{
				this.ClearFunction();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
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

		private void btnDelete_Click(object sender, EventArgs e)
		{
			try
			{

                vendersp.VendorDelete(this.strVendorIdForEdit);
                MessageBox.Show("Deleted successfully", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                ClearFunction();
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

                saveOrEditDetails();

            }
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		public void ClearFunction()
		{
			try
			{
				this.txtAddress.Clear();
				this.txtDescription.Clear();
				this.txtVendorName.Clear();
				this.txtPincode.Clear();
				this.txtPhone.Clear();
				this.txtEmail.Clear();
				this.txtState.Clear();
				this.txtMobile.Clear();
				this.txtSearch.Clear();
				this.FillVendorGrid();
				this.btnSave.Text = "&Save";
				this.btnClear.Text = "C&lear";
				this.strVendorIdForEdit = "";
				this.strVendorIdForOtherForms = "";
				this.strVendorName = "";
				this.strLedgerId = "";
				this.txtOpeningBalance.Text = "0.00";
				this.cmbDebitOrCredit.Text = "Dr";
				this.cmbCountry.Text = "India";
				this.isInEditMode = false;
				this.btnDelete.Enabled = false;
				this.txtVendorName.Focus();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void cmbCountry_KeyPress(object sender, KeyPressEventArgs e)
		{
			try
			{
				if (e.KeyChar == '\r')
				{
					this.txtState.Focus();
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void cmbDebitOrCredit_KeyDown(object sender, KeyEventArgs e)
		{
			this.DropDownComboOrDateTimePicker(e);
		}

		private void cmbDebitOrCredit_KeyPress(object sender, KeyPressEventArgs e)
		{
			try
			{
				if (e.KeyChar == '\r')
				{
					string str = this.txtDescription.Text.Trim();
					if (!(str == ""))
					{
						this.txtDescription.SelectionStart = str.Length;
						this.txtDescription.Focus();
					}
					else
					{
						this.txtDescription.SelectionStart = 0;
						this.txtDescription.Focus();
					}
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void cmbGroupUnder_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				this.DropDownComboOrDateTimePicker(e);
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void cmbGroupUnder_KeyPress(object sender, KeyPressEventArgs e)
		{
			try
			{
				if (e.KeyChar == '\r')
				{
					this.txtOpeningBalance.Focus();
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void cmbSearchBy_KeyDown(object sender, KeyEventArgs e)
		{
			this.DropDownComboOrDateTimePicker(e);
		}

		private void dgvVendors_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				if (this.dgvVendors.CurrentRow != null)
				{
					if ((this.dgvVendors.Rows.Count <= 0 ? false : e.ColumnIndex > -1))
					{
						if (this.dgvVendors.CurrentRow.Cells[0].Value != null)
						{
							if (this.dgvVendors.CurrentRow.Cells[0].Value.ToString() != "")
							{
								this.strVendorIdForEdit = this.dgvVendors.CurrentRow.Cells[0].Value.ToString();
								this.strVendorName = this.dgvVendors.CurrentRow.Cells[1].Value.ToString();
								this.FillControlsForEdit();
								this.dgvVendors.CurrentRow.Selected = true;
							}
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

		private void dgvVendors_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			try
			{
				DataGridViewCellEventArgs dataGridViewCellEventArg = new DataGridViewCellEventArgs(e.ColumnIndex, e.RowIndex);
				this.dgvVendors_CellClick(sender, dataGridViewCellEventArg);
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void dgvVendors_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
		{
			((DataGridView)sender).ClearSelection();
		}

		private void dgvVendors_KeyUp(object sender, KeyEventArgs e)
		{
			try
			{
				if ((e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Return ? true : e.KeyCode == Keys.Tab))
				{
					if (this.dgvVendors.CurrentRow != null)
					{
						DataGridViewCellEventArgs dataGridViewCellEventArg = new DataGridViewCellEventArgs(this.dgvVendors.CurrentCell.ColumnIndex, this.dgvVendors.CurrentCell.RowIndex);
						this.dgvVendors_CellClick(sender, dataGridViewCellEventArg);
					}
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

		public void DropDownComboOrDateTimePicker(KeyEventArgs e)
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

		public void FillControlsForEdit()
		{
			try
			{
				VendorInfo vendorInfo = new VendorInfo();
				AccountLedgerInfo accountLedgerInfo = new AccountLedgerInfo();
				AccountLedgerSP accountLedgerSP = new AccountLedgerSP();
				vendorInfo = this.vendorsp.VendorView(this.strVendorIdForEdit);
				this.txtVendorName.Text = vendorInfo.VendorName;
				this.txtAddress.Text = vendorInfo.Address;
				this.txtPincode.Text = vendorInfo.PinCode;
				this.cmbCountry.Text = vendorInfo.Country;
				this.txtState.Text = vendorInfo.State;
				this.txtPhone.Text = vendorInfo.PhoneNumber;
				this.txtMobile.Text = vendorInfo.MobileNumber;
				this.txtEmail.Text = vendorInfo.EmailId;
				this.txtDescription.Text = vendorInfo.Description;
				this.strLedgerId = vendorInfo.LedgerId;
				accountLedgerInfo = accountLedgerSP.AccountLedgerView(this.strLedgerId);
				string str = accountLedgerInfo.OpeningBalance.ToString();
				if (!(str != "0.0000"))
				{
					this.txtOpeningBalance.Text = "0.0";
				}
				else
				{
					this.txtOpeningBalance.Text = double.Parse(str).ToString();
				}
				if (!accountLedgerInfo.DebitOrCredit)
				{
					this.cmbDebitOrCredit.Text = "Cr";
				}
				else
				{
					this.cmbDebitOrCredit.Text = "Dr";
				}
				this.btnDelete.Enabled = true;
				this.btnClear.Text = "&New";
				this.btnSave.Text = "&Update";
				this.isInEditMode = true;
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		public void FillVendorGrid()
		{
			DataRow row = null;
			try
			{
				DataTable dataTable = new DataTable();
				dataTable = this.vendorsp.VendorViewAll();
				this.dgvVendors.Rows.Clear();
				int str = 0;
				foreach (DataRow row1 in dataTable.Rows)
				{
					if (!(row1.ItemArray[0].ToString() == "0"))
					{
						str++;
					}
					else
					{
						dataTable.Rows.RemoveAt(str);
						break;
					}
				}
				str = 0;
				foreach (DataRow dataRow in dataTable.Rows)
				{
					this.dgvVendors.Rows.Add();
					this.dgvVendors.Rows[str].Cells[0].Value = dataRow.ItemArray[0].ToString();
					this.dgvVendors.Rows[str].Cells[1].Value = dataRow.ItemArray[1].ToString();
					str++;
				}
				this.dgvVendors.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
				this.dgvVendors.ClearSelection();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void frmVendor_FormClosing(object sender, FormClosingEventArgs e)
		{
			try
			{
				this.isFormClose = true;
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void frmVendor_Load(object sender, EventArgs e)
		{
			try
			{
				this.ClearFunction();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void InitializeComponent()
		{
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmVendor));
			this.panel1 = new Panel();
			this.btnSave = new Button();
			this.btnDelete = new Button();
			this.btnClear = new Button();
			this.btnClose = new Button();
			this.panel8 = new Panel();
			this.label14 = new Label();
			this.txtEmail = new TextBox();
			this.label13 = new Label();
			this.label12 = new Label();
			this.cmbDebitOrCredit = new ComboBox();
			this.txtOpeningBalance = new TextBox();
			this.label11 = new Label();
			this.label10 = new Label();
			this.txtMobile = new TextBox();
			this.txtPhone = new TextBox();
			this.cmbCountry = new ComboBox();
			this.label5 = new Label();
			this.txtDescription = new TextBox();
			this.txtState = new TextBox();
			this.txtPincode = new TextBox();
			this.txtAddress = new TextBox();
			this.label8 = new Label();
			this.label7 = new Label();
			this.gpbRegister = new GroupBox();
			this.pnlRegister = new Panel();
			this.dgvVendors = new DataGridView();
			this.ID = new DataGridViewTextBoxColumn();
			this.VendorName = new DataGridViewTextBoxColumn();
			this.txtSearch = new TextBox();
			this.label6 = new Label();
			this.label4 = new Label();
			this.label3 = new Label();
			this.txtVendorName = new TextBox();
			this.label2 = new Label();
			this.panel6 = new Panel();
			this.label1 = new Label();
			this.panel7 = new Panel();
			this.panel5 = new Panel();
			this.panel4 = new Panel();
			this.panel3 = new Panel();
			this.panel2 = new Panel();
			this.dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
			this.panel1.SuspendLayout();
			this.panel8.SuspendLayout();
			this.gpbRegister.SuspendLayout();
			this.pnlRegister.SuspendLayout();
			((ISupportInitialize)this.dgvVendors).BeginInit();
			this.panel6.SuspendLayout();
			base.SuspendLayout();
			this.panel1.BackColor = Color.Transparent;
			this.panel1.BackgroundImage = (Image)componentResourceManager.GetObject("panel1.BackgroundImage");
			this.panel1.BackgroundImageLayout = ImageLayout.Stretch;
			this.panel1.Controls.Add(this.btnSave);
			this.panel1.Controls.Add(this.btnDelete);
			this.panel1.Controls.Add(this.btnClear);
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
			this.panel1.Size = new System.Drawing.Size(650, 440);
			this.panel1.TabIndex = 1;
			this.btnSave.BackColor = Color.FromArgb(255, 209, 150);
			this.btnSave.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 1);
			this.btnSave.FlatStyle = FlatStyle.Flat;
			this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.btnSave.Location = new Point(324, 386);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(75, 23);
			this.btnSave.TabIndex = 11;
			this.btnSave.Text = "&Save";
			this.btnSave.UseVisualStyleBackColor = false;
			this.btnSave.Click += new EventHandler(this.btnSave_Click);
			this.btnDelete.BackColor = Color.FromArgb(255, 209, 150);
			this.btnDelete.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 1);
			this.btnDelete.FlatStyle = FlatStyle.Flat;
			this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.btnDelete.Location = new Point(405, 386);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(75, 23);
			this.btnDelete.TabIndex = 12;
			this.btnDelete.Text = "&Delete";
			this.btnDelete.UseVisualStyleBackColor = false;
			this.btnDelete.Click += new EventHandler(this.btnDelete_Click);
			this.btnClear.BackColor = Color.FromArgb(255, 209, 150);
			this.btnClear.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 1);
			this.btnClear.FlatStyle = FlatStyle.Flat;
			this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.btnClear.Location = new Point(486, 386);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(75, 23);
			this.btnClear.TabIndex = 13;
			this.btnClear.Text = "C&lear";
			this.btnClear.UseVisualStyleBackColor = false;
			this.btnClear.Click += new EventHandler(this.btnClear_Click);
			this.btnClose.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnClose.BackColor = Color.FromArgb(255, 209, 150);
			this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnClose.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 1);
			this.btnClose.FlatStyle = FlatStyle.Flat;
			this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.btnClose.Location = new Point(567, 386);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(75, 23);
			this.btnClose.TabIndex = 14;
			this.btnClose.Text = "&Close";
			this.btnClose.UseVisualStyleBackColor = false;
			this.btnClose.Click += new EventHandler(this.btnClose_Click);
			this.panel8.BackgroundImage = (Image)componentResourceManager.GetObject("panel8.BackgroundImage");
			this.panel8.BackgroundImageLayout = ImageLayout.Stretch;
			this.panel8.Controls.Add(this.label14);
			this.panel8.Controls.Add(this.txtEmail);
			this.panel8.Controls.Add(this.label13);
			this.panel8.Controls.Add(this.label12);
			this.panel8.Controls.Add(this.cmbDebitOrCredit);
			this.panel8.Controls.Add(this.txtOpeningBalance);
			this.panel8.Controls.Add(this.label11);
			this.panel8.Controls.Add(this.label10);
			this.panel8.Controls.Add(this.txtMobile);
			this.panel8.Controls.Add(this.txtPhone);
			this.panel8.Controls.Add(this.cmbCountry);
			this.panel8.Controls.Add(this.label5);
			this.panel8.Controls.Add(this.txtDescription);
			this.panel8.Controls.Add(this.txtState);
			this.panel8.Controls.Add(this.txtPincode);
			this.panel8.Controls.Add(this.txtAddress);
			this.panel8.Controls.Add(this.label8);
			this.panel8.Controls.Add(this.label7);
			this.panel8.Controls.Add(this.gpbRegister);
			this.panel8.Controls.Add(this.label4);
			this.panel8.Controls.Add(this.label3);
			this.panel8.Controls.Add(this.txtVendorName);
			this.panel8.Controls.Add(this.label2);
			this.panel8.Dock = DockStyle.Top;
			this.panel8.Location = new Point(1, 34);
			this.panel8.Name = "panel8";
			this.panel8.Padding = new System.Windows.Forms.Padding(5);
			this.panel8.Size = new System.Drawing.Size(648, 346);
			this.panel8.TabIndex = 0;
			this.label14.AutoSize = true;
			this.label14.Location = new Point(11, 237);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(35, 13);
			this.label14.TabIndex = 32;
			this.label14.Text = "Email:";
			this.txtEmail.Location = new Point(134, 230);
			this.txtEmail.MaxLength = 50;
			this.txtEmail.Name = "txtEmail";
			this.txtEmail.Size = new System.Drawing.Size(232, 20);
			this.txtEmail.TabIndex = 7;
			this.txtEmail.KeyPress += new KeyPressEventHandler(this.txtEmail_KeyPress);
			this.label13.AutoSize = true;
			this.label13.Location = new Point(11, 288);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(63, 13);
			this.label13.TabIndex = 29;
			this.label13.Text = "Description:";
			this.label12.AutoSize = true;
			this.label12.Location = new Point(11, 266);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(89, 13);
			this.label12.TabIndex = 27;
			this.label12.Text = "Opening Balance";
			this.cmbDebitOrCredit.DropDownStyle = ComboBoxStyle.DropDownList;
			this.cmbDebitOrCredit.FormattingEnabled = true;
			ComboBox.ObjectCollection items = this.cmbDebitOrCredit.Items;
			object[] objArray = new object[] { "Dr", "Cr" };
			items.AddRange(objArray);
			this.cmbDebitOrCredit.Location = new Point(301, 259);
			this.cmbDebitOrCredit.Name = "cmbDebitOrCredit";
			this.cmbDebitOrCredit.Size = new System.Drawing.Size(65, 21);
			this.cmbDebitOrCredit.TabIndex = 9;
			this.cmbDebitOrCredit.KeyPress += new KeyPressEventHandler(this.cmbDebitOrCredit_KeyPress);
			this.cmbDebitOrCredit.KeyDown += new KeyEventHandler(this.cmbDebitOrCredit_KeyDown);
			this.txtOpeningBalance.Location = new Point(134, 259);
			this.txtOpeningBalance.MaxLength = 8;
			this.txtOpeningBalance.Name = "txtOpeningBalance";
			this.txtOpeningBalance.Size = new System.Drawing.Size(161, 20);
			this.txtOpeningBalance.TabIndex = 8;
			this.txtOpeningBalance.Enter += new EventHandler(this.txtOpeningBalance_Enter);
			this.txtOpeningBalance.Leave += new EventHandler(this.txtOpeningBalance_Leave);
			this.txtOpeningBalance.KeyPress += new KeyPressEventHandler(this.txtOpeningBalance_KeyPress);
			this.label11.AutoSize = true;
			this.label11.Location = new Point(11, 209);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(41, 13);
			this.label11.TabIndex = 23;
			this.label11.Text = "Mobile:";
			this.label10.AutoSize = true;
			this.label10.Location = new Point(11, 183);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(41, 13);
			this.label10.TabIndex = 22;
			this.label10.Text = "Phone:";
			this.txtMobile.Location = new Point(134, 202);
			this.txtMobile.MaxLength = 15;
			this.txtMobile.Name = "txtMobile";
			this.txtMobile.Size = new System.Drawing.Size(232, 20);
			this.txtMobile.TabIndex = 6;
			this.txtMobile.KeyPress += new KeyPressEventHandler(this.txtMobile_KeyPress);
			this.txtPhone.Location = new Point(134, 176);
			this.txtPhone.MaxLength = 15;
			this.txtPhone.Name = "txtPhone";
			this.txtPhone.Size = new System.Drawing.Size(232, 20);
			this.txtPhone.TabIndex = 5;
			this.txtPhone.KeyPress += new KeyPressEventHandler(this.txtPhone_KeyPress);
			this.cmbCountry.DropDownStyle = ComboBoxStyle.DropDownList;
			this.cmbCountry.FormattingEnabled = true;
			ComboBox.ObjectCollection objectCollections = this.cmbCountry.Items;
			objArray = new object[] { "Afghanistan", "Albania", "Algeria", "American Samoa", "Andorra", "Angola", "Anguilla", "Antigua and Barbuda", "Argentina", "Armenia", "Aruba", "Australia", "Austria", "Azerbajan", "Bahamas", "Bahrain", "Bangladesh", "Barbados", "Belarus", "Belgium", "Belize", "Benin", "Bermuda", "Bhutan", "Bolivia", "Bosnia and Herzegowina", "Botswana", "Brazil", "Brunei Darussalam", "Bulgaria", "Burkina Faso", "Burundi", "Cambodia", "Cameroon", "Canada", "Cape Verde", "Cayman Islands", "Central African Republic", "Chad", "Chile", "China", "Colombia", "Comoros", "Congo", "Cook Islands", "Costa Rica", "Cuba", "Cyprus", "Czech Republic", "Democratic Republic Kongo", "Denmark", "Djibouti", "Dominica", "Dominican Republic", "East Timor", "Ecuador", "Egypt", "El Salvador", "Equatorial Guinea", "Eritrea", "Estonia", "Ethiopia", "Faroe Islands", "Fiji", "Finland", "France", "French Guayana", "French Polynesia", "Gabon", "Gambia", "Georgia - Sakartvelo", "Germany", "Ghana", "Greece", "Greenland - Kalaallit Nunaat", "Grenada", "Guadeloupe", "Guam", "Guatemala", "Guernsey", "Guinea", "Guinea-Bissau", "Guyana", "Guyane", "Haiti", "Honduras", "Hong Kong", "Hrvatska (Croatia)", "Hungary", "Iceland", "India", "Indonesia", "Iran", "Iraq", "Ireland", "Islands", "Israel", "Italy", "Ivory Coast", "Jamaica", "Japan", "Jordan", "Kazakhstan", "Kenya", "Kiribati", "Korea - Democratic People´s Republic", "Korea - Republic", "Kosova", "Kuwait", "Kyrgyzstan", "Laos", "Latvia", "Lebanon", "Lesotho", "Liberia", "Libyan Arab Jamahiriya", "Liechtenstein", "Lithuania", "Luxembourg", "Macau", "Macedonia (FYROM)", "Madagascar", "Malawi", "Malaysia", "Mali", "Malta", "Marshall Islands", "Martinique", "Mauritania", "Mauritius", "Mayotte", "Mexico", "Micronesia", "Moldova", "Monaco", "Mongolia", "Montserrat", "Morocco", "Mozambique", "Myanmar (Burma)", "Namibia", "Nauru", "Nepal", "Netherlands", "Netherlands Antilles", "New Caledonia", "New Zealand", "Nicaragua", "Niger", "Nigeria", "Niue", "Norfolk Island", "Northern Mariana Islands", "Norway", "Oman", "Pakistan", "Palau", "Palestina", "Panama", "Papau New Guinea", "Paraguay", "Peru", "Philippines", "Pitcairn", "Poland", "Portugal", "Puerto Rico", "Qatar", "Reunion", "Romania", "Russian Federation (Asian Region)", "Russian Federation (European Region)", "Rwanda", "Saint Kitts and Nevis", "Saint Lucia", "Saint Vincent and the Grenadines", "Samoa (American Samoa)", "Samoa (Western Samoa)", "San Marino", "Saudi Arabia", "Senegal", "Seychelles", "Sierra Leone", "Singapore", "Slovakia", "Slovenia", "Solomon Islands", "Somalia", "Somaliland", "South Africa", "Spain", "Sri Lanka", "St. Helena", "Sudan", "Suriname", "Svalbard and Jan Mayen", "Swaziland", "Sweden", "Switzerland", "Syrian Arab Republic", "Taiwan", "Tajikistan", "Tanzania", "Thailand", "Tibet", "Togo", "Tonga", "Trinidad and Tobago", "Tunisia", "Turkey", "Turkmenistan", "Turks and Caicos Islands", "Tuvalu", "Uganda", "Ukraine", "United Arab Emirates", "United Kingdom", "Uruguay", "USA", "Uzbekistan", "Vanuatu", "Vatican City State - Holy See", "Venezuela", "Vietnam", "Virgin Islands (British)", "Virgin Islands (U.S.)", "Wallis and Futuna", "Western Sahara", "Yemen", "Yugoslavia", "Zambia", "Zimbabwe" };
			objectCollections.AddRange(objArray);
			this.cmbCountry.Location = new Point(134, 123);
			this.cmbCountry.Name = "cmbCountry";
			this.cmbCountry.Size = new System.Drawing.Size(232, 21);
			this.cmbCountry.TabIndex = 3;
			this.cmbCountry.KeyPress += new KeyPressEventHandler(this.cmbCountry_KeyPress);
			this.cmbCountry.KeyDown += new KeyEventHandler(this.cmbGroupUnder_KeyDown);
			this.label5.AutoSize = true;
			this.label5.Location = new Point(11, 157);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(35, 13);
			this.label5.TabIndex = 18;
			this.label5.Text = "State:";
			this.txtDescription.Location = new Point(134, 285);
			this.txtDescription.Multiline = true;
			this.txtDescription.Name = "txtDescription";
			this.txtDescription.Size = new System.Drawing.Size(232, 55);
			this.txtDescription.TabIndex = 10;
			this.txtDescription.Enter += new EventHandler(this.txtDescription_Enter);
			this.txtDescription.KeyPress += new KeyPressEventHandler(this.txtDescription_KeyPress);
			this.txtState.Location = new Point(134, 150);
			this.txtState.MaxLength = 50;
			this.txtState.Name = "txtState";
			this.txtState.Size = new System.Drawing.Size(232, 20);
			this.txtState.TabIndex = 4;
			this.txtState.KeyPress += new KeyPressEventHandler(this.txtState_KeyPress);
			this.txtPincode.Location = new Point(134, 97);
			this.txtPincode.MaxLength = 15;
			this.txtPincode.Name = "txtPincode";
			this.txtPincode.Size = new System.Drawing.Size(232, 20);
			this.txtPincode.TabIndex = 2;
			this.txtPincode.KeyPress += new KeyPressEventHandler(this.txtPincode_KeyPress);
			this.txtAddress.Location = new Point(134, 36);
			this.txtAddress.Multiline = true;
			this.txtAddress.Name = "txtAddress";
			this.txtAddress.Size = new System.Drawing.Size(232, 55);
			this.txtAddress.TabIndex = 1;
			this.txtAddress.Enter += new EventHandler(this.txtAddress_Enter);
			this.txtAddress.KeyUp += new KeyEventHandler(this.txtAddress_KeyUp);
			this.txtAddress.KeyPress += new KeyPressEventHandler(this.txtAddress_KeyPress);
			this.label8.AutoSize = true;
			this.label8.Location = new Point(11, 104);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(49, 13);
			this.label8.TabIndex = 13;
			this.label8.Text = "Pincode:";
			this.label7.AutoSize = true;
			this.label7.Location = new Point(11, 131);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(46, 13);
			this.label7.TabIndex = 12;
			this.label7.Text = "Country:";
			this.gpbRegister.BackColor = Color.White;
			this.gpbRegister.Controls.Add(this.pnlRegister);
			this.gpbRegister.Location = new Point(390, 8);
			this.gpbRegister.Name = "gpbRegister";
			this.gpbRegister.Padding = new System.Windows.Forms.Padding(5);
			this.gpbRegister.Size = new System.Drawing.Size(251, 330);
			this.gpbRegister.TabIndex = 7;
			this.gpbRegister.TabStop = false;
			this.gpbRegister.Text = "Register";
			this.pnlRegister.Controls.Add(this.dgvVendors);
			this.pnlRegister.Controls.Add(this.txtSearch);
			this.pnlRegister.Controls.Add(this.label6);
			this.pnlRegister.Dock = DockStyle.Fill;
			this.pnlRegister.Location = new Point(5, 18);
			this.pnlRegister.Name = "pnlRegister";
			this.pnlRegister.Size = new System.Drawing.Size(241, 307);
			this.pnlRegister.TabIndex = 0;
			this.dgvVendors.AllowUserToAddRows = false;
			this.dgvVendors.AllowUserToDeleteRows = false;
			this.dgvVendors.AllowUserToResizeColumns = false;
			this.dgvVendors.AllowUserToResizeRows = false;
			this.dgvVendors.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvVendors.BackgroundColor = Color.White;
			this.dgvVendors.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			DataGridViewColumnCollection columns = this.dgvVendors.Columns;
			DataGridViewColumn[] d = new DataGridViewColumn[] { this.ID, this.VendorName };
			columns.AddRange(d);
			this.dgvVendors.GridColor = Color.WhiteSmoke;
			this.dgvVendors.Location = new Point(9, 34);
			this.dgvVendors.MultiSelect = false;
			this.dgvVendors.Name = "dgvVendors";
			this.dgvVendors.ReadOnly = true;
			this.dgvVendors.RowHeadersVisible = false;
			this.dgvVendors.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			this.dgvVendors.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			this.dgvVendors.Size = new System.Drawing.Size(225, 270);
			this.dgvVendors.TabIndex = 19;
			this.dgvVendors.TabStop = false;
			this.dgvVendors.CellClick += new DataGridViewCellEventHandler(this.dgvVendors_CellClick);
			this.dgvVendors.ColumnHeaderMouseClick += new DataGridViewCellMouseEventHandler(this.dgvVendors_ColumnHeaderMouseClick);
			this.dgvVendors.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(this.dgvVendors_DataBindingComplete);
			this.dgvVendors.KeyUp += new KeyEventHandler(this.dgvVendors_KeyUp);
			this.ID.DataPropertyName = "VendorId";
			this.ID.HeaderText = "Vendor Id";
			this.ID.Name = "ID";
			this.ID.ReadOnly = true;
			this.ID.Resizable = DataGridViewTriState.False;
			this.ID.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.ID.Visible = false;
			this.VendorName.DataPropertyName = "Vendor Name";
			this.VendorName.HeaderText = "Vendor Name";
			this.VendorName.Name = "VendorName";
			this.VendorName.ReadOnly = true;
			this.VendorName.Resizable = DataGridViewTriState.False;
			this.VendorName.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.txtSearch.Location = new Point(77, 8);
			this.txtSearch.MaxLength = 50;
			this.txtSearch.Name = "txtSearch";
			this.txtSearch.Size = new System.Drawing.Size(142, 20);
			this.txtSearch.TabIndex = 18;
			this.txtSearch.TabStop = false;
			this.txtSearch.TextChanged += new EventHandler(this.txtSearch_TextChanged);
			this.label6.AutoSize = true;
			this.label6.Location = new Point(6, 15);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(62, 13);
			this.label6.TabIndex = 17;
			this.label6.Text = "Search For:";
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label4.ForeColor = Color.Red;
			this.label4.Location = new Point(372, 13);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(12, 13);
			this.label4.TabIndex = 5;
			this.label4.Text = "*";
			this.label3.AutoSize = true;
			this.label3.Location = new Point(8, 44);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(48, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "Address:";
			this.txtVendorName.Location = new Point(134, 10);
			this.txtVendorName.MaxLength = 50;
			this.txtVendorName.Name = "txtVendorName";
			this.txtVendorName.Size = new System.Drawing.Size(232, 20);
			this.txtVendorName.TabIndex = 0;
			this.txtVendorName.Leave += new EventHandler(this.txtVendorName_Leave);
			this.txtVendorName.KeyPress += new KeyPressEventHandler(this.txtVendorName_KeyPress);
			this.label2.AutoSize = true;
			this.label2.Location = new Point(8, 17);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(75, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Vendor Name:";
			this.panel6.BackgroundImage = (Image)componentResourceManager.GetObject("panel6.BackgroundImage");
			this.panel6.Controls.Add(this.label1);
			this.panel6.Controls.Add(this.panel7);
			this.panel6.Dock = DockStyle.Top;
			this.panel6.Location = new Point(1, 1);
			this.panel6.Name = "panel6";
			this.panel6.Size = new System.Drawing.Size(648, 33);
			this.panel6.TabIndex = 3;
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label1.Location = new Point(11, 7);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(52, 15);
			this.label1.TabIndex = 4;
			this.label1.Text = "Vendor";
			this.panel7.BackColor = Color.FromArgb(136, 136, 136);
			this.panel7.Dock = DockStyle.Bottom;
			this.panel7.Location = new Point(0, 32);
			this.panel7.Name = "panel7";
			this.panel7.Size = new System.Drawing.Size(648, 1);
			this.panel7.TabIndex = 3;
			this.panel5.BackColor = Color.FromArgb(136, 136, 136);
			this.panel5.Dock = DockStyle.Bottom;
			this.panel5.Location = new Point(1, 439);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(648, 1);
			this.panel5.TabIndex = 2;
			this.panel4.BackColor = Color.FromArgb(136, 136, 136);
			this.panel4.Dock = DockStyle.Top;
			this.panel4.Location = new Point(1, 0);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(648, 1);
			this.panel4.TabIndex = 1;
			this.panel3.BackColor = Color.FromArgb(136, 136, 136);
			this.panel3.Dock = DockStyle.Right;
			this.panel3.Location = new Point(649, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(1, 440);
			this.panel3.TabIndex = 1;
			this.panel2.BackColor = Color.FromArgb(136, 136, 136);
			this.panel2.Dock = DockStyle.Left;
			this.panel2.Location = new Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(1, 440);
			this.panel2.TabIndex = 0;
			this.dataGridViewTextBoxColumn1.DataPropertyName = "VendorId";
			this.dataGridViewTextBoxColumn1.HeaderText = "Vendor Id";
			this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn1.ReadOnly = true;
			this.dataGridViewTextBoxColumn1.Resizable = DataGridViewTriState.False;
			this.dataGridViewTextBoxColumn1.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.dataGridViewTextBoxColumn1.Visible = false;
			this.dataGridViewTextBoxColumn2.DataPropertyName = "Vendor Name";
			this.dataGridViewTextBoxColumn2.HeaderText = "Vendor Name";
			this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
			this.dataGridViewTextBoxColumn2.ReadOnly = true;
			this.dataGridViewTextBoxColumn2.Resizable = DataGridViewTriState.False;
			this.dataGridViewTextBoxColumn2.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.dataGridViewTextBoxColumn2.Width = 222;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.BackColor = Color.White;
			base.CancelButton = this.btnClose;
			base.ClientSize = new System.Drawing.Size(664, 454);
			base.Controls.Add(this.panel1);
			base.Icon = (System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.Name = "frmVendor";
			base.Padding = new System.Windows.Forms.Padding(7);
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "Vendor";
			base.FormClosing += new FormClosingEventHandler(this.frmVendor_FormClosing);
			base.Load += new EventHandler(this.frmVendor_Load);
			this.panel1.ResumeLayout(false);
			this.panel8.ResumeLayout(false);
			this.panel8.PerformLayout();
			this.gpbRegister.ResumeLayout(false);
			this.pnlRegister.ResumeLayout(false);
			this.pnlRegister.PerformLayout();
			((ISupportInitialize)this.dgvVendors).EndInit();
			this.panel6.ResumeLayout(false);
			this.panel6.PerformLayout();
			base.ResumeLayout(false);
		}

		private void txtAddress_Enter(object sender, EventArgs e)
		{
			try
			{
				this.txtAddress.Text = this.txtAddress.Text.Trim();
				if (!(this.txtAddress.Text == ""))
				{
					this.txtAddress.SelectionStart = this.txtAddress.Text.Length;
					this.txtAddress.Focus();
				}
				else
				{
					this.txtAddress.SelectionStart = 0;
					this.txtAddress.Focus();
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void txtAddress_KeyPress(object sender, KeyPressEventArgs e)
		{
			try
			{
				if (e.KeyChar != '\r')
				{
					this.inDescriptionCount = 0;
				}
				else
				{
					frmVendor _frmVendor = this;
					_frmVendor.inDescriptionCount = _frmVendor.inDescriptionCount + 1;
					if (this.inDescriptionCount == 2)
					{
						this.inDescriptionCount = 0;
						this.txtPincode.Focus();
					}
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void txtAddress_KeyUp(object sender, KeyEventArgs e)
		{
		}

		private void txtDescription_Enter(object sender, EventArgs e)
		{
			try
			{
				this.txtDescription.Text = this.txtDescription.Text.Trim();
				if (!(this.txtDescription.Text == ""))
				{
					this.txtDescription.SelectionStart = this.txtDescription.Text.Length;
					this.txtDescription.Focus();
				}
				else
				{
					this.txtDescription.SelectionStart = 0;
					this.txtDescription.Focus();
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void txtDescription_KeyPress(object sender, KeyPressEventArgs e)
		{
			try
			{
				if (e.KeyChar != '\r')
				{
					this.inDescriptionCount = 0;
				}
				else
				{
					frmVendor _frmVendor = this;
					_frmVendor.inDescriptionCount = _frmVendor.inDescriptionCount + 1;
					if (this.inDescriptionCount == 2)
					{
						this.inDescriptionCount = 0;
						this.btnSave.Focus();
					}
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
		{
			try
			{
				if (e.KeyChar == '\r')
				{
					this.txtOpeningBalance.Focus();
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void txtMobile_KeyPress(object sender, KeyPressEventArgs e)
		{
			try
			{
				if (e.KeyChar == '\r')
				{
					this.txtEmail.Focus();
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void txtOpeningBalance_Enter(object sender, EventArgs e)
		{
			try
			{
				if (decimal.Parse(this.txtOpeningBalance.Text) == new decimal(0))
				{
					this.txtOpeningBalance.Text = "";
				}
			}
			catch (Exception exception)
			{
				this.txtOpeningBalance.Text = "";
			}
		}

		private void txtOpeningBalance_KeyPress(object sender, KeyPressEventArgs e)
		{
			try
			{
				if (e.KeyChar == '\r')
				{
					this.cmbDebitOrCredit.Focus();
				}
				else if (!char.IsNumber(e.KeyChar))
				{
					if ((e.KeyChar == '\b' ? false : e.KeyChar != '.'))
					{
						e.Handled = true;
					}
					else if (e.KeyChar != '.')
					{
						e.Handled = false;
					}
					else
					{
						string text = this.txtOpeningBalance.Text;
						for (int i = 0; i < text.Length; i++)
						{
							if (text[i] == '.')
							{
								e.Handled = true;
							}
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

		private void txtOpeningBalance_Leave(object sender, EventArgs e)
		{
			try
			{
				try
				{
					decimal.Parse(this.txtOpeningBalance.Text);
				}
				catch (Exception exception)
				{
					this.txtOpeningBalance.Text = "0.00";
				}
			}
			catch (Exception exception2)
			{
				Exception exception1 = exception2;
				MessageBox.Show(exception1.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
		{
			try
			{
				if (e.KeyChar == '\r')
				{
					this.txtMobile.Focus();
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void txtPincode_KeyPress(object sender, KeyPressEventArgs e)
		{
			try
			{
				if (e.KeyChar == '\r')
				{
					this.cmbCountry.Focus();
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
				for (int i = 0; i < this.dgvVendors.Rows.Count; i++)
				{
					if (!this.dgvVendors[1, i].Value.ToString().ToLower().StartsWith(this.txtSearch.Text.ToLower()))
					{
						this.dgvVendors.Rows[i].Visible = false;
					}
					else
					{
						this.dgvVendors.Rows[i].Visible = true;
					}
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void txtState_KeyPress(object sender, KeyPressEventArgs e)
		{
			try
			{
				if (e.KeyChar == '\r')
				{
					this.txtPhone.Focus();
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void txtVendorName_KeyPress(object sender, KeyPressEventArgs e)
		{
			try
			{
				string str = this.txtDescription.Text.Trim();
				if (e.KeyChar == '\r')
				{
					if (!(str == ""))
					{
						this.txtAddress.SelectionStart = str.Length;
						this.txtAddress.Focus();
					}
					else
					{
						this.txtAddress.SelectionStart = 0;
						this.txtAddress.Focus();
					}
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void txtVendorName_Leave(object sender, EventArgs e)
		{
			try
			{
				if (MDIMedicalShop.MDIObj.ActiveMdiChild == this)
				{
					if ((this.txtSearch.Focused || this.dgvVendors.Focused ? false : !this.isFormClose))
					{
						if (this.txtVendorName.Text.Trim() == "")
						{
							this.txtVendorName.Focus();
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

		public bool ValidateEmail()
		{
			bool flag = true;
			Regex regex = new Regex("\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*");
			if (this.txtEmail.Text.Length > 0)
			{
				if (!regex.IsMatch(this.txtEmail.Text))
				{
					MessageBox.Show("Invalid Email", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					flag = false;
					this.txtEmail.Focus();
					this.txtEmail.SelectAll();
				}
			}
			return flag;
		}

		public bool ValidateMobile()
		{
			bool flag = false;
			if (this.txtMobile.Text != "")
			{
				int num = 0;
				if (!(new Regex("^((([0-9]{4}([-| ]{1}))?[0-9]{7})|((([+]?([0-9]{2})?)|([0][0]?([0-9]{2})?))?([-| ]{1})?[0-9]{9,12})|)$")).IsMatch(this.txtMobile.Text))
				{
					num = 1;
					flag = true;
				}
				if (num == 0)
				{
					flag = false;
				}
				else if (!this.btnClose.Focused)
				{
					MessageBox.Show("Invalid mobile number", "CybroMMS", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					this.txtMobile.SelectAll();
					this.txtMobile.Focus();
				}
			}
			return flag;
		}

		public bool ValidatePhoneNo()
		{
			bool flag = true;
			if ((this.txtPhone.Text.Length <= 0 || this.txtPhone.Text.Length >= 6 ? this.txtPhone.Text.Length <= 14 : false))
			{
				bool flag1 = false;
				int num = 0;
				int num1 = 0;
				int num2 = 0;
				string text = this.txtPhone.Text;
				for (int i = 0; i < text.Length; i++)
				{
					char chr = text[i];
					if (!char.IsDigit(chr))
					{
						if (!(Convert.ToInt32(chr) == 32 || Convert.ToInt32(chr) == 43 ? true : Convert.ToInt32(chr) == 45))
						{
							flag1 = true;
							break;
						}
						else if (!(this.txtPhone.Text.StartsWith("-") ? false : !this.txtPhone.Text.StartsWith(" ")))
						{
							flag1 = true;
							break;
						}
						else if (!(this.txtPhone.Text.EndsWith("-") ? false : !this.txtPhone.Text.EndsWith("+")))
						{
							flag1 = true;
							break;
						}
						else if ((this.txtPhone.Text.IndexOf(chr) <= 0 ? true : Convert.ToInt32(chr) != 43))
						{
							if (Convert.ToInt32(chr) == 43)
							{
								num++;
							}
							if (Convert.ToInt32(chr) == 45)
							{
								num1++;
							}
							if (Convert.ToInt32(chr) == 32)
							{
								num2++;
							}
						}
						else
						{
							flag1 = true;
							break;
						}
					}
				}
				if ((num > 1 || num1 > 2 ? true : num2 > 2))
				{
					flag1 = true;
				}
				if (flag1)
				{
					flag = false;
					MessageBox.Show("Invalid phone number", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					this.txtPhone.Focus();
					this.txtPhone.SelectAll();
				}
			}
			else
			{
				flag = false;
				MessageBox.Show("Invalid phone number", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				this.txtPhone.Focus();
				this.txtPhone.SelectAll();
			}
			return flag;
		}

        private void saveOrEditDetails()
        {
           
            try
            {
                DataTable dataTable = new DataTable();
                if (!FinacialYearInfo._activeOrNot)
                {
                    MessageBox.Show("Selected finacial year has been closed", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {

                    this.txtVendorName.Text = this.txtVendorName.Text.Trim();
                    if (!(this.txtVendorName.Text != ""))
                    {
                        MessageBox.Show("Enter Manufacturer Name", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        this.txtVendorName.Select();
                        this.txtVendorName.Focus();
                    }

                    else
                    {
                        this.venderinfo.VendorName = this.txtVendorName.Text;
                        if (this.txtAddress == null)
                        {
                            this.venderinfo.Address = "";
                        }
                        else
                        {
                            this.venderinfo.Address = this.txtAddress.Text.ToString();
                        }

                        if (this.txtPincode == null)
                        {
                            this.venderinfo.PinCode = "";
                        }
                        else
                        {
                            this.venderinfo.PinCode = this.txtPincode.Text.ToString();
                        }
                        if (this.cmbCountry.SelectedValue == null)
                        {
                            this.venderinfo.Country = "";
                        }
                        else
                        {
                            this.venderinfo.Country = this.cmbCountry.SelectedValue.ToString();
                        }
                        if (this.txtDescription == null)
                        {
                            this.venderinfo.Description = "";
                        }
                        else
                        {
                            this.venderinfo.Description = this.txtDescription.Text.ToString();
                        }
                        if (this.txtState == null)
                        {
                            this.venderinfo.State = "";
                        }
                        else
                        {
                            this.venderinfo.State = this.txtState.Text.ToString();
                        }
                        if (this.txtPhone == null)
                        {
                            this.venderinfo.PhoneNumber = "";
                        }
                        else
                        {
                            this.venderinfo.PhoneNumber = this.txtPhone.Text.ToString();
                        }
                        if (this.txtMobile == null)
                        {
                            this.venderinfo.MobileNumber = "";
                        }
                        else
                        {
                            this.venderinfo.MobileNumber = this.txtMobile.Text.ToString();
                        }

                        if (this.txtEmail == null)
                        {
                            this.venderinfo.EmailId = "";
                        }
                        else
                        {
                            this.venderinfo.EmailId = this.txtEmail.Text.ToString();
                        }
                        if (this.txtOpeningBalance == null)
                        {
                            this.venderinfo.LedgerId = "";
                        }
                        else
                        {
                            this.venderinfo.LedgerId = this.txtOpeningBalance.Text.ToString();
                        }
                        if (this.txtDescription == null)
                        {
                            this.venderinfo.Description = "";
                        }
                        else
                        {
                            this.venderinfo.Description = this.txtDescription.Text.ToString();
                        }
                        
                        if (this.isAutoGenerate)
                        {
                            if (this.CheckExistanceOfvendorName())
                            {
                                MessageBox.Show("manufacturer name already exist", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                this.txtVendorName.Focus();
                                this.txtVendorName.SelectAll();
                            }
                            else if (!(this.btnSave.Text == "&Save"))
                            {
                                this.venderinfo.VendorId = strVendorIdForEdit;
                                this.vendersp.VendorEdit(this.venderinfo);
                                MessageBox.Show("Updated successfully", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                this.ClearFunction();
                            }
                            else
                            {
                                this.venderinfo.VendorId = "0";
                                this.vendersp.vendorAdd(this.venderinfo);

                                MessageBox.Show("Saved successfully", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                                this.ClearFunction();
                            }
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

        public bool CheckExistanceOfvendorName()
        {
            bool flag = false;
            //string str = this.ProductSP.productNameCheck(this.txtProductName.Text.Trim());
            //if (!(str != ""))
            //{
            //    flag = false;
            //}
            //else if (!(this.btnSave.Text == "&Update"))
            //{
            //    flag = true;
            //}
            //else
            //{
            //    flag = (!(this._productNameFromgrid.ToLower() == str.ToLower()) ? true : false);
            //}
            return flag;
        }

    }
}