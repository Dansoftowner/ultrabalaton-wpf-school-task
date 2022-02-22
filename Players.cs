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
                    DateTime.ParseExact(it[3], "hh:mm:ss", CultureInfo.InvariantCulture),
                    int.Parse(it[4]))
                ).ToList()
        )
        {

        }
    }
}
