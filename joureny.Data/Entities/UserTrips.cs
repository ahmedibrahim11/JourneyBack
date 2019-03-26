using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace joureny.Data.Entities
{
   public class UserTrips
    {
        public long  UserId{ get; set; }
        public virtual User User { get; set; }

        public long TripId { get; set; }
        public virtual Trip Trip { get; set; }
    }
}
