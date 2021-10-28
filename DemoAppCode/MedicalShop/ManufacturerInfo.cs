using System;

namespace MedicalShop
{
	internal class ManufacturerInfo
	{
		private string _manufactureId;

		private string _manufactureName;

		private string _address;

		private string _phone;

		private string _email;

		private string _description;

		public string Address
		{
			get
			{
				return this._address;
			}
			set
			{
				this._address = value;
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

		public string Email
		{
			get
			{
				return this._email;
			}
			set
			{
				this._email = value;
			}
		}

		public string ManufactureId
		{
			get
			{
				return this._manufactureId;
			}
			set
			{
				this._manufactureId = value;
			}
		}

		public string ManufactureName
		{
			get
			{
				return this._manufactureName;
			}
			set
			{
				this._manufactureName = value;
			}
		}

		public string Phone
		{
			get
			{
				return this._phone;
			}
			set
			{
				this._phone = value;
			}
		}

		public ManufacturerInfo()
		{
		}
	}
}