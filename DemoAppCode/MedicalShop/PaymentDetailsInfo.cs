using System;

namespace MedicalShop
{
	internal class PaymentDetailsInfo
	{
		private string _paymentDetailsId;

		private string _paymentMasterId;

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

		public string PaymentDetailsId
		{
			get
			{
				return this._paymentDetailsId;
			}
			set
			{
				this._paymentDetailsId = value;
			}
		}

		public string PaymentMasterId
		{
			get
			{
				return this._paymentMasterId;
			}
			set
			{
				this._paymentMasterId = value;
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

		public PaymentDetailsInfo()
		{
		}
	}
}