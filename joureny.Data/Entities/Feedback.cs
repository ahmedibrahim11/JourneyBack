using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace joureny.Data.Entities
{
   public class Feedback:Entity<long>
    {
        public string Message { get; set; }
        public long UserId { get; set; }
        public virtual  User User  { get; set; }    
    }
}
