using System;

namespace MedicalShop
{
	internal class StockPostingInfo
	{
		private string _serialNumber;

		private string _voucherNumber;

		private string _productBatchId;

		private decimal _inwardQuantity;

		private decimal _outwardQuantity;

		private string _voucherType;

		private string _description;

		private DateTime _date;

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

		public decimal InwardQuantity
		{
			get
			{
				return this._inwardQuantity;
			}
			set
			{
				this._inwardQuantity = value;
			}
		}

		public decimal OutwardQuantity
		{
			get
			{
				return this._outwardQuantity;
			}
			set
			{
				this._outwardQuantity = value;
			}
		}

		public string ProductBatchId
		{
			get
			{
				return this._productBatchId;
			}
			set
			{
				this._productBatchId = value;
			}
		}

		public string SerialNumber
		{
			get
			{
				return this._serialNumber;
			}
			set
			{
				this._serialNumber = value;
			}
		}

		public string VoucherNumber
		{
			get
			{
				return this._voucherNumber;
			}
			set
			{
				this._voucherNumber = value;
			}
		}

		public string VoucherType
		{
			get
			{
				return this._voucherType;
			}
			set
			{
				this._voucherType = value;
			}
		}

		public StockPostingInfo()
		{
		}
	}
}