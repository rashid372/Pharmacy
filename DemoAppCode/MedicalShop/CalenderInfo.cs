using System;

namespace MedicalShop
{
	internal class CalenderInfo
	{
		private string _calenderId;

		private string _description;

		private DateTime _date;

		public string CalenderId
		{
			get
			{
				return this._calenderId;
			}
			set
			{
				this._calenderId = value;
			}
		}

		public DateTime Date
		{
			get
			{
				return this._date;
			}
			set
			{
				this._date = value;
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

		public CalenderInfo()
		{
		}
	}
}