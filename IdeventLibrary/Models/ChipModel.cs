using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeventLibrary.Models
{
    public class ChipModel
    {
        private int _id;
        private string _hashedId;
        private DateTimeOffset _validFrom;
        private DateTimeOffset _validTo;
        private ChipGroupModel _group;
        //private User _userId; TODO: Update ChipModel with UserModel.
        private EventModel _event;
        private CompanyModel _company;
        private Dictionary<string, int> _productsOnChip;

        public ChipModel()
        {
        }

        public ChipModel(int id, string hashedId, DateTimeOffset dateFrom, DateTimeOffset dateTo, ChipGroupModel @group, EventModel @event, CompanyModel company)
        {
            _id = id;
            _hashedId = hashedId;
            _validFrom = dateFrom;
            _validTo = dateTo;
            _group = @group;
            _event = @event;
            _company = company;
        }

        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public string HashedId
        {
            get => _hashedId;
            set => _hashedId = value;
        }

        public DateTimeOffset ValidFrom
        {
            get => _validFrom;
            set => _validFrom = value;
        }

        public DateTimeOffset ValidTo
        {
            get => _validTo;
            set => _validTo = value;
        }

        public ChipGroupModel Group
        {
            get => _group;
            set => _group = value;
        }

        public EventModel Event
        {
            get => _event;
            set => _event = value;
        }

        public CompanyModel Company
        {
            get => _company;
            set => _company = value;
        }
        public Dictionary<string, int> ProductsOnChip {
            get => _productsOnChip; 
            set => _productsOnChip = value; 
        }
    }
}
