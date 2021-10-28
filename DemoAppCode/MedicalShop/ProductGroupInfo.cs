using System;

namespace MedicalShop
{
	internal class ProductGroupInfo
	{
		private string _productGroupId;

		private string _productGroupName;

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

		public string ProductGroupName
		{
			get
			{
				return this._productGroupName;
			}
			set
			{
				this._productGroupName = value;
			}
		}

		public ProductGroupInfo()
		{
		}
	}
}