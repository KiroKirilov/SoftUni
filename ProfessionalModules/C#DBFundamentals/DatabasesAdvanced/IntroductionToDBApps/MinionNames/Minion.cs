using System;
using System.Collections.Generic;
using System.Text;

namespace MinionNames
{
    class Minion
    {
        public Minion(string minionName,int age)
        {
            this.MinionName = minionName;
            this.Age = age;
        }

        public string MinionName { get; set; }

        public int Age { get; set; }

        public override string ToString()
        {
            return $"{this.MinionName} {this.Age}";
        }
    }
}
