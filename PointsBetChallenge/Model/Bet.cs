using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointsBetChallenge.Model
{
    public class Bet
    {
        [BsonId]
        public ObjectId BetId { get; set; }
        public string UserId { get; set; }
        public int Stake { get; set; }
    }
}
