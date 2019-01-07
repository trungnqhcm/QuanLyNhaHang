using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyNhaHangServer.Models
{
    public class Food : BaseModel
    {
        public String name { get; set; }
        public decimal Price { get; set; }
        public int? ImageId { get; set; }

        public long FoodCategoryId { get; set; }

        [ForeignKey("FoodCategoryId")]
        public virtual FoodCategory FoodCategory { get; set; }

        public virtual ICollection<IngredientWithFood> IngredientWithFoods { get; set; }
    }
}
