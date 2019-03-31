using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace joureny.Dtos
{
    public class UserTripDto
    {
        public virtual UserDto User { get; set; }
        public virtual TripDto Trip { get; set; }
    }
}