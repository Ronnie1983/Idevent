using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeKortLib.Models
{
    public class Role
    {
        private int _id;
        private string _typeName;

        public Role()
        {
        }
        [Key]
        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public string TypeName
        {
            get => _typeName;
            set => _typeName = value;
        }
    }
}
