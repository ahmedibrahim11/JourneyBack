using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace joureny.Dtos
{
    public class UserAnswerQuestionDto
    {
        public long  userId{ get; set; }
        public long QuestionId { get; set; }
        public QuestionDto Question { get; set; }
        public string Value { get; set; }

    }
}