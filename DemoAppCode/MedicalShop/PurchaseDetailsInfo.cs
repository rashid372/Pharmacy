using System;

namespace MedicalShop
{
	internal class PurchaseDetailsInfo
	{
		private string _purchaseDetailsId;

		private string _purchaseMasterId;

		private string _productBatchId;

		private decimal _rate;

		private float _discount;

		private decimal _qty;

		private decimal _freeQty;

		private float _taxPercentage;

		private bool _taxIncludedOrNot;

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

		public float Discount
		{
			get
			{
				return this._discount;
			}
			set
			{
				this._discount = value;
			}
		}

		public decimal FreeQty
		{
			get
			{
				return this._freeQty;
			}
			set
			{
				this._freeQty = value;
			}
		}

		public string ProductBatchId
		{
			get
			{
				return this._productBatchId;
			}
			set
			{
				this._productBatchId = value;
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

		public string PurchaseMasterId
		{
			get
			{
				return this._purchaseMasterId;
			}
			set
			{
				this._purchaseMasterId = value;
			}
		}

		public decimal Qty
		{
			get
			{
				return this._qty;
			}
			set
			{
				this._qty = value;
			}
		}

		public decimal Rate
		{
			get
			{
				return this._rate;
			}
			set
			{
				this._rate = value;
			}
		}

		public bool TaxIncludedOrNot
		{
			get
			{
				return this._taxIncludedOrNot;
			}
			set
			{
				this._taxIncludedOrNot = value;
			}
		}

		public float TaxPercentage
		{
			get
			{
				return this._taxPercentage;
			}
			set
			{
				this._taxPercentage = value;
			}
		}

		public PurchaseDetailsInfo()
		{
		}
	}
}