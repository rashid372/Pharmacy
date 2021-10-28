using System;

namespace MedicalShop
{
	internal class SalesManInfo
	{
		private string _salesManId;

		private string _salesManName;

		private string _address;

		private string _pinCode;

		private string _Phone;

		private string _mobile;

		private string _email;

		private DateTime _dateOfBirth;

		private DateTime _dateOfJoining;

		private DateTime _dateOfTermination;

		private string _qualification;

		private bool _activeOrNot;

		private string _ledgerId;

		private string _description;

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

		public DateTime DateOfBirth
		{
			get
			{
				return this._dateOfBirth;
			}
			set
			{
				this._dateOfBirth = value;
			}
		}

		public DateTime DateOfJoining
		{
			get
			{
				return this._dateOfJoining;
			}
			set
			{
				this._dateOfJoining = value;
			}
		}

		public DateTime DateOfTermination
		{
			get
			{
				return this._dateOfTermination;
			}
			set
			{
				this._dateOfTermination = value;
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

		public string Mobile
		{
			get
			{
				return this._mobile;
			}
			set
			{
				this._mobile = value;
			}
		}

		public string Phone
		{
			get
			{
				return this._Phone;
			}
			set
			{
				this._Phone = value;
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

		public string Qualification
		{
			get
			{
				return this._qualification;
			}
			set
			{
				this._qualification = value;
			}
		}

		public string SalesManId
		{
			get
			{
				return this._salesManId;
			}
			set
			{
				this._salesManId = value;
			}
		}

		public string SalesManName
		{
			get
			{
				return this._salesManName;
			}
			set
			{
				this._salesManName = value;
			}
		}

		public SalesManInfo()
		{
		}
	}
}