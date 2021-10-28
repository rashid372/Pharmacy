using System;

namespace MedicalShop
{
	internal class CounterSaleDetailsInfo
	{
		private string _counterSaleDetailsId;

		private string _counterSaleMasterId;

		private string _productbatchId;

		private decimal _qty;

		private decimal _rate;

		private string _description;

		public string CounterSaleDetailsId
		{
			get
			{
				return this._counterSaleDetailsId;
			}
			set
			{
				this._counterSaleDetailsId = value;
			}
		}

		public string CounterSaleMasterId
		{
			get
			{
				return this._counterSaleMasterId;
			}
			set
			{
				this._counterSaleMasterId = value;
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

		public string ProductbatchId
		{
			get
			{
				return this._productbatchId;
			}
			set
			{
				this._productbatchId = value;
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

		public CounterSaleDetailsInfo()
		{
		}
	}
}