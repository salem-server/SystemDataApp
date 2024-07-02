using System;
using System.Collections.Generic;

namespace SystemDataApp.DAL
{
    public partial class Invoice
    {
        public Invoice()
        {
            InvoiceDetails = new HashSet<InvoiceDetails>();
        }

        public int Id { get; set; }
        public int Code { get; set; }
        public int? InvoiceNum { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? OrderDateAdd { get; set; }
        public int? UserCode { get; set; }
        public int? CustomerSupplierCode { get; set; }
        public int? InvoiceType { get; set; }
        public double? Total { get; set; }
        public double? Pay { get; set; }
        public double? Stay { get; set; }
        public double? Discount { get; set; }
        public double? DiscountValue { get; set; }
        public double? TotalAfterDiscount { get; set; }
        public double? Tax { get; set; }
        public double? TaxValue { get; set; }
        public double? TotalAfterTax { get; set; }
        public int? BranchCode { get; set; }
        public double? CashPay { get; set; }
        public double? VisaPay { get; set; }

        public Branch BranchCodeNavigation { get; set; }
        public CustomerSupplier CustomerSupplierCodeNavigation { get; set; }
        public Users UserCodeNavigation { get; set; }
        public ICollection<InvoiceDetails> InvoiceDetails { get; set; }
    }
}
