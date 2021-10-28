using System;

namespace MedicalShop
{
	internal class ReminderInfo
	{
		private string _reminderId;

		private DateTime _currentDate;

		private DateTime _reminderDate;

		private string _description;

		public DateTime CurrentDate
		{
			get
			{
				return this._currentDate;
			}
			set
			{
				this._currentDate = value;
			}
		}

		public string Description
		{
			get
			{
				return this._description;
			}
			set
			{
				this._description = value;
			}
		}

		public DateTime ReminderDate
		{
			get
			{
				return this._reminderDate;
			}
			set
			{
				this._reminderDate = value;
			}
		}

		public string ReminderId
		{
			get
			{
				return this._reminderId;
			}
			set
			{
				this._reminderId = value;
			}
		}

		public ReminderInfo()
		{
		}
	}
}