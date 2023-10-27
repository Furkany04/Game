using Business.Services.Abstract;
using Dal.Context;
using Dal.Repositorires.Concreate;
using Microsoft.EntityFrameworkCore;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Concrete
{
    public class AnswerService : Repository<Answer>, IAnswerService
    {
        public AnswerService(GameDbContext context) : base(context)
        {
            _context = context;
        }
        private GameDbContext _context;
        
    
}
}
