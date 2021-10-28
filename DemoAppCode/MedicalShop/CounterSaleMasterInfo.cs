using System;

namespace MedicalShop
{
	internal class CounterSaleMasterInfo
	{
		private string _counterSaleMasterId;

		private DateTime _date;

		private string _description;

		public string CounterSaleMasterId
		{
			get
			{
				return this._counterSaleMasterId;
			}
			set
			{
				this._counterSaleMasterId = value;
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

		public CounterSaleMasterInfo()
		{
		}
	}
}