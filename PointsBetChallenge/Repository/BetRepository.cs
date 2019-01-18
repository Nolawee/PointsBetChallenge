
using MongoDB.Driver;
using MongoDB.Driver.Core.Operations;
using PointsBetChallenge.Model;
using PointsBetChallenge.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointsBetChallenge.Repository
{
    public class BetRepository : IBetRepository
    {
        private readonly IBetContext _context;

        public BetRepository(IBetContext context)
        {
            _context = context;
        }

        public async Task Create(Bet game)
        {
            await _context.Bets.InsertOneAsync(game);
        }

        public async Task<bool> Delete(string userId)
        {
            FilterDefinition<Bet> filter = Builders<Bet>.Filter.Eq(m => m.UserId, userId);

            DeleteResult deleteResult = await _context
                                            .Bets
                                            .DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged
            && deleteResult.DeletedCount > 0;
        }

        public async Task<IEnumerable<Bet>> GetAllBets()
        {
            return await _context.Bets.Find(_ => true).ToListAsync();
        }

        public Task<Bet> GetBet(string userId)
        {
            FilterDefinition<Bet> filter = Builders<Bet>.Filter.Eq(m => m.UserId, userId);
            return _context.Bets.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<bool> Update(Bet bet)
        {
            ReplaceOneResult updateResult = await _context.Bets.ReplaceOneAsync(filter: g => g.BetId == bet.BetId, replacement: bet);

            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }

    }
}
