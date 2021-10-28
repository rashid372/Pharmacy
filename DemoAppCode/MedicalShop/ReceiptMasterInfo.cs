using System;

namespace MedicalShop
{
	internal class ReceiptMasterInfo
	{
		private string _receiptMasterId;

		private DateTime _date;

		private string _ledgerId;

		private string _receiptMode;

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

		public string ReceiptMode
		{
			get
			{
				return this._receiptMode;
			}
			set
			{
				this._receiptMode = value;
			}
		}

		public ReceiptMasterInfo()
		{
		}
	}
}