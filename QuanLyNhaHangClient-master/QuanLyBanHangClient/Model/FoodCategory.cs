using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHangAPI.model.SQL
{
    public class FoodCategory
    {
        [JsonProperty("Id")]
        public int FoodCategoryId { get; set; }

        public String Name { get; set; }

        public FoodCategory()
        {
        }

        public FoodCategory(int foodCategorizeId)
        {
            this.FoodCategoryId = foodCategorizeId;
        }
    }
}
