using System;
using System.Collections.Generic;

namespace SystemDataApp.DAL
{
    public partial class InvoiceDetails
    {
        public int Id { get; set; }
        public int? Num { get; set; }
        public int? InvoiceCode { get; set; }
        public int? ProductCode { get; set; }
        public double? Price { get; set; }
        public double? Qty { get; set; }
        public double? Amount { get; set; }
        public double? Discount { get; set; }
        public double? DiscountValue { get; set; }
        public double? AmountAfterDiscount { get; set; }
        public double? Tax { get; set; }
        public double? TaxValue { get; set; }
        public double? AmountAfterTax { get; set; }
        public int? UnitProductCode { get; set; }
        public double? Fator { get; set; }
        public int? StoreCode { get; set; }

        public Invoice InvoiceCodeNavigation { get; set; }
        public Store StoreCodeNavigation { get; set; }
        public UnitProduct UnitProductCodeNavigation { get; set; }
    }
}
