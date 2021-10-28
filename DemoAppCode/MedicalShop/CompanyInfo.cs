using System;

namespace MedicalShop
{
	internal class CompanyInfo
	{
		public static string _companyId;

		private string _companyName;

		private string _address;

		private string _country;

		private string _state;

		private string _city;

		private string _pincode;

		private string _fax;

		private string _email;

		private string _website;

		private string _drugLicense;

		private string _tinNumber;

		private string _cstNumber;

		private string _currency;

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

		public string City
		{
			get
			{
				return this._city;
			}
			set
			{
				this._city = value;
			}
		}

		public string CompanyId
		{
			get
			{
				return CompanyInfo._companyId;
			}
			set
			{
				CompanyInfo._companyId = value;
			}
		}

		public string CompanyName
		{
			get
			{
				return this._companyName;
			}
			set
			{
				this._companyName = value;
			}
		}

		public string Country
		{
			get
			{
				return this._country;
			}
			set
			{
				this._country = value;
			}
		}

		public string CstNumber
		{
			get
			{
				return this._cstNumber;
			}
			set
			{
				this._cstNumber = value;
			}
		}

		public string Currency
		{
			get
			{
				return this._currency;
			}
			set
			{
				this._currency = value;
			}
		}

		public string DrugLicense
		{
			get
			{
				return this._drugLicense;
			}
			set
			{
				this._drugLicense = value;
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

		public string Fax
		{
			get
			{
				return this._fax;
			}
			set
			{
				this._fax = value;
			}
		}

		public string Pincode
		{
			get
			{
				return this._pincode;
			}
			set
			{
				this._pincode = value;
			}
		}

		public string State
		{
			get
			{
				return this._state;
			}
			set
			{
				this._state = value;
			}
		}

		public string TinNumber
		{
			get
			{
				return this._tinNumber;
			}
			set
			{
				this._tinNumber = value;
			}
		}

		public string Website
		{
			get
			{
				return this._website;
			}
			set
			{
				this._website = value;
			}
		}

		static CompanyInfo()
		{
			CompanyInfo._companyId = "COMP001";
            CompanyInfo._companyId = (new PrimaryDBSP()).GetCompanyId();
        }

		public CompanyInfo()
		{
		}
	}
}