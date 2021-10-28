using System;

namespace MedicalShop
{
	internal class VendorInfo
	{
		private string _vendorId;

		private string _vendorName;

		private string _address;

		private string _country;

		private string _state;

		private string _pinCode;

		private string _phoneNumber;

		private string _mobileNumber;

		private string _emailId;

		private string _ledgerId;

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

		public string EmailId
		{
			get
			{
				return this._emailId;
			}
			set
			{
				this._emailId = value;
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

		public string MobileNumber
		{
			get
			{
				return this._mobileNumber;
			}
			set
			{
				this._mobileNumber = value;
			}
		}

		public string PhoneNumber
		{
			get
			{
				return this._phoneNumber;
			}
			set
			{
				this._phoneNumber = value;
			}
		}

		public string PinCode
		{
			get
			{
				return this._pinCode;
			}
			set
			{
				this._pinCode = value;
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

		public string VendorId
		{
			get
			{
				return this._vendorId;
			}
			set
			{
				this._vendorId = value;
			}
		}

		public string VendorName
		{
			get
			{
				return this._vendorName;
			}
			set
			{
				this._vendorName = value;
			}
		}

		public VendorInfo()
		{
		}
	}
}