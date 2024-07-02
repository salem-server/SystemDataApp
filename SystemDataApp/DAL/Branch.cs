using System;
using System.Collections.Generic;

namespace SystemDataApp.DAL
{
    public partial class Branch
    {
        public Branch()
        {
            Invoice = new HashSet<Invoice>();
            Product = new HashSet<Product>();
            Users = new HashSet<Users>();
        }

        public int Id { get; set; }
        public int Code { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }

        public ICollection<Invoice> Invoice { get; set; }
        public ICollection<Product> Product { get; set; }
        public ICollection<Users> Users { get; set; }
    }
}
