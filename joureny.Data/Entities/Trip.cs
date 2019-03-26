using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace joureny.Data.Entities
{
   public class Trip:Entity<long>
    {
        public string TripName { get; set; }
        public virtual ICollection<UserTrips> UserTrips { get; set; }
    }
}
