using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Resources;
using System.Text.RegularExpressions;
using System.Web.Mail;
using System.Windows.Forms;

namespace MedicalShop
{
	public class frmSendMail : Form
	{
		private MedicalShop.ManufacturerSP ManufacturerSP = new MedicalShop.ManufacturerSP();

		private MedicalShop.SalesManSP SalesManSP = new MedicalShop.SalesManSP();

		private MedicalShop.VendorSP VendorSP = new MedicalShop.VendorSP();

		private MedicalShop.frmCompanyProgress frmCompanyProgress = new MedicalShop.frmCompanyProgress();

		private bool isSend = false;

		private bool isCheck = false;

		private int inEnterCount = 0;

		private string _ID = "";

		private DataTable dtFillCombo = new DataTable();

		private IContainer components = null;

		private Label lblName;

		private ComboBox cmbName;

		private Label label3;

		private TextBox txtemail;

		private Label label5;

		private TextBox txtCC;

		private TextBox txtTo;

		private Label label4;

		private Label label6;

		private TextBox txtBCC;

		private Label label8;

		private Label label7;

		private TextBox txtSubject;

		private Button btnFileattach;

		private ListBox lstbxAttach;

		private BackgroundWorker bwrk1;

		private ComboBox cmbDetails;

		private TextBox txtBody;

		private Panel panel1;

		private Button btnSend;

		private Button btnClear;

		private Button btnClose;

		private Panel panel8;

		private Panel panel6;

		private Label label18;

		private Panel panel7;

		private Panel panel5;

		private Panel panel4;

		private Panel panel3;

		private Panel panel9;

		private Label label1;

		private Button btnAdd;

		public frmSendMail()
		{
			this.InitializeComponent();
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			try
			{
				if (!(this.txtemail.Text != ""))
				{
					this.txtCC.Focus();
				}
				else if (!this.txtemail.Text.Contains(","))
				{
					Regex regex = new Regex("\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*");
					if (this.txtemail.Text.Length > 0)
					{
						if (!regex.IsMatch(this.txtemail.Text))
						{
							MessageBox.Show("Invalid Email", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
							this.txtemail.Focus();
							this.txtemail.SelectAll();
						}
						else if (!(this.txtTo.Text != ""))
						{
							this.txtTo.Text = this.txtemail.Text;
							this.txtemail.Text = "";
						}
						else
						{
							this.txtTo.Text = string.Concat(this.txtTo.Text, ",", this.txtemail.Text);
							this.txtemail.Text = "";
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

		private void btnAdd_KeyPress(object sender, KeyPressEventArgs e)
		{
			this.ShortCuts(e);
		}

		private void btnClear_Click(object sender, EventArgs e)
		{
			try
			{
				this.ClearFields();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Do you want to close?", "Pharmacy", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
			{
				base.Close();
			}
		}

		private void btnFileattach_Click(object sender, EventArgs e)
		{
			try
			{
				OpenFileDialog openFileDialog = new OpenFileDialog();
				openFileDialog.ShowDialog();
				if (openFileDialog.FileName.ToString() != "")
				{
					this.lstbxAttach.Items.Add(openFileDialog.FileName.ToString());
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void btnFileattach_KeyPress(object sender, KeyPressEventArgs e)
		{
			this.ShortCuts(e);
		}

		private void btnSend_Click(object sender, EventArgs e)
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

		private void bwrk1_DoWork(object sender, DoWorkEventArgs e)
		{
			try
			{
				this.SendAttachmentEmail();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void bwrk1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			try
			{
				if ((this.frmCompanyProgress == null ? false : this.isSend))
				{
					this.frmCompanyProgress.Close();
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		public void ClearFields()
		{
			try
			{
				this.cmbDetails.SelectedIndex = -1;
				this.txtemail.Clear();
				this.txtTo.Clear();
				this.txtBody.Clear();
				this.txtBCC.Clear();
				this.txtCC.Clear();
				this.txtSubject.Text = "";
				this.inEnterCount = 0;
				this.lstbxAttach.Items.Clear();
				this.cmbDetails.Enabled = true;
				this.cmbName.SelectedIndex = 0;
				this.cmbName.Select();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				System.Windows.Forms.Cursor.Current = Cursors.Default;
				this.isSend = true;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void cmbDetails_KeyPress(object sender, KeyPressEventArgs e)
		{
			this.ShortCuts(e);
		}

		private void cmbDetails_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				this.txtemail.Text = "";
				if (this.cmbDetails.SelectedValue != null)
				{
					this._ID = this.cmbDetails.SelectedValue.ToString();
				}
				if (this.cmbName.Text != "Other")
				{
					if (this.dtFillCombo.Rows.Count > 0)
					{
						foreach (DataRow row in this.dtFillCombo.Rows)
						{
							this.FillEmail();
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

		private void cmbName_KeyDown(object sender, KeyEventArgs e)
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

		private void cmbName_KeyPress(object sender, KeyPressEventArgs e)
		{
			try
			{
				this.ShortCuts(e);
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void cmbName_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				this.txtemail.Text = "";
				if (this.cmbName.Text == "Manufacture")
				{
					this.cmbDetails.Enabled = true;
					if (this.dtFillCombo.Rows.Count > 0)
					{
						this.dtFillCombo.Rows.Clear();
					}
					this.dtFillCombo = this.ManufacturerSP.ManufacturerViewAllExceptNA();
					this.cmbDetails.DataSource = this.dtFillCombo;
					this.cmbDetails.DisplayMember = "Name";
					this.cmbDetails.ValueMember = "ID";
					this.cmbDetails.SelectedValue = -1;
				}
				if (this.cmbName.Text == "Sales man")
				{
					this.cmbDetails.Enabled = true;
					if (this.dtFillCombo.Rows.Count > 0)
					{
						this.dtFillCombo.Rows.Clear();
					}
					this.dtFillCombo = this.SalesManSP.SalesManViewAllExceptNA();
					this.cmbDetails.DataSource = this.dtFillCombo;
					this.cmbDetails.DisplayMember = "Sales Man Name";
					this.cmbDetails.ValueMember = "Sales Man Id";
					this.cmbDetails.SelectedValue = -1;
				}
				if (this.cmbName.Text == "Vendor")
				{
					this.cmbDetails.Enabled = true;
					if (this.dtFillCombo.Rows.Count > 0)
					{
						this.dtFillCombo.Rows.Clear();
					}
					this.dtFillCombo = this.VendorSP.VendorViewAllExceptNA();
					this.cmbDetails.DataSource = this.dtFillCombo;
					this.cmbDetails.DisplayMember = "Vendor Name";
					this.cmbDetails.ValueMember = "Vendor Id";
					this.cmbDetails.SelectedValue = -1;
				}
				if (this.cmbName.Text == "Other")
				{
					this.cmbDetails.Enabled = false;
					if (this.dtFillCombo.Rows.Count > 0)
					{
						this.dtFillCombo.Rows.Clear();
					}
					this.cmbDetails.DataSource = this.dtFillCombo;
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

		public void FillEmail()
		{
			DataRow row = null;
			if ((this.cmbName.Text != "Manufacture" ? false : this.cmbDetails.Focused))
			{
				if (this.dtFillCombo.Rows.Count > 0)
				{
					foreach (DataRow row1 in this.dtFillCombo.Rows)
					{
						if (this._ID == row1.ItemArray[0].ToString())
						{
							this.txtemail.Text = row1.ItemArray[4].ToString();
						}
					}
				}
			}
			if (this.cmbName.Text == "Sales man")
			{
				if (this.dtFillCombo.Rows.Count > 0)
				{
					foreach (DataRow dataRow in this.dtFillCombo.Rows)
					{
						if (this._ID == dataRow.ItemArray[0].ToString())
						{
							this.txtemail.Text = dataRow.ItemArray[6].ToString();
						}
					}
				}
			}
			if (this.cmbName.Text == "Vendor")
			{
				if (this.dtFillCombo.Rows.Count > 0)
				{
					foreach (DataRow row1 in this.dtFillCombo.Rows)
					{
						if (this._ID == row1.ItemArray[0].ToString())
						{
							this.txtemail.Text = row1.ItemArray[8].ToString();
						}
					}
				}
			}
			if (this.cmbName.Text == "Other")
			{
				if (this.dtFillCombo.Rows.Count > 0)
				{
					foreach (DataRow dataRow1 in this.dtFillCombo.Rows)
					{
						if (this._ID == dataRow1.ItemArray[0].ToString())
						{
							this.txtemail.Text = dataRow1.ItemArray[4].ToString();
						}
					}
				}
			}
		}

		private void frmSendMail_Load(object sender, EventArgs e)
		{
			try
			{
				this.ClearFields();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void InitializeComponent()
		{
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmSendMail));
			this.cmbDetails = new ComboBox();
			this.lstbxAttach = new ListBox();
			this.btnFileattach = new Button();
			this.label8 = new Label();
			this.label7 = new Label();
			this.txtSubject = new TextBox();
			this.label6 = new Label();
			this.txtBCC = new TextBox();
			this.label5 = new Label();
			this.txtCC = new TextBox();
			this.txtTo = new TextBox();
			this.label4 = new Label();
			this.txtemail = new TextBox();
			this.label3 = new Label();
			this.lblName = new Label();
			this.cmbName = new ComboBox();
			this.bwrk1 = new BackgroundWorker();
			this.txtBody = new TextBox();
			this.panel1 = new Panel();
			this.btnSend = new Button();
			this.btnClear = new Button();
			this.btnClose = new Button();
			this.panel8 = new Panel();
			this.label1 = new Label();
			this.btnAdd = new Button();
			this.panel6 = new Panel();
			this.label18 = new Label();
			this.panel7 = new Panel();
			this.panel5 = new Panel();
			this.panel4 = new Panel();
			this.panel3 = new Panel();
			this.panel9 = new Panel();
			this.panel1.SuspendLayout();
			this.panel8.SuspendLayout();
			this.panel6.SuspendLayout();
			base.SuspendLayout();
			this.cmbDetails.DropDownStyle = ComboBoxStyle.DropDownList;
			this.cmbDetails.DropDownWidth = 220;
			this.cmbDetails.FormattingEnabled = true;
			this.cmbDetails.Location = new Point(363, 12);
			this.cmbDetails.Margin = new System.Windows.Forms.Padding(5);
			this.cmbDetails.Name = "cmbDetails";
			this.cmbDetails.Size = new System.Drawing.Size(275, 21);
			this.cmbDetails.TabIndex = 1;
			this.cmbDetails.SelectedIndexChanged += new EventHandler(this.cmbDetails_SelectedIndexChanged);
			this.cmbDetails.KeyPress += new KeyPressEventHandler(this.cmbDetails_KeyPress);
			this.cmbDetails.KeyDown += new KeyEventHandler(this.cmbName_KeyDown);
			this.lstbxAttach.FormattingEnabled = true;
			this.lstbxAttach.Location = new Point(76, 195);
			this.lstbxAttach.Name = "lstbxAttach";
			this.lstbxAttach.Size = new System.Drawing.Size(461, 30);
			this.lstbxAttach.TabIndex = 8;
			this.lstbxAttach.TabStop = false;
			this.lstbxAttach.KeyPress += new KeyPressEventHandler(this.lstbxAttach_KeyPress);
			this.lstbxAttach.KeyDown += new KeyEventHandler(this.lstbxAttach_KeyDown);
			this.btnFileattach.AllowDrop = true;
			this.btnFileattach.BackColor = Color.SteelBlue;
			this.btnFileattach.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.btnFileattach.ForeColor = Color.White;
			this.btnFileattach.Location = new Point(543, 202);
			this.btnFileattach.Name = "btnFileattach";
			this.btnFileattach.Size = new System.Drawing.Size(95, 23);
			this.btnFileattach.TabIndex = 13;
			this.btnFileattach.TabStop = false;
			this.btnFileattach.Text = "File Attach";
			this.btnFileattach.UseVisualStyleBackColor = false;
			this.btnFileattach.Click += new EventHandler(this.btnFileattach_Click);
			this.btnFileattach.KeyPress += new KeyPressEventHandler(this.btnFileattach_KeyPress);
			this.label8.AutoSize = true;
			this.label8.Location = new Point(5, 212);
			this.label8.Margin = new System.Windows.Forms.Padding(0, 15, 15, 15);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(64, 13);
			this.label8.TabIndex = 132;
			this.label8.Text = "Attachment:";
			this.label7.AutoSize = true;
			this.label7.Location = new Point(5, 174);
			this.label7.Margin = new System.Windows.Forms.Padding(0, 15, 15, 15);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(46, 13);
			this.label7.TabIndex = 130;
			this.label7.Text = "Subject:";
			this.txtSubject.Location = new Point(76, 167);
			this.txtSubject.Margin = new System.Windows.Forms.Padding(5);
			this.txtSubject.MaxLength = 50;
			this.txtSubject.Name = "txtSubject";
			this.txtSubject.Size = new System.Drawing.Size(562, 20);
			this.txtSubject.TabIndex = 6;
			this.txtSubject.KeyPress += new KeyPressEventHandler(this.txtSubject_KeyPress);
			this.label6.AutoSize = true;
			this.label6.Location = new Point(5, 146);
			this.label6.Margin = new System.Windows.Forms.Padding(0, 15, 15, 15);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(31, 13);
			this.label6.TabIndex = 128;
			this.label6.Text = "BCC:";
			this.txtBCC.Location = new Point(76, 139);
			this.txtBCC.Margin = new System.Windows.Forms.Padding(5);
			this.txtBCC.Name = "txtBCC";
			this.txtBCC.Size = new System.Drawing.Size(562, 20);
			this.txtBCC.TabIndex = 5;
			this.txtBCC.KeyPress += new KeyPressEventHandler(this.txtBCC_KeyPress);
			this.label5.AutoSize = true;
			this.label5.Location = new Point(5, 116);
			this.label5.Margin = new System.Windows.Forms.Padding(0, 15, 15, 15);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(24, 13);
			this.label5.TabIndex = 126;
			this.label5.Text = "CC:";
			this.txtCC.Location = new Point(76, 109);
			this.txtCC.Margin = new System.Windows.Forms.Padding(5);
			this.txtCC.Name = "txtCC";
			this.txtCC.Size = new System.Drawing.Size(562, 20);
			this.txtCC.TabIndex = 4;
			this.txtCC.KeyPress += new KeyPressEventHandler(this.txtCC_KeyPress);
			this.txtTo.AcceptsReturn = true;
			this.txtTo.BackColor = Color.WhiteSmoke;
			this.txtTo.Enabled = false;
			this.txtTo.Location = new Point(76, 79);
			this.txtTo.Margin = new System.Windows.Forms.Padding(5);
			this.txtTo.Name = "txtTo";
			this.txtTo.Size = new System.Drawing.Size(562, 20);
			this.txtTo.TabIndex = 4;
			this.txtTo.KeyPress += new KeyPressEventHandler(this.txtTo_KeyPress);
			this.label4.AutoSize = true;
			this.label4.Location = new Point(5, 86);
			this.label4.Margin = new System.Windows.Forms.Padding(0, 15, 15, 15);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(23, 13);
			this.label4.TabIndex = 123;
			this.label4.Text = "To:";
			this.txtemail.Location = new Point(363, 39);
			this.txtemail.Margin = new System.Windows.Forms.Padding(5);
			this.txtemail.Name = "txtemail";
			this.txtemail.Size = new System.Drawing.Size(213, 20);
			this.txtemail.TabIndex = 2;
			this.txtemail.Leave += new EventHandler(this.txtemail_Leave);
			this.txtemail.KeyPress += new KeyPressEventHandler(this.txtemail_KeyPress);
			this.label3.AutoSize = true;
			this.label3.Location = new Point(308, 46);
			this.label3.Margin = new System.Windows.Forms.Padding(0, 15, 15, 15);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(35, 13);
			this.label3.TabIndex = 2;
			this.label3.Text = "Email:";
			this.lblName.AutoSize = true;
			this.lblName.Location = new Point(5, 20);
			this.lblName.Margin = new System.Windows.Forms.Padding(0, 15, 15, 15);
			this.lblName.Name = "lblName";
			this.lblName.Size = new System.Drawing.Size(38, 13);
			this.lblName.TabIndex = 112;
			this.lblName.Text = "Name:";
			this.cmbName.DropDownStyle = ComboBoxStyle.DropDownList;
			this.cmbName.DropDownWidth = 220;
			this.cmbName.FormattingEnabled = true;
			ComboBox.ObjectCollection items = this.cmbName.Items;
			object[] objArray = new object[] { "Manufacture", "Sales man", "Vendor", "Other" };
			items.AddRange(objArray);
			this.cmbName.Location = new Point(63, 12);
			this.cmbName.Margin = new System.Windows.Forms.Padding(5);
			this.cmbName.Name = "cmbName";
			this.cmbName.Size = new System.Drawing.Size(218, 21);
			this.cmbName.TabIndex = 0;
			this.cmbName.SelectedIndexChanged += new EventHandler(this.cmbName_SelectedIndexChanged);
			this.cmbName.KeyPress += new KeyPressEventHandler(this.cmbName_KeyPress);
			this.cmbName.KeyDown += new KeyEventHandler(this.cmbName_KeyDown);
			this.bwrk1.DoWork += new DoWorkEventHandler(this.bwrk1_DoWork);
			this.bwrk1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.bwrk1_RunWorkerCompleted);
			this.txtBody.Location = new Point(76, 232);
			this.txtBody.Margin = new System.Windows.Forms.Padding(5);
			this.txtBody.Multiline = true;
			this.txtBody.Name = "txtBody";
			this.txtBody.Size = new System.Drawing.Size(562, 141);
			this.txtBody.TabIndex = 7;
			this.txtBody.Enter += new EventHandler(this.txtBody_Enter);
			this.txtBody.KeyPress += new KeyPressEventHandler(this.txtBody_KeyPress);
			this.panel1.BackColor = Color.Transparent;
			this.panel1.BackgroundImage = (Image)componentResourceManager.GetObject("panel1.BackgroundImage");
			this.panel1.BackgroundImageLayout = ImageLayout.Stretch;
			this.panel1.Controls.Add(this.btnSend);
			this.panel1.Controls.Add(this.btnClear);
			this.panel1.Controls.Add(this.btnClose);
			this.panel1.Controls.Add(this.panel8);
			this.panel1.Controls.Add(this.panel6);
			this.panel1.Controls.Add(this.panel5);
			this.panel1.Controls.Add(this.panel4);
			this.panel1.Controls.Add(this.panel3);
			this.panel1.Controls.Add(this.panel9);
			this.panel1.Dock = DockStyle.Fill;
			this.panel1.Location = new Point(7, 7);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(653, 476);
			this.panel1.TabIndex = 0;
			this.btnSend.BackColor = Color.FromArgb(255, 209, 150);
			this.btnSend.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 1);
			this.btnSend.FlatStyle = FlatStyle.Flat;
			this.btnSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.btnSend.Location = new Point(402, 423);
			this.btnSend.Name = "btnSend";
			this.btnSend.Size = new System.Drawing.Size(75, 23);
			this.btnSend.TabIndex = 1;
			this.btnSend.Text = "S&end";
			this.btnSend.UseVisualStyleBackColor = false;
			this.btnSend.Click += new EventHandler(this.btnSend_Click);
			this.btnClear.BackColor = Color.FromArgb(255, 209, 150);
			this.btnClear.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 1);
			this.btnClear.FlatStyle = FlatStyle.Flat;
			this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.btnClear.Location = new Point(483, 423);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(75, 23);
			this.btnClear.TabIndex = 2;
			this.btnClear.Text = "C&lear";
			this.btnClear.UseVisualStyleBackColor = false;
			this.btnClear.Click += new EventHandler(this.btnClear_Click);
			this.btnClose.BackColor = Color.FromArgb(255, 209, 150);
			this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnClose.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 1);
			this.btnClose.FlatStyle = FlatStyle.Flat;
			this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.btnClose.Location = new Point(564, 423);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(75, 23);
			this.btnClose.TabIndex = 3;
			this.btnClose.Text = "&Close";
			this.btnClose.UseVisualStyleBackColor = false;
			this.btnClose.Click += new EventHandler(this.btnClose_Click);
			this.panel8.BackgroundImage = (Image)componentResourceManager.GetObject("panel8.BackgroundImage");
			this.panel8.BackgroundImageLayout = ImageLayout.Stretch;
			this.panel8.Controls.Add(this.txtBody);
			this.panel8.Controls.Add(this.btnFileattach);
			this.panel8.Controls.Add(this.label1);
			this.panel8.Controls.Add(this.lstbxAttach);
			this.panel8.Controls.Add(this.btnAdd);
			this.panel8.Controls.Add(this.label8);
			this.panel8.Controls.Add(this.lblName);
			this.panel8.Controls.Add(this.label7);
			this.panel8.Controls.Add(this.cmbDetails);
			this.panel8.Controls.Add(this.txtSubject);
			this.panel8.Controls.Add(this.cmbName);
			this.panel8.Controls.Add(this.txtemail);
			this.panel8.Controls.Add(this.label6);
			this.panel8.Controls.Add(this.label3);
			this.panel8.Controls.Add(this.txtBCC);
			this.panel8.Controls.Add(this.txtTo);
			this.panel8.Controls.Add(this.label5);
			this.panel8.Controls.Add(this.label4);
			this.panel8.Controls.Add(this.txtCC);
			this.panel8.Dock = DockStyle.Top;
			this.panel8.Location = new Point(1, 34);
			this.panel8.Name = "panel8";
			this.panel8.Padding = new System.Windows.Forms.Padding(5);
			this.panel8.Size = new System.Drawing.Size(651, 383);
			this.panel8.TabIndex = 1;
			this.label1.AutoSize = true;
			this.label1.Location = new Point(8, 59);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(634, 13);
			this.label1.TabIndex = 135;
			this.label1.Text = componentResourceManager.GetString("label1.Text");
			this.btnAdd.BackColor = Color.SteelBlue;
			this.btnAdd.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 1);
			this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.btnAdd.ForeColor = Color.White;
			this.btnAdd.Location = new Point(584, 36);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(54, 23);
			this.btnAdd.TabIndex = 3;
			this.btnAdd.Text = "Add";
			this.btnAdd.UseVisualStyleBackColor = false;
			this.btnAdd.Click += new EventHandler(this.btnAdd_Click);
			this.btnAdd.KeyPress += new KeyPressEventHandler(this.btnAdd_KeyPress);
			this.panel6.BackgroundImage = (Image)componentResourceManager.GetObject("panel6.BackgroundImage");
			this.panel6.Controls.Add(this.label18);
			this.panel6.Controls.Add(this.panel7);
			this.panel6.Dock = DockStyle.Top;
			this.panel6.Location = new Point(1, 1);
			this.panel6.Name = "panel6";
			this.panel6.Size = new System.Drawing.Size(651, 33);
			this.panel6.TabIndex = 0;
			this.label18.AutoSize = true;
			this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label18.Location = new Point(11, 7);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(70, 15);
			this.label18.TabIndex = 4;
			this.label18.Text = "Draft Mail";
			this.panel7.BackColor = Color.FromArgb(136, 136, 136);
			this.panel7.Dock = DockStyle.Bottom;
			this.panel7.Location = new Point(0, 32);
			this.panel7.Name = "panel7";
			this.panel7.Size = new System.Drawing.Size(651, 1);
			this.panel7.TabIndex = 0;
			this.panel5.BackColor = Color.FromArgb(136, 136, 136);
			this.panel5.Dock = DockStyle.Bottom;
			this.panel5.Location = new Point(1, 475);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(651, 1);
			this.panel5.TabIndex = 2;
			this.panel4.BackColor = Color.FromArgb(136, 136, 136);
			this.panel4.Dock = DockStyle.Top;
			this.panel4.Location = new Point(1, 0);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(651, 1);
			this.panel4.TabIndex = 1;
			this.panel3.BackColor = Color.FromArgb(136, 136, 136);
			this.panel3.Dock = DockStyle.Right;
			this.panel3.Location = new Point(652, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(1, 476);
			this.panel3.TabIndex = 1;
			this.panel9.BackColor = Color.FromArgb(136, 136, 136);
			this.panel9.Dock = DockStyle.Left;
			this.panel9.Location = new Point(0, 0);
			this.panel9.Name = "panel9";
			this.panel9.Size = new System.Drawing.Size(1, 476);
			this.panel9.TabIndex = 0;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.BackColor = Color.White;
			this.BackgroundImageLayout = ImageLayout.Stretch;
			base.CancelButton = this.btnClose;
			base.ClientSize = new System.Drawing.Size(667, 490);
			base.Controls.Add(this.panel1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.Icon = (System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.Name = "frmSendMail";
			base.Padding = new System.Windows.Forms.Padding(7);
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "Draft Mail";
			base.Load += new EventHandler(this.frmSendMail_Load);
			this.panel1.ResumeLayout(false);
			this.panel8.ResumeLayout(false);
			this.panel8.PerformLayout();
			this.panel6.ResumeLayout(false);
			this.panel6.PerformLayout();
			base.ResumeLayout(false);
		}

		private void lstbxAttach_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				if (e.KeyCode == Keys.Delete)
				{
					this.lstbxAttach.Items.Remove(this.lstbxAttach.SelectedItem);
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void lstbxAttach_KeyPress(object sender, KeyPressEventArgs e)
		{
			this.ShortCuts(e);
		}

		public void SendAttachmentEmail()
		{
			try
			{
				System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;
				MailMessage mailMessage = new MailMessage()
				{
					From = "pharmizteam@gmail.com ",
					To = this.txtTo.Text.Trim()
				};
				if (this.txtBCC.Text != "")
				{
					mailMessage.Bcc = this.txtBCC.Text.Trim();
				}
				if (this.txtCC.Text != "")
				{
					mailMessage.Cc = this.txtCC.Text.Trim();
				}
				mailMessage.Subject = this.txtSubject.Text.Trim();
				mailMessage.BodyFormat = MailFormat.Text;
				mailMessage.Body = this.txtBody.Text;
				foreach (string item in this.lstbxAttach.Items)
				{
					MailAttachment mailAttachment = new MailAttachment(item);
					mailMessage.Attachments.Add(mailAttachment);
				}
				mailMessage.Priority = MailPriority.High;
				SmtpMail.SmtpServer = "smtp.gmail.com";
				mailMessage.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "1");
				mailMessage.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", "pharmizteam@gmail.com");
				mailMessage.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", "medicalshop");
				mailMessage.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserverport", "465");
				mailMessage.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpusessl", "true");
				SmtpMail.Send(mailMessage);
				System.Windows.Forms.Cursor.Current = Cursors.Default;
				this.isSend = true;
				this.isCheck = true;
				MessageBox.Show("Mail sent successfully ", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			catch (Exception exception)
			{
				System.Windows.Forms.Cursor.Current = Cursors.Default;
				this.isSend = true;
				MessageBox.Show("Mail sending failed", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		public void ShortCuts(KeyPressEventArgs e)
		{
			try
			{
				if (e.KeyChar == '\r')
				{
					SendKeys.Send("{TAB}");
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void txtBCC_KeyPress(object sender, KeyPressEventArgs e)
		{
			this.ShortCuts(e);
		}

		private void txtBody_Enter(object sender, EventArgs e)
		{
			try
			{
				this.txtBody.Text = this.txtBody.Text.Trim();
				if (!(this.txtBody.Text == ""))
				{
					this.txtBody.SelectionStart = this.txtBody.Text.Length;
					this.txtBody.Focus();
				}
				else
				{
					this.txtBody.SelectionStart = 0;
					this.txtBody.Focus();
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void txtBody_KeyPress(object sender, KeyPressEventArgs e)
		{
			try
			{
				if (e.KeyChar != '\r')
				{
					this.inEnterCount = 0;
				}
				else
				{
					frmSendMail _frmSendMail = this;
					_frmSendMail.inEnterCount = _frmSendMail.inEnterCount + 1;
					if (this.inEnterCount == 2)
					{
						this.inEnterCount = 0;
						this.btnSend.Focus();
					}
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void txtCC_KeyPress(object sender, KeyPressEventArgs e)
		{
			this.ShortCuts(e);
		}

		private void txtemail_KeyPress(object sender, KeyPressEventArgs e)
		{
			try
			{
				this.ShortCuts(e);
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void txtemail_Leave(object sender, EventArgs e)
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

		private void txtSubject_KeyPress(object sender, KeyPressEventArgs e)
		{
			this.ShortCuts(e);
		}

		private void txtTo_KeyPress(object sender, KeyPressEventArgs e)
		{
			this.ShortCuts(e);
		}

		public bool ValidateEmail()
		{
			bool flag = true;
			try
			{
				if ((this.txtBCC.Text.Trim() != "" ? true : this.txtCC.Text.Trim() != ""))
				{
					Regex regex = new Regex("\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*");
					if (this.txtCC.Text.Length > 0)
					{
						if (!regex.IsMatch(this.txtCC.Text))
						{
							MessageBox.Show("Invalid Email", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
							flag = false;
							this.txtCC.Focus();
						}
					}
					if (flag)
					{
						Regex regex1 = new Regex("\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*");
						if (this.txtBCC.Text.Length > 0)
						{
							if (!regex1.IsMatch(this.txtBCC.Text))
							{
								MessageBox.Show("Invalid Email", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
								flag = false;
								this.txtBCC.Focus();
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
			return flag;
		}
	}
}