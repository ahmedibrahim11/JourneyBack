using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace joureny.Data.Entities
{
   public class TripQuestion
    {
        public long TripId { get; set; }
        public virtual Trip Trip { get; set; }
        public long QuestionId { get; set; }
        public virtual Question Question { get; set; }

    }
}
