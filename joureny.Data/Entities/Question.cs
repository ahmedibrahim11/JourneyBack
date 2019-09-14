using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace joureny.Data.Entities
{
    public class Question : Entity<long>
    {
        public string Name { get; set; }
        public string Metadata { get; set; }
        public QuestionType QuestionType { get; set; }

        public QuestionTab QuestionTab { get; set; }

        public bool IsTop { get; set; }
        public bool IsMandatory { get; set; }

        public ICollection<TripQuestion> TripQuestions { get; set; }

        public ICollection<UserAnswerQuestion> UserAnswerQuestion { get; set; }



    }

}
