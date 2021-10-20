using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeKortLib.Models
{
    public class Company
    {
        private int _id;
        private string _companyName;
        private string _cVR;

        public Company()
        {
        }
        [Key]
        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public string CompanyName
        {
            get => _companyName;
            set => _companyName = value;
        }

        public string CVR
        {
            get => _cVR;
            set => _cVR = value;
        }
    }
}
