using System;
using System.Collections.Generic;
using System.Text;

namespace Ultrabalaton
{
    class Player
    {

        public string Name { get; set; }
        public int Number { get; set; }
        public string Category { get; set; }
        public DateTime AccomplishedTime { get; set; }
        public int FinishRate { get; set; }

        public Player(string name, int number, string category, DateTime accomplishedTime, int finishRate)
        {
            Name = name;
            Number = number;
            Category = category;
            AccomplishedTime = accomplishedTime;
            FinishRate = finishRate;
        }
    }
}
