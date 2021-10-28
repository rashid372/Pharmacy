using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;

namespace MedicalShop
{
	public class frmShelf : Form
	{
        private Boolean isAutoGenerate = true;
        private IContainer components = null;

		private Panel panel1;

		private Button btnSave;

		private Button btnDelete;

		private Button btnClear;

		private Button btnClose;

		private Panel panel8;

		private TextBox txtDescription;

		private GroupBox gpbRegister;

		private Label label4;

		private Label label3;

		private TextBox txtShelfName;

		private Label label2;

		private Panel panel6;

		private Label label1;

		private Panel panel7;

		private Panel panel5;

		private Panel panel4;

		private Panel panel3;

		private Panel panel2;

		private Panel panel9;

		private DataGridView dgvShelf;

		private TextBox txtSearch;

		private Label label6;

		private DataGridViewTextBoxColumn ID;

		private DataGridViewTextBoxColumn Shelf;

		private ShelfSP shelfsp = new ShelfSP();
        private MedicalShop.ShelfInfo ShelfInfo = new MedicalShop.ShelfInfo();

        private frmProduct frmproduct;

		private bool isInEditMode = false;

		private bool isFromProductCreationForm = false;

		private bool isFormClose = false;

		private string strShelfIdForEdit = "";

		private string strShelfIdForOtherForms = "";

		private string strShelfName = "";

		private int inDescriptionCount = 0;

		private string strGroupIdForOtherForms = "";


        public frmShelf()
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

 
                shelfsp.ShelfDelete(this.strShelfIdForEdit);
                MessageBox.Show("Deleted successfully", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                ClearFunction();
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
        //private void saveOrEditDetails()
        //{
        //    try
        //    {

        //        DataTable dataTable = new DataTable();
        //         if (!FinacialYearInfo._activeOrNot)
        //        {
        //            MessageBox.Show("Selected finacial year has been closed", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        //        }
        //        else
        //        {

        //            string str = "";
        //            this.txtShelfName.Text = this.txtShelfName.Text.Trim();
        //            if (!(this.txtShelfName.Text == "" ? true : !(this.btnSave.Text == "&Save")))
        //            {
        //                str = this.shelfsp.ProductGroupNameCheck(this.txtShelfName.Text.Trim());
        //                if (!(str != "true"))
        //                {
        //                    MessageBox.Show("Product group already exist", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        //                    this.txtShelfName.Select();
        //                    this.txtShelfName.SelectAll();
        //                }
        //                else
        //                {

        //                    this.ShelfInfo.ShelfName = this.txtShelfName.Text.Trim();
        //                    this.ShelfInfo.ShelfDescription = this.txtDescription.Text.Trim();
        //                    this.strGroupIdForOtherForms = this.shelfsp.ShelfAdd(this.ShelfInfo);
        //                    MessageBox.Show("Saved successfully", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        //                    if (!this.isFromProductCreationForm)
        //                    {
        //                        this.ClearFunction();
        //                    }
        //                    else
        //                    {
        //                        base.Close();
        //                    }
        //                }
        //            }
        //            else if (!(!(this.txtShelfName.Text != "") || !(this.btnSave.Text == "&Update") ? true : !(this.strShelfIdForEdit != "1")))
        //            {
        //                if (this.txtShelfName.Text.Trim().ToLower() != this.strShelfName)
        //                {
        //                    str = this.shelfsp.ProductGroupNameCheck(this.txtShelfName.Text.Trim());
        //                }
        //                if (!(str != "true"))
        //                {
        //                    MessageBox.Show("Shelf already exist", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        //                    this.txtShelfName.Select();
        //                    this.txtShelfName.SelectAll();
        //                }
        //                else
        //                {
        //                    this.ShelfInfo.ShelfId = this.strShelfIdForEdit;
        //                    this.ShelfInfo.ShelfName = this.txtShelfName.Text.Trim();
        //                    this.ShelfInfo.ShelfDescription = this.txtDescription.Text.Trim();
        //                    this.shelfsp.ShelfEdit(this.ShelfInfo);
        //                    this.strGroupIdForOtherForms = this.ShelfInfo.ShelfId;
        //                    MessageBox.Show("Updated successfully", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        //                    this.ClearFunction();
        //                }
        //            }
        //            else if (!(this.strShelfIdForEdit != "1" ? true : !(this.btnSave.Text == "&Update")))
        //            {
        //                MessageBox.Show("Can't update this product group", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        //                this.txtShelfName.Select();
        //                this.txtShelfName.SelectAll();
        //            }
        //            else if (this.txtShelfName.Text == "")
        //            {
        //                MessageBox.Show("Enter group name", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        //                this.txtShelfName.Select();
        //                this.txtShelfName.SelectAll();
        //            }
        //        }
        //    }
        //    catch (Exception exception1)
        //    {
        //        Exception exception = exception1;
        //        MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        //    }
        //}
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
                    this.txtShelfName.Text = this.txtShelfName.Text.Trim();
                    if (!(this.txtShelfName.Text != ""))
                    {
                        MessageBox.Show("Enter ledger name", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        this.txtShelfName.Select();
                        this.txtShelfName.Focus();
                    }

                    else
                    {
                        this.ShelfInfo.ShelfName = this.txtShelfName.Text;
     
 
                        if (txtDescription.Text == null)
                        {
                            this.ShelfInfo.ShelfDescription = "";
                        }
                        else
                        {
                            this.ShelfInfo.ShelfDescription = txtDescription.Text;
                        }




                        if (this.isAutoGenerate)
                        {
                            if (this.CheckExistanceOfShelfName())
                            {
                                MessageBox.Show("Shelf name already exist", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                this.txtShelfName.Focus();
                                this.txtShelfName.SelectAll();
                            }
                            else if (!(this.btnSave.Text == "&Save"))
                            {
                                this.ShelfInfo.ShelfId = strShelfIdForEdit;
                                this.shelfsp.ShelfEdit(this.ShelfInfo);
                                MessageBox.Show("Updated successfully", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                this.ClearFunction();
                            }
                            else
                            {
                                this.ShelfInfo.ShelfId= "0";
                                this.shelfsp.ShelfAdd(this.ShelfInfo);
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

        public bool CheckExistanceOfShelfName()
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

        public void ClearFunction()
		{
			try
			{
				this.strShelfIdForEdit = "";
				this.strShelfIdForOtherForms = "";
				this.strShelfName = "";
				this.txtDescription.Clear();
				this.txtShelfName.Clear();
				this.txtSearch.Clear();
				this.FillShelfGrid();
				this.btnSave.Text = "&Save";
				this.btnClear.Text = "C&lear";
				this.isInEditMode = false;
				this.btnDelete.Enabled = false;
				this.txtShelfName.Focus();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void dgvShelf_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				if (this.dgvShelf.CurrentRow != null)
				{
					if ((this.dgvShelf.Rows.Count <= 0 ? false : e.ColumnIndex > -1))
					{
						if (this.dgvShelf.CurrentRow.Cells[0].Value != null)
						{
							if (this.dgvShelf.CurrentRow.Cells[0].Value.ToString() != "")
							{
								this.strShelfIdForEdit = this.dgvShelf.CurrentRow.Cells[0].Value.ToString();
								this.strShelfName = this.dgvShelf.CurrentRow.Cells[1].Value.ToString();
								this.FillControlsForEdit();
								this.dgvShelf.CurrentRow.Selected = true;
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

		private void dgvShelf_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			try
			{
				DataGridViewCellEventArgs dataGridViewCellEventArg = new DataGridViewCellEventArgs(e.ColumnIndex, e.RowIndex);
				this.dgvShelf_CellClick(sender, dataGridViewCellEventArg);
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void dgvShelf_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
		{
			((DataGridView)sender).ClearSelection();
		}

		private void dgvShelf_KeyUp(object sender, KeyEventArgs e)
		{
			try
			{
				if ((e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Return ? true : e.KeyCode == Keys.Tab))
				{
					if (this.dgvShelf.CurrentRow != null)
					{
						DataGridViewCellEventArgs dataGridViewCellEventArg = new DataGridViewCellEventArgs(this.dgvShelf.CurrentCell.ColumnIndex, this.dgvShelf.CurrentCell.RowIndex);
						this.dgvShelf_CellClick(sender, dataGridViewCellEventArg);
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
				ShelfInfo shelfInfo = new ShelfInfo();
				shelfInfo = this.shelfsp.ShelfView(this.strShelfIdForEdit);
				this.txtShelfName.Text = shelfInfo.ShelfName;
				this.txtDescription.Text = shelfInfo.ShelfDescription;
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

		public void FillShelfGrid()
		{
			DataRow row = null;
			try
			{
				DataTable dataTable = new DataTable();
				dataTable = this.shelfsp.ShelfViewAll();
				this.dgvShelf.Rows.Clear();
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
					this.dgvShelf.Rows.Add();
					this.dgvShelf.Rows[str].Cells[0].Value = dataRow.ItemArray[0].ToString();
					this.dgvShelf.Rows[str].Cells[1].Value = dataRow.ItemArray[1].ToString();
					str++;
				}
				this.dgvShelf.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
				this.dgvShelf.ClearSelection();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void frmShelf_FormClosing(object sender, FormClosingEventArgs e)
		{
		}

		private void frmShelf_Load(object sender, EventArgs e)
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
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmShelf));
			this.panel1 = new Panel();
			this.btnSave = new Button();
			this.btnDelete = new Button();
			this.btnClear = new Button();
			this.btnClose = new Button();
			this.panel8 = new Panel();
			this.txtDescription = new TextBox();
			this.gpbRegister = new GroupBox();
			this.panel9 = new Panel();
			this.dgvShelf = new DataGridView();
			this.ID = new DataGridViewTextBoxColumn();
			this.Shelf = new DataGridViewTextBoxColumn();
			this.txtSearch = new TextBox();
			this.label6 = new Label();
			this.label4 = new Label();
			this.label3 = new Label();
			this.txtShelfName = new TextBox();
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
			((ISupportInitialize)this.dgvShelf).BeginInit();
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
			this.panel1.TabIndex = 1;
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
			this.panel8.Controls.Add(this.txtShelfName);
			this.panel8.Controls.Add(this.label2);
			this.panel8.Dock = DockStyle.Top;
			this.panel8.Location = new Point(1, 34);
			this.panel8.Name = "panel8";
			this.panel8.Padding = new System.Windows.Forms.Padding(5);
			this.panel8.Size = new System.Drawing.Size(648, 315);
			this.panel8.TabIndex = 0;
			this.txtDescription.Location = new Point(134, 36);
			this.txtDescription.Multiline = true;
			this.txtDescription.Name = "txtDescription";
			this.txtDescription.Size = new System.Drawing.Size(232, 55);
			this.txtDescription.TabIndex = 1;
			this.txtDescription.Enter += new EventHandler(this.txtDescription_Enter);
			this.txtDescription.KeyPress += new KeyPressEventHandler(this.txtDescription_KeyPress);
			this.gpbRegister.BackColor = Color.White;
			this.gpbRegister.Controls.Add(this.panel9);
			this.gpbRegister.Location = new Point(389, 8);
			this.gpbRegister.Name = "gpbRegister";
			this.gpbRegister.Padding = new System.Windows.Forms.Padding(5);
			this.gpbRegister.Size = new System.Drawing.Size(251, 295);
			this.gpbRegister.TabIndex = 7;
			this.gpbRegister.TabStop = false;
			this.gpbRegister.Text = "Register";
			this.panel9.Controls.Add(this.dgvShelf);
			this.panel9.Controls.Add(this.txtSearch);
			this.panel9.Controls.Add(this.label6);
			this.panel9.Dock = DockStyle.Fill;
			this.panel9.Location = new Point(5, 18);
			this.panel9.Name = "panel9";
			this.panel9.Size = new System.Drawing.Size(241, 272);
			this.panel9.TabIndex = 0;
			this.dgvShelf.AllowUserToAddRows = false;
			this.dgvShelf.AllowUserToDeleteRows = false;
			this.dgvShelf.AllowUserToOrderColumns = true;
			this.dgvShelf.AllowUserToResizeColumns = false;
			this.dgvShelf.AllowUserToResizeRows = false;
			this.dgvShelf.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvShelf.BackgroundColor = Color.White;
			this.dgvShelf.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			DataGridViewColumnCollection columns = this.dgvShelf.Columns;
			DataGridViewColumn[] d = new DataGridViewColumn[] { this.ID, this.Shelf };
			columns.AddRange(d);
			this.dgvShelf.GridColor = Color.WhiteSmoke;
			this.dgvShelf.Location = new Point(7, 35);
			this.dgvShelf.MultiSelect = false;
			this.dgvShelf.Name = "dgvShelf";
			this.dgvShelf.ReadOnly = true;
			this.dgvShelf.RowHeadersVisible = false;
			this.dgvShelf.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			this.dgvShelf.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			this.dgvShelf.Size = new System.Drawing.Size(225, 230);
			this.dgvShelf.TabIndex = 18;
			this.dgvShelf.TabStop = false;
			this.dgvShelf.CellClick += new DataGridViewCellEventHandler(this.dgvShelf_CellClick);
			this.dgvShelf.ColumnHeaderMouseClick += new DataGridViewCellMouseEventHandler(this.dgvShelf_ColumnHeaderMouseClick);
			this.dgvShelf.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(this.dgvShelf_DataBindingComplete);
			this.dgvShelf.KeyUp += new KeyEventHandler(this.dgvShelf_KeyUp);
			this.ID.HeaderText = "ID";
			this.ID.Name = "ID";
			this.ID.ReadOnly = true;
			this.ID.Resizable = DataGridViewTriState.False;
			this.ID.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.ID.Visible = false;
			this.Shelf.HeaderText = "Shelf";
			this.Shelf.Name = "Shelf";
			this.Shelf.ReadOnly = true;
			this.Shelf.Resizable = DataGridViewTriState.False;
			this.Shelf.SortMode = DataGridViewColumnSortMode.NotSortable;
			this.txtSearch.Location = new Point(79, 9);
			this.txtSearch.MaxLength = 50;
			this.txtSearch.Name = "txtSearch";
			this.txtSearch.Size = new System.Drawing.Size(153, 20);
			this.txtSearch.TabIndex = 17;
			this.txtSearch.TabStop = false;
			this.txtSearch.TextChanged += new EventHandler(this.txtSearch_TextChanged);
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
			this.label4.TabIndex = 5;
			this.label4.Text = "*";
			this.label3.AutoSize = true;
			this.label3.Location = new Point(8, 44);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(63, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "Description:";
			this.txtShelfName.Location = new Point(134, 10);
			this.txtShelfName.MaxLength = 50;
			this.txtShelfName.Name = "txtShelfName";
			this.txtShelfName.Size = new System.Drawing.Size(232, 20);
			this.txtShelfName.TabIndex = 0;
			this.txtShelfName.Leave += new EventHandler(this.txtShelfName_Leave);
			this.txtShelfName.KeyPress += new KeyPressEventHandler(this.txtShelfName_KeyPress);
			this.label2.AutoSize = true;
			this.label2.Location = new Point(8, 17);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(65, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Shelf Name:";
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
			this.label1.Size = new System.Drawing.Size(40, 15);
			this.label1.TabIndex = 4;
			this.label1.Text = "Shelf";
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
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.BackColor = Color.White;
			base.CancelButton = this.btnClose;
			base.ClientSize = new System.Drawing.Size(664, 438);
			base.Controls.Add(this.panel1);
			base.Icon = (System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.Name = "frmShelf";
			base.Padding = new System.Windows.Forms.Padding(7);
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "Shelf";
			base.FormClosing += new FormClosingEventHandler(this.frmShelf_FormClosing);
			base.Load += new EventHandler(this.frmShelf_Load);
			this.panel1.ResumeLayout(false);
			this.panel8.ResumeLayout(false);
			this.panel8.PerformLayout();
			this.gpbRegister.ResumeLayout(false);
			this.panel9.ResumeLayout(false);
			this.panel9.PerformLayout();
			((ISupportInitialize)this.dgvShelf).EndInit();
			this.panel6.ResumeLayout(false);
			this.panel6.PerformLayout();
			base.ResumeLayout(false);
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
					frmShelf _frmShelf = this;
					_frmShelf.inDescriptionCount = _frmShelf.inDescriptionCount + 1;
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

		private void txtSearch_TextChanged(object sender, EventArgs e)
		{
			try
			{
				for (int i = 0; i < this.dgvShelf.Rows.Count; i++)
				{
					if (!this.dgvShelf[1, i].Value.ToString().ToLower().StartsWith(this.txtSearch.Text.ToLower()))
					{
						this.dgvShelf.Rows[i].Visible = false;
					}
					else
					{
						this.dgvShelf.Rows[i].Visible = true;
					}
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void txtShelfName_KeyPress(object sender, KeyPressEventArgs e)
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

		private void txtShelfName_Leave(object sender, EventArgs e)
		{
			try
			{
				if (MDIMedicalShop.MDIObj.ActiveMdiChild == this)
				{
					if ((this.txtSearch.Focused || this.dgvShelf.Focused ? false : !this.isFormClose))
					{
						if (this.txtShelfName.Text.Trim() == "")
						{
							this.txtShelfName.Focus();
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