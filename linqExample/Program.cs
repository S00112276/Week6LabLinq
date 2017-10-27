using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linqExample
{

    public class Player
    {
        Guid _id;
        string _name;
        int _xp;

        public Guid Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public int Xp { get => _xp; set => _xp = value; }

        public override string ToString()
        {
            return _id.ToString() + " " + _name.ToString() + " " + _xp.ToString();
        }
    }

    class Program
    {
        static List<Player> players = new List<Player>()
        {
            new Player { Id = Guid.NewGuid(), Name = "Robbin Williams", Xp=300},
            new Player { Id = Guid.NewGuid(), Name = "Jim Carrey", Xp=200},
            new Player { Id = Guid.NewGuid(), Name = "Richard Pryor", Xp=100},
            new Player { Id = Guid.NewGuid(), Name = "Gene Wilder", Xp=400}
        };

        static void Main(string[] args)
        {
            #region equals
            // Return the first occurance of the match or null
            Console.WriteLine("         -*-*-*- Thats name = Gene Wilder -*-*-*-");
            Player found = players.FirstOrDefault(p => p.Name == "Gene Wilder");
            if(found != null)
                Console.WriteLine("{0}", found.ToString());
            else Console.WriteLine("Not found");
            #endregion

            #region contains
            // Return the first occurance of the match or null
            Console.WriteLine();
            Console.WriteLine("         -*-*-*- First that contains 'Pryor' -*-*-*-");
            Player found1 = players.FirstOrDefault(p => p.Name.Contains("Pryor"));
            if (found != null)
                Console.WriteLine("First found {0}", found1.ToString());
            else Console.WriteLine("Not found");
            #endregion

            #region topPlayers
            // Return all those with an XP value over 200
            Console.WriteLine();
            Console.WriteLine("         -*-*-*- Top Players -*-*-*-");
            List<Player> topPlayers = players.Where(plr => plr.Xp >= 200).ToList();

            if (topPlayers.Count > 0)
                foreach (var item in topPlayers)
                {
                    Console.WriteLine("{0}", item.ToString());
                }
            else Console.WriteLine("No match found");

            // Score board
            Console.WriteLine();
            Console.WriteLine("         -*-*-*- Score Board -*-*-*-");
            var ScoreBoard = players
                                    .OrderByDescending(o => o.Xp)
                                    .Select( scores => new { scores.Name, scores.Xp });
            foreach (var item in ScoreBoard)
            {
                Console.WriteLine("{0,-15} {1,20}", item.Name, item.Xp);
            }

            Console.ReadKey();
            #endregion
        }
    }
}