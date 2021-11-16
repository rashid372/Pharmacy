using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalShop
{
    class VendorProductResponse
    {
        private string productId;
        private string vendorId;
        private string productName;
        private string vendorName;
        private float purchaseRate;

        public string ProductId { get => productId; set => productId = value; }
        public string VendorId { get => vendorId; set => vendorId = value; }
        public string ProductName { get => productName; set => productName = value; }
        public string VendorName { get => vendorName; set => vendorName = value; }
        public float PurchaseRate { get => purchaseRate; set => purchaseRate = value; }
    }
}
