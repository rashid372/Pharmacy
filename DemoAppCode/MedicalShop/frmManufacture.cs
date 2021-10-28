using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;

namespace MedicalShop
{
	public class frmManufacture : Form
	{
		private ManufacturerSP manufacturesp = new ManufacturerSP();
        private ManufacturerInfo manufacturerinfo = new ManufacturerInfo();
        private Boolean  isAutoGenerate = true;

        private bool isFormClose = false;

		private bool isInEditMode = false;

		private string strManufactureIdForEdit = "";

		private string strManufactureForOtherForms = "";

		private string strManufactureName = "";

		private int inDescriptionCount = 0;

		private int inAddressCount = 0;

		private IContainer components = null;

		private Panel panel1;

		private Button btnSave;

		private Button btnDelete;

		private Button btnClear;

		private Button btnClose;

		private Panel panel8;

		private Label label8;

		private Label label7;

		private GroupBox gpbRegister;

		private Label label4;

		private Label label3;

		private TextBox txtManufactureName;

		private Label label2;

		private Panel panel6;

		private Label label1;

		private Panel panel7;

		private Panel panel5;

		private Panel panel4;

		private Panel panel3;

		private Panel panel2;

		private TextBox txtPhone;

		private TextBox txtAddress;

		private TextBox txtEmail;

		private Label label5;

		private TextBox txtDescription;

		private Panel panel9;

		private DataGridView dgvManufacture;

		private DataGridViewTextBoxColumn Column1;

		private DataGridViewTextBoxColumn Column2;

		private TextBox txtSearch;

		private Label label6;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;

		public frmManufacture()
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
				this.txtSearch.Clear();
				this.FillManufactureGrid();
				this.txtDescription.Clear();
				this.txtManufactureName.Clear();
				this.txtPhone.Clear();
				this.txtEmail.Clear();
				this.txtAddress.Clear();
				this.txtSearch.Clear();
				this.btnSave.Text = "&Save";
				this.btnClear.Text = "C&lear";
				this.strManufactureIdForEdit = "";
				this.strManufactureName = "";
				this.isInEditMode = false;
				this.btnDelete.Enabled = false;
				this.txtManufactureName.Focus();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void dgvmanufacture_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				if (this.dgvManufacture.CurrentRow != null)
				{
					if ((this.dgvManufacture.Rows.Count <= 0 ? false : e.ColumnIndex > -1))
					{
						if (this.dgvManufacture.CurrentRow.Cells[0].Value != null)
						{
							if (this.dgvManufacture.CurrentRow.Cells[0].Value.ToString() != "")
							{
								this.strManufactureIdForEdit = this.dgvManufacture.CurrentRow.Cells[0].Value.ToString();
								this.strManufactureName = this.dgvManufacture.CurrentRow.Cells[1].Value.ToString();
								this.FillControlsForEdit();
								this.dgvManufacture.CurrentRow.Selected = true;
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

		private void dgvmanufacture_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
		}

		private void dgvmanufacture_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			try
			{
				DataGridViewCellEventArgs dataGridViewCellEventArg = new DataGridViewCellEventArgs(e.ColumnIndex, e.RowIndex);
				this.dgvmanufacture_CellClick(sender, dataGridViewCellEventArg);
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void dgvmanufacture_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
		{
			((DataGridView)sender).ClearSelection();
		}

		private void dgvmanufacture_KeyUp(object sender, KeyEventArgs e)
		{
			try
			{
				if ((e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Return ? true : e.KeyCode == Keys.Tab))
				{
					if (this.dgvManufacture.CurrentRow != null)
					{
						DataGridViewCellEventArgs dataGridViewCellEventArg = new DataGridViewCellEventArgs(this.dgvManufacture.CurrentCell.ColumnIndex, this.dgvManufacture.CurrentCell.RowIndex);
						this.dgvmanufacture_CellClick(sender, dataGridViewCellEventArg);
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

		public void FillControlsForEdit()
		{
			try
			{
				ManufacturerInfo manufacturerInfo = new ManufacturerInfo();
				manufacturerInfo = this.manufacturesp.ManufacturerView(this.strManufactureIdForEdit);
				this.txtManufactureName.Text = manufacturerInfo.ManufactureName;
				this.txtAddress.Text = manufacturerInfo.Address;
				this.txtPhone.Text = manufacturerInfo.Phone;
				this.txtEmail.Text = manufacturerInfo.Email;
				this.txtDescription.Text = manufacturerInfo.Description;
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

		public void FillManufactureGrid()
		{
			DataRow row = null;
			this.dgvManufacture.Rows.Clear();
			try
			{
				DataTable dataTable = new DataTable();
				dataTable = this.manufacturesp.ManufacturerViewAll();
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
					this.dgvManufacture.Rows.Add();
					this.dgvManufacture.Rows[str].Cells[0].Value = dataRow.ItemArray[0].ToString();
					this.dgvManufacture.Rows[str].Cells[1].Value = dataRow.ItemArray[1].ToString();
					str++;
				}
				this.dgvManufacture.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
				this.dgvManufacture.ClearSelection();
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

		private void frmManufacture_FormClosing(object sender, FormClosingEventArgs e)
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

		private void frmManufacture_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				if (e.KeyCode == Keys.Escape)
				{
					if (MessageBox.Show("Do you want to close?", "Pharmacy", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
					{
						base.Close();
					}
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void frmManufacture_Load(object sender, EventArgs e)
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
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmManufacture));
			this.panel1 = new Panel();
			this.btnSave = new Button();
			this.btnDelete = new Button();
			this.btnClear = new Button();
			this.btnClose = new Button();
			this.panel8 = new Panel();
			this.label5 = new Label();
			this.txtDescription = new TextBox();
			this.txtEmail = new TextBox();
			this.txtPhone = new TextBox();
			this.txtAddress = new TextBox();
			this.label8 = new Label();
			this.label7 = new Label();
			this.gpbRegister = new GroupBox();
			this.panel9 = new Panel();
			this.dgvManufacture = new DataGridView();
			this.Column1 = new DataGridViewTextBoxColumn();
			this.Column2 = new DataGridViewTextBoxColumn();
			this.txtSearch = new TextBox();
			this.label6 = new Label();
			this.label4 = new Label();
			this.label3 = new Label();
			this.txtManufactureName = new TextBox();
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
			this.panel9.SuspendLayout();
			((ISupportInitialize)this.dgvManufacture).BeginInit();
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
			this.panel1.TabIndex = 4;
			this.btnSave.BackColor = Color.FromArgb(255, 209, 150);
			this.btnSave.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 1);
			this.btnSave.FlatStyle = FlatStyle.Flat;
			this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.btnSave.Location = new Point(324, 367);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(75, 23);
			this.btnSave.TabIndex = 6;
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
			this.btnDelete.TabIndex = 7;
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
			this.btnClear.TabIndex = 8;
			this.btnClear.Text = "C&lear";
			this.btnClear.UseVisualStyleBackColor = false;
			this.btnClear.Click += new EventHandler(this.btnClear_Click);
			this.btnClose.BackColor = Color.FromArgb(255, 209, 150);
			this.btnClose.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 1);
			this.btnClose.FlatStyle = FlatStyle.Flat;
			this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.btnClose.Location = new Point(567, 367);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(75, 23);
			this.btnClose.TabIndex = 9;
			this.btnClose.Text = "&Close";
			this.btnClose.UseVisualStyleBackColor = false;
			this.btnClose.Click += new EventHandler(this.btnClose_Click);
			this.panel8.BackgroundImage = (Image)componentResourceManager.GetObject("panel8.BackgroundImage");
			this.panel8.BackgroundImageLayout = ImageLayout.Stretch;
			this.panel8.Controls.Add(this.label5);
			this.panel8.Controls.Add(this.txtDescription);
			this.panel8.Controls.Add(this.txtEmail);
			this.panel8.Controls.Add(this.txtPhone);
			this.panel8.Controls.Add(this.txtAddress);
			this.panel8.Controls.Add(this.label8);
			this.panel8.Controls.Add(this.label7);
			this.panel8.Controls.Add(this.gpbRegister);
			this.panel8.Controls.Add(this.label4);
			this.panel8.Controls.Add(this.label3);
			this.panel8.Controls.Add(this.txtManufactureName);
			this.panel8.Controls.Add(this.label2);
			this.panel8.Dock = DockStyle.Top;
			this.panel8.Location = new Point(1, 34);
			this.panel8.Name = "panel8";
			this.panel8.Padding = new System.Windows.Forms.Padding(5);
			this.panel8.Size = new System.Drawing.Size(648, 327);
			this.panel8.TabIndex = 4;
			this.label5.AutoSize = true;
			this.label5.Location = new Point(8, 176);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(63, 13);
			this.label5.TabIndex = 18;
			this.label5.Text = "Description:";
			this.txtDescription.Location = new Point(134, 173);
			this.txtDescription.Multiline = true;
			this.txtDescription.Name = "txtDescription";
			this.txtDescription.Size = new System.Drawing.Size(232, 79);
			this.txtDescription.TabIndex = 5;
			this.txtDescription.Enter += new EventHandler(this.txtDescription_Enter);
			this.txtDescription.KeyPress += new KeyPressEventHandler(this.txtDescription_KeyPress);
			this.txtEmail.Location = new Point(134, 147);
			this.txtEmail.MaxLength = 50;
			this.txtEmail.Name = "txtEmail";
			this.txtEmail.Size = new System.Drawing.Size(232, 20);
			this.txtEmail.TabIndex = 4;
			this.txtEmail.KeyPress += new KeyPressEventHandler(this.txtEmail_KeyPress);
			this.txtPhone.Location = new Point(134, 121);
			this.txtPhone.MaxLength = 15;
			this.txtPhone.Name = "txtPhone";
			this.txtPhone.Size = new System.Drawing.Size(232, 20);
			this.txtPhone.TabIndex = 3;
			this.txtPhone.KeyPress += new KeyPressEventHandler(this.txtPhone_KeyPress);
			this.txtAddress.Location = new Point(134, 36);
			this.txtAddress.Multiline = true;
			this.txtAddress.Name = "txtAddress";
			this.txtAddress.Size = new System.Drawing.Size(232, 79);
			this.txtAddress.TabIndex = 2;
			this.txtAddress.Enter += new EventHandler(this.txtAddress_Enter);
			this.txtAddress.KeyPress += new KeyPressEventHandler(this.txtAddress_KeyPress);
			this.label8.AutoSize = true;
			this.label8.Location = new Point(8, 128);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(41, 13);
			this.label8.TabIndex = 13;
			this.label8.Text = "Phone:";
			this.label7.AutoSize = true;
			this.label7.Location = new Point(8, 154);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(35, 13);
			this.label7.TabIndex = 12;
			this.label7.Text = "Email:";
			this.gpbRegister.BackColor = Color.White;
			this.gpbRegister.Controls.Add(this.panel9);
			this.gpbRegister.Location = new Point(390, 8);
			this.gpbRegister.Name = "gpbRegister";
			this.gpbRegister.Padding = new System.Windows.Forms.Padding(5);
			this.gpbRegister.Size = new System.Drawing.Size(251, 309);
			this.gpbRegister.TabIndex = 10;
			this.gpbRegister.TabStop = false;
			this.gpbRegister.Text = "Register";
			this.panel9.Controls.Add(this.dgvManufacture);
			this.panel9.Controls.Add(this.txtSearch);
			this.panel9.Controls.Add(this.label6);
			this.panel9.Dock = DockStyle.Fill;
			this.panel9.Location = new Point(5, 18);
			this.panel9.Name = "panel9";
			this.panel9.Size = new System.Drawing.Size(241, 286);
			this.panel9.TabIndex = 0;
			this.dgvManufacture.AllowUserToAddRows = false;
			this.dgvManufacture.AllowUserToDeleteRows = false;
			this.dgvManufacture.AllowUserToResizeColumns = false;
			this.dgvManufacture.AllowUserToResizeRows = false;
			this.dgvManufacture.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvManufacture.BackgroundColor = Color.White;
			this.dgvManufacture.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			DataGridViewColumnCollection columns = this.dgvManufacture.Columns;
			DataGridViewColumn[] column1 = new DataGridViewColumn[] { this.Column1, this.Column2 };
			columns.AddRange(column1);
			this.dgvManufacture.GridColor = Color.WhiteSmoke;
			this.dgvManufacture.Location = new Point(9, 55);
			this.dgvManufacture.MultiSelect = false;
			this.dgvManufacture.Name = "dgvManufacture";
			this.dgvManufacture.ReadOnly = true;
			this.dgvManufacture.RowHeadersVisible = false;
			this.dgvManufacture.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			this.dgvManufacture.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			this.dgvManufacture.Size = new System.Drawing.Size(225, 223);
			this.dgvManufacture.TabIndex = 15;
			this.dgvManufacture.CellClick += new DataGridViewCellEventHandler(this.dgvmanufacture_CellClick);
			this.dgvManufacture.KeyUp += new KeyEventHandler(this.dgvmanufacture_KeyUp);
			this.Column1.HeaderText = "Id";
			this.Column1.Name = "Column1";
			this.Column1.ReadOnly = true;
			this.Column1.Resizable = DataGridViewTriState.False;
			this.Column1.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.Column1.Visible = false;
			this.Column2.HeaderText = "Manufacture";
			this.Column2.Name = "Column2";
			this.Column2.ReadOnly = true;
			this.Column2.Resizable = DataGridViewTriState.False;
			this.Column2.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.txtSearch.Location = new Point(74, 10);
			this.txtSearch.MaxLength = 50;
			this.txtSearch.Name = "txtSearch";
			this.txtSearch.Size = new System.Drawing.Size(160, 20);
			this.txtSearch.TabIndex = 14;
			this.txtSearch.TabStop = false;
			this.txtSearch.TextChanged += new EventHandler(this.txtSearch_TextChanged);
			this.label6.AutoSize = true;
			this.label6.Location = new Point(6, 15);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(62, 13);
			this.label6.TabIndex = 12;
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
			this.txtManufactureName.Location = new Point(134, 10);
			this.txtManufactureName.MaxLength = 50;
			this.txtManufactureName.Name = "txtManufactureName";
			this.txtManufactureName.Size = new System.Drawing.Size(232, 20);
			this.txtManufactureName.TabIndex = 1;
			this.txtManufactureName.LocationChanged += new EventHandler(this.txtManufactureName_Leave);
			this.txtManufactureName.Leave += new EventHandler(this.txtManufactureName_Leave);
			this.txtManufactureName.KeyPress += new KeyPressEventHandler(this.txtManufactureName_KeyPress);
			this.txtManufactureName.KeyDown += new KeyEventHandler(this.txtManufactureName_KeyDown);
			this.label2.AutoSize = true;
			this.label2.Location = new Point(8, 17);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(101, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Manufacture Name:";
			this.panel6.BackgroundImage = (Image)componentResourceManager.GetObject("panel6.BackgroundImage");
			this.panel6.Controls.Add(this.label1);
			this.panel6.Controls.Add(this.panel7);
			this.panel6.Dock = DockStyle.Top;
			this.panel6.Location = new Point(1, 1);
			this.panel6.Name = "panel6";
			this.panel6.Size = new System.Drawing.Size(648, 33);
			this.panel6.TabIndex = 4;
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label1.Location = new Point(11, 7);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(87, 15);
			this.label1.TabIndex = 4;
			this.label1.Text = "Manufacture";
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
			this.panel3.Size = new System.Drawing.Size(1, 416);
			this.panel3.TabIndex = 1;
			this.panel2.BackColor = Color.FromArgb(136, 136, 136);
			this.panel2.Dock = DockStyle.Left;
			this.panel2.Location = new Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(1, 416);
			this.panel2.TabIndex = 0;
			this.dataGridViewTextBoxColumn1.HeaderText = "Id";
			this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn1.ReadOnly = true;
			this.dataGridViewTextBoxColumn1.Resizable = DataGridViewTriState.False;
			this.dataGridViewTextBoxColumn1.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.dataGridViewTextBoxColumn1.Visible = false;
			this.dataGridViewTextBoxColumn2.HeaderText = "Manufacture";
			this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
			this.dataGridViewTextBoxColumn2.ReadOnly = true;
			this.dataGridViewTextBoxColumn2.Resizable = DataGridViewTriState.False;
			this.dataGridViewTextBoxColumn2.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.dataGridViewTextBoxColumn2.Width = 222;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.BackColor = Color.White;
			base.ClientSize = new System.Drawing.Size(664, 430);
			base.Controls.Add(this.panel1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.Icon = (System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.KeyPreview = true;
			base.MaximizeBox = false;
			base.Name = "frmManufacture";
			base.Padding = new System.Windows.Forms.Padding(7);
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "Manufacture";
			base.FormClosing += new FormClosingEventHandler(this.frmManufacture_FormClosing);
			base.KeyDown += new KeyEventHandler(this.frmManufacture_KeyDown);
			base.Load += new EventHandler(this.frmManufacture_Load);
			this.panel1.ResumeLayout(false);
			this.panel8.ResumeLayout(false);
			this.panel8.PerformLayout();
			this.gpbRegister.ResumeLayout(false);
			this.panel9.ResumeLayout(false);
			this.panel9.PerformLayout();
			((ISupportInitialize)this.dgvManufacture).EndInit();
			this.panel6.ResumeLayout(false);
			this.panel6.PerformLayout();
			base.ResumeLayout(false);
		}

		private void txtAddress_Enter(object sender, EventArgs e)
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

		private void txtAddress_KeyPress(object sender, KeyPressEventArgs e)
		{
			try
			{
				if (e.KeyChar != '\r')
				{
					this.inAddressCount = 0;
				}
				else
				{
					frmManufacture _frmManufacture = this;
					_frmManufacture.inAddressCount = _frmManufacture.inAddressCount + 1;
					if (this.inAddressCount == 2)
					{
						this.inAddressCount = 0;
						this.txtPhone.Focus();
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
					frmManufacture _frmManufacture = this;
					_frmManufacture.inDescriptionCount = _frmManufacture.inDescriptionCount + 1;
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
				string str = this.txtDescription.Text.Trim();
				if (e.KeyChar == '\r')
				{
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

		private void txtManufactureName_KeyDown(object sender, KeyEventArgs e)
		{
			if ((e.KeyCode != Keys.Return ? false : this.txtManufactureName.Text != ""))
			{
				this.txtAddress.Focus();
			}
		}

		private void txtManufactureName_KeyPress(object sender, KeyPressEventArgs e)
		{
			try
			{
				string str = this.txtAddress.Text.Trim();
				if ((e.KeyChar != '\r' ? false : this.txtManufactureName.Text.Trim() != ""))
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

		private void txtManufactureName_Leave(object sender, EventArgs e)
		{
			try
			{
				if (MDIMedicalShop.MDIObj.ActiveMdiChild == this)
				{
					if ((this.txtSearch.Focused || this.dgvManufacture.Focused ? false : !this.isFormClose))
					{
						if (this.txtManufactureName.Text.Trim() == "")
						{
							this.txtManufactureName.Focus();
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

		private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
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

		private void txtSearch_TextChanged(object sender, EventArgs e)
		{
			try
			{
				for (int i = 0; i < this.dgvManufacture.Rows.Count; i++)
				{
					if (!this.dgvManufacture[1, i].Value.ToString().ToLower().StartsWith(this.txtSearch.Text.ToLower()))
					{
						this.dgvManufacture.Rows[i].Visible = false;
					}
					else
					{
						this.dgvManufacture.Rows[i].Visible = true;
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
                   
                    this.txtManufactureName.Text = this.txtManufactureName.Text.Trim();
                    if (!(this.txtManufactureName.Text != ""))
                    {
                        MessageBox.Show("Enter Manufacturer Name", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        this.txtManufactureName.Select();
                        this.txtManufactureName.Focus();
                    }
                  
                    else
                    {
                        this.manufacturerinfo.ManufactureName = this.txtManufactureName.Text;
                        if (this.txtAddress == null)
                        {
                            this.manufacturerinfo.Address = "";
                        }
                        else
                        {
                            this.manufacturerinfo.Address = this.txtAddress.Text.ToString();
                        }

                        if (this.txtPhone== null)
                        {
                            this.manufacturerinfo.Phone = "";
                        }
                        else
                        {
                            this.manufacturerinfo.Phone = this.txtPhone.Text.ToString();
                        }
                        if (this.txtEmail== null)
                        {
                            this.manufacturerinfo.Email = "";
                        }
                        else
                        {
                            this.manufacturerinfo.Email = this.txtEmail.Text.ToString();
                        }
                        if (this.txtDescription== null)
                        {
                            this.manufacturerinfo.Description = "";
                        }
                        else
                        {
                            this.manufacturerinfo.Description = this.txtDescription.Text.ToString();
                        }
                        
                        if (this.isAutoGenerate)
                        {
                            if (this.CheckExistanceOfManufacturerName())
                            {
                                MessageBox.Show("manufacturer name already exist", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                this.txtManufactureName.Focus();
                                this.txtManufactureName.SelectAll();
                            }
                            else if (!(this.btnSave.Text == "&Save"))
                            {
                                this.manufacturerinfo.ManufactureId = strManufactureIdForEdit;
                                this.manufacturesp.ManufacturerEdit(this.manufacturerinfo);
                                MessageBox.Show("Updated successfully", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                this.ClearFunction();
                            }
                            else
                            {
                                this.manufacturerinfo.ManufactureId = "0";
                                this.manufacturesp.ManufacturerAdd(this.manufacturerinfo);
                               
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

        public bool CheckExistanceOfManufacturerName()
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