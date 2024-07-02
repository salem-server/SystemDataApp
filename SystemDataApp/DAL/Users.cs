using System;
using System.Collections.Generic;

namespace SystemDataApp.DAL
{
    public partial class Users
    {
        public Users()
        {
            Invoice = new HashSet<Invoice>();
        }

        public int Id { get; set; }
        public int Code { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Tel { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public bool? IsAdmin { get; set; }
        public int? BranchCode { get; set; }

        public Branch BranchCodeNavigation { get; set; }
        public ICollection<Invoice> Invoice { get; set; }
    }
}
