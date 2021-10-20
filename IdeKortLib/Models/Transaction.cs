using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeKortLib.Models
{
    public class Transaction
    {
        private int _id;
        private int _operator;
        private int _buyer;
        private int _event;
        private int _amount;

        public Transaction()
        {
        }
        [Key]
        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public int Operator
        {
            get => _operator;
            set => _operator = value;
        }

        public int Buyer
        {
            get => _buyer;
            set => _buyer = value;
        }

        public int Event
        {
            get => _event;
            set => _event = value;
        }

        public int Amount
        {
            get => _amount;
            set => _amount = value;
        }

        public User OperatorClass { get; set; }
        public User BuyerClass { get; set; }
        public Event EventClass { get; set; }
        public Amount AmountClass { get; set; }
    }
}
