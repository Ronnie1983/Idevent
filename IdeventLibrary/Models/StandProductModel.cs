using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace IdeventLibrary.Models
{
    public class StandProductModel
    {
        public StandProductModel()
        {
           

        }

        public StandProductModel(string name, int value, EventStandModel eventStand)
        {
            Name = name;
            Value = value;
            EventStandModel = eventStand;
        }
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Value { get; set; }
        public EventStandModel EventStandModel { get; set; }
    }
}
