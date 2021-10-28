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
	public class frmScheduler : Form
	{
		private IContainer components = null;

		private Panel panel1;

		private Button btnClose;

		private Panel panel8;

		private Panel panel6;

		private Label label1;

		private Panel panel7;

		private Panel panel5;

		private Panel panel4;

		private Panel panel3;

		private Panel panel2;

		private TabControl tcSheduler;

		private TabPage tabCalender;

		private TabPage tabReminder;

		private GroupBox groupBox1;

		private Panel panel9;

		private DataGridView dgvReminder;

		private TextBox txtDescriptionReminder;

		private DateTimePicker dtpCurrentDate;

		private DateTimePicker dtpReminderDate;

		private Label label8;

		private Label label3;

		private Label label2;

		private Button btnSaveCalendar;

		private Button btnClearCalendar;

		private Button btnSaveReminder;

		private Button btnDeleteReminder;

		private Button btnClearReminder;

		private DataGridView dgvSearch;

		private DateTimePicker dtpCMonth;

		private DateTimePicker dtpCYear;

		private DataGridView dgvCalendar;

		private DataGridViewButtonColumn Sun;

		private DataGridViewButtonColumn Mon;

		private DataGridViewButtonColumn Tue;

		private DataGridViewButtonColumn Wed;

		private DataGridViewButtonColumn Thu;

		private DataGridViewButtonColumn Fri;

		private DataGridViewButtonColumn Sat;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;

		private Label label4;

		private DataGridViewTextBoxColumn Column1;

		private DataGridViewTextBoxColumn FromDate;

		private DataGridViewTextBoxColumn DayDescription;

		private DataGridViewTextBoxColumn Column2;

		private DateTimePicker dtpReminderMonth;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;

		private DataGridViewTextBoxColumn SlNof;

		private DataGridViewTextBoxColumn datef;

		private DataGridViewTextBoxColumn Column3;

		private DataGridViewTextBoxColumn Column4;

		private DataGridViewTextBoxColumn Column5;

		private MedicalShop.CalenderInfo CalenderInfo = new MedicalShop.CalenderInfo();

		private MedicalShop.CalenderSP CalenderSP = new MedicalShop.CalenderSP();

		private MedicalShop.ReminderInfo ReminderInfo = new MedicalShop.ReminderInfo();

		private MedicalShop.ReminderSP ReminderSP = new MedicalShop.ReminderSP();

		private bool isFromREminderPopUp = false;

		private string _ID = "";

		private string _serialNumber = "";

		private int _month = 0;

		private string _reminderId = "";

		private int intFocus = 0;

		public frmScheduler()
		{
			this.InitializeComponent();
		}

		private void btnClearCalendar_Click(object sender, EventArgs e)
		{
			try
			{
				this.ClearTabCalender();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void btnClearReminder_Click(object sender, EventArgs e)
		{
			try
			{
				this.ClearTabReminder();
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

		private void btnDeleteCalendar_Click(object sender, EventArgs e)
		{
			try
			{
				this.DeleteCalendar();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void btnDeleteReminder_Click(object sender, EventArgs e)
		{
			try
			{
				this.DeleteReminder();
				this.ClearTabReminder();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void btnSaveCalendar_Click(object sender, EventArgs e)
		{
			try
			{
				this.SaveCalendar();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void btnSaveReminder_Click(object sender, EventArgs e)
		{
			try
			{
				this.SaveReminder();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		public void CallthisFormFromReminderPOpUp()
		{
			this.isFromREminderPopUp = true;
			this.tcSheduler.SelectedTab = this.tabReminder;
		}

		public void checkCurentMonth()
		{
			int month = DateTime.Today.Month;
			this.dtpReminderMonth.Text = DateTime.Today.ToString();
		}

		public void CheckMonth()
		{
			if (this.dtpCMonth.Text == "Jan")
			{
				this._month = 1;
			}
			else if (this.dtpCMonth.Text == "Feb")
			{
				this._month = 2;
			}
			else if (this.dtpCMonth.Text == "Mar")
			{
				this._month = 3;
			}
			else if (this.dtpCMonth.Text == "Apr")
			{
				this._month = 4;
			}
			else if (this.dtpCMonth.Text == "May")
			{
				this._month = 5;
			}
			else if (this.dtpCMonth.Text == "Jun")
			{
				this._month = 6;
			}
			else if (this.dtpCMonth.Text == "Jul")
			{
				this._month = 7;
			}
			else if (this.dtpCMonth.Text == "Aug")
			{
				this._month = 8;
			}
			else if (this.dtpCMonth.Text == "Sep")
			{
				this._month = 9;
			}
			else if (this.dtpCMonth.Text == "Oct")
			{
				this._month = 10;
			}
			else if (this.dtpCMonth.Text == "Nov")
			{
				this._month = 11;
			}
			else if (this.dtpCMonth.Text == "Dec")
			{
				this._month = 12;
			}
		}

		public void ClearTabCalender()
		{
			try
			{
				int year = this.dtpCYear.Value.Year;
				DateTime value = this.dtpCMonth.Value;
				DateTime dateTime = new DateTime(year, value.Month, 1);
				this.btnSaveCalendar.Text = "&Save";
				this.dtpCMonth.Value = dateTime;
				this.dtpCYear.Value = dateTime;
				this._ID = "";
				this._serialNumber = "";
				this.LoadCalendar();
				this.dtpCMonth.Select();
				this.FillSearchGrid();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		public void ClearTabReminder()
		{
			try
			{
				this.dtpCurrentDate.Text = DateTime.Today.ToString();
				this.dtpReminderDate.Text = DateTime.Today.ToString();
				this.txtDescriptionReminder.Text = "";
				this.dgdReminderFill();
				this.checkCurentMonth();
				this.btnDeleteReminder.Enabled = false;
				this.btnSaveReminder.Text = "&Save";
				this.btnClearReminder.Text = "C&lear";
				this._reminderId = "";
				this.txtDescriptionReminder.Select();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void DeleteCalendar()
		{
			DataGridViewRow row = null;
			DataGridViewRow dataGridViewRow = null;
			try
			{
				int num = 0;
				if (MessageBox.Show("Do you want to delete?", "Pharmacy", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
				{
					if (!(this._ID != ""))
					{
						foreach (DataGridViewRow row1 in (IEnumerable)this.dgvSearch.Rows)
						{
							if (!(row1.Cells[0].Value.ToString() == this._serialNumber))
							{
								num++;
							}
							else
							{
								this.dgvSearch.Rows.RemoveAt(num);
								num = 1;
								foreach (DataGridViewRow dataGridViewRow1 in (IEnumerable)this.dgvSearch.Rows)
								{
									int num1 = num;
									num = num1 + 1;
									dataGridViewRow1.Cells[0].Value = num1;
								}
								break;
							}
						}
					}
					else
					{
						this.CalenderSP.CalenderDelete(this._ID);
						foreach (DataGridViewRow row1 in (IEnumerable)this.dgvSearch.Rows)
						{
							if (!(row1.Cells[0].Value.ToString() == this._serialNumber))
							{
								num++;
							}
							else
							{
								this.dgvSearch.Rows.RemoveAt(num);
								num = 1;
								foreach (DataGridViewRow dataGridViewRow1 in (IEnumerable)this.dgvSearch.Rows)
								{
									int num2 = num;
									num = num2 + 1;
									dataGridViewRow1.Cells[0].Value = num2;
								}
								break;
							}
						}
					}
					DataGridViewCell currentCell = this.dgvSearch.CurrentCell;
					this.dgvSearch.CurrentCell = null;
					MessageBox.Show("Deleted successfully", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					this.LoadCalendar();
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void DeleteReminder()
		{
			try
			{
				if (MessageBox.Show("Do you want to delete?", "Pharmacy", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
				{
					this.ReminderSP.ReminderDelete(this._reminderId);
					MessageBox.Show("Deleted successfully", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					this.txtDescriptionReminder.Text = "";
					this.dtpCurrentDate.Text = DateTime.Today.ToString();
					this.dtpReminderDate.Text = DateTime.Today.ToString();
					this.dgdReminderFill();
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void dgdReminder_Click(object sender, EventArgs e)
		{
			try
			{
				if (this.dgvReminder.Rows.Count > 0)
				{
					this._reminderId = this.dgvReminder.CurrentRow.Cells[2].Value.ToString();
					this.ReminderInfo = this.ReminderSP.ReminderView(this._reminderId);
					this.txtDescriptionReminder.Text = this.ReminderInfo.Description;
					this.dtpCurrentDate.Text = this.dgvReminder.CurrentRow.Cells[3].Value.ToString();
					this.dtpReminderDate.Text = this.dgvReminder.CurrentRow.Cells[4].Value.ToString();
					this.btnDeleteReminder.Enabled = true;
					this.btnSaveReminder.Text = "&Update";
					this.btnClearReminder.Text = "&New";
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void dgdReminder_KeyUp(object sender, KeyEventArgs e)
		{
			try
			{
				if ((e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Return ? true : e.KeyCode == Keys.Tab))
				{
					if (this.dgvReminder.CurrentRow != null)
					{
						DataGridViewCellEventArgs dataGridViewCellEventArg = new DataGridViewCellEventArgs(0, this.dgvReminder.CurrentRow.Index);
						this.dgdReminder_Click(sender, dataGridViewCellEventArg);
					}
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		public void dgdReminderFill()
		{
			try
			{
				if (this.dtpReminderMonth.Text != "")
				{
					DataTable dataTable = new DataTable();
					if (this.dgvReminder.RowCount > 0)
					{
						this.dgvReminder.Rows.Clear();
					}
					dataTable = this.ReminderSP.ReminderViewBydate(DateTime.Parse(this.dtpReminderMonth.Text));
					int count = 0;
					foreach (DataRow row in dataTable.Rows)
					{
						this.dgvReminder.Rows.Add();
						this.dgvReminder.Rows[count].Cells[0].Value = this.dgvReminder.Rows.Count;
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
							this.dgvReminder[1, this.dgvReminder.Rows.Count - 1].Value = str2;
						}
						else
						{
							this.dgvReminder[1, this.dgvReminder.Rows.Count - 1].Value = "";
						}
						this.dgvReminder.Rows[count].Cells[2].Value = row.ItemArray[0].ToString();
						this.dgvReminder.Rows[count].Cells[3].Value = row.ItemArray[1].ToString();
						this.dgvReminder.Rows[count].Cells[4].Value = row.ItemArray[2].ToString();
						count++;
					}
					this.dgvReminder.ClearSelection();
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
				if (this.dgvSearch.Rows.Count > 0)
				{
					if (this.dgvSearch.CurrentRow.Cells[3].Value != null)
					{
						this._ID = this.dgvSearch.CurrentRow.Cells[3].Value.ToString();
					}
					this._serialNumber = this.dgvSearch.CurrentRow.Cells[0].Value.ToString();
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void dgdSearch_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
		{
			this.dgvSearch.ClearSelection();
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

		private void dgvCalendar_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				if (this.dgvCalendar.CurrentRow != null)
				{
					if ((this.dgvCalendar.CurrentCell == null ? false : this.dgvCalendar.CurrentRow.Index != 0))
					{
						bool flag = false;
						int index = 0;
						if (this.dgvCalendar.CurrentCell.Value != null)
						{
							int year = this.dtpCYear.Value.Year;
							DateTime value = this.dtpCMonth.Value;
							DateTime dateTime = new DateTime(year, value.Month, int.Parse(this.dgvCalendar.CurrentCell.Value.ToString()));
							string str = dateTime.ToString("dd-MMM-yyyy");
							foreach (DataGridViewRow row in (IEnumerable)this.dgvSearch.Rows)
							{
								if (row.Cells[1].Value.ToString() == str)
								{
									flag = true;
									index = row.Index;
									break;
								}
							}
							if (!flag)
							{
								this.dgvSearch.Rows.Add();
								this.dgvSearch.Rows[this.dgvSearch.Rows.Count - 1].Cells[0].Value = this.dgvSearch.Rows.Count;
								this.dgvSearch.Rows[this.dgvSearch.Rows.Count - 1].Cells[1].Value = str;
								this.dgvSearch.Rows[0].Selected = false;
								this.dgvSearch.CurrentCell = this.dgvSearch.Rows[this.dgvSearch.Rows.Count - 1].Cells[1];
								this.dgvSearch.CurrentCell.Selected = true;
								this.dgvCalendar.CurrentCell.Style.BackColor = Color.BlanchedAlmond;
								this.dgvSearch.Rows[0].Selected = false;
							}
							else
							{
								this.dgvSearch.Rows.RemoveAt(index);
								this.dgvCalendar.CurrentCell.Style.BackColor = Color.White;
								this.dgvSearch.ClearSelection();
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

		private void dtpCMonth_ValueChanged(object sender, EventArgs e)
		{
			try
			{
				this.LoadCalendar();
				this.FillSearchGrid();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void dtpCurrentDateReminder_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar != '\r')
			{
				this.intFocus = 0;
			}
			else
			{
				frmScheduler _frmScheduler = this;
				_frmScheduler.intFocus = _frmScheduler.intFocus + 1;
				if (this.intFocus == 2)
				{
					this.intFocus = 0;
					this.btnSaveReminder.Focus();
				}
			}
		}

		private void dtpCYear_ValueChanged(object sender, EventArgs e)
		{
			try
			{
				this.LoadCalendar();
				this.FillSearchGrid();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void dtpReminderMonth_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				this.dgdReminderFill();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void FillSearchGrid()
		{
			DateTime date;
			bool year;
			try
			{
				if (this.dgvSearch.Rows.Count > 0)
				{
					this.dgvSearch.Rows.Clear();
				}
				DataTable dataTable = new DataTable();
				dataTable = this.CalenderSP.CalenderViewAll();
				this.CheckMonth();
				if (dataTable.Rows.Count > 0)
				{
					foreach (DataRow row in dataTable.Rows)
					{
						if (this._month != DateTime.Parse(row.ItemArray[2].ToString()).Date.Month)
						{
							year = true;
						}
						else
						{
							int num = int.Parse(this.dtpCYear.Text);
							date = DateTime.Parse(row.ItemArray[2].ToString());
							date = date.Date;
							year = num != date.Year;
						}
						if (!year)
						{
							this.dgvSearch.Rows.Add();
							this.dgvSearch.Rows[this.dgvSearch.Rows.Count - 1].Cells[0].Value = this.dgvSearch.Rows.Count;
							date = DateTime.Parse(row.ItemArray[2].ToString());
							date = date.Date;
							date = DateTime.Parse(date.ToShortDateString());
							string str = date.ToString("dd-MMM-yyyy");
							this.dgvSearch.Rows[this.dgvSearch.Rows.Count - 1].Cells[1].Value = str;
							this.dgvSearch.Rows[this.dgvSearch.Rows.Count - 1].Cells[2].Value = row.ItemArray[1].ToString();
							this.dgvSearch.Rows[this.dgvSearch.Rows.Count - 1].Cells[3].Value = row.ItemArray[0].ToString();
						}
					}
					DataGridViewCell currentCell = this.dgvSearch.CurrentCell;
					this.dgvSearch.CurrentCell = null;
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void frmSchedule_Load(object sender, EventArgs e)
		{
			this.ClearTabReminder();
			this.ClearTabCalender();
			this.checkCurentMonth();
			if (this.isFromREminderPopUp)
			{
				this.tcSheduler.SelectedTab = this.tabReminder;
			}
		}

		private void InitializeComponent()
		{
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmScheduler));
			DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
			DataGridViewCellStyle window = new DataGridViewCellStyle();
			DataGridViewCellStyle font = new DataGridViewCellStyle();
			this.panel1 = new Panel();
			this.btnClose = new Button();
			this.panel8 = new Panel();
			this.tcSheduler = new TabControl();
			this.tabCalender = new TabPage();
			this.dtpCMonth = new DateTimePicker();
			this.dtpCYear = new DateTimePicker();
			this.dgvSearch = new DataGridView();
			this.Column1 = new DataGridViewTextBoxColumn();
			this.FromDate = new DataGridViewTextBoxColumn();
			this.DayDescription = new DataGridViewTextBoxColumn();
			this.Column2 = new DataGridViewTextBoxColumn();
			this.dgvCalendar = new DataGridView();
			this.Sun = new DataGridViewButtonColumn();
			this.Mon = new DataGridViewButtonColumn();
			this.Tue = new DataGridViewButtonColumn();
			this.Wed = new DataGridViewButtonColumn();
			this.Thu = new DataGridViewButtonColumn();
			this.Fri = new DataGridViewButtonColumn();
			this.Sat = new DataGridViewButtonColumn();
			this.btnSaveCalendar = new Button();
			this.btnClearCalendar = new Button();
			this.tabReminder = new TabPage();
			this.label4 = new Label();
			this.btnSaveReminder = new Button();
			this.btnDeleteReminder = new Button();
			this.btnClearReminder = new Button();
			this.label8 = new Label();
			this.label3 = new Label();
			this.label2 = new Label();
			this.dtpCurrentDate = new DateTimePicker();
			this.dtpReminderDate = new DateTimePicker();
			this.txtDescriptionReminder = new TextBox();
			this.groupBox1 = new GroupBox();
			this.panel9 = new Panel();
			this.dtpReminderMonth = new DateTimePicker();
			this.dgvReminder = new DataGridView();
			this.SlNof = new DataGridViewTextBoxColumn();
			this.datef = new DataGridViewTextBoxColumn();
			this.Column3 = new DataGridViewTextBoxColumn();
			this.Column4 = new DataGridViewTextBoxColumn();
			this.Column5 = new DataGridViewTextBoxColumn();
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
			this.dataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn7 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn8 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn9 = new DataGridViewTextBoxColumn();
			this.panel1.SuspendLayout();
			this.panel8.SuspendLayout();
			this.tcSheduler.SuspendLayout();
			this.tabCalender.SuspendLayout();
			((ISupportInitialize)this.dgvSearch).BeginInit();
			((ISupportInitialize)this.dgvCalendar).BeginInit();
			this.tabReminder.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.panel9.SuspendLayout();
			((ISupportInitialize)this.dgvReminder).BeginInit();
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
			this.panel1.Size = new System.Drawing.Size(711, 442);
			this.panel1.TabIndex = 5;
			this.btnClose.BackColor = Color.FromArgb(255, 209, 150);
			this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnClose.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 1);
			this.btnClose.FlatStyle = FlatStyle.Flat;
			this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.btnClose.Location = new Point(616, 389);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(75, 23);
			this.btnClose.TabIndex = 5;
			this.btnClose.Text = "&Close";
			this.btnClose.UseVisualStyleBackColor = false;
			this.btnClose.Click += new EventHandler(this.btnClose_Click);
			this.panel8.BackgroundImage = (Image)componentResourceManager.GetObject("panel8.BackgroundImage");
			this.panel8.BackgroundImageLayout = ImageLayout.Stretch;
			this.panel8.Controls.Add(this.tcSheduler);
			this.panel8.Dock = DockStyle.Top;
			this.panel8.Location = new Point(1, 34);
			this.panel8.Name = "panel8";
			this.panel8.Padding = new System.Windows.Forms.Padding(5);
			this.panel8.Size = new System.Drawing.Size(709, 349);
			this.panel8.TabIndex = 0;
			this.tcSheduler.Controls.Add(this.tabCalender);
			this.tcSheduler.Controls.Add(this.tabReminder);
			this.tcSheduler.Dock = DockStyle.Fill;
			this.tcSheduler.Location = new Point(5, 5);
			this.tcSheduler.Name = "tcSheduler";
			this.tcSheduler.SelectedIndex = 0;
			this.tcSheduler.Size = new System.Drawing.Size(699, 339);
			this.tcSheduler.TabIndex = 0;
			this.tcSheduler.Click += new EventHandler(this.tcSheduler_Click);
			this.tabCalender.BackColor = Color.White;
			this.tabCalender.Controls.Add(this.dtpCMonth);
			this.tabCalender.Controls.Add(this.dtpCYear);
			this.tabCalender.Controls.Add(this.dgvSearch);
			this.tabCalender.Controls.Add(this.dgvCalendar);
			this.tabCalender.Controls.Add(this.btnSaveCalendar);
			this.tabCalender.Controls.Add(this.btnClearCalendar);
			this.tabCalender.Location = new Point(4, 22);
			this.tabCalender.Name = "tabCalender";
			this.tabCalender.Padding = new System.Windows.Forms.Padding(10);
			this.tabCalender.Size = new System.Drawing.Size(691, 313);
			this.tabCalender.TabIndex = 0;
			this.tabCalender.Text = "Calender";
			this.tabCalender.UseVisualStyleBackColor = true;
			this.dtpCMonth.CustomFormat = "MMM";
			this.dtpCMonth.Format = DateTimePickerFormat.Custom;
			this.dtpCMonth.Location = new Point(33, 13);
			this.dtpCMonth.Name = "dtpCMonth";
			this.dtpCMonth.ShowUpDown = true;
			this.dtpCMonth.Size = new System.Drawing.Size(82, 20);
			this.dtpCMonth.TabIndex = 0;
			this.dtpCMonth.ValueChanged += new EventHandler(this.dtpCMonth_ValueChanged);
			this.dtpCYear.CustomFormat = "yyyy";
			this.dtpCYear.Format = DateTimePickerFormat.Custom;
			this.dtpCYear.Location = new Point(143, 13);
			this.dtpCYear.Name = "dtpCYear";
			this.dtpCYear.ShowUpDown = true;
			this.dtpCYear.Size = new System.Drawing.Size(80, 20);
			this.dtpCYear.TabIndex = 1;
			this.dtpCYear.ValueChanged += new EventHandler(this.dtpCYear_ValueChanged);
			this.dgvSearch.AllowUserToAddRows = false;
			this.dgvSearch.AllowUserToDeleteRows = false;
			this.dgvSearch.AllowUserToResizeColumns = false;
			this.dgvSearch.AllowUserToResizeRows = false;
			this.dgvSearch.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvSearch.BackgroundColor = Color.White;
			dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle.BackColor = Color.White;
			dataGridViewCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			dataGridViewCellStyle.ForeColor = Color.Black;
			dataGridViewCellStyle.SelectionBackColor = Color.DodgerBlue;
			dataGridViewCellStyle.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle.WrapMode = DataGridViewTriState.True;
			this.dgvSearch.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
			this.dgvSearch.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			DataGridViewColumnCollection columns = this.dgvSearch.Columns;
			DataGridViewColumn[] column1 = new DataGridViewColumn[] { this.Column1, this.FromDate, this.DayDescription, this.Column2 };
			columns.AddRange(column1);
			window.Alignment = DataGridViewContentAlignment.MiddleLeft;
			window.BackColor = SystemColors.Window;
			window.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			window.ForeColor = SystemColors.ControlText;
			window.SelectionBackColor = Color.CornflowerBlue;
			window.SelectionForeColor = Color.White;
			window.WrapMode = DataGridViewTriState.False;
			this.dgvSearch.DefaultCellStyle = window;
			this.dgvSearch.GridColor = Color.WhiteSmoke;
			this.dgvSearch.Location = new Point(314, 39);
			this.dgvSearch.MultiSelect = false;
			this.dgvSearch.Name = "dgvSearch";
			this.dgvSearch.RowHeadersVisible = false;
			this.dgvSearch.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			this.dgvSearch.SelectionMode = DataGridViewSelectionMode.CellSelect;
			this.dgvSearch.Size = new System.Drawing.Size(367, 223);
			this.dgvSearch.TabIndex = 92;
			this.dgvSearch.CellClick += new DataGridViewCellEventHandler(this.dgdSearch_CellClick);
			this.dgvSearch.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(this.dgdSearch_DataBindingComplete);
			this.dgvSearch.KeyUp += new KeyEventHandler(this.dgdSearch_KeyUp);
			this.Column1.HeaderText = "ID";
			this.Column1.Name = "Column1";
			this.Column1.Visible = false;
			this.FromDate.HeaderText = "Date";
			this.FromDate.Name = "FromDate";
			this.FromDate.ReadOnly = true;
			this.DayDescription.HeaderText = "Day Description";
			this.DayDescription.Name = "DayDescription";
			this.Column2.HeaderText = "ID1";
			this.Column2.Name = "Column2";
			this.Column2.Visible = false;
			this.dgvCalendar.AllowUserToAddRows = false;
			this.dgvCalendar.AllowUserToDeleteRows = false;
			this.dgvCalendar.AllowUserToResizeColumns = false;
			this.dgvCalendar.AllowUserToResizeRows = false;
			this.dgvCalendar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvCalendar.BackgroundColor = Color.White;
			this.dgvCalendar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvCalendar.ColumnHeadersVisible = false;
			DataGridViewColumnCollection dataGridViewColumnCollections = this.dgvCalendar.Columns;
			column1 = new DataGridViewColumn[] { this.Sun, this.Mon, this.Tue, this.Wed, this.Thu, this.Fri, this.Sat };
			dataGridViewColumnCollections.AddRange(column1);
			font.Alignment = DataGridViewContentAlignment.MiddleLeft;
			font.BackColor = SystemColors.Window;
			font.Font = new System.Drawing.Font("Verdana", 6.4f);
			font.ForeColor = Color.Black;
			font.SelectionBackColor = Color.CornflowerBlue;
			font.SelectionForeColor = Color.Black;
			font.WrapMode = DataGridViewTriState.False;
			this.dgvCalendar.DefaultCellStyle = font;
			this.dgvCalendar.Location = new Point(13, 39);
			this.dgvCalendar.MultiSelect = false;
			this.dgvCalendar.Name = "dgvCalendar";
			this.dgvCalendar.ReadOnly = true;
			this.dgvCalendar.RowHeadersVisible = false;
			this.dgvCalendar.Size = new System.Drawing.Size(270, 160);
			this.dgvCalendar.TabIndex = 2;
			this.dgvCalendar.CellClick += new DataGridViewCellEventHandler(this.dgvCalendar_CellClick);
			this.Sun.FlatStyle = FlatStyle.Flat;
			this.Sun.HeaderText = "Sun";
			this.Sun.Name = "Sun";
			this.Sun.ReadOnly = true;
			this.Sun.Resizable = DataGridViewTriState.False;
			this.Mon.FlatStyle = FlatStyle.Flat;
			this.Mon.HeaderText = "Mon";
			this.Mon.Name = "Mon";
			this.Mon.ReadOnly = true;
			this.Mon.Resizable = DataGridViewTriState.False;
			this.Tue.FlatStyle = FlatStyle.Flat;
			this.Tue.HeaderText = "Tue";
			this.Tue.Name = "Tue";
			this.Tue.ReadOnly = true;
			this.Tue.Resizable = DataGridViewTriState.False;
			this.Wed.FlatStyle = FlatStyle.Flat;
			this.Wed.HeaderText = "Wed";
			this.Wed.Name = "Wed";
			this.Wed.ReadOnly = true;
			this.Wed.Resizable = DataGridViewTriState.False;
			this.Wed.SortMode = DataGridViewColumnSortMode.Automatic;
			this.Thu.FlatStyle = FlatStyle.Flat;
			this.Thu.HeaderText = "Thu";
			this.Thu.Name = "Thu";
			this.Thu.ReadOnly = true;
			this.Thu.Resizable = DataGridViewTriState.False;
			this.Thu.SortMode = DataGridViewColumnSortMode.Automatic;
			this.Fri.FlatStyle = FlatStyle.Flat;
			this.Fri.HeaderText = "Fri";
			this.Fri.Name = "Fri";
			this.Fri.ReadOnly = true;
			this.Fri.Resizable = DataGridViewTriState.False;
			this.Fri.SortMode = DataGridViewColumnSortMode.Automatic;
			this.Sat.FlatStyle = FlatStyle.Flat;
			this.Sat.HeaderText = "Sat";
			this.Sat.Name = "Sat";
			this.Sat.ReadOnly = true;
			this.Sat.Resizable = DataGridViewTriState.False;
			this.Sat.SortMode = DataGridViewColumnSortMode.Automatic;
			this.btnSaveCalendar.BackColor = Color.FromArgb(255, 209, 150);
			this.btnSaveCalendar.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 1);
			this.btnSaveCalendar.FlatStyle = FlatStyle.Flat;
			this.btnSaveCalendar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.btnSaveCalendar.Location = new Point(452, 277);
			this.btnSaveCalendar.Name = "btnSaveCalendar";
			this.btnSaveCalendar.Size = new System.Drawing.Size(75, 23);
			this.btnSaveCalendar.TabIndex = 21;
			this.btnSaveCalendar.Text = "&Save";
			this.btnSaveCalendar.UseVisualStyleBackColor = false;
			this.btnSaveCalendar.Click += new EventHandler(this.btnSaveCalendar_Click);
			this.btnClearCalendar.BackColor = Color.FromArgb(255, 209, 150);
			this.btnClearCalendar.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 1);
			this.btnClearCalendar.FlatStyle = FlatStyle.Flat;
			this.btnClearCalendar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.btnClearCalendar.Location = new Point(545, 277);
			this.btnClearCalendar.Name = "btnClearCalendar";
			this.btnClearCalendar.Size = new System.Drawing.Size(75, 23);
			this.btnClearCalendar.TabIndex = 19;
			this.btnClearCalendar.Text = "&Reset";
			this.btnClearCalendar.UseVisualStyleBackColor = false;
			this.btnClearCalendar.Click += new EventHandler(this.btnClearCalendar_Click);
			this.tabReminder.BackColor = Color.White;
			this.tabReminder.Controls.Add(this.label4);
			this.tabReminder.Controls.Add(this.btnSaveReminder);
			this.tabReminder.Controls.Add(this.btnDeleteReminder);
			this.tabReminder.Controls.Add(this.btnClearReminder);
			this.tabReminder.Controls.Add(this.label8);
			this.tabReminder.Controls.Add(this.label3);
			this.tabReminder.Controls.Add(this.label2);
			this.tabReminder.Controls.Add(this.dtpCurrentDate);
			this.tabReminder.Controls.Add(this.dtpReminderDate);
			this.tabReminder.Controls.Add(this.txtDescriptionReminder);
			this.tabReminder.Controls.Add(this.groupBox1);
			this.tabReminder.Location = new Point(4, 22);
			this.tabReminder.Name = "tabReminder";
			this.tabReminder.Padding = new System.Windows.Forms.Padding(3);
			this.tabReminder.Size = new System.Drawing.Size(691, 313);
			this.tabReminder.TabIndex = 1;
			this.tabReminder.Text = "Reminder";
			this.tabReminder.UseVisualStyleBackColor = true;
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label4.ForeColor = Color.Red;
			this.label4.Location = new Point(370, 70);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(12, 13);
			this.label4.TabIndex = 49;
			this.label4.Text = "*";
			this.btnSaveReminder.BackColor = Color.FromArgb(255, 209, 150);
			this.btnSaveReminder.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 1);
			this.btnSaveReminder.FlatStyle = FlatStyle.Flat;
			this.btnSaveReminder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.btnSaveReminder.Location = new Point(444, 277);
			this.btnSaveReminder.Name = "btnSaveReminder";
			this.btnSaveReminder.Size = new System.Drawing.Size(75, 23);
			this.btnSaveReminder.TabIndex = 3;
			this.btnSaveReminder.Text = "&Save";
			this.btnSaveReminder.UseVisualStyleBackColor = false;
			this.btnSaveReminder.Click += new EventHandler(this.btnSaveReminder_Click);
			this.btnDeleteReminder.BackColor = Color.FromArgb(255, 209, 150);
			this.btnDeleteReminder.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 1);
			this.btnDeleteReminder.FlatStyle = FlatStyle.Flat;
			this.btnDeleteReminder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.btnDeleteReminder.Location = new Point(525, 277);
			this.btnDeleteReminder.Name = "btnDeleteReminder";
			this.btnDeleteReminder.Size = new System.Drawing.Size(75, 23);
			this.btnDeleteReminder.TabIndex = 4;
			this.btnDeleteReminder.Text = "&Delete";
			this.btnDeleteReminder.UseVisualStyleBackColor = false;
			this.btnDeleteReminder.Click += new EventHandler(this.btnDeleteReminder_Click);
			this.btnClearReminder.BackColor = Color.FromArgb(255, 209, 150);
			this.btnClearReminder.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 1);
			this.btnClearReminder.FlatStyle = FlatStyle.Flat;
			this.btnClearReminder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.btnClearReminder.Location = new Point(606, 277);
			this.btnClearReminder.Name = "btnClearReminder";
			this.btnClearReminder.Size = new System.Drawing.Size(75, 23);
			this.btnClearReminder.TabIndex = 5;
			this.btnClearReminder.Text = "C&lear";
			this.btnClearReminder.UseVisualStyleBackColor = false;
			this.btnClearReminder.Click += new EventHandler(this.btnClearReminder_Click);
			this.label8.AutoSize = true;
			this.label8.Location = new Point(25, 70);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(63, 13);
			this.label8.TabIndex = 48;
			this.label8.Text = "Description:";
			this.label3.AutoSize = true;
			this.label3.Location = new Point(25, 46);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(81, 13);
			this.label3.TabIndex = 47;
			this.label3.Text = "Reminder Date:";
			this.label2.AutoSize = true;
			this.label2.Location = new Point(25, 17);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(70, 13);
			this.label2.TabIndex = 46;
			this.label2.Text = "Current Date:";
			this.dtpCurrentDate.CustomFormat = "dd-MMM-yyyy";
			this.dtpCurrentDate.Format = DateTimePickerFormat.Custom;
			this.dtpCurrentDate.Location = new Point(132, 13);
			this.dtpCurrentDate.Name = "dtpCurrentDate";
			this.dtpCurrentDate.Size = new System.Drawing.Size(132, 20);
			this.dtpCurrentDate.TabIndex = 0;
			this.dtpCurrentDate.KeyPress += new KeyPressEventHandler(this.dtpCurrentDateReminder_KeyPress);
			this.dtpReminderDate.CustomFormat = "dd-MMM-yyyy";
			this.dtpReminderDate.Format = DateTimePickerFormat.Custom;
			this.dtpReminderDate.Location = new Point(132, 39);
			this.dtpReminderDate.Name = "dtpReminderDate";
			this.dtpReminderDate.Size = new System.Drawing.Size(132, 20);
			this.dtpReminderDate.TabIndex = 1;
			this.dtpReminderDate.KeyPress += new KeyPressEventHandler(this.dtpCurrentDateReminder_KeyPress);
			this.txtDescriptionReminder.Location = new Point(132, 67);
			this.txtDescriptionReminder.Multiline = true;
			this.txtDescriptionReminder.Name = "txtDescriptionReminder";
			this.txtDescriptionReminder.Size = new System.Drawing.Size(232, 55);
			this.txtDescriptionReminder.TabIndex = 2;
			this.txtDescriptionReminder.Enter += new EventHandler(this.txtDescriptionReminder_Enter);
			this.txtDescriptionReminder.KeyPress += new KeyPressEventHandler(this.dtpCurrentDateReminder_KeyPress);
			this.groupBox1.BackColor = Color.White;
			this.groupBox1.Controls.Add(this.panel9);
			this.groupBox1.Location = new Point(394, 6);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(5);
			this.groupBox1.Size = new System.Drawing.Size(287, 259);
			this.groupBox1.TabIndex = 8;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Register";
			this.panel9.Controls.Add(this.dtpReminderMonth);
			this.panel9.Controls.Add(this.dgvReminder);
			this.panel9.Dock = DockStyle.Fill;
			this.panel9.Location = new Point(5, 18);
			this.panel9.Name = "panel9";
			this.panel9.Size = new System.Drawing.Size(277, 236);
			this.panel9.TabIndex = 0;
			this.dtpReminderMonth.CustomFormat = "dd-MMM-yyyy";
			this.dtpReminderMonth.Format = DateTimePickerFormat.Custom;
			this.dtpReminderMonth.Location = new Point(45, 15);
			this.dtpReminderMonth.Name = "dtpReminderMonth";
			this.dtpReminderMonth.Size = new System.Drawing.Size(135, 20);
			this.dtpReminderMonth.TabIndex = 25;
			this.dtpReminderMonth.ValueChanged += new EventHandler(this.dtpReminderMonth_SelectedIndexChanged);
			this.dgvReminder.AllowUserToAddRows = false;
			this.dgvReminder.AllowUserToDeleteRows = false;
			this.dgvReminder.AllowUserToOrderColumns = true;
			this.dgvReminder.AllowUserToResizeColumns = false;
			this.dgvReminder.AllowUserToResizeRows = false;
			this.dgvReminder.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvReminder.BackgroundColor = Color.White;
			this.dgvReminder.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			DataGridViewColumnCollection columns1 = this.dgvReminder.Columns;
			column1 = new DataGridViewColumn[] { this.SlNof, this.datef, this.Column3, this.Column4, this.Column5 };
			columns1.AddRange(column1);
			this.dgvReminder.GridColor = Color.WhiteSmoke;
			this.dgvReminder.Location = new Point(12, 46);
			this.dgvReminder.MultiSelect = false;
			this.dgvReminder.Name = "dgvReminder";
			this.dgvReminder.ReadOnly = true;
			this.dgvReminder.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
			this.dgvReminder.RowHeadersVisible = false;
			this.dgvReminder.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			this.dgvReminder.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			this.dgvReminder.Size = new System.Drawing.Size(255, 179);
			this.dgvReminder.TabIndex = 1;
			this.dgvReminder.TabStop = false;
			this.dgvReminder.KeyUp += new KeyEventHandler(this.dgdReminder_KeyUp);
			this.dgvReminder.Click += new EventHandler(this.dgdReminder_Click);
			this.SlNof.HeaderText = "SI No";
			this.SlNof.Name = "SlNof";
			this.SlNof.ReadOnly = true;
			this.SlNof.Visible = false;
			this.datef.HeaderText = "Description";
			this.datef.Name = "datef";
			this.datef.ReadOnly = true;
			this.Column3.HeaderText = "Si Db";
			this.Column3.Name = "Column3";
			this.Column3.ReadOnly = true;
			this.Column3.Visible = false;
			this.Column4.HeaderText = "CurentDate";
			this.Column4.Name = "Column4";
			this.Column4.ReadOnly = true;
			this.Column4.Visible = false;
			this.Column5.HeaderText = "ReminderDate";
			this.Column5.Name = "Column5";
			this.Column5.ReadOnly = true;
			this.Column5.Visible = false;
			this.panel6.BackgroundImage = (Image)componentResourceManager.GetObject("panel6.BackgroundImage");
			this.panel6.Controls.Add(this.label1);
			this.panel6.Controls.Add(this.panel7);
			this.panel6.Dock = DockStyle.Top;
			this.panel6.Location = new Point(1, 1);
			this.panel6.Name = "panel6";
			this.panel6.Size = new System.Drawing.Size(709, 33);
			this.panel6.TabIndex = 3;
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label1.Location = new Point(11, 7);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(65, 15);
			this.label1.TabIndex = 4;
			this.label1.Text = "Sheduler";
			this.panel7.BackColor = Color.FromArgb(136, 136, 136);
			this.panel7.Dock = DockStyle.Bottom;
			this.panel7.Location = new Point(0, 32);
			this.panel7.Name = "panel7";
			this.panel7.Size = new System.Drawing.Size(709, 1);
			this.panel7.TabIndex = 3;
			this.panel5.BackColor = Color.FromArgb(136, 136, 136);
			this.panel5.Dock = DockStyle.Bottom;
			this.panel5.Location = new Point(1, 441);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(709, 1);
			this.panel5.TabIndex = 2;
			this.panel4.BackColor = Color.FromArgb(136, 136, 136);
			this.panel4.Dock = DockStyle.Top;
			this.panel4.Location = new Point(1, 0);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(709, 1);
			this.panel4.TabIndex = 1;
			this.panel3.BackColor = Color.FromArgb(136, 136, 136);
			this.panel3.Dock = DockStyle.Right;
			this.panel3.Location = new Point(710, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(1, 442);
			this.panel3.TabIndex = 1;
			this.panel2.BackColor = Color.FromArgb(136, 136, 136);
			this.panel2.Dock = DockStyle.Left;
			this.panel2.Location = new Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(1, 442);
			this.panel2.TabIndex = 0;
			this.dataGridViewTextBoxColumn1.HeaderText = "ID";
			this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn1.Visible = false;
			this.dataGridViewTextBoxColumn2.HeaderText = "Date";
			this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
			this.dataGridViewTextBoxColumn2.ReadOnly = true;
			this.dataGridViewTextBoxColumn2.Width = 182;
			this.dataGridViewTextBoxColumn3.HeaderText = "Day Description";
			this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
			this.dataGridViewTextBoxColumn3.Width = 182;
			this.dataGridViewTextBoxColumn4.HeaderText = "ID1";
			this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
			this.dataGridViewTextBoxColumn4.Visible = false;
			this.dataGridViewTextBoxColumn5.HeaderText = "SI No";
			this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
			this.dataGridViewTextBoxColumn5.ReadOnly = true;
			this.dataGridViewTextBoxColumn5.Visible = false;
			this.dataGridViewTextBoxColumn5.Width = 126;
			this.dataGridViewTextBoxColumn6.HeaderText = "Description";
			this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
			this.dataGridViewTextBoxColumn6.ReadOnly = true;
			this.dataGridViewTextBoxColumn6.Width = 126;
			this.dataGridViewTextBoxColumn7.HeaderText = "Si Db";
			this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
			this.dataGridViewTextBoxColumn7.ReadOnly = true;
			this.dataGridViewTextBoxColumn7.Visible = false;
			this.dataGridViewTextBoxColumn8.HeaderText = "CurentDate";
			this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
			this.dataGridViewTextBoxColumn8.ReadOnly = true;
			this.dataGridViewTextBoxColumn8.Visible = false;
			this.dataGridViewTextBoxColumn8.Width = 84;
			this.dataGridViewTextBoxColumn9.HeaderText = "ReminderDate";
			this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
			this.dataGridViewTextBoxColumn9.ReadOnly = true;
			this.dataGridViewTextBoxColumn9.Visible = false;
			this.dataGridViewTextBoxColumn9.Width = 84;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.BackColor = Color.White;
			base.CancelButton = this.btnClose;
			base.ClientSize = new System.Drawing.Size(725, 456);
			base.Controls.Add(this.panel1);
			base.Icon = (System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.Name = "frmScheduler";
			base.Padding = new System.Windows.Forms.Padding(7);
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "Scheduler";
			base.Load += new EventHandler(this.frmSchedule_Load);
			this.panel1.ResumeLayout(false);
			this.panel8.ResumeLayout(false);
			this.tcSheduler.ResumeLayout(false);
			this.tabCalender.ResumeLayout(false);
			((ISupportInitialize)this.dgvSearch).EndInit();
			((ISupportInitialize)this.dgvCalendar).EndInit();
			this.tabReminder.ResumeLayout(false);
			this.tabReminder.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.panel9.ResumeLayout(false);
			((ISupportInitialize)this.dgvReminder).EndInit();
			this.panel6.ResumeLayout(false);
			this.panel6.PerformLayout();
			base.ResumeLayout(false);
		}

		private void LoadCalendar()
		{
			int i;
			try
			{
				this.dgvCalendar.Rows.Clear();
				this.dgvCalendar.Rows.Add(7);
				DataGridViewTextBoxCell dataGridViewTextBoxCell = new DataGridViewTextBoxCell();
				DataGridViewTextBoxCell dataGridViewTextBoxCell1 = new DataGridViewTextBoxCell();
				DataGridViewTextBoxCell dataGridViewTextBoxCell2 = new DataGridViewTextBoxCell();
				DataGridViewTextBoxCell dataGridViewTextBoxCell3 = new DataGridViewTextBoxCell();
				DataGridViewTextBoxCell dataGridViewTextBoxCell4 = new DataGridViewTextBoxCell();
				DataGridViewTextBoxCell dataGridViewTextBoxCell5 = new DataGridViewTextBoxCell();
				DataGridViewTextBoxCell dataGridViewTextBoxCell6 = new DataGridViewTextBoxCell();
				this.dgvCalendar[0, 0] = dataGridViewTextBoxCell;
				this.dgvCalendar[1, 0] = dataGridViewTextBoxCell1;
				this.dgvCalendar[2, 0] = dataGridViewTextBoxCell2;
				this.dgvCalendar[3, 0] = dataGridViewTextBoxCell3;
				this.dgvCalendar[4, 0] = dataGridViewTextBoxCell4;
				this.dgvCalendar[5, 0] = dataGridViewTextBoxCell5;
				this.dgvCalendar[6, 0] = dataGridViewTextBoxCell6;
				this.dgvCalendar[0, 0].Value = "Sun";
				this.dgvCalendar[1, 0].Value = "Mon";
				this.dgvCalendar[2, 0].Value = "Tue";
				this.dgvCalendar[3, 0].Value = "Wed";
				this.dgvCalendar[4, 0].Value = "Thu";
				this.dgvCalendar[5, 0].Value = "Fri";
				this.dgvCalendar[6, 0].Value = "Sat";
				this.dgvCalendar.Rows[0].DefaultCellStyle.BackColor = Color.FromArgb(188, 222, 252);
				int num = 0;
				int num1 = 0;
				int num2 = 1;
				int year = this.dtpCYear.Value.Year;
				DateTime value = this.dtpCMonth.Value;
				DateTime dateTime = new DateTime(year, value.Month, 1);
				string str = dateTime.DayOfWeek.ToString();
				if (str != null)
				{
					switch (str)
					{
						case "Sunday":
						{
							num1 = 0;
							break;
						}
						case "Monday":
						{
							num1 = 1;
							break;
						}
						case "Tuesday":
						{
							num1 = 2;
							break;
						}
						case "Wednesday":
						{
							num1 = 3;
							break;
						}
						case "Thursday":
						{
							num1 = 4;
							break;
						}
						case "Friday":
						{
							num1 = 5;
							break;
						}
						case "Saturday":
						{
							num1 = 6;
							break;
						}
						default:
						{
							goto Label1;
						}
					}
				}
				else
				{
				}
			Label1:
				int year1 = this.dtpCYear.Value.Year;
				value = this.dtpCMonth.Value;
				num = DateTime.DaysInMonth(year1, value.Month);
				for (i = 1; i <= num; i++)
				{
					if (num1 > 6)
					{
						num1 = 0;
						num2++;
					}
					this.dgvCalendar[num1, num2].Value = i;
					num1++;
				}
				this.dgvCalendar.ClearSelection();
				MedicalShop.CalenderSP calenderSP = this.CalenderSP;
				int month = this.dtpCMonth.Value.Month;
				value = this.dtpCYear.Value;
				DataTable dataTable = calenderSP.CalenderInMonthAndYear(month, value.Year);
				if (dataTable.Rows.Count > 0)
				{
					for (i = 0; i <= dataTable.Rows.Count - 1; i++)
					{
						value = DateTime.Parse(dataTable.Rows[i]["Date"].ToString());
						string str1 = value.Day.ToString();
						foreach (DataGridViewRow row in (IEnumerable)this.dgvCalendar.Rows)
						{
							if (row.Index != 0)
							{
								for (int j = 0; j <= this.dgvCalendar.ColumnCount - 1; j++)
								{
									if ((row.Cells[j].Value == null ? false : row.Cells[j].Value.ToString().Trim() != ""))
									{
										if (row.Cells[j].Value.ToString() == str1)
										{
											row.Cells[j].Style.BackColor = Color.BlanchedAlmond;
										}
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

		protected override bool ProcessDialogKey(Keys keyData)
		{
			bool flag;
			if (keyData != Keys.Tab)
			{
				base.ProcessDialogKey(keyData);
				flag = false;
			}
			else if (!this.txtDescriptionReminder.Focused)
			{
				base.ProcessDialogKey(keyData);
				flag = true;
			}
			else
			{
				this.btnSaveReminder.Focus();
				flag = false;
			}
			return flag;
		}

		private void SaveCalendar()
		{
			try
			{
				this.CheckMonth();
				this.CalenderSP.CalenderDeleteByMonth(this._month.ToString());
				if (this.dgvSearch.Rows.Count > 0)
				{
					foreach (DataGridViewRow row in (IEnumerable)this.dgvSearch.Rows)
					{
						this.CalenderInfo.Date = DateTime.Parse(row.Cells[1].Value.ToString());
						if (row.Cells[2].Value == null)
						{
							this.CalenderInfo.Description = "";
						}
						else
						{
							this.CalenderInfo.Description = row.Cells[2].Value.ToString();
						}
						this.CalenderSP.CalenderAdd(this.CalenderInfo);
					}
				}
				MessageBox.Show("Saved successfully", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				this.ClearTabCalender();
				this.LoadCalendar();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void SaveReminder()
		{
			try
			{
				this.ReminderInfo.CurrentDate = DateTime.Parse(this.dtpCurrentDate.Text);
				this.ReminderInfo.ReminderDate = DateTime.Parse(this.dtpReminderDate.Text);
				this.ReminderInfo.Description = this.txtDescriptionReminder.Text.Trim();
				this.txtDescriptionReminder.Text = this.txtDescriptionReminder.Text.Trim();
				if (!(this.txtDescriptionReminder.Text == "" ? true : !(DateTime.Parse(this.dtpCurrentDate.Text) <= DateTime.Parse(this.dtpReminderDate.Text))))
				{
					if (this.btnSaveReminder.Text == "&Save")
					{
						this.ReminderSP.ReminderAdd(this.ReminderInfo);
						this.ClearTabReminder();
						MessageBox.Show("Saved successfully", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					}
					else if (this.btnSaveReminder.Text == "&Update")
					{
						this.ReminderInfo.ReminderId = this._reminderId;
						this.ReminderSP.ReminderEdit(this.ReminderInfo);
						this.ClearTabReminder();
						MessageBox.Show("Updated successfully", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					}
				}
				else if (DateTime.Parse(this.dtpCurrentDate.Text) > DateTime.Parse(this.dtpReminderDate.Text))
				{
					MessageBox.Show("Current date cannot be greater than reminder date", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					this.dtpReminderDate.Select();
				}
				else if (this.txtDescriptionReminder.Text == "")
				{
					MessageBox.Show("Enter description", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					this.txtDescriptionReminder.Select();
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void tcSheduler_Click(object sender, EventArgs e)
		{
			try
			{
				if (this.tcSheduler.SelectedTab.Text == "Calender")
				{
					this.ClearTabCalender();
					this.checkCurentMonth();
				}
				else if (this.tcSheduler.SelectedTab.Text == "Reminder")
				{
					this.ClearTabReminder();
					this.checkCurentMonth();
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void txtDescriptionReminder_Enter(object sender, EventArgs e)
		{
			try
			{
				this.txtDescriptionReminder.Text = this.txtDescriptionReminder.Text.Trim();
				if (!(this.txtDescriptionReminder.Text == ""))
				{
					this.txtDescriptionReminder.SelectionStart = this.txtDescriptionReminder.Text.Length;
					this.txtDescriptionReminder.Focus();
				}
				else
				{
					this.txtDescriptionReminder.SelectionStart = 0;
					this.txtDescriptionReminder.Focus();
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