using System;

namespace MedicalShop
{
	internal class DamageStcokMasterInfo
	{
		private string _damageStockMasterId;

		private DateTime _date;

		private string _description;

		public string DamageStockMasterId
		{
			get
			{
				return this._damageStockMasterId;
			}
			set
			{
				this._damageStockMasterId = value;
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

		public DamageStcokMasterInfo()
		{
		}
	}
}