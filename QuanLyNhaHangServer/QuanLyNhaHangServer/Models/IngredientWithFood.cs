using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyNhaHangServer.Models
{
    public class IngredientWithFood : BaseModel
    {
        public long FoodId { get; set; }
        public long IngredientId { get; set; }
        public float Quantities { get; set; }
        [ForeignKey("FoodId")]
        public virtual Food Food { get; set; }

        [ForeignKey("IngredientId")]
        public virtual Ingredient  Ingredient { get; set; }
    }
}
