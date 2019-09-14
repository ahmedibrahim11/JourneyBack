using joureny.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace joureny.Dtos
{
    public class UserDto
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public int MobileNumber { get; set; }
        public Gender Gender { set; get; }
    }
}