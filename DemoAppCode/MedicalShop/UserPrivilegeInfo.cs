using System;

namespace MedicalShop
{
	internal class UserPrivilegeInfo
	{
		private string _privilegeId;

		private string _userId;

		private string _formName;

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

		public string FormName
		{
			get
			{
				return this._formName;
			}
			set
			{
				this._formName = value;
			}
		}

		public string PrivilegeId
		{
			get
			{
				return this._privilegeId;
			}
			set
			{
				this._privilegeId = value;
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

		public UserPrivilegeInfo()
		{
		}
	}
}