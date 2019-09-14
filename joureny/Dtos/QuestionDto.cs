using joureny.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace joureny.Dtos
{
    public class QuestionDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Metadata { get; set; }
        public QuestionType QuestionType { get; set; }
        public QuestionTab QuestionTab { get; set; }
        public bool IsTop { get; set; }
        public bool IsMandatory { get; set; }
    }
}