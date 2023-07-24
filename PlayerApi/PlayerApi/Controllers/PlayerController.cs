using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlayerApi.Data.Interfaces;
using PlayerApi.Data.Repositories;
using PlayerApi.Models;

namespace PlayerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly IPlayerRepository playerRepository;

        public PlayersController(IPlayerRepository playerRepository)
        {
            this.playerRepository = playerRepository;
        }


        [HttpGet("GetPlayers")]
        public async Task<IActionResult> GetPlayers()
        {
            var players = await playerRepository.GetPlayers();
            return Ok(players);
        }

        [HttpPost("Post")]
        public async Task<IActionResult> Post([FromBody] Player player)
        {
            var players = await playerRepository.CreatePlayer(player);
            return Ok(players);
        }


        [HttpPut("Put")]
        public async Task<IActionResult> Put([FromBody] Player player)
        {
            var players = await playerRepository.EditPlayer(player);
            return Ok(players);
        }


        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var players = await playerRepository.DeletePlayer(id);
            return Ok(players);
        }

    }
}
