using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace joureny.Data.Entities
{

    public enum ConnectionStatus
    {
        Requested,Pending,Connected,Rejected,WaitingForReview
    }
    public class UserConnection:Entity<long>
    {
        public long UserId { get; set; }
        public long ConnectionId { get; set; }
        public ConnectionStatus ConnectionStatus { get; set; }
    }
}
