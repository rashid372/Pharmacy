using System;

namespace MedicalShop
{
	internal class AccountGroupInfo
	{
		private string _accountGroupId;

		private string _accountGroupName;

		private string _groupUnder;

		private string _description;

		private bool _defaultOrNot;

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

		public string AccountGroupName
		{
			get
			{
				return this._accountGroupName;
			}
			set
			{
				this._accountGroupName = value;
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

		public string GroupUnder
		{
			get
			{
				return this._groupUnder;
			}
			set
			{
				this._groupUnder = value;
			}
		}

		public AccountGroupInfo()
		{
		}
	}
}