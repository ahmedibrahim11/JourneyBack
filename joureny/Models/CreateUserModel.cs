using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace joureny.Models
{
    public class CreateUserModel
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}