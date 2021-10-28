using System;

namespace MedicalShop
{
	internal class FinacialYearInfo
	{
		private string _finacialYearId;

		public static DateTime _fromDate;

		public static DateTime _toDate;

		public static bool _activeOrNot;

		public bool ActiveOrNot
		{
			get
			{
				return FinacialYearInfo._activeOrNot;
			}
			set
			{
				FinacialYearInfo._activeOrNot = value;
			}
		}

		public string FinacialYearId
		{
			get
			{
				return this._finacialYearId;
			}
			set
			{
				this._finacialYearId = value;
			}
		}

		public DateTime FromDate
		{
			get
			{
				return FinacialYearInfo._fromDate;
			}
			set
			{
				FinacialYearInfo._fromDate = value;
			}
		}

		public DateTime ToDate
		{
			get
			{
				return FinacialYearInfo._toDate;
			}
			set
			{
				FinacialYearInfo._toDate = value;
			}
		}

		public FinacialYearInfo()
		{
		}
	}
}