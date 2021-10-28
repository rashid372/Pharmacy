using System;

namespace MedicalShop
{
	internal class SettingsInfo
	{
		private string _settingsId;

		private bool _automaticProductIdGeneration;

		private string _negativeStockAlertStatus;

		private string _expiryProductTransactionStatus;

		private string _expiryReminderWithin;

		private string _description;

		private bool _expiryReminderNeeded;

		private bool _lowStockAlertStatus;

		public bool AutomaticProductIdGeneration
		{
			get
			{
				return this._automaticProductIdGeneration;
			}
			set
			{
				this._automaticProductIdGeneration = value;
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

		public string ExpiryProductTransactionStatus
		{
			get
			{
				return this._expiryProductTransactionStatus;
			}
			set
			{
				this._expiryProductTransactionStatus = value;
			}
		}

		public bool ExpiryReminderNeeded
		{
			get
			{
				return this._expiryReminderNeeded;
			}
			set
			{
				this._expiryReminderNeeded = value;
			}
		}

		public string ExpiryReminderWithin
		{
			get
			{
				return this._expiryReminderWithin;
			}
			set
			{
				this._expiryReminderWithin = value;
			}
		}

		public bool LowStockAlertStatus
		{
			get
			{
				return this._lowStockAlertStatus;
			}
			set
			{
				this._lowStockAlertStatus = value;
			}
		}

		public string NegativeStockAlertStatus
		{
			get
			{
				return this._negativeStockAlertStatus;
			}
			set
			{
				this._negativeStockAlertStatus = value;
			}
		}

		public string SettingsId
		{
			get
			{
				return this._settingsId;
			}
			set
			{
				this._settingsId = value;
			}
		}

		public SettingsInfo()
		{
		}
	}
}