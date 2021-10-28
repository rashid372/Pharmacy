using System;

namespace MedicalShop
{
	internal class PurchaseMasterInfo
	{
		private string _purchaseMasterId;

		private DateTime _date;

		private string _ledgerId;

		private int _dueDays;

		private string _purchaseInvoiceNo;

		private decimal _billDiscount;

		private string _description;

		private decimal _additionalCost;

		private string _vendor;

		public decimal AdditionalCost
		{
			get
			{
				return this._additionalCost;
			}
			set
			{
				this._additionalCost = value;
			}
		}

		public decimal BillDiscount
		{
			get
			{
				return this._billDiscount;
			}
			set
			{
				this._billDiscount = value;
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

		public int DueDays
		{
			get
			{
				return this._dueDays;
			}
			set
			{
				this._dueDays = value;
			}
		}

		public string LedgerId
		{
			get
			{
				return this._ledgerId;
			}
			set
			{
				this._ledgerId = value;
			}
		}

		public string PurchaseInvoiceNo
		{
			get
			{
				return this._purchaseInvoiceNo;
			}
			set
			{
				this._purchaseInvoiceNo = value;
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

		public string VendorId
		{
			get
			{
				return this._vendor;
			}
			set
			{
				this._vendor = value;
			}
		}

		public PurchaseMasterInfo()
		{
		}
	}
}