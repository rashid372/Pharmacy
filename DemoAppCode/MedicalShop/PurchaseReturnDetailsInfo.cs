using System;

namespace MedicalShop
{
	internal class PurchaseReturnDetailsInfo
	{
		private string _purchaseReturnDetailsId;

		private string _purchaseReturnMasterId;

		private string _purchaseDetailsId;

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

		public string PurchaseDetailsId
		{
			get
			{
				return this._purchaseDetailsId;
			}
			set
			{
				this._purchaseDetailsId = value;
			}
		}

		public string PurchaseReturnDetailsId
		{
			get
			{
				return this._purchaseReturnDetailsId;
			}
			set
			{
				this._purchaseReturnDetailsId = value;
			}
		}

		public string PurchaseReturnMasterId
		{
			get
			{
				return this._purchaseReturnMasterId;
			}
			set
			{
				this._purchaseReturnMasterId = value;
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

		public PurchaseReturnDetailsInfo()
		{
		}
	}
}