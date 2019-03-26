using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace joureny.Data.Entities
{
    public class User : Entity<long>
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }

        #region [Trip]
        public virtual ICollection<UserTrips> UserTrips { get; set; }
        #endregion
    }


}
