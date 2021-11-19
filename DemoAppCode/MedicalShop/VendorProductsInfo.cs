using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalShop
{
    internal class VendorProductsInfo
    {
        private string _productId;
        private string _vendorId;
        private decimal _purchaseRate;
        private string _createBy;

        public string ProductId { get => _productId; set => _productId = value; }
        public string VendorId { get => _vendorId; set => _vendorId = value; }
        public decimal PurchaseRate { get => _purchaseRate; set => _purchaseRate = value; }
        public string CreateBy { get => _createBy; set => _createBy = value; }
    }
}
