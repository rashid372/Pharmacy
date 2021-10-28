using System;

namespace MedicalShop
{
	internal class LedgerPostingInfo
	{
		private string _ledgerPostingId;

		private string _voucherNumber;

		private string _ledgerId;

		private string _voucherType;

		private decimal _debit;

		private decimal _credit;

		private string _description;

		private DateTime _date;

		public decimal Credit
		{
			get
			{
				return this._credit;
			}
			set
			{
				this._credit = value;
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

		public decimal Debit
		{
			get
			{
				return this._debit;
			}
			set
			{
				this._debit = value;
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

		public string LedgerPostingId
		{
			get
			{
				return this._ledgerPostingId;
			}
			set
			{
				this._ledgerPostingId = value;
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

		public LedgerPostingInfo()
		{
		}
	}
}