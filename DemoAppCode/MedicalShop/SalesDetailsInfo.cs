using System;

namespace MedicalShop
{
	internal class SalesDetailsInfo
	{
		private string _salesDetailsId;

		private string _salesMasterId;

		private string _productBatchId;

		private decimal _rate;

		private decimal _MRP;

		private decimal _qty;

		private decimal _freeQty;

		private float _discount;

		private bool _directSaleOrNot;

		private bool _taxIncludedOrNot;

		private float _taxPercentage;

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

		public bool DirectSaleOrNot
		{
			get
			{
				return this._directSaleOrNot;
			}
			set
			{
				this._directSaleOrNot = value;
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

		public decimal MRP
		{
			get
			{
				return this._MRP;
			}
			set
			{
				this._MRP = value;
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

		public SalesDetailsInfo()
		{
		}
	}
}