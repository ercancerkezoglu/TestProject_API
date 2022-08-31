using System;
using System.Collections.Generic;

#nullable disable

namespace TestProject.Entity
{
    public partial class User
    {
        public int UserId { get; set; }
        public int? CompanyId { get; set; }
        public string LoginId { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string EmailId { get; set; }
        public string Role { get; set; }
        public bool? Status { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }
        public DateTime? Accessed { get; set; }

        public virtual Company Company { get; set; }
    }
}
