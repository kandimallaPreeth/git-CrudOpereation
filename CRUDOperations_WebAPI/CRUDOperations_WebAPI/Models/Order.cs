using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CRUDOperations_WebAPI.Models
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime? OrderedDateTime { get; set; }
        [Required]
        [StringLength(10)]
        public double Amount { get; set; }
        public Product? product { get; set; }

        public Customer? customer { get; set; }
    }
}
