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
        
        public EventStandModel EventStandModel 
        { 
            get => eventStandModel; 
            set { 
                eventStandModel = value;
                if(value != null)
                {
                    EventStandId = value.Id;
                }
                
            } 
        }
        public int Amount { get; set; }
        public int EventStandId { get; set; }

        public bool ShouldSerializeEventStandModel()
        {
            return false;
        }

        //public bool ShouldDeserializeEventStandModel()
        //{
        //    return false;
        //}
    }
}
