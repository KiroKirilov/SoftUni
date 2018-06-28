using System;
using System.Collections.Generic;
using System.Text;

namespace RemoveVillain
{
    class Villain
    {
        public Villain(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public int Id { get; set; }

        public string Name { get; set; }
    }
}
