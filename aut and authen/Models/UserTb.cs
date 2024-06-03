using System;
using System.Collections.Generic;

namespace aut_and_authen.Models
{
    public partial class UserTb
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? City { get; set; }
        public string? Phone { get; set; }
    }
}
