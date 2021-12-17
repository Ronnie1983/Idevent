using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeventLibrary.Models
{
    public class ChipContentModel
    {
        

        public ChipContentModel()
        {

        }
        public ChipContentModel(StandProductModel standProduct, int chipId, int groupId)
        {
            StandProduct = standProduct;
            ChipId = chipId;
            GroupId = groupId;
        }

        public ChipContentModel(StandProductModel standProduct, int chipId)
        {
            StandProduct = standProduct;
            ChipId = chipId;
            
        }

        public int Id { get; set; }
        public StandProductModel StandProduct { get; set; }
        public int ChipId { get; set; }
        public int GroupId { get; set; }
    }
}
