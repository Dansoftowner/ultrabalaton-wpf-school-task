using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace Ultrabalaton
{
    class Players
    {

        private List<Player> PlayerList;

        public int PlayersCount => PlayerList.Count();
        public List<string> UniqueCategories => PlayerList.Select(it => it.Category).Distinct().ToList();

        public Players(List<Player> playerList)
        {
            PlayerList = playerList;
        }

        public Players(string filePath) : this(
            File.ReadLines(filePath)
                .Skip(1)
                .Select(it => it.Split(";"))
                .Select(it => new Player(
                    it[0],
                    int.Parse(it[1]),
                    it[2],
                    ParseTimeSpan(it[3]),
                    int.Parse(it[4]))
                ).ToList()
        )
        {

        }

        public Player GetByName(string name) => PlayerList.Where(it => it.Name == name).FirstOrDefault();

        public List<Player> GetByCategory(string category) => PlayerList.Where(it => it.Category == category).ToList();

        public List<Player> FinishedPlayersInCategory(string category) => GetByCategory(category).Where(it => it.FinishRate == 100).ToList();

        public int FinishedCountInCategory(string category) => FinishedPlayersInCategory(category).Count();

        public Player WinnerInCategory(string category) => GetByCategory(category)
            .Where(it => it.FinishRate == 100)
            .Aggregate((l, r) => l.AccomplishedTime < r.AccomplishedTime ? l : r);

        private static TimeSpan ParseTimeSpan(string input)
        {
            var parts = input.Split(":").Select(int.Parse).ToList();
            return new TimeSpan(parts[0], parts[1], parts[2]);
        }
    }
}
