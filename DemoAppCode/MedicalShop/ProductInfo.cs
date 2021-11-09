using System;

namespace MedicalShop
{
	internal class ProductInfo
	{
		private string _productId;

		private string _productName;

		private string _productGroupId;

		private string _manufactureId;

		private string _shelfId;

		private string _genericNameId;

		private decimal _stockMinimumLevel;

		private decimal _stockMaximumLevel;

		private string _medicineFor;

		private string _description;

		private string _unitId;
		private decimal _purchaseRate;

		private decimal _salesRate;

		private decimal _packing;

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
		public decimal Packing
		{
			get
			{
				return this._packing;
			}
			set
			{
				this._packing = value;
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

		public string GenericNameId
		{
			get
			{
				return this._genericNameId;
			}
			set
			{
				this._genericNameId = value;
			}
		}

		public string ManufactureId
		{
			get
			{
				return this._manufactureId;
			}
			set
			{
				this._manufactureId = value;
			}
		}

		public string MedicineFor
		{
			get
			{
				return this._medicineFor;
			}
			set
			{
				this._medicineFor = value;
			}
		}

		public string ProductGroupId
		{
			get
			{
				return this._productGroupId;
			}
			set
			{
				this._productGroupId = value;
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

		public string ProductName
		{
			get
			{
				return this._productName;
			}
			set
			{
				this._productName = value;
			}
		}

		public string ShelfId
		{
			get
			{
				return this._shelfId;
			}
			set
			{
				this._shelfId = value;
			}
		}

		public decimal StockMaximumLevel
		{
			get
			{
				return this._stockMaximumLevel;
			}
			set
			{
				this._stockMaximumLevel = value;
			}
		}

		public decimal StockMinimumLevel
		{
			get
			{
				return this._stockMinimumLevel;
			}
			set
			{
				this._stockMinimumLevel = value;
			}
		}

		public string UnitId
		{
			get
			{
				return this._unitId;
			}
			set
			{
				this._unitId = value;
			}
		}

		public ProductInfo()
		{
		}
	}
}