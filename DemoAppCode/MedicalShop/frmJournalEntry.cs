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
	public class frmJournalEntry : Form
	{
		private IContainer components = null;

		private Panel panel1;

		private Button btnSave;

		private Button btnDelete;

		private Button btnClear;

		private Button btnClose;

		private Panel panel8;

		private dgv.DataGridViewEnter dgvJournal;

		private Panel panel6;

		private Label label1;

		private Panel panel7;

		private Panel panel5;

		private Panel panel4;

		private Panel panel3;

		private Panel panel2;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;

		private Label label13;

		private DateTimePicker dtpDate;

		private TextBox txtVoucherNo;

		private Label label2;

		private Label label4;

		private TextBox txtDescription;

		private Label label3;

		private Label lblCreditAmount;

		private Label lblDebitAmt;

		private Button btnRemove;

		private CheckBox cbPrint;

		private DataGridViewComboBoxColumn AccountLedger;

		private DataGridViewTextBoxColumn Debit;

		private DataGridViewTextBoxColumn Credit;

		private Label lblCredit;

		private Label lblDebit;

		private JournalMasterSP mastersp = new JournalMasterSP();

		private JournalDetailsSP detailssp = new JournalDetailsSP();

		private string strDefaultCurrency = "";

		private bool isInEditMode = false;

		private frmJournalRegister frmregister;

		private int inDescriptionCount = 0;

		public frmJournalEntry()
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
                MessageBox.Show("Thank you for using Pharmacy.To gain access please buy full version", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                //JournalDetailsSP.PatientDelete(this.strPatientIdForEdit);
                //MessageBox.Show("Deleted successfully", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                //ClearFunction();
            }
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void btnRemove_Click(object sender, EventArgs e)
		{
			try
			{
				if (this.dgvJournal.CurrentRow != null)
				{
					try
					{
						if (this.dgvJournal.Rows.Count != 1)
						{
							this.dgvJournal.Rows.RemoveAt(this.dgvJournal.CurrentCell.RowIndex);
						}
						else
						{
							this.dgvJournal.Rows.Clear();
						}
					}
					catch (Exception exception)
					{
					}
					if (this.dgvJournal.Rows.Count > 0)
					{
						this.dgvJournal.Focus();
						this.dgvJournal.CurrentCell = this.dgvJournal.Rows[0].Cells[0];
					}
					this.CalculateTotalDebitCredit();
				}
			}
			catch (Exception exception2)
			{
				Exception exception1 = exception2;
				MessageBox.Show(exception1.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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

		public void CalculateTotalDebitCredit()
		{
			try
			{
				decimal num = new decimal(0);
				decimal num1 = new decimal(0);
				foreach (DataGridViewRow row in (IEnumerable)this.dgvJournal.Rows)
				{
					if ((row.Cells[0].Value == null ? false : row.Cells[0].Value.ToString() != ""))
					{
						if ((row.Cells[1].Value == null ? false : row.Cells[1].Value.ToString().Trim() != ""))
						{
							num = num + decimal.Parse(row.Cells[1].Value.ToString());
						}
						if ((row.Cells[2].Value == null ? false : row.Cells[2].Value.ToString().Trim() != ""))
						{
							num1 = num1 + decimal.Parse(row.Cells[2].Value.ToString());
						}
					}
				}
				this.lblDebitAmt.Text = string.Concat(num, " ", this.strDefaultCurrency);
				this.lblDebit.Text = num.ToString();
				this.lblCreditAmount.Text = string.Concat(num1, " ", this.strDefaultCurrency);
				this.lblCredit.Text = num1.ToString();
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
				this.dgvJournal.Rows.Clear();
				this.FillAccountLedgerComboInGrid();
				this.lblCreditAmount.Text = string.Concat("0.00 ", this.strDefaultCurrency);
				this.lblCredit.Text = "0.00";
				this.lblDebitAmt.Text = string.Concat("0.00 ", this.strDefaultCurrency);
				this.lblDebit.Text = "0.00";
				this.dtpDate.Text = "";
				this.txtDescription.Clear();
				this.btnDelete.Enabled = false;
				this.btnSave.Text = "&Save";
				this.btnClear.Text = "C&lear";
				if (this.isInEditMode)
				{
					this.isInEditMode = false;
					this.frmregister.Close();
				}
				this.cbPrint.Checked = false;
				this.dtpDate.Focus();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void dgvJournal_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
		}

		private void dgvJournal_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				if (this.dgvJournal.CurrentCell != null)
				{
					if (this.dgvJournal.CurrentCell.ColumnIndex == 1)
					{
						try
						{
							if (decimal.Parse(this.dgvJournal.CurrentCell.Value.ToString()) > new decimal(0))
							{
								this.dgvJournal.CurrentRow.Cells[2].Value = 0;
							}
						}
						catch (Exception exception)
						{
						}
					}
					else if (this.dgvJournal.CurrentCell.ColumnIndex == 2)
					{
						try
						{
							if (decimal.Parse(this.dgvJournal.CurrentCell.Value.ToString()) > new decimal(0))
							{
								this.dgvJournal.CurrentRow.Cells[1].Value = 0;
							}
						}
						catch (Exception exception1)
						{
						}
					}
				}
			}
			catch (Exception exception3)
			{
				Exception exception2 = exception3;
				MessageBox.Show(exception2.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void dgvJournal_CellLeave(object sender, DataGridViewCellEventArgs e)
		{
			bool flag;
			try
			{
				if (this.dgvJournal.CurrentCell == null)
				{
					flag = true;
				}
				else
				{
					flag = (this.dgvJournal.CurrentCell.ColumnIndex == 1 ? false : this.dgvJournal.CurrentCell.ColumnIndex != 2);
				}
				if (!flag)
				{
					try
					{
						decimal.Parse(this.dgvJournal.CurrentCell.Value.ToString());
					}
					catch (Exception exception)
					{
						this.dgvJournal.CurrentCell.Value = 0;
					}
				}
			}
			catch (Exception exception2)
			{
				Exception exception1 = exception2;
				MessageBox.Show(exception1.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void dgvJournal_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				this.CalculateTotalDebitCredit();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void dgvJournal_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
		{
			DataGridViewTextBoxEditingControl control = e.Control as DataGridViewTextBoxEditingControl;
			if (control != null)
			{
				control.KeyPress += new KeyPressEventHandler(this.TextBoxCellEditControlKeyPress);
			}
		}

		private void dgvJournal_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				if (e.KeyCode == Keys.Return)
				{
					if (this.dgvJournal.CurrentCell != null)
					{
						if ((this.dgvJournal.CurrentCell.ColumnIndex != 2 ? false : this.dgvJournal.CurrentRow.Index == this.dgvJournal.Rows.Count - 1))
						{
							try
							{
								decimal.Parse(this.dgvJournal.CurrentRow.Cells[1].Value.ToString());
							}
							catch (Exception exception)
							{
								this.dgvJournal.CurrentRow.Cells[1].Value = 0;
							}
							try
							{
								decimal.Parse(this.dgvJournal.CurrentRow.Cells[2].Value.ToString());
							}
							catch (Exception exception1)
							{
								this.dgvJournal.CurrentRow.Cells[2].Value = 0;
							}
							if ((decimal.Parse(this.dgvJournal.CurrentRow.Cells[1].Value.ToString()) != new decimal(0) ? false : decimal.Parse(this.dgvJournal.CurrentRow.Cells[2].Value.ToString()) == new decimal(0)))
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
								this.dgvJournal.ClearSelection();
								this.txtDescription.Focus();
							}
						}
					}
				}
			}
			catch (Exception exception3)
			{
				Exception exception2 = exception3;
				MessageBox.Show(exception2.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void dgvJournal_Leave(object sender, EventArgs e)
		{
			try
			{
				this.dgvJournal.ClearSelection();
				foreach (DataGridViewRow row in (IEnumerable)this.dgvJournal.Rows)
				{
					if ((row.Cells[0].Value == null ? true : row.Cells[0].Value.ToString() == ""))
					{
						try
						{
							this.dgvJournal.Rows.RemoveAt(row.Index);
						}
						catch (Exception exception)
						{
						}
					}
				}
			}
			catch (Exception exception2)
			{
				Exception exception1 = exception2;
				MessageBox.Show(exception1.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void dgvJournal_RowEnter(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				foreach (DataGridViewRow row in (IEnumerable)this.dgvJournal.Rows)
				{
					if (row.Cells[0].Value == null)
					{
						row.Cells[0].Value = "2";
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

		public void DoWhenComingFromRegister(frmJournalRegister frm, string strVcouherNo)
		{
			try
			{
				this.ClearFunction();
				this.frmregister = frm;
				this.isInEditMode = true;
				base.Show();
				this.txtVoucherNo.Text = strVcouherNo;
				JournalMasterInfo journalMasterInfo = new JournalMasterInfo();
				JournalDetailsInfo journalDetailsInfo = new JournalDetailsInfo();
				DataTable dataTable = new DataTable();
				journalMasterInfo = this.mastersp.JournalMasterView(strVcouherNo);
				dataTable = this.detailssp.JournalDetailsViewAllByMasterId(this.txtVoucherNo.Text);
				this.btnClear.Text = "&New";
				this.btnSave.Text = "&Update";
				this.dtpDate.Value = journalMasterInfo.Date;
				this.txtDescription.Text = journalMasterInfo.Description;
				this.btnDelete.Enabled = true;
				int str = 0;
				foreach (DataRow row in dataTable.Rows)
				{
					this.dgvJournal.Rows.Add();
					this.dgvJournal.Rows[str].Cells[0].Value = row.ItemArray[2].ToString();
					DataGridViewCell item = this.dgvJournal.Rows[str].Cells[1];
					double num = double.Parse(row.ItemArray[3].ToString());
					item.Value = num.ToString();
					DataGridViewCell dataGridViewCell = this.dgvJournal.Rows[str].Cells[2];
					num = double.Parse(row.ItemArray[4].ToString());
					dataGridViewCell.Value = num.ToString();
					str++;
				}
				this.dtpDate.Focus();
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
					this.frmregister.DoWhenComingFromJounal();
				}
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
					this.dgvJournal.Focus();
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void dtpDate_Leave(object sender, EventArgs e)
		{
			try
			{
				if (this.dgvJournal.Focused)
				{
					if (this.dgvJournal.Rows.Count == 0)
					{
						this.dgvJournal.Rows.Add();
					}
					this.dgvJournal.Focus();
					this.dgvJournal.CurrentCell = this.dgvJournal.Rows[0].Cells[0];
					this.dgvJournal.ClearSelection();
					this.dgvJournal.CurrentCell.Selected = true;
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		public void FillAccountLedgerComboInGrid()
		{
			try
			{
				DataTable dataTable = (new AccountLedgerSP()).AccountLedgerViewAll();
				this.AccountLedger.DataSource = dataTable;
				this.AccountLedger.DisplayMember = "Name";
				this.AccountLedger.ValueMember = "ID";
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void frmJournalEntry_FormClosing(object sender, FormClosingEventArgs e)
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

		private void frmJournalEntry_KeyDown(object sender, KeyEventArgs e)
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
				else if (e.KeyCode == Keys.Escape)
				{
					if (MessageBox.Show("Do you want to close?", "Pharmacy", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
					{
						base.Close();
					}
				}
			}
			catch (Exception exception2)
			{
				Exception exception1 = exception2;
				MessageBox.Show(exception1.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void frmJournalEntry_Load(object sender, EventArgs e)
		{
			try
			{
				CompanySP companySP = new CompanySP();
				DataTable dataTable = new DataTable();
				dataTable = companySP.CompanyViewAll();
				this.strDefaultCurrency = dataTable.Rows[0][13].ToString();
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
			string str = this.mastersp.JournalMasterGetMax();
			this.txtVoucherNo.Text = str;
		}

		private void InitializeComponent()
		{
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmJournalEntry));
			this.panel1 = new Panel();
			this.btnSave = new Button();
			this.btnDelete = new Button();
			this.btnClear = new Button();
			this.btnClose = new Button();
			this.panel8 = new Panel();
			this.lblDebitAmt = new Label();
			this.cbPrint = new CheckBox();
			this.label4 = new Label();
			this.txtDescription = new TextBox();
			this.label3 = new Label();
			this.lblCreditAmount = new Label();
			this.btnRemove = new Button();
			this.txtVoucherNo = new TextBox();
			this.label2 = new Label();
			this.label13 = new Label();
			this.dtpDate = new DateTimePicker();
			this.dgvJournal = new dgv.DataGridViewEnter();
			this.AccountLedger = new DataGridViewComboBoxColumn();
			this.Debit = new DataGridViewTextBoxColumn();
			this.Credit = new DataGridViewTextBoxColumn();
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
			this.lblDebit = new Label();
			this.lblCredit = new Label();
			this.panel1.SuspendLayout();
			this.panel8.SuspendLayout();
			((ISupportInitialize)this.dgvJournal).BeginInit();
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
			this.panel1.Size = new System.Drawing.Size(678, 431);
			this.panel1.TabIndex = 1;
			this.btnSave.BackColor = Color.FromArgb(255, 209, 150);
			this.btnSave.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 1);
			this.btnSave.FlatStyle = FlatStyle.Flat;
			this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.btnSave.Location = new Point(351, 388);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(75, 23);
			this.btnSave.TabIndex = 3;
			this.btnSave.Text = "&Save";
			this.btnSave.UseVisualStyleBackColor = false;
			this.btnSave.Click += new EventHandler(this.btnSave_Click);
			this.btnDelete.BackColor = Color.FromArgb(255, 209, 150);
			this.btnDelete.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 1);
			this.btnDelete.FlatStyle = FlatStyle.Flat;
			this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.btnDelete.Location = new Point(432, 388);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(75, 23);
			this.btnDelete.TabIndex = 4;
			this.btnDelete.Text = "&Delete";
			this.btnDelete.UseVisualStyleBackColor = false;
			this.btnDelete.Click += new EventHandler(this.btnDelete_Click);
			this.btnClear.BackColor = Color.FromArgb(255, 209, 150);
			this.btnClear.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 1);
			this.btnClear.FlatStyle = FlatStyle.Flat;
			this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.btnClear.Location = new Point(513, 388);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(75, 23);
			this.btnClear.TabIndex = 5;
			this.btnClear.Text = "C&lear";
			this.btnClear.UseVisualStyleBackColor = false;
			this.btnClear.Click += new EventHandler(this.btnClear_Click);
			this.btnClose.BackColor = Color.FromArgb(255, 209, 150);
			this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnClose.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 1);
			this.btnClose.FlatStyle = FlatStyle.Flat;
			this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.btnClose.Location = new Point(594, 388);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(75, 23);
			this.btnClose.TabIndex = 6;
			this.btnClose.Text = "&Close";
			this.btnClose.UseVisualStyleBackColor = false;
			this.btnClose.Click += new EventHandler(this.btnClose_Click);
			this.panel8.BackgroundImage = (Image)componentResourceManager.GetObject("panel8.BackgroundImage");
			this.panel8.BackgroundImageLayout = ImageLayout.Stretch;
			this.panel8.Controls.Add(this.lblCredit);
			this.panel8.Controls.Add(this.lblDebit);
			this.panel8.Controls.Add(this.lblDebitAmt);
			this.panel8.Controls.Add(this.cbPrint);
			this.panel8.Controls.Add(this.label4);
			this.panel8.Controls.Add(this.txtDescription);
			this.panel8.Controls.Add(this.label3);
			this.panel8.Controls.Add(this.lblCreditAmount);
			this.panel8.Controls.Add(this.btnRemove);
			this.panel8.Controls.Add(this.txtVoucherNo);
			this.panel8.Controls.Add(this.label2);
			this.panel8.Controls.Add(this.label13);
			this.panel8.Controls.Add(this.dtpDate);
			this.panel8.Controls.Add(this.dgvJournal);
			this.panel8.Dock = DockStyle.Top;
			this.panel8.Location = new Point(1, 34);
			this.panel8.Name = "panel8";
			this.panel8.Padding = new System.Windows.Forms.Padding(5);
			this.panel8.Size = new System.Drawing.Size(676, 338);
			this.panel8.TabIndex = 0;
			this.lblDebitAmt.AutoSize = true;
			this.lblDebitAmt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.lblDebitAmt.Location = new Point(242, 217);
			this.lblDebitAmt.Name = "lblDebitAmt";
			this.lblDebitAmt.Size = new System.Drawing.Size(40, 13);
			this.lblDebitAmt.TabIndex = 96;
			this.lblDebitAmt.Text = "Total:";
			this.cbPrint.AutoSize = true;
			this.cbPrint.Location = new Point(95, 316);
			this.cbPrint.Name = "cbPrint";
			this.cbPrint.Size = new System.Drawing.Size(97, 17);
			this.cbPrint.TabIndex = 103;
			this.cbPrint.Text = "Print after save";
			this.cbPrint.UseVisualStyleBackColor = true;
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label4.Location = new Point(13, 217);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(40, 13);
			this.label4.TabIndex = 102;
			this.label4.Text = "Total:";
			this.txtDescription.Location = new Point(95, 248);
			this.txtDescription.Multiline = true;
			this.txtDescription.Name = "txtDescription";
			this.txtDescription.Size = new System.Drawing.Size(222, 62);
			this.txtDescription.TabIndex = 2;
			this.txtDescription.Enter += new EventHandler(this.txtDescription_Enter);
			this.txtDescription.KeyPress += new KeyPressEventHandler(this.txtDescription_KeyPress);
			this.label3.AutoSize = true;
			this.label3.Location = new Point(13, 251);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(63, 13);
			this.label3.TabIndex = 98;
			this.label3.Text = "Description:";
			this.lblCreditAmount.AutoSize = true;
			this.lblCreditAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.lblCreditAmount.Location = new Point(465, 220);
			this.lblCreditAmount.Name = "lblCreditAmount";
			this.lblCreditAmount.Size = new System.Drawing.Size(32, 13);
			this.lblCreditAmount.TabIndex = 97;
			this.lblCreditAmount.Text = "0.00";
			this.btnRemove.BackColor = Color.SteelBlue;
			this.btnRemove.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 1);
			this.btnRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.btnRemove.ForeColor = Color.White;
			this.btnRemove.Location = new Point(605, 220);
			this.btnRemove.Name = "btnRemove";
			this.btnRemove.Size = new System.Drawing.Size(63, 23);
			this.btnRemove.TabIndex = 94;
			this.btnRemove.TabStop = false;
			this.btnRemove.Text = "Remove";
			this.btnRemove.UseVisualStyleBackColor = false;
			this.btnRemove.Click += new EventHandler(this.btnRemove_Click);
			this.txtVoucherNo.BackColor = Color.WhiteSmoke;
			this.txtVoucherNo.Location = new Point(106, 13);
			this.txtVoucherNo.Name = "txtVoucherNo";
			this.txtVoucherNo.ReadOnly = true;
			this.txtVoucherNo.Size = new System.Drawing.Size(238, 20);
			this.txtVoucherNo.TabIndex = 55;
			this.txtVoucherNo.TabStop = false;
			this.label2.AutoSize = true;
			this.label2.Location = new Point(13, 20);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(67, 13);
			this.label2.TabIndex = 54;
			this.label2.Text = "Voucher No:";
			this.label13.AutoSize = true;
			this.label13.Location = new Point(427, 20);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(33, 13);
			this.label13.TabIndex = 53;
			this.label13.Text = "Date:";
			this.dtpDate.CustomFormat = "dd-MMM-yyyy";
			this.dtpDate.Format = DateTimePickerFormat.Custom;
			this.dtpDate.Location = new Point(485, 13);
			this.dtpDate.Name = "dtpDate";
			this.dtpDate.Size = new System.Drawing.Size(131, 20);
			this.dtpDate.TabIndex = 0;
			this.dtpDate.Leave += new EventHandler(this.dtpDate_Leave);
			this.dtpDate.KeyPress += new KeyPressEventHandler(this.dtpDate_KeyPress);
			this.dgvJournal.AllowUserToDeleteRows = false;
			this.dgvJournal.AllowUserToOrderColumns = true;
			this.dgvJournal.AllowUserToResizeColumns = false;
			this.dgvJournal.AllowUserToResizeRows = false;
			this.dgvJournal.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvJournal.BackgroundColor = Color.White;
			this.dgvJournal.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			DataGridViewColumnCollection columns = this.dgvJournal.Columns;
			DataGridViewColumn[] accountLedger = new DataGridViewColumn[] { this.AccountLedger, this.Debit, this.Credit };
			columns.AddRange(accountLedger);
			this.dgvJournal.GridColor = Color.WhiteSmoke;
			this.dgvJournal.Location = new Point(8, 45);
			this.dgvJournal.MultiSelect = false;
			this.dgvJournal.Name = "dgvJournal";
			this.dgvJournal.RowHeadersVisible = false;
			this.dgvJournal.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			this.dgvJournal.SelectionMode = DataGridViewSelectionMode.CellSelect;
			this.dgvJournal.Size = new System.Drawing.Size(660, 169);
			this.dgvJournal.TabIndex = 1;
			this.dgvJournal.CellLeave += new DataGridViewCellEventHandler(this.dgvJournal_CellLeave);
			this.dgvJournal.KeyDown += new KeyEventHandler(this.dgvJournal_KeyDown);
			this.dgvJournal.RowEnter += new DataGridViewCellEventHandler(this.dgvJournal_RowEnter);
			this.dgvJournal.Leave += new EventHandler(this.dgvJournal_Leave);
			this.dgvJournal.CellEndEdit += new DataGridViewCellEventHandler(this.dgvJournal_CellEndEdit);
			this.dgvJournal.CellValueChanged += new DataGridViewCellEventHandler(this.dgvJournal_CellValueChanged);
			this.dgvJournal.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(this.dgvJournal_EditingControlShowing);
			this.dgvJournal.CellContentClick += new DataGridViewCellEventHandler(this.dgvJournal_CellContentClick);
			this.AccountLedger.HeaderText = "Account Ledger";
			this.AccountLedger.Name = "AccountLedger";
			this.AccountLedger.Resizable = DataGridViewTriState.False;
			this.Debit.HeaderText = "Debit";
			this.Debit.MaxInputLength = 8;
			this.Debit.Name = "Debit";
			this.Debit.Resizable = DataGridViewTriState.False;
			this.Debit.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.Credit.HeaderText = "Credit";
			this.Credit.MaxInputLength = 8;
			this.Credit.Name = "Credit";
			this.Credit.Resizable = DataGridViewTriState.False;
			this.Credit.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.panel6.BackgroundImage = (Image)componentResourceManager.GetObject("panel6.BackgroundImage");
			this.panel6.Controls.Add(this.label1);
			this.panel6.Controls.Add(this.panel7);
			this.panel6.Dock = DockStyle.Top;
			this.panel6.Location = new Point(1, 1);
			this.panel6.Name = "panel6";
			this.panel6.Size = new System.Drawing.Size(676, 33);
			this.panel6.TabIndex = 3;
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label1.Location = new Point(11, 7);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(91, 15);
			this.label1.TabIndex = 4;
			this.label1.Text = "Journal Entry";
			this.panel7.BackColor = Color.FromArgb(136, 136, 136);
			this.panel7.Dock = DockStyle.Bottom;
			this.panel7.Location = new Point(0, 32);
			this.panel7.Name = "panel7";
			this.panel7.Size = new System.Drawing.Size(676, 1);
			this.panel7.TabIndex = 3;
			this.panel5.BackColor = Color.FromArgb(136, 136, 136);
			this.panel5.Dock = DockStyle.Bottom;
			this.panel5.Location = new Point(1, 430);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(676, 1);
			this.panel5.TabIndex = 2;
			this.panel4.BackColor = Color.FromArgb(136, 136, 136);
			this.panel4.Dock = DockStyle.Top;
			this.panel4.Location = new Point(1, 0);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(676, 1);
			this.panel4.TabIndex = 1;
			this.panel3.BackColor = Color.FromArgb(136, 136, 136);
			this.panel3.Dock = DockStyle.Right;
			this.panel3.Location = new Point(677, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(1, 431);
			this.panel3.TabIndex = 1;
			this.panel2.BackColor = Color.FromArgb(136, 136, 136);
			this.panel2.Dock = DockStyle.Left;
			this.panel2.Location = new Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(1, 431);
			this.panel2.TabIndex = 0;
			this.dataGridViewTextBoxColumn1.HeaderText = "SI";
			this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn1.ReadOnly = true;
			this.dataGridViewTextBoxColumn1.Width = 329;
			this.dataGridViewTextBoxColumn2.HeaderText = "Name";
			this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
			this.dataGridViewTextBoxColumn2.ReadOnly = true;
			this.dataGridViewTextBoxColumn2.Width = 328;
			this.dataGridViewTextBoxColumn3.HeaderText = "Description";
			this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
			this.dataGridViewTextBoxColumn3.Visible = false;
			this.dataGridViewTextBoxColumn3.Width = 219;
			this.lblDebit.AutoSize = true;
			this.lblDebit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.lblDebit.Location = new Point(242, 220);
			this.lblDebit.Name = "lblDebit";
			this.lblDebit.Size = new System.Drawing.Size(40, 13);
			this.lblDebit.TabIndex = 104;
			this.lblDebit.Text = "Total:";
			this.lblDebit.Visible = false;
			this.lblCredit.AutoSize = true;
			this.lblCredit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.lblCredit.Location = new Point(465, 217);
			this.lblCredit.Name = "lblCredit";
			this.lblCredit.Size = new System.Drawing.Size(32, 13);
			this.lblCredit.TabIndex = 105;
			this.lblCredit.Text = "0.00";
			this.lblCredit.Visible = false;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.BackColor = Color.White;
			base.ClientSize = new System.Drawing.Size(692, 445);
			base.Controls.Add(this.panel1);
			base.Icon = (System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.KeyPreview = true;
			base.MaximizeBox = false;
			base.Name = "frmJournalEntry";
			base.Padding = new System.Windows.Forms.Padding(7);
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "Journal Entry";
			base.FormClosing += new FormClosingEventHandler(this.frmJournalEntry_FormClosing);
			base.KeyDown += new KeyEventHandler(this.frmJournalEntry_KeyDown);
			base.Load += new EventHandler(this.frmJournalEntry_Load);
			this.panel1.ResumeLayout(false);
			this.panel8.ResumeLayout(false);
			this.panel8.PerformLayout();
			((ISupportInitialize)this.dgvJournal).EndInit();
			this.panel6.ResumeLayout(false);
			this.panel6.PerformLayout();
			base.ResumeLayout(false);
		}

		public void SaveOrEdit()
		{
			DataGridViewRow row = null;
			LedgerPostingInfo ledgerPostingInfo;
			LedgerPostingSP ledgerPostingSP;
			try
			{
				if (!FinacialYearInfo._activeOrNot)
				{
					MessageBox.Show("Selected finacial year has been closed", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
				else
				{
					JournalMasterSP journalMasterSP = new JournalMasterSP();
					JournalDetailsSP journalDetailsSP = new JournalDetailsSP();
					JournalMasterInfo journalMasterInfo = new JournalMasterInfo();
					JournalDetailsInfo journalDetailsInfo = new JournalDetailsInfo();
					if (!(decimal.Parse(this.lblCredit.Text) != new decimal(0) ? true : !(decimal.Parse(this.lblDebit.Text) == new decimal(0))))
					{
						MessageBox.Show("Incomplete details", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						this.dgvJournal.Focus();
						this.dgvJournal.CurrentCell = this.dgvJournal.Rows[0].Cells[1];
						this.dgvJournal.CurrentCell.Selected = true;
					}
					else if (!(decimal.Parse(this.lblCredit.Text) != decimal.Parse(this.lblDebit.Text)))
					{
						this.txtDescription.Text = this.txtDescription.Text.Trim();
						journalMasterInfo.Date = DateTime.Parse(this.dtpDate.Text);
						journalMasterInfo.JournalMasterId = this.txtVoucherNo.Text;
						journalMasterInfo.Description = this.txtDescription.Text;
						if (this.isInEditMode)
						{
							journalMasterSP.JournalMasterEdit(journalMasterInfo);
							journalDetailsInfo.JournalMasterId = journalMasterInfo.JournalMasterId;
							journalDetailsSP.journalDetailsDeleteByMasterId(journalMasterInfo.JournalMasterId);
							ledgerPostingSP = new LedgerPostingSP();
							ledgerPostingSP.LedgerPostingDeleteByVoucherTypeAndVoucherNo(journalMasterInfo.JournalMasterId, "Journal Entry");
							foreach (DataGridViewRow row1 in (IEnumerable)this.dgvJournal.Rows)
							{
								try
								{
									decimal.Parse(row1.Cells[1].Value.ToString());
								}
								catch (Exception exception)
								{
									row1.Cells[1].Value = 0;
								}
								try
								{
									decimal.Parse(row1.Cells[2].Value.ToString());
								}
								catch (Exception exception1)
								{
									row1.Cells[2].Value = 0;
								}
								ledgerPostingInfo = new LedgerPostingInfo();
								if ((decimal.Parse(row1.Cells[1].Value.ToString()) != new decimal(0) ? true : decimal.Parse(row1.Cells[2].Value.ToString()) != new decimal(0)))
								{
									if (row1.Cells[0].Value != null)
									{
										journalDetailsInfo.LedgerId = row1.Cells[0].Value.ToString();
										journalDetailsInfo.Debit = decimal.Parse(row1.Cells[1].Value.ToString());
										journalDetailsInfo.Credit = decimal.Parse(row1.Cells[2].Value.ToString());
										journalDetailsInfo.Description = "";
										journalDetailsSP.JournalDetailsAdd(journalDetailsInfo);
										ledgerPostingInfo.LedgerId = journalDetailsInfo.LedgerId;
										ledgerPostingInfo.VoucherNumber = journalMasterInfo.JournalMasterId;
										ledgerPostingInfo.VoucherType = "Jounal Entry";
										ledgerPostingInfo.Date = DateTime.Parse(this.dtpDate.Text);
										ledgerPostingInfo.Debit = journalDetailsInfo.Debit;
										ledgerPostingInfo.Credit = journalDetailsInfo.Credit;
										ledgerPostingInfo.Description = "From journal";
										ledgerPostingSP.LedgerPostingAdd(ledgerPostingInfo);
									}
								}
							}
							MessageBox.Show("Updated successfully", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
							if (this.cbPrint.Checked)
							{
							}
							base.Close();
						}
						else
						{
							string text = this.txtVoucherNo.Text;
							this.GenerateVoucherNumber();
							journalMasterInfo.JournalMasterId = this.txtVoucherNo.Text;
							journalMasterSP.JournalMasterAdd(journalMasterInfo);
							journalDetailsInfo.JournalMasterId = journalMasterInfo.JournalMasterId;
							foreach (DataGridViewRow dataGridViewRow in (IEnumerable)this.dgvJournal.Rows)
							{
								try
								{
									decimal.Parse(dataGridViewRow.Cells[1].Value.ToString());
								}
								catch (Exception exception2)
								{
									dataGridViewRow.Cells[1].Value = 0;
								}
								try
								{
									decimal.Parse(dataGridViewRow.Cells[2].Value.ToString());
								}
								catch (Exception exception3)
								{
									dataGridViewRow.Cells[2].Value = 0;
								}
								if ((decimal.Parse(dataGridViewRow.Cells[1].Value.ToString()) != new decimal(0) ? true : decimal.Parse(dataGridViewRow.Cells[2].Value.ToString()) != new decimal(0)))
								{
									if (dataGridViewRow.Cells[0].Value != null)
									{
										journalDetailsInfo.LedgerId = dataGridViewRow.Cells[0].Value.ToString();
										journalDetailsInfo.Debit = decimal.Parse(dataGridViewRow.Cells[1].Value.ToString());
										journalDetailsInfo.Credit = decimal.Parse(dataGridViewRow.Cells[2].Value.ToString());
										journalDetailsInfo.Description = "";
										journalDetailsSP.JournalDetailsAdd(journalDetailsInfo);
										ledgerPostingInfo = new LedgerPostingInfo();
										ledgerPostingSP = new LedgerPostingSP();
										ledgerPostingInfo.LedgerId = journalDetailsInfo.LedgerId;
										ledgerPostingInfo.VoucherNumber = journalMasterInfo.JournalMasterId;
										ledgerPostingInfo.VoucherType = "Jounal Entry";
										ledgerPostingInfo.Date = DateTime.Parse(this.dtpDate.Text);
										ledgerPostingInfo.Debit = journalDetailsInfo.Debit;
										ledgerPostingInfo.Credit = journalDetailsInfo.Credit;
										ledgerPostingInfo.Description = "From journal";
										ledgerPostingSP.LedgerPostingAdd(ledgerPostingInfo);
									}
								}
							}
							if (text != this.txtVoucherNo.Text)
							{
								MessageBox.Show(string.Concat("Voucher number changed from ", text, "to ", this.txtVoucherNo.Text), "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
							}
							MessageBox.Show("Saved successfully", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
							if (this.cbPrint.Checked)
							{
							}
							this.ClearFunction();
						}
					}
					else
					{
						MessageBox.Show("Total Debit amount and Credit amount should be equal", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						this.dgvJournal.Focus();
						this.dgvJournal.CurrentCell = this.dgvJournal.Rows[0].Cells[1];
						this.dgvJournal.CurrentCell.Selected = true;
					}
				}
			}
			catch (Exception exception5)
			{
				Exception exception4 = exception5;
				MessageBox.Show(exception4.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void TextBoxCellEditControlKeyPress(object sender, KeyPressEventArgs e)
		{
			try
			{
				if ((this.dgvJournal.CurrentCell.ColumnIndex == 1 ? true : this.dgvJournal.CurrentCell.ColumnIndex == 2))
				{
					if (!char.IsNumber(e.KeyChar))
					{
						if ((e.KeyChar == '\b' ? false : e.KeyChar != '.'))
						{
							e.Handled = true;
						}
						else
						{
							e.Handled = false;
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
				if (e.KeyChar == '\r')
				{
					if (e.KeyChar != '\r')
					{
						this.inDescriptionCount = 0;
					}
					else
					{
						frmJournalEntry _frmJournalEntry = this;
						_frmJournalEntry.inDescriptionCount = _frmJournalEntry.inDescriptionCount + 1;
						if (this.inDescriptionCount == 2)
						{
							this.inDescriptionCount = 0;
							this.btnSave.Focus();
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