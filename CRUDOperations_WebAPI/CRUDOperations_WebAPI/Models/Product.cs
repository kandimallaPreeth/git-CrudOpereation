using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CRUDOperations_WebAPI.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string ProductType { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public double Price { get; set; }

    }
}
