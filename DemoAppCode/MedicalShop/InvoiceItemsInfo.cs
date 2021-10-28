using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalShop
{
   public class InvoiceItemsInfo
    {
        private string _productId;
        private string _productName;
        private string _batch;
        private DateTime _expiry;
        private decimal _Rate;
        private string _Quantity;
        private decimal _BillDiscount;
        private decimal _grossAmount;
        private decimal _Totalamount;
        

        public string ProductId
        {
            get
            {
                return this._productId;
            }
            set
            {
                this._productId = value;
            }
        }

        public string ProductName
        {
            get
            {
                return this._productName;
            }
            set
            {
                this._productName = value;
            }
        }
        public string Batch
        {
            get
            {
                return this._batch;
            }
            set
            {
                this._batch = value;
            }
        }
        public DateTime Expiry
        {
            get
            {
                return this._expiry;
            }
            set
            {
                this._expiry = value;
            }
        }
        public decimal Rate
        {
            get
            {
                return this._Rate;
            }
            set
            {
                this._Rate = value;
            }
        }

        public string Quantity
        {
            get
            {
                return this._Quantity;
            }
            set
            {
                this._Quantity = value;
            }
        }

        public decimal BillDiscount
        {
            get
            {
                return this._BillDiscount;
            }
            set
            {
                this._BillDiscount = value;
            }
        }

        public decimal TotalAmount
        {
            get
            {
                return this._Totalamount;
            }
            set
            {
                this._Totalamount = value;
            }
        }

        public decimal GrossAmount
        {
            get
            {
                return _grossAmount;
            }

            set
            {
                _grossAmount = value;
            }
        }

        public InvoiceItemsInfo()
        {
        }


    }
}
