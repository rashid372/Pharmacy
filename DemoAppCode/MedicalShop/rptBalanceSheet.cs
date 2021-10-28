using MedicalShop.Properties;
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
	public class rptBalanceSheet : Form
	{
		private MedicalShop.DoctorSP DoctorSP = new MedicalShop.DoctorSP();

		private MedicalShop.CompanyInfo CompanyInfo = new MedicalShop.CompanyInfo();

		private MedicalShop.CompanySP CompanySP = new MedicalShop.CompanySP();

		private MedicalShop.frmCompanyProgress frmCompanyProgress = new MedicalShop.frmCompanyProgress();

		private string strFormat = "";

		private string strHeading = "";

		private int _pageNo = 0;

		private int _page = 0;

		private IContainer components = null;

		private Label lblPlace;

		private Label lblCompanyName;

		private Label label5;

		private PictureBox btnClose;

		private Button btnClear;

		private DataGridView dgvReport;

		private Label lblPhone;

		private ToolTip toolTip1;

		private BackgroundWorker bwrk1;

		private Panel panel1;

		private DataGridViewTextBoxColumn Column1;

		private DataGridViewTextBoxColumn Column2;

		private DataGridViewTextBoxColumn Column3;

		private DataGridViewTextBoxColumn Column4;

		private DataGridViewTextBoxColumn Column5;

		private DataGridViewTextBoxColumn Column6;

		private DataGridViewTextBoxColumn Column7;

		private Panel panel2;

		private Panel panel3;

		private Panel panel4;

		private Panel panel5;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;

		private GroupBox groupBox1;

		private DateTimePicker dtpTo;

		private DateTimePicker dtpFrom;

		private Label label2;

		private Label label1;

		private Label label3;

		private Label label4;

		private RadioButton rbtnContensed;

		private RadioButton rbtnDetailed;

		private GroupBox groupBox4;

		private Button btnExport;

		private ComboBox cmbExportType;

		public rptBalanceSheet()
		{
			this.InitializeComponent();
		}

		private void btnClear_Click(object sender, EventArgs e)
		{
			this.rptLedgerBalance_Load(sender, e);
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		private void btnExport_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Thank you for using Pharmacy.To gain access please buy full version", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}

		private void bwrk1_DoWork(object sender, DoWorkEventArgs e)
		{
			try
			{
				ExportToExcel exportToExcel = new ExportToExcel();
				if (this.strFormat == "Excel")
				{
					exportToExcel.ExportExcel(this.dgvReport, this.strHeading, 0, 1, "Excel");
				}
				else if (this.strFormat == "Html")
				{
					exportToExcel.ExportExcel(this.dgvReport, this.strHeading, 0, 1, "Html");
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void bwrk1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			try
			{
				if ((this.frmCompanyProgress == null ? false : this.frmCompanyProgress.Visible))
				{
					this.frmCompanyProgress.Close();
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

		private void dtpFrom_KeyDown(object sender, KeyEventArgs e)
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

		private void dtpFrom_ValueChanged(object sender, EventArgs e)
		{
			try
			{
				this.FillGrid();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void dtpTo_KeyDown(object sender, KeyEventArgs e)
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

		public void FillGrid()
		{
			DataRow row = null;
			int str;
			decimal num;
			DataSet dataSet;
			decimal num1;
			decimal num2;
			decimal num3;
			decimal num4;
			decimal num5;
			decimal num6;
			decimal num7;
			decimal num8;
			decimal num9;
			decimal num10;
			decimal num11;
			decimal num12;
			decimal num13;
			decimal num14;
			decimal num15;
			decimal num16;
			System.Drawing.Font font;
			decimal num17;
			decimal num18;
			DataGridViewRow dataGridViewRow = null;
			decimal num19;
			decimal num20;
			decimal num21;
			decimal num22;
			this.dgvReport.Rows.Clear();
			this.LoadGridColumns();
			AccountLedgerSP accountLedgerSP = new AccountLedgerSP();
			DataSet dataSet1 = new DataSet();
			DataTable dataTable = new DataTable();
			if (!this.rbtnContensed.Checked)
			{
				dataSet1 = accountLedgerSP.DetailedBalanceSheet(DateTime.Parse(this.dtpFrom.Text), DateTime.Parse(this.dtpTo.Text));
				dataTable = dataSet1.Tables[0];
				foreach (DataRow row1 in dataTable.Rows)
				{
					this.dgvReport.Rows.Add();
					this.dgvReport.Rows[this.dgvReport.Rows.Count - 1].Cells[0].Value = row1.ItemArray[0].ToString();
					this.dgvReport.Rows[this.dgvReport.Rows.Count - 1].Cells[1].Value = row1.ItemArray[1].ToString();
				}
				dataTable = new DataTable();
				dataTable = dataSet1.Tables[1];
				str = 0;
				foreach (DataRow dataRow in dataTable.Rows)
				{
					if (str >= this.dgvReport.Rows.Count)
					{
						this.dgvReport.Rows.Add();
						this.dgvReport.Rows[this.dgvReport.Rows.Count - 1].Cells[2].Value = dataRow.ItemArray[0].ToString();
						this.dgvReport.Rows[this.dgvReport.Rows.Count - 1].Cells[3].Value = dataRow.ItemArray[1].ToString();
					}
					else
					{
						this.dgvReport.Rows[str].Cells[2].Value = dataRow.ItemArray[0].ToString();
						this.dgvReport.Rows[str].Cells[3].Value = dataRow.ItemArray[1].ToString();
					}
					str++;
				}
				num = new decimal(0);
				dataTable = new DataTable();
				dataTable = dataSet1.Tables[2];
				if (dataTable.Rows.Count > 0)
				{
					foreach (DataRow row1 in dataTable.Rows)
					{
						num = num + decimal.Parse(row1.ItemArray[0].ToString());
					}
					if (!(num > new decimal(0)))
					{
						this.dgvReport.Rows.Add();
						this.dgvReport.Rows[this.dgvReport.Rows.Count - 1].Cells[0].Value = "Closing Stock";
						this.dgvReport.Rows[this.dgvReport.Rows.Count - 1].Cells[1].Value = -num;
					}
					else
					{
						this.dgvReport.Rows.Add();
						this.dgvReport.Rows[this.dgvReport.Rows.Count - 1].Cells[2].Value = "Closing Stock";
						this.dgvReport.Rows[this.dgvReport.Rows.Count - 1].Cells[3].Value = num;
					}
				}
				dataSet = accountLedgerSP.ProfitAndLossAnalysis(DateTime.Parse(this.dtpFrom.Text), DateTime.Parse(this.dtpTo.Text));
				dataTable = dataSet.Tables[0];
				this.dgvReport.Rows.Add();
				num1 = new decimal(0);
				if (dataTable.Rows.Count > 0)
				{
					foreach (DataRow dataRow1 in dataTable.Rows)
					{
						num1 = num1 + decimal.Parse(dataRow1.ItemArray[0].ToString().ToString());
					}
				}
				dataTable = new DataTable();
				dataTable = dataSet.Tables[7];
				num2 = new decimal(0);
				if (dataTable.Rows.Count > 0)
				{
					foreach (DataRow row2 in dataTable.Rows)
					{
						num2 = num2 + decimal.Parse(row2.ItemArray[0].ToString().ToString());
					}
				}
				dataTable = new DataTable();
				dataTable = dataSet.Tables[1];
				num3 = new decimal(0);
				if (dataTable.Rows.Count > 0)
				{
					foreach (DataRow dataRow2 in dataTable.Rows)
					{
						num4 = decimal.Parse(dataRow2["Debit"].ToString().ToString());
						num3 = num3 + num4;
					}
				}
				dataTable = new DataTable();
				dataTable = dataSet.Tables[2];
				num5 = new decimal(0);
				if (dataTable.Rows.Count > 0)
				{
					foreach (DataRow row3 in dataTable.Rows)
					{
						num4 = decimal.Parse(row3["Credit"].ToString().ToString());
						num5 = num5 + num4;
					}
				}
				dataTable = new DataTable();
				dataTable = dataSet.Tables[3];
				num6 = new decimal(0);
				if (dataTable.Rows.Count > 0)
				{
					foreach (DataRow dataRow3 in dataTable.Rows)
					{
						num4 = decimal.Parse(dataRow3["Debit"].ToString().ToString());
						num6 = num6 + num4;
					}
				}
				dataTable = new DataTable();
				dataTable = dataSet.Tables[4];
				num7 = new decimal(0);
				if (dataTable.Rows.Count > 0)
				{
					foreach (DataRow row4 in dataTable.Rows)
					{
						num4 = decimal.Parse(row4["Credit"].ToString().ToString());
						num7 = num7 + num4;
					}
				}
				num8 = new decimal(0);
				num9 = new decimal(0);
				num8 = (num1 + num3) + num6;
				num9 = (num2 + num5) + num7;
				num10 = new decimal(0);
				num11 = new decimal(0);
				if (!(num8 > num9))
				{
					num10 = num9 - num8;
				}
				else
				{
					num11 = num8 - num9;
				}
				dataTable = new DataTable();
				dataTable = dataSet.Tables[5];
				num12 = new decimal(0);
				if (dataTable.Rows.Count > 0)
				{
					foreach (DataRow dataRow4 in dataTable.Rows)
					{
						num4 = decimal.Parse(dataRow4["Debit"].ToString().ToString());
						num12 = num12 + num4;
					}
				}
				dataTable = new DataTable();
				dataTable = dataSet.Tables[6];
				num13 = new decimal(0);
				if (dataTable.Rows.Count > 0)
				{
					foreach (DataRow row5 in dataTable.Rows)
					{
						num4 = decimal.Parse(row5["Credit"].ToString().ToString());
						num13 = num13 + num4;
					}
				}
				num14 = num11 + num12;
				num15 = num10 + num13;
				num16 = num15 - num14;
				num16 = Math.Round(num16, 2);
				if (!(num16 > new decimal(0)))
				{
					this.dgvReport.Rows.Add();
					this.dgvReport.Rows[this.dgvReport.Rows.Count - 1].Cells[2].Value = "Net Loss";
					this.dgvReport.Rows[this.dgvReport.Rows.Count - 1].Cells[3].Value = -num16;
				}
				else
				{
					this.dgvReport.Rows.Add();
					this.dgvReport.Rows[this.dgvReport.Rows.Count - 1].Cells[0].Value = "Net Profit";
					this.dgvReport.Rows[this.dgvReport.Rows.Count - 1].Cells[1].Value = num16;
				}
				font = new System.Drawing.Font(this.dgvReport.Font, FontStyle.Bold);
				num17 = new decimal(0);
				num18 = new decimal(0);
				foreach (DataGridViewRow dataGridViewRow1 in (IEnumerable)this.dgvReport.Rows)
				{
					num19 = new decimal(0);
					num20 = new decimal(0);
					try
					{
						num19 = decimal.Parse(dataGridViewRow1.Cells[1].Value.ToString());
					}
					catch (Exception exception)
					{
						num19 = new decimal(0);
					}
					try
					{
						num20 = decimal.Parse(dataGridViewRow1.Cells[3].Value.ToString());
					}
					catch (Exception exception1)
					{
						num20 = new decimal(0);
					}
					num17 = num17 + num19;
					num18 = num18 + num20;
				}
				num21 = new decimal(0);
				num22 = new decimal(0);
				if (num17 != num18)
				{
					if (!(num17 > num18))
					{
						this.dgvReport.Rows.Add();
						this.dgvReport.Rows[this.dgvReport.Rows.Count - 1].Cells[0].Value = "Diffrence";
						this.dgvReport.Rows[this.dgvReport.Rows.Count - 1].Cells[1].Value = Math.Round(num18 - num17, 2);
						num22 = num18 - num17;
						this.dgvReport.Rows[this.dgvReport.Rows.Count - 1].DefaultCellStyle.Font = font;
						this.dgvReport.Rows[this.dgvReport.Rows.Count - 1].DefaultCellStyle.ForeColor = Color.Red;
					}
					else
					{
						this.dgvReport.Rows.Add();
						this.dgvReport.Rows[this.dgvReport.Rows.Count - 1].Cells[2].Value = "Diffrence";
						this.dgvReport.Rows[this.dgvReport.Rows.Count - 1].Cells[3].Value = Math.Round(num17 - num18, 2);
						num21 = num17 - num18;
						this.dgvReport.Rows[this.dgvReport.Rows.Count - 1].DefaultCellStyle.Font = font;
						this.dgvReport.Rows[this.dgvReport.Rows.Count - 1].DefaultCellStyle.ForeColor = Color.Red;
					}
				}
				this.dgvReport.Rows.Add();
				this.dgvReport.Rows[this.dgvReport.Rows.Count - 1].Cells[1].Value = "_______________________";
				this.dgvReport.Rows[this.dgvReport.Rows.Count - 1].Cells[3].Value = "_______________________";
				this.dgvReport.Rows.Add();
				this.dgvReport.Rows[this.dgvReport.Rows.Count - 1].DefaultCellStyle.Font = font;
				this.dgvReport.Rows[this.dgvReport.Rows.Count - 1].Cells[0].Value = "Total";
				this.dgvReport.Rows[this.dgvReport.Rows.Count - 1].Cells[2].Value = "Total";
				this.dgvReport.Rows[this.dgvReport.Rows.Count - 1].Cells[1].Value = Math.Round(num17 + num22, 2);
				this.dgvReport.Rows[this.dgvReport.Rows.Count - 1].Cells[3].Value = Math.Round(num18 + num21, 2);
			}
			else
			{
				dataSet1 = accountLedgerSP.BalanceSheet(DateTime.Parse(this.dtpFrom.Text), DateTime.Parse(this.dtpTo.Text));
				dataTable = dataSet1.Tables[0];
				foreach (DataRow dataRow5 in dataTable.Rows)
				{
					this.dgvReport.Rows.Add();
					this.dgvReport.Rows[this.dgvReport.Rows.Count - 1].Cells[0].Value = dataRow5.ItemArray[1].ToString();
					this.dgvReport.Rows[this.dgvReport.Rows.Count - 1].Cells[1].Value = dataRow5.ItemArray[2].ToString();
				}
				dataTable = new DataTable();
				dataTable = dataSet1.Tables[1];
				str = 0;
				foreach (DataRow row6 in dataTable.Rows)
				{
					if (str >= this.dgvReport.Rows.Count)
					{
						this.dgvReport.Rows.Add();
						this.dgvReport.Rows[this.dgvReport.Rows.Count - 1].Cells[2].Value = row6.ItemArray[1].ToString();
						this.dgvReport.Rows[this.dgvReport.Rows.Count - 1].Cells[3].Value = row6.ItemArray[2].ToString();
					}
					else
					{
						this.dgvReport.Rows[str].Cells[2].Value = row6.ItemArray[1].ToString();
						this.dgvReport.Rows[str].Cells[3].Value = row6.ItemArray[2].ToString();
					}
					str++;
				}
				num = new decimal(0);
				dataTable = new DataTable();
				dataTable = dataSet1.Tables[2];
				if (dataTable.Rows.Count > 0)
				{
					foreach (DataRow dataRow6 in dataTable.Rows)
					{
						num = num + decimal.Parse(dataRow6.ItemArray[0].ToString());
					}
					if (!(num > new decimal(0)))
					{
						this.dgvReport.Rows.Add();
						this.dgvReport.Rows[this.dgvReport.Rows.Count - 1].Cells[0].Value = "Closing Stock";
						this.dgvReport.Rows[this.dgvReport.Rows.Count - 1].Cells[1].Value = -num;
					}
					else
					{
						this.dgvReport.Rows.Add();
						this.dgvReport.Rows[this.dgvReport.Rows.Count - 1].Cells[2].Value = "Closing Stock";
						this.dgvReport.Rows[this.dgvReport.Rows.Count - 1].Cells[3].Value = num;
					}
				}
				dataSet = accountLedgerSP.ProfitAndLossAnalysis(DateTime.Parse(this.dtpFrom.Text), DateTime.Parse(this.dtpTo.Text));
				dataTable = dataSet.Tables[0];
				this.dgvReport.Rows.Add();
				num1 = new decimal(0);
				if (dataTable.Rows.Count > 0)
				{
					foreach (DataRow row7 in dataTable.Rows)
					{
						num1 = num1 + decimal.Parse(row7.ItemArray[0].ToString().ToString());
					}
				}
				dataTable = new DataTable();
				dataTable = dataSet.Tables[7];
				num2 = new decimal(0);
				if (dataTable.Rows.Count > 0)
				{
					foreach (DataRow dataRow7 in dataTable.Rows)
					{
						num2 = num2 + decimal.Parse(dataRow7.ItemArray[0].ToString().ToString());
					}
				}
				dataTable = new DataTable();
				dataTable = dataSet.Tables[1];
				num3 = new decimal(0);
				if (dataTable.Rows.Count > 0)
				{
					foreach (DataRow row8 in dataTable.Rows)
					{
						num4 = decimal.Parse(row8["Debit"].ToString().ToString());
						num3 = num3 + num4;
					}
				}
				dataTable = new DataTable();
				dataTable = dataSet.Tables[2];
				num5 = new decimal(0);
				if (dataTable.Rows.Count > 0)
				{
					foreach (DataRow dataRow8 in dataTable.Rows)
					{
						num4 = decimal.Parse(dataRow8["Credit"].ToString().ToString());
						num5 = num5 + num4;
					}
				}
				dataTable = new DataTable();
				dataTable = dataSet.Tables[3];
				num6 = new decimal(0);
				if (dataTable.Rows.Count > 0)
				{
					foreach (DataRow row9 in dataTable.Rows)
					{
						num4 = decimal.Parse(row9["Debit"].ToString().ToString());
						num6 = num6 + num4;
					}
				}
				dataTable = new DataTable();
				dataTable = dataSet.Tables[4];
				num7 = new decimal(0);
				if (dataTable.Rows.Count > 0)
				{
					foreach (DataRow dataRow9 in dataTable.Rows)
					{
						num4 = decimal.Parse(dataRow9["Credit"].ToString().ToString());
						num7 = num7 + num4;
					}
				}
				num8 = new decimal(0);
				num9 = new decimal(0);
				num8 = (num1 + num3) + num6;
				num9 = (num2 + num5) + num7;
				num10 = new decimal(0);
				num11 = new decimal(0);
				if (!(num8 > num9))
				{
					num10 = num9 - num8;
				}
				else
				{
					num11 = num8 - num9;
				}
				dataTable = new DataTable();
				dataTable = dataSet.Tables[5];
				num12 = new decimal(0);
				if (dataTable.Rows.Count > 0)
				{
					foreach (DataRow row10 in dataTable.Rows)
					{
						num4 = decimal.Parse(row10["Debit"].ToString().ToString());
						num12 = num12 + num4;
					}
				}
				dataTable = new DataTable();
				dataTable = dataSet.Tables[6];
				num13 = new decimal(0);
				if (dataTable.Rows.Count > 0)
				{
					foreach (DataRow dataRow10 in dataTable.Rows)
					{
						num4 = decimal.Parse(dataRow10["Credit"].ToString().ToString());
						num13 = num13 + num4;
					}
				}
				num14 = num11 + num12;
				num15 = num10 + num13;
				num16 = num15 - num14;
				num16 = Math.Round(num16, 2);
				if (!(num16 > new decimal(0)))
				{
					this.dgvReport.Rows.Add();
					this.dgvReport.Rows[this.dgvReport.Rows.Count - 1].Cells[2].Value = "Net Loss";
					this.dgvReport.Rows[this.dgvReport.Rows.Count - 1].Cells[3].Value = -num16;
					this.dgvReport.Rows[this.dgvReport.Rows.Count - 1].Cells[3].Style.ForeColor = Color.Red;
				}
				else
				{
					this.dgvReport.Rows.Add();
					this.dgvReport.Rows[this.dgvReport.Rows.Count - 1].Cells[0].Value = "Net Profit";
					this.dgvReport.Rows[this.dgvReport.Rows.Count - 1].Cells[1].Value = num16;
					this.dgvReport.Rows[this.dgvReport.Rows.Count - 1].Cells[1].Style.ForeColor = Color.Green;
				}
				font = new System.Drawing.Font(this.dgvReport.Font, FontStyle.Bold);
				num17 = new decimal(0);
				num18 = new decimal(0);
				foreach (DataGridViewRow dataGridViewRow1 in (IEnumerable)this.dgvReport.Rows)
				{
					num19 = new decimal(0);
					num20 = new decimal(0);
					try
					{
						num19 = decimal.Parse(dataGridViewRow1.Cells[1].Value.ToString());
					}
					catch (Exception exception2)
					{
						num19 = new decimal(0);
					}
					try
					{
						num20 = decimal.Parse(dataGridViewRow1.Cells[3].Value.ToString());
					}
					catch (Exception exception3)
					{
						num20 = new decimal(0);
					}
					num17 = num17 + num19;
					num18 = num18 + num20;
				}
				num21 = new decimal(0);
				num22 = new decimal(0);
				if (num17 != num18)
				{
					if (!(num17 > num18))
					{
						this.dgvReport.Rows.Add();
						this.dgvReport.Rows[this.dgvReport.Rows.Count - 1].Cells[0].Value = "Diffrence";
						this.dgvReport.Rows[this.dgvReport.Rows.Count - 1].Cells[1].Value = Math.Round(num18 - num17, 2);
						num22 = num18 - num17;
						this.dgvReport.Rows[this.dgvReport.Rows.Count - 1].DefaultCellStyle.Font = font;
						this.dgvReport.Rows[this.dgvReport.Rows.Count - 1].DefaultCellStyle.ForeColor = Color.Red;
					}
					else
					{
						this.dgvReport.Rows.Add();
						this.dgvReport.Rows[this.dgvReport.Rows.Count - 1].Cells[2].Value = "Diffrence";
						this.dgvReport.Rows[this.dgvReport.Rows.Count - 1].Cells[3].Value = Math.Round(num17 - num18, 2);
						num21 = num17 - num18;
						this.dgvReport.Rows[this.dgvReport.Rows.Count - 1].DefaultCellStyle.Font = font;
						this.dgvReport.Rows[this.dgvReport.Rows.Count - 1].DefaultCellStyle.ForeColor = Color.Red;
					}
				}
				this.dgvReport.Rows.Add();
				this.dgvReport.Rows[this.dgvReport.Rows.Count - 1].Cells[1].Value = "_______________________";
				this.dgvReport.Rows[this.dgvReport.Rows.Count - 1].Cells[3].Value = "_______________________";
				this.dgvReport.Rows.Add();
				this.dgvReport.Rows[this.dgvReport.Rows.Count - 1].DefaultCellStyle.Font = font;
				this.dgvReport.Rows[this.dgvReport.Rows.Count - 1].Cells[0].Value = "Total";
				this.dgvReport.Rows[this.dgvReport.Rows.Count - 1].Cells[2].Value = "Total";
				this.dgvReport.Rows[this.dgvReport.Rows.Count - 1].Cells[1].Value = Math.Round(num17 + num22, 2);
				this.dgvReport.Rows[this.dgvReport.Rows.Count - 1].Cells[3].Value = Math.Round(num18 + num21, 2);
			}
		}

		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(rptBalanceSheet));
			DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
			DataGridViewCellStyle control = new DataGridViewCellStyle();
			DataGridViewCellStyle window = new DataGridViewCellStyle();
			this.btnClear = new Button();
			this.lblPhone = new Label();
			this.lblPlace = new Label();
			this.lblCompanyName = new Label();
			this.label5 = new Label();
			this.btnClose = new PictureBox();
			this.dgvReport = new DataGridView();
			this.Column1 = new DataGridViewTextBoxColumn();
			this.Column2 = new DataGridViewTextBoxColumn();
			this.Column3 = new DataGridViewTextBoxColumn();
			this.Column4 = new DataGridViewTextBoxColumn();
			this.Column5 = new DataGridViewTextBoxColumn();
			this.Column6 = new DataGridViewTextBoxColumn();
			this.Column7 = new DataGridViewTextBoxColumn();
			this.toolTip1 = new ToolTip(this.components);
			this.btnExport = new Button();
			this.bwrk1 = new BackgroundWorker();
			this.panel1 = new Panel();
			this.panel2 = new Panel();
			this.panel3 = new Panel();
			this.panel4 = new Panel();
			this.panel5 = new Panel();
			this.groupBox1 = new GroupBox();
			this.rbtnContensed = new RadioButton();
			this.rbtnDetailed = new RadioButton();
			this.dtpTo = new DateTimePicker();
			this.dtpFrom = new DateTimePicker();
			this.label2 = new Label();
			this.label1 = new Label();
			this.label3 = new Label();
			this.label4 = new Label();
			this.dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn7 = new DataGridViewTextBoxColumn();
			this.groupBox4 = new GroupBox();
			this.cmbExportType = new ComboBox();
			((ISupportInitialize)this.btnClose).BeginInit();
			((ISupportInitialize)this.dgvReport).BeginInit();
			this.panel1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox4.SuspendLayout();
			base.SuspendLayout();
			this.btnClear.BackColor = Color.Transparent;
			this.btnClear.BackgroundImage = Resources.RefreshIcon;
			this.btnClear.BackgroundImageLayout = ImageLayout.Center;
			this.btnClear.Cursor = Cursors.Hand;
			this.btnClear.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnClear.FlatAppearance.BorderColor = Color.LightSkyBlue;
			this.btnClear.FlatAppearance.MouseOverBackColor = Color.PowderBlue;
			this.btnClear.FlatStyle = FlatStyle.Flat;
			this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.btnClear.ImageAlign = ContentAlignment.BottomCenter;
			this.btnClear.Location = new Point(12, 87);
			this.btnClear.Margin = new System.Windows.Forms.Padding(10);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(30, 30);
			this.btnClear.TabIndex = 2;
			this.toolTip1.SetToolTip(this.btnClear, "Reset");
			this.btnClear.UseVisualStyleBackColor = false;
			this.btnClear.Click += new EventHandler(this.btnClear_Click);
			this.lblPhone.BackColor = Color.Transparent;
			this.lblPhone.Font = new System.Drawing.Font("Verdana", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.lblPhone.ForeColor = Color.Black;
			this.lblPhone.Location = new Point(328, 95);
			this.lblPhone.Name = "lblPhone";
			this.lblPhone.Size = new System.Drawing.Size(337, 18);
			this.lblPhone.TabIndex = 6;
			this.lblPhone.Text = "Phone : 0494 2423344";
			this.lblPhone.TextAlign = ContentAlignment.TopCenter;
			this.lblPlace.BackColor = Color.Transparent;
			this.lblPlace.Font = new System.Drawing.Font("Verdana", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.lblPlace.ForeColor = Color.Black;
			this.lblPlace.Location = new Point(57, 74);
			this.lblPlace.Name = "lblPlace";
			this.lblPlace.Size = new System.Drawing.Size(878, 18);
			this.lblPlace.TabIndex = 6;
			this.lblPlace.Text = "Kakkenchery ,Malappuram";
			this.lblPlace.TextAlign = ContentAlignment.TopCenter;
			this.lblCompanyName.BackColor = Color.Transparent;
			this.lblCompanyName.Font = new System.Drawing.Font("Verdana", 15.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.lblCompanyName.ForeColor = Color.DimGray;
			this.lblCompanyName.Location = new Point(52, 43);
			this.lblCompanyName.Name = "lblCompanyName";
			this.lblCompanyName.Size = new System.Drawing.Size(894, 30);
			this.lblCompanyName.TabIndex = 5;
			this.lblCompanyName.Text = "Name";
			this.lblCompanyName.TextAlign = ContentAlignment.TopCenter;
			this.label5.AutoSize = true;
			this.label5.BackColor = Color.Transparent;
			this.label5.Font = new System.Drawing.Font("Verdana", 14.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label5.ForeColor = Color.Black;
			this.label5.Location = new Point(3, 5);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(165, 23);
			this.label5.TabIndex = 0;
			this.label5.Text = "Balance Sheet";
			this.btnClose.BackColor = Color.Transparent;
			this.btnClose.Cursor = Cursors.Hand;
			this.btnClose.Image = (Image)componentResourceManager.GetObject("btnClose.Image");
			this.btnClose.Location = new Point(971, 0);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(25, 25);
			this.btnClose.SizeMode = PictureBoxSizeMode.StretchImage;
			this.btnClose.TabIndex = 1;
			this.btnClose.TabStop = false;
			this.btnClose.Click += new EventHandler(this.btnClose_Click);
			this.dgvReport.AllowUserToAddRows = false;
			this.dgvReport.AllowUserToDeleteRows = false;
			this.dgvReport.AllowUserToResizeColumns = false;
			this.dgvReport.AllowUserToResizeRows = false;
			dataGridViewCellStyle.SelectionBackColor = Color.White;
			this.dgvReport.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle;
			this.dgvReport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvReport.BackgroundColor = Color.White;
			this.dgvReport.BorderStyle = BorderStyle.Fixed3D;
			control.Alignment = DataGridViewContentAlignment.MiddleLeft;
			control.BackColor = SystemColors.Control;
			control.Font = new System.Drawing.Font("Verdana", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			control.ForeColor = SystemColors.WindowText;
			control.SelectionBackColor = SystemColors.Highlight;
			control.SelectionForeColor = SystemColors.HighlightText;
			control.WrapMode = DataGridViewTriState.True;
			this.dgvReport.ColumnHeadersDefaultCellStyle = control;
			this.dgvReport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvReport.ColumnHeadersVisible = false;
			DataGridViewColumnCollection columns = this.dgvReport.Columns;
			DataGridViewColumn[] column1 = new DataGridViewColumn[] { this.Column1, this.Column2, this.Column3, this.Column4, this.Column5, this.Column6, this.Column7 };
			columns.AddRange(column1);
			window.Alignment = DataGridViewContentAlignment.MiddleLeft;
			window.BackColor = SystemColors.Window;
			window.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			window.ForeColor = Color.Black;
			window.SelectionBackColor = Color.White;
			window.SelectionForeColor = Color.Black;
			window.WrapMode = DataGridViewTriState.False;
			this.dgvReport.DefaultCellStyle = window;
			this.dgvReport.GridColor = Color.WhiteSmoke;
			this.dgvReport.Location = new Point(12, 233);
			this.dgvReport.MultiSelect = false;
			this.dgvReport.Name = "dgvReport";
			this.dgvReport.ReadOnly = true;
			this.dgvReport.RowHeadersVisible = false;
			this.dgvReport.ScrollBars = ScrollBars.Vertical;
			this.dgvReport.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			this.dgvReport.Size = new System.Drawing.Size(972, 361);
			this.dgvReport.TabIndex = 2;
			this.Column1.HeaderText = "Column1";
			this.Column1.Name = "Column1";
			this.Column1.ReadOnly = true;
			this.Column2.HeaderText = "Column2";
			this.Column2.Name = "Column2";
			this.Column2.ReadOnly = true;
			this.Column3.HeaderText = "Column3";
			this.Column3.Name = "Column3";
			this.Column3.ReadOnly = true;
			this.Column4.HeaderText = "Column4";
			this.Column4.Name = "Column4";
			this.Column4.ReadOnly = true;
			this.Column5.HeaderText = "Column5";
			this.Column5.Name = "Column5";
			this.Column5.ReadOnly = true;
			this.Column6.HeaderText = "Column6";
			this.Column6.Name = "Column6";
			this.Column6.ReadOnly = true;
			this.Column7.HeaderText = "Column7";
			this.Column7.Name = "Column7";
			this.Column7.ReadOnly = true;
			this.btnExport.BackColor = Color.Transparent;
			this.btnExport.BackgroundImage = Resources.ExportIcon;
			this.btnExport.BackgroundImageLayout = ImageLayout.Center;
			this.btnExport.Cursor = Cursors.Hand;
			this.btnExport.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnExport.FlatAppearance.BorderColor = Color.LightSkyBlue;
			this.btnExport.FlatAppearance.MouseOverBackColor = Color.PowderBlue;
			this.btnExport.FlatStyle = FlatStyle.Flat;
			this.btnExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.btnExport.ImageAlign = ContentAlignment.BottomCenter;
			this.btnExport.Location = new Point(189, 11);
			this.btnExport.Margin = new System.Windows.Forms.Padding(10);
			this.btnExport.Name = "btnExport";
			this.btnExport.Size = new System.Drawing.Size(30, 30);
			this.btnExport.TabIndex = 3;
			this.toolTip1.SetToolTip(this.btnExport, "Export");
			this.btnExport.UseVisualStyleBackColor = false;
			this.btnExport.Click += new EventHandler(this.btnExport_Click);
			this.bwrk1.DoWork += new DoWorkEventHandler(this.bwrk1_DoWork);
			this.bwrk1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.bwrk1_RunWorkerCompleted);
			this.panel1.BackgroundImage = Resources.head_bg;
			this.panel1.Controls.Add(this.btnClose);
			this.panel1.Controls.Add(this.label5);
			this.panel1.Dock = DockStyle.Top;
			this.panel1.Location = new Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(996, 33);
			this.panel1.TabIndex = 14;
			this.panel2.BackColor = Color.FromArgb(136, 136, 136);
			this.panel2.Dock = DockStyle.Left;
			this.panel2.Location = new Point(0, 33);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(1, 627);
			this.panel2.TabIndex = 15;
			this.panel3.BackColor = Color.FromArgb(136, 136, 136);
			this.panel3.Dock = DockStyle.Right;
			this.panel3.Location = new Point(995, 33);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(1, 627);
			this.panel3.TabIndex = 16;
			this.panel4.BackColor = Color.FromArgb(136, 136, 136);
			this.panel4.Dock = DockStyle.Top;
			this.panel4.Location = new Point(1, 33);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(994, 1);
			this.panel4.TabIndex = 17;
			this.panel5.BackColor = Color.FromArgb(136, 136, 136);
			this.panel5.Dock = DockStyle.Bottom;
			this.panel5.Location = new Point(1, 659);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(994, 1);
			this.panel5.TabIndex = 18;
			this.groupBox1.BackColor = Color.Transparent;
			this.groupBox1.Controls.Add(this.rbtnContensed);
			this.groupBox1.Controls.Add(this.rbtnDetailed);
			this.groupBox1.Controls.Add(this.dtpTo);
			this.groupBox1.Controls.Add(this.dtpFrom);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new Point(18, 130);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(734, 42);
			this.groupBox1.TabIndex = 30;
			this.groupBox1.TabStop = false;
			this.rbtnContensed.AutoSize = true;
			this.rbtnContensed.BackColor = Color.Transparent;
			this.rbtnContensed.Location = new Point(408, 14);
			this.rbtnContensed.Name = "rbtnContensed";
			this.rbtnContensed.Size = new System.Drawing.Size(79, 17);
			this.rbtnContensed.TabIndex = 27;
			this.rbtnContensed.TabStop = true;
			this.rbtnContensed.Text = "Condensed";
			this.rbtnContensed.UseVisualStyleBackColor = false;
			this.rbtnContensed.CheckedChanged += new EventHandler(this.dtpFrom_ValueChanged);
			this.rbtnDetailed.AutoSize = true;
			this.rbtnDetailed.BackColor = Color.Transparent;
			this.rbtnDetailed.Location = new Point(530, 16);
			this.rbtnDetailed.Name = "rbtnDetailed";
			this.rbtnDetailed.Size = new System.Drawing.Size(64, 17);
			this.rbtnDetailed.TabIndex = 28;
			this.rbtnDetailed.TabStop = true;
			this.rbtnDetailed.Text = "Detailed";
			this.rbtnDetailed.UseVisualStyleBackColor = false;
			this.rbtnDetailed.CheckedChanged += new EventHandler(this.dtpFrom_ValueChanged);
			this.dtpTo.CustomFormat = "dd-MMM-yyyy";
			this.dtpTo.Format = DateTimePickerFormat.Custom;
			this.dtpTo.Location = new Point(200, 16);
			this.dtpTo.Name = "dtpTo";
			this.dtpTo.Size = new System.Drawing.Size(117, 20);
			this.dtpTo.TabIndex = 25;
			this.dtpTo.ValueChanged += new EventHandler(this.dtpFrom_ValueChanged);
			this.dtpTo.KeyDown += new KeyEventHandler(this.dtpTo_KeyDown);
			this.dtpFrom.CustomFormat = "dd-MMM-yyyy";
			this.dtpFrom.Format = DateTimePickerFormat.Custom;
			this.dtpFrom.Location = new Point(45, 16);
			this.dtpFrom.Name = "dtpFrom";
			this.dtpFrom.Size = new System.Drawing.Size(117, 20);
			this.dtpFrom.TabIndex = 25;
			this.dtpFrom.ValueChanged += new EventHandler(this.dtpFrom_ValueChanged);
			this.dtpFrom.KeyDown += new KeyEventHandler(this.dtpFrom_KeyDown);
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label2.Location = new Point(168, 21);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(23, 13);
			this.label2.TabIndex = 19;
			this.label2.Text = "To:";
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label1.Location = new Point(5, 21);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(33, 13);
			this.label1.TabIndex = 17;
			this.label1.Text = "From:";
			this.label3.BackColor = Color.Transparent;
			this.label3.Font = new System.Drawing.Font("Verdana", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label3.ForeColor = Color.Black;
			this.label3.Location = new Point(13, 212);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(275, 18);
			this.label3.TabIndex = 31;
			this.label3.Text = "Liability";
			this.label3.TextAlign = ContentAlignment.TopCenter;
			this.label4.BackColor = Color.Transparent;
			this.label4.Font = new System.Drawing.Font("Verdana", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label4.ForeColor = Color.Black;
			this.label4.Location = new Point(704, 212);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(275, 18);
			this.label4.TabIndex = 32;
			this.label4.Text = "Asset";
			this.label4.TextAlign = ContentAlignment.TopCenter;
			this.dataGridViewTextBoxColumn1.HeaderText = "Column1";
			this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn1.ReadOnly = true;
			this.dataGridViewTextBoxColumn1.Width = 138;
			this.dataGridViewTextBoxColumn2.HeaderText = "Column2";
			this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
			this.dataGridViewTextBoxColumn2.ReadOnly = true;
			this.dataGridViewTextBoxColumn2.Width = 138;
			this.dataGridViewTextBoxColumn3.HeaderText = "Column3";
			this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
			this.dataGridViewTextBoxColumn3.ReadOnly = true;
			this.dataGridViewTextBoxColumn3.Width = 138;
			this.dataGridViewTextBoxColumn4.HeaderText = "Column4";
			this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
			this.dataGridViewTextBoxColumn4.ReadOnly = true;
			this.dataGridViewTextBoxColumn4.Width = 139;
			this.dataGridViewTextBoxColumn5.HeaderText = "Column5";
			this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
			this.dataGridViewTextBoxColumn5.ReadOnly = true;
			this.dataGridViewTextBoxColumn5.Width = 138;
			this.dataGridViewTextBoxColumn6.HeaderText = "Column6";
			this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
			this.dataGridViewTextBoxColumn6.ReadOnly = true;
			this.dataGridViewTextBoxColumn6.Width = 138;
			this.dataGridViewTextBoxColumn7.HeaderText = "Column7";
			this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
			this.dataGridViewTextBoxColumn7.ReadOnly = true;
			this.dataGridViewTextBoxColumn7.Width = 138;
			this.groupBox4.BackColor = Color.Transparent;
			this.groupBox4.Controls.Add(this.btnExport);
			this.groupBox4.Controls.Add(this.cmbExportType);
			this.groupBox4.Location = new Point(758, 128);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(232, 45);
			this.groupBox4.TabIndex = 33;
			this.groupBox4.TabStop = false;
			this.cmbExportType.DropDownStyle = ComboBoxStyle.DropDownList;
			this.cmbExportType.FormattingEnabled = true;
			this.cmbExportType.Items.AddRange(new object[] { "Print", "Excel", "Html" });
			this.cmbExportType.Location = new Point(6, 18);
			this.cmbExportType.Name = "cmbExportType";
			this.cmbExportType.Size = new System.Drawing.Size(170, 21);
			this.cmbExportType.TabIndex = 0;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.BackColor = Color.White;
			this.BackgroundImage = Resources.report_bg;
			this.BackgroundImageLayout = ImageLayout.Stretch;
			base.ClientSize = new System.Drawing.Size(996, 660);
			base.ControlBox = false;
			base.Controls.Add(this.groupBox4);
			base.Controls.Add(this.label4);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.groupBox1);
			base.Controls.Add(this.btnClear);
			base.Controls.Add(this.lblPhone);
			base.Controls.Add(this.lblPlace);
			base.Controls.Add(this.lblCompanyName);
			base.Controls.Add(this.panel5);
			base.Controls.Add(this.panel4);
			base.Controls.Add(this.panel3);
			base.Controls.Add(this.panel2);
			base.Controls.Add(this.panel1);
			base.Controls.Add(this.dgvReport);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.KeyPreview = true;
			base.Name = "rptBalanceSheet";
			base.StartPosition = FormStartPosition.CenterScreen;
			base.WindowState = FormWindowState.Maximized;
			base.KeyDown += new KeyEventHandler(this.rptProfitAndLossAnalysis_KeyDown);
			base.Load += new EventHandler(this.rptLedgerBalance_Load);
			((ISupportInitialize)this.btnClose).EndInit();
			((ISupportInitialize)this.dgvReport).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		public void LoadCompanyDetails()
		{
			try
			{
				DataTable dataTable = new DataTable();
				this.CompanyInfo = this.CompanySP.CompanyView(MedicalShop.CompanyInfo._companyId);
				this.lblCompanyName.Text = this.CompanyInfo.CompanyName;
				this.lblPhone.Text = this.CompanyInfo.Pincode;
				string[] strArrays = Regex.Split(this.CompanyInfo.Address, "\r\n");
				string str = "";
				string[] strArrays1 = strArrays;
				for (int i = 0; i < (int)strArrays1.Length; i++)
				{
					str = string.Concat(str, strArrays1[i], "  ");
				}
				if (!(str == " , "))
				{
					int length = str.Length;
					string str1 = str.Substring(0, length - 2);
					this.lblPlace.Text = str1;
				}
				else
				{
					this.lblPlace.Text = "";
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		public void LoadGridColumns()
		{
			try
			{
				this.dgvReport.Columns.Clear();
				this.dgvReport.Rows.Clear();
				this.dgvReport.Columns.Add("Expense", "Expense");
				this.dgvReport.Columns.Add("Amount1", "Amount1");
				this.dgvReport.Columns.Add("Income", "Income");
				this.dgvReport.Columns.Add("Amount2", "Amount2");
				this.dgvReport.Columns[1].Width = 150;
				this.dgvReport.Columns[3].Width = 150;
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void rptLedgerBalance_Load(object sender, EventArgs e)
		{
			try
			{
				this.dtpFrom.MinDate = FinacialYearInfo._fromDate;
				this.dtpFrom.MaxDate = FinacialYearInfo._toDate;
				this.dtpFrom.Value = FinacialYearInfo._fromDate;
				this.dtpTo.MinDate = FinacialYearInfo._fromDate;
				this.dtpTo.MaxDate = FinacialYearInfo._toDate;
				this.dtpTo.Value = FinacialYearInfo._toDate;
				this.cmbExportType.SelectedIndex = 0;
				this.rbtnContensed.Checked = true;
				this.LoadCompanyDetails();
				this.LoadGridColumns();
				this.FillGrid();
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageBox.Show(exception.Message, "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void rptProfitAndLossAnalysis_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				if (e.KeyCode == Keys.Escape)
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
	}
}