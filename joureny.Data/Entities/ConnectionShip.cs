using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace joureny.Data.Entities
{
    public enum ConnectionState
    {
        Requested,Bending,Connected
    }
    public class ConnectionShip
    {
        [Key, Column(Order = 0)]
        public long UserId { get; set; }

        public virtual ICollection<User> Users { get; set; }

        [Key, Column(Order = 1)]

        public long ConnectionId { get; set; }

        public virtual ICollection<User> Connections {get;set;}

        public ConnectionState ConnectionState { get; set; }
    }
}
