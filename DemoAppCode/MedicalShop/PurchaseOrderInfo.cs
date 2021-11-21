using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalShop
{
  internal  class PurchaseOrderInfo
    {
        private string _productId;
        private string _vendorId;
        private string _productName;
        private decimal _vendorRate;
        private decimal _productRate;
        private int _quantity;
        private decimal _stock;
        private decimal _runningIndex;
        private DateTime _orderDate;

        [System.ComponentModel.Browsable(false)]
        public string ProductId { get => _productId; set => _productId = value; }
        [System.ComponentModel.Browsable(false)]
        public string VendorId { get => _vendorId; set => _vendorId = value; }
        public string ProductName { get => _productName; set => _productName = value; }
        public int Quantity { get => _quantity; set => _quantity = value; }
        public DateTime OrderDate { get => _orderDate; set => _orderDate = value; }
        public decimal VendorRate { get => _vendorRate; set => _vendorRate = value; }
        public decimal ProductRate { get => _productRate; set => _productRate = value; }
        public decimal Stock { get => _stock; set => _stock = value; }
        public decimal RunningIndex { get => _runningIndex; set => _runningIndex = value; }
    }
}
