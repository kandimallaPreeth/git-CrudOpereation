using System;
using System.Collections.Generic;

namespace CRUD_In_MVC.Models
{
    public partial class Order
    {
        public int Id { get; set; }
        public DateTime? OrderedDateTime { get; set; }
        public double Amount { get; set; }
        public int? ProductId { get; set; }
        public int? CustomerId { get; set; }

        public virtual Customer? Customer { get; set; }
        public virtual Product? Product { get; set; }
    }
}
