using System;

namespace MedicalShop
{
	internal class DamageStockDetailsInfo
	{
		private string _damageStockDetailsId;

		private string _damageStockMasterId;

		private string _productBatchId;

		private decimal _qty;

		private string _description;

		public string DamageStockDetailsId
		{
			get
			{
				return this._damageStockDetailsId;
			}
			set
			{
				this._damageStockDetailsId = value;
			}
		}

		public string DamageStockMasterId
		{
			get
			{
				return this._damageStockMasterId;
			}
			set
			{
				this._damageStockMasterId = value;
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

		public DamageStockDetailsInfo()
		{
		}
	}
}