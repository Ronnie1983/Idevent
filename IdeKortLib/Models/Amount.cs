using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeKortLib.Models
{
    public class Amount
    {
        private int _id;
        private int _chip;
        private int _product;
        private int _total;

        public Amount()
        {
        }
        [Key]
        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public int Chip
        {
            get => _chip;
            set => _chip = value;
        }

        public int Product
        {
            get => _product;
            set => _product = value;
        }

        public int Total
        {
            get => _total;
            set => _total = value;
        }

        public Chip ChipClass { get; set; }
        public Product ProductClass { get; set; }

        public override string ToString()
        {
            return $"you can have {Total}";
        }
    }
}
