using Core.EntityBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTO_s
{
    public class QuestionDTO:EntityBase
    {
        public string QuestionText { get; set; }
        public string DifficultyLevel { get; set; }
        public int PointValue { get; set; }
    }
}
