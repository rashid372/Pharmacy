using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;

namespace MedicalShop
{
	public class frmUnit : Form
	{
		private MedicalShop.UnitInfo UnitInfo = new MedicalShop.UnitInfo();

		private MedicalShop.UnitSP UnitSP = new MedicalShop.UnitSP();

		private MedicalShop.frmProduct frmProduct = new MedicalShop.frmProduct();

		private string _ID = "";

		private string _Name = "";

		private bool isFromProductForm = false;

		private string strUnitNameOtherForms = "";

		private bool isFormClose = false;

		private int inDescriptionCount = 0;

		private IContainer components = null;

		private Panel panel1;

		private Button btnSave;

		private Button btnDelete;

		private Button btnClear;

		private Button btnClose;

		private Panel panel8;

		private TextBox txtDescription;

		private GroupBox gpbRegister;

		private Panel panel9;

		private DataGridView dgdSearch;

		private TextBox txtsearch;

		private Label label6;

		private Label label4;

		private Label label3;

		private TextBox txtUnitName;

		private Label label2;

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

		private DataGridViewTextBoxColumn Column1;

		private DataGridViewTextBoxColumn Column2;

		private DataGridViewTextBoxColumn Column3;

		public frmUnit()
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
				this.DeleteDetails();
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

		public void clear()
		{
			try
			{
				this.txtUnitName.Text = "";
				this.txtDescription.Text = "";
				this.txtsearch.Text = "";
				this.dgdSearchFill();
				this._ID = "";
				this.btnSave.Text = "&Save";
				this.btnClear.Text = "C&lear";
				this.btnDelete.Enabled = false;
				this.txtUnitName.Focus();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void DeleteDetails()
		{
			try
			{
				if (!FinacialYearInfo._activeOrNot)
				{
					MessageBox.Show("Selected finacial year has been closed", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
				else if (!(this.UnitSP.UnitIdCheckForDelete(this._ID) != "true"))
				{
					MessageBox.Show("Can't delete,reference exist", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					this.txtUnitName.Select();
				}
				else if (MessageBox.Show("Do you want to delete?", "Pharmacy", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
				{
					this.UnitSP.UnitDelete(this._ID);
					this.clear();
					MessageBox.Show("Deleted successfully", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
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
						this._Name = this.dgdSearch.CurrentRow.Cells[1].Value.ToString();
						this.txtUnitName.Text = this.dgdSearch.CurrentRow.Cells[1].Value.ToString();
						this.txtDescription.Text = this.dgdSearch.CurrentRow.Cells[2].Value.ToString();
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
				DataTable dataTable = new DataTable();
				dataTable = this.UnitSP.UnitViewAll();
				if (this.dgdSearch.RowCount > 0)
				{
					this.dgdSearch.Rows.Clear();
				}
				foreach (DataRow row in dataTable.Rows)
				{
					this.dgdSearch.Rows.Add();
					this.dgdSearch.Rows[str].Cells[0].Value = row.ItemArray[0].ToString();
					this.dgdSearch.Rows[str].Cells[1].Value = row.ItemArray[1].ToString();
					this.dgdSearch.Rows[str].Cells[2].Value = row.ItemArray[2].ToString();
					str++;
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

		private void frmUnit_FormClosing(object sender, FormClosingEventArgs e)
		{
		}

		private void frmUnit_Load(object sender, EventArgs e)
		{
			try
			{
				this.dgdSearchFill();
				this.btnDelete.Enabled = false;
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void InitializeComponent()
		{
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmUnit));
			this.panel1 = new Panel();
			this.btnSave = new Button();
			this.btnDelete = new Button();
			this.btnClear = new Button();
			this.btnClose = new Button();
			this.panel8 = new Panel();
			this.txtDescription = new TextBox();
			this.gpbRegister = new GroupBox();
			this.panel9 = new Panel();
			this.dgdSearch = new DataGridView();
			this.Column1 = new DataGridViewTextBoxColumn();
			this.Column2 = new DataGridViewTextBoxColumn();
			this.Column3 = new DataGridViewTextBoxColumn();
			this.txtsearch = new TextBox();
			this.label6 = new Label();
			this.label4 = new Label();
			this.label3 = new Label();
			this.txtUnitName = new TextBox();
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
			this.panel1.SuspendLayout();
			this.panel8.SuspendLayout();
			this.gpbRegister.SuspendLayout();
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
			this.panel1.Size = new System.Drawing.Size(650, 424);
			this.panel1.TabIndex = 2;
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
			this.panel8.Controls.Add(this.txtDescription);
			this.panel8.Controls.Add(this.gpbRegister);
			this.panel8.Controls.Add(this.label4);
			this.panel8.Controls.Add(this.label3);
			this.panel8.Controls.Add(this.txtUnitName);
			this.panel8.Controls.Add(this.label2);
			this.panel8.Dock = DockStyle.Top;
			this.panel8.Location = new Point(1, 34);
			this.panel8.Name = "panel8";
			this.panel8.Padding = new System.Windows.Forms.Padding(5);
			this.panel8.Size = new System.Drawing.Size(648, 330);
			this.panel8.TabIndex = 1;
			this.txtDescription.Location = new Point(134, 36);
			this.txtDescription.Multiline = true;
			this.txtDescription.Name = "txtDescription";
			this.txtDescription.Size = new System.Drawing.Size(232, 55);
			this.txtDescription.TabIndex = 1;
			this.txtDescription.Enter += new EventHandler(this.txtDescription_Enter);
			this.txtDescription.KeyPress += new KeyPressEventHandler(this.txtDescription_KeyPress);
			this.gpbRegister.BackColor = Color.White;
			this.gpbRegister.Controls.Add(this.panel9);
			this.gpbRegister.Location = new Point(390, 8);
			this.gpbRegister.Name = "gpbRegister";
			this.gpbRegister.Padding = new System.Windows.Forms.Padding(5);
			this.gpbRegister.Size = new System.Drawing.Size(251, 309);
			this.gpbRegister.TabIndex = 7;
			this.gpbRegister.TabStop = false;
			this.gpbRegister.Text = "Register";
			this.panel9.Controls.Add(this.dgdSearch);
			this.panel9.Controls.Add(this.txtsearch);
			this.panel9.Controls.Add(this.label6);
			this.panel9.Dock = DockStyle.Fill;
			this.panel9.Location = new Point(5, 18);
			this.panel9.Name = "panel9";
			this.panel9.Size = new System.Drawing.Size(241, 286);
			this.panel9.TabIndex = 0;
			this.dgdSearch.AllowUserToAddRows = false;
			this.dgdSearch.AllowUserToDeleteRows = false;
			this.dgdSearch.AllowUserToOrderColumns = true;
			this.dgdSearch.AllowUserToResizeColumns = false;
			this.dgdSearch.AllowUserToResizeRows = false;
			this.dgdSearch.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			this.dgdSearch.BackgroundColor = Color.White;
			this.dgdSearch.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			DataGridViewColumnCollection columns = this.dgdSearch.Columns;
			DataGridViewColumn[] column1 = new DataGridViewColumn[] { this.Column1, this.Column2, this.Column3 };
			columns.AddRange(column1);
			this.dgdSearch.GridColor = Color.WhiteSmoke;
			this.dgdSearch.Location = new Point(7, 35);
			this.dgdSearch.MultiSelect = false;
			this.dgdSearch.Name = "dgdSearch";
			this.dgdSearch.ReadOnly = true;
			this.dgdSearch.RowHeadersVisible = false;
			this.dgdSearch.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			this.dgdSearch.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			this.dgdSearch.Size = new System.Drawing.Size(225, 248);
			this.dgdSearch.TabIndex = 1;
			this.dgdSearch.TabStop = false;
			this.dgdSearch.CellClick += new DataGridViewCellEventHandler(this.dgdSearch_CellClick);
			this.dgdSearch.Leave += new EventHandler(this.txtsearch_Leave);
			this.dgdSearch.KeyUp += new KeyEventHandler(this.dgdSearch_KeyUp);
			this.Column1.HeaderText = "SI";
			this.Column1.Name = "Column1";
			this.Column1.ReadOnly = true;
			this.Column1.Resizable = DataGridViewTriState.False;
			this.Column1.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.Column1.Visible = false;
			this.Column2.HeaderText = "Name";
			this.Column2.Name = "Column2";
			this.Column2.ReadOnly = true;
			this.Column2.Resizable = DataGridViewTriState.False;
			this.Column2.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.Column3.HeaderText = "Description";
			this.Column3.Name = "Column3";
			this.Column3.ReadOnly = true;
			this.Column3.Resizable = DataGridViewTriState.False;
			this.Column3.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.Column3.Visible = false;
			this.txtsearch.Location = new Point(79, 9);
			this.txtsearch.MaxLength = 50;
			this.txtsearch.Name = "txtsearch";
			this.txtsearch.Size = new System.Drawing.Size(153, 20);
			this.txtsearch.TabIndex = 0;
			this.txtsearch.TabStop = false;
			this.txtsearch.Leave += new EventHandler(this.txtsearch_Leave);
			this.txtsearch.TextChanged += new EventHandler(this.txtsearch_TextChanged);
			this.label6.AutoSize = true;
			this.label6.Location = new Point(4, 16);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(62, 13);
			this.label6.TabIndex = 16;
			this.label6.Text = "Search For:";
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label4.ForeColor = Color.Red;
			this.label4.Location = new Point(372, 13);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(12, 13);
			this.label4.TabIndex = 2;
			this.label4.Text = "*";
			this.label3.AutoSize = true;
			this.label3.Location = new Point(8, 44);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(63, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "Description:";
			this.txtUnitName.Location = new Point(134, 10);
			this.txtUnitName.MaxLength = 50;
			this.txtUnitName.Name = "txtUnitName";
			this.txtUnitName.Size = new System.Drawing.Size(232, 20);
			this.txtUnitName.TabIndex = 0;
			this.txtUnitName.Leave += new EventHandler(this.txtUnitName_Leave);
			this.txtUnitName.KeyPress += new KeyPressEventHandler(this.txtUnitName_KeyPress);
			this.label2.AutoSize = true;
			this.label2.Location = new Point(8, 17);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(29, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Unit:";
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
			this.label1.Size = new System.Drawing.Size(33, 15);
			this.label1.TabIndex = 4;
			this.label1.Text = "Unit";
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
			this.dataGridViewTextBoxColumn1.HeaderText = "ID";
			this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn1.ReadOnly = true;
			this.dataGridViewTextBoxColumn1.Visible = false;
			this.dataGridViewTextBoxColumn1.Width = 74;
			this.dataGridViewTextBoxColumn2.HeaderText = "Shelf";
			this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
			this.dataGridViewTextBoxColumn2.ReadOnly = true;
			this.dataGridViewTextBoxColumn2.Width = 222;
			this.dataGridViewTextBoxColumn3.HeaderText = "Description";
			this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
			this.dataGridViewTextBoxColumn3.Width = 74;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.BackColor = Color.White;
			base.CancelButton = this.btnClose;
			base.ClientSize = new System.Drawing.Size(664, 438);
			base.Controls.Add(this.panel1);
			base.Icon = (System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.Name = "frmUnit";
			base.Padding = new System.Windows.Forms.Padding(7);
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "Unit";
			base.FormClosing += new FormClosingEventHandler(this.frmUnit_FormClosing);
			base.Load += new EventHandler(this.frmUnit_Load);
			this.panel1.ResumeLayout(false);
			this.panel8.ResumeLayout(false);
			this.panel8.PerformLayout();
			this.gpbRegister.ResumeLayout(false);
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
					this.txtUnitName.Text = this.txtUnitName.Text.Trim();
					if (!(this.txtUnitName.Text.Trim() == "" ? true : !(this.btnSave.Text == "&Save")))
					{
						if (!(this.UnitSP.UnitNameCheck(this.txtUnitName.Text.Trim()) != "true"))
						{
							MessageBox.Show("Unit name already exist", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
							this.txtUnitName.Select();
						}
						else
						{
							this.UnitInfo.UnitName = this.txtUnitName.Text.Trim();
							this.UnitInfo.Description = this.txtDescription.Text.Trim();
							this.strUnitNameOtherForms = this.UnitSP.UnitAdd(this.UnitInfo);
							MessageBox.Show("Saved successfully", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
							if (!this.isFromProductForm)
							{
								this.clear();
							}
							else
							{
								base.Close();
							}
						}
					}
					else if ((this.txtUnitName.Text.Trim() == "" ? true : !(this.btnSave.Text == "&Update")))
					{
						MessageBox.Show("Enter unit name", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						this.txtUnitName.Select();
					}
					else if (this._Name.ToLower().Trim() == this.txtUnitName.Text.ToLower().Trim())
					{
						this.UnitInfo.UnitId = this._ID;
						this.UnitInfo.UnitName = this.txtUnitName.Text.Trim();
						this.UnitInfo.Description = this.txtDescription.Text.Trim();
						this.UnitSP.UnitEdit(this.UnitInfo);
						this.strUnitNameOtherForms = this._ID;
						MessageBox.Show("Updated successfully", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						this.clear();
					}
					else if (!(this.UnitSP.UnitNameCheck(this.txtUnitName.Text.Trim()) != "true"))
					{
						MessageBox.Show("Unit name already exist", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						this.txtUnitName.Select();
					}
					else
					{
						this.UnitInfo.UnitId = this._ID;
						this.UnitInfo.UnitName = this.txtUnitName.Text.Trim();
						this.UnitInfo.Description = this.txtDescription.Text.Trim();
						this.UnitSP.UnitEdit(this.UnitInfo);
						this.strUnitNameOtherForms = this._ID;
						MessageBox.Show("Updated successfully", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						this.clear();
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
				if (e.KeyChar != '\r')
				{
					this.inDescriptionCount = 0;
				}
				else
				{
					frmUnit _frmUnit = this;
					_frmUnit.inDescriptionCount = _frmUnit.inDescriptionCount + 1;
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

		private void txtsearch_Leave(object sender, EventArgs e)
		{
		}

		private void txtsearch_TextChanged(object sender, EventArgs e)
		{
			try
			{
				for (int i = 0; i < this.dgdSearch.Rows.Count; i++)
				{
					if (!this.dgdSearch[1, i].Value.ToString().ToLower().StartsWith(this.txtsearch.Text.ToLower()))
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

		private void txtUnitName_KeyPress(object sender, KeyPressEventArgs e)
		{
			if ((e.KeyChar != '\r' || !(this.txtUnitName.Text.Trim() != "") ? true : this.txtsearch.Focused))
			{
				this.txtUnitName.Focus();
			}
			else
			{
				e.Handled = true;
				SendKeys.Send("{TAB}");
			}
		}

		private void txtUnitName_Leave(object sender, EventArgs e)
		{
			try
			{
				if (MDIMedicalShop.MDIObj.ActiveMdiChild == this)
				{
					if ((this.txtsearch.Focused || this.dgdSearch.Focused ? false : !this.isFormClose))
					{
						if (this.txtUnitName.Text.Trim() == "")
						{
							this.txtUnitName.Focus();
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