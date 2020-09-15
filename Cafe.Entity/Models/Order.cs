using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Entity.Models
{
    public class Order
    {
        public int Id { get; set; }
        public long SumPrice { get; set; }
        public bool IsPaid { get; set; }
        public int TableNumber { get; set; }
        public DateTime Time { get; set; }
    }
}
