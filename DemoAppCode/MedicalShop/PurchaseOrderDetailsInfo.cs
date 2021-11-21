using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalShop
{
   internal class PurchaseOrderDetailsInfo
    {
        private long _purchaseOrderMasterId;
        private long _purchaseOrderDetailsId;
        private string _productId;
        private decimal _rate;
        private double _discount;
        private decimal _qty;
        private decimal _freeQty;
        private string _productName;
        private string _puchaseOrderTitle;
        private string _vendorId;


        [System.ComponentModel.Browsable(false)]
        public long PurchaseOrderMasterId { get => _purchaseOrderMasterId; set => _purchaseOrderMasterId = value; }
        [System.ComponentModel.Browsable(false)]
        public long PurchaseOrderDetailsId { get => _purchaseOrderDetailsId; set => _purchaseOrderDetailsId = value; }
        [System.ComponentModel.Browsable(false)]
        public string ProductId { get => _productId; set => _productId = value; }
        public decimal Rate { get => _rate; set => _rate = value; }
        public double Discount { get => _discount; set => _discount = value; }
        public decimal Qty { get => _qty; set => _qty = value; }
        public decimal FreeQty { get => _freeQty; set => _freeQty = value; }
        public string ProductName { get => _productName; set => _productName = value; }
        [System.ComponentModel.Browsable(false)]
        public string PuchaseOrderTitle { get => _puchaseOrderTitle; set => _puchaseOrderTitle = value; }
        [System.ComponentModel.Browsable(false)]
        public string VendorId { get => _vendorId; set => _vendorId = value; }
    }
}
