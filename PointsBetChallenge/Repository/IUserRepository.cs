using System.Collections.Generic;
using System.Threading.Tasks;
using PointsBetChallenge.Model;

namespace PointsBetChallenge.Repository
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllGames();
        Task<User> GetUser(string userId);
        Task Create(User game);
        Task<bool> Update(User game);
        Task<bool> Delete(string name);
    }
}