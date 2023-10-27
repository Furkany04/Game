using Core.EntityBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Answer : EntityBase
    {
        public string AnswerText { get; set; }
        public bool IsCorrect { get; set; }
        public int QuestionID { get; set; }
        public Question Question { get; set; }
    }

}
