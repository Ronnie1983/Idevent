using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace IdeventLibrary.Models
{
    public class StandProductModel
    {
        private EventStandModel eventStandModel;
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
        [MinLength(1)]
        public string Name { get; set; }
        [Required]
        public int Value { get; set; }
        [JsonIgnore]
        public EventStandModel EventStandModel 
        { 
            get => eventStandModel; 
            set { 
                eventStandModel = value;
                EventStandId = EventStandModel.Id;
            } 
        }
        public int Amount { get; set; }
        public int EventStandId { get; set; }
    }
}
