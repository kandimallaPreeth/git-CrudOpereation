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
        [StringLength(30)]
        public string ProductType { get; set; }
        [Required]
        [StringLength(30)]
        public string ProductName { get; set; }
        [Required]
        [StringLength(10)]
        public double Price { get; set; }

    }
}
