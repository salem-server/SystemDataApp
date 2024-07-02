using System;
using System.Collections.Generic;

namespace SystemDataApp.DAL
{
    public partial class Product
    {
        public Product()
        {
            UnitProduct = new HashSet<UnitProduct>();
        }

        public int Id { get; set; }
        public int Code { get; set; }
        public string Name { get; set; }
        public double? Qty { get; set; }
        public bool? IsDeleted { get; set; }
        public bool? IsActive { get; set; }
        public int? IsType { get; set; }
        public int? CategoryCode { get; set; }
        public byte[] Img { get; set; }
        public int? BranchCode { get; set; }
        public int? StoreCode { get; set; }
        public double? Discount { get; set; }
        public double? Tax { get; set; }

        public Branch BranchCodeNavigation { get; set; }
        public Category CategoryCodeNavigation { get; set; }
        public Store StoreCodeNavigation { get; set; }
        public ICollection<UnitProduct> UnitProduct { get; set; }
    }
}
