using Business.Services.Abstract;
using Dal.Context;
using Dal.Repositorires.Concreate;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Concrete
{
    public class GameService : Repository<Game>, IGameService
    {
        public GameService(GameDbContext context) : base(context)
        {
            _context = context;
        }
        private GameDbContext _context;
    }
}
