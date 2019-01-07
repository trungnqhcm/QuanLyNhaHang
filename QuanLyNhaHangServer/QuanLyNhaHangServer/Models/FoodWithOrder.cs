using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyNhaHangServer.Models
{
    public class FoodWithOrder : BaseModel
    {
        public int Quantities { get; set; }
        public long OrderId { get; set; }
        public long FoodId { get; set; }

        [ForeignKey("OrderId")]
        public virtual Order Order { get; set; }
        [ForeignKey("FoodId")]
        public virtual Food Food { get; set; }
    }
}
