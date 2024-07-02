using System;
using System.Collections.Generic;

namespace SystemDataApp.DAL
{
    public partial class Store
    {
        public Store()
        {
            InvoiceDetails = new HashSet<InvoiceDetails>();
            Product = new HashSet<Product>();
        }

        public int Id { get; set; }
        public int Code { get; set; }
        public string Name { get; set; }
        public int? BranchCode { get; set; }

        public ICollection<InvoiceDetails> InvoiceDetails { get; set; }
        public ICollection<Product> Product { get; set; }
    }
}
