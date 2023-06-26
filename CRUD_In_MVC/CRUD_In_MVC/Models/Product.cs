using System;
using System.Collections.Generic;

namespace CRUD_In_MVC.Models
{
    public partial class Product
    {
        public Product()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string ProductType { get; set; } = null!;
        public string ProductName { get; set; } = null!;
        public double Price { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
