using Microsoft.AspNetCore.Mvc;
using PointsBetChallenge.Model;
using PointsBetChallenge.Repository;
using System;
using System.Net;
using System.Threading.Tasks;

namespace PointsBetChallenge.Controllers
{
    [Produces("application/json")]
    [Route("api/place-bet")]
    public class PlaceBetController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IBetRepository _betRepository;


        public PlaceBetController(IUserRepository userRepository, IBetRepository betRepository)
        {
            _userRepository = userRepository;
            _betRepository = betRepository;
        }
        // GET: api/Game
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return new ObjectResult(await _userRepository.GetAllGames());
        }

        // POST: api/Game
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Bet bet)
        {
            try
            {
                var User = await _userRepository.GetUser(bet.UserId);
                var Balance = User.Balance - bet.Stake;
                if (Balance < 0)
                {
                    // Insuffient funds
                    return BadRequest(new { reason = "insufficient balance" });
                }

                User.Balance = Balance;

                await _userRepository.Update(User);

                await _betRepository.Create(bet);


                return Ok(bet);
            }
            catch(Exception e)
            {
                // LogException(e);
                return StatusCode(500, new { reason = "bet api unavailable" });
            }
            
        }

    }
}
