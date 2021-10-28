using System;

namespace MedicalShop
{
	internal class ReceiptDetailsInfo
	{
		private string _receiptDetailsId;

		private string _receiptMasterId;

		private string _ledgerId;

		private string _voucherNumber;

		private string _voucherType;

		private decimal _amount;

		private string _chequeNumber;

		private DateTime _chequeDate;

		private string _description;

		public decimal Amount
		{
			get
			{
				return this._amount;
			}
			set
			{
				this._amount = value;
			}
		}

		public DateTime ChequeDate
		{
			get
			{
				return this._chequeDate;
			}
			set
			{
				this._chequeDate = value;
			}
		}

		public string ChequeNumber
		{
			get
			{
				return this._chequeNumber;
			}
			set
			{
				this._chequeNumber = value;
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

		public string ReceiptDetailsId
		{
			get
			{
				return this._receiptDetailsId;
			}
			set
			{
				this._receiptDetailsId = value;
			}
		}

		public string ReceiptMasterId
		{
			get
			{
				return this._receiptMasterId;
			}
			set
			{
				this._receiptMasterId = value;
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

		public ReceiptDetailsInfo()
		{
		}
	}
}