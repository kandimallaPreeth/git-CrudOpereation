using System;
using System.Collections.Generic;

namespace CRUD_In_MVC.Models
{
    public partial class SignUp
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Role { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string ComformPassword { get; set; } = null!;
    }
}
