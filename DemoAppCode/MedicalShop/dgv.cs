using System;
using System.Windows.Forms;

namespace MedicalShop
{
	internal class dgv
	{
		public dgv()
		{
		}

		public class DataGridViewEnter : DataGridView
		{
			public DataGridViewEnter()
			{
			}

			protected override bool ProcessDataGridViewKey(KeyEventArgs e)
			{
				bool flag;
				if (e.KeyCode != Keys.Return)
				{
					flag = (e.KeyCode != Keys.Back ? base.ProcessDataGridViewKey(e) : this.ProcessLeftKey(e.KeyData));
				}
				else
				{
					flag = this.ProcessRightKey(e.KeyData);
				}
				return flag;
			}

			protected override bool ProcessDialogKey(Keys keyData)
			{
				bool flag;
				Keys key = keyData & Keys.KeyCode;
				if (key != Keys.Return)
				{
					if (key == Keys.Back)
					{
						base.EndEdit();
						if ((base.CurrentCell.OwningColumn.CellType.ToString() != "System.Windows.Forms.DataGridViewTextBoxCell" ? true : base.CurrentCell.ReadOnly))
						{
							flag = this.ProcessLeftKey(keyData);
							return flag;
						}
						else if ((base.CurrentCell.Value == null ? false : !(base.CurrentCell.Value.ToString() == "")))
						{
							if (base.CurrentCell.Value.ToString().Length > 0)
							{
								goto Label1;
							}
							flag = this.ProcessLeftKey(keyData);
							return flag;
						}
						else
						{
							flag = this.ProcessLeftKey(keyData);
							return flag;
						}
					}
				Label2:
					flag = base.ProcessDialogKey(keyData);
				}
				else
				{
					flag = this.ProcessRightKey(keyData);
				}
				return flag;
                Label1:
                base.BeginEdit(false);
                return true;
			}

			public new bool ProcessLeftKey(Keys keyData)
			{
				bool flag;
				try
				{
					if ((keyData & Keys.KeyCode) == Keys.Back)
					{
						if (base.CurrentCell.ColumnIndex == 0)
						{
							if (base.CurrentCell.RowIndex > 0)
							{
								if (base.Rows[base.CurrentCell.RowIndex - 1].Cells[base.ColumnCount - 1].Visible)
								{
									base.CurrentCell = base.Rows[base.CurrentCell.RowIndex - 1].Cells[base.ColumnCount - 1];
									flag = true;
									return flag;
								}
								else if (!base.Rows[base.CurrentCell.RowIndex - 1].Cells[base.ColumnCount - 2].Visible)
								{
									MessageBox.Show("invisible");
								}
								else
								{
									base.CurrentCell = base.Rows[base.CurrentCell.RowIndex - 1].Cells[base.ColumnCount - 2];
									flag = true;
									return flag;
								}
							}
						}
						flag = base.ProcessLeftKey(keyData);
						return flag;
					}
				}
				catch (Exception exception)
				{
				}
				flag = base.ProcessLeftKey(keyData);
				return flag;
			}

			public new bool ProcessRightKey(Keys keyData)
			{
				bool flag;
				try
				{
					if ((keyData & Keys.KeyCode) != Keys.Return)
					{
						flag = base.ProcessRightKey(keyData);
						return flag;
					}
					else
					{
						int columnIndex = base.CurrentCell.ColumnIndex;
						if ((base.Columns[base.Columns.Count - 1].Visible ? false : columnIndex == base.Columns[base.Columns.Count - 1].Index - 1))
						{
							columnIndex++;
						}
						if ((columnIndex != base.ColumnCount - 1 ? true : base.CurrentCell.RowIndex != base.RowCount - 1))
						{
							if (columnIndex == base.Columns.Count - 1)
							{
								if (base.CurrentCell.RowIndex + 1 < base.RowCount)
								{
									if (base.Rows[base.CurrentCell.RowIndex + 1].Cells[0].Visible)
									{
										base.CurrentCell = base.Rows[base.CurrentCell.RowIndex + 1].Cells[0];
										flag = true;
										return flag;
									}
									else if (base.Rows[base.CurrentCell.RowIndex + 1].Cells[1].Visible)
									{
										base.CurrentCell = base.Rows[base.CurrentCell.RowIndex + 1].Cells[1];
										flag = true;
										return flag;
									}
									else if (base.Rows[base.CurrentCell.RowIndex + 1].Cells[2].Visible)
									{
										base.CurrentCell = base.Rows[base.CurrentCell.RowIndex + 1].Cells[2];
										flag = true;
										return flag;
									}
									else if (base.Rows[base.CurrentCell.RowIndex + 1].Cells[3].Visible)
									{
										base.CurrentCell = base.Rows[base.CurrentCell.RowIndex + 1].Cells[3];
										flag = true;
										return flag;
									}
									else if (base.Rows[base.CurrentCell.RowIndex + 1].Cells[4].Visible)
									{
										base.CurrentCell = base.Rows[base.CurrentCell.RowIndex + 1].Cells[4];
										flag = true;
										return flag;
									}
								}
							}
							flag = base.ProcessRightKey(keyData);
						}
						else
						{
							base.EndEdit();
							((BindingSource)base.DataSource).AddNew();
							base.CurrentCell = base.Rows[base.RowCount - 1].Cells[0];
							flag = true;
						}
					}
				}
				catch
				{
					flag = base.ProcessRightKey(keyData);
					return flag;
				}
				return flag;
			}
		}
	}
}