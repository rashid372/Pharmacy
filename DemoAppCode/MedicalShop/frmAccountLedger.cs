using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;

namespace MedicalShop
{
	public class frmAccountLedger : Form
	{
		private IContainer components = null;

		private Panel panel1;

		private Button btnSave;

		private Button btnDelete;

		private Button btnClear;

		private Button btnClose;

		private Panel panel8;

		private GroupBox gpbRegister;

		private TextBox txtDescription;

		private Label label4;

		private Label label3;

		private ComboBox cmbGroupUnder;

		private TextBox txtLedgerName;

		private Label label2;

		private Panel panel6;

		private Label label1;

		private Panel panel7;

		private Panel panel5;

		private Panel panel4;

		private Panel panel3;

		private Panel panel2;

		private Button btnNew;

		private Label label8;

		private Label label7;

		private ComboBox cmbDebitOrCredit;

		private TextBox txtOpeningBalance;

		private Panel panel9;

		private DataGridView dgvAccountLedger;

		private DataGridViewTextBoxColumn ID;

		private DataGridViewTextBoxColumn LedgerName;

		private TextBox txtSearch;

		private Label label6;

		private ComboBox cmbSearchBy;

		private Label label5;

		private RadioButton rbtnNonBuiltIn;

		private RadioButton rbtnBuiltIn;

		private RadioButton rbtnAll;

		private AccountGroupSP accountgroupSP = new AccountGroupSP();

		private AccountLedgerSP accountledgerSP = new AccountLedgerSP();

        private AccountLedgerInfo accountledgerinfo = new AccountLedgerInfo();

        private Boolean isAutoGenerate = true;

        private bool isFormClose = false;

		private bool isInEditMode = false;

		private bool isFromOtherForms = false;

		private string strLedgerIdForEdit = "";

		private string strLedgerIdForOtherForms = "";

		private string strLedgerName = "";

		private string strOldGroupId = "";

		private int inDescriptionCount = 0;

		private string strType = "";

		private bool isBuiltIn = false;

		public frmAccountLedger()
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
                //MessageBox.Show("Thank you for using Pharmacy.To gain access please buy full version", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                  accountledgerSP.AccountLedgerDelete(this.strLedgerIdForEdit);
                 MessageBox.Show("Deleted successfully", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                  ClearFunction();
            }
            catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void btnNew_Click(object sender, EventArgs e)
		{
            //MessageBox.Show("Thank you for using Pharmacy.To gain access please buy full version", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            frmAccountGroup AccountGroup = new frmAccountGroup();
            this.Close();
            AccountGroup.Show();
        }

		private void btnSave_Click(object sender, EventArgs e)
		{
			try
			{
                //	MessageBox.Show("Thank you for using Pharmacy.To gain access please buy full version", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.saveOrEditDetails();
            }
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		public bool CheckExistanceOfLedgerIdInLedgerPosting()
		{
			DataTable dataTable = new DataTable();
			return (new LedgerPostingSP()).LedgerPostingCheckExistanceOfLedgerId(this.strLedgerIdForEdit);
		}

		public void ClearFunction()
		{
			try
			{
				this.txtDescription.Clear();
				this.txtLedgerName.Clear();
				this.txtSearch.Clear();
				this.cmbSearchBy.Text = "All";
				this.FillAccountLedgerGrid();
				this.FillAccountGroupCombo();
				this.FillSearchByCombo();
				this.btnSave.Text = "&Save";
				this.btnClear.Text = "C&lear";
				this.strLedgerIdForEdit = "";
				this.strLedgerIdForOtherForms = "";
				this.strLedgerName = "";
				this.strOldGroupId = "";
				this.txtOpeningBalance.Text = "0.00";
				this.cmbGroupUnder.SelectedValue = 0;
				this.cmbDebitOrCredit.Text = "Dr";
				this.isInEditMode = false;
				this.btnDelete.Enabled = false;
				this.cmbGroupUnder.Enabled = true;
				this.txtLedgerName.ReadOnly = false;
				this.txtLedgerName.BackColor = Color.White;
				this.rbtnAll.Checked = true;
				this.isBuiltIn = true;
				this.txtLedgerName.Focus();
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
			this.DropDownComboOrDateTimePicker(e);
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

		private void cmbSearchBy_KeyPress(object sender, KeyPressEventArgs e)
		{
			try
			{
				if (e.KeyChar == '\r')
				{
					this.txtSearch.Focus();
				}
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
				this.FillAccountLedgerGrid();
				this.txtSearch.Clear();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void dgvAccountLedger_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				if (this.dgvAccountLedger.CurrentRow != null)
				{
					if ((this.dgvAccountLedger.Rows.Count <= 0 ? false : e.ColumnIndex > -1))
					{
						if (this.dgvAccountLedger.CurrentRow.Cells[0].Value != null)
						{
							if (this.dgvAccountLedger.CurrentRow.Cells[0].Value.ToString() != "")
							{
								this.strLedgerIdForEdit = this.dgvAccountLedger.CurrentRow.Cells[0].Value.ToString();
								this.strLedgerName = this.dgvAccountLedger.CurrentRow.Cells[1].Value.ToString();
								this.FillAccountGroupCombo();
								this.FillControlsForEdit();
								this.dgvAccountLedger.CurrentRow.Selected = true;
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

		private void dgvAccountLedger_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			try
			{
				DataGridViewCellEventArgs dataGridViewCellEventArg = new DataGridViewCellEventArgs(e.ColumnIndex, e.RowIndex);
				this.dgvAccountLedger_CellClick(sender, dataGridViewCellEventArg);
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void dgvAccountLedger_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
		{
			((DataGridView)sender).ClearSelection();
		}

		private void dgvAccountLedger_KeyUp(object sender, KeyEventArgs e)
		{
			try
			{
				if ((e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Return ? true : e.KeyCode == Keys.Tab))
				{
					if (this.dgvAccountLedger.CurrentRow != null)
					{
						DataGridViewCellEventArgs dataGridViewCellEventArg = new DataGridViewCellEventArgs(this.dgvAccountLedger.CurrentCell.ColumnIndex, this.dgvAccountLedger.CurrentCell.RowIndex);
						this.dgvAccountLedger_CellClick(sender, dataGridViewCellEventArg);
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

		public void FillAccountGroupCombo()
		{
			try
			{
				AccountGroupSP accountGroupSP = new AccountGroupSP();
				DataTable dataTable = new DataTable();
				dataTable = accountGroupSP.AccountGroupViewAll();
				int num = 0;
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					if ((dataTable.Rows[i].ItemArray[0].ToString() == "3" ? true : dataTable.Rows[i].ItemArray[0].ToString() == "4"))
					{
						dataTable.Rows.Remove(dataTable.Rows[i]);
						i--;
						num++;
						if (num == 2)
						{
							break;
						}
					}
				}
				this.cmbGroupUnder.DataSource = dataTable;
				this.cmbGroupUnder.DisplayMember = dataTable.Columns[1].ToString();
				this.cmbGroupUnder.ValueMember = dataTable.Columns[0].ToString();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		public void FillAccountLedgerGrid()
		{
			try
			{
				DataTable dataTable = new DataTable();
				if (!(this.cmbSearchBy.Text == "All" || this.cmbSearchBy.Text == "" || this.cmbSearchBy.SelectedValue == null ? false : !(this.cmbSearchBy.SelectedValue.ToString() == "System.Data.DataRowView")))
				{
					if (this.rbtnAll.Checked)
					{
						dataTable = this.accountledgerSP.AccountLedgerViewAll();
					}
					else if (this.rbtnBuiltIn.Checked)
					{
						dataTable = this.accountledgerSP.AccountLedgerViewAllByStatus(true);
					}
					else if (this.rbtnNonBuiltIn.Checked)
					{
						dataTable = this.accountledgerSP.AccountLedgerViewAllByStatus(false);
					}
				}
				else if (this.rbtnAll.Checked)
				{
					dataTable = this.accountledgerSP.AccountLedgerViewAllByAccountGroupId(this.cmbSearchBy.SelectedValue.ToString());
				}
				else if (this.rbtnBuiltIn.Checked)
				{
					dataTable = this.accountledgerSP.AccountLedgerViewAllByAccountGroupIdAndStatus(this.cmbSearchBy.SelectedValue.ToString(), true);
				}
				else if (this.rbtnNonBuiltIn.Checked)
				{
					dataTable = this.accountledgerSP.AccountLedgerViewAllByAccountGroupIdAndStatus(this.cmbSearchBy.SelectedValue.ToString(), false);
				}
				this.dgvAccountLedger.Rows.Clear();
				int str = 0;
				foreach (DataRow row in dataTable.Rows)
				{
					this.dgvAccountLedger.Rows.Add();
					this.dgvAccountLedger.Rows[str].Cells[0].Value = row.ItemArray[0].ToString();
					this.dgvAccountLedger.Rows[str].Cells[1].Value = row.ItemArray[1].ToString();
					str++;
				}
				this.dgvAccountLedger.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
				this.dgvAccountLedger.ClearSelection();
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
				AccountLedgerInfo accountLedgerInfo = new AccountLedgerInfo();
				accountLedgerInfo = this.accountledgerSP.AccountLedgerView(this.strLedgerIdForEdit);
				this.txtLedgerName.Text = accountLedgerInfo.AcccountLedgerName;
				this.txtDescription.Text = accountLedgerInfo.Description;
				this.cmbGroupUnder.SelectedValue = accountLedgerInfo.AccountGroupId;
				string str = accountLedgerInfo.OpeningBalance.ToString();
				if (!(str.Trim() == "0.0000"))
				{
					this.txtOpeningBalance.Text = double.Parse(str).ToString();
				}
				else
				{
					this.txtOpeningBalance.Text = "0.0";
				}
				this.cmbGroupUnder.Enabled = true;
				this.txtLedgerName.ReadOnly = false;
				this.txtLedgerName.BackColor = Color.White;
				this.isBuiltIn = false;
				if (!accountLedgerInfo.DebitOrCredit)
				{
					this.cmbDebitOrCredit.Text = "Cr";
				}
				else
				{
					this.cmbDebitOrCredit.Text = "Dr";
				}
				if (!this.CheckExistanceOfLedgerIdInLedgerPosting())
				{
					this.cmbGroupUnder.Enabled = true;
				}
				else
				{
					this.cmbGroupUnder.Enabled = false;
					this.btnNew.Enabled = false;
				}
				if (accountLedgerInfo.DefaultOrNot)
				{
					this.isBuiltIn = true;
					this.cmbGroupUnder.Enabled = false;
					this.btnNew.Enabled = false;
					this.txtLedgerName.ReadOnly = true;
					this.txtLedgerName.BackColor = Color.WhiteSmoke;
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

		public void FillSearchByCombo()
		{
			try
			{
				DataTable dataTable = new DataTable();
				dataTable = this.accountgroupSP.AccountGroupViewAll();
				DataRow dataRow = dataTable.NewRow();
				dataTable.Rows.Add(dataRow);
				dataRow[1] = "All";
				this.cmbSearchBy.DataSource = dataTable;
				this.cmbSearchBy.DisplayMember = dataTable.Columns[1].ToString();
				this.cmbSearchBy.ValueMember = dataTable.Columns[0].ToString();
				this.cmbSearchBy.Text = "All";
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void frmAccountLedger_FormClosing(object sender, FormClosingEventArgs e)
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

		private void frmAccountLedger_Load(object sender, EventArgs e)
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
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmAccountLedger));
			this.panel1 = new Panel();
			this.btnSave = new Button();
			this.btnDelete = new Button();
			this.btnClear = new Button();
			this.btnClose = new Button();
			this.panel8 = new Panel();
			this.txtOpeningBalance = new TextBox();
			this.label8 = new Label();
			this.label7 = new Label();
			this.cmbDebitOrCredit = new ComboBox();
			this.btnNew = new Button();
			this.gpbRegister = new GroupBox();
			this.panel9 = new Panel();
			this.dgvAccountLedger = new DataGridView();
			this.ID = new DataGridViewTextBoxColumn();
			this.LedgerName = new DataGridViewTextBoxColumn();
			this.txtSearch = new TextBox();
			this.label6 = new Label();
			this.cmbSearchBy = new ComboBox();
			this.label5 = new Label();
			this.rbtnNonBuiltIn = new RadioButton();
			this.rbtnBuiltIn = new RadioButton();
			this.rbtnAll = new RadioButton();
			this.txtDescription = new TextBox();
			this.label4 = new Label();
			this.label3 = new Label();
			this.cmbGroupUnder = new ComboBox();
			this.txtLedgerName = new TextBox();
			this.label2 = new Label();
			this.panel6 = new Panel();
			this.label1 = new Label();
			this.panel7 = new Panel();
			this.panel5 = new Panel();
			this.panel4 = new Panel();
			this.panel3 = new Panel();
			this.panel2 = new Panel();
			this.panel1.SuspendLayout();
			this.panel8.SuspendLayout();
			this.gpbRegister.SuspendLayout();
			this.panel9.SuspendLayout();
			((ISupportInitialize)this.dgvAccountLedger).BeginInit();
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
			this.panel1.Size = new System.Drawing.Size(650, 416);
			this.panel1.TabIndex = 0;
			this.btnSave.BackColor = Color.FromArgb(255, 209, 150);
			this.btnSave.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 1);
			this.btnSave.FlatStyle = FlatStyle.Flat;
			this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.btnSave.Location = new Point(324, 367);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(75, 23);
			this.btnSave.TabIndex = 5;
			this.btnSave.Text = "&Save";
			this.btnSave.UseVisualStyleBackColor = false;
			this.btnSave.Click += new EventHandler(this.btnSave_Click);
			this.btnDelete.BackColor = Color.FromArgb(255, 209, 150);
			this.btnDelete.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 1);
			this.btnDelete.FlatStyle = FlatStyle.Flat;
			this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.btnDelete.Location = new Point(405, 367);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(75, 23);
			this.btnDelete.TabIndex = 6;
			this.btnDelete.Text = "&Delete";
			this.btnDelete.UseVisualStyleBackColor = false;
			this.btnDelete.Click += new EventHandler(this.btnDelete_Click);
			this.btnClear.BackColor = Color.FromArgb(255, 209, 150);
			this.btnClear.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 1);
			this.btnClear.FlatStyle = FlatStyle.Flat;
			this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.btnClear.Location = new Point(486, 367);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(75, 23);
			this.btnClear.TabIndex = 7;
			this.btnClear.Text = "C&lear";
			this.btnClear.UseVisualStyleBackColor = false;
			this.btnClear.Click += new EventHandler(this.btnClear_Click);
			this.btnClose.BackColor = Color.FromArgb(255, 209, 150);
			this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnClose.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 1);
			this.btnClose.FlatStyle = FlatStyle.Flat;
			this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.btnClose.Location = new Point(567, 367);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(75, 23);
			this.btnClose.TabIndex = 8;
			this.btnClose.Text = "&Close";
			this.btnClose.UseVisualStyleBackColor = false;
			this.btnClose.Click += new EventHandler(this.btnClose_Click);
			this.panel8.BackgroundImage = (Image)componentResourceManager.GetObject("panel8.BackgroundImage");
			this.panel8.BackgroundImageLayout = ImageLayout.Stretch;
			this.panel8.Controls.Add(this.txtOpeningBalance);
			this.panel8.Controls.Add(this.label8);
			this.panel8.Controls.Add(this.label7);
			this.panel8.Controls.Add(this.cmbDebitOrCredit);
			this.panel8.Controls.Add(this.btnNew);
			this.panel8.Controls.Add(this.gpbRegister);
			this.panel8.Controls.Add(this.txtDescription);
			this.panel8.Controls.Add(this.label4);
			this.panel8.Controls.Add(this.label3);
			this.panel8.Controls.Add(this.cmbGroupUnder);
			this.panel8.Controls.Add(this.txtLedgerName);
			this.panel8.Controls.Add(this.label2);
			this.panel8.Dock = DockStyle.Top;
			this.panel8.Location = new Point(1, 34);
			this.panel8.Name = "panel8";
			this.panel8.Padding = new System.Windows.Forms.Padding(5);
			this.panel8.Size = new System.Drawing.Size(648, 327);
			this.panel8.TabIndex = 0;
			this.txtOpeningBalance.Location = new Point(134, 63);
			this.txtOpeningBalance.Margin = new System.Windows.Forms.Padding(15, 15, 15, 5);
			this.txtOpeningBalance.MaxLength = 8;
			this.txtOpeningBalance.Name = "txtOpeningBalance";
			this.txtOpeningBalance.Size = new System.Drawing.Size(174, 20);
			this.txtOpeningBalance.TabIndex = 2;
			this.txtOpeningBalance.Text = "0.00";
			this.txtOpeningBalance.Enter += new EventHandler(this.txtOpeningBalance_Enter);
			this.txtOpeningBalance.Leave += new EventHandler(this.txtOpeningBalance_Leave);
			this.txtOpeningBalance.KeyPress += new KeyPressEventHandler(this.txtOpeningBalance_KeyPress);
			this.label8.AutoSize = true;
			this.label8.Location = new Point(8, 93);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(63, 13);
			this.label8.TabIndex = 13;
			this.label8.Text = "Description:";
			this.label7.AutoSize = true;
			this.label7.Location = new Point(8, 71);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(92, 13);
			this.label7.TabIndex = 12;
			this.label7.Text = "Opening Balance:";
			this.cmbDebitOrCredit.DropDownStyle = ComboBoxStyle.DropDownList;
			this.cmbDebitOrCredit.FormattingEnabled = true;
			this.cmbDebitOrCredit.Items.AddRange(new object[] { "Dr", "Cr" });
			this.cmbDebitOrCredit.Location = new Point(314, 63);
			this.cmbDebitOrCredit.Name = "cmbDebitOrCredit";
			this.cmbDebitOrCredit.Size = new System.Drawing.Size(52, 21);
			this.cmbDebitOrCredit.TabIndex = 3;
			this.cmbDebitOrCredit.KeyPress += new KeyPressEventHandler(this.cmbDebitOrCredit_KeyPress);
			this.cmbDebitOrCredit.KeyDown += new KeyEventHandler(this.cmbDebitOrCredit_KeyDown);
			this.btnNew.BackColor = Color.SteelBlue;
			this.btnNew.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 1);
			this.btnNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.btnNew.ForeColor = Color.White;
			this.btnNew.Location = new Point(312, 36);
			this.btnNew.Name = "btnNew";
			this.btnNew.Size = new System.Drawing.Size(54, 23);
			this.btnNew.TabIndex = 678678;
			this.btnNew.TabStop = false;
			this.btnNew.Text = "New";
			this.btnNew.UseVisualStyleBackColor = false;
			this.btnNew.Click += new EventHandler(this.btnNew_Click);
			this.gpbRegister.BackColor = Color.White;
			this.gpbRegister.Controls.Add(this.panel9);
			this.gpbRegister.Location = new Point(390, 8);
			this.gpbRegister.Name = "gpbRegister";
			this.gpbRegister.Padding = new System.Windows.Forms.Padding(5);
			this.gpbRegister.Size = new System.Drawing.Size(251, 309);
			this.gpbRegister.TabIndex = 10;
			this.gpbRegister.TabStop = false;
			this.gpbRegister.Text = "Register";
			this.panel9.Controls.Add(this.dgvAccountLedger);
			this.panel9.Controls.Add(this.txtSearch);
			this.panel9.Controls.Add(this.label6);
			this.panel9.Controls.Add(this.cmbSearchBy);
			this.panel9.Controls.Add(this.label5);
			this.panel9.Controls.Add(this.rbtnNonBuiltIn);
			this.panel9.Controls.Add(this.rbtnBuiltIn);
			this.panel9.Controls.Add(this.rbtnAll);
			this.panel9.Dock = DockStyle.Fill;
			this.panel9.Location = new Point(5, 18);
			this.panel9.Name = "panel9";
			this.panel9.Size = new System.Drawing.Size(241, 286);
			this.panel9.TabIndex = 10;
			this.dgvAccountLedger.AllowUserToAddRows = false;
			this.dgvAccountLedger.AllowUserToDeleteRows = false;
			this.dgvAccountLedger.AllowUserToOrderColumns = true;
			this.dgvAccountLedger.AllowUserToResizeColumns = false;
			this.dgvAccountLedger.AllowUserToResizeRows = false;
			this.dgvAccountLedger.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvAccountLedger.BackgroundColor = Color.White;
			this.dgvAccountLedger.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			DataGridViewColumnCollection columns = this.dgvAccountLedger.Columns;
			DataGridViewColumn[] d = new DataGridViewColumn[] { this.ID, this.LedgerName };
			columns.AddRange(d);
			this.dgvAccountLedger.GridColor = Color.WhiteSmoke;
			this.dgvAccountLedger.Location = new Point(9, 81);
			this.dgvAccountLedger.MultiSelect = false;
			this.dgvAccountLedger.Name = "dgvAccountLedger";
			this.dgvAccountLedger.ReadOnly = true;
			this.dgvAccountLedger.RowHeadersVisible = false;
			this.dgvAccountLedger.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			this.dgvAccountLedger.Size = new System.Drawing.Size(225, 200);
			this.dgvAccountLedger.TabIndex = 456462;
			this.dgvAccountLedger.TabStop = false;
			this.dgvAccountLedger.CellClick += new DataGridViewCellEventHandler(this.dgvAccountLedger_CellClick);
			this.dgvAccountLedger.ColumnHeaderMouseClick += new DataGridViewCellMouseEventHandler(this.dgvAccountLedger_ColumnHeaderMouseClick);
			this.dgvAccountLedger.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(this.dgvAccountLedger_DataBindingComplete);
			this.dgvAccountLedger.KeyUp += new KeyEventHandler(this.dgvAccountLedger_KeyUp);
			this.ID.HeaderText = "ID";
			this.ID.Name = "ID";
			this.ID.ReadOnly = true;
			this.ID.Visible = false;
			this.LedgerName.HeaderText = "Ledger Name";
			this.LedgerName.Name = "LedgerName";
			this.LedgerName.ReadOnly = true;
			this.txtSearch.Location = new Point(86, 55);
			this.txtSearch.MaxLength = 50;
			this.txtSearch.Name = "txtSearch";
			this.txtSearch.Size = new System.Drawing.Size(148, 20);
			this.txtSearch.TabIndex = 456461;
			this.txtSearch.TabStop = false;
			this.txtSearch.TextChanged += new EventHandler(this.txtSearch_TextChanged);
			this.label6.AutoSize = true;
			this.label6.Location = new Point(6, 62);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(62, 13);
			this.label6.TabIndex = 456458;
			this.label6.Text = "Search For:";
			this.cmbSearchBy.DropDownStyle = ComboBoxStyle.DropDownList;
			this.cmbSearchBy.FormattingEnabled = true;
			this.cmbSearchBy.Location = new Point(86, 28);
			this.cmbSearchBy.Name = "cmbSearchBy";
			this.cmbSearchBy.Size = new System.Drawing.Size(148, 21);
			this.cmbSearchBy.TabIndex = 456460;
			this.cmbSearchBy.TabStop = false;
			this.cmbSearchBy.SelectedIndexChanged += new EventHandler(this.cmbSearchBy_SelectedIndexChanged);
			this.cmbSearchBy.KeyPress += new KeyPressEventHandler(this.cmbSearchBy_KeyPress);
			this.cmbSearchBy.KeyDown += new KeyEventHandler(this.cmbSearchBy_KeyDown);
			this.label5.AutoSize = true;
			this.label5.Location = new Point(6, 35);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(59, 13);
			this.label5.TabIndex = 456457;
			this.label5.Text = "Search By:";
			this.rbtnNonBuiltIn.AutoSize = true;
			this.rbtnNonBuiltIn.Location = new Point(158, 5);
			this.rbtnNonBuiltIn.Name = "rbtnNonBuiltIn";
			this.rbtnNonBuiltIn.Size = new System.Drawing.Size(76, 17);
			this.rbtnNonBuiltIn.TabIndex = 456464;
			this.rbtnNonBuiltIn.TabStop = true;
			this.rbtnNonBuiltIn.Text = "Not Built in";
			this.rbtnNonBuiltIn.UseVisualStyleBackColor = true;
			this.rbtnNonBuiltIn.CheckedChanged += new EventHandler(this.rbtnNonBuiltIn_CheckedChanged);
			this.rbtnBuiltIn.AutoSize = true;
			this.rbtnBuiltIn.Location = new Point(96, 5);
			this.rbtnBuiltIn.Name = "rbtnBuiltIn";
			this.rbtnBuiltIn.Size = new System.Drawing.Size(56, 17);
			this.rbtnBuiltIn.TabIndex = 456465;
			this.rbtnBuiltIn.TabStop = true;
			this.rbtnBuiltIn.Text = "Built in";
			this.rbtnBuiltIn.UseVisualStyleBackColor = true;
			this.rbtnBuiltIn.CheckedChanged += new EventHandler(this.rbtnBuiltIn_CheckedChanged);
			this.rbtnAll.AutoSize = true;
			this.rbtnAll.Location = new Point(51, 5);
			this.rbtnAll.Name = "rbtnAll";
			this.rbtnAll.Size = new System.Drawing.Size(36, 17);
			this.rbtnAll.TabIndex = 10;
			this.rbtnAll.Text = "All";
			this.rbtnAll.UseVisualStyleBackColor = true;
			this.rbtnAll.CheckedChanged += new EventHandler(this.rbtnAll_CheckedChanged);
			this.txtDescription.Location = new Point(134, 90);
			this.txtDescription.Multiline = true;
			this.txtDescription.Name = "txtDescription";
			this.txtDescription.Size = new System.Drawing.Size(232, 79);
			this.txtDescription.TabIndex = 4;
			this.txtDescription.Enter += new EventHandler(this.txtDescription_Enter);
			this.txtDescription.KeyPress += new KeyPressEventHandler(this.txtDescription_KeyPress);
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
			this.label3.Size = new System.Drawing.Size(39, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "Group:";
			this.cmbGroupUnder.DropDownStyle = ComboBoxStyle.DropDownList;
			this.cmbGroupUnder.FormattingEnabled = true;
			this.cmbGroupUnder.Location = new Point(134, 36);
			this.cmbGroupUnder.Name = "cmbGroupUnder";
			this.cmbGroupUnder.Size = new System.Drawing.Size(174, 21);
			this.cmbGroupUnder.TabIndex = 1;
			this.cmbGroupUnder.KeyPress += new KeyPressEventHandler(this.cmbGroupUnder_KeyPress);
			this.cmbGroupUnder.KeyDown += new KeyEventHandler(this.cmbGroupUnder_KeyDown);
			this.txtLedgerName.Location = new Point(134, 10);
			this.txtLedgerName.MaxLength = 50;
			this.txtLedgerName.Name = "txtLedgerName";
			this.txtLedgerName.Size = new System.Drawing.Size(232, 20);
			this.txtLedgerName.TabIndex = 0;
			this.txtLedgerName.Leave += new EventHandler(this.txtLedgerName_Leave);
			this.txtLedgerName.KeyPress += new KeyPressEventHandler(this.txtLedgerName_KeyPress);
			this.label2.AutoSize = true;
			this.label2.Location = new Point(8, 17);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(74, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Ledger Name:";
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
			this.label1.Size = new System.Drawing.Size(106, 15);
			this.label1.TabIndex = 4;
			this.label1.Text = "Account Ledger";
			this.panel7.BackColor = Color.FromArgb(136, 136, 136);
			this.panel7.Dock = DockStyle.Bottom;
			this.panel7.Location = new Point(0, 32);
			this.panel7.Name = "panel7";
			this.panel7.Size = new System.Drawing.Size(648, 1);
			this.panel7.TabIndex = 3;
			this.panel5.BackColor = Color.FromArgb(136, 136, 136);
			this.panel5.Dock = DockStyle.Bottom;
			this.panel5.Location = new Point(1, 415);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(648, 1);
			this.panel5.TabIndex = 3;
			this.panel4.BackColor = Color.FromArgb(136, 136, 136);
			this.panel4.Dock = DockStyle.Top;
			this.panel4.Location = new Point(1, 0);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(648, 1);
			this.panel4.TabIndex = 3;
			this.panel3.BackColor = Color.FromArgb(136, 136, 136);
			this.panel3.Dock = DockStyle.Right;
			this.panel3.Location = new Point(649, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(1, 416);
			this.panel3.TabIndex = 3;
			this.panel2.BackColor = Color.FromArgb(136, 136, 136);
			this.panel2.Dock = DockStyle.Left;
			this.panel2.Location = new Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(1, 416);
			this.panel2.TabIndex = 3;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.BackColor = Color.White;
			base.CancelButton = this.btnClose;
			base.ClientSize = new System.Drawing.Size(664, 430);
			base.Controls.Add(this.panel1);
			base.Icon = (System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.Name = "frmAccountLedger";
			base.Padding = new System.Windows.Forms.Padding(7);
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "Account Ledger";
			base.FormClosing += new FormClosingEventHandler(this.frmAccountLedger_FormClosing);
			base.Load += new EventHandler(this.frmAccountLedger_Load);
			this.panel1.ResumeLayout(false);
			this.panel8.ResumeLayout(false);
			this.panel8.PerformLayout();
			this.gpbRegister.ResumeLayout(false);
			this.panel9.ResumeLayout(false);
			this.panel9.PerformLayout();
			((ISupportInitialize)this.dgvAccountLedger).EndInit();
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

		private void rbtnAll_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				this.FillAccountLedgerGrid();
				this.txtSearch.Clear();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void rbtnBuiltIn_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				this.FillAccountLedgerGrid();
				this.txtSearch.Clear();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void rbtnNonBuiltIn_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				this.FillAccountLedgerGrid();
				this.txtSearch.Clear();
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
					frmAccountLedger _frmAccountLedger = this;
					_frmAccountLedger.inDescriptionCount = _frmAccountLedger.inDescriptionCount + 1;
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

		private void txtLedgerName_KeyPress(object sender, KeyPressEventArgs e)
		{
			try
			{
				if (e.KeyChar == '\r')
				{
					this.cmbGroupUnder.Focus();
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void txtLedgerName_Leave(object sender, EventArgs e)
		{
			try
			{
				if (MDIMedicalShop.MDIObj.ActiveMdiChild == this)
				{
					if ((this.txtSearch.Focused || this.dgvAccountLedger.Focused || this.cmbSearchBy.Focused || this.isFormClose ? false : !this.btnNew.Focused))
					{
						if (this.txtLedgerName.Text.Trim() == "")
						{
							this.txtLedgerName.Focus();
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

		private void txtSearch_TextChanged(object sender, EventArgs e)
		{
			try
			{
				for (int i = 0; i < this.dgvAccountLedger.Rows.Count; i++)
				{
					if (!this.dgvAccountLedger[1, i].Value.ToString().ToLower().StartsWith(this.txtSearch.Text.ToLower()))
					{
						this.dgvAccountLedger.Rows[i].Visible = false;
					}
					else
					{
						this.dgvAccountLedger.Rows[i].Visible = true;
					}
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

        private void saveOrEditDetails()
        {
            try
            {
                DataTable dataTable = new DataTable();
                if (!FinacialYearInfo._activeOrNot)
                {
                    MessageBox.Show("Selected finacial year has been closed", "Pharmacy", MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                }
                else
                {
                    this.txtLedgerName.Text = this.txtLedgerName.Text.Trim();
                    if (!(this.txtLedgerName.Text != ""))
                    {
                        MessageBox.Show("Enter ledger name", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        this.txtLedgerName.Select();
                        this.txtLedgerName.Focus();
                    }
                    else if ((this.cmbGroupUnder.SelectedValue == null || !(this.cmbGroupUnder.SelectedValue.ToString() !="") ? true : this.cmbGroupUnder.SelectedIndex == -1))
                    {
                        MessageBox.Show("Select Group", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        this.cmbGroupUnder.Select();
                        this.cmbGroupUnder.Focus();
                    }
                    else
                    {
                        this.accountledgerinfo.AcccountLedgerName = this.txtLedgerName.Text;
                        if (this.cmbGroupUnder.SelectedValue == null)
                        {
                            this.accountledgerinfo.AccountGroupId = "";
                        }
                        else
                        {
                            this.accountledgerinfo.AccountGroupId = this.cmbGroupUnder.SelectedValue.ToString();
                        }
                        if (txtOpeningBalance.Text == null)
                        {
                            this.accountledgerinfo.OpeningBalance = 0;
                        }
                        else
                        {
                            this.accountledgerinfo.OpeningBalance = decimal.Parse(txtOpeningBalance.Text);
                        }
                        if (txtDescription.Text == null)
                        {
                            this.accountledgerinfo.Description = "";
                        }
                        else
                        {
                            this.accountledgerinfo.Description = txtDescription.Text;
                        }




                        if (this.isAutoGenerate)
                        {
                            if (this.CheckExistanceOfLedgerName())
                            {
                                MessageBox.Show("Ledger name already exist", "Pharmacy", MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                                this.txtLedgerName.Focus();
                                this.txtLedgerName.SelectAll();
                            }
                            else if (!(this.btnSave.Text == "&Save"))
                            {
                                this.accountledgerinfo.LedgerId = strLedgerIdForEdit;
                                this.accountledgerSP.AccountLedgerEdit(this.accountledgerinfo);
                                MessageBox.Show("Updated successfully", "Pharmacy", MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                                this.ClearFunction();
                            }
                            else
                            {
                                this.accountledgerinfo.LedgerId = "0";
                                this.accountledgerSP.AccountLedgerAdd(this.accountledgerinfo);
                                MessageBox.Show("Saved successfully", "Pharmacy", MessageBoxButtons.OK,MessageBoxIcon.Asterisk);

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

        public bool CheckExistanceOfLedgerName()
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