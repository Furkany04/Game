using Core.EntityBase;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class User : IdentityUser
    {
        public User() { }
        public User(string userName):base(userName) { }
        public int Score { get; set; } = 0;
        public int HighScore { get; set; } = 0;
    }
}
