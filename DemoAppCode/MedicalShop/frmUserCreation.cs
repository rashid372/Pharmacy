using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;

namespace MedicalShop
{
	public class frmUserCreation : Form
	{
        private MedicalShop.UserSP UserSP = new MedicalShop.UserSP();

        private MedicalShop.UserInfo UserInfo = new MedicalShop.UserInfo();


        private DataTable dtSearch = new DataTable();
        private Boolean isAutoGenerate = true;
        private string strIdForUserEdit = "";

        private string _exist = "";

		private string _ID = "";

		private string _userName = "";

		private bool isFormClose = false;

		private int inDescriptionCount = 0;

		private bool isFromSettings = false;

		private IContainer components = null;

		private Panel panel1;

		private Button btnSave;

		private Button btnDelete;

		private Button btnClear;

		private Button btnClose;

		private Panel panel8;

		private Label label7;

		private TextBox txtDescription;

		private GroupBox groupBox1;

		private Panel panel9;

		private Label label5;

		private TextBox txtSearch;

		private Label label6;

		private DataGridView dgdSearch;

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

		private TextBox txtConfirmPassword;

		private TextBox txtPassword;

		private TextBox txtUserName;

		private Label label10;

		private Label label9;

		private Label label8;

		private CheckBox cbxStatus;

		private ComboBox cmbSearch;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;

		private DataGridViewTextBoxColumn Column1;

		private DataGridViewTextBoxColumn Column2;

		public frmUserCreation()
		{
			this.InitializeComponent();
		}

		private void btnclear_Click(object sender, EventArgs e)
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
      
                UserSP.UserDelete(this._ID);
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

                saveOrEditDetails();
            }
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		public void clear()
		{
			try
			{
				this.txtUserName.Text = this.txtUserName.Text.Trim();
				this.dgdSearchFill();
				this.txtUserName.Text = "";
				this.txtPassword.Text = "";
				this.txtConfirmPassword.Text = "";
				this.txtDescription.Text = "";
				this.txtSearch.Clear();
				this._exist = "";
				this._ID = "";
				this.cmbSearch.SelectedIndex = 0;
				this.btnSave.Text = "&Save";
				this.btnClear.Text = "C&lear";
				this.btnDelete.Enabled = false;
				this.cbxStatus.Checked = false;
				this.txtUserName.Select();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void cmbSearch_KeyDown(object sender, KeyEventArgs e)
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

		private void cmbSearch_KeyPress(object sender, KeyPressEventArgs e)
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

		private void cmbSearch_Leave(object sender, EventArgs e)
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

		private void cmbSearch_SelectedIndexChanged(object sender, EventArgs e)
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

		private void dgdSearch_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				if (this.dgdSearch.CurrentRow != null)
				{
					if (this.dgdSearch.Rows.Count > 0)
					{
						this._ID = this.dgdSearch.CurrentRow.Cells[0].Value.ToString();
						this._userName = this.dgdSearch.CurrentRow.Cells[1].Value.ToString();
						foreach (DataRow row in this.dtSearch.Rows)
						{
							if (this._ID == row.ItemArray[0].ToString())
							{
								this.txtUserName.Text = row.ItemArray[1].ToString();
								this.txtPassword.Text = row.ItemArray[2].ToString();
								this.txtConfirmPassword.Text = row.ItemArray[2].ToString();
								if (!(row.ItemArray[3].ToString() == "True"))
								{
									this.cbxStatus.Checked = true;
								}
								else
								{
									this.cbxStatus.Checked = false;
								}
								this.txtDescription.Text = row.ItemArray[4].ToString();
							}
						}
						this.dgdSearch.CurrentRow.Selected = true;
						this.btnDelete.Enabled = true;
						this.btnSave.Text = "&Update";
						this.btnClear.Text = "&New";
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
					if (this.dgdSearch.CurrentRow != null)
					{
						DataGridViewCellEventArgs dataGridViewCellEventArg = new DataGridViewCellEventArgs(0, this.dgdSearch.CurrentRow.Index);
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
				int str = 0;
				if (this.dtSearch.Rows.Count > 0)
				{
					this.dtSearch.Rows.Clear();
				}
				this.dtSearch = this.UserSP.UserViewAll();
				if (this.dgdSearch.RowCount > 0)
				{
					this.dgdSearch.Rows.Clear();
				}
				foreach (DataRow row in this.dtSearch.Rows)
				{
					if (row.ItemArray[0].ToString() != "1")
					{
						if (this.cmbSearch.Text == "All")
						{
							this.dgdSearch.Rows.Add();
							this.dgdSearch.Rows[str].Cells[0].Value = row.ItemArray[0].ToString();
							this.dgdSearch.Rows[str].Cells[1].Value = row.ItemArray[1].ToString();
							str++;
						}
						else if (this.cmbSearch.Text == "Active")
						{
							if (row.ItemArray[3].ToString() == "True")
							{
								this.dgdSearch.Rows.Add();
								this.dgdSearch.Rows[str].Cells[0].Value = row.ItemArray[0].ToString();
								this.dgdSearch.Rows[str].Cells[1].Value = row.ItemArray[1].ToString();
								str++;
							}
						}
						else if (this.cmbSearch.Text == "Blocked")
						{
							if (row.ItemArray[3].ToString() == "False")
							{
								this.dgdSearch.Rows.Add();
								this.dgdSearch.Rows[str].Cells[0].Value = row.ItemArray[0].ToString();
								this.dgdSearch.Rows[str].Cells[1].Value = row.ItemArray[1].ToString();
								str++;
							}
						}
					}
				}
				DataGridViewCell currentCell = this.dgdSearch.CurrentCell;
				this.dgdSearch.CurrentCell = null;
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

		private void frmUserCreation_FormClosing(object sender, FormClosingEventArgs e)
		{
			this.isFormClose = true;
		}

		private void frmUserCreation_Load(object sender, EventArgs e)
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
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmUserCreation));
			this.panel1 = new Panel();
			this.btnSave = new Button();
			this.btnDelete = new Button();
			this.btnClear = new Button();
			this.btnClose = new Button();
			this.panel8 = new Panel();
			this.cbxStatus = new CheckBox();
			this.label10 = new Label();
			this.label9 = new Label();
			this.label8 = new Label();
			this.txtConfirmPassword = new TextBox();
			this.txtPassword = new TextBox();
			this.txtUserName = new TextBox();
			this.label7 = new Label();
			this.txtDescription = new TextBox();
			this.groupBox1 = new GroupBox();
			this.panel9 = new Panel();
			this.cmbSearch = new ComboBox();
			this.label5 = new Label();
			this.txtSearch = new TextBox();
			this.label6 = new Label();
			this.dgdSearch = new DataGridView();
			this.Column1 = new DataGridViewTextBoxColumn();
			this.Column2 = new DataGridViewTextBoxColumn();
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
			((ISupportInitialize)this.dgdSearch).BeginInit();
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
			this.panel1.Size = new System.Drawing.Size(651, 422);
			this.panel1.TabIndex = 0;
			this.btnSave.BackColor = Color.FromArgb(255, 209, 150);
			this.btnSave.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 1);
			this.btnSave.FlatStyle = FlatStyle.Flat;
			this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.btnSave.Location = new Point(324, 370);
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
			this.btnDelete.Location = new Point(405, 370);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(75, 23);
			this.btnDelete.TabIndex = 1;
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
			this.btnClear.TabIndex = 2;
			this.btnClear.Text = "C&lear";
			this.btnClear.UseVisualStyleBackColor = false;
			this.btnClear.Click += new EventHandler(this.btnclear_Click);
			this.btnClose.BackColor = Color.FromArgb(255, 209, 150);
			this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnClose.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 1);
			this.btnClose.FlatStyle = FlatStyle.Flat;
			this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.btnClose.Location = new Point(567, 370);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(75, 23);
			this.btnClose.TabIndex = 3;
			this.btnClose.Text = "&Close";
			this.btnClose.UseVisualStyleBackColor = false;
			this.btnClose.Click += new EventHandler(this.btnClose_Click);
			this.panel8.BackgroundImage = (Image)componentResourceManager.GetObject("panel8.BackgroundImage");
			this.panel8.BackgroundImageLayout = ImageLayout.Stretch;
			this.panel8.Controls.Add(this.cbxStatus);
			this.panel8.Controls.Add(this.label10);
			this.panel8.Controls.Add(this.label9);
			this.panel8.Controls.Add(this.label8);
			this.panel8.Controls.Add(this.txtConfirmPassword);
			this.panel8.Controls.Add(this.txtPassword);
			this.panel8.Controls.Add(this.txtUserName);
			this.panel8.Controls.Add(this.label7);
			this.panel8.Controls.Add(this.txtDescription);
			this.panel8.Controls.Add(this.groupBox1);
			this.panel8.Controls.Add(this.label4);
			this.panel8.Controls.Add(this.label3);
			this.panel8.Controls.Add(this.label2);
			this.panel8.Dock = DockStyle.Top;
			this.panel8.Location = new Point(1, 34);
			this.panel8.Name = "panel8";
			this.panel8.Padding = new System.Windows.Forms.Padding(5);
			this.panel8.Size = new System.Drawing.Size(649, 330);
			this.panel8.TabIndex = 4;
			this.cbxStatus.AutoSize = true;
			this.cbxStatus.Location = new Point(113, 300);
			this.cbxStatus.Name = "cbxStatus";
			this.cbxStatus.Size = new System.Drawing.Size(53, 17);
			this.cbxStatus.TabIndex = 4;
			this.cbxStatus.Text = "Block";
			this.cbxStatus.UseVisualStyleBackColor = true;
			this.cbxStatus.KeyPress += new KeyPressEventHandler(this.txtUserName_KeyPress);
			this.label10.AutoSize = true;
			this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label10.ForeColor = Color.Red;
			this.label10.Location = new Point(289, 69);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(12, 13);
			this.label10.TabIndex = 23;
			this.label10.Text = "*";
			this.label9.AutoSize = true;
			this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label9.ForeColor = Color.Red;
			this.label9.Location = new Point(289, 43);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(12, 13);
			this.label9.TabIndex = 22;
			this.label9.Text = "*";
			this.label8.AutoSize = true;
			this.label8.Location = new Point(8, 91);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(63, 13);
			this.label8.TabIndex = 21;
			this.label8.Text = "Description:";
			this.txtConfirmPassword.Location = new Point(113, 62);
			this.txtConfirmPassword.MaxLength = 15;
			this.txtConfirmPassword.Name = "txtConfirmPassword";
			this.txtConfirmPassword.Size = new System.Drawing.Size(174, 20);
			this.txtConfirmPassword.TabIndex = 2;
			this.txtConfirmPassword.UseSystemPasswordChar = true;
			this.txtConfirmPassword.Leave += new EventHandler(this.txtConfirmPassword_Leave);
			this.txtConfirmPassword.KeyPress += new KeyPressEventHandler(this.txtUserName_KeyPress);
			this.txtPassword.Location = new Point(113, 36);
			this.txtPassword.MaxLength = 15;
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.Size = new System.Drawing.Size(174, 20);
			this.txtPassword.TabIndex = 1;
			this.txtPassword.UseSystemPasswordChar = true;
			this.txtPassword.Leave += new EventHandler(this.txtPassword_Leave);
			this.txtPassword.KeyPress += new KeyPressEventHandler(this.txtUserName_KeyPress);
			this.txtUserName.Location = new Point(113, 10);
			this.txtUserName.MaxLength = 50;
			this.txtUserName.Name = "txtUserName";
			this.txtUserName.Size = new System.Drawing.Size(174, 20);
			this.txtUserName.TabIndex = 0;
			this.txtUserName.Leave += new EventHandler(this.txtUserName_Leave);
			this.txtUserName.KeyPress += new KeyPressEventHandler(this.txtUserName_KeyPress);
			this.label7.AutoSize = true;
			this.label7.Location = new Point(8, 69);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(94, 13);
			this.label7.TabIndex = 17;
			this.label7.Text = "Confirm Password:";
			this.txtDescription.Location = new Point(113, 88);
			this.txtDescription.Multiline = true;
			this.txtDescription.Name = "txtDescription";
			this.txtDescription.Size = new System.Drawing.Size(174, 88);
			this.txtDescription.TabIndex = 3;
			this.txtDescription.Enter += new EventHandler(this.txtDescription_Enter);
			this.txtDescription.KeyPress += new KeyPressEventHandler(this.txtUserName_KeyPress);
			this.groupBox1.BackColor = Color.White;
			this.groupBox1.Controls.Add(this.panel9);
			this.groupBox1.Location = new Point(323, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(5);
			this.groupBox1.Size = new System.Drawing.Size(318, 309);
			this.groupBox1.TabIndex = 7;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Search";
			this.panel9.Controls.Add(this.cmbSearch);
			this.panel9.Controls.Add(this.label5);
			this.panel9.Controls.Add(this.txtSearch);
			this.panel9.Controls.Add(this.label6);
			this.panel9.Controls.Add(this.dgdSearch);
			this.panel9.Dock = DockStyle.Fill;
			this.panel9.Location = new Point(5, 18);
			this.panel9.Name = "panel9";
			this.panel9.Size = new System.Drawing.Size(308, 286);
			this.panel9.TabIndex = 0;
			this.cmbSearch.DropDownStyle = ComboBoxStyle.DropDownList;
			this.cmbSearch.FormattingEnabled = true;
			this.cmbSearch.Items.AddRange(new object[] { "All", "Active", "Blocked" });
			this.cmbSearch.Location = new Point(76, 9);
			this.cmbSearch.Name = "cmbSearch";
			this.cmbSearch.Size = new System.Drawing.Size(219, 21);
			this.cmbSearch.TabIndex = 0;
			this.cmbSearch.TabStop = false;
			this.cmbSearch.Leave += new EventHandler(this.cmbSearch_Leave);
			this.cmbSearch.SelectedIndexChanged += new EventHandler(this.cmbSearch_SelectedIndexChanged);
			this.cmbSearch.KeyPress += new KeyPressEventHandler(this.cmbSearch_KeyPress);
			this.cmbSearch.KeyDown += new KeyEventHandler(this.cmbSearch_KeyDown);
			this.label5.AutoSize = true;
			this.label5.Location = new Point(6, 43);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(44, 13);
			this.label5.TabIndex = 19;
			this.label5.Text = "Search:";
			this.txtSearch.Location = new Point(76, 36);
			this.txtSearch.MaxLength = 50;
			this.txtSearch.Name = "txtSearch";
			this.txtSearch.Size = new System.Drawing.Size(219, 20);
			this.txtSearch.TabIndex = 1;
			this.txtSearch.TabStop = false;
			this.txtSearch.Leave += new EventHandler(this.cmbSearch_Leave);
			this.txtSearch.KeyPress += new KeyPressEventHandler(this.txtUserName_KeyPress);
			this.txtSearch.TextChanged += new EventHandler(this.txtSearch_TextChanged);
			this.label6.AutoSize = true;
			this.label6.Location = new Point(6, 15);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(59, 13);
			this.label6.TabIndex = 16;
			this.label6.Text = "Search By:";
			this.dgdSearch.AllowUserToAddRows = false;
			this.dgdSearch.AllowUserToDeleteRows = false;
			this.dgdSearch.AllowUserToResizeColumns = false;
			this.dgdSearch.AllowUserToResizeRows = false;
			this.dgdSearch.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			this.dgdSearch.BackgroundColor = Color.White;
			this.dgdSearch.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			DataGridViewColumnCollection columns = this.dgdSearch.Columns;
			DataGridViewColumn[] column1 = new DataGridViewColumn[] { this.Column1, this.Column2 };
			columns.AddRange(column1);
			this.dgdSearch.GridColor = Color.WhiteSmoke;
			this.dgdSearch.Location = new Point(9, 62);
			this.dgdSearch.MultiSelect = false;
			this.dgdSearch.Name = "dgdSearch";
			this.dgdSearch.ReadOnly = true;
			this.dgdSearch.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
			this.dgdSearch.RowHeadersVisible = false;
			this.dgdSearch.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			this.dgdSearch.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			this.dgdSearch.Size = new System.Drawing.Size(286, 216);
			this.dgdSearch.TabIndex = 2;
			this.dgdSearch.TabStop = false;
			this.dgdSearch.CellClick += new DataGridViewCellEventHandler(this.dgdSearch_CellClick);
			this.dgdSearch.Leave += new EventHandler(this.cmbSearch_Leave);
			this.dgdSearch.KeyUp += new KeyEventHandler(this.dgdSearch_KeyUp);
			this.Column1.HeaderText = "User id";
			this.Column1.Name = "Column1";
			this.Column1.ReadOnly = true;
			this.Column1.Visible = false;
			this.Column2.HeaderText = "User Name";
			this.Column2.Name = "Column2";
			this.Column2.ReadOnly = true;
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label4.ForeColor = Color.Red;
			this.label4.Location = new Point(289, 13);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(12, 13);
			this.label4.TabIndex = 5;
			this.label4.Text = "*";
			this.label3.AutoSize = true;
			this.label3.Location = new Point(8, 43);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(56, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "Password:";
			this.label2.AutoSize = true;
			this.label2.Location = new Point(8, 17);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(63, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "User Name:";
			this.panel6.BackgroundImage = (Image)componentResourceManager.GetObject("panel6.BackgroundImage");
			this.panel6.Controls.Add(this.label1);
			this.panel6.Controls.Add(this.panel7);
			this.panel6.Dock = DockStyle.Top;
			this.panel6.Location = new Point(1, 1);
			this.panel6.Name = "panel6";
			this.panel6.Size = new System.Drawing.Size(649, 33);
			this.panel6.TabIndex = 0;
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label1.Location = new Point(11, 7);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(95, 15);
			this.label1.TabIndex = 4;
			this.label1.Text = "User Creation";
			this.panel7.BackColor = Color.FromArgb(136, 136, 136);
			this.panel7.Dock = DockStyle.Bottom;
			this.panel7.Location = new Point(0, 32);
			this.panel7.Name = "panel7";
			this.panel7.Size = new System.Drawing.Size(649, 1);
			this.panel7.TabIndex = 3;
			this.panel5.BackColor = Color.FromArgb(136, 136, 136);
			this.panel5.Dock = DockStyle.Bottom;
			this.panel5.Location = new Point(1, 421);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(649, 1);
			this.panel5.TabIndex = 2;
			this.panel4.BackColor = Color.FromArgb(136, 136, 136);
			this.panel4.Dock = DockStyle.Top;
			this.panel4.Location = new Point(1, 0);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(649, 1);
			this.panel4.TabIndex = 1;
			this.panel3.BackColor = Color.FromArgb(136, 136, 136);
			this.panel3.Dock = DockStyle.Right;
			this.panel3.Location = new Point(650, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(1, 422);
			this.panel3.TabIndex = 1;
			this.panel2.BackColor = Color.FromArgb(136, 136, 136);
			this.panel2.Dock = DockStyle.Left;
			this.panel2.Location = new Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(1, 422);
			this.panel2.TabIndex = 0;
			this.dataGridViewTextBoxColumn1.HeaderText = "Si";
			this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn1.ReadOnly = true;
			this.dataGridViewTextBoxColumn1.Width = 142;
			this.dataGridViewTextBoxColumn2.HeaderText = "Message";
			this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
			this.dataGridViewTextBoxColumn2.ReadOnly = true;
			this.dataGridViewTextBoxColumn2.Width = 141;
			this.dataGridViewTextBoxColumn3.HeaderText = "Id";
			this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
			this.dataGridViewTextBoxColumn3.ReadOnly = true;
			this.dataGridViewTextBoxColumn3.Visible = false;
			this.dataGridViewTextBoxColumn4.HeaderText = "From Date";
			this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
			this.dataGridViewTextBoxColumn4.ReadOnly = true;
			this.dataGridViewTextBoxColumn4.Visible = false;
			this.dataGridViewTextBoxColumn5.HeaderText = "To Date";
			this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
			this.dataGridViewTextBoxColumn5.ReadOnly = true;
			this.dataGridViewTextBoxColumn5.Visible = false;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.BackColor = Color.White;
			base.CancelButton = this.btnClose;
			base.ClientSize = new System.Drawing.Size(665, 436);
			base.Controls.Add(this.panel1);
			base.Icon = (System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.Name = "frmUserCreation";
			base.Padding = new System.Windows.Forms.Padding(7);
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "User Creation";
			base.FormClosing += new FormClosingEventHandler(this.frmUserCreation_FormClosing);
			base.Load += new EventHandler(this.frmUserCreation_Load);
			this.panel1.ResumeLayout(false);
			this.panel8.ResumeLayout(false);
			this.panel8.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.panel9.ResumeLayout(false);
			this.panel9.PerformLayout();
			((ISupportInitialize)this.dgdSearch).EndInit();
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

		public void ReturnFromPrivilege()
		{
			base.Enabled = true;
			base.WindowState = FormWindowState.Normal;
			base.Activate();
			this.txtUserName.Focus();
		}

		public void ShowFromSettings()
		{
			this.isFromSettings = true;
			base.Show();
		}

		private void txtConfirmPassword_Leave(object sender, EventArgs e)
		{
			try
			{
				if (MDIMedicalShop.MDIObj.ActiveMdiChild == this)
				{
					if ((this.txtSearch.Focused || this.dgdSearch.Focused || this.cmbSearch.Focused || this.txtUserName.Focused || this.txtPassword.Focused ? false : !this.isFormClose))
					{
						if (this.txtConfirmPassword.Text.Trim() == "")
						{
							this.txtConfirmPassword.Focus();
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

		private void txtPassword_Leave(object sender, EventArgs e)
		{
			try
			{
				if (MDIMedicalShop.MDIObj.ActiveMdiChild == this)
				{
					if ((this.txtSearch.Focused || this.dgdSearch.Focused || this.cmbSearch.Focused || this.txtUserName.Focused ? false : !this.isFormClose))
					{
						if (this.txtPassword.Text.Trim() == "")
						{
							this.txtPassword.Focus();
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
				for (int i = 0; i < this.dgdSearch.Rows.Count; i++)
				{
					if (!this.dgdSearch[1, i].Value.ToString().ToLower().StartsWith(this.txtSearch.Text.ToLower()))
					{
						this.dgdSearch.Rows[i].Visible = false;
					}
					else
					{
						this.dgdSearch.Rows[i].Visible = true;
					}
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void txtUserName_KeyPress(object sender, KeyPressEventArgs e)
		{
			try
			{
				if (e.KeyChar == '\r')
				{
					if (!this.txtDescription.Focused)
					{
						this.inDescriptionCount = 0;
						e.Handled = true;
						SendKeys.Send("{TAB}");
					}
					else
					{
						frmUserCreation _frmUserCreation = this;
						_frmUserCreation.inDescriptionCount = _frmUserCreation.inDescriptionCount + 1;
						if (this.inDescriptionCount == 2)
						{
							this.inDescriptionCount = 0;
							this.btnSave.Focus();
						}
					}
				}
				else if ((e.KeyChar != ' ' || this.txtUserName.Focused ? false : !this.txtDescription.Focused))
				{
					e.Handled = true;
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void txtUserName_Leave(object sender, EventArgs e)
		{
			try
			{
				if (MDIMedicalShop.MDIObj.ActiveMdiChild == this)
				{
					if ((this.txtSearch.Focused || this.dgdSearch.Focused || this.cmbSearch.Focused ? false : !this.isFormClose))
					{
						if (this.txtUserName.Text.Trim() == "")
						{
							this.txtUserName.Focus();
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

                    this.txtUserName.Text = this.txtUserName.Text.Trim();
                    if (!(this.txtUserName.Text != ""))
                    {
                        MessageBox.Show("Enter User Name", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        this.txtUserName.Select();
                        this.txtUserName.Focus();
                    }

                    else
                    {
                        this.UserInfo.Username = this.txtUserName.Text;




                        if (!(this.txtPassword.Text != ""))
                        {
                            MessageBox.Show("Enter password ", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            this.txtPassword.Select();
                            this.txtPassword.Focus();
                        }

                        else
                        {
                            this.UserInfo.Password = this.txtPassword.Text;

                            if (!(this.txtConfirmPassword.Text != ""))
                            {
                                MessageBox.Show("Confirm password ", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                this.txtConfirmPassword.Select();
                                this.txtConfirmPassword.Focus();
                            }

                            else
                            {
                                this.UserInfo.Password = this.txtConfirmPassword.Text;


                                if (this.txtDescription == null)
                                {
                                    this.UserInfo.Description = "";
                                }
                                else
                                {
                                    this.UserInfo.Description = this.txtDescription.Text.ToString();
                                }

                                if (this.isAutoGenerate)
                                {
                                    if (this.CheckExistanceOfUserName())
                                    {
                                        MessageBox.Show("User name already exist", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                        this.txtUserName.Focus();
                                        this.txtUserName.SelectAll();
                                    }
                                    else if (!(this.btnSave.Text == "&Save"))
                                    {
                                        this.UserInfo.UserId = _ID;
                                        this.UserSP.UserEdit(this.UserInfo);
                                        MessageBox.Show("Updated successfully", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                        this.clear();
                                    }
                                    else
                                    {
                                        this.UserInfo.UserId = "0";
                                        this.UserSP.UserAdd(this.UserInfo);

                                        MessageBox.Show("Saved successfully", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                                        this.clear();
                                    }
                                }


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

        public bool CheckExistanceOfUserName()
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