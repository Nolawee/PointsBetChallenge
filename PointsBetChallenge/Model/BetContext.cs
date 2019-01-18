using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace PointsBetChallenge.Model
{
    public class BetContext : IBetContext
    {
        private readonly IMongoDatabase _db;

        public BetContext(IOptions<Settings> options)
        {
            var client = new MongoClient(options.Value.ConnectionString);
            _db = client.GetDatabase(options.Value.Database);
        }
        public IMongoCollection<Bet> Bets => _db.GetCollection<Bet>("Bets");
    }
}
