using System;

namespace MedicalShop
{
	internal class JournalDetailsInfo
	{
		private string _journalDetailsId;

		private string _journalMasterId;

		private string _ledgerId;

		private decimal _debit;

		private decimal _credit;

		private string _description;

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

		public string JournalDetailsId
		{
			get
			{
				return this._journalDetailsId;
			}
			set
			{
				this._journalDetailsId = value;
			}
		}

		public string JournalMasterId
		{
			get
			{
				return this._journalMasterId;
			}
			set
			{
				this._journalMasterId = value;
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

		public JournalDetailsInfo()
		{
		}
	}
}