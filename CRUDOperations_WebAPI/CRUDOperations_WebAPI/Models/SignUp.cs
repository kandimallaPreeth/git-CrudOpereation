using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUDOperations_WebAPI.Models
{
    public class SignUp
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        [Required]
        [StringLength(50)]
        public string Email { get; set; }
        [Required]
        [StringLength(20)]
        public string Role { get; set; }
        [Required]
        [StringLength(20)]
        [Compare("ComformPassword")]
        public string Password { get; set; }
        [Required]
        [StringLength(20)]
        public string ComformPassword { get; set; }

    }
}
