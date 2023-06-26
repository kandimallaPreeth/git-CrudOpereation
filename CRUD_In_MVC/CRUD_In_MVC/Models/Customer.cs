using System;
using System.Collections.Generic;

namespace CRUD_In_MVC.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Address { get; set; } = null!;
        public DateTime? DateOfAssociation { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
