using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeKortLib.Models
{
    public class Active
    {
        private int _id;
        private DateTime _activeFrom;
        private DateTime _activeTo;
        private bool _isActive;

        public Active()
        {
        }
        [Key]
        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public DateTime ActiveFrom
        {
            get => _activeFrom;
            set => _activeFrom = value;
        }

        public DateTime ActiveTo
        {
            get => _activeTo;
            set => _activeTo = value;
        }

        public bool IsActive
        {
            get => _isActive;
            set => _isActive = value;
        }
    }
}
