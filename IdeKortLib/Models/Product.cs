using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeKortLib.Models
{
    public class Product
    {
        private int _id;
        private string _name;
        private int _active;
        private int _event;
        private int _price;

        public Product()
        {
        }
        [Key]
        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public int Active
        {
            get => _active;
            set => _active = value;
        }

        public int Event
        {
            get => _event;
            set => _event = value;
        }

        public int Price
        {
            get => _price;
            set => _price = value;
        }

        public Active ActiveClass { get; set; }
        public Event EventClass { get; set; }

        public override string ToString()
        {
            return $"Name: {Name} Price: {Price}";
        }
    }
}
