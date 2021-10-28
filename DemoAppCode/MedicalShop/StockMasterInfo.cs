using System;

namespace MedicalShop
{
	internal class StockMasterInfo
	{
		private string _stockMasterId;

		private DateTime _date;

		private string _description;

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

		public string StockMasterId
		{
			get
			{
				return this._stockMasterId;
			}
			set
			{
				this._stockMasterId = value;
			}
		}

		public StockMasterInfo()
		{
		}
	}
}