using System;
using System.Collections.Generic;
using System.Linq;

namespace Football.Service
{
    public class PlayerService
    {
        private readonly IPlayerRepository _playerRepository;

        public PlayerService(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public Player GetTopMiniFootballPlayer()
        {
            var players = _playerRepository.GetPlayers(true);
            return players.OrderByDescending(p => p.Goals).First();
        }

        public void UpdateScore(string name, int goals)
        {
            _playerRepository.UpdateScore(name, goals);
        }
    }

    public interface IPlayerRepository
    {
        List<Player> GetPlayers(bool isMiniFootballer);

        void UpdateScore(string name, int goals);
    }

    public class Player
    {
        public string Name { get; set; }
        public int Goals { get; set; }
        public bool MiniFootBaller { get; set; }
    }
}