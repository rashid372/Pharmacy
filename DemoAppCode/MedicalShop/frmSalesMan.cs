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
	public class frmSalesMan : Form
	{
		private MedicalShop.SalesManSP SalesManSP = new MedicalShop.SalesManSP();

		private MedicalShop.SalesManInfo SalesManInfo = new MedicalShop.SalesManInfo();

		private MedicalShop.AccountLedgerSP AccountLedgerSP = new MedicalShop.AccountLedgerSP();

		private MedicalShop.AccountLedgerInfo AccountLedgerInfo = new MedicalShop.AccountLedgerInfo();

		private string _ID = "";

		private string _existCode = "false";

		private string _existName = "false";

		private string _Name = "";

		private string _LedgerId = "";

		private bool isFromOtherForm = false;

		private string strSalesManId = "";

		private DataTable dtSearch = new DataTable();

		private int inDescriptionCount = 0;

		private int inAddressCount = 0;

		private int inQualificationCount = 0;

		private bool isFormClose = false;

		private bool isFromSalesInvoice = false;

		private MedicalShop.frmSalesInvoice frmSalesInvoice;

		private IContainer components = null;

		private Panel panel1;

		private Button btnSave;

		private Button btnDelete;

		private Button btnClear;

		private Button btnClose;

		private Panel panel8;

		private Label label15;

		private Label label9;

		private TextBox txtSalesManName;

		private Label label13;

		private Label label12;

		private Label label11;

		private Label label10;

		private TextBox txtPhone;

		private TextBox txtPinCode;

		private Label label8;

		private GroupBox gpbRegister;

		private Label label4;

		private Label label3;

		private TextBox txtSalesManCode;

		private Label label2;

		private Panel panel6;

		private Label label1;

		private Panel panel7;

		private Panel panel5;

		private Panel panel4;

		private Panel panel3;

		private Panel panel2;

		private TextBox txtEmail;

		private TextBox txtMobile;

		private TextBox txtAddress;

		private Label lblTermination;

		private DateTimePicker dtpDateOfJoining;

		private Label label5;

		private DateTimePicker dtpDateOfTermination;

		private DateTimePicker dtpDateOfBirth;

		private CheckBox cbxActive;

		private Label label16;

		private TextBox txtDescription;

		private TextBox txtQualification;

		private Label label14;

		private Panel panel9;

		private TextBox txtsearch;

		private Label label6;

		private DataGridView dgvSearch;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;

		private DataGridViewTextBoxColumn Column1;

		private DataGridViewTextBoxColumn Column2;
        private Button btnNew;
        private Label label7;
        private ComboBox cmbGroupUnder;
        private Label label17;
        private Label label18;
        private Label label19;
        private DataGridViewTextBoxColumn Column3;

		public frmSalesMan()
		{
			this.InitializeComponent();
		}

		private void btnClear_Click(object sender, EventArgs e)
		{
			try
			{
				this.Clear();
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

                SalesManSP.SalesManDelete (this.strSalesManId);
                MessageBox.Show("Deleted successfully", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                Clear();
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

		public void CallThisFormFromsalesInvoice(MedicalShop.frmSalesInvoice frmsalesinvoice)
		{
			this.isFromSalesInvoice = true;
			this.frmSalesInvoice = frmsalesinvoice;
			this.DoWhenComingFromOtherForms();
		}

		private void cbxActive_CheckedChanged(object sender, EventArgs e)
		{
			if (!this.cbxActive.Checked)
			{
				this.lblTermination.Enabled = true;
				this.dtpDateOfTermination.Enabled = true;
			}
			else
			{
				this.lblTermination.Enabled = false;
				this.dtpDateOfTermination.Enabled = false;
			}
		}

		private void cbxActive_Click(object sender, EventArgs e)
		{
		}

		public void Clear()
		{
			try
			{
				this.txtSalesManCode.Text = "";
				this.txtSalesManName.Text = "";
				this.txtAddress.Text = "";
				this.txtPinCode.Text = "";
				this.txtPhone.Text = "";
				this.txtMobile.Text = "";
				this.txtEmail.Text = "";
				this.dtpDateOfBirth.Text = DateTime.Today.ToString();
				this.dtpDateOfJoining.Text = DateTime.Today.ToString();
				this.dtpDateOfTermination.Text = DateTime.Today.ToString();
				this.txtQualification.Text = "";
				this.txtsearch.Text = "";
				this.txtDescription.Text = "";
				this._LedgerId = "";
				this._ID = "";
				this.strSalesManId = "";
				this.dgdSearchFill();
				this.btnSave.Text = "&Save";
				this.btnClear.Text = "C&lear";
				this.btnDelete.Enabled = false;
				this.txtSalesManCode.BackColor = Color.White;
				this.txtSalesManCode.Enabled = true;
				this.txtSalesManCode.Focus();
				this.cbxActive.Checked = true;
				this.lblTermination.Enabled = false;
				this.dtpDateOfTermination.Enabled = false;
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void dgdSearch_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				if (this.dgvSearch.CurrentRow != null)
				{
					if (this.dgvSearch.RowCount > 0)
					{
						this.txtSalesManCode.Enabled = false;
						this.txtSalesManCode.BackColor = Color.WhiteSmoke;
						this._ID = this.dgvSearch.CurrentRow.Cells[0].Value.ToString();
						this._Name = this.dgvSearch.CurrentRow.Cells[1].Value.ToString();
						foreach (DataRow row in this.dtSearch.Rows)
						{
							if (this._ID == row.ItemArray[0].ToString())
							{
								this.txtSalesManCode.Text = row.ItemArray[0].ToString();
								this.txtSalesManName.Text = row.ItemArray[1].ToString();
								this.txtAddress.Text = row.ItemArray[2].ToString();
								this.txtPinCode.Text = row.ItemArray[3].ToString();
								this.txtPhone.Text = row.ItemArray[4].ToString();
								this.txtMobile.Text = row.ItemArray[5].ToString();
								this.txtEmail.Text = row.ItemArray[6].ToString();
								this.dtpDateOfBirth.Text = row.ItemArray[7].ToString();
								this.dtpDateOfJoining.Text = row.ItemArray[8].ToString();
								this.txtQualification.Text = row.ItemArray[10].ToString();
								if (!(row.ItemArray[11].ToString() == true.ToString()))
								{
									this.cbxActive.Checked = false;
									this.dtpDateOfTermination.Enabled = true;
									this.lblTermination.Enabled = true;
									this.dtpDateOfTermination.Text = row.ItemArray[9].ToString();
								}
								else
								{
									this.cbxActive.Checked = true;
									this.lblTermination.Enabled = false;
									this.dtpDateOfTermination.Enabled = false;
								}
								this._LedgerId = row.ItemArray[12].ToString();
								this.txtDescription.Text = row.ItemArray[13].ToString();
							}
						}
						this.dgvSearch.CurrentRow.Selected = true;
						this.btnSave.Text = "&Update";
						this.btnClear.Text = "&New";
						this.btnDelete.Enabled = true;
						this.txtSalesManCode.Enabled = false;
					}
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void dgdSearch_KeyUp(object sender, KeyEventArgs e)
		{
			try
			{
				if ((e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Return ? true : e.KeyCode == Keys.Tab))
				{
					if (this.dgvSearch.CurrentRow != null)
					{
						DataGridViewCellEventArgs dataGridViewCellEventArg = new DataGridViewCellEventArgs(0, this.dgvSearch.CurrentRow.Index);
						this.dgdSearch_CellClick(sender, dataGridViewCellEventArg);
					}
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void dgdSearchFill()
		{
			try
			{
				int str = 0;
				if (this.dtSearch.Rows.Count > 0)
				{
					this.dtSearch.Rows.Clear();
				}
				this.dtSearch = this.SalesManSP.SalesManViewAll();
				if (this.dgvSearch.RowCount > 0)
				{
					this.dgvSearch.Rows.Clear();
				}
				int num = 0;
				foreach (DataRow row in this.dtSearch.Rows)
				{
					if (!(row.ItemArray[0].ToString() == "0"))
					{
						num++;
					}
					else
					{
						this.dtSearch.Rows.RemoveAt(num);
						break;
					}
				}
				foreach (DataRow dataRow in this.dtSearch.Rows)
				{
					this.dgvSearch.Rows.Add();
					this.dgvSearch.Rows[str].Cells[0].Value = dataRow.ItemArray[0].ToString();
					this.dgvSearch.Rows[str].Cells[1].Value = dataRow.ItemArray[1].ToString();
					str++;
				}
				DataGridViewCell currentCell = this.dgvSearch.CurrentCell;
				this.dgvSearch.CurrentCell = null;
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

		public void DoWhenComingFromOtherForms()
		{
			this.isFromOtherForm = true;
			this.gpbRegister.Enabled = false;
			base.Show();
		}

		public void DoWhenQuitingForm()
		{
			if (this.isFromSalesInvoice)
			{
				if (!this.cbxActive.Checked)
				{
					this.frmSalesInvoice.FillComboFromSalesmanForm("");
				}
				else
				{
					this.frmSalesInvoice.FillComboFromSalesmanForm(this.strSalesManId);
				}
			}
		}

		private void dtpDateOfBirth_KeyDown(object sender, KeyEventArgs e)
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

		private void frmSalesMan_FormClosing(object sender, FormClosingEventArgs e)
		{
			try
			{
				this.isFormClose = true;
				this.DoWhenQuitingForm();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void frmSalesMan_Load(object sender, EventArgs e)
		{
			try
			{
				this.Clear();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void InitializeComponent()
		{
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmSalesMan));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel8 = new System.Windows.Forms.Panel();
            this.txtQualification = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cbxActive = new System.Windows.Forms.CheckBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblTermination = new System.Windows.Forms.Label();
            this.dtpDateOfJoining = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpDateOfTermination = new System.Windows.Forms.DateTimePicker();
            this.dtpDateOfBirth = new System.Windows.Forms.DateTimePicker();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtMobile = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtSalesManName = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtPinCode = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.gpbRegister = new System.Windows.Forms.GroupBox();
            this.panel9 = new System.Windows.Forms.Panel();
            this.txtsearch = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvSearch = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSalesManCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label19 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel8.SuspendLayout();
            this.gpbRegister.SuspendLayout();
            this.panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearch)).BeginInit();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
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
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(7, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(650, 468);
            this.panel1.TabIndex = 5;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(209)))), ((int)(((byte)(150)))));
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(1)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(324, 418);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(209)))), ((int)(((byte)(150)))));
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(1)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(405, 418);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(209)))), ((int)(((byte)(150)))));
            this.btnClear.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(1)))));
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(486, 418);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "C&lear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(209)))), ((int)(((byte)(150)))));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(1)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(567, 418);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panel8
            // 
            this.panel8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel8.Controls.Add(this.label19);
            this.panel8.Controls.Add(this.txtQualification);
            this.panel8.Controls.Add(this.label14);
            this.panel8.Controls.Add(this.cbxActive);
            this.panel8.Controls.Add(this.label16);
            this.panel8.Controls.Add(this.txtDescription);
            this.panel8.Controls.Add(this.lblTermination);
            this.panel8.Controls.Add(this.dtpDateOfJoining);
            this.panel8.Controls.Add(this.label5);
            this.panel8.Controls.Add(this.dtpDateOfTermination);
            this.panel8.Controls.Add(this.dtpDateOfBirth);
            this.panel8.Controls.Add(this.txtEmail);
            this.panel8.Controls.Add(this.txtMobile);
            this.panel8.Controls.Add(this.txtAddress);
            this.panel8.Controls.Add(this.label15);
            this.panel8.Controls.Add(this.label9);
            this.panel8.Controls.Add(this.txtSalesManName);
            this.panel8.Controls.Add(this.label13);
            this.panel8.Controls.Add(this.label12);
            this.panel8.Controls.Add(this.label11);
            this.panel8.Controls.Add(this.label10);
            this.panel8.Controls.Add(this.txtPhone);
            this.panel8.Controls.Add(this.txtPinCode);
            this.panel8.Controls.Add(this.label8);
            this.panel8.Controls.Add(this.gpbRegister);
            this.panel8.Controls.Add(this.label4);
            this.panel8.Controls.Add(this.label3);
            this.panel8.Controls.Add(this.txtSalesManCode);
            this.panel8.Controls.Add(this.label2);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(1, 34);
            this.panel8.Name = "panel8";
            this.panel8.Padding = new System.Windows.Forms.Padding(5);
            this.panel8.Size = new System.Drawing.Size(648, 369);
            this.panel8.TabIndex = 1;
            // 
            // txtQualification
            // 
            this.txtQualification.Location = new System.Drawing.Point(461, 268);
            this.txtQualification.Multiline = true;
            this.txtQualification.Name = "txtQualification";
            this.txtQualification.Size = new System.Drawing.Size(180, 80);
            this.txtQualification.TabIndex = 10;
            this.txtQualification.TextChanged += new System.EventHandler(this.rtbQualification_TextChanged);
            this.txtQualification.Enter += new System.EventHandler(this.txtQualification_Enter);
            this.txtQualification.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSalesManCode_KeyPress);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(387, 271);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(68, 13);
            this.label14.TabIndex = 55;
            this.label14.Text = "Qualification:";
            // 
            // cbxActive
            // 
            this.cbxActive.AutoSize = true;
            this.cbxActive.Location = new System.Drawing.Point(11, 344);
            this.cbxActive.Name = "cbxActive";
            this.cbxActive.Size = new System.Drawing.Size(56, 17);
            this.cbxActive.TabIndex = 54;
            this.cbxActive.Text = "Active";
            this.cbxActive.UseVisualStyleBackColor = true;
            this.cbxActive.CheckedChanged += new System.EventHandler(this.cbxActive_CheckedChanged);
            this.cbxActive.Click += new System.EventHandler(this.cbxActive_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(8, 308);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(63, 13);
            this.label16.TabIndex = 53;
            this.label16.Text = "Description:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(134, 305);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(232, 55);
            this.txtDescription.TabIndex = 11;
            this.txtDescription.Enter += new System.EventHandler(this.txtDescription_Enter);
            this.txtDescription.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSalesManCode_KeyPress);
            // 
            // lblTermination
            // 
            this.lblTermination.AutoSize = true;
            this.lblTermination.Location = new System.Drawing.Point(8, 286);
            this.lblTermination.Name = "lblTermination";
            this.lblTermination.Size = new System.Drawing.Size(103, 13);
            this.lblTermination.TabIndex = 50;
            this.lblTermination.Text = "Date of Termination:";
            // 
            // dtpDateOfJoining
            // 
            this.dtpDateOfJoining.CustomFormat = "dd-MMM-yyyy";
            this.dtpDateOfJoining.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateOfJoining.Location = new System.Drawing.Point(134, 253);
            this.dtpDateOfJoining.Name = "dtpDateOfJoining";
            this.dtpDateOfJoining.Size = new System.Drawing.Size(232, 20);
            this.dtpDateOfJoining.TabIndex = 8;
            this.dtpDateOfJoining.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpDateOfBirth_KeyDown);
            this.dtpDateOfJoining.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSalesManCode_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 260);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 13);
            this.label5.TabIndex = 48;
            this.label5.Text = "Date of Joining:";
            // 
            // dtpDateOfTermination
            // 
            this.dtpDateOfTermination.CustomFormat = "dd-MMM-yyyy";
            this.dtpDateOfTermination.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateOfTermination.Location = new System.Drawing.Point(134, 279);
            this.dtpDateOfTermination.Name = "dtpDateOfTermination";
            this.dtpDateOfTermination.Size = new System.Drawing.Size(232, 20);
            this.dtpDateOfTermination.TabIndex = 9;
            this.dtpDateOfTermination.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpDateOfBirth_KeyDown);
            this.dtpDateOfTermination.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSalesManCode_KeyPress);
            // 
            // dtpDateOfBirth
            // 
            this.dtpDateOfBirth.CustomFormat = "dd-MMM-yyyy";
            this.dtpDateOfBirth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateOfBirth.Location = new System.Drawing.Point(134, 227);
            this.dtpDateOfBirth.Name = "dtpDateOfBirth";
            this.dtpDateOfBirth.Size = new System.Drawing.Size(232, 20);
            this.dtpDateOfBirth.TabIndex = 7;
            this.dtpDateOfBirth.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpDateOfBirth_KeyDown);
            this.dtpDateOfBirth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSalesManCode_KeyPress);
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(134, 201);
            this.txtEmail.MaxLength = 50;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(232, 20);
            this.txtEmail.TabIndex = 6;
            this.txtEmail.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSalesManCode_KeyPress);
            // 
            // txtMobile
            // 
            this.txtMobile.Location = new System.Drawing.Point(134, 175);
            this.txtMobile.MaxLength = 15;
            this.txtMobile.Name = "txtMobile";
            this.txtMobile.Size = new System.Drawing.Size(232, 20);
            this.txtMobile.TabIndex = 5;
            this.txtMobile.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSalesManCode_KeyPress);
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(134, 62);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(232, 55);
            this.txtAddress.TabIndex = 2;
            this.txtAddress.Enter += new System.EventHandler(this.txtAddress_Enter);
            this.txtAddress.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSalesManCode_KeyPress);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(8, 234);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(69, 13);
            this.label15.TabIndex = 41;
            this.label15.Text = "Date of Birth:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(372, 41);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(12, 13);
            this.label9.TabIndex = 32;
            this.label9.Text = "*";
            // 
            // txtSalesManName
            // 
            this.txtSalesManName.Location = new System.Drawing.Point(134, 36);
            this.txtSalesManName.MaxLength = 50;
            this.txtSalesManName.Name = "txtSalesManName";
            this.txtSalesManName.Size = new System.Drawing.Size(232, 20);
            this.txtSalesManName.TabIndex = 1;
            this.txtSalesManName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSalesManCode_KeyPress);
            this.txtSalesManName.Leave += new System.EventHandler(this.txtSalesManName_Leave);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(8, 208);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(35, 13);
            this.label13.TabIndex = 29;
            this.label13.Text = "Email:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(8, 182);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 13);
            this.label12.TabIndex = 27;
            this.label12.Text = "Mobile:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 156);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 13);
            this.label11.TabIndex = 23;
            this.label11.Text = "Phone:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 130);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "Pincode:";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(134, 149);
            this.txtPhone.MaxLength = 15;
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(232, 20);
            this.txtPhone.TabIndex = 4;
            this.txtPhone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSalesManCode_KeyPress);
            // 
            // txtPinCode
            // 
            this.txtPinCode.Location = new System.Drawing.Point(134, 123);
            this.txtPinCode.MaxLength = 15;
            this.txtPinCode.Name = "txtPinCode";
            this.txtPinCode.Size = new System.Drawing.Size(232, 20);
            this.txtPinCode.TabIndex = 3;
            this.txtPinCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSalesManCode_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 65);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Address:";
            // 
            // gpbRegister
            // 
            this.gpbRegister.BackColor = System.Drawing.Color.White;
            this.gpbRegister.Controls.Add(this.panel9);
            this.gpbRegister.Location = new System.Drawing.Point(390, 8);
            this.gpbRegister.Name = "gpbRegister";
            this.gpbRegister.Padding = new System.Windows.Forms.Padding(5);
            this.gpbRegister.Size = new System.Drawing.Size(251, 254);
            this.gpbRegister.TabIndex = 7;
            this.gpbRegister.TabStop = false;
            this.gpbRegister.Text = "Register";
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.txtsearch);
            this.panel9.Controls.Add(this.label6);
            this.panel9.Controls.Add(this.dgvSearch);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel9.Location = new System.Drawing.Point(5, 18);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(241, 231);
            this.panel9.TabIndex = 0;
            // 
            // txtsearch
            // 
            this.txtsearch.Location = new System.Drawing.Point(86, 9);
            this.txtsearch.MaxLength = 50;
            this.txtsearch.Name = "txtsearch";
            this.txtsearch.Size = new System.Drawing.Size(148, 20);
            this.txtsearch.TabIndex = 0;
            this.txtsearch.TabStop = false;
            this.txtsearch.TextChanged += new System.EventHandler(this.txtsearch_TextChanged);
            this.txtsearch.Leave += new System.EventHandler(this.txtsearch_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Search For:";
            // 
            // dgvSearch
            // 
            this.dgvSearch.AllowUserToAddRows = false;
            this.dgvSearch.AllowUserToDeleteRows = false;
            this.dgvSearch.AllowUserToResizeColumns = false;
            this.dgvSearch.AllowUserToResizeRows = false;
            this.dgvSearch.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSearch.BackgroundColor = System.Drawing.Color.White;
            this.dgvSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			DataGridViewColumnCollection columns = this.dgvSearch.Columns;
			DataGridViewColumn[] column1 = new DataGridViewColumn[] { this.Column1, this.Column2, this.Column3 };
			columns.AddRange(column1);
            this.dgvSearch.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvSearch.Location = new System.Drawing.Point(9, 53);
            this.dgvSearch.MultiSelect = false;
            this.dgvSearch.Name = "dgvSearch";
            this.dgvSearch.ReadOnly = true;
            this.dgvSearch.RowHeadersVisible = false;
            this.dgvSearch.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvSearch.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSearch.Size = new System.Drawing.Size(225, 169);
            this.dgvSearch.TabIndex = 1;
            this.dgvSearch.TabStop = false;
            this.dgvSearch.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgdSearch_CellClick);
            this.dgvSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgdSearch_KeyUp);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(372, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(12, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "*";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Sales Man Name::";
            // 
            // txtSalesManCode
            // 
            this.txtSalesManCode.Location = new System.Drawing.Point(134, 10);
            this.txtSalesManCode.MaxLength = 50;
            this.txtSalesManCode.Name = "txtSalesManCode";
            this.txtSalesManCode.Size = new System.Drawing.Size(232, 20);
            this.txtSalesManCode.TabIndex = 0;
            this.txtSalesManCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSalesManCode_KeyPress);
            this.txtSalesManCode.Leave += new System.EventHandler(this.txtSalesManCode_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Sales Man Code:";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.label1);
            this.panel6.Controls.Add(this.panel7);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(1, 1);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(648, 33);
            this.panel6.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Sales Man";
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            this.panel7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel7.Location = new System.Drawing.Point(0, 32);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(648, 1);
            this.panel7.TabIndex = 3;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(1, 467);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(648, 1);
            this.panel5.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(1, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(648, 1);
            this.panel4.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(649, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1, 468);
            this.panel3.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1, 468);
            this.panel2.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "SI";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column1.Visible = false;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Name";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Description";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column3.Visible = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "SI";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn1.Visible = false;
            this.dataGridViewTextBoxColumn1.Width = 111;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Name";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn2.Width = 111;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Description";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn3.Visible = false;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(28, 295);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(39, 13);
            this.label19.TabIndex = 6;
            this.label19.Text = "Group:";
            // 
            // frmSalesMan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(664, 482);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "frmSalesMan";
            this.Padding = new System.Windows.Forms.Padding(7);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sales Man";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSalesMan_FormClosing);
            this.Load += new System.EventHandler(this.frmSalesMan_Load);
            this.panel1.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.gpbRegister.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearch)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);

		}

		public bool MobileValidation()
		{
			bool flag = false;
			try
			{
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
						this.txtMobile.SelectAll();
						this.txtMobile.Focus();
					}
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			return flag;
		}

		protected override bool ProcessDialogKey(Keys keyData)
		{
			bool flag;
			if (keyData != Keys.Tab)
			{
				base.ProcessDialogKey(keyData);
				flag = false;
			}
			else if (!this.txtDescription.Focused)
			{
				base.ProcessDialogKey(keyData);
				flag = true;
			}
			else
			{
				this.btnSave.Focus();
				flag = false;
			}
			return flag;
		}

		private void rtbQualification_TextChanged(object sender, EventArgs e)
		{
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

		private void txtQualification_Enter(object sender, EventArgs e)
		{
			try
			{
				this.txtQualification.Text = this.txtQualification.Text.Trim();
				if (!(this.txtQualification.Text == ""))
				{
					this.txtQualification.SelectionStart = this.txtQualification.Text.Length;
					this.txtQualification.Focus();
				}
				else
				{
					this.txtQualification.SelectionStart = 0;
					this.txtQualification.Focus();
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void txtSalesManCode_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar != '\r')
			{
				this.inQualificationCount = 0;
				this.inDescriptionCount = 0;
				this.inQualificationCount = 0;
				this.inAddressCount = 0;
			}
			else if (this.txtDescription.Focused)
			{
				frmSalesMan _frmSalesMan = this;
				_frmSalesMan.inDescriptionCount = _frmSalesMan.inDescriptionCount + 1;
				if (this.inDescriptionCount == 2)
				{
					this.inDescriptionCount = 0;
					e.Handled = true;
					SendKeys.Send("{TAB}");
				}
			}
			else if (this.txtQualification.Focused)
			{
				frmSalesMan _frmSalesMan1 = this;
				_frmSalesMan1.inQualificationCount = _frmSalesMan1.inQualificationCount + 1;
				if (this.inQualificationCount == 2)
				{
					this.inQualificationCount = 0;
					e.Handled = true;
					SendKeys.Send("{TAB}");
				}
			}
			else if (!this.txtAddress.Focused)
			{
				SendKeys.Send("{TAB}");
			}
			else
			{
				frmSalesMan _frmSalesMan2 = this;
				_frmSalesMan2.inAddressCount = _frmSalesMan2.inAddressCount + 1;
				if (this.inAddressCount == 2)
				{
					this.inAddressCount = 0;
					e.Handled = true;
					SendKeys.Send("{TAB}");
				}
			}
		}

		private void txtSalesManCode_Leave(object sender, EventArgs e)
		{
			try
			{
				if (MDIMedicalShop.MDIObj.ActiveMdiChild == this)
				{
					if ((this.txtsearch.Focused || this.dgvSearch.Focused ? false : !this.isFormClose))
					{
						if (this.txtSalesManCode.Text.Trim() == "")
						{
							this.txtSalesManCode.Focus();
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

		private void txtSalesManName_Leave(object sender, EventArgs e)
		{
			try
			{
				if (MDIMedicalShop.MDIObj.ActiveMdiChild == this)
				{
					if ((this.txtsearch.Focused || this.dgvSearch.Focused || this.txtSalesManCode.Focused ? false : !this.isFormClose))
					{
						if (this.txtSalesManName.Text.Trim() == "")
						{
							this.txtSalesManName.Focus();
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

		private void txtsearch_Leave(object sender, EventArgs e)
		{
			try
			{
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void txtsearch_TextChanged(object sender, EventArgs e)
		{
			try
			{
				for (int i = 0; i < this.dgvSearch.Rows.Count; i++)
				{
					if (!this.dgvSearch[1, i].Value.ToString().ToLower().StartsWith(this.txtsearch.Text.ToLower()))
					{
						this.dgvSearch.Rows[i].Visible = false;
					}
					else
					{
						this.dgvSearch.Rows[i].Visible = true;
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
					flag = false;
					this.txtEmail.Focus();
					this.txtEmail.SelectAll();
				}
			}
			return flag;
		}

		public bool ValidatePhoneNo(string number)
		{
			bool flag = true;
			TextBox textBox = new TextBox()
			{
				Text = number
			};
			if ((textBox.Text.Length <= 0 || textBox.Text.Length >= 6 ? textBox.Text.Length <= 14 : false))
			{
				bool flag1 = false;
				int num = 0;
				int num1 = 0;
				int num2 = 0;
				string text = textBox.Text;
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
				}
			}
			else
			{
				flag = false;
			}
			return flag;
		}

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmbGroupUnder_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void cmbGroupUnder_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}