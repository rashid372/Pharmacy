using System;

namespace MedicalShop
{
	internal class DoctorInfo
	{
		private string _doctorId;

		private string _doctorName;

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

		public string DoctorId
		{
			get
			{
				return this._doctorId;
			}
			set
			{
				this._doctorId = value;
			}
		}

		public string DoctorName
		{
			get
			{
				return this._doctorName;
			}
			set
			{
				this._doctorName = value;
			}
		}

		public DoctorInfo()
		{
		}
	}
}