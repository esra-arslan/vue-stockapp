using System;
using System.Collections.Generic;

namespace firtApiProject.Models
{
    public partial class user
    {
        public int id { get; set; }
        public string? name { get; set; }
        public string? surname { get; set; }
        public string email { get; set; } = null!;
        public string password { get; set; } = null!;
        public string? phoneNumber { get; set; }
        public string? role { get; set; }
    }
}
