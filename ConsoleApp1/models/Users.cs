using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.models
{
    class Users
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Users(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
