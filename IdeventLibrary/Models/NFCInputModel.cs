using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace IdeventLibrary.Models
{
    public class NFCInputModel
    {
         
        [Required]
        public String Input { get; set; }

        public NFCInputModel()
        {

        }
    }
}

