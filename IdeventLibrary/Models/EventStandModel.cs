using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace IdeventLibrary.Models
{
    public class EventStandModel
    {
        private int _id;
        private string _name;
        private EventModel _event = new EventModel();
        private StandFunctionalityModel _functionalities = new StandFunctionalityModel();


        public EventStandModel()
        {

        }
        public EventStandModel(string name, EventModel eventModel, StandFunctionalityModel functionality)
        {
            Name = name;
            Event = eventModel;
            Functionalities = functionality;
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
        
        public EventModel Event
        {
            get { return _event; }
            set { _event = value; }
        }
        
        public StandFunctionalityModel Functionalities
        {
            get { return _functionalities; }
            set { _functionalities = value; }
        }

        public List<StandProductModel> standProducts { get; set; } = new List<StandProductModel>();
        [Required]
        public string NewStandFuncName { get; set; }

    }
}
