using System;
using System.Collections.Generic;

namespace aut_and_authen.Models
{
    public partial class Anu
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Passeord { get; set; }
        public string? Role { get; set; }
    }
}
