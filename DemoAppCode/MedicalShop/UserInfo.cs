using System;

namespace MedicalShop
{
	internal class UserInfo
	{
		private string _userId;

		private string _username;

		private string _password;

		private bool _activeOrNot;

		private string _description;

		public static string _currentUserId;

		public bool ActiveOrNot
		{
			get
			{
				return this._activeOrNot;
			}
			set
			{
				this._activeOrNot = value;
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

		public string Password
		{
			get
			{
				return this._password;
			}
			set
			{
				this._password = value;
			}
		}

		public string UserId
		{
			get
			{
				return this._userId;
			}
			set
			{
				this._userId = value;
			}
		}

		public string Username
		{
			get
			{
				return this._username;
			}
			set
			{
				this._username = value;
			}
		}

		static UserInfo()
		{
			UserInfo._currentUserId = "1";
		}

		public UserInfo()
		{
		}
	}
}