using System;

namespace MedicalShop
{
	internal class ProductBatchInfo
	{
		private string _productBatchId;

		private string _productId;

		private string _batchName;

		private DateTime _expiryDate;

		private decimal _purchaseRate;

		private decimal _salesRate;

		private decimal _MRP;

		private string _description;

		public string BatchName
		{
			get
			{
				return this._batchName;
			}
			set
			{
				this._batchName = value;
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

		public DateTime ExpiryDate
		{
			get
			{
				return this._expiryDate;
			}
			set
			{
				this._expiryDate = value;
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

		public decimal PurchaseRate
		{
			get
			{
				return this._purchaseRate;
			}
			set
			{
				this._purchaseRate = value;
			}
		}

		public decimal SalesRate
		{
			get
			{
				return this._salesRate;
			}
			set
			{
				this._salesRate = value;
			}
		}

		public ProductBatchInfo()
		{
		}
	}
}