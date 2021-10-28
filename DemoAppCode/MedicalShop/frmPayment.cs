using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;

namespace MedicalShop
{
	public class frmPayment : Form
	{
		private LedgerPostingSP ledgerpostingsp = new LedgerPostingSP();

		private PaymentMasterSP mastersp = new PaymentMasterSP();

		private PaymentDetailsSP detailssp = new PaymentDetailsSP();

		private frmPaymentRegister frmregister;

		private bool isInEditMode = false;

		private bool isFormClose = false;

		private bool isCashCombo = false;

		private string strDefaultCurrency = "";

		private string strOldCashBankLedgerId = "";

		private string strOldAccountLedgeId = "";

		private int inDescriptionCount = 0;

		private DataTable dtbl = new DataTable();

		private string CashBankAccount = "";

		private string AccountLedger = "";

		private int _pageNo = 0;

		private int _page = 0;

		private bool nextPage = false;

		private IContainer components = null;

		private Panel panel1;

		private Button btnSave;

		private Button btnDelete;

		private Button btnClear;

		private Button btnClose;

		private Panel panel8;

		private TextBox txtDescription;

		private Label lblLedger;

		private TextBox txtVoucherNo;

		private Label lblVoucerNo;

		private Panel panel6;

		private Label label1;

		private Panel panel7;

		private Panel panel5;

		private Panel panel4;

		private Panel panel3;

		private Panel panel2;

		private RadioButton rbtnChecque;

		private RadioButton rbtnCash;

		private ComboBox cmbCashBankAccount;

		private DateTimePicker dtpchequedate;

		private GroupBox gpbCheque;

		private TextBox txtChequeNo;

		private TextBox txtAmount;

		private ComboBox cmbAccountLedger;

		private DateTimePicker dtpDate;

		private Label label5;

		private Label label7;

		private Label label6;

		private Label label9;

		private Label lblAccountLedger;

		private Button btnNewLedger;

		private Button btnNewCahLedger;

		private Label lblBlnceAmount;

		private Label label11;

		private CheckBox cbxPrint;

		private Label label10;

		private Label label13;

		public frmPayment()
		{
			this.InitializeComponent();
		}

		public void AssignCurrentBalance()
		{
			try
			{
				if ((this.cmbAccountLedger.SelectedValue == null ? true : !(this.cmbAccountLedger.SelectedValue.ToString() != "")))
				{
					this.lblBlnceAmount.Text = string.Concat("0.00 ", this.strDefaultCurrency);
					this.lblBlnceAmount.BackColor = Color.Black;
					this.lblBlnceAmount.BackColor = Color.Transparent;
				}
				else
				{
					DataTable dataTable = new DataTable();
					dataTable = this.ledgerpostingsp.LedgerPostingGetCurerntBalanceOfLedger(this.cmbAccountLedger.SelectedValue.ToString(), this.dtpDate.Value);
					if (dataTable.Rows.Count <= 0)
					{
						this.lblBlnceAmount.Text = string.Concat("0.00 ", this.strDefaultCurrency);
						this.lblBlnceAmount.ForeColor = Color.Black;
						this.lblBlnceAmount.BackColor = Color.Transparent;
					}
					else
					{
						decimal num = decimal.Parse(dataTable.Rows[0][0].ToString());
						num = Math.Round(num, 2);
						if ((dataTable.Rows[0][2].ToString() == null ? true : !(dataTable.Rows[0][2].ToString() != "")))
						{
							this.lblBlnceAmount.Text = string.Concat("0.00 ", this.strDefaultCurrency);
							this.lblBlnceAmount.ForeColor = Color.Black;
							this.lblBlnceAmount.BackColor = Color.Transparent;
						}
						else if (!(dataTable.Rows[0][2].ToString() == "false"))
						{
							this.lblBlnceAmount.Text = string.Concat(num.ToString(), " ", this.strDefaultCurrency, " Cr");
							this.lblBlnceAmount.ForeColor = Color.Green;
							this.lblBlnceAmount.BackColor = Color.Transparent;
						}
						else
						{
							this.lblBlnceAmount.Text = string.Concat(num.ToString(), " ", this.strDefaultCurrency, " Dr");
							this.lblBlnceAmount.ForeColor = Color.Red;
							this.lblBlnceAmount.BackColor = Color.Transparent;
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
				MessageBox.Show("Thank you for using Pharmacy.To gain access please buy full version", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void btnNewCahLedger_Click(object sender, EventArgs e)
		{
            frmAccountLedger  Accountledger = new  frmAccountLedger();
            this.Close();
            Accountledger.Show();
        }

		private void btnNewLedger_Click(object sender, EventArgs e)
		{
            frmAccountLedger Accountledger = new frmAccountLedger();
            this.Close();
            Accountledger.Show();
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

		public void ClearFunction()
		{
			try
			{
				this.GenerateVoucherNumber();
				this.FillCashBankAccountCombo();
				this.FillAccountLedgerCombo();
				this.lblBlnceAmount.Text = string.Concat("0.00 ", this.strDefaultCurrency);
				this.txtAmount.Text = "0.00";
				this.txtChequeNo.Clear();
				this.txtDescription.Clear();
				this.rbtnCash.Checked = true;
				this.btnDelete.Enabled = false;
				this.isCashCombo = false;
				this.strOldAccountLedgeId = "";
				this.strOldCashBankLedgerId = "";
				this.cmbCashBankAccount.SelectedIndex = -1;
				this.cmbAccountLedger.SelectedValue = 2;
				this.btnSave.Text = "&Save";
				this.btnClear.Text = "C&lear";
				if (this.isInEditMode)
				{
					this.isInEditMode = false;
					this.frmregister.Close();
				}
				this.cbxPrint.Checked = false;
				this.dtpDate.Focus();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void cmbAccountLedger_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				this.DropDowncomboAndCalender(e);
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void cmbAccountLedger_KeyPress(object sender, KeyPressEventArgs e)
		{
			try
			{
				if (e.KeyChar == '\r')
				{
					this.txtAmount.Focus();
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void cmbAccountLedger_Leave(object sender, EventArgs e)
		{
			try
			{
				if ((this.btnClose.Focused || this.btnClear.Focused || this.btnNewLedger.Focused || this.btnNewCahLedger.Focused || this.dtpDate.Focused || this.rbtnCash.Focused || this.rbtnChecque.Focused || this.cmbCashBankAccount.Focused ? false : !this.isFormClose))
				{
					if (this.cmbAccountLedger.SelectedValue == null)
					{
						this.cmbAccountLedger.Focus();
					}
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void cmbAccountLedger_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				this.AssignCurrentBalance();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void cmbCashBankAccount_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				this.DropDowncomboAndCalender(e);
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void cmbCashBankAccount_KeyPress(object sender, KeyPressEventArgs e)
		{
			try
			{
				if (e.KeyChar == '\r')
				{
					this.cmbAccountLedger.Focus();
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void cmbCashBankAccount_Leave(object sender, EventArgs e)
		{
			try
			{
				if ((this.btnClose.Focused || this.btnClear.Focused || this.btnNewLedger.Focused || this.btnNewCahLedger.Focused || this.dtpDate.Focused || this.rbtnCash.Focused || this.rbtnChecque.Focused ? false : !this.isFormClose))
				{
					if (this.cmbCashBankAccount.SelectedValue == null)
					{
						this.cmbCashBankAccount.Focus();
					}
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void cmbCashBankAccount_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				this.FillAccountLedgerCombo();
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

		public void DoLedgerPosting()
		{
			try
			{
				if (decimal.Parse(this.txtAmount.Text) > new decimal(0))
				{
					LedgerPostingInfo ledgerPostingInfo = new LedgerPostingInfo()
					{
						VoucherNumber = this.txtVoucherNo.Text,
						VoucherType = "Payment Voucher",
						Description = "By payment",
						Date = DateTime.Parse(this.dtpDate.Text)
					};
					if (this.isInEditMode)
					{
						DataTable dataTable = this.ledgerpostingsp.LedgerPostingViewByVoucherTypeAndVoucherNumber(ledgerPostingInfo.VoucherNumber, "Payment Voucher");
						ledgerPostingInfo.LedgerPostingId = dataTable.Rows[0][0].ToString();
						ledgerPostingInfo.LedgerId = this.cmbCashBankAccount.SelectedValue.ToString();
						ledgerPostingInfo.Credit = decimal.Parse(this.txtAmount.Text);
						ledgerPostingInfo.Debit = new decimal(0);
						this.ledgerpostingsp.LedgerPostingEdit(ledgerPostingInfo);
						ledgerPostingInfo.LedgerPostingId = dataTable.Rows[1][0].ToString();
						ledgerPostingInfo.LedgerId = this.cmbAccountLedger.SelectedValue.ToString();
						ledgerPostingInfo.Debit = decimal.Parse(this.txtAmount.Text);
						ledgerPostingInfo.Credit = new decimal(0);
						this.ledgerpostingsp.LedgerPostingEdit(ledgerPostingInfo);
					}
					else
					{
						ledgerPostingInfo.LedgerId = this.cmbCashBankAccount.SelectedValue.ToString();
						ledgerPostingInfo.Credit = decimal.Parse(this.txtAmount.Text);
						ledgerPostingInfo.Debit = new decimal(0);
						this.ledgerpostingsp.LedgerPostingAdd(ledgerPostingInfo);
						ledgerPostingInfo.LedgerId = this.cmbAccountLedger.SelectedValue.ToString();
						ledgerPostingInfo.Debit = decimal.Parse(this.txtAmount.Text);
						ledgerPostingInfo.Credit = new decimal(0);
						this.ledgerpostingsp.LedgerPostingAdd(ledgerPostingInfo);
					}
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		public void DoWhenComingFromRegister(frmPaymentRegister frm, string strVcouherNo)
		{
			try
			{
				this.frmregister = frm;
				this.isInEditMode = true;
				base.Show();
				this.txtVoucherNo.Text = strVcouherNo;
				PaymentMasterInfo paymentMasterInfo = new PaymentMasterInfo();
				PaymentDetailsInfo paymentDetailsInfo = new PaymentDetailsInfo();
				paymentMasterInfo = this.mastersp.PaymentMasterView(strVcouherNo);
				paymentDetailsInfo = this.detailssp.PaymentDetailsViewByMasterId(this.txtVoucherNo.Text);
				if (!(paymentMasterInfo.PaymentMode == "By Cash"))
				{
					this.rbtnChecque.Checked = true;
					this.txtChequeNo.Text = paymentDetailsInfo.ChequeNumber;
					this.dtpchequedate.Value = paymentDetailsInfo.ChequeDate;
				}
				else
				{
					this.rbtnCash.Checked = true;
				}
				this.FillCashBankAccountCombo();
				this.FillAccountLedgerCombo();
				this.btnClear.Text = "&New";
				this.btnSave.Text = "&Update";
				this.dtpDate.Value = paymentMasterInfo.Date;
				this.cmbCashBankAccount.SelectedValue = paymentMasterInfo.LedgerId;
				this.txtDescription.Text = paymentMasterInfo.Description;
				string str = paymentDetailsInfo.Amount.ToString();
				this.txtAmount.Text = double.Parse(str).ToString();
				this.cmbAccountLedger.SelectedValue = paymentDetailsInfo.LedgerId;
				this.btnDelete.Enabled = true;
				base.Activate();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		public void DoWhenQuitingForm()
		{
			try
			{
				if (this.isInEditMode)
				{
					this.frmregister.DoWhenComingFromPayment();
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		public void DropDowncomboAndCalender(KeyEventArgs e)
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

		private void dtpchequedate_KeyPress(object sender, KeyPressEventArgs e)
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

		private void dtpDate_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				this.DropDowncomboAndCalender(e);
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void dtpDate_KeyPress(object sender, KeyPressEventArgs e)
		{
			try
			{
				if (e.KeyChar == '\r')
				{
					this.cmbCashBankAccount.Focus();
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		public void FillAccountLedgerCombo()
		{
			try
			{
				AccountLedgerSP accountLedgerSP = new AccountLedgerSP();
				string str = "";
				if (this.cmbCashBankAccount.SelectedValue != null)
				{
					str = this.cmbCashBankAccount.SelectedValue.ToString();
				}
				this.dtbl = accountLedgerSP.AccountLedgerViewAll();
				foreach (DataRow row in this.dtbl.Rows)
				{
					if (row.ItemArray[0].ToString() == str)
					{
						this.dtbl.Rows.Remove(row);
						break;
					}
				}
				this.cmbAccountLedger.DataSource = this.dtbl;
				this.cmbAccountLedger.DisplayMember = this.dtbl.Columns[1].ToString();
				this.cmbAccountLedger.ValueMember = this.dtbl.Columns[0].ToString();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		public void FillCashBankAccountCombo()
		{
			try
			{
				AccountLedgerSP accountLedgerSP = new AccountLedgerSP();
				DataTable dataTable = new DataTable();
				if (!this.rbtnCash.Checked)
				{
					this.lblLedger.Text = "Bank Account";
					dataTable = accountLedgerSP.AccountLedgerViewUnderBank();
				}
				else
				{
					this.lblLedger.Text = "Cash Account";
					dataTable = accountLedgerSP.AccountLedgerViewUnderCash();
				}
				if (dataTable.Rows.Count > 0)
				{
				}
				this.cmbCashBankAccount.DataSource = dataTable;
				this.cmbCashBankAccount.DisplayMember = dataTable.Columns[1].ToString();
				this.cmbCashBankAccount.ValueMember = dataTable.Columns[0].ToString();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void frmPayment_FormClosing(object sender, FormClosingEventArgs e)
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

		private void frmPayment_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				if (e.KeyCode == Keys.F2)
				{
					try
					{
						Process.Start("calc");
					}
					catch (Exception exception)
					{
						MessageBox.Show("Can't run calculator", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					}
				}
			}
			catch (Exception exception2)
			{
				Exception exception1 = exception2;
				MessageBox.Show(exception1.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void frmPayment_Load(object sender, EventArgs e)
		{
			try
			{
				if (!this.isInEditMode)
				{
					this.ClearFunction();
				}
				this.dtpDate.MinDate = FinacialYearInfo._fromDate;
				this.dtpDate.MaxDate = FinacialYearInfo._toDate;
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		public void GenerateVoucherNumber()
		{
			string str = this.mastersp.PaymentMasterGetMax();
			this.txtVoucherNo.Text = str;
		}

		private void InitializeComponent()
		{
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmPayment));
			this.panel1 = new Panel();
			this.cbxPrint = new CheckBox();
			this.btnSave = new Button();
			this.btnDelete = new Button();
			this.btnClear = new Button();
			this.btnClose = new Button();
			this.panel8 = new Panel();
			this.label13 = new Label();
			this.label10 = new Label();
			this.lblBlnceAmount = new Label();
			this.label11 = new Label();
			this.label9 = new Label();
			this.lblAccountLedger = new Label();
			this.btnNewLedger = new Button();
			this.btnNewCahLedger = new Button();
			this.dtpDate = new DateTimePicker();
			this.label5 = new Label();
			this.gpbCheque = new GroupBox();
			this.label7 = new Label();
			this.label6 = new Label();
			this.dtpchequedate = new DateTimePicker();
			this.txtChequeNo = new TextBox();
			this.txtAmount = new TextBox();
			this.cmbAccountLedger = new ComboBox();
			this.cmbCashBankAccount = new ComboBox();
			this.rbtnChecque = new RadioButton();
			this.rbtnCash = new RadioButton();
			this.txtDescription = new TextBox();
			this.lblLedger = new Label();
			this.txtVoucherNo = new TextBox();
			this.lblVoucerNo = new Label();
			this.panel6 = new Panel();
			this.label1 = new Label();
			this.panel7 = new Panel();
			this.panel5 = new Panel();
			this.panel4 = new Panel();
			this.panel3 = new Panel();
			this.panel2 = new Panel();
			this.panel1.SuspendLayout();
			this.panel8.SuspendLayout();
			this.gpbCheque.SuspendLayout();
			this.panel6.SuspendLayout();
			base.SuspendLayout();
			this.panel1.BackColor = Color.Transparent;
			this.panel1.BackgroundImage = (Image)componentResourceManager.GetObject("panel1.BackgroundImage");
			this.panel1.BackgroundImageLayout = ImageLayout.Stretch;
			this.panel1.Controls.Add(this.cbxPrint);
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
			this.panel1.Size = new System.Drawing.Size(650, 317);
			this.panel1.TabIndex = 2;
			this.cbxPrint.AutoSize = true;
			this.cbxPrint.Location = new Point(12, 278);
			this.cbxPrint.Name = "cbxPrint";
			this.cbxPrint.Size = new System.Drawing.Size(97, 17);
			this.cbxPrint.TabIndex = 48;
			this.cbxPrint.TabStop = false;
			this.cbxPrint.Text = "Print after save";
			this.cbxPrint.UseVisualStyleBackColor = true;
			this.btnSave.BackColor = Color.FromArgb(255, 209, 150);
			this.btnSave.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 1);
			this.btnSave.FlatStyle = FlatStyle.Flat;
			this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.btnSave.Location = new Point(323, 272);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(75, 23);
			this.btnSave.TabIndex = 8;
			this.btnSave.Text = "&Save";
			this.btnSave.UseVisualStyleBackColor = false;
			this.btnSave.Click += new EventHandler(this.btnSave_Click);
			this.btnDelete.BackColor = Color.FromArgb(255, 209, 150);
			this.btnDelete.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 1);
			this.btnDelete.FlatStyle = FlatStyle.Flat;
			this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.btnDelete.Location = new Point(404, 272);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(75, 23);
			this.btnDelete.TabIndex = 9;
			this.btnDelete.Text = "&Delete";
			this.btnDelete.UseVisualStyleBackColor = false;
			this.btnDelete.Click += new EventHandler(this.btnDelete_Click);
			this.btnClear.BackColor = Color.FromArgb(255, 209, 150);
			this.btnClear.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 1);
			this.btnClear.FlatStyle = FlatStyle.Flat;
			this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.btnClear.Location = new Point(485, 272);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(75, 23);
			this.btnClear.TabIndex = 10;
			this.btnClear.Text = "C&lear";
			this.btnClear.UseVisualStyleBackColor = false;
			this.btnClear.Click += new EventHandler(this.btnClear_Click);
			this.btnClose.BackColor = Color.FromArgb(255, 209, 150);
			this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnClose.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 1);
			this.btnClose.FlatStyle = FlatStyle.Flat;
			this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.btnClose.Location = new Point(566, 272);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(75, 23);
			this.btnClose.TabIndex = 11;
			this.btnClose.Text = "&Close";
			this.btnClose.UseVisualStyleBackColor = false;
			this.btnClose.Click += new EventHandler(this.btnClose_Click);
			this.panel8.BackgroundImage = (Image)componentResourceManager.GetObject("panel8.BackgroundImage");
			this.panel8.BackgroundImageLayout = ImageLayout.Stretch;
			this.panel8.Controls.Add(this.label13);
			this.panel8.Controls.Add(this.label10);
			this.panel8.Controls.Add(this.lblBlnceAmount);
			this.panel8.Controls.Add(this.label11);
			this.panel8.Controls.Add(this.label9);
			this.panel8.Controls.Add(this.lblAccountLedger);
			this.panel8.Controls.Add(this.btnNewLedger);
			this.panel8.Controls.Add(this.btnNewCahLedger);
			this.panel8.Controls.Add(this.dtpDate);
			this.panel8.Controls.Add(this.label5);
			this.panel8.Controls.Add(this.gpbCheque);
			this.panel8.Controls.Add(this.txtAmount);
			this.panel8.Controls.Add(this.cmbAccountLedger);
			this.panel8.Controls.Add(this.cmbCashBankAccount);
			this.panel8.Controls.Add(this.rbtnChecque);
			this.panel8.Controls.Add(this.rbtnCash);
			this.panel8.Controls.Add(this.txtDescription);
			this.panel8.Controls.Add(this.lblLedger);
			this.panel8.Controls.Add(this.txtVoucherNo);
			this.panel8.Controls.Add(this.lblVoucerNo);
			this.panel8.Dock = DockStyle.Top;
			this.panel8.Location = new Point(1, 34);
			this.panel8.Name = "panel8";
			this.panel8.Padding = new System.Windows.Forms.Padding(5);
			this.panel8.Size = new System.Drawing.Size(648, 232);
			this.panel8.TabIndex = 0;
			this.label13.AutoSize = true;
			this.label13.Location = new Point(445, 13);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(33, 13);
			this.label13.TabIndex = 51;
			this.label13.Text = "Date:";
			this.label10.AutoSize = true;
			this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label10.ForeColor = Color.Red;
			this.label10.Location = new Point(628, 100);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(12, 13);
			this.label10.TabIndex = 49;
			this.label10.Text = "*";
			this.lblBlnceAmount.AutoSize = true;
			this.lblBlnceAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.lblBlnceAmount.Location = new Point(251, 120);
			this.lblBlnceAmount.Name = "lblBlnceAmount";
			this.lblBlnceAmount.Size = new System.Drawing.Size(53, 13);
			this.lblBlnceAmount.TabIndex = 47;
			this.lblBlnceAmount.Text = "Balance";
			this.label11.AutoSize = true;
			this.label11.Location = new Point(131, 120);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(86, 13);
			this.label11.TabIndex = 46;
			this.label11.Text = "Current Balance:";
			this.label9.AutoSize = true;
			this.label9.Location = new Point(405, 100);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(46, 13);
			this.label9.TabIndex = 39;
			this.label9.Text = "Amount:";
			this.lblAccountLedger.AutoSize = true;
			this.lblAccountLedger.Location = new Point(8, 100);
			this.lblAccountLedger.Name = "lblAccountLedger";
			this.lblAccountLedger.Size = new System.Drawing.Size(47, 13);
			this.lblAccountLedger.TabIndex = 38;
			this.lblAccountLedger.Text = "Paid To:";
			this.btnNewLedger.BackColor = Color.SteelBlue;
			this.btnNewLedger.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 1);
			this.btnNewLedger.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.btnNewLedger.ForeColor = Color.White;
			this.btnNewLedger.Location = new Point(318, 95);
			this.btnNewLedger.Name = "btnNewLedger";
			this.btnNewLedger.Size = new System.Drawing.Size(54, 23);
			this.btnNewLedger.TabIndex = 37;
			this.btnNewLedger.TabStop = false;
			this.btnNewLedger.Text = "New";
			this.btnNewLedger.UseVisualStyleBackColor = false;
			this.btnNewLedger.Click += new EventHandler(this.btnNewLedger_Click);
			this.btnNewCahLedger.BackColor = Color.SteelBlue;
			this.btnNewCahLedger.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 1);
			this.btnNewCahLedger.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.btnNewCahLedger.ForeColor = Color.White;
			this.btnNewCahLedger.Location = new Point(318, 68);
			this.btnNewCahLedger.Name = "btnNewCahLedger";
			this.btnNewCahLedger.Size = new System.Drawing.Size(54, 23);
			this.btnNewCahLedger.TabIndex = 36;
			this.btnNewCahLedger.TabStop = false;
			this.btnNewCahLedger.Text = "New";
			this.btnNewCahLedger.UseVisualStyleBackColor = false;
			this.btnNewCahLedger.Click += new EventHandler(this.btnNewCahLedger_Click);
			this.dtpDate.CustomFormat = "dd-MMM-yyyy";
			this.dtpDate.Format = DateTimePickerFormat.Custom;
			this.dtpDate.Location = new Point(490, 8);
			this.dtpDate.Name = "dtpDate";
			this.dtpDate.Size = new System.Drawing.Size(131, 20);
			this.dtpDate.TabIndex = 0;
			this.dtpDate.KeyPress += new KeyPressEventHandler(this.dtpDate_KeyPress);
			this.dtpDate.KeyDown += new KeyEventHandler(this.dtpDate_KeyDown);
			this.label5.AutoSize = true;
			this.label5.Location = new Point(8, 144);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(63, 13);
			this.label5.TabIndex = 12;
			this.label5.Text = "Description:";
			this.gpbCheque.Controls.Add(this.label7);
			this.gpbCheque.Controls.Add(this.label6);
			this.gpbCheque.Controls.Add(this.dtpchequedate);
			this.gpbCheque.Controls.Add(this.txtChequeNo);
			this.gpbCheque.Location = new Point(399, 120);
			this.gpbCheque.Name = "gpbCheque";
			this.gpbCheque.Size = new System.Drawing.Size(241, 80);
			this.gpbCheque.TabIndex = 11;
			this.gpbCheque.TabStop = false;
			this.label7.AutoSize = true;
			this.label7.Location = new Point(6, 49);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(72, 13);
			this.label7.TabIndex = 14;
			this.label7.Text = "cheque Date:";
			this.label6.AutoSize = true;
			this.label6.Location = new Point(6, 23);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(64, 13);
			this.label6.TabIndex = 13;
			this.label6.Text = "Cheque No:";
			this.dtpchequedate.CustomFormat = "dd-MMM-yyyy";
			this.dtpchequedate.Format = DateTimePickerFormat.Custom;
			this.dtpchequedate.Location = new Point(101, 43);
			this.dtpchequedate.Name = "dtpchequedate";
			this.dtpchequedate.Size = new System.Drawing.Size(132, 20);
			this.dtpchequedate.TabIndex = 6;
			this.dtpchequedate.KeyPress += new KeyPressEventHandler(this.dtpchequedate_KeyPress);
			this.txtChequeNo.Location = new Point(101, 17);
			this.txtChequeNo.MaxLength = 50;
			this.txtChequeNo.Name = "txtChequeNo";
			this.txtChequeNo.Size = new System.Drawing.Size(132, 20);
			this.txtChequeNo.TabIndex = 5;
			this.txtChequeNo.KeyPress += new KeyPressEventHandler(this.txtChequeNo_KeyPress);
			this.txtAmount.Location = new Point(490, 92);
			this.txtAmount.MaxLength = 8;
			this.txtAmount.Name = "txtAmount";
			this.txtAmount.Size = new System.Drawing.Size(132, 20);
			this.txtAmount.TabIndex = 4;
			this.txtAmount.Enter += new EventHandler(this.txtAmount_Enter);
			this.txtAmount.Leave += new EventHandler(this.txtAmount_Leave);
			this.txtAmount.KeyPress += new KeyPressEventHandler(this.txtAmount_KeyPress);
			this.cmbAccountLedger.DropDownStyle = ComboBoxStyle.DropDownList;
			this.cmbAccountLedger.FormattingEnabled = true;
			this.cmbAccountLedger.Location = new Point(134, 92);
			this.cmbAccountLedger.Name = "cmbAccountLedger";
			this.cmbAccountLedger.Size = new System.Drawing.Size(178, 21);
			this.cmbAccountLedger.TabIndex = 3;
			this.cmbAccountLedger.Leave += new EventHandler(this.cmbAccountLedger_Leave);
			this.cmbAccountLedger.SelectedIndexChanged += new EventHandler(this.cmbAccountLedger_SelectedIndexChanged);
			this.cmbAccountLedger.KeyPress += new KeyPressEventHandler(this.cmbAccountLedger_KeyPress);
			this.cmbAccountLedger.KeyDown += new KeyEventHandler(this.cmbAccountLedger_KeyDown);
			this.cmbCashBankAccount.DropDownStyle = ComboBoxStyle.DropDownList;
			this.cmbCashBankAccount.FormattingEnabled = true;
			this.cmbCashBankAccount.Location = new Point(134, 65);
			this.cmbCashBankAccount.Name = "cmbCashBankAccount";
			this.cmbCashBankAccount.Size = new System.Drawing.Size(178, 21);
			this.cmbCashBankAccount.TabIndex = 2;
			this.cmbCashBankAccount.Leave += new EventHandler(this.cmbCashBankAccount_Leave);
			this.cmbCashBankAccount.SelectedIndexChanged += new EventHandler(this.cmbCashBankAccount_SelectedIndexChanged);
			this.cmbCashBankAccount.KeyPress += new KeyPressEventHandler(this.cmbCashBankAccount_KeyPress);
			this.cmbCashBankAccount.KeyDown += new KeyEventHandler(this.cmbCashBankAccount_KeyDown);
			this.rbtnChecque.AutoSize = true;
			this.rbtnChecque.Location = new Point(204, 11);
			this.rbtnChecque.Name = "rbtnChecque";
			this.rbtnChecque.Size = new System.Drawing.Size(77, 17);
			this.rbtnChecque.TabIndex = 7;
			this.rbtnChecque.TabStop = true;
			this.rbtnChecque.Text = "By Cheque";
			this.rbtnChecque.UseVisualStyleBackColor = true;
			this.rbtnChecque.CheckedChanged += new EventHandler(this.rbtnChecque_CheckedChanged);
			this.rbtnCash.AutoSize = true;
			this.rbtnCash.Location = new Point(134, 11);
			this.rbtnCash.Name = "rbtnCash";
			this.rbtnCash.Size = new System.Drawing.Size(64, 17);
			this.rbtnCash.TabIndex = 6;
			this.rbtnCash.TabStop = true;
			this.rbtnCash.Text = "By Cash";
			this.rbtnCash.UseVisualStyleBackColor = true;
			this.rbtnCash.CheckedChanged += new EventHandler(this.rbtnCash_CheckedChanged);
			this.txtDescription.Location = new Point(134, 141);
			this.txtDescription.Multiline = true;
			this.txtDescription.Name = "txtDescription";
			this.txtDescription.Size = new System.Drawing.Size(250, 55);
			this.txtDescription.TabIndex = 7;
			this.txtDescription.Enter += new EventHandler(this.txtDescription_Enter);
			this.txtDescription.KeyPress += new KeyPressEventHandler(this.txtDescription_KeyPress);
			this.lblLedger.AutoSize = true;
			this.lblLedger.Location = new Point(8, 73);
			this.lblLedger.Name = "lblLedger";
			this.lblLedger.Size = new System.Drawing.Size(106, 13);
			this.lblLedger.TabIndex = 4;
			this.lblLedger.Text = "Cash/Party Account:";
			this.txtVoucherNo.BackColor = Color.WhiteSmoke;
			this.txtVoucherNo.Location = new Point(134, 39);
			this.txtVoucherNo.Name = "txtVoucherNo";
			this.txtVoucherNo.ReadOnly = true;
			this.txtVoucherNo.Size = new System.Drawing.Size(250, 20);
			this.txtVoucherNo.TabIndex = 1;
			this.txtVoucherNo.TabStop = false;
			this.lblVoucerNo.AutoSize = true;
			this.lblVoucerNo.Location = new Point(8, 46);
			this.lblVoucerNo.Name = "lblVoucerNo";
			this.lblVoucerNo.Size = new System.Drawing.Size(67, 13);
			this.lblVoucerNo.TabIndex = 1;
			this.lblVoucerNo.Text = "Voucher No:";
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
			this.label1.Size = new System.Drawing.Size(62, 15);
			this.label1.TabIndex = 4;
			this.label1.Text = "Payment";
			this.panel7.BackColor = Color.FromArgb(136, 136, 136);
			this.panel7.Dock = DockStyle.Bottom;
			this.panel7.Location = new Point(0, 32);
			this.panel7.Name = "panel7";
			this.panel7.Size = new System.Drawing.Size(648, 1);
			this.panel7.TabIndex = 3;
			this.panel5.BackColor = Color.FromArgb(136, 136, 136);
			this.panel5.Dock = DockStyle.Bottom;
			this.panel5.Location = new Point(1, 316);
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
			this.panel3.Size = new System.Drawing.Size(1, 317);
			this.panel3.TabIndex = 1;
			this.panel2.BackColor = Color.FromArgb(136, 136, 136);
			this.panel2.Dock = DockStyle.Left;
			this.panel2.Location = new Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(1, 317);
			this.panel2.TabIndex = 0;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.BackColor = Color.White;
			base.CancelButton = this.btnClose;
			base.ClientSize = new System.Drawing.Size(664, 331);
			base.Controls.Add(this.panel1);
			base.Icon = (System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.KeyPreview = true;
			base.MaximizeBox = false;
			base.Name = "frmPayment";
			base.Padding = new System.Windows.Forms.Padding(7);
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "Payment";
			base.FormClosing += new FormClosingEventHandler(this.frmPayment_FormClosing);
			base.KeyDown += new KeyEventHandler(this.frmPayment_KeyDown);
			base.Load += new EventHandler(this.frmPayment_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel8.ResumeLayout(false);
			this.panel8.PerformLayout();
			this.gpbCheque.ResumeLayout(false);
			this.gpbCheque.PerformLayout();
			this.panel6.ResumeLayout(false);
			this.panel6.PerformLayout();
			base.ResumeLayout(false);
		}

		protected override bool ProcessDialogKey(Keys keyData)
		{
			bool flag;
			if (keyData != Keys.Tab)
			{
				base.ProcessDialogKey(keyData);
				flag = false;
			}
			else if (!this.txtAmount.Focused)
			{
				base.ProcessDialogKey(keyData);
				flag = true;
			}
			else
			{
				this.txtDescription.Focus();
				flag = false;
			}
			return flag;
		}

		private void rbtnCash_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				this.FillCashBankAccountCombo();
				if (!this.rbtnCash.Checked)
				{
					this.gpbCheque.Enabled = true;
				}
				else
				{
					this.gpbCheque.Enabled = false;
				}
				this.FillAccountLedgerCombo();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void rbtnChecque_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				this.FillCashBankAccountCombo();
				if (!this.rbtnCash.Checked)
				{
					this.gpbCheque.Enabled = true;
				}
				else
				{
					this.gpbCheque.Enabled = false;
					this.txtChequeNo.Text = "";
				}
				this.FillAccountLedgerCombo();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		public void SaveOrEdit()
		{
			try
			{
				if (!FinacialYearInfo._activeOrNot)
				{
					MessageBox.Show("Selected finacial year has been closed", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
				else if (!(this.cmbCashBankAccount.SelectedValue == null || this.cmbCashBankAccount.SelectedValue.ToString() == "" ? false : this.cmbCashBankAccount.SelectedIndex != -1))
				{
					if (!this.rbtnCash.Checked)
					{
						MessageBox.Show("Select bank account", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					}
					else
					{
						MessageBox.Show("Select cash account", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					}
					this.cmbCashBankAccount.Focus();
				}
				else if (!(this.cmbAccountLedger.SelectedValue == null || this.cmbAccountLedger.SelectedValue.ToString() == "" ? false : this.cmbAccountLedger.SelectedIndex != -1))
				{
					MessageBox.Show("Select account ledger", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					this.cmbAccountLedger.Focus();
				}
				else if ((!this.rbtnChecque.Checked ? true : !(this.txtChequeNo.Text.Trim() == "")))
				{
					this.txtAmount.Text = this.txtAmount.Text.Trim();
					this.txtDescription.Text = this.txtDescription.Text.Trim();
					this.txtChequeNo.Text = this.txtChequeNo.Text.Trim();
					if ((this.txtAmount.Text.Trim() == "" ? false : !(decimal.Parse(this.txtAmount.Text) == new decimal(0))))
					{
						PaymentMasterInfo paymentMasterInfo = new PaymentMasterInfo();
						PaymentDetailsInfo paymentDetailsInfo = new PaymentDetailsInfo();
						paymentMasterInfo.Date = DateTime.Parse(this.dtpDate.Text);
						paymentMasterInfo.LedgerId = this.cmbCashBankAccount.SelectedValue.ToString();
						paymentMasterInfo.Description = this.txtDescription.Text;
						paymentMasterInfo.PaymentMode = "By Cash";
						if (this.rbtnChecque.Checked)
						{
							paymentMasterInfo.PaymentMode = "By Cheque";
						}
						if (this.isInEditMode)
						{
							paymentDetailsInfo = this.detailssp.PaymentDetailsViewByMasterId(this.txtVoucherNo.Text);
							paymentDetailsInfo.PaymentDetailsId = paymentDetailsInfo.PaymentDetailsId;
						}
						paymentDetailsInfo.PaymentMasterId = this.txtVoucherNo.Text;
						paymentDetailsInfo.Amount = decimal.Parse(this.txtAmount.Text);
						paymentDetailsInfo.ChequeDate = DateTime.Parse(this.dtpchequedate.Text);
						paymentDetailsInfo.ChequeNumber = this.txtChequeNo.Text;
						paymentDetailsInfo.VoucherNumber = "";
						paymentDetailsInfo.VoucherType = "";
						paymentDetailsInfo.Description = "";
						paymentDetailsInfo.LedgerId = this.cmbAccountLedger.SelectedValue.ToString();
						if (this.isInEditMode)
						{
							paymentMasterInfo.PaymentMasterId = this.txtVoucherNo.Text;
							this.mastersp.PaymentMasterEdit(paymentMasterInfo);
							this.detailssp.PaymentDetailsEdit(paymentDetailsInfo);
							this.DoLedgerPosting();
							MessageBox.Show("Updated successfully", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
							if (this.cbxPrint.Checked)
							{
							}
							base.Close();
						}
						else
						{
							string text = this.txtVoucherNo.Text;
							this.GenerateVoucherNumber();
							paymentMasterInfo.PaymentMasterId = this.txtVoucherNo.Text;
							paymentDetailsInfo.PaymentMasterId = this.txtVoucherNo.Text;
							this.mastersp.PaymentMasterAdd(paymentMasterInfo);
							this.detailssp.PaymentDetailsAdd(paymentDetailsInfo);
							this.DoLedgerPosting();
							if (text != this.txtVoucherNo.Text)
							{
								MessageBox.Show(string.Concat("Voucher number changed from ", text, "to ", this.txtVoucherNo.Text), "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
							}
							MessageBox.Show("Saved successfully", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
							if (this.cbxPrint.Checked)
							{
							}
							this.ClearFunction();
						}
					}
					else
					{
						MessageBox.Show("Enter amount", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						this.txtAmount.Focus();
					}
				}
				else
				{
					MessageBox.Show("Enter cheque number", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					this.txtChequeNo.Focus();
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void txtAmount_Enter(object sender, EventArgs e)
		{
			try
			{
				if (decimal.Parse(this.txtAmount.Text) == new decimal(0))
				{
					this.txtAmount.Text = "";
				}
			}
			catch (Exception exception)
			{
				this.txtAmount.Text = "";
			}
		}

		private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
		{
			try
			{
				if (e.KeyChar == '\r')
				{
					if (!this.rbtnCash.Checked)
					{
						this.txtChequeNo.Focus();
					}
					else
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
						string text = this.txtAmount.Text;
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

		private void txtAmount_Leave(object sender, EventArgs e)
		{
			try
			{
				try
				{
					decimal.Parse(this.txtAmount.Text);
				}
				catch (Exception exception)
				{
					this.txtAmount.Text = "0.00";
				}
			}
			catch (Exception exception2)
			{
				Exception exception1 = exception2;
				MessageBox.Show(exception1.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void txtChequeNo_KeyPress(object sender, KeyPressEventArgs e)
		{
			try
			{
				if (e.KeyChar == '\r')
				{
					this.dtpchequedate.Focus();
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
					frmPayment _frmPayment = this;
					_frmPayment.inDescriptionCount = _frmPayment.inDescriptionCount + 1;
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
	}
}