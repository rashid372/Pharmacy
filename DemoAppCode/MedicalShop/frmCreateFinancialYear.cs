using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;

namespace MedicalShop
{
	public class frmCreateFinancialYear : Form
	{
		private FinacialYearSP financialyearsp = new FinacialYearSP();

		private bool isInEditMode = false;

		private string strFinacialYearId = "";

		private bool isFromCompanyForm = false;

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

		private DateTimePicker dtpFromDate;

		private Label label2;

		private DateTimePicker dtpToDate;

		private Label label8;

		private Button btnSave;

		private Button btnClose;

		private Button btnReset;

		public frmCreateFinancialYear()
		{
			this.InitializeComponent();
		}

		private void btnclose_Click(object sender, EventArgs e)
		{
			try
			{
				if (MessageBox.Show("Do you want to close ?", "Pharmacy", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
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
			bool month;
			try
			{
				if (!this.isInEditMode)
				{
					DateTimePicker dateTimePicker = this.dtpFromDate;
					DateTime today = DateTime.Today;
					dateTimePicker.Value = DateTime.Parse(string.Concat("01-Apr-", today.Year));
					if (this.dtpFromDate.Value.Year != DateTime.Today.Year)
					{
						month = true;
					}
					else
					{
						int num = DateTime.Today.Month;
						today = this.dtpFromDate.Value;
						month = num >= today.Month;
					}
					if (!month)
					{
						DateTimePicker dateTimePicker1 = this.dtpFromDate;
						today = this.dtpFromDate.Value;
						dateTimePicker1.Value = today.AddYears(-1);
					}
					DateTimePicker dateTimePicker2 = this.dtpToDate;
					today = this.dtpFromDate.Value;
					today = today.AddYears(1);
					dateTimePicker2.Value = today.AddDays(-1);
				}
				else
				{
					this.dtpFromDate.Value = FinacialYearInfo._fromDate;
					this.dtpToDate.Value = FinacialYearInfo._toDate;
					this.strFinacialYearId = this.financialyearsp.FinacialYearViewByDate(FinacialYearInfo._fromDate, FinacialYearInfo._toDate);
				}
				this.dtpFromDate.Focus();
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
				this.SaveOrEdit();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		public void CallThisFormFromCompanyCreation(bool isFromCompany)
		{
			bool month;
			DateTimePicker dateTimePicker = this.dtpFromDate;
			DateTime today = DateTime.Today;
			dateTimePicker.Value = DateTime.Parse(string.Concat("01-Apr-", today.Year));
			if (this.dtpFromDate.Value.Year != DateTime.Today.Year)
			{
				month = true;
			}
			else
			{
				int num = DateTime.Today.Month;
				today = this.dtpFromDate.Value;
				month = num >= today.Month;
			}
			if (!month)
			{
				DateTimePicker dateTimePicker1 = this.dtpFromDate;
				today = this.dtpFromDate.Value;
				dateTimePicker1.Value = today.AddYears(-1);
			}
			this.isFromCompanyForm = isFromCompany;
			DateTimePicker dateTimePicker2 = this.dtpToDate;
			today = this.dtpFromDate.Value;
			today = today.AddYears(1);
			dateTimePicker2.Value = today.AddDays(-1);
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.ControlBox = false;
			this.btnClose.Enabled = false;
			base.ShowDialog();
		}

		public void CallThisFormFromMDI(bool isEditMode)
		{
			bool month;
			this.isInEditMode = isEditMode;
			if (!isEditMode)
			{
				DateTimePicker dateTimePicker = this.dtpFromDate;
				DateTime today = DateTime.Today;
				dateTimePicker.Value = DateTime.Parse(string.Concat("01-Apr-", today.Year));
				if (this.dtpFromDate.Value.Year != DateTime.Today.Year)
				{
					month = true;
				}
				else
				{
					int num = DateTime.Today.Month;
					today = this.dtpFromDate.Value;
					month = num >= today.Month;
				}
				if (!month)
				{
					DateTimePicker dateTimePicker1 = this.dtpFromDate;
					today = this.dtpFromDate.Value;
					dateTimePicker1.Value = today.AddYears(-1);
				}
				DateTimePicker dateTimePicker2 = this.dtpToDate;
				today = this.dtpFromDate.Value;
				today = today.AddYears(1);
				dateTimePicker2.Value = today.AddDays(-1);
			}
			else
			{
				this.dtpFromDate.Value = FinacialYearInfo._fromDate;
				this.dtpToDate.Value = FinacialYearInfo._toDate;
				this.strFinacialYearId = this.financialyearsp.FinacialYearViewByDate(FinacialYearInfo._fromDate, FinacialYearInfo._toDate);
			}
		}

		public bool CheckDuplicateFinancialYear()
		{
			bool flag = true;
			DataTable dataTable = this.financialyearsp.FinacialYearGetBetweenDate(DateTime.Parse(this.dtpFromDate.Text), DateTime.Parse(this.dtpToDate.Text));
			if (dataTable.Rows.Count == 0)
			{
				flag = false;
			}
			else if ((dataTable.Rows.Count != 1 ? true : !this.isInEditMode))
			{
				flag = true;
			}
			else
			{
				flag = (!(dataTable.Rows[0][0].ToString() == this.strFinacialYearId) ? true : false);
			}
			return flag;
		}

		public bool CheckWhetherActiveFinacialYearExist()
		{
			bool flag = true;
			if (this.financialyearsp.FinancialYearViewallActingYear().Rows.Count == 0)
			{
				flag = false;
			}
			return flag;
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
				if (e.KeyCode == Keys.Return)
				{
					this.dtpToDate.Focus();
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void dtpToDate_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				if (e.KeyCode == Keys.Return)
				{
					this.btnSave.Focus();
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void frmFinacialYear_Load(object sender, EventArgs e)
		{
			try
			{
				this.dtpFromDate.Focus();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void InitializeComponent()
		{
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmCreateFinancialYear));
			this.panel1 = new Panel();
			this.panel8 = new Panel();
			this.btnReset = new Button();
			this.btnSave = new Button();
			this.btnClose = new Button();
			this.label2 = new Label();
			this.dtpToDate = new DateTimePicker();
			this.label8 = new Label();
			this.dtpFromDate = new DateTimePicker();
			this.panel6 = new Panel();
			this.label1 = new Label();
			this.panel7 = new Panel();
			this.panel5 = new Panel();
			this.panel4 = new Panel();
			this.panel3 = new Panel();
			this.panel2 = new Panel();
			this.panel1.SuspendLayout();
			this.panel8.SuspendLayout();
			this.panel6.SuspendLayout();
			base.SuspendLayout();
			this.panel1.BackColor = Color.Transparent;
			this.panel1.BackgroundImage = (Image)componentResourceManager.GetObject("panel1.BackgroundImage");
			this.panel1.BackgroundImageLayout = ImageLayout.Stretch;
			this.panel1.Controls.Add(this.panel8);
			this.panel1.Controls.Add(this.panel6);
			this.panel1.Controls.Add(this.panel5);
			this.panel1.Controls.Add(this.panel4);
			this.panel1.Controls.Add(this.panel3);
			this.panel1.Controls.Add(this.panel2);
			this.panel1.Dock = DockStyle.Fill;
			this.panel1.Location = new Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(268, 175);
			this.panel1.TabIndex = 3;
			this.panel8.BackgroundImage = (Image)componentResourceManager.GetObject("panel8.BackgroundImage");
			this.panel8.BackgroundImageLayout = ImageLayout.Stretch;
			this.panel8.Controls.Add(this.btnReset);
			this.panel8.Controls.Add(this.btnSave);
			this.panel8.Controls.Add(this.btnClose);
			this.panel8.Controls.Add(this.label2);
			this.panel8.Controls.Add(this.dtpToDate);
			this.panel8.Controls.Add(this.label8);
			this.panel8.Controls.Add(this.dtpFromDate);
			this.panel8.Dock = DockStyle.Top;
			this.panel8.Location = new Point(1, 34);
			this.panel8.Name = "panel8";
			this.panel8.Padding = new System.Windows.Forms.Padding(5);
			this.panel8.Size = new System.Drawing.Size(266, 117);
			this.panel8.TabIndex = 0;
			this.btnReset.BackColor = Color.FromArgb(255, 209, 150);
			this.btnReset.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 1);
			this.btnReset.FlatStyle = FlatStyle.Flat;
			this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.btnReset.ForeColor = Color.Black;
			this.btnReset.Location = new Point(97, 86);
			this.btnReset.Margin = new System.Windows.Forms.Padding(5, 5, 5, 0);
			this.btnReset.Name = "btnReset";
			this.btnReset.Size = new System.Drawing.Size(75, 23);
			this.btnReset.TabIndex = 18;
			this.btnReset.Text = "&Reset";
			this.btnReset.UseVisualStyleBackColor = false;
			this.btnReset.Click += new EventHandler(this.btnReset_Click);
			this.btnSave.BackColor = Color.FromArgb(255, 209, 150);
			this.btnSave.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 1);
			this.btnSave.FlatStyle = FlatStyle.Flat;
			this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.btnSave.Location = new Point(12, 86);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(75, 23);
			this.btnSave.TabIndex = 17;
			this.btnSave.Text = "&Save";
			this.btnSave.UseVisualStyleBackColor = false;
			this.btnSave.Click += new EventHandler(this.btnSave_Click);
			this.btnClose.BackColor = Color.FromArgb(255, 209, 150);
			this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnClose.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 1);
			this.btnClose.FlatStyle = FlatStyle.Flat;
			this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.btnClose.Location = new Point(180, 86);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(75, 23);
			this.btnClose.TabIndex = 19;
			this.btnClose.Text = "&Close";
			this.btnClose.UseVisualStyleBackColor = false;
			this.btnClose.Click += new EventHandler(this.btnclose_Click);
			this.label2.AutoSize = true;
			this.label2.Location = new Point(11, 47);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(55, 13);
			this.label2.TabIndex = 16;
			this.label2.Text = "End Date:";
			this.dtpToDate.CustomFormat = "dd-MMM-yyyy";
			this.dtpToDate.Format = DateTimePickerFormat.Custom;
			this.dtpToDate.Location = new Point(121, 40);
			this.dtpToDate.Name = "dtpToDate";
			this.dtpToDate.Size = new System.Drawing.Size(134, 20);
			this.dtpToDate.TabIndex = 15;
			this.dtpToDate.KeyDown += new KeyEventHandler(this.dtpToDate_KeyDown);
			this.label8.AutoSize = true;
			this.label8.Location = new Point(11, 21);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(58, 13);
			this.label8.TabIndex = 14;
			this.label8.Text = "Start Date:";
			this.dtpFromDate.CustomFormat = "dd-MMM-yyyy";
			this.dtpFromDate.Format = DateTimePickerFormat.Custom;
			this.dtpFromDate.Location = new Point(121, 14);
			this.dtpFromDate.Name = "dtpFromDate";
			this.dtpFromDate.Size = new System.Drawing.Size(134, 20);
			this.dtpFromDate.TabIndex = 0;
			this.dtpFromDate.KeyDown += new KeyEventHandler(this.dtpFromDate_KeyDown);
			this.panel6.BackgroundImage = (Image)componentResourceManager.GetObject("panel6.BackgroundImage");
			this.panel6.Controls.Add(this.label1);
			this.panel6.Controls.Add(this.panel7);
			this.panel6.Dock = DockStyle.Top;
			this.panel6.Location = new Point(1, 1);
			this.panel6.Name = "panel6";
			this.panel6.Size = new System.Drawing.Size(266, 33);
			this.panel6.TabIndex = 3;
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label1.Location = new Point(11, 7);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(99, 15);
			this.label1.TabIndex = 4;
			this.label1.Text = "Financial Year";
			this.panel7.BackColor = Color.FromArgb(136, 136, 136);
			this.panel7.Dock = DockStyle.Bottom;
			this.panel7.Location = new Point(0, 32);
			this.panel7.Name = "panel7";
			this.panel7.Size = new System.Drawing.Size(266, 1);
			this.panel7.TabIndex = 3;
			this.panel5.BackColor = Color.FromArgb(136, 136, 136);
			this.panel5.Dock = DockStyle.Bottom;
			this.panel5.Location = new Point(1, 174);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(266, 1);
			this.panel5.TabIndex = 2;
			this.panel4.BackColor = Color.FromArgb(136, 136, 136);
			this.panel4.Dock = DockStyle.Top;
			this.panel4.Location = new Point(1, 0);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(266, 1);
			this.panel4.TabIndex = 1;
			this.panel3.BackColor = Color.FromArgb(136, 136, 136);
			this.panel3.Dock = DockStyle.Right;
			this.panel3.Location = new Point(267, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(1, 175);
			this.panel3.TabIndex = 1;
			this.panel2.BackColor = Color.FromArgb(136, 136, 136);
			this.panel2.Dock = DockStyle.Left;
			this.panel2.Location = new Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(1, 175);
			this.panel2.TabIndex = 0;
			base.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.BackColor = Color.White;
			base.CancelButton = this.btnClose;
			base.ClientSize = new System.Drawing.Size(268, 175);
			base.Controls.Add(this.panel1);
			base.Icon = (System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.Name = "frmCreateFinancialYear";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "Financial Year";
			base.Load += new EventHandler(this.frmFinacialYear_Load);
			this.panel1.ResumeLayout(false);
			this.panel8.ResumeLayout(false);
			this.panel8.PerformLayout();
			this.panel6.ResumeLayout(false);
			this.panel6.PerformLayout();
			base.ResumeLayout(false);
		}

		public void SaveOrEdit()
		{
			if ((this.isInEditMode ? true : !this.isFromCompanyForm))
			{
                FinacialYearInfo finacialYearInfo = new FinacialYearInfo();
                //MessageBox.Show("Thank you for using Pharmacy.To gain access please buy full version", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.financialyearsp.FinacialYearAdd(finacialYearInfo);
                MessageBox.Show("Saved successfully", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                base.Close();
            }
			else
			{
				FinacialYearInfo finacialYearInfo = new FinacialYearInfo()
				{
					FromDate = DateTime.Parse(this.dtpFromDate.Text),
					ToDate = DateTime.Parse(this.dtpToDate.Text),
					ActiveOrNot = true
				};
				this.financialyearsp.FinacialYearAdd(finacialYearInfo);
				MessageBox.Show("Saved successfully", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				base.Close();
			}
		}
	}
}