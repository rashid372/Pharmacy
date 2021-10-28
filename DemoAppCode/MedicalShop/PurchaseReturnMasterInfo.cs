using System;

namespace MedicalShop
{
	internal class PurchaseReturnMasterInfo
	{
		private string _purchaseReturnMasterId;

		private string _purchaseMasterId;

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

		public string PurchaseMasterId
		{
			get
			{
				return this._purchaseMasterId;
			}
			set
			{
				this._purchaseMasterId = value;
			}
		}

		public string PurchaseReturnMasterId
		{
			get
			{
				return this._purchaseReturnMasterId;
			}
			set
			{
				this._purchaseReturnMasterId = value;
			}
		}

		public PurchaseReturnMasterInfo()
		{
		}
	}
}