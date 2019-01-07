using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyNhaHangServer.Models
{
    public class TableWithOrder : BaseModel
    {
        public long TableId { get; set; }
        public long OrderId { get; set; }

        [ForeignKey("TableId")]
        public virtual Table Table { get; set; }
        [ForeignKey("OrderId")]
        public virtual Order Order { get; set; }
    }
}
