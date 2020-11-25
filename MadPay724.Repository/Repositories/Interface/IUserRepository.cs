using MadPay724.Repo.Infrastucturs;
using MadPay724.Data.Models;
using System.Threading.Tasks;

namespace MadPay724.Repo.Repositories.Interface
{
    public interface IUserRepository: IRepository<User>
    {
        Task<bool> UserExists(string username);

    }
}
