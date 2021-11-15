using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeventLibrary.Models
{
    public class EventStandModel
    {
        private int _id;
        private string _name;
        private EventModel _event;
        private StandFunctionalityModel _functionalities;


        public EventStandModel()
        {

        }
        public EventStandModel(string name, EventModel eventModel, StandFunctionalityModel functionality)
        {
            Name = name;
            Event = eventModel;
            Functionalities = functionality;
        }

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

    }
}
