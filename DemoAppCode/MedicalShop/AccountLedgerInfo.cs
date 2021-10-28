using System;

namespace MedicalShop
{
	internal class AccountLedgerInfo
	{
		private string _ledgerId;

		private string _acccountLedgerName;

		private string _accountGroupId;

		private decimal _openingBalance;

		private bool _debitOrCredit;

		private string _description;

		private bool _defaultOrNot;

		public string AcccountLedgerName
		{
			get
			{
				return this._acccountLedgerName;
			}
			set
			{
				this._acccountLedgerName = value;
			}
		}

		public string AccountGroupId
		{
			get
			{
				return this._accountGroupId;
			}
			set
			{
				this._accountGroupId = value;
			}
		}

		public bool DebitOrCredit
		{
			get
			{
				return this._debitOrCredit;
			}
			set
			{
				this._debitOrCredit = value;
			}
		}

		public bool DefaultOrNot
		{
			get
			{
				return this._defaultOrNot;
			}
			set
			{
				this._defaultOrNot = value;
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

		public decimal OpeningBalance
		{
			get
			{
				return this._openingBalance;
			}
			set
			{
				this._openingBalance = value;
			}
		}

		public AccountLedgerInfo()
		{
		}
	}
}