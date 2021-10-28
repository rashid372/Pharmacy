using System;

namespace MedicalShop
{
	internal class GreetingTextInfo
	{
		private string _greetingTextId;

		private DateTime _fromDate;

		private DateTime _toDate;

		private string _greetingMessage;

		private string _description;

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

		public DateTime FromDate
		{
			get
			{
				return this._fromDate;
			}
			set
			{
				this._fromDate = value;
			}
		}

		public string GreetingMessage
		{
			get
			{
				return this._greetingMessage;
			}
			set
			{
				this._greetingMessage = value;
			}
		}

		public string GreetingTextId
		{
			get
			{
				return this._greetingTextId;
			}
			set
			{
				this._greetingTextId = value;
			}
		}

		public DateTime ToDate
		{
			get
			{
				return this._toDate;
			}
			set
			{
				this._toDate = value;
			}
		}

		public GreetingTextInfo()
		{
		}
	}
}