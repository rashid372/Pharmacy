using System;

namespace MedicalShop
{
	internal class PaymentMasterInfo
	{
		private string _paymentMasterId;

		private DateTime _date;

		private string _ledgerId;

		private string _paymentMode;

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

		public string PaymentMode
		{
			get
			{
				return this._paymentMode;
			}
			set
			{
				this._paymentMode = value;
			}
		}

		public PaymentMasterInfo()
		{
		}
	}
}