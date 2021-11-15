using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeventLibrary.Models
{
    public class EventStands
    {
        private int _id;
        private string _name;
        private Event _event;
        private StandFunctionalities _functionalities;


        public EventStands()
        {

        }
        public EventStands(string name, Event eventModel, StandFunctionalities functionality)
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
        public Event Event
        {
            get { return _event; }
            set { _event = value; }
        }

        public StandFunctionalities Functionalities
        {
            get { return _functionalities; }
            set { _functionalities = value; }
        }

    }
}
