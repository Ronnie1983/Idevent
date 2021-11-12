using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeventLibrary.Models
{
    public class Event
    {
        public Event(){}

        public Event(int id, string name, int companyId)
        {
            Id = id;
            Name = name;
            CompanyId = companyId;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int CompanyId { get; set; }
    }
}
