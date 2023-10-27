using Core.EntityBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Game : EntityBase
    {
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string? Status { get; set; }
    }
}
