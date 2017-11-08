using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSheep.Entity
{
    public class FOrderEntity
    {
        public int Id { get; set; }

        public int RoomId { get; set; }

        public int FoodId { get; set; }

        public int Quantity { get; set; }

        public float Price { get; set; }

        public float Amount { get; set; }

        public bool HasFinished { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }
    }
}
