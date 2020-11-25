using MadPay724.Comman.Helper;
using MadPay724.Data.DatabaseContext;
using MadPay724.Data.Models;
using MadPay724.Repo.Infrastucturs;
using MadPay724.Services.Site.Admin.Auth.Interface;
using System.Threading.Tasks;

namespace MadPay724.Services.Site.Admin.Auth.Services
{
    public class AuthService: IAuthService
    {
        private readonly IUnitOfWork<MadPayDbContext> _db;
        public AuthService(IUnitOfWork<MadPayDbContext> dbContext)
        {
            _db = dbContext;
        }
        public async Task<User> Login(string username, string password)
        {
            var user = await _db.UserRepository.GetAsync(p => p.UserName == username);
            if (user == null)

                return null;
            if (!Utilities.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            return user;
        }

        public async Task<User> Register(User user, string password)
        {
            byte[] passwordHash, passwordSalt;
            Utilities.CreatPasswordHash(password, out passwordHash, out passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            await _db.UserRepository.InsertAsync(user);
            await _db.SaveAsync();
            return user;
        }
    }
}
