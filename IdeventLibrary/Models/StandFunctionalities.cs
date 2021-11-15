using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeventLibrary.Models
{
    public class StandFunctionalities
    {
        private int _id;
        private string _name;

        public StandFunctionalities()
        {
            _id = 0;
            _name = "TestFunction";
        }
        public StandFunctionalities(string name)
        {
            _name = name;
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }


    }
}
