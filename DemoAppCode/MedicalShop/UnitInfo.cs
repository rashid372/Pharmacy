using System;

namespace MedicalShop
{
	internal class UnitInfo
	{
		private string _unitId;

		private string _unitName;

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

		public string UnitName
		{
			get
			{
				return this._unitName;
			}
			set
			{
				this._unitName = value;
			}
		}

		public UnitInfo()
		{
		}
	}
}