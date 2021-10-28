using System;
using System.Windows.Forms;

namespace MedicalShop
{
	internal class DateInGrid
	{
		public static bool isValue;

		static DateInGrid()
		{
			DateInGrid.isValue = false;
		}

		public DateInGrid()
		{
		}

		public class CalendarCell : DataGridViewTextBoxCell
		{
			public override object DefaultNewRowValue
			{
				get
				{
					return "";
				}
			}

			public override Type EditType
			{
				get
				{
					return typeof(DateInGrid.CalendarEditingControl);
				}
			}

			public override Type ValueType
			{
				get
				{
					return typeof(DateTime);
				}
			}

			public CalendarCell()
			{
				base.Style.Format = "dd-MMM-yyyy";
			}

			public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
			{
				DateTime dateTime;
				base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);
				DateInGrid.CalendarEditingControl editingControl = base.DataGridView.EditingControl as DateInGrid.CalendarEditingControl;
				DateInGrid.CalendarEditingControl calendarEditingControl = editingControl;
				object value = base.Value;
				if (value == null)
				{
					value = "";
				}
				calendarEditingControl.Value = (DateTime.TryParse(value.ToString(), out dateTime) ? dateTime : DateTime.Now);
				if (base.Value != null)
				{
					if (!(base.Value.ToString() != ""))
					{
						DateInGrid.isValue = false;
						editingControl.Checked = false;
					}
					else
					{
						DateInGrid.isValue = true;
						editingControl.Checked = true;
					}
				}
			}
		}

		public class CalendarColumn : DataGridViewColumn
		{
			public override DataGridViewCell CellTemplate
			{
				get
				{
					return base.CellTemplate;
				}
				set
				{
					if ((value == null ? false : !value.GetType().IsAssignableFrom(typeof(DateInGrid.CalendarCell))))
					{
						throw new InvalidCastException("Must be a CalendarCell");
					}
					base.CellTemplate = value;
				}
			}

			public CalendarColumn() : base(new DateInGrid.CalendarCell())
			{
			}
		}

		private class CalendarEditingControl : DateTimePicker, IDataGridViewEditingControl
		{
			private DataGridView dataGridView;

			private bool valueChanged;

			private int rowIndex;

			public DataGridView EditingControlDataGridView
			{
				get
				{
					return this.dataGridView;
				}
				set
				{
					this.dataGridView = value;
				}
			}

			public object EditingControlFormattedValue
			{
				get
				{
					return base.Value.ToShortDateString();
				}
				set
				{
					if (value is string)
					{
						base.Value = DateTime.Parse((string)value);
					}
				}
			}

			public int EditingControlRowIndex
			{
				get
				{
					return this.rowIndex;
				}
				set
				{
					this.rowIndex = value;
				}
			}

			public bool EditingControlValueChanged
			{
				get
				{
					return this.valueChanged;
				}
				set
				{
					this.valueChanged = value;
				}
			}

			public Cursor EditingPanelCursor
			{
				get
				{
					return base.Cursor;
				}
			}

			public bool RepositionEditingControlOnValueChange
			{
				get
				{
					return false;
				}
			}

			public CalendarEditingControl()
			{
				base.Format = DateTimePickerFormat.Short;
			}

			public void ApplyCellStyleToEditingControl(DataGridViewCellStyle dataGridViewCellStyle)
			{
				this.Font = dataGridViewCellStyle.Font;
				base.CalendarForeColor = dataGridViewCellStyle.ForeColor;
				base.CalendarMonthBackground = dataGridViewCellStyle.BackColor;
				base.Format = DateTimePickerFormat.Custom;
				base.CustomFormat = "dd-MMM-yyyy";
				base.ShowUpDown = true;
				if (!DateInGrid.isValue)
				{
					base.Checked = false;
				}
			}

			public bool EditingControlWantsInputKey(Keys key, bool dataGridViewWantsInputKey)
			{
				bool flag;
				Keys key1 = key & Keys.KeyCode;
				if (key1 != Keys.Return)
				{
					switch (key1)
					{
						case Keys.Prior:
						case Keys.Next:
						case Keys.End:
						case Keys.Home:
						case Keys.Left:
						case Keys.Up:
						case Keys.Right:
						case Keys.Down:
						{
							break;
						}
						default:
						{
							switch (key1)
							{
								case Keys.NumPad0:
								case Keys.NumPad1:
								case Keys.NumPad2:
								case Keys.NumPad3:
								case Keys.NumPad4:
								case Keys.NumPad5:
								case Keys.NumPad6:
								case Keys.NumPad7:
								case Keys.NumPad8:
								case Keys.NumPad9:
								{
									break;
								}
								default:
								{
									flag = !dataGridViewWantsInputKey;
									return flag;
								}
							}
							break;
						}
					}
				}
				flag = true;
				return flag;
			}

			public object GetEditingControlFormattedValue(DataGridViewDataErrorContexts context)
			{
				object editingControlFormattedValue;
				if (!base.Checked)
				{
					editingControlFormattedValue = "";
				}
				else
				{
					editingControlFormattedValue = this.EditingControlFormattedValue;
				}
				return editingControlFormattedValue;
			}

			protected override void OnValueChanged(EventArgs eventargs)
			{
				this.valueChanged = true;
				this.EditingControlDataGridView.NotifyCurrentCellDirty(true);
				base.OnValueChanged(eventargs);
			}

			public void PrepareEditingControlForEdit(bool selectAll)
			{
			}
		}
	}
}