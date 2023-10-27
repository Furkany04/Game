using Core.EntityBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTO_s
{
    public class AnswerDTO:EntityBase
    {
        public string AnswerText { get; set; }
        public bool IsCorrect { get; set; }
        public int QuestionID { get; set; }
    }
}
