using System;
using System.Collections.Generic;

namespace SystemDataApp.DAL
{
    public partial class UnitName
    {
        public UnitName()
        {
            UnitProduct = new HashSet<UnitProduct>();
        }

        public int Id { get; set; }
        public int Code { get; set; }
        public string Name { get; set; }

        public ICollection<UnitProduct> UnitProduct { get; set; }
    }
}
