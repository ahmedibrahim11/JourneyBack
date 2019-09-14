using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace joureny.Models
{
    public class UserAnswerQuestionModel
    {
        public long QuestionId { get; set; }

        public long UserId { get; set; }

        public string Value { get; set; }
    }
}