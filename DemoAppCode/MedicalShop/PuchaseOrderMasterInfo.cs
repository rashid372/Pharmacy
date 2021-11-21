using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalShop
{
    internal class PuchaseOrderMasterInfo
    {
		private string _vendorId;
	private long _purchaseOrderMasterId;
	private DateTime _orderDate;
	private DateTime _receivingDate;
	private string _puchaseOrderTitle;
	private string _status;
    private string _createdBy;

        [System.ComponentModel.Browsable(false)]
        public string VendorId { get => _vendorId; set => _vendorId = value; }
        [System.ComponentModel.Browsable(false)]
        public long PurchaseOrderMasterId { get => _purchaseOrderMasterId; set => _purchaseOrderMasterId = value; }
        public DateTime OrderDate { get => _orderDate; set => _orderDate = value; }
        public DateTime ReceivingDate { get => _receivingDate; set => _receivingDate = value; }
        public string PuchaseOrderTitle { get => _puchaseOrderTitle; set => _puchaseOrderTitle = value; }
        public string Status { get => _status; set => _status = value; }
        [System.ComponentModel.Browsable(false)]
        public string CreatedBy { get => _createdBy; set => _createdBy = value; }
    }
}
