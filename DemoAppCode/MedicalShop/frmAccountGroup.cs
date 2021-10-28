using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;

namespace MedicalShop
{
	public class frmAccountGroup : Form
	{
        private MedicalShop.AccountGroupInfo AccountGroupInfo = new MedicalShop.AccountGroupInfo();
        private MedicalShop.AccountGroupSP AccountGroupSP = new MedicalShop.AccountGroupSP();
        private Boolean isAutoGenerate=true;



        private IContainer components = null;

		private Panel panel1;

		private Panel panel5;

		private Panel panel4;

		private Panel panel3;

		private Panel panel2;

		private Panel panel6;

		private Panel panel7;

		private Label label1;

		private Panel panel8;

		private Label label3;

		private ComboBox cmbGroupUnder;

		private TextBox txtGroupName;

		private Label label2;

		private TextBox txtDescription;

		private Label label4;

		private Button btnClose;

		private Button btnDelete;

		private Button btnClear;

		private Button btnSave;

		private GroupBox gbpRegister;

		private Panel panel9;

		private DataGridView dgvAccountGroupRegister;

		private TextBox txtSearch;

		private Label label6;

		private ComboBox cmbSearchBy;

		private Label label5;

		private RadioButton rbtnNonBuiltIn;

		private RadioButton rbtnBuiltIn;

		private RadioButton rbtnAll;

		private DataGridViewTextBoxColumn ID;

		private DataGridViewTextBoxColumn GroupName;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;

		private Label label8;

		private AccountGroupSP accountgroupSP = new AccountGroupSP();

		private frmAccountLedger frmaccountledger;

		private bool isInEditMode = false;

		private bool isFromAccountCreationForm = false;

		private bool isFormClose = false;

		private string strGroupIdForEdit = "";

		private string strGroupIdForOtherForms = "";

		private string strGroupName = "";

		private int inDescriptionCount = 0;

		public frmAccountGroup()
		{
			this.InitializeComponent();
		}

		private void btnClear_Click(object sender, EventArgs e)
		{
			try
			{
				this.ClearFunction();
				this.txtGroupName.Focus();
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
                this.AccountGroupSP.AccountGroupDelete(this.strGroupIdForEdit);
                MessageBox.Show("Deleted successfully", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.ClearFunction();
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
                //MessageBox.Show("Thank you for using Pharmacy.To gain access please buy full version", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.saveOrEditDetails();
            }
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		public bool CheckExistanceOfGroupIdInOtherTables()
		{
			bool flag = false;
			DataTable dataTable = new DataTable();
			dataTable = (new AccountLedgerSP()).AccountLedgerViewAll();
			if (dataTable.Rows.Count > 0)
			{
				foreach (DataRow row in dataTable.Rows)
				{
					if (!(this.strGroupIdForEdit == row.ItemArray[2].ToString()))
					{
						flag = false;
					}
					else
					{
						flag = true;
						break;
					}
				}
			}
			return flag;
		}

		public void ClearFunction()
		{
			try
			{
				this.strGroupIdForEdit = "";
				this.strGroupIdForOtherForms = "";
				this.strGroupName = "";
				this.txtDescription.Clear();
				this.txtGroupName.Clear();
				this.txtSearch.Clear();
				this.cmbSearchBy.Text = "All";
				this.FillAccountGroupGrid();
				this.FillAccountGroupCombo();
				this.FillSearchByCombo();
				this.btnSave.Text = "&Save";
				this.btnClear.Text = "C&lear";
				this.cmbGroupUnder.SelectedValue = 0;
				this.isInEditMode = false;
				this.btnDelete.Enabled = false;
				this.cmbGroupUnder.Enabled = true;
				this.rbtnAll.Checked = true;
				this.txtGroupName.Focus();
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

		private void cmbGroupUnder_KeyPress(object sender, KeyPressEventArgs e)
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

		private void cmbSearchBy_KeyDown(object sender, KeyEventArgs e)
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
				this.FillAccountGroupGrid();
				this.txtSearch.Clear();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void dgvAccountGroupRegister_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				if (this.dgvAccountGroupRegister.CurrentRow != null)
				{
					if ((this.dgvAccountGroupRegister.Rows.Count <= 0 ? false : e.ColumnIndex > -1))
					{
						if (this.dgvAccountGroupRegister.CurrentRow.Cells[0].Value != null)
						{
							if (this.dgvAccountGroupRegister.CurrentRow.Cells[0].Value.ToString() != "")
							{
								this.strGroupIdForEdit = this.dgvAccountGroupRegister.CurrentRow.Cells[0].Value.ToString();
								this.strGroupName = this.dgvAccountGroupRegister.CurrentRow.Cells[1].Value.ToString();
								this.FillAccountGroupCombo();
								this.FillControlsForEdit();
								this.dgvAccountGroupRegister.CurrentRow.Selected = true;
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

		private void dgvAccountGroupRegister_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			try
			{
				DataGridViewCellEventArgs dataGridViewCellEventArg = new DataGridViewCellEventArgs(e.ColumnIndex, e.RowIndex);
				this.dgvAccountGroupRegister_CellClick(sender, dataGridViewCellEventArg);
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void dgvAccountGroupRegister_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
		{
			((DataGridView)sender).ClearSelection();
		}

		private void dgvAccountGroupRegister_KeyUp(object sender, KeyEventArgs e)
		{
			try
			{
				if ((e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Return ? true : e.KeyCode == Keys.Tab))
				{
					if (this.dgvAccountGroupRegister.CurrentRow != null)
					{
						DataGridViewCellEventArgs dataGridViewCellEventArg = new DataGridViewCellEventArgs(this.dgvAccountGroupRegister.CurrentCell.ColumnIndex, this.dgvAccountGroupRegister.CurrentCell.RowIndex);
						this.dgvAccountGroupRegister_CellClick(sender, dataGridViewCellEventArg);
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

		public void FillAccountGroupCombo()
		{
			try
			{
				DataTable dataTable = new DataTable();
				dataTable = this.accountgroupSP.AccountGroupViewAll();
				if (this.strGroupIdForEdit != "")
				{
					foreach (DataRow row in dataTable.Rows)
					{
						if (this.strGroupIdForEdit == row.ItemArray[0].ToString())
						{
							if (this.strGroupIdForEdit != "0")
							{
								dataTable.Rows.Remove(row);
								break;
							}
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

		public void FillAccountGroupGrid()
		{
			try
			{
				DataTable dataTable = new DataTable();
				if (!(this.cmbSearchBy.Text == "All" || this.cmbSearchBy.Text == "" || this.cmbSearchBy.SelectedValue == null ? false : !(this.cmbSearchBy.SelectedValue.ToString() == "System.Data.DataRowView")))
				{
					if (this.rbtnAll.Checked)
					{
						dataTable = this.accountgroupSP.AccountGroupViewAll();
					}
					else if (this.rbtnBuiltIn.Checked)
					{
						dataTable = this.accountgroupSP.AccountGroupViewAllByStatus(true);
					}
					else if (this.rbtnNonBuiltIn.Checked)
					{
						dataTable = this.accountgroupSP.AccountGroupViewAllByStatus(false);
					}
				}
				else if (this.rbtnAll.Checked)
				{
					dataTable = this.accountgroupSP.AccountGroupViewAllByAccountGroupId(this.cmbSearchBy.SelectedValue.ToString());
				}
				else if (this.rbtnBuiltIn.Checked)
				{
					dataTable = this.accountgroupSP.AccountGroupViewAllByAccountGroupIdAndStatus(this.cmbSearchBy.SelectedValue.ToString(), true);
				}
				else if (this.rbtnNonBuiltIn.Checked)
				{
					dataTable = this.accountgroupSP.AccountGroupViewAllByAccountGroupIdAndStatus(this.cmbSearchBy.SelectedValue.ToString(), false);
				}
				this.dgvAccountGroupRegister.Rows.Clear();
				int str = 0;
				foreach (DataRow row in dataTable.Rows)
				{
					this.dgvAccountGroupRegister.Rows.Add();
					this.dgvAccountGroupRegister.Rows[str].Cells[0].Value = row.ItemArray[0].ToString();
					this.dgvAccountGroupRegister.Rows[str].Cells[1].Value = row.ItemArray[1].ToString();
					str++;
				}
				this.dgvAccountGroupRegister.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
				this.dgvAccountGroupRegister.ClearSelection();
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
				AccountGroupInfo accountGroupInfo = new AccountGroupInfo();
				accountGroupInfo = this.accountgroupSP.AccountGroupView(this.strGroupIdForEdit);
				this.txtGroupName.Text = accountGroupInfo.AccountGroupName;
				this.txtDescription.Text = accountGroupInfo.Description;
				this.cmbGroupUnder.SelectedValue = accountGroupInfo.GroupUnder;
				if (accountGroupInfo.DefaultOrNot)
				{
					this.cmbGroupUnder.Enabled = true;
				}
				else if (!this.CheckExistanceOfGroupIdInOtherTables())
				{
					this.cmbGroupUnder.Enabled = true;
				}
				else
				{
					this.cmbGroupUnder.Enabled = false;
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

		private void frmAccountGroup_FormClosing(object sender, FormClosingEventArgs e)
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

		private void frmAccountGroup_Load(object sender, EventArgs e)
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
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmAccountGroup));
			this.panel1 = new Panel();
			this.btnSave = new Button();
			this.btnDelete = new Button();
			this.btnClear = new Button();
			this.btnClose = new Button();
			this.panel8 = new Panel();
			this.label8 = new Label();
			this.gbpRegister = new GroupBox();
			this.panel9 = new Panel();
			this.txtSearch = new TextBox();
			this.label6 = new Label();
			this.cmbSearchBy = new ComboBox();
			this.label5 = new Label();
			this.rbtnNonBuiltIn = new RadioButton();
			this.rbtnBuiltIn = new RadioButton();
			this.rbtnAll = new RadioButton();
			this.dgvAccountGroupRegister = new DataGridView();
			this.ID = new DataGridViewTextBoxColumn();
			this.GroupName = new DataGridViewTextBoxColumn();
			this.txtDescription = new TextBox();
			this.label4 = new Label();
			this.label3 = new Label();
			this.cmbGroupUnder = new ComboBox();
			this.txtGroupName = new TextBox();
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
			this.gbpRegister.SuspendLayout();
			this.panel9.SuspendLayout();
			((ISupportInitialize)this.dgvAccountGroupRegister).BeginInit();
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
			this.panel1.Size = new System.Drawing.Size(588, 385);
			this.panel1.TabIndex = 1;
			this.btnSave.BackColor = Color.FromArgb(255, 209, 150);
			this.btnSave.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 1);
			this.btnSave.FlatStyle = FlatStyle.Flat;
			this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.btnSave.Location = new Point(263, 336);
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
			this.btnDelete.Location = new Point(344, 336);
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
			this.btnClear.Location = new Point(425, 336);
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
			this.btnClose.Location = new Point(506, 336);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(75, 23);
			this.btnClose.TabIndex = 6;
			this.btnClose.Text = "&Close";
			this.btnClose.UseVisualStyleBackColor = false;
			this.btnClose.Click += new EventHandler(this.btnClose_Click);
			this.panel8.BackgroundImage = (Image)componentResourceManager.GetObject("panel8.BackgroundImage");
			this.panel8.BackgroundImageLayout = ImageLayout.Stretch;
			this.panel8.Controls.Add(this.label8);
			this.panel8.Controls.Add(this.gbpRegister);
			this.panel8.Controls.Add(this.txtDescription);
			this.panel8.Controls.Add(this.label4);
			this.panel8.Controls.Add(this.label3);
			this.panel8.Controls.Add(this.cmbGroupUnder);
			this.panel8.Controls.Add(this.txtGroupName);
			this.panel8.Controls.Add(this.label2);
			this.panel8.Dock = DockStyle.Top;
			this.panel8.Location = new Point(1, 34);
			this.panel8.Name = "panel8";
			this.panel8.Padding = new System.Windows.Forms.Padding(5);
			this.panel8.Size = new System.Drawing.Size(586, 296);
			this.panel8.TabIndex = 0;
			this.label8.AutoSize = true;
			this.label8.Location = new Point(15, 76);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(63, 13);
			this.label8.TabIndex = 14;
			this.label8.Text = "Description:";
			this.gbpRegister.BackColor = Color.White;
			this.gbpRegister.Controls.Add(this.panel9);
			this.gbpRegister.Location = new Point(327, 6);
			this.gbpRegister.Name = "gbpRegister";
			this.gbpRegister.Padding = new System.Windows.Forms.Padding(5);
			this.gbpRegister.Size = new System.Drawing.Size(251, 275);
			this.gbpRegister.TabIndex = 10;
			this.gbpRegister.TabStop = false;
			this.gbpRegister.Text = "Register";
			this.panel9.Controls.Add(this.txtSearch);
			this.panel9.Controls.Add(this.label6);
			this.panel9.Controls.Add(this.cmbSearchBy);
			this.panel9.Controls.Add(this.label5);
			this.panel9.Controls.Add(this.rbtnNonBuiltIn);
			this.panel9.Controls.Add(this.rbtnBuiltIn);
			this.panel9.Controls.Add(this.rbtnAll);
			this.panel9.Controls.Add(this.dgvAccountGroupRegister);
			this.panel9.Dock = DockStyle.Fill;
			this.panel9.Location = new Point(5, 18);
			this.panel9.Name = "panel9";
			this.panel9.Size = new System.Drawing.Size(241, 252);
			this.panel9.TabIndex = 10;
			this.txtSearch.Location = new Point(86, 55);
			this.txtSearch.MaxLength = 50;
			this.txtSearch.Name = "txtSearch";
			this.txtSearch.Size = new System.Drawing.Size(148, 20);
			this.txtSearch.TabIndex = 11;
			this.txtSearch.TabStop = false;
			this.txtSearch.TextChanged += new EventHandler(this.txtSearch_TextChanged);
			this.label6.AutoSize = true;
			this.label6.Location = new Point(6, 62);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(62, 13);
			this.label6.TabIndex = 13;
			this.label6.Text = "Search For:";
			this.cmbSearchBy.DropDownStyle = ComboBoxStyle.DropDownList;
			this.cmbSearchBy.FormattingEnabled = true;
			this.cmbSearchBy.Location = new Point(86, 28);
			this.cmbSearchBy.Name = "cmbSearchBy";
			this.cmbSearchBy.Size = new System.Drawing.Size(148, 21);
			this.cmbSearchBy.TabIndex = 10;
			this.cmbSearchBy.TabStop = false;
			this.cmbSearchBy.SelectedIndexChanged += new EventHandler(this.cmbSearchBy_SelectedIndexChanged);
			this.cmbSearchBy.KeyDown += new KeyEventHandler(this.cmbSearchBy_KeyDown);
			this.label5.AutoSize = true;
			this.label5.Location = new Point(6, 35);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(59, 13);
			this.label5.TabIndex = 9;
			this.label5.Text = "Search By:";
			this.rbtnNonBuiltIn.AutoSize = true;
			this.rbtnNonBuiltIn.Location = new Point(158, 5);
			this.rbtnNonBuiltIn.Name = "rbtnNonBuiltIn";
			this.rbtnNonBuiltIn.Size = new System.Drawing.Size(76, 17);
			this.rbtnNonBuiltIn.TabIndex = 1533;
			this.rbtnNonBuiltIn.Text = "Not Built in";
			this.rbtnNonBuiltIn.UseVisualStyleBackColor = true;
			this.rbtnNonBuiltIn.CheckedChanged += new EventHandler(this.rbtnNonBuiltIn_CheckedChanged);
			this.rbtnBuiltIn.AutoSize = true;
			this.rbtnBuiltIn.Location = new Point(96, 5);
			this.rbtnBuiltIn.Name = "rbtnBuiltIn";
			this.rbtnBuiltIn.Size = new System.Drawing.Size(56, 17);
			this.rbtnBuiltIn.TabIndex = 1255;
			this.rbtnBuiltIn.Text = "Built in";
			this.rbtnBuiltIn.UseVisualStyleBackColor = true;
			this.rbtnBuiltIn.CheckedChanged += new EventHandler(this.rbtnBuiltIn_CheckedChanged);
			this.rbtnAll.AutoSize = true;
			this.rbtnAll.Location = new Point(51, 5);
			this.rbtnAll.Name = "rbtnAll";
			this.rbtnAll.Size = new System.Drawing.Size(36, 17);
			this.rbtnAll.TabIndex = 1500;
			this.rbtnAll.TabStop = true;
			this.rbtnAll.Text = "All";
			this.rbtnAll.UseVisualStyleBackColor = true;
			this.rbtnAll.CheckedChanged += new EventHandler(this.rbtnAll_CheckedChanged);
			this.dgvAccountGroupRegister.AllowUserToAddRows = false;
			this.dgvAccountGroupRegister.AllowUserToDeleteRows = false;
			this.dgvAccountGroupRegister.AllowUserToOrderColumns = true;
			this.dgvAccountGroupRegister.AllowUserToResizeColumns = false;
			this.dgvAccountGroupRegister.AllowUserToResizeRows = false;
			this.dgvAccountGroupRegister.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvAccountGroupRegister.BackgroundColor = Color.White;
			this.dgvAccountGroupRegister.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			DataGridViewColumnCollection columns = this.dgvAccountGroupRegister.Columns;
			DataGridViewColumn[] d = new DataGridViewColumn[] { this.ID, this.GroupName };
			columns.AddRange(d);
			this.dgvAccountGroupRegister.GridColor = Color.WhiteSmoke;
			this.dgvAccountGroupRegister.Location = new Point(9, 82);
			this.dgvAccountGroupRegister.MultiSelect = false;
			this.dgvAccountGroupRegister.Name = "dgvAccountGroupRegister";
			this.dgvAccountGroupRegister.ReadOnly = true;
			this.dgvAccountGroupRegister.RowHeadersVisible = false;
			this.dgvAccountGroupRegister.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			this.dgvAccountGroupRegister.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			this.dgvAccountGroupRegister.Size = new System.Drawing.Size(225, 165);
			this.dgvAccountGroupRegister.TabIndex = 12;
			this.dgvAccountGroupRegister.TabStop = false;
			this.dgvAccountGroupRegister.CellClick += new DataGridViewCellEventHandler(this.dgvAccountGroupRegister_CellClick);
			this.dgvAccountGroupRegister.ColumnHeaderMouseClick += new DataGridViewCellMouseEventHandler(this.dgvAccountGroupRegister_ColumnHeaderMouseClick);
			this.dgvAccountGroupRegister.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(this.dgvAccountGroupRegister_DataBindingComplete);
			this.dgvAccountGroupRegister.KeyUp += new KeyEventHandler(this.dgvAccountGroupRegister_KeyUp);
			this.ID.HeaderText = "ID";
			this.ID.Name = "ID";
			this.ID.ReadOnly = true;
			this.ID.Resizable = DataGridViewTriState.False;
			this.ID.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.ID.Visible = false;
			this.GroupName.HeaderText = "Group Name";
			this.GroupName.Name = "GroupName";
			this.GroupName.ReadOnly = true;
			this.GroupName.Resizable = DataGridViewTriState.False;
			this.GroupName.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.txtDescription.Location = new Point(134, 63);
			this.txtDescription.Multiline = true;
			this.txtDescription.Name = "txtDescription";
			this.txtDescription.Size = new System.Drawing.Size(174, 79);
			this.txtDescription.TabIndex = 2;
			this.txtDescription.Enter += new EventHandler(this.txtDescription_Enter);
			this.txtDescription.KeyPress += new KeyPressEventHandler(this.txtDescription_KeyPress);
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label4.ForeColor = Color.Red;
			this.label4.Location = new Point(309, 13);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(12, 13);
			this.label4.TabIndex = 5;
			this.label4.Text = "*";
			this.label3.AutoSize = true;
			this.label3.Location = new Point(15, 44);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(70, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "Group Name:";
			this.cmbGroupUnder.DropDownStyle = ComboBoxStyle.DropDownList;
			this.cmbGroupUnder.FormattingEnabled = true;
			this.cmbGroupUnder.Location = new Point(134, 36);
			this.cmbGroupUnder.Name = "cmbGroupUnder";
			this.cmbGroupUnder.Size = new System.Drawing.Size(174, 21);
			this.cmbGroupUnder.TabIndex = 1;
			this.cmbGroupUnder.KeyPress += new KeyPressEventHandler(this.cmbGroupUnder_KeyPress);
			this.cmbGroupUnder.KeyDown += new KeyEventHandler(this.cmbGroupUnder_KeyDown);
			this.txtGroupName.Location = new Point(134, 10);
			this.txtGroupName.MaxLength = 50;
			this.txtGroupName.Name = "txtGroupName";
			this.txtGroupName.Size = new System.Drawing.Size(174, 20);
			this.txtGroupName.TabIndex = 0;
			this.txtGroupName.Leave += new EventHandler(this.txtGroupName_Leave);
			this.txtGroupName.KeyPress += new KeyPressEventHandler(this.txtGroupName_KeyPress);
			this.label2.AutoSize = true;
			this.label2.Location = new Point(15, 17);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(113, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Account Group Name:";
			this.panel6.BackgroundImage = (Image)componentResourceManager.GetObject("panel6.BackgroundImage");
			this.panel6.Controls.Add(this.label1);
			this.panel6.Controls.Add(this.panel7);
			this.panel6.Dock = DockStyle.Top;
			this.panel6.Location = new Point(1, 1);
			this.panel6.Name = "panel6";
			this.panel6.Size = new System.Drawing.Size(586, 33);
			this.panel6.TabIndex = 0;
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label1.Location = new Point(11, 7);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 15);
			this.label1.TabIndex = 4;
			this.label1.Text = "Account Group";
			this.panel7.BackColor = Color.FromArgb(136, 136, 136);
			this.panel7.Dock = DockStyle.Bottom;
			this.panel7.Location = new Point(0, 32);
			this.panel7.Name = "panel7";
			this.panel7.Size = new System.Drawing.Size(586, 1);
			this.panel7.TabIndex = 0;
			this.panel5.BackColor = Color.FromArgb(136, 136, 136);
			this.panel5.Dock = DockStyle.Bottom;
			this.panel5.Location = new Point(1, 384);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(586, 1);
			this.panel5.TabIndex = 0;
			this.panel4.BackColor = Color.FromArgb(136, 136, 136);
			this.panel4.Dock = DockStyle.Top;
			this.panel4.Location = new Point(1, 0);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(586, 1);
			this.panel4.TabIndex = 0;
			this.panel3.BackColor = Color.FromArgb(136, 136, 136);
			this.panel3.Dock = DockStyle.Right;
			this.panel3.Location = new Point(587, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(1, 385);
			this.panel3.TabIndex = 0;
			this.panel2.BackColor = Color.FromArgb(136, 136, 136);
			this.panel2.Dock = DockStyle.Left;
			this.panel2.Location = new Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(1, 385);
			this.panel2.TabIndex = 0;
			this.dataGridViewTextBoxColumn1.HeaderText = "ID";
			this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn1.Resizable = DataGridViewTriState.False;
			this.dataGridViewTextBoxColumn1.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.dataGridViewTextBoxColumn1.Visible = false;
			this.dataGridViewTextBoxColumn2.HeaderText = "Group Name";
			this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
			this.dataGridViewTextBoxColumn2.Resizable = DataGridViewTriState.False;
			this.dataGridViewTextBoxColumn2.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.dataGridViewTextBoxColumn2.Width = 222;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.BackColor = Color.White;
			base.CancelButton = this.btnClose;
			base.ClientSize = new System.Drawing.Size(602, 399);
			base.Controls.Add(this.panel1);
			base.Icon = (System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.Name = "frmAccountGroup";
			base.Padding = new System.Windows.Forms.Padding(7);
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "Account Group";
			base.FormClosing += new FormClosingEventHandler(this.frmAccountGroup_FormClosing);
			base.Load += new EventHandler(this.frmAccountGroup_Load);
			this.panel1.ResumeLayout(false);
			this.panel8.ResumeLayout(false);
			this.panel8.PerformLayout();
			this.gbpRegister.ResumeLayout(false);
			this.panel9.ResumeLayout(false);
			this.panel9.PerformLayout();
			((ISupportInitialize)this.dgvAccountGroupRegister).EndInit();
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
			else if (this.txtDescription.Focused)
			{
				this.btnSave.Focus();
				flag = false;
			}
			else if (this.cmbSearchBy.Focused)
			{
				this.txtSearch.Focus();
				flag = false;
			}
			else if (!this.txtSearch.Focused)
			{
				base.ProcessDialogKey(keyData);
				flag = true;
			}
			else
			{
				this.dgvAccountGroupRegister.Focus();
				flag = false;
			}
			return flag;
		}

		private void rbtnAll_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				this.FillAccountGroupGrid();
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
				this.FillAccountGroupGrid();
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
				this.FillAccountGroupGrid();
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
					frmAccountGroup _frmAccountGroup = this;
					_frmAccountGroup.inDescriptionCount = _frmAccountGroup.inDescriptionCount + 1;
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

		private void txtGroupName_KeyPress(object sender, KeyPressEventArgs e)
		{
			try
			{
				if (e.KeyChar == '\r')
				{
					if (!this.cmbGroupUnder.Enabled)
					{
						this.txtDescription.Focus();
					}
					else
					{
						this.cmbGroupUnder.Focus();
					}
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void txtGroupName_Leave(object sender, EventArgs e)
		{
			try
			{
				if (MDIMedicalShop.MDIObj.ActiveMdiChild == this)
				{
					if ((this.txtSearch.Focused || this.dgvAccountGroupRegister.Focused || this.cmbSearchBy.Focused ? false : !this.isFormClose))
					{
						if (this.txtGroupName.Text.Trim() == "")
						{
							this.txtGroupName.Focus();
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

		private void txtSearch_TextChanged(object sender, EventArgs e)
		{
			try
			{
				for (int i = 0; i < this.dgvAccountGroupRegister.Rows.Count; i++)
				{
					if (!this.dgvAccountGroupRegister[1, i].Value.ToString().ToLower().StartsWith(this.txtSearch.Text.ToLower()))
					{
						this.dgvAccountGroupRegister.Rows[i].Visible = false;
					}
					else
					{
						this.dgvAccountGroupRegister.Rows[i].Visible = true;
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
                    MessageBox.Show("Selected finacial year has been closed", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    
                    this.txtGroupName.Text = this.txtGroupName.Text.Trim();
                    
                    if (!(this.txtGroupName.Text != ""))
                    {
                        MessageBox.Show("Enter group name", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        this.txtGroupName.Select();
                        this.txtGroupName.Focus();
                    }
                    else if ((this.cmbGroupUnder.SelectedValue == null || !(this.cmbGroupUnder.SelectedValue.ToString() != "") ? true : this.cmbGroupUnder.SelectedIndex == -1))
                    {
                        MessageBox.Show("Select group", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        this.cmbGroupUnder.Select();
                        this.cmbGroupUnder.Focus();
                    }
                    else
                    {
                        this.AccountGroupInfo.AccountGroupName = this.txtGroupName.Text;
                        this.AccountGroupInfo.AccountGroupId = "0";
                        if (this.txtDescription.Text == null)
                        {
                            this.AccountGroupInfo.Description = "";
                        }
                        else
                        {
                            this.txtDescription.Text = this.txtDescription.Text.Trim();
                            this.AccountGroupInfo.Description = this.txtDescription.Text.ToString();
                        }
                        if (this.cmbGroupUnder.SelectedValue == null)
                        {
                            this.AccountGroupInfo.GroupUnder = "";
                        }
                        else
                        {
                            this.AccountGroupInfo.GroupUnder = this.cmbGroupUnder.SelectedValue.ToString();
                        }


                        if (this.isAutoGenerate)
                        {
                            if (this.CheckExistanceOfGroupName())
                            {
                                MessageBox.Show("Group name already exist", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                this.txtGroupName.Focus();
                                this.txtGroupName.SelectAll();
                            }
                            else if (!(this.btnSave.Text == "&Save"))
                            {
                                this.AccountGroupInfo.AccountGroupId = this.strGroupIdForEdit;
                                this.AccountGroupSP.AccountGroupEdit(this.AccountGroupInfo);
                                MessageBox.Show("Updated successfully", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                this.ClearFunction();
                               
                            }
                            else
                            {
                                this.AccountGroupSP.AccountGroupAdd(this.AccountGroupInfo);
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
        public bool CheckExistanceOfGroupName()
        {
            bool flag;
            string str = this.accountgroupSP.AccountGroupNameCheck(this.txtGroupName.Text.Trim());
            if (!(str != ""))
            {
                flag = false;
            }
            else if (!(this.btnSave.Text == "&Update"))
            {
                flag = true;
            }
            else
            {
                flag = true;
                // flag = (!(this._productNameFromgrid.ToLower() == str.ToLower()) ? true : false);
            }
            return flag;
        }
        public void clear()
        {
            try
            {

                this.txtGroupName.Text = "";
                this.txtDescription.Text = "";
                this.cmbGroupUnder.SelectedIndex = -1;
                this.btnDelete.Enabled = false;
                this.btnSave.Text = "&Save";
                this.btnClear.Text = "C&lear";
                this.FillAccountGroupGrid();
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
    }
}