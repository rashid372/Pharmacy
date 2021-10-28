using System;

namespace MedicalShop
{
	internal class SalesMasterInfo
	{
		private string _salesMasterId;

		private string _salesInvoiceNo;

		private DateTime _date;

		private string _ledgerId;

		private string _doctorId;

		private string _salesManId;

		private string _patientId;

		private decimal _billDiscount;

		private string _description;

		public decimal BillDiscount
		{
			get
			{
				return this._billDiscount;
			}
			set
			{
				this._billDiscount = value;
			}
		}

		public DateTime Date
		{
			get
			{
				return this._date;
			}
			set
			{
				this._date = value;
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

		public string SalesInvoiceNo
		{
			get
			{
				return this._salesInvoiceNo;
			}
			set
			{
				this._salesInvoiceNo = value;
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

		public string SalesMasterId
		{
			get
			{
				return this._salesMasterId;
			}
			set
			{
				this._salesMasterId = value;
			}
		}

		public SalesMasterInfo()
		{
		}
	}
}