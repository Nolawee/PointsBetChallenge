
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
    public class UserRepository : IUserRepository
    {
        private readonly IUserContext _context;

        public UserRepository(IUserContext context)
        {
            _context = context;
        }

        public async Task Create(User game)
        {
            await _context.Users.InsertOneAsync(game);
        }

        public async Task<bool> Delete(string userId)
        {
            FilterDefinition<User> filter = Builders<User>.Filter.Eq(m => m.UserId, userId);

            DeleteResult deleteResult = await _context
                                            .Users
                                            .DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged
            && deleteResult.DeletedCount > 0;
        }

        public async Task<IEnumerable<User>> GetAllGames()
        {
            return await _context.Users.Find(_ => true).ToListAsync();
        }

        public Task<User> GetUser(string userId)
        {
            FilterDefinition<User> filter = Builders<User>.Filter.Eq(m => m.UserId, userId);
            return _context.Users.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<bool> Update(User user)
        {
            ReplaceOneResult updateResult = await _context.Users.ReplaceOneAsync(filter: g => g.Id == user.Id, replacement: user);

            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }

    }
}
