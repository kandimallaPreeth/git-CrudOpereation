using System.ComponentModel.DataAnnotations.Schema;

namespace CRUDOperations_WebAPI.Models
{
    [NotMapped]
    public class Login
    {

        public string UserName {get; set;}
        public string Password { get; set;}
        public string Role { get; set;}
    }
}
