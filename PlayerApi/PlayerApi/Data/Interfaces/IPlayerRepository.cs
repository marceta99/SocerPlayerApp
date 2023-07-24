using PlayerApi.Models;

namespace PlayerApi.Data.Interfaces
{
    public interface IPlayerRepository
    {

        Task<List<Player>> GetPlayers();
        Task<int> EditPlayer(Player player);
        Task<int> CreatePlayer(Player player);
        Task<bool> DeletePlayer(int id);

    }
}
