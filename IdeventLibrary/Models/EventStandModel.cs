using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace IdeventLibrary.Models
{
    public class EventStandModel
    {
        private int _id;
        private string _name;
        private EventModel _event = new EventModel();
        private StandFunctionalityModel _functionality = new StandFunctionalityModel();
        public EventStandModel()
        {

        }
        public EventStandModel(string name, EventModel eventModel, StandFunctionalityModel functionality)
        {
            Name = name;
            Event = eventModel;
            Functionality = functionality;
        }
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        [Required]
        [MinLength(1)]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
       //[JsonIgnore]
        public EventModel Event
        {
            get { return _event; }
            set 
            { 
                _event = value; 
                EventID = value.Id;
            }
        }
        public int EventID { get; set; }
        [Required]
        public StandFunctionalityModel Functionality
        {
            get { return _functionality; }
            set 
            { 
                _functionality = value;
                FunctionalityId = value.Id;
            }
        }
        public int FunctionalityId { get; set; }
        public List<StandProductModel> standProducts { get; set; } = new List<StandProductModel>();

    }
}
