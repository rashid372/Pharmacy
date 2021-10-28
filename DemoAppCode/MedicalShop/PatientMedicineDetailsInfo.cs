using System;

namespace MedicalShop
{
	internal class PatientMedicineDetailsInfo
	{
		private string _patientMedicineDetailsId;

		private string _patientId;

		private string _productId;

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

		public string PatientMedicineDetailsId
		{
			get
			{
				return this._patientMedicineDetailsId;
			}
			set
			{
				this._patientMedicineDetailsId = value;
			}
		}

		public string ProductId
		{
			get
			{
				return this._productId;
			}
			set
			{
				this._productId = value;
			}
		}

		public PatientMedicineDetailsInfo()
		{
		}
	}
}