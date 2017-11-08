using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSheep.Entity
{
    public class SOrderEntity
    {
        public int Id { get; set; }

        public int RoomId { get; set; }

        public float Amount { get; set; }

        public int State { get; set; }

        public string UserName { get; set; }

        public string Mobile { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }
    }
}
