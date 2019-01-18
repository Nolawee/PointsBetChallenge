using System.Collections.Generic;
using System.Threading.Tasks;
using PointsBetChallenge.Model;

namespace PointsBetChallenge.Repository
{
    public interface IBetRepository
    {
        Task<IEnumerable<Bet>> GetAllBets();
        Task<Bet>GetBet(string betId);
        Task Create(Bet bet);
        Task<bool> Update(Bet bet);
        Task<bool> Delete(string betId);
    }
}