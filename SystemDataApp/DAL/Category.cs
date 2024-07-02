using System;
using System.Collections.Generic;

namespace SystemDataApp.DAL
{
    public partial class Category
    {
        public Category()
        {
            Product = new HashSet<Product>();
        }

        public int Id { get; set; }
        public int Code { get; set; }
        public string Name { get; set; }

        public ICollection<Product> Product { get; set; }
    }
}
