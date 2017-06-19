using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseService.Models
{
  public class Game
    {
        public IEnumerable<GameList> GameList { get; set; }
    }
    public class GameList {
        public long Id { get; set; }
        public decimal amount { get; set; }
        public DateTime start_at { get; set; }
    }
    public class JoinGame
    {
        public int status { get; set; }
        public string message { get; set; }
    }
}
