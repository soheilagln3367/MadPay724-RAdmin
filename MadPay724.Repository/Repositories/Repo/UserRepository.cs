using MadPay724.Data.DatabaseContext;
using MadPay724.Repo.Infrastucturs;
using MadPay724.Data.Models;
using MadPay724.Repo.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace MadPay724.Repo.Repositories.Repo
{
    public class UserRepository: Repository<User>, IUserRepository
    {
        private readonly DbContext _db;
        public UserRepository(DbContext dbContext) : base(dbContext)
        {
            _db = (_db ?? (MadPayDbContext)_db);
        }

     

        public async Task<bool> UserExists(string username)
        {
            if (await GetAsync(p => p.UserName == username) != null)
                return true;
            return false;
        }
    }
}
