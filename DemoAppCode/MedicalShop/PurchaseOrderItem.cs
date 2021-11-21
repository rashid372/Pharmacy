using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalShop
{
   internal class PurchaseOrderItem
    {
        private string _productId;
        private string _vendorId;
        private string _productName;
        private decimal _quantity;
        private decimal _amount;

        [System.ComponentModel.Browsable(false)]
        public string ProductId { get => _productId; set => _productId = value; }
        public string ProductName { get => _productName; set => _productName = value; }
        public decimal Quantity { get => _quantity; set => _quantity = value; }
        public decimal Amount { get => _amount; set => _amount = value; }
        [System.ComponentModel.Browsable(false)]
        public string VendorId { get => _vendorId; set => _vendorId = value; }
    }
}
