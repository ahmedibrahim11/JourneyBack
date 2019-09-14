using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace joureny.Data.Entities
{
   public class UserAnswerQuestion
    {
        public long QuestionId { get; set; }
        public virtual Question Question { get; set; }

        public long UserId { get; set; }
        public virtual User User { get; set; }

        public string Value { get; set; }
    }
}
