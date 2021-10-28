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
	public class frmGreetingText : Form
	{
		private IContainer components = null;

		private Panel panel1;

		private Button btnSave;

		private Button btnDelete;

		private Button btnClear;

		private Button btnClose;

		private Panel panel8;

		private TextBox txtMessage;

		private GroupBox groupBox1;

		private Panel panel9;

		private DataGridView dgvSearch;

		private TextBox txtSearch;

		private Label label6;

		private Label label4;

		private Label label3;

		private Label label2;

		private Panel panel6;

		private Label label1;

		private Panel panel7;

		private Panel panel5;

		private Panel panel4;

		private Panel panel3;

		private Panel panel2;

		private DateTimePicker dtpToDate;

		private DateTimePicker dtpFromDate;

		private DateTimePicker dtpSearchDate;

		private Label label5;

		private Label label7;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;

		private DataGridViewTextBoxColumn Column1;

		private DataGridViewTextBoxColumn Column2;

		private DataGridViewTextBoxColumn Column3;

		private DataGridViewTextBoxColumn Column4;

		private DataGridViewTextBoxColumn Column5;

		private CheckBox cbxAll;

		private MedicalShop.GreetingTextSP GreetingTextSP = new MedicalShop.GreetingTextSP();

		private MedicalShop.GreetingTextInfo GreetingTextInfo = new MedicalShop.GreetingTextInfo();

		private string _ID = "";

		private DataTable dtSearch = new DataTable();

		private int intFocus = 0;

		private bool isFormClose = false;

		public frmGreetingText()
		{
			this.InitializeComponent();
		}

		private void btnClear_Click(object sender, EventArgs e)
		{
			try
			{
				this.clear();
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
                GreetingTextSP.GreetingTextDelete(this._ID);
                MessageBox.Show("Deleted successfully", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                clear();
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
				this.saveOrEditDetails();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void cbxAll_CheckedChanged(object sender, EventArgs e)
		{
			if (!this.cbxAll.Checked)
			{
				this.dtpSearchDate.Enabled = true;
			}
			else
			{
				this.dtpSearchDate.Enabled = false;
			}
			this.dgdSearchFill();
		}

		private void cbxAll_Click(object sender, EventArgs e)
		{
		}

		public void clear()
		{
			try
			{
				this.cbxAll.Checked = true;
				this.dtpSearchDate.Enabled = false;
				this.dgdSearchFill();
				this.btnSave.Text = "&Save";
				this.btnClear.Text = "C&lear";
				this.btnDelete.Enabled = false;
				this.txtMessage.Text = "";
				this.txtSearch.Text = "";
				this.dtpFromDate.Focus();
				this._ID = "";
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
						this.btnSave.Text = "&Update";
						this.btnClear.Text = "&New";
						this.btnDelete.Enabled = true;
						this._ID = this.dgvSearch.CurrentRow.Cells[2].Value.ToString();
						this.dtpFromDate.Text = this.dgvSearch.CurrentRow.Cells[3].Value.ToString();
						this.dtpToDate.Text = this.dgvSearch.CurrentRow.Cells[4].Value.ToString();
						this.GreetingTextInfo = this.GreetingTextSP.GreetingTextView(this._ID);
						this.txtMessage.Text = this.GreetingTextInfo.GreetingMessage;
						this.dgvSearch.CurrentRow.Selected = true;
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

		public void dgdSearchFill()
		{
			try
			{
				int rowCount = 0;
				if (this.dtSearch.Rows.Count > 0)
				{
					this.dtSearch.Rows.Clear();
				}
				if (!this.cbxAll.Checked)
				{
					this.dtSearch = this.GreetingTextSP.GreetingTextViewBetweenDate(DateTime.Parse(this.dtpSearchDate.Text.ToString()));
				}
				else
				{
					this.dtSearch = this.GreetingTextSP.GreetingTextViewAll();
				}
				if (this.dgvSearch.RowCount > 0)
				{
					this.dgvSearch.Rows.Clear();
				}
				foreach (DataRow row in this.dtSearch.Rows)
				{
					this.dgvSearch.Rows.Add();
					this.dgvSearch.Rows[rowCount].Cells[0].Value = this.dgvSearch.RowCount;
					string str = row.ItemArray[3].ToString();
					string[] strArrays = Regex.Split(str, "\r\n");
					string str1 = "";
					string[] strArrays1 = strArrays;
					for (int i = 0; i < (int)strArrays1.Length; i++)
					{
						str1 = string.Concat(str1, strArrays1[i], "  ");
					}
					if (!(str1 == " , "))
					{
						int length = str1.Length;
						string str2 = str1.Substring(0, length - 2);
						this.dgvSearch[1, this.dgvSearch.Rows.Count - 1].Value = str2;
					}
					else
					{
						this.dgvSearch[1, this.dgvSearch.Rows.Count - 1].Value = "";
					}
					this.dgvSearch.Rows[rowCount].Cells[2].Value = row.ItemArray[0].ToString();
					this.dgvSearch.Rows[rowCount].Cells[3].Value = row.ItemArray[1].ToString();
					this.dgvSearch.Rows[rowCount].Cells[4].Value = row.ItemArray[2].ToString();
					rowCount++;
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

		private void dtpFromDate_KeyDown(object sender, KeyEventArgs e)
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

		private void dtpFromDate_KeyPress(object sender, KeyPressEventArgs e)
		{
			try
			{
				if (e.KeyChar != '\r')
				{
					this.intFocus = 0;
				}
				else if (!this.txtMessage.Focused)
				{
					this.intFocus = 0;
					SendKeys.Send("{TAB}");
				}
				else
				{
					frmGreetingText _frmGreetingText = this;
					_frmGreetingText.intFocus = _frmGreetingText.intFocus + 1;
					if (this.intFocus == 2)
					{
						this.intFocus = 0;
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

		private void dtpSearchDate_KeyPress(object sender, KeyPressEventArgs e)
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

		private void dtpSearchDate_ValueChanged(object sender, EventArgs e)
		{
			try
			{
				this.dgdSearchFill();
				this.txtSearch.Clear();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void frmGreetingText_FormClosing(object sender, FormClosingEventArgs e)
		{
			this.isFormClose = true;
		}

		private void frmGreetingText_Load(object sender, EventArgs e)
		{
			try
			{
				this.clear();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void InitializeComponent()
		{
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmGreetingText));
			this.panel1 = new Panel();
			this.btnSave = new Button();
			this.btnDelete = new Button();
			this.btnClear = new Button();
			this.btnClose = new Button();
			this.panel8 = new Panel();
			this.label7 = new Label();
			this.dtpToDate = new DateTimePicker();
			this.dtpFromDate = new DateTimePicker();
			this.txtMessage = new TextBox();
			this.groupBox1 = new GroupBox();
			this.panel9 = new Panel();
			this.cbxAll = new CheckBox();
			this.dtpSearchDate = new DateTimePicker();
			this.label5 = new Label();
			this.txtSearch = new TextBox();
			this.label6 = new Label();
			this.dgvSearch = new DataGridView();
			this.Column1 = new DataGridViewTextBoxColumn();
			this.Column2 = new DataGridViewTextBoxColumn();
			this.Column3 = new DataGridViewTextBoxColumn();
			this.Column4 = new DataGridViewTextBoxColumn();
			this.Column5 = new DataGridViewTextBoxColumn();
			this.label4 = new Label();
			this.label3 = new Label();
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
			this.dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
			this.panel1.SuspendLayout();
			this.panel8.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.panel9.SuspendLayout();
			((ISupportInitialize)this.dgvSearch).BeginInit();
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
			this.panel1.Size = new System.Drawing.Size(650, 424);
			this.panel1.TabIndex = 6;
			this.panel1.Paint += new PaintEventHandler(this.panel1_Paint);
			this.btnSave.BackColor = Color.FromArgb(255, 209, 150);
			this.btnSave.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 1);
			this.btnSave.FlatStyle = FlatStyle.Flat;
			this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.btnSave.Location = new Point(324, 370);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(75, 23);
			this.btnSave.TabIndex = 2;
			this.btnSave.Text = "&Save";
			this.btnSave.UseVisualStyleBackColor = false;
			this.btnSave.Click += new EventHandler(this.btnSave_Click);
			this.btnDelete.BackColor = Color.FromArgb(255, 209, 150);
			this.btnDelete.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 1);
			this.btnDelete.FlatStyle = FlatStyle.Flat;
			this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.btnDelete.Location = new Point(405, 370);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(75, 23);
			this.btnDelete.TabIndex = 3;
			this.btnDelete.Text = "&Delete";
			this.btnDelete.UseVisualStyleBackColor = false;
			this.btnDelete.Click += new EventHandler(this.btnDelete_Click);
			this.btnClear.BackColor = Color.FromArgb(255, 209, 150);
			this.btnClear.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 1);
			this.btnClear.FlatStyle = FlatStyle.Flat;
			this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.btnClear.Location = new Point(486, 370);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(75, 23);
			this.btnClear.TabIndex = 4;
			this.btnClear.Text = "C&lear";
			this.btnClear.UseVisualStyleBackColor = false;
			this.btnClear.Click += new EventHandler(this.btnClear_Click);
			this.btnClose.BackColor = Color.FromArgb(255, 209, 150);
			this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnClose.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 1);
			this.btnClose.FlatStyle = FlatStyle.Flat;
			this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.btnClose.Location = new Point(567, 370);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(75, 23);
			this.btnClose.TabIndex = 5;
			this.btnClose.Text = "&Close";
			this.btnClose.UseVisualStyleBackColor = false;
			this.btnClose.Click += new EventHandler(this.btnClose_Click);
			this.panel8.BackgroundImage = (Image)componentResourceManager.GetObject("panel8.BackgroundImage");
			this.panel8.BackgroundImageLayout = ImageLayout.Stretch;
			this.panel8.Controls.Add(this.label7);
			this.panel8.Controls.Add(this.dtpToDate);
			this.panel8.Controls.Add(this.dtpFromDate);
			this.panel8.Controls.Add(this.txtMessage);
			this.panel8.Controls.Add(this.groupBox1);
			this.panel8.Controls.Add(this.label4);
			this.panel8.Controls.Add(this.label3);
			this.panel8.Controls.Add(this.label2);
			this.panel8.Dock = DockStyle.Top;
			this.panel8.Location = new Point(1, 34);
			this.panel8.Name = "panel8";
			this.panel8.Padding = new System.Windows.Forms.Padding(5);
			this.panel8.Size = new System.Drawing.Size(648, 330);
			this.panel8.TabIndex = 1;
			this.label7.AutoSize = true;
			this.label7.Location = new Point(11, 78);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(53, 13);
			this.label7.TabIndex = 17;
			this.label7.Text = "Message:";
			this.dtpToDate.CustomFormat = "dd-MMM-yyyy";
			this.dtpToDate.Format = DateTimePickerFormat.Custom;
			this.dtpToDate.Location = new Point(134, 36);
			this.dtpToDate.Name = "dtpToDate";
			this.dtpToDate.Size = new System.Drawing.Size(132, 20);
			this.dtpToDate.TabIndex = 1;
			this.dtpToDate.KeyPress += new KeyPressEventHandler(this.dtpFromDate_KeyPress);
			this.dtpToDate.KeyDown += new KeyEventHandler(this.dtpFromDate_KeyDown);
			this.dtpFromDate.CustomFormat = "dd-MMM-yyyy";
			this.dtpFromDate.Format = DateTimePickerFormat.Custom;
			this.dtpFromDate.Location = new Point(134, 10);
			this.dtpFromDate.Name = "dtpFromDate";
			this.dtpFromDate.Size = new System.Drawing.Size(132, 20);
			this.dtpFromDate.TabIndex = 0;
			this.dtpFromDate.KeyPress += new KeyPressEventHandler(this.dtpFromDate_KeyPress);
			this.dtpFromDate.KeyDown += new KeyEventHandler(this.dtpFromDate_KeyDown);
			this.txtMessage.Location = new Point(134, 62);
			this.txtMessage.Multiline = true;
			this.txtMessage.Name = "txtMessage";
			this.txtMessage.Size = new System.Drawing.Size(232, 85);
			this.txtMessage.TabIndex = 2;
			this.txtMessage.Enter += new EventHandler(this.txtMessage_Enter);
			this.txtMessage.Leave += new EventHandler(this.txtMessage_Leave);
			this.txtMessage.KeyPress += new KeyPressEventHandler(this.dtpFromDate_KeyPress);
			this.groupBox1.BackColor = Color.White;
			this.groupBox1.Controls.Add(this.panel9);
			this.groupBox1.Location = new Point(390, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(5);
			this.groupBox1.Size = new System.Drawing.Size(251, 309);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Search";
			this.panel9.Controls.Add(this.cbxAll);
			this.panel9.Controls.Add(this.dtpSearchDate);
			this.panel9.Controls.Add(this.label5);
			this.panel9.Controls.Add(this.txtSearch);
			this.panel9.Controls.Add(this.label6);
			this.panel9.Controls.Add(this.dgvSearch);
			this.panel9.Dock = DockStyle.Fill;
			this.panel9.Location = new Point(5, 18);
			this.panel9.Name = "panel9";
			this.panel9.Size = new System.Drawing.Size(241, 286);
			this.panel9.TabIndex = 0;
			this.cbxAll.AutoSize = true;
			this.cbxAll.Location = new Point(200, 13);
			this.cbxAll.Name = "cbxAll";
			this.cbxAll.Size = new System.Drawing.Size(37, 17);
			this.cbxAll.TabIndex = 7;
			this.cbxAll.Text = "All";
			this.cbxAll.UseVisualStyleBackColor = true;
			this.cbxAll.Click += new EventHandler(this.cbxAll_Click);
			this.cbxAll.CheckedChanged += new EventHandler(this.cbxAll_CheckedChanged);
			this.dtpSearchDate.CustomFormat = "dd-MMM-yyyy";
			this.dtpSearchDate.Format = DateTimePickerFormat.Custom;
			this.dtpSearchDate.Location = new Point(64, 10);
			this.dtpSearchDate.Name = "dtpSearchDate";
			this.dtpSearchDate.Size = new System.Drawing.Size(132, 20);
			this.dtpSearchDate.TabIndex = 0;
			this.dtpSearchDate.TabStop = false;
			this.dtpSearchDate.ValueChanged += new EventHandler(this.dtpSearchDate_ValueChanged);
			this.dtpSearchDate.KeyPress += new KeyPressEventHandler(this.dtpSearchDate_KeyPress);
			this.dtpSearchDate.KeyDown += new KeyEventHandler(this.dtpFromDate_KeyDown);
			this.label5.AutoSize = true;
			this.label5.Location = new Point(1, 43);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(62, 13);
			this.label5.TabIndex = 19;
			this.label5.Text = "Search For:";
			this.txtSearch.Location = new Point(63, 36);
			this.txtSearch.MaxLength = 50;
			this.txtSearch.Name = "txtSearch";
			this.txtSearch.Size = new System.Drawing.Size(149, 20);
			this.txtSearch.TabIndex = 1;
			this.txtSearch.TabStop = false;
			this.txtSearch.TextChanged += new EventHandler(this.txtSearch_TextChanged);
			this.label6.AutoSize = true;
			this.label6.Location = new Point(6, 15);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(33, 13);
			this.label6.TabIndex = 16;
			this.label6.Text = "Date:";
			this.dgvSearch.AllowUserToAddRows = false;
			this.dgvSearch.AllowUserToDeleteRows = false;
			this.dgvSearch.AllowUserToResizeColumns = false;
			this.dgvSearch.AllowUserToResizeRows = false;
			this.dgvSearch.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvSearch.BackgroundColor = Color.White;
			this.dgvSearch.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			DataGridViewColumnCollection columns = this.dgvSearch.Columns;
			DataGridViewColumn[] column1 = new DataGridViewColumn[] { this.Column1, this.Column2, this.Column3, this.Column4, this.Column5 };
			columns.AddRange(column1);
			this.dgvSearch.GridColor = Color.WhiteSmoke;
			this.dgvSearch.Location = new Point(9, 62);
			this.dgvSearch.MultiSelect = false;
			this.dgvSearch.Name = "dgvSearch";
			this.dgvSearch.ReadOnly = true;
			this.dgvSearch.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
			this.dgvSearch.RowHeadersVisible = false;
			this.dgvSearch.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			this.dgvSearch.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			this.dgvSearch.Size = new System.Drawing.Size(225, 216);
			this.dgvSearch.TabIndex = 2;
			this.dgvSearch.TabStop = false;
			this.dgvSearch.CellClick += new DataGridViewCellEventHandler(this.dgdSearch_CellClick);
			this.dgvSearch.KeyUp += new KeyEventHandler(this.dgdSearch_KeyUp);
			this.Column1.HeaderText = "Si";
			this.Column1.Name = "Column1";
			this.Column1.ReadOnly = true;
			this.Column1.Resizable = DataGridViewTriState.False;
			this.Column1.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.Column1.Visible = false;
			this.Column2.HeaderText = "Message";
			this.Column2.Name = "Column2";
			this.Column2.ReadOnly = true;
			this.Column2.Resizable = DataGridViewTriState.False;
			this.Column2.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.Column3.HeaderText = "Id";
			this.Column3.Name = "Column3";
			this.Column3.ReadOnly = true;
			this.Column3.Resizable = DataGridViewTriState.False;
			this.Column3.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.Column3.Visible = false;
			this.Column4.HeaderText = "From Date";
			this.Column4.Name = "Column4";
			this.Column4.ReadOnly = true;
			this.Column4.Resizable = DataGridViewTriState.False;
			this.Column4.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.Column4.Visible = false;
			this.Column5.HeaderText = "To Date";
			this.Column5.Name = "Column5";
			this.Column5.ReadOnly = true;
			this.Column5.Resizable = DataGridViewTriState.False;
			this.Column5.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.Column5.Visible = false;
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label4.ForeColor = Color.Red;
			this.label4.Location = new Point(372, 65);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(12, 13);
			this.label4.TabIndex = 5;
			this.label4.Text = "*";
			this.label3.AutoSize = true;
			this.label3.Location = new Point(8, 44);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(49, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "To Date:";
			this.label2.AutoSize = true;
			this.label2.Location = new Point(8, 17);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(59, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "From Date:";
			this.panel6.BackgroundImage = (Image)componentResourceManager.GetObject("panel6.BackgroundImage");
			this.panel6.Controls.Add(this.label1);
			this.panel6.Controls.Add(this.panel7);
			this.panel6.Dock = DockStyle.Top;
			this.panel6.Location = new Point(1, 1);
			this.panel6.Name = "panel6";
			this.panel6.Size = new System.Drawing.Size(648, 33);
			this.panel6.TabIndex = 0;
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label1.Location = new Point(11, 7);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(93, 15);
			this.label1.TabIndex = 0;
			this.label1.Text = "Greeting Text";
			this.panel7.BackColor = Color.FromArgb(136, 136, 136);
			this.panel7.Dock = DockStyle.Bottom;
			this.panel7.Location = new Point(0, 32);
			this.panel7.Name = "panel7";
			this.panel7.Size = new System.Drawing.Size(648, 1);
			this.panel7.TabIndex = 3;
			this.panel5.BackColor = Color.FromArgb(136, 136, 136);
			this.panel5.Dock = DockStyle.Bottom;
			this.panel5.Location = new Point(1, 423);
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
			this.panel3.Size = new System.Drawing.Size(1, 424);
			this.panel3.TabIndex = 1;
			this.panel2.BackColor = Color.FromArgb(136, 136, 136);
			this.panel2.Dock = DockStyle.Left;
			this.panel2.Location = new Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(1, 424);
			this.panel2.TabIndex = 0;
			this.dataGridViewTextBoxColumn1.HeaderText = "Si";
			this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn1.Width = 111;
			this.dataGridViewTextBoxColumn2.HeaderText = "Message";
			this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
			this.dataGridViewTextBoxColumn2.Width = 111;
			this.dataGridViewTextBoxColumn3.HeaderText = "Id";
			this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
			this.dataGridViewTextBoxColumn3.Visible = false;
			this.dataGridViewTextBoxColumn4.HeaderText = "From Date";
			this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
			this.dataGridViewTextBoxColumn4.Visible = false;
			this.dataGridViewTextBoxColumn5.HeaderText = "To Date";
			this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
			this.dataGridViewTextBoxColumn5.Visible = false;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.BackColor = Color.White;
			base.CancelButton = this.btnClose;
			base.ClientSize = new System.Drawing.Size(664, 438);
			base.Controls.Add(this.panel1);
			base.Icon = (System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.Name = "frmGreetingText";
			base.Padding = new System.Windows.Forms.Padding(7);
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "Greeting Text";
			base.FormClosing += new FormClosingEventHandler(this.frmGreetingText_FormClosing);
			base.Load += new EventHandler(this.frmGreetingText_Load);
			this.panel1.ResumeLayout(false);
			this.panel8.ResumeLayout(false);
			this.panel8.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.panel9.ResumeLayout(false);
			this.panel9.PerformLayout();
			((ISupportInitialize)this.dgvSearch).EndInit();
			this.panel6.ResumeLayout(false);
			this.panel6.PerformLayout();
			base.ResumeLayout(false);
		}

		private void panel1_Paint(object sender, PaintEventArgs e)
		{
		}

		protected override bool ProcessDialogKey(Keys keyData)
		{
			bool flag;
			if (keyData != Keys.Tab)
			{
				base.ProcessDialogKey(keyData);
				flag = false;
			}
			else if (!this.txtMessage.Focused)
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

		private void saveOrEditDetails()
		{
			try
			{
                 if (!FinacialYearInfo._activeOrNot)
				{
					MessageBox.Show("Selected finacial year has been closed", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
				else
				{
					this.txtMessage.Text = this.txtMessage.Text.Trim();
					if (DateTime.Parse(this.dtpFromDate.Text) > DateTime.Parse(this.dtpToDate.Text))
					{
						MessageBox.Show("From date cannot be greater than to date", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						this.dtpToDate.Focus();
					}
					else if (!(this.txtMessage.Text == ""))
					{
						this.GreetingTextInfo.FromDate = DateTime.Parse(this.dtpFromDate.Text.ToString());
						this.GreetingTextInfo.ToDate = DateTime.Parse(this.dtpToDate.Text.ToString());
						this.GreetingTextInfo.GreetingMessage = this.txtMessage.Text.Trim();
						this.GreetingTextInfo.Description = "";
						if (this.btnSave.Text == "&Save")
						{
							this.GreetingTextSP.GreetingTextAdd(this.GreetingTextInfo);
							MessageBox.Show("Saved successfully", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
							this.clear();
						}
						else if (this.btnSave.Text == "&Update")
						{
							this.GreetingTextInfo.GreetingTextId = this._ID;
							this.GreetingTextSP.GreetingTextEdit(this.GreetingTextInfo);
							MessageBox.Show("Updated successfully", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
							this.clear();
						}
					}
					else
					{
						MessageBox.Show("Enter message", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						this.txtMessage.Focus();
					}
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void txtMessage_Enter(object sender, EventArgs e)
		{
			try
			{
				this.txtMessage.Text = this.txtMessage.Text.Trim();
				if (!(this.txtMessage.Text == ""))
				{
					this.txtMessage.SelectionStart = this.txtMessage.Text.Length;
					this.txtMessage.Focus();
				}
				else
				{
					this.txtMessage.SelectionStart = 0;
					this.txtMessage.Focus();
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void txtMessage_Leave(object sender, EventArgs e)
		{
			try
			{
				if (MDIMedicalShop.MDIObj.ActiveMdiChild == this)
				{
					if ((this.txtSearch.Focused || this.dgvSearch.Focused || this.dtpSearchDate.Focused || this.dtpFromDate.Focused || this.dtpToDate.Focused ? false : !this.isFormClose))
					{
						if (this.txtMessage.Text.Trim() == "")
						{
							this.txtMessage.Focus();
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
				for (int i = 0; i < this.dgvSearch.Rows.Count; i++)
				{
					if (!this.dgvSearch[1, i].Value.ToString().ToLower().StartsWith(this.txtSearch.Text.ToLower()))
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
	}
}