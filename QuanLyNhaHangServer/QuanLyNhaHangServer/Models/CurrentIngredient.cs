using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyNhaHangServer.Models
{
    public class CurrentIngredient :BaseModel
    {
        public String Name { get; set; }
        public long UnitId { get; set; }
        public int Quantity { get; set; }

        [ForeignKey("UnitId")]
        public virtual Unit Unit { get; set; }

        public CurrentIngredient(Ingredient ingredient)
        {
            Name = ingredient.Name;
            UnitId = ingredient.UnitId;
            Unit = ingredient.Unit;
        }
    }
}
