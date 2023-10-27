using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTO_s
{
    public class UserDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int Score { get; set; }
        public int? HighScore { get; set; }
    }
}
