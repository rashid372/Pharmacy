using System;

namespace MedicalShop
{
	internal class CompanyPathInfo
	{
		private string _companyId;

		private string _companyName;

		private string _path;

		private bool _defaultOrNot;

		public string CompanyId
		{
			get
			{
				return this._companyId;
			}
			set
			{
				this._companyId = value;
			}
		}

		public string CompanyName
		{
			get
			{
				return this._companyName;
			}
			set
			{
				this._companyName = value;
			}
		}

		public bool DefaultOrNot
		{
			get
			{
				return this._defaultOrNot;
			}
			set
			{
				this._defaultOrNot = value;
			}
		}

		public string Path
		{
			get
			{
				return this._path;
			}
			set
			{
				this._path = value;
			}
		}

		public CompanyPathInfo()
		{
		}
	}
}