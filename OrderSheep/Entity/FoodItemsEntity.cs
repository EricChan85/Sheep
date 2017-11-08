using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSheep.Entity
{
    public class FoodItemsEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Category { get; set; }

        public float RetailPrice { get; set; }

        public string PicExtension { get; set; }

        public DateTime CreateTime { get; set; }
    }
}
