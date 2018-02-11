using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChampionsLeague
{
    class Program
    {
        static void Main(string[] args)
        {
            var teamData = new Dictionary<string, Team>();

            var input = "";
            while ((input=Console.ReadLine())!="stop")
            {
                var data = input.Split('|').Select(i => i.Trim()).ToArray();

                var team1 = data[0];
                var team2 = data[1];
                var result1 = data[2];
                var result2 = data[3];
                var winningTeam = GetWinningTeam(team1, team2, result1, result2);

                if (!teamData.ContainsKey(team1))
                {
                    teamData.Add(team1, new Team { Wins = 0, Opponents = new List<string>() });
                }

                if (!teamData.ContainsKey(team2))
                {
                    teamData.Add(team2, new Team { Wins = 0, Opponents = new List<string>() });
                }

                if (team1 == winningTeam)
                    teamData[team1].Wins++;
                else
                    teamData[team2].Wins++;

                teamData[team1].Opponents.Add(team2);
                teamData[team2].Opponents.Add(team1);
            }

            foreach (var team in teamData.OrderByDescending(t=>t.Value.Wins).ThenBy(t=>t.Key))
            {
                Console.WriteLine(team.Key);
                Console.WriteLine($"- Wins: {team.Value.Wins}");
                Console.WriteLine($"- Opponents: {String.Join(", ",team.Value.Opponents.OrderBy(t=>t))}");
            }
        }

        private static string GetWinningTeam(string team1, string team2, string result1, string result2)
        {
            //Barcelona | Real Madrid | 2:1 | 3:2
            //team1        team2       t1:t2  t2:t1
            var team1Game1Goals = int.Parse(result1[0].ToString());
            var team2Game1Goals = int.Parse(result1[2].ToString());

            var team1Game2Goals = int.Parse(result2[2].ToString());
            var team2Game2Goals = int.Parse(result2[0].ToString());

            if (team1Game1Goals + team1Game2Goals > team2Game1Goals + team2Game2Goals)
                return team1;
            if (team2Game1Goals + team2Game2Goals > team1Game1Goals + team1Game2Goals)
                return team2;

            if (team1Game2Goals > team2Game1Goals)
                return team1;
            if (team1Game2Goals < team2Game1Goals)
                return team2;

            return "";
        }
    }

    class Team
    {
        public int Wins { get; set; }
        public List<string> Opponents { get; set; }
    }
}
