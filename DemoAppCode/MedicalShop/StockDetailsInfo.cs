using System;

namespace MedicalShop
{
	internal class StockDetailsInfo
	{
		private string _stockDetailsId;

		private string _stockMasterId;

		private string _productBatchId;

		private decimal _qty;

		private string _description;

		private decimal _rate;

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

		public string StockDetailsId
		{
			get
			{
				return this._stockDetailsId;
			}
			set
			{
				this._stockDetailsId = value;
			}
		}

		public string StockMasterId
		{
			get
			{
				return this._stockMasterId;
			}
			set
			{
				this._stockMasterId = value;
			}
		}

		public StockDetailsInfo()
		{
		}
	}
}