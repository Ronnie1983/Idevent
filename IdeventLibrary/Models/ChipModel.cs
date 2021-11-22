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
        private int _uid;
        private DateTimeOffset _dateFrom;
        private DateTimeOffset _dateTo;
        private ChipGroupModel _group;
        //private User _userId; TODO: Update ChipModel with UserModel.
        private EventModel _event;
        private CompanyModel _company;
        private List<StandProductModel> _standProducts;

        public ChipModel()
        {
        }

        public ChipModel(int id, int uid, DateTimeOffset dateFrom, DateTimeOffset dateTo, ChipGroupModel @group, EventModel @event, CompanyModel company)
        {
            _id = id;
            _uid = uid;
            _dateFrom = dateFrom;
            _dateTo = dateTo;
            _group = @group;
            _event = @event;
            _company = company;
        }

        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public int Uid
        {
            get => _uid;
            set => _uid = value;
        }

        public DateTimeOffset DateFrom
        {
            get => _dateFrom;
            set => _dateFrom = value;
        }

        public DateTimeOffset DateTo
        {
            get => _dateTo;
            set => _dateTo = value;
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
        public List<StandProductModel> StandProducts {
            get => _standProducts; 
            set => _standProducts = value; 
        }
    }
}
