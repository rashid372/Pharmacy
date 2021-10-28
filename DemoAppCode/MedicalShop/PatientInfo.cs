using System;

namespace MedicalShop
{
	internal class PatientInfo
	{
		private string _patientId;

		private string _name;

		private string _address;

		private string _mobileNo;

		private string _phoneNo;

		private string _description;

		private bool _dailyCustomerOrNot;

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

		public bool DailyCustomerOrNot
		{
			get
			{
				return this._dailyCustomerOrNot;
			}
			set
			{
				this._dailyCustomerOrNot = value;
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

		public string MobileNo
		{
			get
			{
				return this._mobileNo;
			}
			set
			{
				this._mobileNo = value;
			}
		}

		public string Name
		{
			get
			{
				return this._name;
			}
			set
			{
				this._name = value;
			}
		}

		public string PatientId
		{
			get
			{
				return this._patientId;
			}
			set
			{
				this._patientId = value;
			}
		}

		public string PhoneNo
		{
			get
			{
				return this._phoneNo;
			}
			set
			{
				this._phoneNo = value;
			}
		}

		public PatientInfo()
		{
		}
	}
}