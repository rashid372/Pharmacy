using System;

namespace MedicalShop
{
	internal class SalesReturnDetailsInfo
	{
		private string _salesReturnDetailsId;

		private string _salesReturnMasterId;

		private string _salesDetailsId;

		private decimal _returnedQty;

		private decimal _returnedFreeQty;

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

		public decimal ReturnedFreeQty
		{
			get
			{
				return this._returnedFreeQty;
			}
			set
			{
				this._returnedFreeQty = value;
			}
		}

		public decimal ReturnedQty
		{
			get
			{
				return this._returnedQty;
			}
			set
			{
				this._returnedQty = value;
			}
		}

		public string SalesDetailsId
		{
			get
			{
				return this._salesDetailsId;
			}
			set
			{
				this._salesDetailsId = value;
			}
		}

		public string SalesReturnDetailsId
		{
			get
			{
				return this._salesReturnDetailsId;
			}
			set
			{
				this._salesReturnDetailsId = value;
			}
		}

		public string SalesReturnMasterId
		{
			get
			{
				return this._salesReturnMasterId;
			}
			set
			{
				this._salesReturnMasterId = value;
			}
		}

		public SalesReturnDetailsInfo()
		{
		}
	}
}