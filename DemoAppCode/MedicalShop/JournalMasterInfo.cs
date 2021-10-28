using System;

namespace MedicalShop
{
	internal class JournalMasterInfo
	{
		private string _journalMasterId;

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

		public JournalMasterInfo()
		{
		}
	}
}