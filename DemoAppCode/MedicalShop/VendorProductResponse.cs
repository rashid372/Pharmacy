using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalShop
{
    class VendorProductResponse
    {
        private string productName;
        private decimal purchaseRate;
        private decimal productPurchaseRate;
        private string productId;
        private string vendorId;

        private string vendorName;

        [System.ComponentModel.Browsable(false)]
      virtual  public string ProductId { get => productId; set => productId = value; }
        [System.ComponentModel.Browsable(false)]
        virtual  public string VendorId { get => vendorId; set => vendorId = value; }
        public string ProductName { get => productName; set => productName = value; }
        public string VendorName { get => vendorName; set => vendorName = value; }
        public decimal PurchaseRate { get => purchaseRate; set => purchaseRate = value; }
        public decimal ProductPurchaseRate { get => productPurchaseRate; set => productPurchaseRate = value; }
    }
}
