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
	public class frmTelephoneDirectory : Form
	{
		private MedicalShop.VendorInfo VendorInfo = new MedicalShop.VendorInfo();

		private MedicalShop.VendorSP VendorSP = new MedicalShop.VendorSP();

		private MedicalShop.SalesManInfo SalesManInfo = new MedicalShop.SalesManInfo();

		private MedicalShop.SalesManSP SalesManSP = new MedicalShop.SalesManSP();

		private MedicalShop.ManufacturerInfo ManufacturerInfo = new MedicalShop.ManufacturerInfo();

		private MedicalShop.ManufacturerSP ManufacturerSP = new MedicalShop.ManufacturerSP();

		private MedicalShop.PatientInfo PatientInfo = new MedicalShop.PatientInfo();

		private MedicalShop.PatientSP PatientSP = new MedicalShop.PatientSP();

		private DataTable dtDgdVendorFill = new DataTable();

		private IContainer components = null;

		private Panel panel1;

		private Button btnClose;

		private Panel panel8;

		private Label label2;

		private Panel panel6;

		private Label label1;

		private Panel panel7;

		private Panel panel5;

		private Panel panel4;

		private Panel panel3;

		private Panel panel2;

		private Label label3;

		private TextBox txtSearchFor;

		private ComboBox cmbSearchBy;

		private DataGridView dgdSearch;

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

		public frmTelephoneDirectory()
		{
			this.InitializeComponent();
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

		public void Clear()
		{
			try
			{
				this.txtSearchFor.Text = "";
				this.dgdSearchFill();
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
					e.Handled = true;
					SendKeys.Send("{TAB}");
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void cmbSearchBy_Leave(object sender, EventArgs e)
		{
			try
			{
				if (!(this.cmbSearchBy.Text == ""))
				{
					this.txtSearchFor.Focus();
				}
				else
				{
					this.cmbSearchBy.Focus();
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
				this.Clear();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void dgdSearchFill()
		{
			try
			{
				this.dtDgdVendorFill.Clear();
				if (this.dgdSearch.Rows.Count > 0)
				{
					this.dgdSearch.Rows.Clear();
				}
				this.dtDgdVendorFill = this.VendorSP.TelephoneDirectoryViewByName(this.cmbSearchBy.Text.Trim());
				if (this.dtDgdVendorFill.Rows.Count > 0)
				{
					foreach (DataRow row in this.dtDgdVendorFill.Rows)
					{
						if (row.ItemArray[0].ToString() != "NA")
						{
							this.dgdSearch.Rows.Add();
							this.dgdSearch.Rows[this.dgdSearch.Rows.Count - 1].Cells[0].Value = this.dgdSearch.Rows.Count;
							this.dgdSearch.Rows[this.dgdSearch.Rows.Count - 1].Cells[1].Value = row.ItemArray[0].ToString();
							string str = row.ItemArray[1].ToString();
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
								this.dgdSearch.Rows[this.dgdSearch.Rows.Count - 1].Cells[2].Value = str2;
							}
							else
							{
								this.dgdSearch.Rows[this.dgdSearch.Rows.Count - 1].Cells[2].Value = "";
							}
							this.dgdSearch.Rows[this.dgdSearch.Rows.Count - 1].Cells[3].Value = row.ItemArray[2].ToString();
							if (this.cmbSearchBy.Text != "Manufacture")
							{
								this.dgdSearch.Rows[this.dgdSearch.Rows.Count - 1].Cells[4].Value = row.ItemArray[3].ToString();
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

		protected override void Dispose(bool disposing)
		{
			if ((!disposing ? false : this.components != null))
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void frmTelephoneDirectory_Load(object sender, EventArgs e)
		{
			try
			{
				this.cmbSearchBy.SelectedIndex = 0;
				this.Clear();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void InitializeComponent()
		{
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmTelephoneDirectory));
			this.panel1 = new Panel();
			this.btnClose = new Button();
			this.panel8 = new Panel();
			this.dgdSearch = new DataGridView();
			this.Column1 = new DataGridViewTextBoxColumn();
			this.Column2 = new DataGridViewTextBoxColumn();
			this.Column3 = new DataGridViewTextBoxColumn();
			this.Column4 = new DataGridViewTextBoxColumn();
			this.Column5 = new DataGridViewTextBoxColumn();
			this.cmbSearchBy = new ComboBox();
			this.label3 = new Label();
			this.txtSearchFor = new TextBox();
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
			((ISupportInitialize)this.dgdSearch).BeginInit();
			this.panel6.SuspendLayout();
			base.SuspendLayout();
			this.panel1.BackColor = Color.Transparent;
			this.panel1.BackgroundImage = (Image)componentResourceManager.GetObject("panel1.BackgroundImage");
			this.panel1.BackgroundImageLayout = ImageLayout.Stretch;
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
			this.panel1.Size = new System.Drawing.Size(650, 418);
			this.panel1.TabIndex = 6;
			this.btnClose.BackColor = Color.FromArgb(255, 209, 150);
			this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnClose.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 1);
			this.btnClose.FlatStyle = FlatStyle.Flat;
			this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.btnClose.Location = new Point(557, 377);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(75, 23);
			this.btnClose.TabIndex = 5;
			this.btnClose.Text = "&Close";
			this.btnClose.UseVisualStyleBackColor = false;
			this.btnClose.Click += new EventHandler(this.btnClose_Click);
			this.panel8.BackgroundImage = (Image)componentResourceManager.GetObject("panel8.BackgroundImage");
			this.panel8.BackgroundImageLayout = ImageLayout.Stretch;
			this.panel8.Controls.Add(this.dgdSearch);
			this.panel8.Controls.Add(this.cmbSearchBy);
			this.panel8.Controls.Add(this.label3);
			this.panel8.Controls.Add(this.txtSearchFor);
			this.panel8.Controls.Add(this.label2);
			this.panel8.Dock = DockStyle.Top;
			this.panel8.Location = new Point(1, 34);
			this.panel8.Name = "panel8";
			this.panel8.Padding = new System.Windows.Forms.Padding(5);
			this.panel8.Size = new System.Drawing.Size(648, 325);
			this.panel8.TabIndex = 1;
			this.dgdSearch.AllowUserToAddRows = false;
			this.dgdSearch.AllowUserToDeleteRows = false;
			this.dgdSearch.AllowUserToResizeColumns = false;
			this.dgdSearch.AllowUserToResizeRows = false;
			this.dgdSearch.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			this.dgdSearch.BackgroundColor = Color.White;
			this.dgdSearch.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			DataGridViewColumnCollection columns = this.dgdSearch.Columns;
			DataGridViewColumn[] column1 = new DataGridViewColumn[] { this.Column1, this.Column2, this.Column3, this.Column4, this.Column5 };
			columns.AddRange(column1);
			this.dgdSearch.GridColor = Color.WhiteSmoke;
			this.dgdSearch.Location = new Point(11, 73);
			this.dgdSearch.MultiSelect = false;
			this.dgdSearch.Name = "dgdSearch";
			this.dgdSearch.ReadOnly = true;
			this.dgdSearch.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
			this.dgdSearch.RowHeadersVisible = false;
			this.dgdSearch.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			this.dgdSearch.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			this.dgdSearch.Size = new System.Drawing.Size(629, 216);
			this.dgdSearch.TabIndex = 35;
			this.Column1.HeaderText = "SI";
			this.Column1.Name = "Column1";
			this.Column1.ReadOnly = true;
			this.Column1.Visible = false;
			this.Column2.HeaderText = "Name";
			this.Column2.Name = "Column2";
			this.Column2.ReadOnly = true;
			this.Column3.HeaderText = "Address";
			this.Column3.Name = "Column3";
			this.Column3.ReadOnly = true;
			this.Column4.HeaderText = "Phone";
			this.Column4.Name = "Column4";
			this.Column4.ReadOnly = true;
			this.Column5.HeaderText = "Mobille";
			this.Column5.Name = "Column5";
			this.Column5.ReadOnly = true;
			this.cmbSearchBy.DropDownStyle = ComboBoxStyle.DropDownList;
			this.cmbSearchBy.FormattingEnabled = true;
			ComboBox.ObjectCollection items = this.cmbSearchBy.Items;
			object[] objArray = new object[] { "All", "Vendor", "Sales Man", "Manufacture", "Patient" };
			items.AddRange(objArray);
			this.cmbSearchBy.Location = new Point(134, 9);
			this.cmbSearchBy.Name = "cmbSearchBy";
			this.cmbSearchBy.Size = new System.Drawing.Size(232, 21);
			this.cmbSearchBy.TabIndex = 0;
			this.cmbSearchBy.Leave += new EventHandler(this.cmbSearchBy_Leave);
			this.cmbSearchBy.SelectedIndexChanged += new EventHandler(this.cmbSearchBy_SelectedIndexChanged);
			this.cmbSearchBy.KeyPress += new KeyPressEventHandler(this.cmbSearchBy_KeyPress);
			this.cmbSearchBy.KeyDown += new KeyEventHandler(this.cmbSearchBy_KeyDown);
			this.label3.AutoSize = true;
			this.label3.Location = new Point(8, 43);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(62, 13);
			this.label3.TabIndex = 7;
			this.label3.Text = "Search For:";
			this.txtSearchFor.Location = new Point(134, 36);
			this.txtSearchFor.MaxLength = 50;
			this.txtSearchFor.Name = "txtSearchFor";
			this.txtSearchFor.Size = new System.Drawing.Size(232, 20);
			this.txtSearchFor.TabIndex = 1;
			this.txtSearchFor.TextChanged += new EventHandler(this.txtSearchFor_TextChanged);
			this.label2.AutoSize = true;
			this.label2.Location = new Point(8, 17);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(59, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Search By:";
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
			this.label1.Size = new System.Drawing.Size(136, 15);
			this.label1.TabIndex = 4;
			this.label1.Text = "Telephone Directory";
			this.panel7.BackColor = Color.FromArgb(136, 136, 136);
			this.panel7.Dock = DockStyle.Bottom;
			this.panel7.Location = new Point(0, 32);
			this.panel7.Name = "panel7";
			this.panel7.Size = new System.Drawing.Size(648, 1);
			this.panel7.TabIndex = 3;
			this.panel5.BackColor = Color.FromArgb(136, 136, 136);
			this.panel5.Dock = DockStyle.Bottom;
			this.panel5.Location = new Point(1, 417);
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
			this.panel3.Size = new System.Drawing.Size(1, 418);
			this.panel3.TabIndex = 1;
			this.panel2.BackColor = Color.FromArgb(136, 136, 136);
			this.panel2.Dock = DockStyle.Left;
			this.panel2.Location = new Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(1, 418);
			this.panel2.TabIndex = 0;
			this.dataGridViewTextBoxColumn1.HeaderText = "SI";
			this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn1.Visible = false;
			this.dataGridViewTextBoxColumn1.Width = 125;
			this.dataGridViewTextBoxColumn2.HeaderText = "Name";
			this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
			this.dataGridViewTextBoxColumn2.Width = 125;
			this.dataGridViewTextBoxColumn3.HeaderText = "Address";
			this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
			this.dataGridViewTextBoxColumn3.Width = 126;
			this.dataGridViewTextBoxColumn4.HeaderText = "Phone";
			this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
			this.dataGridViewTextBoxColumn4.Width = 125;
			this.dataGridViewTextBoxColumn5.HeaderText = "Mobille";
			this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
			this.dataGridViewTextBoxColumn5.Width = 125;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.BackColor = Color.White;
			base.CancelButton = this.btnClose;
			base.ClientSize = new System.Drawing.Size(664, 432);
			base.Controls.Add(this.panel1);
			base.Icon = (System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.Name = "frmTelephoneDirectory";
			base.Padding = new System.Windows.Forms.Padding(7);
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "Telephone Directory";
			base.Load += new EventHandler(this.frmTelephoneDirectory_Load);
			this.panel1.ResumeLayout(false);
			this.panel8.ResumeLayout(false);
			this.panel8.PerformLayout();
			((ISupportInitialize)this.dgdSearch).EndInit();
			this.panel6.ResumeLayout(false);
			this.panel6.PerformLayout();
			base.ResumeLayout(false);
		}

		private void txtSearchFor_TextChanged(object sender, EventArgs e)
		{
			try
			{
				for (int i = 0; i < this.dgdSearch.Rows.Count; i++)
				{
					if (!this.dgdSearch[1, i].Value.ToString().ToLower().StartsWith(this.txtSearchFor.Text.ToLower()))
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
	}
}