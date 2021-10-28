using System;

namespace MedicalShop
{
	internal class ShelfInfo
	{
		private string _shelfId;

		private string _shelfName;

		private string _shelfDescription;

		public string ShelfDescription
		{
			get
			{
				return this._shelfDescription;
			}
			set
			{
				this._shelfDescription = value;
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

		public string ShelfName
		{
			get
			{
				return this._shelfName;
			}
			set
			{
				this._shelfName = value;
			}
		}

		public ShelfInfo()
		{
		}
	}
}