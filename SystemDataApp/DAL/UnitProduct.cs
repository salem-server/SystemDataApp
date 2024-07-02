using System;
using System.Collections.Generic;

namespace SystemDataApp.DAL
{
    public partial class UnitProduct
    {
        public UnitProduct()
        {
            InvoiceDetails = new HashSet<InvoiceDetails>();
        }

        public int Id { get; set; }
        public int Code { get; set; }
        public string Barcode { get; set; }
        public double? Factor { get; set; }
        public double? PriceBuy { get; set; }
        public double? PriceSale { get; set; }
        public int? ProductCode { get; set; }
        public int? UnitNameCode { get; set; }

        public Product ProductCodeNavigation { get; set; }
        public UnitName UnitNameCodeNavigation { get; set; }
        public ICollection<InvoiceDetails> InvoiceDetails { get; set; }
    }
}
