using System;
using System.Collections.Generic;

namespace Connectivity_Pro.Models
{
    public partial class User
    {
        public string FirstName { get; set; } = null!;
        public string? LastName { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public DateTime? Dob { get; set; }
        public int? Gender { get; set; }
    }
        public enum Gender
        {
            Male = 1,
            Female = 2,
            Others = 3
        }
    
       
    
}
