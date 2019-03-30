using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace joureny.Data.Entities
{

    public enum Gender
    {
        male,female
    }
    public class User : Entity<long>
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int MobileNumber { get; set; }
        public  string PasswordSalt { get; set; }
        public Role Role { get; set; }
        public Gender Gender { set; get; }

        #region [Trip]
        public virtual ICollection<UserTrips> UserTrips { get; set; }
        #endregion

        #region [UserFeedback]
        public virtual ICollection<Feedback>Feedbacks { get; set; }

        #endregion
    }


}
