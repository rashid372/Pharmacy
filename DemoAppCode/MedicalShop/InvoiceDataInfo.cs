using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalShop
{
  public class InvoiceDataInfo
    {
        private string _saleMan;
        private decimal _totalAmount;
        private decimal _billDiscount;
        private decimal _grandTotal;

        private string _warrantyText;
      
        


        private string _invoiceNo;
        private string _CustomerName;
        private string _CustomerCode;
        private DateTime _Date;
        private decimal _Paid;

        private string _companyName;
        private string _address;
        private string _Phone;


        private string _vocherNo;
        private string _vendor;
        private string _CashVendor;




        private List<InvoiceItemsInfo> _invoiceitem = new List<InvoiceItemsInfo>();

        public decimal TotalAmount
        {
            get { return this._totalAmount; }
            set { this._totalAmount = value; }
        }

        public decimal BillDiscount
        {
            get { return this._billDiscount; }
            set { this._billDiscount = value; }
        }

        public decimal GrandTotal
        {
            get { return this._grandTotal; }
            set { this._grandTotal = value; }
        }

        public string vocherNo
        {
            get { return this._vocherNo; }
            set { this._vocherNo = value; }
        }

        public string Vendor
        {
            get { return this._vendor; }
            set { this._vendor = value; }
        }
        public string WarrantyText
        {
            get { return this._warrantyText; }
            set { this._warrantyText = value; }
        }
        public string SaleMan
        {
            get { return this._saleMan; }
            set { this._saleMan = value; }
        }
        public string CustomerCode
        {
            get {
                return this._CustomerCode;
            }
            set {
                this._CustomerCode = value;
            }
        }
        public string InvoiceNo
        {
            get
            {
                return this._invoiceNo;
            }
            set
            {
                this._invoiceNo = value;
            }
        }

        public string CashVendor
        {
            get
            {
                return this._CashVendor;
            }
            set
            {
                this._CashVendor = value;
            }
        }
        public decimal Paid
        {
            get
            {
                return this._Paid;
            }
            set
            {
                this._Paid = value;
            }
        }

        



        public List<InvoiceItemsInfo> invoiceitem
        {
            get
            { return  this._invoiceitem; }
            set
            {
                this._invoiceitem = value;
            }
        }
        public DateTime SaleDate
        {
            get
            {
                return this._Date;
            }
            set {
                this._Date = value;
            }
        }


        public string CustomerName
        {
            get
            {
                return this._CustomerName;
            }
            set
            {
                this._CustomerName = value;

            }
        }


        public string Phone
        {
            get
            {
                return this._Phone;
            }
            set
            {
                this._Phone = value;
            }
        }

        public string Address
        {
            get
            {
                return this._address;
            }
            set
            {
                this._address = value;
            }
        }
        public string CompanyName
        {
            get
            {
                return this._companyName;
            }
            set
            {
                this._companyName = value;
            }
        }
        //public InvoiceDataInfo()
        //{
        //}
    }
}
