using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHangClient.Model
{
    public class TableWithOrder
    {
        [JsonProperty("Id")]
        public int TableWithOrderId { get; set; }

        public int TableId { get; set; }
        public int OrderId { get; set; }

        public TableWithOrder()
        {

        }

        public TableWithOrder(int tableWithOrderId)
        {
            TableWithOrderId = tableWithOrderId;
        }
    }
}
