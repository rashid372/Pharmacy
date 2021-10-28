using System;

namespace MedicalShop
{
	internal class GenericNameInfo
	{
		private string _genericNameId;

		private string _genericName;

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

		public string GenericName
		{
			get
			{
				return this._genericName;
			}
			set
			{
				this._genericName = value;
			}
		}

		public string GenericNameId
		{
			get
			{
				return this._genericNameId;
			}
			set
			{
				this._genericNameId = value;
			}
		}

		public GenericNameInfo()
		{
		}
	}
}