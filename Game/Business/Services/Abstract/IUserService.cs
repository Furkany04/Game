using Dal.Repositorires.Abstract;
using Model.Entities;

namespace Business.Services.Abstract
{
    public interface IUserService : IRepository<User>
    {
    }
}
