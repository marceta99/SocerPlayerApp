using Microsoft.EntityFrameworkCore;
using PlayerApi.Data.Interfaces;
using PlayerApi.Models;

namespace PlayerApi.Data.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly ApiDbContext dbContext;

        public PlayerRepository(ApiDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<int> CreatePlayer(Player player)
        {  
        
            dbContext.Players.Add(player);
            await dbContext.SaveChangesAsync();
            return player.PlayerId;
        }

        public async Task<bool> DeletePlayer(int id)
        {
            var player = await dbContext.Players.Where(p => p.PlayerId == id).FirstOrDefaultAsync();
            dbContext.Players.Remove(player);
            await dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<int> EditPlayer(Player player)
        {
            var playerToEdit = await dbContext.Players.Where(p => p.PlayerId == player.PlayerId).FirstOrDefaultAsync();
            playerToEdit.Name = player.Name;
            playerToEdit.JerseyNumber = player.JerseyNumber;
            await dbContext.SaveChangesAsync();
            return player.PlayerId; 

        
        }

        public async Task<List<Player>> GetPlayers()
        {
            var players = await dbContext.Players.ToListAsync();
            return players; 
        }
    }
}
