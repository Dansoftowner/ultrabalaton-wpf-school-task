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

        private static TimeSpan ParseTimeSpan(string input)
        {
            var parts = input.Split(":").Select(int.Parse).ToList();
            return new TimeSpan(parts[0], parts[1], parts[2]);
        }
    }
}
