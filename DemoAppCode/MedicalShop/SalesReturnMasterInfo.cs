using System;

namespace MedicalShop
{
	internal class SalesReturnMasterInfo
	{
		private string _salesReturnMasterId;

		private string _salesMasterId;

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

		public string SalesMasterId
		{
			get
			{
				return this._salesMasterId;
			}
			set
			{
				this._salesMasterId = value;
			}
		}

		public string SalesReturnMasterId
		{
			get
			{
				return this._salesReturnMasterId;
			}
			set
			{
				this._salesReturnMasterId = value;
			}
		}

		public SalesReturnMasterInfo()
		{
		}
	}
}